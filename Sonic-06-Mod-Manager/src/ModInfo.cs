using System;
using System.IO;
using System.Net;
using System.Text;
using System.Linq;
using Unify.Tools;
using System.Drawing;
using Unify.Messages;
using Unify.Networking;
using System.Windows.Forms;
using System.IO.Compression;


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
    public partial class ModInfo : Form
    {
        string metadata, data, version, modDirectory = string.Empty;

        public ModInfo(string modPath) {
            InitializeComponent();

            modDirectory = modPath;

            if (ModManager.dreamcastDay) {
                if (Properties.Settings.Default.dream)
                    Icon = Properties.Resources.dreamcast_ntsc_icon;
                else
                    Icon = Properties.Resources.dreamcast_pal_icon;
            }

            if (ModManager.christmas) Icon = Properties.Resources.icon_christmas;

            if (Properties.Settings.Default.theme) {
                lbl_Title.ForeColor = SystemColors.Control;
                pnl_Backdrop.BackColor = Color.FromArgb(59, 59, 63);
                pic_Thumbnail.BackColor = Color.FromArgb(45, 45, 48);
                BackColor = Color.FromArgb(28, 28, 28);
                tb_Description.BackColor = Color.FromArgb(45, 45, 48); tb_Description.ForeColor = SystemColors.Control;
                tb_Information.BackColor = Color.FromArgb(45, 45, 48); tb_Information.ForeColor = SystemColors.Control;
            }

            string[] getThumbnail = Directory.GetFiles(modPath, "thumbnail*", SearchOption.TopDirectoryOnly);
            foreach (var img in getThumbnail)
                pic_Thumbnail.BackgroundImage = Image.FromFile(img);

            using (StreamReader configFile = new StreamReader($"{Path.Combine(modPath)}\\mod.ini", Encoding.Default)) {
                string line;
                string entryValue;
                while ((line = configFile.ReadLine()) != null) {
                    if (line.StartsWith("Title")) {
                        entryValue = line.Substring(line.IndexOf("=") + 2);
                        entryValue = entryValue.Remove(entryValue.Length - 1);
                        lbl_Title.Text = entryValue;
                        Text = entryValue;
                    }
                    if (line.StartsWith("Version")) {
                        entryValue = line.Substring(line.IndexOf("=") + 2);
                        entryValue = entryValue.Remove(entryValue.Length - 1);
                        version = entryValue;
                        tb_Information.Text += $"Version: {entryValue}\n";
                    }
                    if (line.StartsWith("Date")) {
                        entryValue = line.Substring(line.IndexOf("=") + 2);
                        entryValue = entryValue.Remove(entryValue.Length - 1);
                        tb_Information.Text += $"Date: {entryValue}\n";
                    }
                    if (line.StartsWith("Author")) {
                        entryValue = line.Substring(line.IndexOf("=") + 2);
                        entryValue = entryValue.Remove(entryValue.Length - 1);
                        tb_Information.Text += $"Author: {entryValue}\n";
                    }
                    if (line.StartsWith("Platform")) {
                        entryValue = line.Substring(line.IndexOf("=") + 2);
                        entryValue = entryValue.Remove(entryValue.Length - 1);
                        tb_Information.Text += $"Platform: {entryValue}\n";
                    }
                    if (line.StartsWith("Merge")) {
                        entryValue = line.Substring(line.IndexOf("=") + 2);
                        entryValue = entryValue.Remove(entryValue.Length - 1);
                        tb_Information.Text += $"Merge: {entryValue}\n";
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
                        metadata = entryValue.Replace(@"\n", Environment.NewLine);
                        if (entryValue.Length > 0) btn_Update.Enabled = pgb_Progress.Enabled = true;
                    }
                    if (line.StartsWith("Data")) 
                    {
                        entryValue = line.Substring(line.IndexOf("=") + 2);
                        entryValue = entryValue.Remove(entryValue.Length - 1);
                        data = entryValue.Replace(@"\n", Environment.NewLine);
                    }
                }
            }

            if (lbl_Title.Width >= MinimumSize.Width) {
                Width = lbl_Title.Width + 110;
                MinimumSize = new Size(Width, Height);
            }
        }

        private void ModInfo_FormClosing(object sender, FormClosingEventArgs e) { pic_Thumbnail.BackgroundImage.Dispose(); }

        private void Btn_Update_Click(object sender, EventArgs e) {
            string archive = Path.GetTempFileName();
            string metadata, version = string.Empty;

            try { metadata = new TimedWebClient { Timeout = 100000 }.DownloadString(this.metadata); }
            catch { return; }

            if (metadata.Length != 0) {
                string[] splitMetadata = metadata.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

                foreach (string line in splitMetadata) {
                    string entryValue = string.Empty;
                    if (line.StartsWith("Version")) {
                        entryValue = line.Substring(line.IndexOf("=") + 2);
                        entryValue = entryValue.Remove(entryValue.Length - 1);
                        version = entryValue;
                    }
                    if (line.StartsWith("Data")) {
                        entryValue = line.Substring(line.IndexOf("=") + 2);
                        entryValue = entryValue.Remove(entryValue.Length - 1);
                        if (data != entryValue) data = entryValue;
                    }
                }
            }

            if (version != this.version) {
                var clientApplication = new WebClient();
                clientApplication.DownloadProgressChanged += (s, dlevent) => { pgb_Progress.Value = dlevent.ProgressPercentage; };
                clientApplication.DownloadFileAsync(new Uri(data), archive);
                clientApplication.DownloadFileCompleted += (s, dlevent) => {
                    var bytes = File.ReadAllBytes(archive).Take(2).ToArray();
                    var hexString = BitConverter.ToString(bytes); hexString = hexString.Replace("-", " ");
                    var extractData = new DirectoryInfo(modDirectory);
                    pic_Thumbnail.BackgroundImage.Dispose();
                    pic_Thumbnail.BackgroundImage = Properties.Resources.logo_exception;

                    try {
                        if (Directory.Exists(modDirectory)) {
                            foreach (FileInfo file in extractData.GetFiles())
                                file.Delete();
                            foreach (DirectoryInfo directory in extractData.GetDirectories())
                                directory.Delete(true);
                        }
                        Directory.Delete(modDirectory);
                    } catch { }

                    if (hexString == "50 4B")
                        using (ZipArchive zArchive = new ZipArchive(new MemoryStream(File.ReadAllBytes(archive))))
                            Archives.ExtractToDirectory(zArchive, Properties.Settings.Default.modsDirectory, true);
                    else Archives.InstallFrom7zArchive(archive);

                    UnifyMessages.UnifyMessage.Show(ModsMessages.msg_ModUpdated(lbl_Title.Text), SystemMessages.tl_Success, "OK", "Information");

                    File.Delete(archive);
                    Close();
                };
            } else UnifyMessages.UnifyMessage.Show(SystemMessages.msg_NoUpdates, lbl_Title.Text, "OK", "Information");
        }
    }
}
