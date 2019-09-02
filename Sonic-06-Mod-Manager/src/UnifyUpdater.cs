using System;
using System.IO;
using System.Net;
using Unify.Messages;
using System.Windows.Forms;

// Project Unify is licensed under the MIT License:
/*
 * MIT License

 * Copyright (c) 2019 Knuxfan24 & HyperPolygon64

 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:

 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.

 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

namespace Sonic_06_Mod_Manager.src
{
    public partial class UnifyUpdater : Form
    {
        string url;
        bool enabled;

        public UnifyUpdater(string versionNumber, string url, bool enabled)
        {
            InitializeComponent();

            this.url = url;
            this.enabled = enabled;

            lbl_Title.Text = $"Updating Sonic '06 Mod Manager to {versionNumber}...";
            Width = lbl_Title.Width + 40;

            if (this.enabled) UpdateVersion();
            else Close();
        }

        private void UpdateVersion()
        {
            var clientApplication = new WebClient();
            clientApplication.DownloadProgressChanged += (s, e) => { pgb_Progress.Value = e.ProgressPercentage; };
            clientApplication.DownloadFileAsync(new Uri(url), Application.ExecutablePath + ".pak");
            clientApplication.DownloadFileCompleted += (s, e) => {
                File.Replace(Application.ExecutablePath + ".pak", Application.ExecutablePath, Application.ExecutablePath + ".bak");
                UnifyMessages.UnifyMessage.Show(SystemMessages.msg_UpdateComplete, SystemMessages.tl_Success, "OK", "Information", false);
                Application.Exit();
            };
        }
    }
}
