
namespace Unify.Environment3
{
    partial class ProfileSelect
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfileSelect));
            this.Button_OK = new System.Windows.Forms.Button();
            this.Label_CurrentProfile = new System.Windows.Forms.Label();
            this.unifytb_Profiles = new Unify.Environment3.UnifyTabControl();
            this.unifytb_Tab_Profiles = new System.Windows.Forms.TabPage();
            this.Panel_PatchBackdrop = new System.Windows.Forms.Panel();
            this.ListView_ProfilesList = new System.Windows.Forms.ListView();
            this.Column_PatchesList_Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.unifytb_Info = new Unify.Environment3.UnifyTabControl();
            this.Tab_Mods = new System.Windows.Forms.TabPage();
            this.ListBox_Mods = new System.Windows.Forms.ListBox();
            this.Tab_Patches = new System.Windows.Forms.TabPage();
            this.ListBox_Patches = new System.Windows.Forms.ListBox();
            this.Tab_Tweaks = new System.Windows.Forms.TabPage();
            this.ListBox_Tweaks = new System.Windows.Forms.ListBox();
            this.unifytb_Profiles.SuspendLayout();
            this.unifytb_Tab_Profiles.SuspendLayout();
            this.Panel_PatchBackdrop.SuspendLayout();
            this.unifytb_Info.SuspendLayout();
            this.Tab_Mods.SuspendLayout();
            this.Tab_Patches.SuspendLayout();
            this.Tab_Tweaks.SuspendLayout();
            this.SuspendLayout();
            // 
            // Button_OK
            // 
            this.Button_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_OK.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Button_OK.Enabled = false;
            this.Button_OK.FlatAppearance.BorderSize = 0;
            this.Button_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_OK.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_OK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Button_OK.Location = new System.Drawing.Point(705, 429);
            this.Button_OK.Name = "Button_OK";
            this.Button_OK.Size = new System.Drawing.Size(84, 23);
            this.Button_OK.TabIndex = 103;
            this.Button_OK.Text = "OK";
            this.Button_OK.UseVisualStyleBackColor = false;
            this.Button_OK.Click += new System.EventHandler(this.Button_OK_Click);
            // 
            // Label_CurrentProfile
            // 
            this.Label_CurrentProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label_CurrentProfile.AutoSize = true;
            this.Label_CurrentProfile.Location = new System.Drawing.Point(12, 433);
            this.Label_CurrentProfile.Name = "Label_CurrentProfile";
            this.Label_CurrentProfile.Size = new System.Drawing.Size(162, 15);
            this.Label_CurrentProfile.TabIndex = 104;
            this.Label_CurrentProfile.Text = "Last Used Profile: Placeholder";
            this.Label_CurrentProfile.Visible = false;
            // 
            // unifytb_Profiles
            // 
            this.unifytb_Profiles.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.unifytb_Profiles.AllowDragging = false;
            this.unifytb_Profiles.AllowDrop = true;
            this.unifytb_Profiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.unifytb_Profiles.BackTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.unifytb_Profiles.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.unifytb_Profiles.ClosingButtonColor = System.Drawing.Color.WhiteSmoke;
            this.unifytb_Profiles.ClosingMessage = null;
            this.unifytb_Profiles.Controls.Add(this.unifytb_Tab_Profiles);
            this.unifytb_Profiles.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unifytb_Profiles.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.unifytb_Profiles.HorizontalLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.unifytb_Profiles.ItemSize = new System.Drawing.Size(240, 16);
            this.unifytb_Profiles.Location = new System.Drawing.Point(0, 0);
            this.unifytb_Profiles.Name = "unifytb_Profiles";
            this.unifytb_Profiles.NoTabDisplay = false;
            this.unifytb_Profiles.SelectedIndex = 0;
            this.unifytb_Profiles.SelectedTextColor = System.Drawing.SystemColors.Control;
            this.unifytb_Profiles.ShowClosingButton = false;
            this.unifytb_Profiles.ShowClosingMessage = false;
            this.unifytb_Profiles.Size = new System.Drawing.Size(800, 421);
            this.unifytb_Profiles.TabIndex = 102;
            this.unifytb_Profiles.TextColor = System.Drawing.SystemColors.Control;
            // 
            // unifytb_Tab_Profiles
            // 
            this.unifytb_Tab_Profiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.unifytb_Tab_Profiles.Controls.Add(this.Panel_PatchBackdrop);
            this.unifytb_Tab_Profiles.Controls.Add(this.unifytb_Info);
            this.unifytb_Tab_Profiles.Location = new System.Drawing.Point(4, 20);
            this.unifytb_Tab_Profiles.Name = "unifytb_Tab_Profiles";
            this.unifytb_Tab_Profiles.Size = new System.Drawing.Size(792, 397);
            this.unifytb_Tab_Profiles.TabIndex = 0;
            this.unifytb_Tab_Profiles.Text = "Profiles";
            // 
            // Panel_PatchBackdrop
            // 
            this.Panel_PatchBackdrop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_PatchBackdrop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Panel_PatchBackdrop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel_PatchBackdrop.Controls.Add(this.ListView_ProfilesList);
            this.Panel_PatchBackdrop.Location = new System.Drawing.Point(2, 4);
            this.Panel_PatchBackdrop.Name = "Panel_PatchBackdrop";
            this.Panel_PatchBackdrop.Size = new System.Drawing.Size(521, 392);
            this.Panel_PatchBackdrop.TabIndex = 104;
            // 
            // ListView_ProfilesList
            // 
            this.ListView_ProfilesList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.ListView_ProfilesList.AllowDrop = true;
            this.ListView_ProfilesList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ListView_ProfilesList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListView_ProfilesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Column_PatchesList_Title});
            this.ListView_ProfilesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListView_ProfilesList.ForeColor = System.Drawing.SystemColors.Control;
            this.ListView_ProfilesList.FullRowSelect = true;
            this.ListView_ProfilesList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.ListView_ProfilesList.HideSelection = false;
            this.ListView_ProfilesList.LabelEdit = true;
            this.ListView_ProfilesList.Location = new System.Drawing.Point(0, 0);
            this.ListView_ProfilesList.MultiSelect = false;
            this.ListView_ProfilesList.Name = "ListView_ProfilesList";
            this.ListView_ProfilesList.OwnerDraw = true;
            this.ListView_ProfilesList.Size = new System.Drawing.Size(519, 390);
            this.ListView_ProfilesList.TabIndex = 1;
            this.ListView_ProfilesList.UseCompatibleStateImageBehavior = false;
            this.ListView_ProfilesList.View = System.Windows.Forms.View.Details;
            this.ListView_ProfilesList.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.ListView_ProfilesList_AfterLabelEdit);
            this.ListView_ProfilesList.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.ListView_ProfilesList_DrawItem);
            this.ListView_ProfilesList.SelectedIndexChanged += new System.EventHandler(this.ListView_ProfilesList_SelectedIndexChanged);
            this.ListView_ProfilesList.DoubleClick += new System.EventHandler(this.Button_OK_Click);
            this.ListView_ProfilesList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListView_ProfilesList_MouseClick);
            // 
            // Column_PatchesList_Title
            // 
            this.Column_PatchesList_Title.Text = "Title";
            this.Column_PatchesList_Title.Width = 519;
            // 
            // unifytb_Info
            // 
            this.unifytb_Info.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.unifytb_Info.AllowDragging = false;
            this.unifytb_Info.AllowDrop = true;
            this.unifytb_Info.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.unifytb_Info.BackTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.unifytb_Info.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.unifytb_Info.ClosingButtonColor = System.Drawing.Color.WhiteSmoke;
            this.unifytb_Info.ClosingMessage = null;
            this.unifytb_Info.Controls.Add(this.Tab_Mods);
            this.unifytb_Info.Controls.Add(this.Tab_Patches);
            this.unifytb_Info.Controls.Add(this.Tab_Tweaks);
            this.unifytb_Info.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unifytb_Info.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.unifytb_Info.HorizontalLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.unifytb_Info.ItemSize = new System.Drawing.Size(240, 16);
            this.unifytb_Info.Location = new System.Drawing.Point(527, 4);
            this.unifytb_Info.Name = "unifytb_Info";
            this.unifytb_Info.NoTabDisplay = false;
            this.unifytb_Info.SelectedIndex = 0;
            this.unifytb_Info.SelectedTextColor = System.Drawing.SystemColors.Control;
            this.unifytb_Info.ShowClosingButton = false;
            this.unifytb_Info.ShowClosingMessage = false;
            this.unifytb_Info.Size = new System.Drawing.Size(262, 392);
            this.unifytb_Info.TabIndex = 103;
            this.unifytb_Info.TextColor = System.Drawing.SystemColors.Control;
            this.unifytb_Info.SelectedIndexChanged += new System.EventHandler(this.unifytb_Info_SelectedIndexChanged);
            // 
            // Tab_Mods
            // 
            this.Tab_Mods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Tab_Mods.Controls.Add(this.ListBox_Mods);
            this.Tab_Mods.Location = new System.Drawing.Point(4, 20);
            this.Tab_Mods.Name = "Tab_Mods";
            this.Tab_Mods.Size = new System.Drawing.Size(254, 368);
            this.Tab_Mods.TabIndex = 0;
            this.Tab_Mods.Text = "Mods";
            // 
            // ListBox_Mods
            // 
            this.ListBox_Mods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ListBox_Mods.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListBox_Mods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListBox_Mods.ForeColor = System.Drawing.SystemColors.Control;
            this.ListBox_Mods.FormattingEnabled = true;
            this.ListBox_Mods.ItemHeight = 15;
            this.ListBox_Mods.Items.AddRange(new object[] {
            "Please select a profile..."});
            this.ListBox_Mods.Location = new System.Drawing.Point(0, 0);
            this.ListBox_Mods.Name = "ListBox_Mods";
            this.ListBox_Mods.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.ListBox_Mods.Size = new System.Drawing.Size(254, 368);
            this.ListBox_Mods.TabIndex = 0;
            // 
            // Tab_Patches
            // 
            this.Tab_Patches.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Tab_Patches.Controls.Add(this.ListBox_Patches);
            this.Tab_Patches.Location = new System.Drawing.Point(4, 20);
            this.Tab_Patches.Name = "Tab_Patches";
            this.Tab_Patches.Size = new System.Drawing.Size(254, 368);
            this.Tab_Patches.TabIndex = 1;
            this.Tab_Patches.Text = "Patches";
            // 
            // ListBox_Patches
            // 
            this.ListBox_Patches.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ListBox_Patches.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListBox_Patches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListBox_Patches.ForeColor = System.Drawing.SystemColors.Control;
            this.ListBox_Patches.FormattingEnabled = true;
            this.ListBox_Patches.ItemHeight = 15;
            this.ListBox_Patches.Items.AddRange(new object[] {
            "Please select a profile..."});
            this.ListBox_Patches.Location = new System.Drawing.Point(0, 0);
            this.ListBox_Patches.Name = "ListBox_Patches";
            this.ListBox_Patches.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.ListBox_Patches.Size = new System.Drawing.Size(254, 368);
            this.ListBox_Patches.TabIndex = 1;
            // 
            // Tab_Tweaks
            // 
            this.Tab_Tweaks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Tab_Tweaks.Controls.Add(this.ListBox_Tweaks);
            this.Tab_Tweaks.Location = new System.Drawing.Point(4, 20);
            this.Tab_Tweaks.Name = "Tab_Tweaks";
            this.Tab_Tweaks.Size = new System.Drawing.Size(254, 368);
            this.Tab_Tweaks.TabIndex = 2;
            this.Tab_Tweaks.Text = "Tweaks";
            // 
            // ListBox_Tweaks
            // 
            this.ListBox_Tweaks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ListBox_Tweaks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListBox_Tweaks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListBox_Tweaks.ForeColor = System.Drawing.SystemColors.Control;
            this.ListBox_Tweaks.FormattingEnabled = true;
            this.ListBox_Tweaks.ItemHeight = 15;
            this.ListBox_Tweaks.Items.AddRange(new object[] {
            "Please select a profile..."});
            this.ListBox_Tweaks.Location = new System.Drawing.Point(0, 0);
            this.ListBox_Tweaks.Name = "ListBox_Tweaks";
            this.ListBox_Tweaks.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.ListBox_Tweaks.Size = new System.Drawing.Size(254, 368);
            this.ListBox_Tweaks.TabIndex = 1;
            // 
            // ProfileSelect
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(800, 461);
            this.Controls.Add(this.Label_CurrentProfile);
            this.Controls.Add(this.Button_OK);
            this.Controls.Add(this.unifytb_Profiles);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(816, 500);
            this.Name = "ProfileSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Profile Select";
            this.unifytb_Profiles.ResumeLayout(false);
            this.unifytb_Tab_Profiles.ResumeLayout(false);
            this.Panel_PatchBackdrop.ResumeLayout(false);
            this.unifytb_Info.ResumeLayout(false);
            this.Tab_Mods.ResumeLayout(false);
            this.Tab_Patches.ResumeLayout(false);
            this.Tab_Tweaks.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Unify.Environment3.UnifyTabControl unifytb_Profiles;
        private System.Windows.Forms.TabPage unifytb_Tab_Profiles;
        private System.Windows.Forms.Button Button_OK;
        private Unify.Environment3.UnifyTabControl unifytb_Info;
        private System.Windows.Forms.TabPage Tab_Mods;
        private System.Windows.Forms.TabPage Tab_Patches;
        private System.Windows.Forms.TabPage Tab_Tweaks;
        private System.Windows.Forms.Panel Panel_PatchBackdrop;
        private System.Windows.Forms.ListView ListView_ProfilesList;
        private System.Windows.Forms.ColumnHeader Column_PatchesList_Title;
        private System.Windows.Forms.ListBox ListBox_Mods;
        private System.Windows.Forms.ListBox ListBox_Patches;
        private System.Windows.Forms.ListBox ListBox_Tweaks;
        private System.Windows.Forms.Label Label_CurrentProfile;
    }
}