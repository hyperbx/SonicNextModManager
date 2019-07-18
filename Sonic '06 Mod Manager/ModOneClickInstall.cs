using System;
using System.IO;
using System.Net;
using GameBanana;
using System.Linq;
using System.Drawing;
using Microsoft.Win32;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;
using System.IO.Compression;
using System.Text.RegularExpressions;

// Sonic '06 Mod Manager is licensed under the MIT License:
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

// AddModForm code is licensed under the MIT License:
/*
 * MIT License

 * Copyright (c) 2017 thesupersonic16

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

namespace Sonic_06_Mod_Manager
{
    public partial class ModOneClickInstall : Form
    {
        public string URL;
        public string downloadID;
        public GBAPIItemDataBasic Item;
        public WebClient WebClient = new WebClient();
        public static string cache;
        public string downloadURL;
        public int mod;

        public ModOneClickInstall(GBAPIItemDataBasic item, string url, int downloadID, int modID)
        {
            InitializeComponent();
            URL = url;
            Item = item;
            mod = modID;
            this.downloadID = downloadID.ToString();
            downloadURL = $"https://gamebanana.com/mmdl/{downloadID}";
            cache = Path.Combine(Application.StartupPath, "cache");
            title.Text = item.ModName;
            Text = $"GameBanana 1-Click Install for {item.ModName}";
            credits.Text = $"Published by {item.OwnerName}\n\n{ProcessCredits(item.Credits)}";
            if (item.Subtitle != string.Empty) { description.DocumentText = $"<html><body><style>{Properties.Resources.GBStyleSheet}</style><h1><center>{item.Subtitle}</center></h1><br>{Regex.Replace(item.Body, @"Â", "")}</body></html>"; }
            else { description.DocumentText = $"<html><body><style>{Properties.Resources.GBStyleSheet}</style>{Regex.Replace(item.Body, @"Â", "")}</body></html>"; }

            // Loads an Image if the submission contains one
            if (item.ScreenshotURL != null)
            {
                try
                {
                    var request = WebRequest.Create(item.ScreenshotURL);

                    using (var response = request.GetResponse())
                    using (var stream = response.GetResponseStream())
                    {
                        pictureBox1.BackgroundImage = Bitmap.FromStream(stream);
                        pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                    }
                }
                catch { pictureBox1.BackgroundImage = Properties.Resources.logo_image_not_found; }
            }
            else { pictureBox1.BackgroundImage = Properties.Resources.logo_image_not_found; }
        }

        public static string applicationData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public static string ProcessCredits(GBAPICreditGroup[] groups)
        {
            string s = "";
            foreach (var group in groups)
            {
                s += $"{group.GroupName}\n";
                for (int i = 0; i < group.Credits.Length; ++i)
                {
                    s += $"  - {group.Credits[i].MemberName}\n     {group.Credits[i].Role}\n";
                }
            }
            return s;
        }

        public static void InstallFromZip(string ZipPath)
        {
            try
            {
                // Extracts all contents inside of the zip file
                ZipFile.ExtractToDirectory(ZipPath, Properties.Settings.Default.modsPath);

                // Deletes the temp folder with all of its contents
                Directory.Delete(cache, true);
            }
            catch
            {
                InstallFrom7zArchive(ZipPath);
            }
        }

        // Requires 7-Zip to be installed.
        public static void InstallFrom7zArchive(string ArchivePath)
        {
            // Gets 7-Zip's Registry Key.
            var key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\7-Zip");
            // If null then try get it from the 64-bit Registry.
            if (key == null)
                key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
                    .OpenSubKey("SOFTWARE\\7-Zip");
            // Checks if 7-Zip is installed by checking if the key and path value exists.
            if (key != null && key.GetValue("Path") is string path)
            {
                // Path to 7z.exe.
                string exe = Path.Combine(path, "7z.exe");

                // Extracts the archive to the temp folder.
                var psi = new ProcessStartInfo(exe, $"x \"{ArchivePath}\" -o\"{Properties.Settings.Default.modsPath}\" -y");
                psi.CreateNoWindow = true;
                Process.Start(psi).WaitForExit(1000 * 60 * 5);

                // Deletes the temp folder with all of its contents.
                Directory.Delete(cache, true);
                key.Close();
            }
            else
            {
                InstallFromWinRAR(ArchivePath);
            }

        }

        // Requires WinRAR to be installed.
        public static void InstallFromWinRAR(string ArchivePath)
        {
            // Gets WinRAR's Registry Key.
            var key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\WinRAR");
            // If null then try to get it from the 64-bit registry.
            if (key == null)
                key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE\\WinRAR");
            if (key != null && key.GetValue("exe64") is string path)
            {
                // Extracts the archive to the temp folder.
                var psi = new ProcessStartInfo(path, $"x \"{ArchivePath}\" \"{Properties.Settings.Default.modsPath}\"");
                psi.CreateNoWindow = true;
                Process.Start(psi).WaitForExit(1000 * 60 * 5);

                // Deletes the temp folder with all of its contents.
                Directory.Delete(cache, true);
                key.Close();
            }
            else
            {
                MessageBox.Show("Failed to install from archive because 7-Zip or WinRAR is not installed.",
                    "Extract Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Decline_Click(object sender, System.EventArgs e)
        {
            if (btn_Decline.Text != "No")
            {
                DialogResult cancel = MessageBox.Show("Are you sure you want to cancel downloading?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                switch (cancel)
                {
                    case DialogResult.Yes:
                        Close();
                        break;
                }
            }
            else { Close(); }
        }

        private void Btn_Accept_Click(object sender, EventArgs e)
        {
            lbl_Query.Visible = false;
            btn_Accept.Visible = false;
            dl_Progress.Visible = true;
            btn_Decline.Text = "Cancel";

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(downloadURL);
                var response = request.GetResponse();
                var URI = response.ResponseUri;
                response.Close();

                Directory.CreateDirectory(cache);

                using (WebClient wc = new WebClient())
                {
                    wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                    wc.DownloadFileCompleted += wc_DownloadFileCompleted;
                    wc.DownloadFileAsync(URI, $"{cache}\\{Path.GetFileName(downloadURL)}.bin");
                }
            }
            catch
            {
                MessageBox.Show("Unable to establish a connection to GameBanana.", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            dl_Progress.Value = e.ProgressPercentage;
        }

        private void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                var bytes = File.ReadAllBytes($"{cache}\\{Path.GetFileName(downloadURL)}.bin").Take(2).ToArray();
                var hexString = BitConverter.ToString(bytes); hexString = hexString.Replace("-", " ");
                if (hexString == "50 4B")
                {
                    InstallFromZip($"{cache}\\{Path.GetFileName(downloadURL)}.bin");
                }
                else
                {
                    InstallFrom7zArchive($"{cache}\\{Path.GetFileName(downloadURL)}.bin");
                }

                MessageBox.Show($"{Item.ModName} has been installed in your mods directory.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch
            {
                MessageBox.Show($"Failed to extract {Item.ModName}.", "Extract Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void ModOneClickInstall_Shown(object sender, EventArgs e)
        {
            if (mod == 6666)
            {
                MessageBox.Show("Interesting choice of mod, huh...", "Sonic '06 Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
            }
            else
            {
                try
                {
                    var getArchiveList = new Tools.TimedWebClient { Timeout = 100000 }.DownloadString($"https://api.gamebanana.com/Core/Item/Data?itemtype=File&itemid={downloadID}&fields=Metadata().aArchiveFilesList()");
                    if (!getArchiveList.Contains("mod.ini")) { MessageBox.Show("This mod may not be compatible with Sonic '06 Mod Manager.", "Missing Configuration", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                }
                catch { }
            }
        }
    }
}
