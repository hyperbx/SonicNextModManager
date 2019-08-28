using System;
using System.Media;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

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

namespace Unify.Messages
{
    internal partial class UnifyMessages : Form
    {
        public static string Accept = string.Empty;

        public UnifyMessages()
        {
            InitializeComponent();
        }

        public UnifyMessages(string text, string caption, string buttons, string icon)
        {
            InitializeComponent();

            Text = caption;

            if (text.Length > 65) {
                lbl_Description.Text = SpliceText(text, 65);
                Height += lbl_Description.Height - 35;
            }
            else {
                lbl_Description.Text = text;
                lbl_Description.Top += 7;
                Height -= 7;
            }

            switch (buttons)
            {
                case "YesNo":
                    btn_Yes.Visible = true;
                    btn_OK.Text = "No";
                    btn_OK.BackColor = Color.Tomato;
                    break;
                case "YesNoCancel":
                    btn_Yes.Visible = true;
                    btn_No.Visible = true;
                    btn_OK.Text = "Cancel";
                    btn_OK.BackColor = Color.Tomato;
                    break;
                case "OKCancel":
                    btn_Yes.Visible = true;
                    btn_Yes.Text = "OK";
                    btn_OK.Text = "Cancel";
                    btn_OK.BackColor = Color.Tomato;
                    break;
                case "AbortRetryIgnore":
                    btn_Abort.Visible = true;
                    btn_Yes.Visible = true;
                    btn_Yes.Text = "Retry";
                    btn_OK.Text = "Ignore";
                    btn_OK.BackColor = Color.SkyBlue;
                    break;
                case "RetryCancel":
                    btn_Yes.Visible = true;
                    btn_Yes.Text = "Retry";
                    btn_OK.Text = "Cancel";
                    btn_OK.BackColor = Color.Tomato;
                    break;
            }

            switch (icon)
            {
                case "Error":
                    pic_Icon.BackgroundImage = Sonic_06_Mod_Manager.Properties.Resources.error.ToBitmap();
                    SystemSounds.Hand.Play();
                    break;
                case "Information":
                    pic_Icon.BackgroundImage = Extract("shell32.dll", 277, true).ToBitmap();
                    SystemSounds.Asterisk.Play();
                    break;
                case "Question":
                    pic_Icon.BackgroundImage = Extract("shell32.dll", 154, true).ToBitmap();
                    SystemSounds.Question.Play();
                    break;
                case "Warning":
                    pic_Icon.BackgroundImage = Extract("shell32.dll", 237, true).ToBitmap();
                    SystemSounds.Asterisk.Play();
                    break;
            }

            if (Sonic_06_Mod_Manager.Properties.Settings.Default.theme) {
                BackColor = Color.FromArgb(45, 45, 48);
                lbl_Description.ForeColor = SystemColors.Control;
                pic_Icon.BackColor = Color.FromArgb(45, 45, 48);
                pnl_ButtonBackdrop.BackColor = Color.FromArgb(59, 59, 63);
            }

            Width = lbl_Description.Width + 100;
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

        public string SpliceText(string text, int lineLength)
        {
            string pattern = "(.{" + lineLength + "})";
            Regex rgx = new Regex(pattern);
            string sentence = text;

            foreach (Match match in rgx.Matches(sentence)) {
                lbl_Description.Top -= 1;
                pic_Icon.Top += 1;
            }

            return Regex.Replace(text, "(.{" + lineLength + "})", "$1" + Environment.NewLine);
        }

        public static class UnifyMessage
        {
            public static string Show(string text, string caption, string buttons, string icon) {
                using (var openMessenger = new UnifyMessages(text, caption, buttons, icon))
                    openMessenger.ShowDialog();

                return Accept;
            }
        }

        private void Btn_OK_Click(object sender, EventArgs e) { Accept = btn_OK.Text; Close(); }

        private void Btn_Yes_Click(object sender, EventArgs e) { Accept = btn_Yes.Text; Close(); }

        private void Btn_No_Click(object sender, EventArgs e) { Accept = btn_No.Text; Close(); }

        private void Btn_Abort_Click(object sender, EventArgs e) { Accept = btn_Abort.Text; Close(); }
    }

    class SystemMessages
    {
        public static string tl_DefaultTitle = "Sonic '06 Mod Manager";

        public static string msg_DefaultStatus = "Ready.";
        public static string msg_LaunchXenia = "Launching Xenia...";
        public static string msg_LaunchRPCS3 = "Launching RPCS3...";
        public static string msg_XeniaExitCall = "Waiting for Xenia exit call...";
        public static string msg_RPCS3ExitCall = "Waiting for RPCS3 exit call...";
        public static string msg_CreateNewMod = "Creating new mod...";
        public static string msg_EditMod = "Editing mod...";
        public static string msg_ModInfo = "Previewing mod info...";
        public static string msg_Cleanup = "Cleaning up mods...";
        public static string msg_Prereq_Newtonsoft = "Newtonsoft.Json.dll was written to the application path.";
        public static string tl_FatalError = "Fatal Error";
        public static string msg_Prereq_Ookii = "Ookii.Dialogs.dll was written to the application path.";
        public static string msg_GameBananaRegistry = "Do you want to run Sonic '06 Mod Manager as an administrator to install the GameBanana 1-Click Install key?";
        public static string tl_MissingRegistry = "Missing Registry";
        public static string msg_GameBananaRegistryUninstall = "Do you want to run Sonic '06 Mod Manager as an administrator to uninstall the GameBanana 1-Click Install key?";
        public static string tl_AreYouSure = "Are you sure?";
        public static string tl_ServerError = "Server Error";
        public static string tl_FileError = "File Error";
        public static string tl_ListError = "List Error";
        public static string tl_NameError = "Name Error";
        public static string tl_Success = "Success";
        public static string tl_SuccessWarn = "Success, but errors occurred...";
        public static string tl_ExtractError = "Extract Error";

        public static string ex_Prereq_Newtonsoft_WriteFailure(Exception exception) { return $"Failed to write Newtonsoft.Json.dll. Please reinstall Sonic '06 Mod Manager.\n\n{exception}"; }
        public static string ex_Prereq_Ookii_WriteFailure(Exception exception) { return $"Failed to write Ookii.Dialogs.dll. Please reinstall Sonic '06 Mod Manager.\n\n{exception}"; }
        public static string msg_InstallingMod(string mod) { return $"Installing {mod}..."; }
        public static string msg_CopyingMod(string mod) { return $"Copying {mod}..."; }
        public static string msg_MergingMod(string mod) { return $"Merging {mod}..."; }
    }

    class ModsMessages
    {
        public static string msg_NoModDirectory = "No mods directory specified, or the specified directory is\ninvalid - please select your Sonic '06 mods directory...";
        public static string ex_ModListError = "An error occurred whilst retrieving the mods list.";
        public static string msg_LocateARCs = "Please select ARC files to make read-only...";
        public static string msg_ThumbnailDeleteError = "An error occurred whilst removing the thumbnail.";
        public static string ex_ModInstallFailure = "General mod installation failure, please ensure your game directory is set correctly.";
        public static string msg_CancelDownloading = "Are you sure you want to cancel downloading?";
        public static string msg_LoSInstalled = "Legacy of Solaris has been installed in your mods directory.";
        public static string ex_GitHubTimeout = "Unable to establish a connection to GitHub.";
        public static string ex_GameBananaTimeout = "Unable to establish a connection to GameBanana.";
        public static string ex_ExtractFailNoApp = "Failed to install from archive because 7-Zip and/or WinRAR is not installed.";

        public static string ex_GBExtractFailed(string mod) { return $"Failed to extract {mod}."; }
        public static string msg_GBInstalled(string mod) { return $"{mod} has been installed in your mods directory."; }
        public static string ex_SkippedMod(string mod, string file) { return $"\n► {mod} (failed because a mod was already installed on file: {file} - try merging instead)"; }
        public static string ex_SkippedModsTally(string failedMods) { return $"Mod installation completed, but the following mods were skipped:\n{failedMods}"; }
        public static string ex_IncorrectTarget(string mod, string platform) { return $"\n► {mod} (failed because the mod was not targeted for the {platform})"; }
        public static string ex_ModExists(string mod) { return $"A mod called '{mod}' already exists."; }
    }

    class EmulatorMessages
    {
        public static string msg_LocateGame = "Please specify your game directory...";
        public static string msg_LocateXenia = "Please specify your executable file for Xenia...";
        public static string msg_LocateRPCS3 = "Please specify your executable file for RPCS3...";
    }

    class PatchesMessages
    {

    }

    class SettingsMessages
    {
        public static string msg_LocateMods = "Please specify your mods directory...";
        public static string msg_Reset = "This will clear all of the settings for Sonic '06 Mod Manager.\nAre you sure you want to continue?";
    }
}
