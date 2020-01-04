using System;
using System.IO;
using Unify.Tools;
using System.Text;
using Unify.Messages;
using System.Drawing;
using Unify.Networking;
using System.Windows.Forms;

// Project Unify is licensed under the MIT License:
/*
 * MIT License

 * Copyright (c) 2020 Knuxfan24 & HyperPolygon64

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
    public partial class ModCreator : Form
    {
        string modThumbnail = string.Empty;
        string modPath = string.Empty;
        bool edit = false;

        public ModCreator(string modPath, bool edit)
        {
            InitializeComponent();
            this.modPath = modPath;
            this.edit = edit;
            if (!this.edit) {
                text_Date.Text = DateTime.Now.ToString("dd/MM/yyyy");
                text_Author.Text = Environment.UserName;
            }

            combo_System.SelectedIndex = 0;

            if (ModManager.dreamcastDay) {
                if (Properties.Settings.Default.dream)
                    Icon = Properties.Resources.dreamcast_ntsc_icon;
                else
                    Icon = Properties.Resources.dreamcast_pal_icon;
            }

            if (ModManager.christmas) Icon = Properties.Resources.icon_christmas;

            if (!Properties.Settings.Default.theme) { //Edit colours if the user is insane and opts to use the Light Theme
                btn_Browse.FlatAppearance.BorderSize = 1; //Border Size in Light Theme

                //Set things to SystemColors.ControlText
                unifytb_ModCreator.TextColor =
                list_Console.ForeColor =
                text_Title.ForeColor =
                text_Version.ForeColor =
                text_Date.ForeColor =
                text_Author.ForeColor =
                text_ReadOnly.ForeColor = 
                text_Save.ForeColor = 
                text_Server.ForeColor =
                text_Data.ForeColor =
                tb_Description.ForeColor =
                lbl_Title.ForeColor =
                lbl_Version.ForeColor =
                lbl_Date.ForeColor =
                lbl_Author.ForeColor =
                lbl_System.ForeColor =
                lbl_ReadOnly.ForeColor =
                lbl_Save.ForeColor =
                lbl_Server.ForeColor =
                check_Merge.ForeColor =
                group_DescriptionField.ForeColor = 
                lbl_Data.ForeColor = SystemColors.ControlText;

                //Set things to SystemColors.ControlLightLight
                text_Title.BackColor =
                text_Version.BackColor =
                text_Date.BackColor =
                text_Author.BackColor =
                text_ReadOnly.BackColor =
                text_Save.BackColor =
                text_Server.BackColor =
                text_Data.BackColor =
                group_DescriptionField.BackColor =
                tb_Description.BackColor =
                pnl_Console.BackColor =
                list_Console.BackColor =
                btn_RemoveThumbnail.BackColor =
                unifytb_ModCreator.HeaderColor =
                pic_Thumbnail.BackColor =
                group_DescriptionField.BackColor =
                tb_Description.BackColor = 
                SystemColors.ControlLightLight;

                //Set things to SystemColors.Control
                unifytb_ModCreator.BorderColor =
                unifytb_ModCreator.BackTabColor =
                unifytb_Tab_Description.BackColor =
                unifytb_Tab_Details.BackColor =
                unifytb_Tab_Networking.BackColor =
                BackColor =
                SystemColors.Control;
            }

            if (edit)
            {
                if (File.Exists(Path.Combine(modPath, "mod.ini")))
                {
                    using (StreamReader configFile = new StreamReader(Path.Combine(modPath, "mod.ini"), Encoding.Default))
                    {
                        string line;
                        string entryValue;
                        while ((line = configFile.ReadLine()) != null)
                        {
                            if (line.StartsWith("Title"))
                            {
                                entryValue = line.Substring(line.IndexOf("=") + 2);
                                entryValue = entryValue.Remove(entryValue.Length - 1);
                                text_Title.Text = entryValue;
                            }
                            if (line.StartsWith("Version"))
                            {
                                entryValue = line.Substring(line.IndexOf("=") + 2);
                                entryValue = entryValue.Remove(entryValue.Length - 1);
                                text_Version.Text = entryValue;
                            }
                            if (line.StartsWith("Date"))
                            {
                                entryValue = line.Substring(line.IndexOf("=") + 2);
                                entryValue = entryValue.Remove(entryValue.Length - 1);
                                text_Date.Text = entryValue;
                            }
                            if (line.StartsWith("Author"))
                            {
                                entryValue = line.Substring(line.IndexOf("=") + 2);
                                entryValue = entryValue.Remove(entryValue.Length - 1);
                                text_Author.Text = entryValue;
                            }
                            if (line.StartsWith("Platform"))
                            {
                                entryValue = line.Substring(line.IndexOf("=") + 2);
                                entryValue = entryValue.Remove(entryValue.Length - 1);

                                switch (entryValue)
                                {
                                    case "Xbox 360":
                                        combo_System.SelectedIndex = 0;
                                        break;
                                    case "PlayStation 3":
                                        combo_System.SelectedIndex = 1;
                                        break;
                                    case "All Systems":
                                        combo_System.SelectedIndex = 2;
                                        break;
                                }
                            }
                            if (line.StartsWith("Merge"))
                            {
                                entryValue = line.Substring(line.IndexOf("=") + 2);
                                entryValue = entryValue.Remove(entryValue.Length - 1);
                                check_Merge.Checked = bool.Parse(entryValue);
                                if (check_Merge.Checked)
                                {
                                    text_ReadOnly.Enabled = true;
                                    btn_ReadOnlyBrowser.Enabled = true;

                                    if (!Properties.Settings.Default.theme)
                                        lbl_ReadOnly.ForeColor = SystemColors.ControlText;
                                    else
                                        lbl_ReadOnly.ForeColor = SystemColors.Control;
                                }
                            }
                            if (line.StartsWith("Read-only"))
                            {
                                entryValue = line.Substring(line.IndexOf("=") + 2);
                                entryValue = entryValue.Remove(entryValue.Length - 1);
                                text_ReadOnly.Text = entryValue;
                            }
                            if (line.StartsWith("Save"))
                            {
                                entryValue = line.Substring(line.IndexOf("=") + 2);
                                entryValue = entryValue.Remove(entryValue.Length - 1);
                                text_Save.Text = entryValue;
                            }
                            if (line.StartsWith("Description"))
                            {
                                entryValue = line.Substring(line.IndexOf("=") + 2);
                                entryValue = entryValue.Remove(entryValue.Length - 1);
                                tb_Description.Text += entryValue.Replace(@"\n", Environment.NewLine);
                            }
                            if (line.StartsWith("Metadata"))
                            {
                                entryValue = line.Substring(line.IndexOf("=") + 2);
                                entryValue = entryValue.Remove(entryValue.Length - 1);
                                text_Server.Text += entryValue.Replace(@"\n", Environment.NewLine);
                            }
                            if (line.StartsWith("Data"))
                            {
                                entryValue = line.Substring(line.IndexOf("=") + 2);
                                entryValue = entryValue.Remove(entryValue.Length - 1);
                                text_Data.Text += entryValue.Replace(@"\n", Environment.NewLine);
                            }
                        }
                    }
                }
                else { Close(); }

                btn_Create.Text = "Edit Mod";
                btn_Create.BackColor = Color.SkyBlue;
                btn_Delete.Visible = true;

                if (Directory.Exists(modPath)) {
                    string[] getThumbnail = Directory.GetFiles(modPath, "thumbnail*", SearchOption.TopDirectoryOnly);
                    foreach (var img in getThumbnail) {
                        pic_Thumbnail.BackgroundImage = Image.FromFile(img);
                    }
                }
            }

            if (!edit) { lbl_ReadOnly.ForeColor = SystemColors.GrayText; }
        }

        public static bool FilePathHasInvalidChars(string path)
        {
            return !string.IsNullOrEmpty(path) && path.IndexOfAny(Path.GetInvalidPathChars()) >= 0;
        }

        private void Btn_Create_Click(object sender, EventArgs e)
        {
            string safeTitle = text_Title.Text.Replace(@"\", "")
                                              .Replace("/", " - ")
                                              .Replace(":", " - ")
                                              .Replace("*", "")
                                              .Replace("?", "")
                                              .Replace("\"", "'")
                                              .Replace("<", "")
                                              .Replace(">", "")
                                              .Replace("|", "");

            if (Directory.Exists(Path.Combine(Properties.Settings.Default.modsDirectory, safeTitle)) && !edit)
                UnifyMessages.UnifyMessage.Show(ModsMessages.ex_ModExists(safeTitle), SystemMessages.tl_NameError, "OK", "Error");
            else {
                pic_Thumbnail.BackgroundImage.Dispose();
                pic_Thumbnail.BackgroundImage = Properties.Resources.logo_exception;

                string newPath = Path.Combine(Properties.Settings.Default.modsDirectory, safeTitle);

                if (!edit)
                     Directory.CreateDirectory(newPath);
                else if (!Directory.Exists(newPath))
                    Directory.Move(modPath, newPath);

                using (Stream configCreate = File.Open(Path.Combine(newPath, "mod.ini"), FileMode.Create))
                using (StreamWriter configInfo = new StreamWriter(configCreate)) {
                    configInfo.WriteLine("[Main]");
                    configInfo.WriteLine($"Title=\"{text_Title.Text}\"");
                    if (text_Version.Text != string.Empty) configInfo.WriteLine($"Version=\"{text_Version.Text}\"");
                    if (text_Date.Text != string.Empty) configInfo.WriteLine($"Date=\"{text_Date.Text}\"");
                    if (text_Author.Text != string.Empty) configInfo.WriteLine($"Author=\"{text_Author.Text}\"");
                    configInfo.WriteLine($"Platform=\"{combo_System.Text}\"");
                    configInfo.WriteLine($"Merge=\"{check_Merge.Checked.ToString()}\"");
                    if (text_ReadOnly.Text != string.Empty) configInfo.WriteLine($"Read-only=\"{text_ReadOnly.Text}\"");
                    if (text_Save.Text != string.Empty && combo_System.SelectedIndex == 0) configInfo.WriteLine($"Save=\"savedata.360\"");
                    else if (text_Save.Text != string.Empty && combo_System.SelectedIndex == 1) configInfo.WriteLine($"Save=\"savedata.ps3\"");
                    if (tb_Description.Text != string.Empty) {
                        string descriptionText = string.Empty;
                        foreach (var newLine in tb_Description.Lines)
                            descriptionText += $"{newLine}\\n";
                        configInfo.WriteLine($"Description=\"{descriptionText}\"");
                    }
                    if (text_Server.Text != string.Empty) {
                        configInfo.WriteLine();
                        configInfo.WriteLine("[Updater]");
                        configInfo.WriteLine($"Metadata=\"{text_Server.Text}\"");
                    }
                    if (text_Data.Text != string.Empty) configInfo.WriteLine($"Data=\"{text_Data.Text}\"");
                    configInfo.Close();
                }

                if (File.Exists(modThumbnail))
                    File.Copy(modThumbnail, Path.Combine(newPath, $"thumbnail{Path.GetExtension(modThumbnail)}"), true);

                if (File.Exists(text_Save.Text))
                    if (combo_System.SelectedIndex == 0)
                        File.Copy(text_Save.Text, Path.Combine(newPath, "savedata.360"), true);
                    else if (combo_System.SelectedIndex == 1)
                        File.Copy(text_Save.Text, Path.Combine(newPath, "savedata.ps3"), true);

                //if (modThumbnail == string.Empty && edit) {
                //    try {
                //        string[] getThumbnail = Directory.GetFiles(newPath, "thumbnail*", SearchOption.TopDirectoryOnly);
                //        foreach (var img in getThumbnail)
                //            if (File.Exists(img)) File.Delete(img);
                //    }
                //    catch (Exception ex) { UnifyMessages.UnifyMessage.Show($"{ModsMessages.msg_ThumbnailDeleteError}\n\n{ex}", SystemMessages.tl_FileError, "OK", "Error", false); }
                //}

                if (text_Save.Text == string.Empty && edit) {
                    try {
                        string[] getSaveData = Directory.GetFiles(newPath, "savedata*", SearchOption.TopDirectoryOnly);
                        foreach (var save in getSaveData)
                            if (File.Exists(save)) File.Delete(save);
                    }
                    catch (Exception ex) { UnifyMessages.UnifyMessage.Show($"{ModsMessages.msg_SaveDeleteError}\n\n{ex}", SystemMessages.tl_FileError, "OK", "Error"); }
                }

                Close();
            }
        }

        private void Text_Title_TextChanged(object sender, EventArgs e)
        {
            if (text_Title.Text != string.Empty)
                btn_Create.Enabled = true;
            else
                btn_Create.Enabled = false;
        }

        private void Check_Merge_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Merge.Checked) {
                text_ReadOnly.Enabled = true;
                btn_ReadOnlyBrowser.Enabled = true;

                if (!Properties.Settings.Default.theme)
                    lbl_ReadOnly.ForeColor = SystemColors.ControlText;
                else
                    lbl_ReadOnly.ForeColor = SystemColors.Control;
            }
            else {
                text_ReadOnly.Enabled = false;
                btn_ReadOnlyBrowser.Enabled = false;
                lbl_ReadOnly.ForeColor = SystemColors.GrayText;
            }
        }

        private void Btn_Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog thumbnail = new OpenFileDialog
            {
                Title = "Please search for a thumbnail...",
                Filter = "PNG (*.png)|*.png|JPEG (*.jpg; *.jpeg; *.jpe; *.jfif)|*.jpg; *.jpeg; *.jpe; *.jfif|BMP (*.bmp)|*.bmp"
            };

            if (thumbnail.ShowDialog() == DialogResult.OK) { 
                pic_Thumbnail.BackgroundImage = new Bitmap(thumbnail.FileName);
                modThumbnail = thumbnail.FileName;
            }
        }

        private void Btn_ReadOnlyBrowser_Click(object sender, EventArgs e) {
            string files = Locations.LocateARCs();

            if (files != string.Empty) {
                if (text_ReadOnly.Text != string.Empty && !text_ReadOnly.Text.EndsWith(","))
                    text_ReadOnly.Text += $",{files.Substring(0, files.Length - 1)}";
                else
                    text_ReadOnly.Text += files.Substring(0, files.Length - 1);
            }
        }

        private void Btn_RemoveThumbnail_Click(object sender, EventArgs e) {
            pic_Thumbnail.BackgroundImage.Dispose();
            pic_Thumbnail.BackgroundImage = Properties.Resources.logo_exception;
            modThumbnail = string.Empty;
        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            string confirmation = UnifyMessages.UnifyMessage.Show(ModsMessages.warn_ModDeleteWarn(Path.GetFileName(modPath)), SystemMessages.tl_AreYouSure, "YesNo", "Question");

            switch (confirmation)
            {
                case "Yes":
                    var tempData = new DirectoryInfo(modPath);

                    try {
                        if (Directory.Exists(modPath)) {
                            foreach (FileInfo file in tempData.GetFiles())
                                file.Delete();
                            foreach (DirectoryInfo directory in tempData.GetDirectories())
                                directory.Delete(true);
                            Directory.Delete(modPath);
                        }
                    } catch { UnifyMessages.UnifyMessage.Show(ModsMessages.ex_ModDeleteError(Path.GetFileName(modPath)), SystemMessages.tl_DirectoryError, "OK", "Error"); } Close();
                    break;
            }
        }

        private void Btn_SaveBrowser_Click(object sender, EventArgs e) { text_Save.Text = Locations.LocateSaves(combo_System.SelectedIndex); }

        private void Combo_System_SelectedIndexChanged(object sender, EventArgs e) {
            if (combo_System.SelectedIndex == 2) {
                lbl_Save.ForeColor = SystemColors.GrayText;
                text_Save.Enabled = false;
                btn_SaveBrowser.Enabled = false;
            } else {
                if (Properties.Settings.Default.theme)
                    lbl_Save.ForeColor = SystemColors.Control;
                else
                    lbl_Save.ForeColor = SystemColors.ControlText;
                text_Save.Enabled = true;
                btn_SaveBrowser.Enabled = true;
            }
        }

        private void Text_UpdateURL_TextChanged(object sender, EventArgs e) {
            if (text_Server.Text.Length != 0) btn_TestConnection.Enabled = true;
            else btn_TestConnection.Enabled = false;
        }

        private void Log(string value) { list_Console.Items.Add($"[{DateTime.Now.ToString("HH:mm:ss tt")}] {value}"); }

        private void Btn_TestConnection_Click(object sender, EventArgs e) {
            string metadata = string.Empty;
            list_Console.Items.Clear();

            Log("Establishing connection to server...");
            try { metadata = new TimedWebClient { Timeout = 100000 }.DownloadString(text_Server.Text); }
            catch { Log("Failed to download data from server..."); return; }

            if (metadata.Length != 0) {
                Log("Connection was successful...");
                list_Console.Items.Add("");

                string[] splitMetadata = metadata.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

                foreach (string line in splitMetadata) {
                    string entryValue = string.Empty;
                    if (line.StartsWith("Version")) {
                        entryValue = line.Substring(line.IndexOf("=") + 2);
                        entryValue = entryValue.Remove(entryValue.Length - 1);
                        Log($"Version: {entryValue}");
                    }
                    if (line.StartsWith("Data")) {
                        entryValue = line.Substring(line.IndexOf("=") + 2);
                        entryValue = entryValue.Remove(entryValue.Length - 1);
                        Log($"Data: {entryValue}");
                    }
                }
            } else Log("Connection was successful, but no data was found in the specified location...");
        }

        private void unifytb_ModCreator_SelectedIndexChanged(object sender, EventArgs e) {
            unifytb_ModCreator.Refresh(); //Refresh user control to remove software rendering leftovers.
        }
    }
}
