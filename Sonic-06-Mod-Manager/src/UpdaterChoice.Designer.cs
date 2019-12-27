namespace Sonic_06_Mod_Manager
{
    partial class UpdaterChoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdaterChoice));
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_ModUpdater = new System.Windows.Forms.Button();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Update
            // 
            this.btn_Update.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Update.FlatAppearance.BorderSize = 0;
            this.btn_Update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Update.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Update.Location = new System.Drawing.Point(8, 8);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(267, 45);
            this.btn_Update.TabIndex = 92;
            this.btn_Update.Text = "Software Updater";
            this.btn_Update.UseVisualStyleBackColor = false;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_ModUpdater
            // 
            this.btn_ModUpdater.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_ModUpdater.FlatAppearance.BorderSize = 0;
            this.btn_ModUpdater.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ModUpdater.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_ModUpdater.Location = new System.Drawing.Point(8, 59);
            this.btn_ModUpdater.Name = "btn_ModUpdater";
            this.btn_ModUpdater.Size = new System.Drawing.Size(267, 45);
            this.btn_ModUpdater.TabIndex = 93;
            this.btn_ModUpdater.Text = "Mod Updater";
            this.btn_ModUpdater.UseVisualStyleBackColor = false;
            this.btn_ModUpdater.Click += new System.EventHandler(this.btn_ModUpdater_Click);
            // 
            // btn_Reset
            // 
            this.btn_Reset.BackColor = System.Drawing.Color.Tomato;
            this.btn_Reset.FlatAppearance.BorderSize = 0;
            this.btn_Reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Reset.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Reset.Location = new System.Drawing.Point(8, 110);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(267, 23);
            this.btn_Reset.TabIndex = 94;
            this.btn_Reset.Text = "Close";
            this.btn_Reset.UseVisualStyleBackColor = false;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // UpdaterChoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 141);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Reset);
            this.Controls.Add(this.btn_ModUpdater);
            this.Controls.Add(this.btn_Update);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdaterChoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Check for Updates";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Button btn_ModUpdater;
        private System.Windows.Forms.Button btn_Reset;
    }
}