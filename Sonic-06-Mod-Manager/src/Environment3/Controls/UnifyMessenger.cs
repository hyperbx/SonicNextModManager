using System;
using System.Media;
using System.Drawing;
using Unify.Environment3;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

// Sonic '06 Mod Manager is licensed under the MIT License:
/*
 * MIT License

 * Copyright (c) 2020 Knuxfan24
 * Copyright (c) 2020 HyperBE32

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

namespace Unify.Messenger
{
    internal partial class UnifyMessenger : Form
    {
        public static string Accept = string.Empty;
        public static int TextHeight = 0;

        public UnifyMessenger() { InitializeComponent(); }

        public UnifyMessenger(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon) {
            InitializeComponent();

            Text = caption;
            rtb_Message.Text = text;

            if (rtb_Message.Text.Length <= 65) {
                rtb_Message.Top += 6;
                rtb_Message.Left += 5;
                Width += rtb_Message.Width - 30;
            }
            else {
                rtb_Message.Top += 1;
                Width += rtb_Message.Width - 30;
            }

            switch (buttons) {
                case MessageBoxButtons.YesNo:
                    btn_Yes.Visible = true;
                    btn_OK.Text = "No";
                    btn_OK.BackColor = Color.Tomato;
                    break;
                case MessageBoxButtons.YesNoCancel:
                    btn_Yes.Visible = true;
                    btn_No.Visible = true;
                    btn_Abort.Visible = true;
                    btn_Abort.Text = "Yes";
                    btn_Abort.BackColor = Color.LightGreen;
                    btn_Yes.Text = "No";
                    btn_Yes.BackColor = Color.Tomato;
                    btn_OK.Text = "Cancel";
                    btn_OK.BackColor = SystemColors.ControlLightLight;
                    break;
                case MessageBoxButtons.OKCancel:
                    btn_Yes.Visible = true;
                    btn_Yes.Text = "OK";
                    btn_OK.Text = "Cancel";
                    btn_Yes.BackColor = SystemColors.ControlLightLight;
                    btn_OK.BackColor = Color.Tomato;
                    break;
                case MessageBoxButtons.AbortRetryIgnore:
                    btn_Abort.Visible = true;
                    btn_Yes.Visible = true;
                    btn_Yes.Text = "Retry";
                    btn_OK.Text = "Ignore";
                    btn_OK.BackColor = Color.SkyBlue;
                    break;
                case MessageBoxButtons.RetryCancel:
                    btn_Yes.Visible = true;
                    btn_Yes.Text = "Retry";
                    btn_OK.Text = "Cancel";
                    btn_OK.BackColor = Color.Tomato;
                    break;
            }

            switch (icon) {
                case MessageBoxIcon.Error:
                    pic_Icon.BackgroundImage = Properties.Resources.error.ToBitmap();
                    TopMost = true;
                    SystemSounds.Hand.Play();
                    break;
                case MessageBoxIcon.Information:
                    pic_Icon.BackgroundImage = Extract("shell32.dll", 277, true).ToBitmap();
                    TopMost = false;
                    SystemSounds.Asterisk.Play();
                    break;
                case MessageBoxIcon.Question:
                    pic_Icon.BackgroundImage = Extract("shell32.dll", 154, true).ToBitmap();
                    TopMost = false;
                    SystemSounds.Question.Play();
                    break;
                case MessageBoxIcon.Warning:
                    pic_Icon.BackgroundImage = Extract("shell32.dll", 237, true).ToBitmap();
                    TopMost = true;
                    SystemSounds.Asterisk.Play();
                    break;
            }

            BackColor = Color.FromArgb(45, 45, 48);
            pic_Icon.BackColor = Color.FromArgb(45, 45, 48);
            pnl_ButtonBackdrop.BackColor = Color.FromArgb(59, 59, 63);
            rtb_Message.BackColor = Color.FromArgb(45, 45, 48);
            rtb_Message.ForeColor = SystemColors.Control;
        }

        public static Icon Extract(string file, int number, bool largeIcon)
        {
            IntPtr large;
            IntPtr small;
            ExtractIconEx(file, number, out large, out small, 1);
            try {  return Icon.FromHandle(largeIcon ? large : small); }
            catch { return null; }

        }
        [DllImport("Shell32.dll", EntryPoint = "ExtractIconExW", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]

        private static extern int ExtractIconEx(string sFile, int iIndex, out IntPtr piLargeVersion, out IntPtr piSmallVersion, int amountIcons);

        public static class UnifyMessage {
            public static DialogResult ShowDialog(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon) {
                using (UnifyMessenger messenger = new UnifyMessenger(text, caption, buttons, icon))
                    messenger.ShowDialog();

                if      (Accept == "OK")     return DialogResult.OK;
                else if (Accept == "Yes")    return DialogResult.Yes;
                else if (Accept == "No")     return DialogResult.No;
                else if (Accept == "Abort")  return DialogResult.Abort;
                else if (Accept == "Retry")  return DialogResult.Retry;
                else if (Accept == "Ignore") return DialogResult.Ignore;
                else if (Accept == "Cancel") return DialogResult.Cancel;
                else                         return DialogResult.OK;
            }
        }

        public static string SpliceText(string text, int lineLength)
        {
            return Regex.Replace(text, "(.{" + lineLength + "})", "$1" + Environment.NewLine);
        }

        private void Btn_OK_Click(object sender, EventArgs e) { Accept = btn_OK.Text; Close(); }

        private void Btn_Yes_Click(object sender, EventArgs e) { Accept = btn_Yes.Text; Close(); }

        private void Btn_No_Click(object sender, EventArgs e) { Accept = btn_No.Text; Close(); }

        private void Btn_Abort_Click(object sender, EventArgs e) { Accept = btn_Abort.Text; Close(); }

        private void Rtb_Message_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            var getMessageBoundaries = (RichTextBox)sender;
            getMessageBoundaries.Height = e.NewRectangle.Height;
            TextHeight = e.NewRectangle.Height;
        }

        private void UnifyMessages_Load(object sender, EventArgs e) {
            if (rtb_Message.Text.Length <= 65)
                Height = TextHeight + 140;
            else
                Height = TextHeight + 135;
        }
    }
}
