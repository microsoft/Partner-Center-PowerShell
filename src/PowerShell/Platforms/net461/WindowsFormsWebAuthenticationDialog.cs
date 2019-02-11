// -----------------------------------------------------------------------
// <copyright file="WindowsFormsWebAuthenticationDialog.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Platforms
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using PartnerCenter.Exceptions;
    using PartnerCenter.Models.Authentication;

    /// <summary>
    /// The browser dialog used for user authentication
    /// </summary>
    [ComVisible(true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class WindowsFormsWebAuthenticationDialog : WindowsFormsWebAuthenticationDialogBase
    {
        private bool zoomed;

        private int statusCode;

        /// <summary>
        /// Default constructor
        /// </summary>
        public WindowsFormsWebAuthenticationDialog(object ownerWindow)
            : base(ownerWindow)
        {
            Shown += FormShownHandler;
            WebBrowser.DocumentTitleChanged += WebBrowserDocumentTitleChangedHandler;
            WebBrowser.ObjectForScripting = this;
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnAuthenticate()
        {
            zoomed = false;
            statusCode = 0;
            ShowBrowser();

            base.OnAuthenticate();
        }


        /// <summary>
        /// 
        /// </summary>
        public void ShowBrowser()
        {
            DialogResult uiResult = DialogResult.None;
            InvokeHandlingOwnerWindow(() => uiResult = ShowDialog(OwnerWindow));

            switch (uiResult)
            {
                case DialogResult.OK:
                    break;
                case DialogResult.Cancel:
                    Result = new AuthorizationResult(AuthorizationStatus.UserCancel, null);
                    break;
                default:
                    throw new PartnerException(statusCode.ToString(CultureInfo.InvariantCulture));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void WebBrowserNavigatingHandler(object sender, WebBrowserNavigatingEventArgs e)
        {
            SetBrowserZoom();
            base.WebBrowserNavigatingHandler(sender, e);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnClosingUrl()
        {
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnNavigationCanceled(int statusCode)
        {
            this.statusCode = statusCode;
            DialogResult = (statusCode == 0) ? DialogResult.Cancel : DialogResult.Abort;
        }

        private void SetBrowserZoom()
        {
            int windowsZoomPercent = DpiHelper.ZoomPercent;
            if (NativeWrapper.NativeMethods.IsProcessDPIAware() && 100 != windowsZoomPercent && !zoomed)
            {
                // There is a bug in some versions of the IE browser control that causes it to 
                // ignore scaling unless it is changed.
                SetBrowserControlZoom(windowsZoomPercent - 1);
                SetBrowserControlZoom(windowsZoomPercent);

                zoomed = true;
            }
        }

        private void SetBrowserControlZoom(int zoomPercent)
        {
            NativeWrapper.IWebBrowser2 browser2 = (NativeWrapper.IWebBrowser2)WebBrowser.ActiveXInstance;

            if (browser2.Document is NativeWrapper.IOleCommandTarget cmdTarget)
            {
                const int OLECMDID_OPTICAL_ZOOM = 63;
                const int OLECMDEXECOPT_DONTPROMPTUSER = 2;

                object[] commandInput = { zoomPercent };

                int hResult = cmdTarget.Exec(
                    IntPtr.Zero, OLECMDID_OPTICAL_ZOOM, OLECMDEXECOPT_DONTPROMPTUSER, commandInput, IntPtr.Zero);
                Marshal.ThrowExceptionForHR(hResult);
            }
        }

        private void FormShownHandler(object sender, EventArgs e)
        {
            // If we don't have an owner we need to make sure that the pop up browser 
            // window is on top of other windows.  Activating the window will accomplish this.
            if (null == Owner)
            {
                Activate();
            }
        }

        private void WebBrowserDocumentTitleChangedHandler(object sender, EventArgs e)
        {
            Text = WebBrowser.DocumentTitle;
        }
    }
}