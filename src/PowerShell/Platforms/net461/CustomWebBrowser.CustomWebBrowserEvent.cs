// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Platforms
{
    using System.Runtime.InteropServices;

    internal partial class CustomWebBrowser
    {
        [ClassInterface(ClassInterfaceType.None)]
        private sealed class CustomWebBrowserEvent : StandardOleMarshalObject, NativeWrapper.IDWebBrowserEvents2
        {
            // Fields
            private readonly CustomWebBrowser parent;

            // Methods
            public CustomWebBrowserEvent(CustomWebBrowser parent)
            {
                this.parent = parent;
            }

            public void NavigateError(object pDisp, ref object URL, ref object frame, ref object statusCode, ref bool cancel)
            {
                int statusCodeInt = (statusCode == null) ? 0 : ((int)statusCode);

                WebBrowserNavigateErrorEventArgs e = new WebBrowserNavigateErrorEventArgs(statusCodeInt, pDisp);
                parent.OnNavigateError(e);
                cancel = e.Cancel;
            }

            // This method are empty because we agree with their implementation in base class event handler System.Windows.Forms.WebBrowser+WebBrowserEvent.
            // We disagree with empty implementation of NavigateError.
            // We also could tweak implementation of base class if we disagree by implementing this method.
            // This is COM events handler, defined in COM interface, however this model works as Events in .NET
            // Multiple handlers are possible, so empty method just called and do nothing.

            public void BeforeNavigate2(object pDisp, ref object URL, ref object flags, ref object targetFrameName, ref object postData, ref object headers, ref bool cancel)
            {
                // Ignore event
            }

            public void ClientToHostWindow(ref long cx, ref long cy)
            {
                // Ignore event
            }

            public void CommandStateChange(long command, bool enable)
            {
                // Ignore event
            }

            public void DocumentComplete(object pDisp, ref object URL)
            {
                // Ignore event
            }

            public void DownloadBegin()
            {
                // Ignore event
            }

            public void DownloadComplete()
            {
                // Ignore event
            }

            public void FileDownload(ref bool cancel)
            {
                // Ignore event
            }

            public void NavigateComplete2(object pDisp, ref object URL)
            {
                // Ignore event
            }


            public void NewWindow2(ref object pDisp, ref bool cancel)
            {
                // Ignore event
            }

            public void OnFullScreen(bool fullScreen)
            {
                // Ignore event
            }

            public void OnMenuBar(bool menuBar)
            {
                // Ignore event
            }

            public void OnQuit()
            {
                // Ignore event
            }

            public void OnStatusBar(bool statusBar)
            {
                // Ignore event
            }

            public void OnTheaterMode(bool theaterMode)
            {
                // Ignore event
            }

            public void OnToolBar(bool toolBar)
            {
                // Ignore event
            }

            public void OnVisible(bool visible)
            {
                // Ignore event
            }

            public void PrintTemplateInstantiation(object pDisp)
            {
                // Ignore event
            }

            public void PrintTemplateTeardown(object pDisp)
            {
                // Ignore event
            }

            public void PrivacyImpactedStateChange(bool bImpacted)
            {
                // Ignore event
            }

            public void ProgressChange(int progress, int progressMax)
            {
                // Ignore event
            }

            public void PropertyChange(string szProperty)
            {
                // Ignore event
            }

            public void SetSecureLockIcon(int secureLockIcon)
            {
                // Ignore event
            }

            public void StatusTextChange(string text)
            {
                // Ignore event
            }

            public void TitleChange(string text)
            {
                // Ignore event
            }

            public void UpdatePageStatus(object pDisp, ref object nPage, ref object fDone)
            {
                // Ignore event
            }

            public void WindowClosing(bool isChildWindow, ref bool cancel)
            {
                // Ignore event
            }

            public void WindowSetHeight(int height)
            {
                // Ignore event
            }

            public void WindowSetLeft(int left)
            {
                // Ignore event
            }

            public void WindowSetResizable(bool resizable)
            {
                // Ignore event
            }

            public void WindowSetTop(int top)
            {
                // Ignore event
            }

            public void WindowSetWidth(int width)
            {
                // Ignore event
            }
        }
    }
}
