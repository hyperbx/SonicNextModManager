namespace Unify.Environment3
{
    partial class ExplorerBrowser
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.WebBrowser_FileBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // WebBrowser_FileBrowser
            // 
            this.WebBrowser_FileBrowser.Location = new System.Drawing.Point(0, 0);
            this.WebBrowser_FileBrowser.Name = "WebBrowser_FileBrowser";
            this.WebBrowser_FileBrowser.Size = new System.Drawing.Size(250, 250);
            this.WebBrowser_FileBrowser.TabIndex = 0;
            this.WebBrowser_FileBrowser.WebBrowserShortcutsEnabled = false;
            // 
            // ExplorerBrowser
            // 
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IsWebBrowserContextMenuEnabled = false;
            this.MinimumSize = new System.Drawing.Size(20, 20);
            this.Name = "WebBrowser_FileBrowser";
            this.ScriptErrorsSuppressed = true;
            this.Size = new System.Drawing.Size(150, 150);
            this.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.ExplorerBrowser_Navigated);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser WebBrowser_FileBrowser;
    }
}
