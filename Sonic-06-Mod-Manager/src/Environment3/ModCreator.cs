using System;
using System.IO;
using System.Linq;
using System.Drawing;
using Unify.Messenger;
using Unify.Networking;
using Unify.Serialisers;
using Unify.Globalisation;
using System.Windows.Forms;

// Sonic '06 Mod Manager is licensed under the MIT License:
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

namespace Unify.Environment3
{
    public partial class ModCreator : Form
    {
        string modThumbnail = string.Empty;
        string mod = string.Empty;
        bool edit = false;

        public ModCreator(string mod, bool edit)
        {
            InitializeComponent();
            this.mod = mod;
            this.edit = edit;
            if (!this.edit) {
                text_Version.Text = "1.0";
                text_Date.Text = DateTime.Now.ToString("dd/MM/yyyy");
                text_Author.Text = Environment.UserName;
                combo_System.SelectedIndex = 0;
                lbl_ReadOnly.ForeColor = SystemColors.GrayText;
            }

            unifytb_ModCreator.ActiveColor = unifytb_ModCreator.HorizontalLineColor = Properties.Settings.Default.AccentColour;
            if (Properties.Settings.Default.HighContrastText) unifytb_ModCreator.SelectedTextColor = SystemColors.ControlText;

            if (edit) {
                if (File.Exists(mod)) {
                    text_Title.Text = INI.DeserialiseKey("Title", mod);
                    text_Version.Text = INI.DeserialiseKey("Version", mod);
                    text_Date.Text = INI.DeserialiseKey("Date", mod);
                    text_Author.Text = INI.DeserialiseKey("Author", mod);

                    switch (INI.DeserialiseKey("Platform", mod))
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
                        default:
                            combo_System.SelectedIndex = 0;
                            break;
                    }

                    try {
                        if (check_Merge.Checked = bool.Parse(INI.DeserialiseKey("Merge", mod))) {
                            text_ReadOnly.Enabled = true;
                            btn_ReadOnlyBrowser.Enabled = true;
                            lbl_ReadOnly.ForeColor = SystemColors.Control;
                        }
                    } catch { /* ignored */ }

                    text_ReadOnly.Text = INI.DeserialiseKey("Read-only", mod);
                    text_Custom.Text = INI.DeserialiseKey("Custom", mod);
                    text_Save.Text = INI.DeserialiseKey("Save", mod);
                    tb_Description.Text += INI.DeserialiseKey("Description", mod).Replace(@"\n", Environment.NewLine);
                    text_Server.Text += INI.DeserialiseKey("Metadata", mod).Replace(@"\n", Environment.NewLine);
                    text_Data.Text += INI.DeserialiseKey("Data", mod);
                }
                else { Close(); }

                btn_Create.Text = "Edit Mod";
                btn_Create.BackColor = Color.SkyBlue;
                btn_Delete.Visible = true;

                if (Directory.Exists(mod)) {
                    string[] getThumbnail = Directory.GetFiles(mod, "thumbnail*", SearchOption.TopDirectoryOnly);
                    foreach (var img in getThumbnail) {
                        pic_Thumbnail.BackgroundImage = Image.FromFile(img);
                    }
                }
            }
        }

        public static bool FilePathHasInvalidChars(string path)
        {
            return !string.IsNullOrEmpty(path) && path.IndexOfAny(Path.GetInvalidPathChars()) >= 0;
        }

        private void Btn_Create_Click(object sender, EventArgs e)
        {
            try {
                string safeTitle = text_Title.Text.Replace(@"\", "")
                                                  .Replace("/", " - ")
                                                  .Replace(":", " - ")
                                                  .Replace("*", "")
                                                  .Replace("?", "")
                                                  .Replace("\"", "'")
                                                  .Replace("<", "")
                                                  .Replace(">", "")
                                                  .Replace("|", "");

                if (Directory.Exists(Path.Combine(Properties.Settings.Default.ModsDirectory, safeTitle)) && !edit)
                    UnifyMessenger.UnifyMessage.ShowDialog($"A mod called {safeTitle} already exists. Please rename your mod.",
                                                           "I/O Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else {
                    pic_Thumbnail.BackgroundImage.Dispose();
                    pic_Thumbnail.BackgroundImage = Properties.Resources.Exception_Logo_Full_Colour;

                    string newPath = Path.Combine(Properties.Settings.Default.ModsDirectory, safeTitle);

                    if (!edit)
                        Directory.CreateDirectory(newPath);
                    else if (!Directory.Exists(newPath))
                        Directory.Move(mod, newPath);

                    using (Stream configCreate = File.Open(Path.Combine(newPath, "mod.ini"), FileMode.Create))
                    using (StreamWriter configInfo = new StreamWriter(configCreate)) {
                                                                configInfo.WriteLine("[Details]");
                                                                configInfo.WriteLine($"Title=\"{text_Title.Text}\"");
                        if (text_Version.Text != string.Empty)  configInfo.WriteLine($"Version=\"{text_Version.Text}\"");
                        if (text_Date.Text != string.Empty)     configInfo.WriteLine($"Date=\"{text_Date.Text}\"");
                        if (text_Author.Text != string.Empty)   configInfo.WriteLine($"Author=\"{text_Author.Text}\"");
                                                                configInfo.WriteLine($"Platform=\"{combo_System.Text}\"");

                                                                configInfo.WriteLine("\n[Filesystem]");
                                                                configInfo.WriteLine($"Merge=\"{check_Merge.Checked.ToString()}\"");
                        if (text_Custom.Text != string.Empty)   configInfo.WriteLine($"Custom=\"{text_Custom.Text}\"");
                        if (text_ReadOnly.Text != string.Empty) configInfo.WriteLine($"Read-only=\"{text_ReadOnly.Text}\"");

                        if (text_Save.Text != string.Empty && combo_System.SelectedIndex == 0)
                            configInfo.WriteLine($"Save=\"savedata.360\"");
                        else if (text_Save.Text != string.Empty && combo_System.SelectedIndex == 1)
                            configInfo.WriteLine($"Save=\"savedata.ps3\"");

                        if (tb_Description.Text != string.Empty) {
                            string descriptionText = string.Empty;
                            string lastLine = tb_Description.Lines.Last();
                            foreach (var newLine in tb_Description.Lines) {
                                if (newLine != lastLine) descriptionText += $"{newLine}\\n";
                                else descriptionText += newLine;
                            }
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

                    if (text_Save.Text == string.Empty && edit) {
                        try {
                            string[] getSaveData = Directory.GetFiles(newPath, "savedata*", SearchOption.TopDirectoryOnly);
                            foreach (var save in getSaveData)
                                if (File.Exists(save)) File.Delete(save);
                        } catch (Exception ex) {
                            UnifyMessenger.UnifyMessage.ShowDialog($"An error occurred whilst removing the save data.",
                                                                   "I/O Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Console.WriteLine(ex);
                        }
                    }

                    if (check_GenerateFilesystem.Checked && Path.GetDirectoryName(Properties.Settings.Default.GameDirectory) != string.Empty) {
                        string[] directories = Directory.GetDirectories(Path.GetDirectoryName(Properties.Settings.Default.GameDirectory), "*.*", SearchOption.AllDirectories);

                        foreach (string path in directories) {
                            string pathTrim = path.Remove(0, Path.GetDirectoryName(Properties.Settings.Default.GameDirectory).Length).Substring(1);
                            if (combo_System.SelectedIndex == 2) {
                                if (!pathTrim.Contains("xenon") && !pathTrim.Contains("ps3"))
                                    Directory.CreateDirectory(Path.Combine(newPath, pathTrim));
                            } else
                                Directory.CreateDirectory(Path.Combine(newPath, pathTrim));
                        }
                    }

                    Close();
                }
            } catch {
                UnifyMessenger.UnifyMessage.ShowDialog($"Failed to edit '{Path.GetFileName(Path.GetDirectoryName(mod))}.' Please ensure that nothing is accessing that mod's directory, or delete it manually.",
                                                       "I/O Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Text_Title_TextChanged(object sender, EventArgs e) {
            if (text_Title.Text != string.Empty)
                btn_Create.Enabled = true;
            else
                btn_Create.Enabled = false;
        }

        private void Check_Merge_CheckedChanged(object sender, EventArgs e) {
            if (check_Merge.Checked) {
                text_ReadOnly.Enabled = true;
                btn_ReadOnlyBrowser.Enabled = true;
                lbl_ReadOnly.ForeColor = SystemColors.Control;
            } else {
                text_ReadOnly.Enabled = false;
                btn_ReadOnlyBrowser.Enabled = false;
                lbl_ReadOnly.ForeColor = SystemColors.GrayText;
            }
        }

        private void Btn_Browse_Click(object sender, EventArgs e)  {
            OpenFileDialog thumbnail = new OpenFileDialog {
                Title = "Please search for a thumbnail...",
                Filter = "PNG (*.png)|*.png|JPEG (*.jpg; *.jpeg; *.jpe; *.jfif)|*.jpg; *.jpeg; *.jpe; *.jfif|BMP (*.bmp)|*.bmp"
            };

            if (thumbnail.ShowDialog() == DialogResult.OK) { 
                pic_Thumbnail.BackgroundImage = new Bitmap(thumbnail.FileName);
                modThumbnail = thumbnail.FileName;
            }
        }

        private void Btn_ReadOnlyBrowser_Click(object sender, EventArgs e) {
            string csvList = string.Empty;

            OpenFileDialog readonlyARC = new OpenFileDialog {
                Title = "Please select files to make read-only...",
                Filter = "ARC files (*.arc)|*.arc",
                Multiselect = true
            };

            if (readonlyARC.ShowDialog() == DialogResult.OK)
                foreach (string name in readonlyARC.FileNames)
                    csvList += $"{Path.GetFileName(name)},";

            if (csvList != string.Empty) {
                if (text_ReadOnly.Text != string.Empty && !text_ReadOnly.Text.EndsWith(","))
                    text_ReadOnly.Text += $",{csvList.Substring(0, csvList.Length - 1)}";
                else
                    text_ReadOnly.Text += csvList.Substring(0, csvList.Length - 1);
            }
        }

        private void Btn_RemoveThumbnail_Click(object sender, EventArgs e) {
            pic_Thumbnail.BackgroundImage.Dispose();
            pic_Thumbnail.BackgroundImage = Properties.Resources.Exception_Logo_Full_Colour;
            modThumbnail = string.Empty;
        }

        private void Btn_SaveBrowser_Click(object sender, EventArgs e) {
            OpenFileDialog save;

            switch (combo_System.SelectedIndex) {
                case 0:
                    save = new OpenFileDialog {
                        Title = $"Please select Sonic '06 save data for the Xbox 360...",
                        Filter = "Xbox 360 Save File (SonicNextSaveData.bin)|SonicNextSaveData.bin",
                        Multiselect = true
                    };
                    break;
                case 1:
                    save = new OpenFileDialog {
                        Title = $"Please select Sonic '06 save data for the PlayStation 3...",
                        Filter = "PlayStation 3 Save File (SYS-DATA)|SYS-DATA",
                        Multiselect = true
                    };
                    break;
                default:
                    save = new OpenFileDialog {
                        Title = $"Please select Sonic '06 save data...",
                        Filter = "Xbox 360 Save File (SonicNextSaveData.bin)|SonicNextSaveData.bin|PlayStation 3 Save File (SYS-DATA)|SYS-DATA",
                        Multiselect = true
                    };
                    break;
            }

            if (save.ShowDialog() == DialogResult.OK)
                text_Save.Text = save.FileName;
        }

        private void Combo_System_SelectedIndexChanged(object sender, EventArgs e) {
            if (combo_System.SelectedIndex == 2) {
                lbl_Save.ForeColor = SystemColors.GrayText;
                text_Save.Enabled = false;
                btn_SaveBrowser.Enabled = false;
            } else {
                lbl_Save.ForeColor = SystemColors.Control;
                text_Save.Enabled = true;
                btn_SaveBrowser.Enabled = true;
            }
        }

        private void Text_UpdateURL_TextChanged(object sender, EventArgs e) {
            if (text_Server.Text.Length != 0) btn_TestConnection.Enabled = true;
            else btn_TestConnection.Enabled = false;
        }

        private void Log(string value) { list_Console.Items.Add($"[{DateTime.Now.ToString("HH:mm:ss tt")}] {value}"); }

        private async void Btn_TestConnection_Click(object sender, EventArgs e) {
            string metadata = string.Empty;
            list_Console.Items.Clear();

            Log("Establishing connection to server...");
            try { metadata = await Client.RequestString(text_Server.Text); }
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

        private void Btn_CustomArchives_Click(object sender, EventArgs e) {
            string csvList = string.Empty;

            //Select ARCs for Read-only parameters and save.
            OpenFileDialog customData = new OpenFileDialog {
                Title = "Please select your custom data...",
                Filter = "All files (*.*)|*.*",
                Multiselect = true
            };

            if (customData.ShowDialog() == DialogResult.OK)
                foreach (string name in customData.FileNames)
                    csvList += $"{Path.GetFileName(name)},";

            if (csvList != string.Empty) {
                if (text_Custom.Text != string.Empty && !text_Custom.Text.EndsWith(","))
                    text_Custom.Text += $",{csvList.Substring(0, csvList.Length - 1)}";
                else
                    text_Custom.Text += csvList.Substring(0, csvList.Length - 1);
            }
        }
    }
}