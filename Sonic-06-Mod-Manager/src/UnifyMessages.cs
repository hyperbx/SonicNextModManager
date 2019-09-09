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
        public static int TextHeight = 0;

        public UnifyMessages()
        {
            InitializeComponent();
        }

        public UnifyMessages(string text, string caption, string buttons, string icon, bool centre)
        {
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
                    btn_Yes.BackColor = SystemColors.ControlLightLight;
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
                    TopMost = true;
                    if (Sonic_06_Mod_Manager.ModManager.dreamcastDay) {
                        SoundPlayer dreamError = new SoundPlayer(Sonic_06_Mod_Manager.Properties.Resources.dream);
                        dreamError.Play();
                    }
                    else
                        SystemSounds.Hand.Play();
                    break;
                case "Information":
                    pic_Icon.BackgroundImage = Extract("shell32.dll", 277, true).ToBitmap();
                    TopMost = false;
                    if (Sonic_06_Mod_Manager.ModManager.dreamcastDay) {
                        SoundPlayer dreamWarn = new SoundPlayer(Sonic_06_Mod_Manager.Properties.Resources.dreamWarn);
                        dreamWarn.Play();
                    }
                    else
                        SystemSounds.Asterisk.Play();
                    break;
                case "Question":
                    pic_Icon.BackgroundImage = Extract("shell32.dll", 154, true).ToBitmap();
                    TopMost = false;
                    SystemSounds.Question.Play();
                    break;
                case "Warning":
                    pic_Icon.BackgroundImage = Extract("shell32.dll", 237, true).ToBitmap();
                    TopMost = true;
                    if (Sonic_06_Mod_Manager.ModManager.dreamcastDay) {
                        SoundPlayer dreamWarn = new SoundPlayer(Sonic_06_Mod_Manager.Properties.Resources.dreamWarn);
                        dreamWarn.Play();
                    }
                    else
                        SystemSounds.Asterisk.Play();
                    break;
            }

            if (Sonic_06_Mod_Manager.Properties.Settings.Default.theme) {
                BackColor = Color.FromArgb(45, 45, 48);
                pic_Icon.BackColor = Color.FromArgb(45, 45, 48);
                pnl_ButtonBackdrop.BackColor = Color.FromArgb(59, 59, 63);
                rtb_Message.BackColor = Color.FromArgb(45, 45, 48);
                rtb_Message.ForeColor = SystemColors.Control;
            }
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

        public static class UnifyMessage
        {
            public static string Show(string text, string caption, string buttons, string icon, bool centre) {
                using (var openMessenger = new UnifyMessages(text, caption, buttons, icon, centre)) {
                    if (centre) openMessenger.StartPosition = FormStartPosition.CenterScreen;
                    else openMessenger.StartPosition = FormStartPosition.CenterParent; //new Point(parentLeft, parentTop);
                    openMessenger.ShowDialog();
                }

                return Accept;
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
        public static string msg_Cleanup = "Cleaning up...";
        public static string msg_Prereq_Newtonsoft = "Newtonsoft.Json.dll was written to the application path.";
        public static string tl_FatalError = "Fatal Error";
        public static string msg_Prereq_Ookii = "Ookii.Dialogs.dll was written to the application path.";
        public static string msg_GameBananaRegistry = $"Do you want to run {tl_DefaultTitle} as an administrator to install the GameBanana 1-Click Install key?";
        public static string tl_MissingRegistry = "Missing Registry";
        public static string msg_GameBananaRegistryUninstall = $"Do you want to run {tl_DefaultTitle} as an administrator to uninstall the GameBanana 1-Click Install key?";
        public static string tl_AreYouSure = "Are you sure?";
        public static string tl_ServerError = "Server Error";
        public static string tl_FileError = "File Error";
        public static string tl_DirectoryError = "Directory Error";
        public static string tl_ListError = "List Error";
        public static string tl_NameError = "Name Error";
        public static string tl_Success = "Success";
        public static string tl_SuccessWarn = "Success, but errors occurred...";
        public static string tl_ExtractError = "Extract Error";
        public static string msg_NoUpdates = "There are currently no updates available.";
        public static string ex_UpdateFailedUnknown = $"An error occurred when updating {tl_DefaultTitle}.";
        public static string warn_CloseProcesses = $"Please close any other instances of {tl_DefaultTitle} and try again.";
        public static string tl_ProcessError = "Process Error";
        public static string tl_Update = "New update available!";
        public static string msg_UpdateComplete = $"Update complete! Please restart {tl_DefaultTitle}.";
        public static string msg_PatchingRenderer = "Patching Renderer...";
        public static string msg_PatchingReflections = "Patching Reflections...";
        public static string msg_PatchingHUD = "Patching HUD...";
        public static string msg_PatchingShadows = "Patching Shadows...";
        public static string msg_PatchingCamera = "Patching Camera...";
        public static string msg_PatchingCharacters = "Patching Characters...";
        public static string ex_JavaMissing = $"{tl_DefaultTitle} requires Java for installing patches. To use the Patches tab, please install Java and restart {tl_DefaultTitle}.";
        public static string tl_JavaError = "Java Error";
        public static string tl_NetworkError = "Network Error";

        public static string ex_Prereq_Newtonsoft_WriteFailure(Exception exception) { return $"Failed to write Newtonsoft.Json.dll. Please reinstall {tl_DefaultTitle}.\n\n{exception}"; }
        public static string ex_Prereq_Ookii_WriteFailure(Exception exception) { return $"Failed to write Ookii.Dialogs.dll. Please reinstall {tl_DefaultTitle}.\n\n{exception}"; }
        public static string msg_InstallingMod(string mod) { return $"Installing {mod}..."; }
        public static string msg_CopyingMod(string mod) { return $"Copying {mod}..."; }
        public static string msg_MergingMod(string mod) { return $"Merging {mod}..."; }
        public static string msg_TransferringMod(string mod) { return $"Transferring {mod}..."; }
        public static string msg_RedirectingSave(string mod) { return $"Redirecting save file for {mod}..."; }
        public static string msg_UpdateAvailable(string latestVersion, string changeLogs) { return $"{tl_DefaultTitle} - {latestVersion} is now available!\n\nChangelogs:\n{changeLogs}\n\nDo you wish to download it?"; }
    }

    class ModsMessages
    {
        public static string msg_NoModDirectory = "No mods directory specified, or the specified directory is invalid - please select your Sonic '06 mods directory...";
        public static string ex_ModListError = "An error occurred whilst retrieving the mods list.";
        public static string msg_LocateARCs = "Please select ARC files to make read-only...";
        public static string msg_LocateSaveX = "Please select a Xbox 360 save file...";
        public static string msg_LocateSavePS = "Please select a PlayStation 3 save file...";
        public static string msg_LocateSave = "Please select a save file...";
        public static string msg_ThumbnailDeleteError = "An error occurred whilst removing the thumbnail.";
        public static string msg_SaveDeleteError = "An error occurred whilst removing the save data.";
        public static string ex_ModInstallFailure = "General mod installation failure, please see the information below...";
        public static string msg_CancelDownloading = "Are you sure you want to cancel downloading?";
        public static string msg_LoSInstalled = "Legacy of Solaris has been installed in your mods directory.";
        public static string ex_GitHubTimeout = "Unable to establish a connection to GitHub.";
        public static string ex_GameBananaTimeout = "Unable to establish a connection to GameBanana.";
        public static string ex_ExtractFailNoApp = "Failed to install from archive because 7-Zip and/or WinRAR is not installed.";
        public static string ex_FTPError = "An error occurred whilst establishing a connection to the FTP server.";

        public static string ex_GBExtractFailed(string mod) { return $"Failed to extract {mod}."; }
        public static string msg_GBInstalled(string mod) { return $"{mod} has been installed in your mods directory."; }
        public static string ex_SkippedMod(string mod, string file) { return $"\n► {mod} (failed because a mod was already installed on file: {file} - try merging instead)"; }
        public static string ex_SkippedModMissingFile(string mod, string file) { return $"\n► {mod} (failed because the following file doesn't exist in the game: {file})"; }
        public static string ex_IncorrectSaveTarget(string mod, string platform) { return $"\n► {mod} (save redirect failed because the save was not targeted for the {platform})"; }
        public static string ex_SkippedModsTally(string failedMods) { return $"Mod installation completed, but the following mods were skipped:\n{failedMods}"; }
        public static string ex_IncorrectTarget(string mod, string platform) { return $"\n► {mod} (failed because the mod was not targeted for the {platform})"; }
        public static string ex_ModExists(string mod) { return $"A mod called '{mod}' already exists."; }
        public static string warn_ModDeleteWarn(string mod) { return $"Are you sure you want to delete '{mod}?'"; }
        public static string ex_ModDeleteError(string mod) { return $"Failed to delete '{mod}.' Please ensure that nothing is accessing that mod's directory, or delete it manually."; }
        public static string ex_SkippedSave(string mod) { return $"\n► {mod} (save redirect failed because a save was already redirected)"; }
    }

    class EmulatorMessages
    {
        public static string msg_LocateGame = "Please specify your game directory...";
        public static string msg_LocateXenia = "Please specify your executable file for Xenia...";
        public static string msg_LocateRPCS3 = "Please specify your executable file for RPCS3...";
    }

    class PatchesMessages
    {
        public static string ex_PatchInstallFailure = "General patch installation failure, please see the information below...";
    }

    class SettingsMessages
    {
        public static string msg_LocateMods = "Please specify your mods directory...";
        public static string msg_Reset = $"This will clear all of the settings for {SystemMessages.tl_DefaultTitle}. Are you sure you want to continue?";
    }
}
