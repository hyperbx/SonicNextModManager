using System;
using System.IO;
using System.Net;
using System.Linq;
using Unify.Tools;
using System.Drawing;
using Unify.Messages;
using Unify.Networking;
using System.Windows.Forms;
using System.ComponentModel;
using Unify.Networking.GameBanana;

namespace Sonic_06_Mod_Manager.src
{
    public partial class ModOneClickInstall : Form
    {
        public static string styleSheet = string.Empty;
        public WebClient WebClient = new WebClient();
        public static string cache = string.Empty;
        public string downloadURL = string.Empty;
        public string downloadID = string.Empty;
        public string url = string.Empty;
        public GBAPIItemDataBasic item;
        public int modID = 0;

        public ModOneClickInstall(GBAPIItemDataBasic item, string url, int downloadID, int modID) {
            InitializeComponent();

             if (ModManager.dreamcastDay) {
                if (Properties.Settings.Default.dream) 
                    Icon = Properties.Resources.dreamcast_ntsc_icon;
                else
                    Icon = Properties.Resources.dreamcast_pal_icon;
             }

            if (!Properties.Settings.Default.theme) styleSheet = Properties.Resources.GBStyleSheetLight;
            else {
                lbl_Title.ForeColor = SystemColors.Control;
                lbl_Query.ForeColor = SystemColors.Control;
                pnl_Backdrop.BackColor = Color.FromArgb(59, 59, 63);
                pic_Thumbnail.BackColor = Color.FromArgb(45, 45, 48);
                BackColor = Color.FromArgb(28, 28, 28);
                tb_Information.BackColor = Color.FromArgb(45, 45, 48); tb_Information.ForeColor = SystemColors.Control;

                styleSheet = Properties.Resources.GBStyleSheetDark;
            }

            this.url = url;
            this.item = item;
            this.modID = modID;
            this.downloadID = downloadID.ToString();

            downloadURL = $"https://gamebanana.com/mmdl/{downloadID}";
            cache = Path.Combine(Application.StartupPath, "cache");

            lbl_Title.Text = item.ModName;
            Text = $"GameBanana 1-Click Install for {item.ModName}";
            tb_Information.Text = $"Published by {item.OwnerName}\n\n{GBAPI.ProcessCredits(item.Credits)}";

            if (item.Subtitle != string.Empty)
                web_Description.DocumentText = $"<html><body><style>{styleSheet}</style><h1><center>{item.Subtitle}</center></h1><br>{item.Body}</body></html>";
            else
                web_Description.DocumentText = $"<html><body><style>{styleSheet}</style>{item.Body}</body></html>";

            if (modID == 6666) return;

            if (modID == 8021) pic_Thumbnail.BackgroundImage = Properties.Resources.logo_legacy;
            else {
                if (item.ScreenshotURL != null) {
                    try {
                        WebRequest request = WebRequest.Create(item.ScreenshotURL);
                        using (var response = request.GetResponse())
                        using (var stream = response.GetResponseStream()) {
                            pic_Thumbnail.BackgroundImage = Image.FromStream(stream);
                            pic_Thumbnail.BackgroundImageLayout = ImageLayout.Zoom;
                        }
                    }
                    catch { pic_Thumbnail.BackgroundImage = Properties.Resources.logo_exception; }
                }
                else { pic_Thumbnail.BackgroundImage = Properties.Resources.logo_exception; }
            }

            if (lbl_Title.Width >= MinimumSize.Width) {
                Width = lbl_Title.Width + 110;
                MinimumSize = new Size(Width, Height);
            }
        }

        private void Btn_Decline_Click(object sender, System.EventArgs e) {
            if (btn_Decline.Text != "No") {
                string cancel = UnifyMessages.UnifyMessage.Show(ModsMessages.msg_CancelDownloading, SystemMessages.tl_AreYouSure, "YesNo", "Question", false);
                if (cancel == "Yes") Close();
            }
            else Close();
        }

        private void Btn_Accept_Click(object sender, System.EventArgs e) {
            lbl_Query.Visible = false;
            btn_Accept.Visible = false;
            dl_Progress.Visible = true;
            btn_Decline.Text = "Cancel";

            if (modID == 8021) {
                try {
                    var downloads = new TimedWebClient { Timeout = 100000 }.DownloadString("https://segacarnival.com/hyper/mods/legacy-of-solaris.sonic06mm");
                    string[] lines = downloads.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

                    for (int i = 0; i < lines.Length; i++) {
                        var request = (HttpWebRequest)WebRequest.Create(lines[i]);
                        var response = request.GetResponse();
                        var URI = response.ResponseUri;
                        response.Close();

                        using (WebClient wc = new WebClient()) {
                            wc.DownloadProgressChanged += wc_DownloadProgressChanged;

                            string getFile = URI.Segments.Last();
                            string modFolder = Path.Combine(Properties.Settings.Default.modsDirectory, "Legacy of Solaris");
                            string x_archives = Path.Combine(Properties.Settings.Default.modsDirectory, "Legacy of Solaris", "xenon", "archives"); Directory.CreateDirectory(x_archives);
                            string x_sound = Path.Combine(Properties.Settings.Default.modsDirectory, "Legacy of Solaris", "xenon", "sound"); Directory.CreateDirectory(x_sound);
                            string w_archives = Path.Combine(Properties.Settings.Default.modsDirectory, "Legacy of Solaris", "win32", "archives"); Directory.CreateDirectory(w_archives);

                            if (getFile == "mod.ini")
                                wc.DownloadFileAsync(URI, Path.Combine(modFolder, getFile));
                            else if (getFile == "object.arc"  ||
                                     getFile == "player.arc"  ||
                                     getFile == "scripts.arc" ||
                                     getFile == "stage.arc"   ||
                                     getFile == "text.arc")
                                wc.DownloadFileAsync(URI, Path.Combine(x_archives, getFile));
                            else if (getFile == "title_loop_GBn.wmv")
                                wc.DownloadFileAsync(URI, Path.Combine(x_sound, getFile));
                            else if (getFile == "player_silver.arc" ||
                                     getFile == "player_sonic.arc"  ||
                                     getFile == "sprite.arc"        ||
                                     getFile == "stage_e0023.arc"   ||
                                     getFile == "stage_e0026.arc"   ||
                                     getFile == "stage_e0104.arc"   ||
                                     getFile == "stage_e0125.arc"   ||
                                     getFile == "stage_kdv_a.arc"   ||
                                     getFile == "stage_kdv_b.arc"   ||
                                     getFile == "stage_kdv_c.arc"   ||
                                     getFile == "stage_kdv_d.arc")
                                wc.DownloadFileAsync(URI, Path.Combine(w_archives, getFile));
                        }
                    } UnifyMessages.UnifyMessage.Show(ModsMessages.msg_LoSInstalled, SystemMessages.tl_Success, "OK", "Information", false); Close();
                } catch { UnifyMessages.UnifyMessage.Show(ModsMessages.ex_GitHubTimeout, SystemMessages.tl_ServerError, "OK", "Error", false); Close(); }
            } else {
                try {
                    var request = (HttpWebRequest)WebRequest.Create(downloadURL);
                    var response = request.GetResponse();
                    var URI = response.ResponseUri;
                    response.Close();

                    Directory.CreateDirectory(cache);

                    using (WebClient wc = new WebClient()) {
                        wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                        wc.DownloadFileCompleted += wc_DownloadFileCompleted;
                        wc.DownloadFileAsync(URI, Path.Combine(cache, $"{Path.GetFileName(downloadURL)}.bin"));
                    }
                } catch { UnifyMessages.UnifyMessage.Show(ModsMessages.ex_GameBananaTimeout, SystemMessages.tl_ServerError, "OK", "Error", false); Close(); }
            }
        }

        private void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e) { dl_Progress.Value = e.ProgressPercentage; }

        private void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                var bytes = File.ReadAllBytes($"{cache}\\{Path.GetFileName(downloadURL)}.bin").Take(2).ToArray();
                var hexString = BitConverter.ToString(bytes); hexString = hexString.Replace("-", " ");

                if (hexString == "50 4B")
                    Archives.InstallFromZip(Path.Combine(cache, $"{Path.GetFileName(downloadURL)}.bin"), cache);
                else
                    Archives.InstallFrom7zArchive(Path.Combine(cache, $"{Path.GetFileName(downloadURL)}.bin"), cache);

                UnifyMessages.UnifyMessage.Show(ModsMessages.msg_GBInstalled(item.ModName), SystemMessages.tl_Success, "OK", "Information", false); Close();
            }
            catch { UnifyMessages.UnifyMessage.Show(ModsMessages.ex_GBExtractFailed(item.ModName), SystemMessages.tl_ExtractError, "OK", "Error", false); Close(); }
        }
    }
}
