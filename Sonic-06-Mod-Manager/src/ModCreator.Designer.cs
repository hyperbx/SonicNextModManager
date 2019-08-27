namespace Sonic_06_Mod_Manager.src
{
    partial class ModCreator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModCreator));
            this.pic_Thumbnail = new System.Windows.Forms.PictureBox();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_ReadOnlyBrowser = new System.Windows.Forms.Button();
            this.text_ReadOnly = new System.Windows.Forms.TextBox();
            this.combo_System = new System.Windows.Forms.ComboBox();
            this.lbl_System = new System.Windows.Forms.Label();
            this.check_Merge = new System.Windows.Forms.CheckBox();
            this.btn_Create = new System.Windows.Forms.Button();
            this.lbl_Author = new System.Windows.Forms.Label();
            this.text_Author = new System.Windows.Forms.TextBox();
            this.lbl_Date = new System.Windows.Forms.Label();
            this.text_Date = new System.Windows.Forms.TextBox();
            this.lbl_Version = new System.Windows.Forms.Label();
            this.text_Version = new System.Windows.Forms.TextBox();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.text_Title = new System.Windows.Forms.TextBox();
            this.lbl_ReadOnly = new System.Windows.Forms.Label();
            this.tb_Description = new System.Windows.Forms.RichTextBox();
            this.group_DescriptionField = new System.Windows.Forms.GroupBox();
            this.btn_RemoveThumbnail = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Thumbnail)).BeginInit();
            this.group_DescriptionField.SuspendLayout();
            this.SuspendLayout();
            // 
            // pic_Thumbnail
            // 
            this.pic_Thumbnail.BackgroundImage = global::Sonic_06_Mod_Manager.Properties.Resources.logo_exception;
            this.pic_Thumbnail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pic_Thumbnail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_Thumbnail.Location = new System.Drawing.Point(12, 12);
            this.pic_Thumbnail.Name = "pic_Thumbnail";
            this.pic_Thumbnail.Size = new System.Drawing.Size(348, 202);
            this.pic_Thumbnail.TabIndex = 0;
            this.pic_Thumbnail.TabStop = false;
            // 
            // btn_Browse
            // 
            this.btn_Browse.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Browse.FlatAppearance.BorderSize = 0;
            this.btn_Browse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Browse.Location = new System.Drawing.Point(12, 214);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(348, 23);
            this.btn_Browse.TabIndex = 46;
            this.btn_Browse.Text = "Browse...";
            this.btn_Browse.UseVisualStyleBackColor = false;
            this.btn_Browse.Click += new System.EventHandler(this.Btn_Browse_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackColor = System.Drawing.Color.Tomato;
            this.btn_Delete.FlatAppearance.BorderSize = 0;
            this.btn_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Delete.Location = new System.Drawing.Point(204, 408);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(75, 23);
            this.btn_Delete.TabIndex = 83;
            this.btn_Delete.Text = "Delete Mod";
            this.btn_Delete.UseVisualStyleBackColor = false;
            this.btn_Delete.Visible = false;
            // 
            // btn_ReadOnlyBrowser
            // 
            this.btn_ReadOnlyBrowser.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_ReadOnlyBrowser.Enabled = false;
            this.btn_ReadOnlyBrowser.FlatAppearance.BorderSize = 0;
            this.btn_ReadOnlyBrowser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ReadOnlyBrowser.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ReadOnlyBrowser.Location = new System.Drawing.Point(338, 381);
            this.btn_ReadOnlyBrowser.Name = "btn_ReadOnlyBrowser";
            this.btn_ReadOnlyBrowser.Size = new System.Drawing.Size(22, 20);
            this.btn_ReadOnlyBrowser.TabIndex = 82;
            this.btn_ReadOnlyBrowser.Text = "...";
            this.btn_ReadOnlyBrowser.UseVisualStyleBackColor = false;
            this.btn_ReadOnlyBrowser.Click += new System.EventHandler(this.Btn_ReadOnlyBrowser_Click);
            // 
            // text_ReadOnly
            // 
            this.text_ReadOnly.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_ReadOnly.Enabled = false;
            this.text_ReadOnly.Location = new System.Drawing.Point(69, 381);
            this.text_ReadOnly.Name = "text_ReadOnly";
            this.text_ReadOnly.Size = new System.Drawing.Size(265, 20);
            this.text_ReadOnly.TabIndex = 80;
            // 
            // combo_System
            // 
            this.combo_System.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_System.FormattingEnabled = true;
            this.combo_System.Items.AddRange(new object[] {
            "Xbox 360",
            "PlayStation 3"});
            this.combo_System.Location = new System.Drawing.Point(69, 354);
            this.combo_System.Name = "combo_System";
            this.combo_System.Size = new System.Drawing.Size(291, 21);
            this.combo_System.TabIndex = 79;
            // 
            // lbl_System
            // 
            this.lbl_System.AutoSize = true;
            this.lbl_System.Location = new System.Drawing.Point(21, 357);
            this.lbl_System.Name = "lbl_System";
            this.lbl_System.Size = new System.Drawing.Size(44, 13);
            this.lbl_System.TabIndex = 78;
            this.lbl_System.Text = "System:";
            // 
            // check_Merge
            // 
            this.check_Merge.AutoSize = true;
            this.check_Merge.Location = new System.Drawing.Point(69, 412);
            this.check_Merge.Name = "check_Merge";
            this.check_Merge.Size = new System.Drawing.Size(62, 17);
            this.check_Merge.TabIndex = 77;
            this.check_Merge.Text = "Merge?";
            this.check_Merge.UseVisualStyleBackColor = true;
            this.check_Merge.CheckedChanged += new System.EventHandler(this.Check_Merge_CheckedChanged);
            // 
            // btn_Create
            // 
            this.btn_Create.BackColor = System.Drawing.Color.LightGreen;
            this.btn_Create.Enabled = false;
            this.btn_Create.FlatAppearance.BorderSize = 0;
            this.btn_Create.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Create.Location = new System.Drawing.Point(285, 408);
            this.btn_Create.Name = "btn_Create";
            this.btn_Create.Size = new System.Drawing.Size(75, 23);
            this.btn_Create.TabIndex = 76;
            this.btn_Create.Text = "Create Mod";
            this.btn_Create.UseVisualStyleBackColor = false;
            this.btn_Create.Click += new System.EventHandler(this.Btn_Create_Click);
            // 
            // lbl_Author
            // 
            this.lbl_Author.AutoSize = true;
            this.lbl_Author.Location = new System.Drawing.Point(24, 331);
            this.lbl_Author.Name = "lbl_Author";
            this.lbl_Author.Size = new System.Drawing.Size(41, 13);
            this.lbl_Author.TabIndex = 75;
            this.lbl_Author.Text = "Author:";
            // 
            // text_Author
            // 
            this.text_Author.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_Author.Location = new System.Drawing.Point(69, 328);
            this.text_Author.Name = "text_Author";
            this.text_Author.Size = new System.Drawing.Size(291, 20);
            this.text_Author.TabIndex = 74;
            // 
            // lbl_Date
            // 
            this.lbl_Date.AutoSize = true;
            this.lbl_Date.Location = new System.Drawing.Point(32, 305);
            this.lbl_Date.Name = "lbl_Date";
            this.lbl_Date.Size = new System.Drawing.Size(33, 13);
            this.lbl_Date.TabIndex = 73;
            this.lbl_Date.Text = "Date:";
            // 
            // text_Date
            // 
            this.text_Date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_Date.Location = new System.Drawing.Point(69, 302);
            this.text_Date.Name = "text_Date";
            this.text_Date.Size = new System.Drawing.Size(291, 20);
            this.text_Date.TabIndex = 72;
            // 
            // lbl_Version
            // 
            this.lbl_Version.AutoSize = true;
            this.lbl_Version.Location = new System.Drawing.Point(20, 279);
            this.lbl_Version.Name = "lbl_Version";
            this.lbl_Version.Size = new System.Drawing.Size(45, 13);
            this.lbl_Version.TabIndex = 71;
            this.lbl_Version.Text = "Version:";
            // 
            // text_Version
            // 
            this.text_Version.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_Version.Location = new System.Drawing.Point(69, 276);
            this.text_Version.Name = "text_Version";
            this.text_Version.Size = new System.Drawing.Size(291, 20);
            this.text_Version.TabIndex = 70;
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Location = new System.Drawing.Point(35, 253);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(30, 13);
            this.lbl_Title.TabIndex = 69;
            this.lbl_Title.Text = "Title:";
            // 
            // text_Title
            // 
            this.text_Title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_Title.Location = new System.Drawing.Point(69, 250);
            this.text_Title.Name = "text_Title";
            this.text_Title.Size = new System.Drawing.Size(291, 20);
            this.text_Title.TabIndex = 68;
            this.text_Title.TextChanged += new System.EventHandler(this.Text_Title_TextChanged);
            // 
            // lbl_ReadOnly
            // 
            this.lbl_ReadOnly.AutoSize = true;
            this.lbl_ReadOnly.Location = new System.Drawing.Point(7, 384);
            this.lbl_ReadOnly.Name = "lbl_ReadOnly";
            this.lbl_ReadOnly.Size = new System.Drawing.Size(58, 13);
            this.lbl_ReadOnly.TabIndex = 84;
            this.lbl_ReadOnly.Text = "Read-only:";
            // 
            // tb_Description
            // 
            this.tb_Description.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tb_Description.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Description.Cursor = System.Windows.Forms.Cursors.Default;
            this.tb_Description.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Description.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Description.Location = new System.Drawing.Point(3, 16);
            this.tb_Description.Name = "tb_Description";
            this.tb_Description.Size = new System.Drawing.Size(352, 407);
            this.tb_Description.TabIndex = 85;
            this.tb_Description.Text = "";
            // 
            // group_DescriptionField
            // 
            this.group_DescriptionField.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.group_DescriptionField.Controls.Add(this.tb_Description);
            this.group_DescriptionField.ForeColor = System.Drawing.SystemColors.ControlText;
            this.group_DescriptionField.Location = new System.Drawing.Point(371, 6);
            this.group_DescriptionField.Name = "group_DescriptionField";
            this.group_DescriptionField.Size = new System.Drawing.Size(358, 426);
            this.group_DescriptionField.TabIndex = 86;
            this.group_DescriptionField.TabStop = false;
            this.group_DescriptionField.Text = "Description";
            // 
            // btn_RemoveThumbnail
            // 
            this.btn_RemoveThumbnail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_RemoveThumbnail.Location = new System.Drawing.Point(337, 12);
            this.btn_RemoveThumbnail.Name = "btn_RemoveThumbnail";
            this.btn_RemoveThumbnail.Size = new System.Drawing.Size(23, 23);
            this.btn_RemoveThumbnail.TabIndex = 87;
            this.btn_RemoveThumbnail.Text = "X";
            this.btn_RemoveThumbnail.UseVisualStyleBackColor = true;
            this.btn_RemoveThumbnail.Click += new System.EventHandler(this.Btn_RemoveThumbnail_Click);
            // 
            // ModCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(740, 442);
            this.Controls.Add(this.btn_RemoveThumbnail);
            this.Controls.Add(this.group_DescriptionField);
            this.Controls.Add(this.lbl_ReadOnly);
            this.Controls.Add(this.btn_Browse);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_ReadOnlyBrowser);
            this.Controls.Add(this.text_ReadOnly);
            this.Controls.Add(this.combo_System);
            this.Controls.Add(this.lbl_System);
            this.Controls.Add(this.check_Merge);
            this.Controls.Add(this.btn_Create);
            this.Controls.Add(this.lbl_Author);
            this.Controls.Add(this.text_Author);
            this.Controls.Add(this.lbl_Date);
            this.Controls.Add(this.text_Date);
            this.Controls.Add(this.lbl_Version);
            this.Controls.Add(this.text_Version);
            this.Controls.Add(this.lbl_Title);
            this.Controls.Add(this.text_Title);
            this.Controls.Add(this.pic_Thumbnail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ModCreator";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mod Creator";
            ((System.ComponentModel.ISupportInitialize)(this.pic_Thumbnail)).EndInit();
            this.group_DescriptionField.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_Thumbnail;
        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_ReadOnlyBrowser;
        private System.Windows.Forms.TextBox text_ReadOnly;
        private System.Windows.Forms.ComboBox combo_System;
        private System.Windows.Forms.Label lbl_System;
        private System.Windows.Forms.CheckBox check_Merge;
        private System.Windows.Forms.Button btn_Create;
        private System.Windows.Forms.Label lbl_Author;
        private System.Windows.Forms.TextBox text_Author;
        private System.Windows.Forms.Label lbl_Date;
        private System.Windows.Forms.TextBox text_Date;
        private System.Windows.Forms.Label lbl_Version;
        private System.Windows.Forms.TextBox text_Version;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.TextBox text_Title;
        private System.Windows.Forms.Label lbl_ReadOnly;
        private System.Windows.Forms.RichTextBox tb_Description;
        private System.Windows.Forms.GroupBox group_DescriptionField;
        private System.Windows.Forms.Button btn_RemoveThumbnail;
    }
}