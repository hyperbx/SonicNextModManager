using System;
using System.IO;
using System.Net;
using System.Linq;
using Unify.Patcher;
using System.Drawing;
using Unify.Messenger;
using System.Windows.Forms;
using System.ComponentModel;
using Unify.Networking.GameBanana;

namespace Unify.Environment3
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
        string archive = string.Empty;
        public int modID = 0;

        public ModOneClickInstall(GBAPIItemDataBasic item, string url, int downloadID, int modID) {
            InitializeComponent();

            lbl_Title.ForeColor = SystemColors.Control;
            lbl_Query.ForeColor = SystemColors.Control;
            pnl_Backdrop.BackColor = Color.FromArgb(59, 59, 63);
            pic_Thumbnail.BackColor = Color.FromArgb(45, 45, 48);
            BackColor = Color.FromArgb(28, 28, 28);
            tb_Information.BackColor = Color.FromArgb(45, 45, 48); tb_Information.ForeColor = SystemColors.Control;
            styleSheet = Properties.Resources.GBStyleSheetDark;

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
                web_Description.DocumentText = $"<html><head><meta charset=\"UTF-8\"><style>{styleSheet}</style></head><body><h1><center>{item.Subtitle}</center></h1><br>{item.Body}</body></html>";
            else
                web_Description.DocumentText = $"<html><head><meta charset=\"UTF-8\"><style>{styleSheet}</style></head><body>{item.Body}</body></html>";

            if (modID == 6666) return;

            if (item.ScreenshotURL != null) {
                try {
                    WebRequest request = WebRequest.Create(item.ScreenshotURL);
                    using (var response = request.GetResponse())
                    using (var stream = response.GetResponseStream()) {
                        pic_Thumbnail.BackgroundImage = Image.FromStream(stream);
                        pic_Thumbnail.BackgroundImageLayout = ImageLayout.Zoom;
                    }
                }
                catch { pic_Thumbnail.BackgroundImage = Properties.Resources.Exception_Logo_Full_Colour; }
            }
            else { pic_Thumbnail.BackgroundImage = Properties.Resources.Exception_Logo_Full_Colour; }

            if (lbl_Title.Width >= (MinimumSize.Width - pic_Logo.Width)) {
                Width = lbl_Title.Width + 110;
                MinimumSize = new Size(Width, Height);
            }
        }

        private void Btn_Decline_Click(object sender, System.EventArgs e) {
            if (btn_Decline.Text != "No") {
                DialogResult cancel = UnifyMessenger.UnifyMessage.ShowDialog("Are you sure you want to cancel downloading?",
                                                                             "Cancel download?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cancel == DialogResult.Yes) Close();
            }
            else Close();
        }

        private void Btn_Accept_Click(object sender, System.EventArgs e) {
            lbl_Query.Visible = false;
            btn_Accept.Visible = false;
            dl_Progress.Visible = true;
            btn_Decline.Text = "Cancel";

            try {
                var request = (HttpWebRequest)WebRequest.Create(downloadURL);
                var response = request.GetResponse();
                var URI = response.ResponseUri;
                response.Close();

                archive = Path.GetTempFileName();

                using (WebClient wc = new WebClient()) {
                    wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                    wc.DownloadFileCompleted += wc_DownloadFileCompleted;
                    wc.DownloadFileAsync(URI, archive);
                }
            } catch {
                UnifyMessenger.UnifyMessage.ShowDialog("Unable to establish a connection to GameBanana.",
                                                       "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e) { dl_Progress.Value = e.ProgressPercentage; }

        private void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                var bytes = File.ReadAllBytes(archive).Take(2).ToArray();
                var hexString = BitConverter.ToString(bytes); hexString = hexString.Replace("-", " ");

                if (hexString == "50 4B") ZIP.InstallFromZip(archive);
                else ZIP.InstallFrom7zArchive(archive);

                UnifyMessenger.UnifyMessage.ShowDialog($"{item.ModName} has been installed in your mods directory.",
                                                       "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();

                File.Delete(archive);
            } catch {
                UnifyMessenger.UnifyMessage.ShowDialog($"Failed to extract {item.ModName}...",
                                                       "Extract failed...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }
    }
}
