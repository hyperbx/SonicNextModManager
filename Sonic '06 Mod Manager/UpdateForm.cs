using System;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Windows.Forms;

namespace Sonic_06_Mod_Manager
{
    public partial class UpdateForm : Form
    {
        string versionString;
        string urlString;
        bool enabledBool;

        public UpdateForm(string versionNumber, string url, bool enabled)
        {
            InitializeComponent();

            versionString = versionNumber;
            urlString = url;
            enabledBool = enabled;
        }

        private void UpdateForm_Load(object sender, System.EventArgs e)
        {
            label1.Text = $"Updating Sonic '06 Mod Manager to {versionString}...";
            Width = label1.Width + 40;

            if (enabledBool)
            {
                UpdateVersion();
            }
            else
            {
                MessageBox.Show("How did I get here?", "What?!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void UpdateVersion()
        {
            var clientApplication = new WebClient();
            clientApplication.DownloadProgressChanged += (s, e) => { pgb_Progress.Value = e.ProgressPercentage; };
            clientApplication.DownloadFileAsync(new Uri(urlString), Application.ExecutablePath + ".pak");
            clientApplication.DownloadFileCompleted += (s, e) => 
            {
                File.Replace(Application.ExecutablePath + ".pak", Application.ExecutablePath, Application.ExecutablePath + ".bak");
                MessageBox.Show("Update complete! Please restart Sonic '06 Mod Manager.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            };
        }
    }
}
