namespace Unify.Environment3
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
            this.btn_Create = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.unifytb_ModCreator = new Unify.Environment3.UnifyTabControl();
            this.unifytb_Tab_Details = new System.Windows.Forms.TabPage();
            this.text_Title = new System.Windows.Forms.TextBox();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.text_Version = new System.Windows.Forms.TextBox();
            this.lbl_Version = new System.Windows.Forms.Label();
            this.text_Date = new System.Windows.Forms.TextBox();
            this.lbl_Date = new System.Windows.Forms.Label();
            this.text_Author = new System.Windows.Forms.TextBox();
            this.btn_RemoveThumbnail = new System.Windows.Forms.Button();
            this.lbl_Author = new System.Windows.Forms.Label();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.lbl_System = new System.Windows.Forms.Label();
            this.combo_System = new System.Windows.Forms.ComboBox();
            this.pic_Thumbnail = new System.Windows.Forms.PictureBox();
            this.unifytb_Tab_Description = new System.Windows.Forms.TabPage();
            this.group_DescriptionField = new System.Windows.Forms.GroupBox();
            this.tb_Description = new System.Windows.Forms.RichTextBox();
            this.unifytb_Tab_Filesystem = new System.Windows.Forms.TabPage();
            this.btn_Custom = new System.Windows.Forms.Button();
            this.lbl_Custom = new System.Windows.Forms.Label();
            this.text_Custom = new System.Windows.Forms.TextBox();
            this.group_Options = new System.Windows.Forms.GroupBox();
            this.check_Merge = new System.Windows.Forms.CheckBox();
            this.check_GenerateFilesystem = new System.Windows.Forms.CheckBox();
            this.btn_ReadOnlyBrowser = new System.Windows.Forms.Button();
            this.lbl_Save = new System.Windows.Forms.Label();
            this.btn_SaveBrowser = new System.Windows.Forms.Button();
            this.text_Save = new System.Windows.Forms.TextBox();
            this.lbl_ReadOnly = new System.Windows.Forms.Label();
            this.text_ReadOnly = new System.Windows.Forms.TextBox();
            this.unifytb_Tab_Networking = new System.Windows.Forms.TabPage();
            this.btn_TestConnection = new System.Windows.Forms.Button();
            this.lbl_Data = new System.Windows.Forms.Label();
            this.pnl_Console = new System.Windows.Forms.Panel();
            this.list_Console = new System.Windows.Forms.ListBox();
            this.text_Server = new System.Windows.Forms.TextBox();
            this.text_Data = new System.Windows.Forms.TextBox();
            this.lbl_Server = new System.Windows.Forms.Label();
            this.unifytb_ModCreator.SuspendLayout();
            this.unifytb_Tab_Details.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Thumbnail)).BeginInit();
            this.unifytb_Tab_Description.SuspendLayout();
            this.group_DescriptionField.SuspendLayout();
            this.unifytb_Tab_Filesystem.SuspendLayout();
            this.group_Options.SuspendLayout();
            this.unifytb_Tab_Networking.SuspendLayout();
            this.pnl_Console.SuspendLayout();
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
            this.btn_Create.TabIndex = 76;
            this.btn_Create.Text = "Create Mod";
            this.btn_Create.UseVisualStyleBackColor = false;
            this.btn_Create.Click += new System.EventHandler(this.Btn_Create_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Location = new System.Drawing.Point(0, 0);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(75, 23);
            this.btn_Delete.TabIndex = 102;
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
            this.unifytb_ModCreator.Controls.Add(this.unifytb_Tab_Description);
            this.unifytb_ModCreator.Controls.Add(this.unifytb_Tab_Filesystem);
            this.unifytb_ModCreator.Controls.Add(this.unifytb_Tab_Networking);
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
            this.unifytb_ModCreator.TabIndex = 101;
            this.unifytb_ModCreator.TextColor = System.Drawing.SystemColors.Control;
            this.unifytb_ModCreator.SelectedIndexChanged += new System.EventHandler(this.unifytb_ModCreator_SelectedIndexChanged);
            // 
            // unifytb_Tab_Details
            // 
            this.unifytb_Tab_Details.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.unifytb_Tab_Details.Controls.Add(this.text_Title);
            this.unifytb_Tab_Details.Controls.Add(this.lbl_Title);
            this.unifytb_Tab_Details.Controls.Add(this.text_Version);
            this.unifytb_Tab_Details.Controls.Add(this.lbl_Version);
            this.unifytb_Tab_Details.Controls.Add(this.text_Date);
            this.unifytb_Tab_Details.Controls.Add(this.lbl_Date);
            this.unifytb_Tab_Details.Controls.Add(this.text_Author);
            this.unifytb_Tab_Details.Controls.Add(this.btn_RemoveThumbnail);
            this.unifytb_Tab_Details.Controls.Add(this.lbl_Author);
            this.unifytb_Tab_Details.Controls.Add(this.btn_Browse);
            this.unifytb_Tab_Details.Controls.Add(this.lbl_System);
            this.unifytb_Tab_Details.Controls.Add(this.combo_System);
            this.unifytb_Tab_Details.Controls.Add(this.pic_Thumbnail);
            this.unifytb_Tab_Details.Location = new System.Drawing.Point(4, 20);
            this.unifytb_Tab_Details.Name = "unifytb_Tab_Details";
            this.unifytb_Tab_Details.Size = new System.Drawing.Size(373, 397);
            this.unifytb_Tab_Details.TabIndex = 0;
            this.unifytb_Tab_Details.Text = "Details";
            // 
            // text_Title
            // 
            this.text_Title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_Title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.text_Title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_Title.ForeColor = System.Drawing.SystemColors.Control;
            this.text_Title.Location = new System.Drawing.Point(73, 253);
            this.text_Title.Name = "text_Title";
            this.text_Title.Size = new System.Drawing.Size(292, 23);
            this.text_Title.TabIndex = 68;
            this.text_Title.TextChanged += new System.EventHandler(this.Text_Title_TextChanged);
            // 
            // lbl_Title
            // 
            this.lbl_Title.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_Title.Location = new System.Drawing.Point(35, 258);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(32, 15);
            this.lbl_Title.TabIndex = 69;
            this.lbl_Title.Text = "Title:";
            // 
            // text_Version
            // 
            this.text_Version.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_Version.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.text_Version.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_Version.ForeColor = System.Drawing.SystemColors.Control;
            this.text_Version.Location = new System.Drawing.Point(73, 281);
            this.text_Version.Name = "text_Version";
            this.text_Version.Size = new System.Drawing.Size(292, 23);
            this.text_Version.TabIndex = 70;
            // 
            // lbl_Version
            // 
            this.lbl_Version.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_Version.AutoSize = true;
            this.lbl_Version.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_Version.Location = new System.Drawing.Point(19, 286);
            this.lbl_Version.Name = "lbl_Version";
            this.lbl_Version.Size = new System.Drawing.Size(48, 15);
            this.lbl_Version.TabIndex = 71;
            this.lbl_Version.Text = "Version:";
            // 
            // text_Date
            // 
            this.text_Date.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_Date.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.text_Date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_Date.ForeColor = System.Drawing.SystemColors.Control;
            this.text_Date.Location = new System.Drawing.Point(73, 309);
            this.text_Date.Name = "text_Date";
            this.text_Date.Size = new System.Drawing.Size(292, 23);
            this.text_Date.TabIndex = 72;
            // 
            // lbl_Date
            // 
            this.lbl_Date.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_Date.AutoSize = true;
            this.lbl_Date.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_Date.Location = new System.Drawing.Point(33, 314);
            this.lbl_Date.Name = "lbl_Date";
            this.lbl_Date.Size = new System.Drawing.Size(34, 15);
            this.lbl_Date.TabIndex = 73;
            this.lbl_Date.Text = "Date:";
            // 
            // text_Author
            // 
            this.text_Author.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_Author.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.text_Author.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_Author.ForeColor = System.Drawing.SystemColors.Control;
            this.text_Author.Location = new System.Drawing.Point(73, 337);
            this.text_Author.Name = "text_Author";
            this.text_Author.Size = new System.Drawing.Size(292, 23);
            this.text_Author.TabIndex = 74;
            // 
            // btn_RemoveThumbnail
            // 
            this.btn_RemoveThumbnail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_RemoveThumbnail.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_RemoveThumbnail.FlatAppearance.BorderSize = 0;
            this.btn_RemoveThumbnail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_RemoveThumbnail.Font = new System.Drawing.Font("Consolas", 9F);
            this.btn_RemoveThumbnail.Location = new System.Drawing.Point(341, 11);
            this.btn_RemoveThumbnail.Name = "btn_RemoveThumbnail";
            this.btn_RemoveThumbnail.Size = new System.Drawing.Size(23, 23);
            this.btn_RemoveThumbnail.TabIndex = 87;
            this.btn_RemoveThumbnail.Text = "X";
            this.btn_RemoveThumbnail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_RemoveThumbnail.UseVisualStyleBackColor = false;
            this.btn_RemoveThumbnail.Click += new System.EventHandler(this.Btn_RemoveThumbnail_Click);
            // 
            // lbl_Author
            // 
            this.lbl_Author.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_Author.AutoSize = true;
            this.lbl_Author.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_Author.Location = new System.Drawing.Point(20, 342);
            this.lbl_Author.Name = "lbl_Author";
            this.lbl_Author.Size = new System.Drawing.Size(47, 15);
            this.lbl_Author.TabIndex = 75;
            this.lbl_Author.Text = "Author:";
            // 
            // btn_Browse
            // 
            this.btn_Browse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Browse.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Browse.FlatAppearance.BorderSize = 0;
            this.btn_Browse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Browse.Location = new System.Drawing.Point(8, 218);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(357, 25);
            this.btn_Browse.TabIndex = 46;
            this.btn_Browse.Text = "Browse...";
            this.btn_Browse.UseVisualStyleBackColor = false;
            this.btn_Browse.Click += new System.EventHandler(this.Btn_Browse_Click);
            // 
            // lbl_System
            // 
            this.lbl_System.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_System.AutoSize = true;
            this.lbl_System.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_System.Location = new System.Drawing.Point(19, 370);
            this.lbl_System.Name = "lbl_System";
            this.lbl_System.Size = new System.Drawing.Size(48, 15);
            this.lbl_System.TabIndex = 78;
            this.lbl_System.Text = "System:";
            // 
            // combo_System
            // 
            this.combo_System.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_System.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_System.FormattingEnabled = true;
            this.combo_System.Items.AddRange(new object[] {
            "Xbox 360",
            "PlayStation 3",
            "All Systems"});
            this.combo_System.Location = new System.Drawing.Point(73, 365);
            this.combo_System.Name = "combo_System";
            this.combo_System.Size = new System.Drawing.Size(292, 23);
            this.combo_System.TabIndex = 79;
            this.combo_System.SelectedIndexChanged += new System.EventHandler(this.Combo_System_SelectedIndexChanged);
            // 
            // pic_Thumbnail
            // 
            this.pic_Thumbnail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pic_Thumbnail.BackgroundImage = global::Unify.Properties.Resources.Exception_Logo_Full_Colour;
            this.pic_Thumbnail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pic_Thumbnail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_Thumbnail.Location = new System.Drawing.Point(8, 10);
            this.pic_Thumbnail.Name = "pic_Thumbnail";
            this.pic_Thumbnail.Size = new System.Drawing.Size(357, 209);
            this.pic_Thumbnail.TabIndex = 0;
            this.pic_Thumbnail.TabStop = false;
            // 
            // unifytb_Tab_Description
            // 
            this.unifytb_Tab_Description.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.unifytb_Tab_Description.Controls.Add(this.group_DescriptionField);
            this.unifytb_Tab_Description.Location = new System.Drawing.Point(4, 20);
            this.unifytb_Tab_Description.Name = "unifytb_Tab_Description";
            this.unifytb_Tab_Description.Size = new System.Drawing.Size(373, 397);
            this.unifytb_Tab_Description.TabIndex = 3;
            this.unifytb_Tab_Description.Text = "Description";
            // 
            // group_DescriptionField
            // 
            this.group_DescriptionField.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.group_DescriptionField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.group_DescriptionField.Controls.Add(this.tb_Description);
            this.group_DescriptionField.ForeColor = System.Drawing.SystemColors.Control;
            this.group_DescriptionField.Location = new System.Drawing.Point(2, 2);
            this.group_DescriptionField.Name = "group_DescriptionField";
            this.group_DescriptionField.Size = new System.Drawing.Size(369, 394);
            this.group_DescriptionField.TabIndex = 86;
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
            this.tb_Description.Size = new System.Drawing.Size(364, 373);
            this.tb_Description.TabIndex = 85;
            this.tb_Description.Text = "";
            // 
            // unifytb_Tab_Filesystem
            // 
            this.unifytb_Tab_Filesystem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.unifytb_Tab_Filesystem.Controls.Add(this.btn_Custom);
            this.unifytb_Tab_Filesystem.Controls.Add(this.lbl_Custom);
            this.unifytb_Tab_Filesystem.Controls.Add(this.text_Custom);
            this.unifytb_Tab_Filesystem.Controls.Add(this.group_Options);
            this.unifytb_Tab_Filesystem.Controls.Add(this.btn_ReadOnlyBrowser);
            this.unifytb_Tab_Filesystem.Controls.Add(this.lbl_Save);
            this.unifytb_Tab_Filesystem.Controls.Add(this.btn_SaveBrowser);
            this.unifytb_Tab_Filesystem.Controls.Add(this.text_Save);
            this.unifytb_Tab_Filesystem.Controls.Add(this.lbl_ReadOnly);
            this.unifytb_Tab_Filesystem.Controls.Add(this.text_ReadOnly);
            this.unifytb_Tab_Filesystem.Location = new System.Drawing.Point(4, 20);
            this.unifytb_Tab_Filesystem.Name = "unifytb_Tab_Filesystem";
            this.unifytb_Tab_Filesystem.Size = new System.Drawing.Size(373, 397);
            this.unifytb_Tab_Filesystem.TabIndex = 4;
            this.unifytb_Tab_Filesystem.Text = "Filesystem";
            // 
            // btn_Custom
            // 
            this.btn_Custom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Custom.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Custom.FlatAppearance.BorderSize = 0;
            this.btn_Custom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Custom.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Custom.Location = new System.Drawing.Point(345, 38);
            this.btn_Custom.Name = "btn_Custom";
            this.btn_Custom.Size = new System.Drawing.Size(22, 23);
            this.btn_Custom.TabIndex = 106;
            this.btn_Custom.Text = "...";
            this.btn_Custom.UseVisualStyleBackColor = false;
            this.btn_Custom.Click += new System.EventHandler(this.Btn_CustomArchives_Click);
            // 
            // lbl_Custom
            // 
            this.lbl_Custom.AutoSize = true;
            this.lbl_Custom.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_Custom.Location = new System.Drawing.Point(17, 42);
            this.lbl_Custom.Name = "lbl_Custom";
            this.lbl_Custom.Size = new System.Drawing.Size(52, 15);
            this.lbl_Custom.TabIndex = 105;
            this.lbl_Custom.Text = "Custom:";
            // 
            // text_Custom
            // 
            this.text_Custom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_Custom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.text_Custom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_Custom.ForeColor = System.Drawing.SystemColors.Control;
            this.text_Custom.Location = new System.Drawing.Point(75, 38);
            this.text_Custom.Name = "text_Custom";
            this.text_Custom.Size = new System.Drawing.Size(265, 23);
            this.text_Custom.TabIndex = 104;
            // 
            // group_Options
            // 
            this.group_Options.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.group_Options.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.group_Options.Controls.Add(this.check_Merge);
            this.group_Options.Controls.Add(this.check_GenerateFilesystem);
            this.group_Options.ForeColor = System.Drawing.SystemColors.Control;
            this.group_Options.Location = new System.Drawing.Point(7, 98);
            this.group_Options.Name = "group_Options";
            this.group_Options.Size = new System.Drawing.Size(359, 78);
            this.group_Options.TabIndex = 103;
            this.group_Options.TabStop = false;
            this.group_Options.Text = "Options";
            // 
            // check_Merge
            // 
            this.check_Merge.AutoSize = true;
            this.check_Merge.ForeColor = System.Drawing.SystemColors.Control;
            this.check_Merge.Location = new System.Drawing.Point(13, 24);
            this.check_Merge.Name = "check_Merge";
            this.check_Merge.Size = new System.Drawing.Size(172, 19);
            this.check_Merge.TabIndex = 95;
            this.check_Merge.Text = "Mergeable with other mods";
            this.check_Merge.UseVisualStyleBackColor = true;
            this.check_Merge.CheckedChanged += new System.EventHandler(this.Check_Merge_CheckedChanged);
            // 
            // check_GenerateFilesystem
            // 
            this.check_GenerateFilesystem.AutoSize = true;
            this.check_GenerateFilesystem.ForeColor = System.Drawing.SystemColors.Control;
            this.check_GenerateFilesystem.Location = new System.Drawing.Point(13, 47);
            this.check_GenerateFilesystem.Name = "check_GenerateFilesystem";
            this.check_GenerateFilesystem.Size = new System.Drawing.Size(169, 19);
            this.check_GenerateFilesystem.TabIndex = 102;
            this.check_GenerateFilesystem.Text = "Generate default filesystem";
            this.check_GenerateFilesystem.UseVisualStyleBackColor = true;
            // 
            // btn_ReadOnlyBrowser
            // 
            this.btn_ReadOnlyBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ReadOnlyBrowser.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_ReadOnlyBrowser.Enabled = false;
            this.btn_ReadOnlyBrowser.FlatAppearance.BorderSize = 0;
            this.btn_ReadOnlyBrowser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ReadOnlyBrowser.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ReadOnlyBrowser.Location = new System.Drawing.Point(345, 10);
            this.btn_ReadOnlyBrowser.Name = "btn_ReadOnlyBrowser";
            this.btn_ReadOnlyBrowser.Size = new System.Drawing.Size(22, 23);
            this.btn_ReadOnlyBrowser.TabIndex = 101;
            this.btn_ReadOnlyBrowser.Text = "...";
            this.btn_ReadOnlyBrowser.UseVisualStyleBackColor = false;
            this.btn_ReadOnlyBrowser.Click += new System.EventHandler(this.Btn_ReadOnlyBrowser_Click);
            // 
            // lbl_Save
            // 
            this.lbl_Save.AutoSize = true;
            this.lbl_Save.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_Save.Location = new System.Drawing.Point(35, 70);
            this.lbl_Save.Name = "lbl_Save";
            this.lbl_Save.Size = new System.Drawing.Size(34, 15);
            this.lbl_Save.TabIndex = 100;
            this.lbl_Save.Text = "Save:";
            // 
            // btn_SaveBrowser
            // 
            this.btn_SaveBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SaveBrowser.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_SaveBrowser.FlatAppearance.BorderSize = 0;
            this.btn_SaveBrowser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SaveBrowser.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SaveBrowser.Location = new System.Drawing.Point(345, 66);
            this.btn_SaveBrowser.Name = "btn_SaveBrowser";
            this.btn_SaveBrowser.Size = new System.Drawing.Size(22, 23);
            this.btn_SaveBrowser.TabIndex = 99;
            this.btn_SaveBrowser.Text = "...";
            this.btn_SaveBrowser.UseVisualStyleBackColor = false;
            this.btn_SaveBrowser.Click += new System.EventHandler(this.Btn_SaveBrowser_Click);
            // 
            // text_Save
            // 
            this.text_Save.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.text_Save.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_Save.ForeColor = System.Drawing.SystemColors.Control;
            this.text_Save.Location = new System.Drawing.Point(75, 66);
            this.text_Save.Name = "text_Save";
            this.text_Save.Size = new System.Drawing.Size(265, 23);
            this.text_Save.TabIndex = 98;
            // 
            // lbl_ReadOnly
            // 
            this.lbl_ReadOnly.AutoSize = true;
            this.lbl_ReadOnly.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbl_ReadOnly.Location = new System.Drawing.Point(5, 14);
            this.lbl_ReadOnly.Name = "lbl_ReadOnly";
            this.lbl_ReadOnly.Size = new System.Drawing.Size(64, 15);
            this.lbl_ReadOnly.TabIndex = 97;
            this.lbl_ReadOnly.Text = "Read-only:";
            // 
            // text_ReadOnly
            // 
            this.text_ReadOnly.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_ReadOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.text_ReadOnly.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_ReadOnly.Enabled = false;
            this.text_ReadOnly.ForeColor = System.Drawing.SystemColors.Control;
            this.text_ReadOnly.Location = new System.Drawing.Point(75, 10);
            this.text_ReadOnly.Name = "text_ReadOnly";
            this.text_ReadOnly.Size = new System.Drawing.Size(265, 23);
            this.text_ReadOnly.TabIndex = 96;
            // 
            // unifytb_Tab_Networking
            // 
            this.unifytb_Tab_Networking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.unifytb_Tab_Networking.Controls.Add(this.btn_TestConnection);
            this.unifytb_Tab_Networking.Controls.Add(this.lbl_Data);
            this.unifytb_Tab_Networking.Controls.Add(this.pnl_Console);
            this.unifytb_Tab_Networking.Controls.Add(this.text_Server);
            this.unifytb_Tab_Networking.Controls.Add(this.text_Data);
            this.unifytb_Tab_Networking.Controls.Add(this.lbl_Server);
            this.unifytb_Tab_Networking.Location = new System.Drawing.Point(4, 20);
            this.unifytb_Tab_Networking.Name = "unifytb_Tab_Networking";
            this.unifytb_Tab_Networking.Size = new System.Drawing.Size(373, 397);
            this.unifytb_Tab_Networking.TabIndex = 1;
            this.unifytb_Tab_Networking.Text = "Networking";
            // 
            // btn_TestConnection
            // 
            this.btn_TestConnection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_TestConnection.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_TestConnection.Enabled = false;
            this.btn_TestConnection.FlatAppearance.BorderSize = 0;
            this.btn_TestConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_TestConnection.Location = new System.Drawing.Point(8, 367);
            this.btn_TestConnection.Name = "btn_TestConnection";
            this.btn_TestConnection.Size = new System.Drawing.Size(357, 23);
            this.btn_TestConnection.TabIndex = 98;
            this.btn_TestConnection.Text = "Test Connection to Update Server";
            this.btn_TestConnection.UseVisualStyleBackColor = false;
            this.btn_TestConnection.Click += new System.EventHandler(this.Btn_TestConnection_Click);
            // 
            // lbl_Data
            // 
            this.lbl_Data.AutoSize = true;
            this.lbl_Data.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_Data.Location = new System.Drawing.Point(16, 42);
            this.lbl_Data.Name = "lbl_Data";
            this.lbl_Data.Size = new System.Drawing.Size(34, 15);
            this.lbl_Data.TabIndex = 100;
            this.lbl_Data.Text = "Data:";
            // 
            // pnl_Console
            // 
            this.pnl_Console.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_Console.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pnl_Console.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Console.Controls.Add(this.list_Console);
            this.pnl_Console.Location = new System.Drawing.Point(8, 69);
            this.pnl_Console.Name = "pnl_Console";
            this.pnl_Console.Size = new System.Drawing.Size(357, 289);
            this.pnl_Console.TabIndex = 97;
            // 
            // list_Console
            // 
            this.list_Console.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.list_Console.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.list_Console.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list_Console.ForeColor = System.Drawing.SystemColors.Control;
            this.list_Console.FormattingEnabled = true;
            this.list_Console.HorizontalScrollbar = true;
            this.list_Console.ItemHeight = 15;
            this.list_Console.Location = new System.Drawing.Point(0, 0);
            this.list_Console.Name = "list_Console";
            this.list_Console.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.list_Console.Size = new System.Drawing.Size(355, 287);
            this.list_Console.TabIndex = 96;
            // 
            // text_Server
            // 
            this.text_Server.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_Server.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.text_Server.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_Server.ForeColor = System.Drawing.SystemColors.Control;
            this.text_Server.Location = new System.Drawing.Point(56, 10);
            this.text_Server.Name = "text_Server";
            this.text_Server.Size = new System.Drawing.Size(309, 23);
            this.text_Server.TabIndex = 94;
            this.text_Server.TextChanged += new System.EventHandler(this.Text_UpdateURL_TextChanged);
            // 
            // text_Data
            // 
            this.text_Data.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_Data.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.text_Data.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_Data.ForeColor = System.Drawing.SystemColors.Control;
            this.text_Data.Location = new System.Drawing.Point(56, 38);
            this.text_Data.Name = "text_Data";
            this.text_Data.Size = new System.Drawing.Size(309, 23);
            this.text_Data.TabIndex = 99;
            // 
            // lbl_Server
            // 
            this.lbl_Server.AutoSize = true;
            this.lbl_Server.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_Server.Location = new System.Drawing.Point(8, 14);
            this.lbl_Server.Name = "lbl_Server";
            this.lbl_Server.Size = new System.Drawing.Size(42, 15);
            this.lbl_Server.TabIndex = 95;
            this.lbl_Server.Text = "Server:";
            // 
            // ModCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(381, 461);
            this.Controls.Add(this.unifytb_ModCreator);
            this.Controls.Add(this.btn_Create);
            this.Controls.Add(this.btn_Delete);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(397, 500);
            this.Name = "ModCreator";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mod Creator";
            this.unifytb_ModCreator.ResumeLayout(false);
            this.unifytb_Tab_Details.ResumeLayout(false);
            this.unifytb_Tab_Details.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Thumbnail)).EndInit();
            this.unifytb_Tab_Description.ResumeLayout(false);
            this.group_DescriptionField.ResumeLayout(false);
            this.unifytb_Tab_Filesystem.ResumeLayout(false);
            this.unifytb_Tab_Filesystem.PerformLayout();
            this.group_Options.ResumeLayout(false);
            this.group_Options.PerformLayout();
            this.unifytb_Tab_Networking.ResumeLayout(false);
            this.unifytb_Tab_Networking.PerformLayout();
            this.pnl_Console.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_Thumbnail;
        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.ComboBox combo_System;
        private System.Windows.Forms.Label lbl_System;
        private System.Windows.Forms.Button btn_Create;
        private System.Windows.Forms.Label lbl_Author;
        private System.Windows.Forms.TextBox text_Author;
        private System.Windows.Forms.Label lbl_Date;
        private System.Windows.Forms.TextBox text_Date;
        private System.Windows.Forms.Label lbl_Version;
        private System.Windows.Forms.TextBox text_Version;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.TextBox text_Title;
        private System.Windows.Forms.RichTextBox tb_Description;
        private System.Windows.Forms.GroupBox group_DescriptionField;
        private System.Windows.Forms.Button btn_RemoveThumbnail;
        private System.Windows.Forms.Label lbl_Server;
        private System.Windows.Forms.TextBox text_Server;
        private System.Windows.Forms.ListBox list_Console;
        private System.Windows.Forms.Panel pnl_Console;
        private System.Windows.Forms.Button btn_TestConnection;
        private System.Windows.Forms.Label lbl_Data;
        private System.Windows.Forms.TextBox text_Data;
        private UnifyTabControl unifytb_ModCreator;
        private System.Windows.Forms.TabPage unifytb_Tab_Details;
        private System.Windows.Forms.TabPage unifytb_Tab_Networking;
        private System.Windows.Forms.TabPage unifytb_Tab_Description;
        private System.Windows.Forms.TabPage unifytb_Tab_Filesystem;
        private System.Windows.Forms.Button btn_ReadOnlyBrowser;
        private System.Windows.Forms.Label lbl_Save;
        private System.Windows.Forms.Button btn_SaveBrowser;
        private System.Windows.Forms.TextBox text_Save;
        private System.Windows.Forms.Label lbl_ReadOnly;
        private System.Windows.Forms.CheckBox check_Merge;
        private System.Windows.Forms.TextBox text_ReadOnly;
        private System.Windows.Forms.Button btn_Custom;
        private System.Windows.Forms.Label lbl_Custom;
        private System.Windows.Forms.TextBox text_Custom;
        private System.Windows.Forms.GroupBox group_Options;
        private System.Windows.Forms.CheckBox check_GenerateFilesystem;
    }
}