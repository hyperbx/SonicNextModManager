namespace Sonic_06_Mod_Manager
{
    partial class ModUpdater
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModUpdater));
            this.list_Mods = new System.Windows.Forms.ListBox();
            this.pnl_ModBackdrop = new System.Windows.Forms.Panel();
            this.tb_Information = new System.Windows.Forms.RichTextBox();
            this.pnl_InfoBackdrop = new System.Windows.Forms.Panel();
            this.split_Main = new System.Windows.Forms.SplitContainer();
            this.btn_Update = new System.Windows.Forms.Button();
            this.pgb_Progress = new System.Windows.Forms.ProgressBar();
            this.pnl_ModBackdrop.SuspendLayout();
            this.pnl_InfoBackdrop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_Main)).BeginInit();
            this.split_Main.Panel1.SuspendLayout();
            this.split_Main.Panel2.SuspendLayout();
            this.split_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // list_Mods
            // 
            this.list_Mods.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.list_Mods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list_Mods.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.list_Mods.FormattingEnabled = true;
            this.list_Mods.ItemHeight = 21;
            this.list_Mods.Location = new System.Drawing.Point(0, 0);
            this.list_Mods.Name = "list_Mods";
            this.list_Mods.Size = new System.Drawing.Size(197, 345);
            this.list_Mods.TabIndex = 0;
            this.list_Mods.SelectedIndexChanged += new System.EventHandler(this.list_Mods_SelectedIndexChanged);
            // 
            // pnl_ModBackdrop
            // 
            this.pnl_ModBackdrop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_ModBackdrop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_ModBackdrop.Controls.Add(this.list_Mods);
            this.pnl_ModBackdrop.Location = new System.Drawing.Point(0, 0);
            this.pnl_ModBackdrop.Name = "pnl_ModBackdrop";
            this.pnl_ModBackdrop.Size = new System.Drawing.Size(199, 347);
            this.pnl_ModBackdrop.TabIndex = 1;
            // 
            // tb_Information
            // 
            this.tb_Information.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tb_Information.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Information.Cursor = System.Windows.Forms.Cursors.Default;
            this.tb_Information.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Information.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Information.Location = new System.Drawing.Point(0, 0);
            this.tb_Information.Name = "tb_Information";
            this.tb_Information.ReadOnly = true;
            this.tb_Information.Size = new System.Drawing.Size(396, 345);
            this.tb_Information.TabIndex = 20;
            this.tb_Information.Text = "";
            // 
            // pnl_InfoBackdrop
            // 
            this.pnl_InfoBackdrop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_InfoBackdrop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_InfoBackdrop.Controls.Add(this.tb_Information);
            this.pnl_InfoBackdrop.Location = new System.Drawing.Point(2, 0);
            this.pnl_InfoBackdrop.Name = "pnl_InfoBackdrop";
            this.pnl_InfoBackdrop.Size = new System.Drawing.Size(398, 347);
            this.pnl_InfoBackdrop.TabIndex = 21;
            // 
            // split_Main
            // 
            this.split_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.split_Main.Location = new System.Drawing.Point(9, 10);
            this.split_Main.Name = "split_Main";
            // 
            // split_Main.Panel1
            // 
            this.split_Main.Panel1.Controls.Add(this.btn_Update);
            this.split_Main.Panel1.Controls.Add(this.pnl_ModBackdrop);
            this.split_Main.Panel1MinSize = 201;
            // 
            // split_Main.Panel2
            // 
            this.split_Main.Panel2.Controls.Add(this.pgb_Progress);
            this.split_Main.Panel2.Controls.Add(this.pnl_InfoBackdrop);
            this.split_Main.Panel2MinSize = 175;
            this.split_Main.Size = new System.Drawing.Size(605, 377);
            this.split_Main.SplitterDistance = 201;
            this.split_Main.TabIndex = 22;
            // 
            // btn_Update
            // 
            this.btn_Update.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Update.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Update.Enabled = false;
            this.btn_Update.FlatAppearance.BorderSize = 0;
            this.btn_Update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Update.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Update.Location = new System.Drawing.Point(0, 354);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(199, 23);
            this.btn_Update.TabIndex = 93;
            this.btn_Update.Text = "Update Mod";
            this.btn_Update.UseVisualStyleBackColor = false;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // pgb_Progress
            // 
            this.pgb_Progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgb_Progress.Enabled = false;
            this.pgb_Progress.Location = new System.Drawing.Point(2, 354);
            this.pgb_Progress.Name = "pgb_Progress";
            this.pgb_Progress.Size = new System.Drawing.Size(398, 23);
            this.pgb_Progress.TabIndex = 94;
            // 
            // ModUpdater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 396);
            this.Controls.Add(this.split_Main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(639, 435);
            this.Name = "ModUpdater";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mod Updater";
            this.Shown += new System.EventHandler(this.ModUpdater_Shown);
            this.pnl_ModBackdrop.ResumeLayout(false);
            this.pnl_InfoBackdrop.ResumeLayout(false);
            this.split_Main.Panel1.ResumeLayout(false);
            this.split_Main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_Main)).EndInit();
            this.split_Main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox list_Mods;
        private System.Windows.Forms.Panel pnl_ModBackdrop;
        private System.Windows.Forms.RichTextBox tb_Information;
        private System.Windows.Forms.Panel pnl_InfoBackdrop;
        private System.Windows.Forms.SplitContainer split_Main;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.ProgressBar pgb_Progress;
    }
}