// -----------------------------------------------------------------------
// <copyright file="WindowsFormsWebAuthenticationDialogBase.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Platforms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using PartnerCenter.Exceptions;
    using PartnerCenter.Models.Authentication;

    /// <summary>
    /// Base class for web form
    /// </summary>
    [ComVisible(true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class WindowsFormsWebAuthenticationDialogBase : Form
    {
        private static readonly HashSet<string> WhiteListedSchemes = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        private const int UIWidth = 566;

        private const string BrowserScheme = "browser";
        private const string JavaScriptScheme = "javascript";
        private const string AboutBlankUri = "about:blank";

        private readonly CustomWebBrowser webBrowser;

        private Keys key = Keys.None;

        private Uri desiredCallbackUri;

        internal AuthorizationResult Result { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WindowsFormsWebAuthenticationDialogBase" /> class.
        /// </summary>
        /// <param name="ownerWindow"></param>
        protected WindowsFormsWebAuthenticationDialogBase(object ownerWindow)
        {
            // From MSDN (http://msdn.microsoft.com/en-us/library/ie/dn720860(v=vs.85).aspx): 
            // The net session count tracks the number of instances of the web browser control. 
            // When a web browser control is created, the net session count is incremented. When the control 
            // is destroyed, the net session count is decremented. When the net session count reaches zero, 
            // the session cookies for the process are cleared. SetQueryNetSessionCount can be used to prevent 
            // the session cookies from being cleared for applications where web browser controls are being created 
            // and destroyed throughout the lifetime of the application. (Because the application lives longer than 
            // a given instance, session cookies must be retained for a longer periods of time.
            int sessionCount = NativeMethods.SetQueryNetSessionCount(NativeMethods.SessionOp.SESSION_QUERY);

            if (sessionCount == 0)
            {
                _ = NativeMethods.SetQueryNetSessionCount(NativeMethods.SessionOp.SESSION_INCREMENT);
            }

            if (ownerWindow == null)
            {
                OwnerWindow = null;
            }
            else if (ownerWindow is IWin32Window)
            {
                OwnerWindow = (IWin32Window)ownerWindow;
            }
            else if (ownerWindow is IntPtr)
            {
                OwnerWindow = new WindowsFormsWin32Window { Handle = (IntPtr)ownerWindow };
            }
            else
            {
                throw new PartnerException("Invalid owner window type. Expected types are IWin32Window or IntPtr (for window handle).");
            }

            webBrowser = new CustomWebBrowser();
            webBrowser.PreviewKeyDown += WebBrowser_PreviewKeyDown;
            InitializeComponent();

            WhiteListedSchemes.Add(BrowserScheme);
        }

        internal IWin32Window OwnerWindow { get; }

        private void WebBrowser_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                key = Keys.Back;
            }
        }

        /// <summary>
        /// Gets Web Browser control used by the dialog.
        /// </summary>
        public WebBrowser WebBrowser => webBrowser;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void WebBrowserNavigatingHandler(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (webBrowser.IsDisposed)
            {
                // we cancel all flows in disposed object and just do nothing, let object to close.
                // it just for safety.
                e.Cancel = true;
                return;
            }

            if (key == Keys.Back)
            {
                //navigation is being done via back key. This needs to be disabled.
                key = Keys.None;
                e.Cancel = true;
            }

            // we cancel further processing, if we reached final URL.
            // Security issue: we prohibit navigation with auth code
            // if redirect URI is URN, then we prohibit navigation, to prevent random browser popup.
            e.Cancel = CheckForClosingUrl(sender, e.Url);

            // check if the url scheme is of type browser://
            // this means we need to launch external browser
            if (!e.Cancel && e.Url.Scheme.Equals(BrowserScheme, StringComparison.OrdinalIgnoreCase))
            {
                // Build the HTTPS URL for launching with an external browser
                UriBuilder httpsUrlBuilder = new UriBuilder(e.Url)
                {
                    Scheme = Uri.UriSchemeHttps
                };

                Process.Start(httpsUrlBuilder.Uri.AbsoluteUri);

                e.Cancel = true;
            }
        }

        private void WebBrowserNavigatedHandler(object sender, WebBrowserNavigatedEventArgs e)
        {
            CheckForClosingUrl(sender, e.Url);
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void WebBrowserNavigateErrorHandler(object sender, WebBrowserNavigateErrorEventArgs e)
        {
            // e.StatusCode - Contains error code which we are able to translate this error to text
            // ADAL.Native contains a code for translation.
            if (DialogResult == DialogResult.OK)
            {
                return;
            }

            if (webBrowser.IsDisposed)
            {
                // we cancel all flow in disposed object.
                e.Cancel = true;
                return;
            }

            if (webBrowser.ActiveXInstance != e.WebBrowserActiveXInstance)
            {
                // this event came from internal frame, ignore this.
                return;
            }

            if (e.StatusCode >= 300 && e.StatusCode < 400)
            {
                // we could get redirect flows here as well.
                return;
            }

            e.Cancel = true;
            StopWebBrowser();
            // in this handler object could be already disposed, so it should be the last method
            OnNavigationCanceled(e.StatusCode);
        }

        private bool CheckForClosingUrl(object sender, Uri url)
        {
            // Make change here
            bool canClose = false;
            if (url.Authority.Equals(desiredCallbackUri.Authority, StringComparison.OrdinalIgnoreCase) &&
                url.AbsolutePath.Equals(desiredCallbackUri.AbsolutePath, StringComparison.OrdinalIgnoreCase))
            {
                if (!(sender is CustomWebBrowser))
                {
                    throw new PartnerException("Invalid web browser type. Expected CustomWebBrowser for the sender object type.");
                }

                if (((CustomWebBrowser)sender).Document == null)
                {
                    throw new PartnerException("Invalid web page response type. WebPage should not be null in the response.");
                }

                Result = new AuthorizationResult(AuthorizationStatus.Success, GetUrlFromDocument(url, ((CustomWebBrowser)sender).Document));
                canClose = true;
            }

            // if redirect_uri is not hit and scheme of the url is not whitelisted and url is not about:blank
            // and url scheme is not https then fail to load.
            if (!canClose && !WhiteListedSchemes.Contains(url.Scheme)
                && !url.AbsoluteUri.Equals(AboutBlankUri, StringComparison.OrdinalIgnoreCase)
                && !url.Scheme.Equals(Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase)
                && !url.Scheme.Equals(JavaScriptScheme, StringComparison.OrdinalIgnoreCase))
            {
                Result = new AuthorizationResult(AuthorizationStatus.ErrorHttp)
                {
                    Error = "non_https_redirect_failed",
                    ErrorDescription = "Non-HTTPS url redirect is not supported in webview"
                };

                canClose = true;
            }

            if (canClose)
            {
                StopWebBrowser();
                // in this handler object could be already disposed, so it should be the last method
                OnClosingUrl();
            }

            return canClose;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static string GetUrlFromDocument(Uri url, HtmlDocument document)
        {
            UriBuilder uriBuilder = new UriBuilder(url);
            List<string> parameters = new List<string>();

            HtmlElementCollection elems = document.GetElementsByTagName("input");
            foreach (HtmlElement elem in elems)
            {
                string name = elem.GetAttribute("name");
                if (!string.IsNullOrEmpty(name))
                {
                    string value = elem.GetAttribute("value");
                    if (!string.IsNullOrEmpty(value))
                    {
                        parameters.Add(string.Format(
                            CultureInfo.InvariantCulture,
                            "{0}={1}",
                            name,
                            elem.GetAttribute("value")));
                    }
                }
            }

            if (parameters.Count == 0)
            {
                throw new PartnerException("Could not find any parameters during form post parsing. Invalid response from server.");
            }

            uriBuilder.Query = string.Join("&", parameters);
            return uriBuilder.Uri.OriginalString;
        }

        private void StopWebBrowser()
        {
            InvokeHandlingOwnerWindow(() =>
            {
                if (!webBrowser.IsDisposed && webBrowser.IsBusy)
                {
                    webBrowser.Stop();
                }
            });
        }

        /// <summary>
        /// 
        /// </summary>
        protected abstract void OnClosingUrl();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statusCode"></param>
        protected abstract void OnNavigationCanceled(int statusCode);

        internal AuthorizationResult AuthenticateAAD(Uri requestUri, Uri callbackUri)
        {
            desiredCallbackUri = callbackUri;
            Result = null;

            // The WebBrowser event handlers must not throw exceptions.
            // If they do then they may be swallowed by the native
            // browser com control.
            webBrowser.Navigating += WebBrowserNavigatingHandler;
            webBrowser.Navigated += WebBrowserNavigatedHandler;
            webBrowser.NavigateError += WebBrowserNavigateErrorHandler;

            webBrowser.Navigate(requestUri);
            OnAuthenticate();

            return Result;
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnAuthenticate()
        {
        }

        /// <summary>
        /// Some calls need to be made on the UI thread and this is the central place to check if we have an owner
        /// window and if so, ensure we invoke on that proper thread.
        /// </summary>
        /// <param name="action"></param>
        protected void InvokeHandlingOwnerWindow(Action action)
        {
            // We only support WindowsForms (since our dialog is winforms based)
            if (OwnerWindow != null && OwnerWindow is Control winFormsControl)
            {
                winFormsControl.Invoke(action);
            }
            else
            {
                action();
            }
        }

        private void InitializeComponent()
        {
            Panel webBrowserPanel;

            InvokeHandlingOwnerWindow(() =>
            {
                Screen screen = (OwnerWindow != null)
                    ? Screen.FromHandle(OwnerWindow.Handle)
                    : Screen.PrimaryScreen;

                // Window height is set to 70% of the screen height.
                int uiHeight = (int)(Math.Max(screen.WorkingArea.Height, 160) * 70.0 / DpiHelper.ZoomPercent);
                webBrowserPanel = new Panel();
                webBrowserPanel.SuspendLayout();
                SuspendLayout();

                // 
                // webBrowser
                // 
                webBrowser.Dock = DockStyle.Fill;
                webBrowser.Location = new Point(0, 25);
                webBrowser.MinimumSize = new Size(20, 20);
                webBrowser.Name = "webBrowser";
                webBrowser.Size = new Size(UIWidth, 565);
                webBrowser.TabIndex = 1;
                webBrowser.IsWebBrowserContextMenuEnabled = false;

                // 
                // webBrowserPanel
                // 
                webBrowserPanel.Controls.Add(webBrowser);
                webBrowserPanel.Dock = DockStyle.Fill;
                webBrowserPanel.BorderStyle = BorderStyle.None;
                webBrowserPanel.Location = new Point(0, 0);
                webBrowserPanel.Name = "webBrowserPanel";
                webBrowserPanel.Size = new Size(UIWidth, uiHeight);
                webBrowserPanel.TabIndex = 2;

                // 
                // BrowserAuthenticationWindow
                // 
                AutoScaleDimensions = new SizeF(6, 13);
                AutoScaleMode = AutoScaleMode.Font;
                ClientSize = new Size(UIWidth, uiHeight);
                Controls.Add(webBrowserPanel);
                FormBorderStyle = FormBorderStyle.FixedSingle;
                Name = "BrowserAuthenticationWindow";

                // Move the window to the center of the parent window only if owner window is set.
                StartPosition = (OwnerWindow != null)
                    ? FormStartPosition.CenterParent
                    : FormStartPosition.CenterScreen;
                Text = string.Empty;
                ShowIcon = false;
                MaximizeBox = false;
                MinimizeBox = false;

                // If we don't have an owner we need to make sure that the pop up browser 
                // window is in the task bar so that it can be selected with the mouse.
                ShowInTaskbar = (null == OwnerWindow);

                webBrowserPanel.ResumeLayout(false);
                ResumeLayout(false);
            });
        }

        private sealed class WindowsFormsWin32Window : IWin32Window
        {
            public IntPtr Handle { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                StopWebBrowser();
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// 
        /// </summary>
        protected static class DpiHelper
        {
            static DpiHelper()
            {
                const double DefaultDpi = 96.0;

                const int LOGPIXELSX = 88;
                const int LOGPIXELSY = 90;

                double deviceDpiX;
                double deviceDpiY;

                IntPtr dC = NativeWrapper.NativeMethods.GetDC(IntPtr.Zero);

                if (dC != IntPtr.Zero)
                {
                    deviceDpiX = NativeWrapper.NativeMethods.GetDeviceCaps(dC, LOGPIXELSX);
                    deviceDpiY = NativeWrapper.NativeMethods.GetDeviceCaps(dC, LOGPIXELSY);

                    _ = NativeWrapper.NativeMethods.ReleaseDC(IntPtr.Zero, dC);
                }
                else
                {
                    deviceDpiX = DefaultDpi;
                    deviceDpiY = DefaultDpi;
                }

                int zoomPercentX = (int)(100 * (deviceDpiX / DefaultDpi));
                int zoomPercentY = (int)(100 * (deviceDpiY / DefaultDpi));

                ZoomPercent = Math.Min(zoomPercentX, zoomPercentY);
            }

            /// <summary>
            /// 
            /// </summary>
            public static int ZoomPercent { get; private set; }
        }


        internal static class NativeMethods
        {
            internal enum SessionOp
            {
                SESSION_QUERY = 0,
                SESSION_INCREMENT,
                SESSION_DECREMENT
            };

            [DllImport("IEFRAME.dll", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
            internal static extern int SetQueryNetSessionCount(SessionOp sessionOp);
        }
    }
}
