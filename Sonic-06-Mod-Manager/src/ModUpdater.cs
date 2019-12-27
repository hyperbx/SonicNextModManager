using System;
using System.IO;
using System.Net;
using System.Text;
using System.Linq;
using Unify.Tools;
using Unify.Messages;
using System.Drawing;
using Unify.Networking;
using System.Windows.Forms;
using System.IO.Compression;
using System.Collections.Generic;

namespace Sonic_06_Mod_Manager
{
    public partial class ModUpdater : Form
    {
        public static List<string> configs = new List<string>() { }; // Defines the configs list for 'mod.ini' files
        string metadata = string.Empty, data = string.Empty;

        public ModUpdater() {
            InitializeComponent();

            if (ModManager.christmas)
                Icon = Properties.Resources.icon_christmas;

            if (Properties.Settings.Default.theme) {
                BackColor = Color.FromArgb(28, 28, 28);
                pnl_InfoBackdrop.BackColor = tb_Information.BackColor =
                    pnl_ModBackdrop.BackColor = list_Mods.BackColor = Color.FromArgb(45, 45, 48);
                tb_Information.ForeColor = list_Mods.ForeColor = SystemColors.Control;
            } else
                pnl_InfoBackdrop.BackColor = tb_Information.BackColor =
                    pnl_ModBackdrop.BackColor = list_Mods.BackColor = SystemColors.ControlLightLight;

            configs.Clear();
            foreach (var mod in Directory.GetFiles(Properties.Settings.Default.modsDirectory, "mod.ini", SearchOption.AllDirectories)) {
                string line       = string.Empty,
                       entryValue = string.Empty,
                       title      = string.Empty,
                       version    = string.Empty,
                       versionDL  = string.Empty,
                       metadata   = string.Empty,
                       metadataDL = string.Empty,
                       data       = string.Empty;

                using (StreamReader configFile = new StreamReader(mod))
                    try {
                        while ((line = configFile.ReadLine()) != null) {
                            if (line.StartsWith("Title")) {
                                entryValue = line.Substring(line.IndexOf("=") + 2);
                                entryValue = entryValue.Remove(entryValue.Length - 1);
                                title = entryValue;
                            }
                            if (line.StartsWith("Version")) {
                                entryValue = line.Substring(line.IndexOf("=") + 2);
                                entryValue = entryValue.Remove(entryValue.Length - 1);
                                version = entryValue;
                            }
                            if (line.StartsWith("Metadata")) {
                                entryValue = line.Substring(line.IndexOf("=") + 2);
                                entryValue = entryValue.Remove(entryValue.Length - 1);
                                metadata = entryValue;
                            }
                            if (line.StartsWith("Data")) {
                                entryValue = line.Substring(line.IndexOf("=") + 2);
                                entryValue = entryValue.Remove(entryValue.Length - 1);
                                data = entryValue;
                            }
                        }

                        
                        if (metadata.Length != 0) {
                            try { metadataDL = new TimedWebClient { Timeout = 100000 }.DownloadString(metadata); }
                            catch { return; }

                            if (metadataDL.Length != 0) {
                                string[] splitMetadata = metadataDL.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

                                foreach (string metadataLine in splitMetadata) {
                                    string metadataEntry = string.Empty;
                                    if (metadataLine.StartsWith("Version")) {
                                        metadataEntry = metadataLine.Substring(metadataLine.IndexOf("=") + 2);
                                        metadataEntry = metadataEntry.Remove(metadataEntry.Length - 1);
                                        versionDL = metadataEntry;
                                    }
                                    if (metadataLine.StartsWith("Data")) {
                                        metadataEntry = metadataLine.Substring(metadataLine.IndexOf("=") + 2);
                                        metadataEntry = metadataEntry.Remove(metadataEntry.Length - 1);
                                        if (data != metadataEntry) data = metadataEntry;
                                    }
                                }

                                if (versionDL != version) {
                                    list_Mods.Items.Add(title);
                                    configs.Add(mod);
                                }
                            }
                        }
                    } catch { }
            }
        }

        private void list_Mods_SelectedIndexChanged(object sender, EventArgs e) {
            tb_Information.Clear();
            if (list_Mods.SelectedIndex != -1) {
                using (StreamReader configFile = new StreamReader(configs[list_Mods.SelectedIndex], Encoding.Default)) {
                    string line       = string.Empty,
                           entryValue = string.Empty,
                           title      = string.Empty,
                           version    = string.Empty,
                           versionDL  = string.Empty,
                           metadata   = string.Empty,
                           metadataDL = string.Empty,
                           data       = string.Empty;

                    while ((line = configFile.ReadLine()) != null) {
                        if (line.StartsWith("Version")) {
                            entryValue = line.Substring(line.IndexOf("=") + 2);
                            entryValue = entryValue.Remove(entryValue.Length - 1);
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
                        if (line.StartsWith("Description")) {
                            entryValue = line.Substring(line.IndexOf("=") + 2);
                            entryValue = entryValue.Remove(entryValue.Length - 1);
                            tb_Information.Text += $"\n{entryValue}\n";
                        }
                        if (line.StartsWith("Metadata")) {
                            entryValue = line.Substring(line.IndexOf("=") + 2);
                            entryValue = entryValue.Remove(entryValue.Length - 1);
                            this.metadata = metadata = entryValue;
                        }
                        if (line.StartsWith("Data")) {
                            entryValue = line.Substring(line.IndexOf("=") + 2);
                            entryValue = entryValue.Remove(entryValue.Length - 1);
                            this.data = entryValue;
                        }
                    }

                    if (metadata.Length != 0) {
                        try { metadataDL = new TimedWebClient { Timeout = 100000 }.DownloadString(metadata); }
                        catch { return; }

                        if (metadataDL.Length != 0) {
                            string[] splitMetadata = metadataDL.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

                            foreach (string metadataLine in splitMetadata) {
                                string metadataEntry = string.Empty;
                                if (metadataLine.StartsWith("Version")) {
                                    metadataEntry = metadataLine.Substring(metadataLine.IndexOf("=") + 2);
                                    metadataEntry = metadataEntry.Remove(metadataEntry.Length - 1);
                                    versionDL = metadataEntry;
                                }
                            }

                            tb_Information.Text += $"\nPlease update to {versionDL}...";
                        }
                    }
                }
                btn_Update.Enabled = true;
            } else btn_Update.Enabled = false;
        }

        private void ModUpdater_Shown(object sender, EventArgs e) {
            if (list_Mods.Items.Count == 0) {
                UnifyMessages.UnifyMessage.Show("All mods are up-to-date...", "Mod Updater", "OK", "Information");
                Close();
            }
        }

        private void btn_Update_Click(object sender, EventArgs e) {
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

            var clientApplication = new WebClient();
            clientApplication.DownloadProgressChanged += (s, dlevent) => { pgb_Progress.Value = dlevent.ProgressPercentage; };
            clientApplication.DownloadFileAsync(new Uri(data), archive);
            clientApplication.DownloadFileCompleted += (s, dlevent) => {
                var bytes = File.ReadAllBytes(archive).Take(2).ToArray();
                var hexString = BitConverter.ToString(bytes); hexString = hexString.Replace("-", " ");
                var extractData = new DirectoryInfo(Path.GetDirectoryName(configs[list_Mods.SelectedIndex]));

                try {
                    if (Directory.Exists(Path.GetDirectoryName(configs[list_Mods.SelectedIndex]))) {
                        foreach (FileInfo file in extractData.GetFiles())
                            file.Delete();
                        foreach (DirectoryInfo directory in extractData.GetDirectories())
                            directory.Delete(true);
                    }
                    Directory.Delete(Path.GetDirectoryName(configs[list_Mods.SelectedIndex]));
                } catch { }

                if (hexString == "50 4B")
                    using (ZipArchive zArchive = new ZipArchive(new MemoryStream(File.ReadAllBytes(archive))))
                        Archives.ExtractToDirectory(zArchive, Properties.Settings.Default.modsDirectory, true);
                else Archives.InstallFrom7zArchive(archive);

                UnifyMessages.UnifyMessage.Show(ModsMessages.msg_ModUpdated(list_Mods.SelectedItem.ToString()), SystemMessages.tl_Success, "OK", "Information");

                File.Delete(archive);
                Close();
            };
        }
    }
}
