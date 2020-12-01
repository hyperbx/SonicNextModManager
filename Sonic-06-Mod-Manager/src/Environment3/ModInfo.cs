using System;
using System.IO;
using System.Net;
using System.Linq;
using Unify.Patcher;
using System.Drawing;
using Unify.Messenger;
using Unify.Networking;
using Unify.Serialisers;
using Unify.Globalisation;
using System.Windows.Forms;
using System.IO.Compression;

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

namespace Unify.Environment3
{
    public partial class ModInfo : Form
    {
        string metadata, data, version, modDirectory = string.Empty;

        public ModInfo(string mod) {
            InitializeComponent();

            modDirectory = Path.GetDirectoryName(mod);

            string[] getThumbnail = Directory.GetFiles(modDirectory, "thumbnail*", SearchOption.TopDirectoryOnly);
            foreach (var img in getThumbnail)
                pic_Thumbnail.BackgroundImage = Image.FromFile(img);

            lbl_Title.Text = Text = INI.DeserialiseKey("Title", mod);
            tb_Information.Text += $"Version: {version = INI.DeserialiseKey("Version", mod)}\n";
            tb_Information.Text += $"Date: {INI.DeserialiseKey("Date", mod)}\n";
            tb_Information.Text += $"Author: {INI.DeserialiseKey("Author", mod)}\n";
            tb_Information.Text += $"Platform: {INI.DeserialiseKey("Platform", mod)}\n";
            tb_Information.Text += $"Merge: {Literal.Bool(INI.DeserialiseKey("Merge", mod))}\n";
            tb_Description.Text += INI.DeserialiseKey("Description", mod).Replace(@"\n", Environment.NewLine);
            if ((metadata = INI.DeserialiseKey("Metadata", mod)) != string.Empty) btn_Update.Enabled = pgb_Progress.Enabled = true;
            data = INI.DeserialiseKey("Data", mod);

            if (lbl_Title.Width >= (MinimumSize.Width - pic_Logo.Width)) {
                Width = lbl_Title.Width + 110;
                MinimumSize = new Size(Width, Height);
            }
        }

        private void ModInfo_FormClosing(object sender, FormClosingEventArgs e) { pic_Thumbnail.BackgroundImage.Dispose(); }

        private async void Btn_Update_Click(object sender, EventArgs e) {
            string archive = Path.GetTempFileName();
            string metadata, version = string.Empty;

            try { metadata = await Client.RequestString(this.metadata); }
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
                using (WebClient client = new WebClient()) {
                    client.DownloadProgressChanged += (s, dlevent) => { pgb_Progress.Value = dlevent.ProgressPercentage; };
                    await client.DownloadFileTaskAsync(new Uri(data), archive);
                    client.DownloadFileCompleted += (s, dlevent) => {
                        byte[] bytes = File.ReadAllBytes(archive).Take(2).ToArray();
                        string hexString = BitConverter.ToString(bytes); hexString = hexString.Replace("-", " ");
                        DirectoryInfo extractData = new DirectoryInfo(modDirectory);
                        pic_Thumbnail.BackgroundImage.Dispose();
                        pic_Thumbnail.BackgroundImage = Properties.Resources.Exception_Logo_Full_Colour;

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
                            using (ZipArchive zip = new ZipArchive(new MemoryStream(File.ReadAllBytes(archive))))
                                ZIP.ExtractToDirectory(zip, Properties.Settings.Default.Path_ModsDirectory, true);
                        else
                            ZIP.InstallFromCustomArchive(archive, Properties.Settings.Default.Path_ModsDirectory);

                        UnifyMessenger.UnifyMessage.ShowDialog($"{lbl_Title.Text} has been updated successfully...",
                                                               lbl_Title.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        File.Delete(archive);
                        Close();
                    };
                }
            } else
                UnifyMessenger.UnifyMessage.ShowDialog("There are currently no updates available.",
                                                       lbl_Title.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
