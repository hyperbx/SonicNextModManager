namespace Sonic_06_Mod_Manager
{
    partial class ModManager
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModManager));
            this.playButton = new System.Windows.Forms.Button();
            this.group_Mods = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.modList = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.modsButton = new System.Windows.Forms.Button();
            this.lbl_ModsDirectory = new System.Windows.Forms.Label();
            this.modsBox = new System.Windows.Forms.TextBox();
            this.xeniaButton = new System.Windows.Forms.Button();
            this.lbl_XeniaExecutable = new System.Windows.Forms.Label();
            this.xeniaBox = new System.Windows.Forms.TextBox();
            this.s06PathButton = new System.Windows.Forms.Button();
            this.lbl_GameDirectory = new System.Windows.Forms.Label();
            this.s06PathBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tm_CreatorDisposal = new System.Windows.Forms.Timer(this.components);
            this.tool_LabelInform = new System.Windows.Forms.ToolTip(this.components);
            this.group_Mods.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // playButton
            // 
            this.playButton.BackColor = System.Drawing.Color.LightGreen;
            this.playButton.FlatAppearance.BorderSize = 0;
            this.playButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playButton.Location = new System.Drawing.Point(10, 379);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(282, 23);
            this.playButton.TabIndex = 31;
            this.playButton.Text = "Save and Play";
            this.playButton.UseVisualStyleBackColor = false;
            this.playButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // group_Mods
            // 
            this.group_Mods.Controls.Add(this.button1);
            this.group_Mods.Controls.Add(this.createButton);
            this.group_Mods.Controls.Add(this.refreshButton);
            this.group_Mods.Controls.Add(this.modList);
            this.group_Mods.Location = new System.Drawing.Point(10, 3);
            this.group_Mods.Name = "group_Mods";
            this.group_Mods.Size = new System.Drawing.Size(374, 267);
            this.group_Mods.TabIndex = 37;
            this.group_Mods.TabStop = false;
            this.group_Mods.Text = "Mods";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(283, 237);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 23);
            this.button1.TabIndex = 37;
            this.button1.Text = "Mod Info";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // createButton
            // 
            this.createButton.BackColor = System.Drawing.Color.LightGreen;
            this.createButton.FlatAppearance.BorderSize = 0;
            this.createButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createButton.Location = new System.Drawing.Point(95, 237);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(182, 23);
            this.createButton.TabIndex = 36;
            this.createButton.Text = "Create New Mod";
            this.createButton.UseVisualStyleBackColor = false;
            this.createButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.refreshButton.FlatAppearance.BorderSize = 0;
            this.refreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshButton.Location = new System.Drawing.Point(6, 237);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(83, 23);
            this.refreshButton.TabIndex = 35;
            this.refreshButton.Text = "Refresh Mods";
            this.refreshButton.UseVisualStyleBackColor = false;
            this.refreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // modList
            // 
            this.modList.FormattingEnabled = true;
            this.modList.Location = new System.Drawing.Point(6, 17);
            this.modList.Name = "modList";
            this.modList.Size = new System.Drawing.Size(362, 214);
            this.modList.TabIndex = 34;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.modsButton);
            this.groupBox1.Controls.Add(this.lbl_ModsDirectory);
            this.groupBox1.Controls.Add(this.modsBox);
            this.groupBox1.Controls.Add(this.xeniaButton);
            this.groupBox1.Controls.Add(this.lbl_XeniaExecutable);
            this.groupBox1.Controls.Add(this.xeniaBox);
            this.groupBox1.Controls.Add(this.s06PathButton);
            this.groupBox1.Controls.Add(this.lbl_GameDirectory);
            this.groupBox1.Controls.Add(this.s06PathBox);
            this.groupBox1.Location = new System.Drawing.Point(10, 273);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(374, 99);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Directories";
            // 
            // modsButton
            // 
            this.modsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(171)))), ((int)(((byte)(83)))));
            this.modsButton.FlatAppearance.BorderSize = 0;
            this.modsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.modsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modsButton.Location = new System.Drawing.Point(346, 17);
            this.modsButton.Name = "modsButton";
            this.modsButton.Size = new System.Drawing.Size(22, 20);
            this.modsButton.TabIndex = 45;
            this.modsButton.Text = "...";
            this.modsButton.UseVisualStyleBackColor = false;
            this.modsButton.Click += new System.EventHandler(this.ModsButton_Click);
            // 
            // lbl_ModsDirectory
            // 
            this.lbl_ModsDirectory.AutoSize = true;
            this.lbl_ModsDirectory.Location = new System.Drawing.Point(17, 20);
            this.lbl_ModsDirectory.Name = "lbl_ModsDirectory";
            this.lbl_ModsDirectory.Size = new System.Drawing.Size(81, 13);
            this.lbl_ModsDirectory.TabIndex = 44;
            this.lbl_ModsDirectory.Text = "Mods Directory:";
            this.tool_LabelInform.SetToolTip(this.lbl_ModsDirectory, "Click here to open your Mods directory...");
            this.lbl_ModsDirectory.Click += new System.EventHandler(this.Lbl_ModsDirectory_Click);
            // 
            // modsBox
            // 
            this.modsBox.Location = new System.Drawing.Point(100, 17);
            this.modsBox.Name = "modsBox";
            this.modsBox.Size = new System.Drawing.Size(241, 20);
            this.modsBox.TabIndex = 43;
            this.modsBox.TextChanged += new System.EventHandler(this.ModsBox_TextChanged);
            // 
            // xeniaButton
            // 
            this.xeniaButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(171)))), ((int)(((byte)(83)))));
            this.xeniaButton.FlatAppearance.BorderSize = 0;
            this.xeniaButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.xeniaButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xeniaButton.Location = new System.Drawing.Point(346, 69);
            this.xeniaButton.Name = "xeniaButton";
            this.xeniaButton.Size = new System.Drawing.Size(22, 20);
            this.xeniaButton.TabIndex = 42;
            this.xeniaButton.Text = "...";
            this.xeniaButton.UseVisualStyleBackColor = false;
            this.xeniaButton.Click += new System.EventHandler(this.XeniaButton_Click);
            // 
            // lbl_XeniaExecutable
            // 
            this.lbl_XeniaExecutable.AutoSize = true;
            this.lbl_XeniaExecutable.Location = new System.Drawing.Point(5, 72);
            this.lbl_XeniaExecutable.Name = "lbl_XeniaExecutable";
            this.lbl_XeniaExecutable.Size = new System.Drawing.Size(93, 13);
            this.lbl_XeniaExecutable.TabIndex = 41;
            this.lbl_XeniaExecutable.Text = "Xenia Executable:";
            this.tool_LabelInform.SetToolTip(this.lbl_XeniaExecutable, "Click here to launch Xenia...");
            this.lbl_XeniaExecutable.Click += new System.EventHandler(this.Lbl_XeniaExecutable_Click);
            // 
            // xeniaBox
            // 
            this.xeniaBox.Location = new System.Drawing.Point(100, 69);
            this.xeniaBox.Name = "xeniaBox";
            this.xeniaBox.Size = new System.Drawing.Size(241, 20);
            this.xeniaBox.TabIndex = 40;
            this.xeniaBox.TextChanged += new System.EventHandler(this.XeniaBox_TextChanged);
            // 
            // s06PathButton
            // 
            this.s06PathButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(171)))), ((int)(((byte)(83)))));
            this.s06PathButton.FlatAppearance.BorderSize = 0;
            this.s06PathButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.s06PathButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.s06PathButton.Location = new System.Drawing.Point(346, 43);
            this.s06PathButton.Name = "s06PathButton";
            this.s06PathButton.Size = new System.Drawing.Size(22, 20);
            this.s06PathButton.TabIndex = 39;
            this.s06PathButton.Text = "...";
            this.s06PathButton.UseVisualStyleBackColor = false;
            this.s06PathButton.Click += new System.EventHandler(this.S06PathButton_Click);
            // 
            // lbl_GameDirectory
            // 
            this.lbl_GameDirectory.AutoSize = true;
            this.lbl_GameDirectory.Location = new System.Drawing.Point(15, 46);
            this.lbl_GameDirectory.Name = "lbl_GameDirectory";
            this.lbl_GameDirectory.Size = new System.Drawing.Size(83, 13);
            this.lbl_GameDirectory.TabIndex = 38;
            this.lbl_GameDirectory.Text = "Game Directory:";
            this.tool_LabelInform.SetToolTip(this.lbl_GameDirectory, "Click here to open your Game directory...");
            this.lbl_GameDirectory.Click += new System.EventHandler(this.Lbl_GameDirectory_Click);
            // 
            // s06PathBox
            // 
            this.s06PathBox.Location = new System.Drawing.Point(100, 43);
            this.s06PathBox.Name = "s06PathBox";
            this.s06PathBox.Size = new System.Drawing.Size(241, 20);
            this.s06PathBox.TabIndex = 37;
            this.s06PathBox.TextChanged += new System.EventHandler(this.S06PathBox_TextChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(298, 379);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 23);
            this.button2.TabIndex = 39;
            this.button2.Text = "About";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // tm_CreatorDisposal
            // 
            this.tm_CreatorDisposal.Tick += new System.EventHandler(this.Tm_CreatorDisposal_Tick);
            // 
            // tool_LabelInform
            // 
            this.tool_LabelInform.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.tool_LabelInform.ToolTipTitle = "Label Shortcuts";
            // 
            // ModManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 411);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.group_Mods);
            this.Controls.Add(this.playButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ModManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sonic \'06 Mod Manager";
            this.Load += new System.EventHandler(this.ModManager_Load);
            this.group_Mods.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.GroupBox group_Mods;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.CheckedListBox modList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button modsButton;
        private System.Windows.Forms.Label lbl_ModsDirectory;
        private System.Windows.Forms.TextBox modsBox;
        private System.Windows.Forms.Button xeniaButton;
        private System.Windows.Forms.Label lbl_XeniaExecutable;
        private System.Windows.Forms.TextBox xeniaBox;
        private System.Windows.Forms.Button s06PathButton;
        private System.Windows.Forms.Label lbl_GameDirectory;
        private System.Windows.Forms.TextBox s06PathBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer tm_CreatorDisposal;
        private System.Windows.Forms.ToolTip tool_LabelInform;
    }
}

