namespace Unify.Environment3
{
    partial class PatchCreator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatchCreator));
            this.btn_Create = new System.Windows.Forms.Button();
            this.unifytb_ModCreator = new Unify.Environment3.UnifyTabControl();
            this.unifytb_Tab_Details = new System.Windows.Forms.TabPage();
            this.text_Blurb = new System.Windows.Forms.TextBox();
            this.lbl_Blurb = new System.Windows.Forms.Label();
            this.group_DescriptionField = new System.Windows.Forms.GroupBox();
            this.tb_Description = new System.Windows.Forms.RichTextBox();
            this.text_Title = new System.Windows.Forms.TextBox();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.text_Author = new System.Windows.Forms.TextBox();
            this.lbl_Author = new System.Windows.Forms.Label();
            this.lbl_System = new System.Windows.Forms.Label();
            this.combo_System = new System.Windows.Forms.ComboBox();
            this.unifytb_ModCreator.SuspendLayout();
            this.unifytb_Tab_Details.SuspendLayout();
            this.group_DescriptionField.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Create
            // 
            this.btn_Create.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Create.BackColor = System.Drawing.Color.LightGreen;
            this.btn_Create.Enabled = false;
            this.btn_Create.FlatAppearance.BorderSize = 0;
            this.btn_Create.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Create.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Create.Location = new System.Drawing.Point(285, 429);
            this.btn_Create.Name = "btn_Create";
            this.btn_Create.Size = new System.Drawing.Size(84, 23);
            this.btn_Create.TabIndex = 103;
            this.btn_Create.Text = "Create Patch";
            this.btn_Create.UseVisualStyleBackColor = false;
            this.btn_Create.Click += new System.EventHandler(this.btn_Create_Click);
            // 
            // unifytb_ModCreator
            // 
            this.unifytb_ModCreator.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.unifytb_ModCreator.AllowDragging = false;
            this.unifytb_ModCreator.AllowDrop = true;
            this.unifytb_ModCreator.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.unifytb_ModCreator.BackTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.unifytb_ModCreator.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.unifytb_ModCreator.ClosingButtonColor = System.Drawing.Color.WhiteSmoke;
            this.unifytb_ModCreator.ClosingMessage = null;
            this.unifytb_ModCreator.Controls.Add(this.unifytb_Tab_Details);
            this.unifytb_ModCreator.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unifytb_ModCreator.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.unifytb_ModCreator.HorizontalLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.unifytb_ModCreator.ItemSize = new System.Drawing.Size(240, 16);
            this.unifytb_ModCreator.Location = new System.Drawing.Point(0, 0);
            this.unifytb_ModCreator.Name = "unifytb_ModCreator";
            this.unifytb_ModCreator.NoTabDisplay = false;
            this.unifytb_ModCreator.SelectedIndex = 0;
            this.unifytb_ModCreator.SelectedTextColor = System.Drawing.SystemColors.Control;
            this.unifytb_ModCreator.ShowClosingButton = false;
            this.unifytb_ModCreator.ShowClosingMessage = false;
            this.unifytb_ModCreator.Size = new System.Drawing.Size(381, 421);
            this.unifytb_ModCreator.TabIndex = 102;
            this.unifytb_ModCreator.TextColor = System.Drawing.SystemColors.Control;
            // 
            // unifytb_Tab_Details
            // 
            this.unifytb_Tab_Details.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.unifytb_Tab_Details.Controls.Add(this.text_Blurb);
            this.unifytb_Tab_Details.Controls.Add(this.lbl_Blurb);
            this.unifytb_Tab_Details.Controls.Add(this.group_DescriptionField);
            this.unifytb_Tab_Details.Controls.Add(this.text_Title);
            this.unifytb_Tab_Details.Controls.Add(this.lbl_Title);
            this.unifytb_Tab_Details.Controls.Add(this.text_Author);
            this.unifytb_Tab_Details.Controls.Add(this.lbl_Author);
            this.unifytb_Tab_Details.Controls.Add(this.lbl_System);
            this.unifytb_Tab_Details.Controls.Add(this.combo_System);
            this.unifytb_Tab_Details.Location = new System.Drawing.Point(4, 20);
            this.unifytb_Tab_Details.Name = "unifytb_Tab_Details";
            this.unifytb_Tab_Details.Size = new System.Drawing.Size(373, 397);
            this.unifytb_Tab_Details.TabIndex = 0;
            this.unifytb_Tab_Details.Text = "Details";
            // 
            // text_Blurb
            // 
            this.text_Blurb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_Blurb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.text_Blurb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_Blurb.ForeColor = System.Drawing.SystemColors.Control;
            this.text_Blurb.Location = new System.Drawing.Point(62, 94);
            this.text_Blurb.Name = "text_Blurb";
            this.text_Blurb.Size = new System.Drawing.Size(303, 23);
            this.text_Blurb.TabIndex = 88;
            // 
            // lbl_Blurb
            // 
            this.lbl_Blurb.AutoSize = true;
            this.lbl_Blurb.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_Blurb.Location = new System.Drawing.Point(17, 98);
            this.lbl_Blurb.Name = "lbl_Blurb";
            this.lbl_Blurb.Size = new System.Drawing.Size(38, 15);
            this.lbl_Blurb.TabIndex = 89;
            this.lbl_Blurb.Text = "Blurb:";
            // 
            // group_DescriptionField
            // 
            this.group_DescriptionField.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.group_DescriptionField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.group_DescriptionField.Controls.Add(this.tb_Description);
            this.group_DescriptionField.ForeColor = System.Drawing.SystemColors.Control;
            this.group_DescriptionField.Location = new System.Drawing.Point(2, 124);
            this.group_DescriptionField.Name = "group_DescriptionField";
            this.group_DescriptionField.Size = new System.Drawing.Size(369, 272);
            this.group_DescriptionField.TabIndex = 87;
            this.group_DescriptionField.TabStop = false;
            this.group_DescriptionField.Text = "Description";
            // 
            // tb_Description
            // 
            this.tb_Description.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Description.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.tb_Description.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Description.Cursor = System.Windows.Forms.Cursors.Default;
            this.tb_Description.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Description.ForeColor = System.Drawing.SystemColors.Control;
            this.tb_Description.Location = new System.Drawing.Point(3, 19);
            this.tb_Description.Name = "tb_Description";
            this.tb_Description.Size = new System.Drawing.Size(364, 251);
            this.tb_Description.TabIndex = 85;
            this.tb_Description.Text = "";
            // 
            // text_Title
            // 
            this.text_Title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_Title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.text_Title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_Title.ForeColor = System.Drawing.SystemColors.Control;
            this.text_Title.Location = new System.Drawing.Point(62, 10);
            this.text_Title.Name = "text_Title";
            this.text_Title.Size = new System.Drawing.Size(303, 23);
            this.text_Title.TabIndex = 68;
            this.text_Title.TextChanged += new System.EventHandler(this.text_Title_TextChanged);
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_Title.Location = new System.Drawing.Point(23, 13);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(32, 15);
            this.lbl_Title.TabIndex = 69;
            this.lbl_Title.Text = "Title:";
            // 
            // text_Author
            // 
            this.text_Author.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_Author.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.text_Author.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_Author.ForeColor = System.Drawing.SystemColors.Control;
            this.text_Author.Location = new System.Drawing.Point(62, 38);
            this.text_Author.Name = "text_Author";
            this.text_Author.Size = new System.Drawing.Size(303, 23);
            this.text_Author.TabIndex = 74;
            // 
            // lbl_Author
            // 
            this.lbl_Author.AutoSize = true;
            this.lbl_Author.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_Author.Location = new System.Drawing.Point(9, 42);
            this.lbl_Author.Name = "lbl_Author";
            this.lbl_Author.Size = new System.Drawing.Size(47, 15);
            this.lbl_Author.TabIndex = 75;
            this.lbl_Author.Text = "Author:";
            // 
            // lbl_System
            // 
            this.lbl_System.AutoSize = true;
            this.lbl_System.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_System.Location = new System.Drawing.Point(8, 70);
            this.lbl_System.Name = "lbl_System";
            this.lbl_System.Size = new System.Drawing.Size(48, 15);
            this.lbl_System.TabIndex = 78;
            this.lbl_System.Text = "System:";
            // 
            // combo_System
            // 
            this.combo_System.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_System.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_System.FormattingEnabled = true;
            this.combo_System.Items.AddRange(new object[] {
            "Xbox 360",
            "PlayStation 3",
            "All Systems"});
            this.combo_System.Location = new System.Drawing.Point(62, 66);
            this.combo_System.Name = "combo_System";
            this.combo_System.Size = new System.Drawing.Size(303, 23);
            this.combo_System.TabIndex = 79;
            // 
            // PatchCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(381, 461);
            this.Controls.Add(this.btn_Create);
            this.Controls.Add(this.unifytb_ModCreator);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(397, 500);
            this.Name = "PatchCreator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Patch Creator";
            this.unifytb_ModCreator.ResumeLayout(false);
            this.unifytb_Tab_Details.ResumeLayout(false);
            this.unifytb_Tab_Details.PerformLayout();
            this.group_DescriptionField.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Environment3.UnifyTabControl unifytb_ModCreator;
        private System.Windows.Forms.TabPage unifytb_Tab_Details;
        private System.Windows.Forms.TextBox text_Title;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.TextBox text_Author;
        private System.Windows.Forms.Label lbl_Author;
        private System.Windows.Forms.Label lbl_System;
        private System.Windows.Forms.ComboBox combo_System;
        private System.Windows.Forms.TextBox text_Blurb;
        private System.Windows.Forms.Label lbl_Blurb;
        private System.Windows.Forms.GroupBox group_DescriptionField;
        private System.Windows.Forms.RichTextBox tb_Description;
        private System.Windows.Forms.Button btn_Create;
    }
}