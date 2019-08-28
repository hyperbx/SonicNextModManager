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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModManager));
            this.btn_SaveAndPlay = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Play = new System.Windows.Forms.Button();
            this.btn_RefreshMods = new System.Windows.Forms.Button();
            this.btn_CreateNewMod = new System.Windows.Forms.Button();
            this.btn_ModInfo = new System.Windows.Forms.Button();
            this.status_Main = new System.Windows.Forms.StatusStrip();
            this.statuslbl_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.radio_All = new System.Windows.Forms.RadioButton();
            this.radio_Xbox360 = new System.Windows.Forms.RadioButton();
            this.radio_PlayStation3 = new System.Windows.Forms.RadioButton();
            this.btn_UninstallMods = new System.Windows.Forms.Button();
            this.btn_EditMod = new System.Windows.Forms.Button();
            this.unifytb_Main = new UnifyTabControl.UnifyTabControl();
            this.unifytb_Tab_Mods = new System.Windows.Forms.TabPage();
            this.btn_Priority = new System.Windows.Forms.Button();
            this.btn_DownerPriority = new System.Windows.Forms.Button();
            this.btn_UpperPriority = new System.Windows.Forms.Button();
            this.btn_DeselectAll = new System.Windows.Forms.Button();
            this.btn_SelectAll = new System.Windows.Forms.Button();
            this.clb_ModsList = new System.Windows.Forms.CheckedListBox();
            this.unifytb_Tab_Emulator = new System.Windows.Forms.TabPage();
            this.lbl_SettingsOverlay = new System.Windows.Forms.Label();
            this.lbl_Debug = new System.Windows.Forms.Label();
            this.lbl_Discord = new System.Windows.Forms.Label();
            this.lbl_Fullscreen = new System.Windows.Forms.Label();
            this.lbl_EnableGamma = new System.Windows.Forms.Label();
            this.lbl_ProtectZero = new System.Windows.Forms.Label();
            this.lbl_VSync = new System.Windows.Forms.Label();
            this.lbl_2xResolution = new System.Windows.Forms.Label();
            this.lbl_ForceRTV = new System.Windows.Forms.Label();
            this.group_Settings = new System.Windows.Forms.GroupBox();
            this.check_Discord = new System.Windows.Forms.CheckBox();
            this.check_Fullscreen = new System.Windows.Forms.CheckBox();
            this.check_Debug = new System.Windows.Forms.CheckBox();
            this.check_Gamma = new System.Windows.Forms.CheckBox();
            this.check_ProtectZero = new System.Windows.Forms.CheckBox();
            this.check_VSync = new System.Windows.Forms.CheckBox();
            this.check_2xRes = new System.Windows.Forms.CheckBox();
            this.check_RTV = new System.Windows.Forms.CheckBox();
            this.group_Setup = new System.Windows.Forms.GroupBox();
            this.combo_Emulator_System = new System.Windows.Forms.ComboBox();
            this.lbl_Emulator_System = new System.Windows.Forms.Label();
            this.combo_API = new System.Windows.Forms.ComboBox();
            this.lbl_API = new System.Windows.Forms.Label();
            this.btn_EmulatorPath = new System.Windows.Forms.Button();
            this.text_EmulatorPath = new System.Windows.Forms.TextBox();
            this.lbl_EmulatorEXE = new System.Windows.Forms.Label();
            this.unifytb_Tab_Patches = new System.Windows.Forms.TabPage();
            this.group_Tweaks = new System.Windows.Forms.GroupBox();
            this.btn_ResetCameraHeight = new System.Windows.Forms.Button();
            this.nud_CameraHeight = new System.Windows.Forms.NumericUpDown();
            this.lbl_CameraHeight = new System.Windows.Forms.Label();
            this.btn_ResetViewportX = new System.Windows.Forms.Button();
            this.btn_ResetReflections = new System.Windows.Forms.Button();
            this.btn_ResetViewportY = new System.Windows.Forms.Button();
            this.btn_ResetCameraDistance = new System.Windows.Forms.Button();
            this.nud_CameraDistance = new System.Windows.Forms.NumericUpDown();
            this.lbl_CameraDistance = new System.Windows.Forms.Label();
            this.nud_ViewportY = new System.Windows.Forms.NumericUpDown();
            this.nud_ViewportX = new System.Windows.Forms.NumericUpDown();
            this.lbl_ViewportY = new System.Windows.Forms.Label();
            this.lbl_ViewportX = new System.Windows.Forms.Label();
            this.lbl_Reflections = new System.Windows.Forms.Label();
            this.combo_Reflections = new System.Windows.Forms.ComboBox();
            this.clb_PatchesList = new System.Windows.Forms.CheckedListBox();
            this.unifytb_Tab_Settings = new System.Windows.Forms.TabPage();
            this.group_Options = new System.Windows.Forms.GroupBox();
            this.btn_ReportBug = new System.Windows.Forms.Button();
            this.lbl_GameBanana = new System.Windows.Forms.Label();
            this.check_GameBanana = new System.Windows.Forms.CheckBox();
            this.btn_Update = new System.Windows.Forms.Button();
            this.lbl_ManualInstall = new System.Windows.Forms.Label();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.btn_GitHub = new System.Windows.Forms.Button();
            this.btn_About = new System.Windows.Forms.Button();
            this.btn_ColourPicker_Default = new System.Windows.Forms.Button();
            this.lbl_AccentColour = new System.Windows.Forms.Label();
            this.btn_ColourPicker = new System.Windows.Forms.Button();
            this.check_ManualInstall = new System.Windows.Forms.CheckBox();
            this.btn_Theme = new System.Windows.Forms.Button();
            this.group_FTP = new System.Windows.Forms.GroupBox();
            this.lbl_FTP = new System.Windows.Forms.Label();
            this.check_FTP = new System.Windows.Forms.CheckBox();
            this.combo_FTP_System = new System.Windows.Forms.ComboBox();
            this.text_Password = new System.Windows.Forms.TextBox();
            this.lbl_System = new System.Windows.Forms.Label();
            this.lbl_Password = new System.Windows.Forms.Label();
            this.text_Username = new System.Windows.Forms.TextBox();
            this.text_FTPLocation = new System.Windows.Forms.TextBox();
            this.lbl_Username = new System.Windows.Forms.Label();
            this.lbl_FTPLocation = new System.Windows.Forms.Label();
            this.group_Directories = new System.Windows.Forms.GroupBox();
            this.btn_GameFolder = new System.Windows.Forms.Button();
            this.btn_ModsFolder = new System.Windows.Forms.Button();
            this.text_GameDirectory = new System.Windows.Forms.TextBox();
            this.text_ModsDirectory = new System.Windows.Forms.TextBox();
            this.lbl_GameDirectory = new System.Windows.Forms.Label();
            this.lbl_ModsDirectory = new System.Windows.Forms.Label();
            this.unifytb_Main.SuspendLayout();
            this.unifytb_Tab_Mods.SuspendLayout();
            this.unifytb_Tab_Emulator.SuspendLayout();
            this.group_Settings.SuspendLayout();
            this.group_Setup.SuspendLayout();
            this.unifytb_Tab_Patches.SuspendLayout();
            this.group_Tweaks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_CameraHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_CameraDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ViewportY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ViewportX)).BeginInit();
            this.unifytb_Tab_Settings.SuspendLayout();
            this.group_Options.SuspendLayout();
            this.group_FTP.SuspendLayout();
            this.group_Directories.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_SaveAndPlay
            // 
            this.btn_SaveAndPlay.BackColor = System.Drawing.Color.LightGreen;
            this.btn_SaveAndPlay.FlatAppearance.BorderSize = 0;
            this.btn_SaveAndPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SaveAndPlay.Location = new System.Drawing.Point(147, 516);
            this.btn_SaveAndPlay.Name = "btn_SaveAndPlay";
            this.btn_SaveAndPlay.Size = new System.Drawing.Size(245, 23);
            this.btn_SaveAndPlay.TabIndex = 44;
            this.btn_SaveAndPlay.Text = "Save and Play";
            this.btn_SaveAndPlay.UseVisualStyleBackColor = false;
            this.btn_SaveAndPlay.Click += new System.EventHandler(this.Btn_SaveAndPlay_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Save.FlatAppearance.BorderSize = 0;
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.Location = new System.Drawing.Point(9, 516);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(132, 23);
            this.btn_Save.TabIndex = 43;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // btn_Play
            // 
            this.btn_Play.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Play.FlatAppearance.BorderSize = 0;
            this.btn_Play.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Play.Location = new System.Drawing.Point(398, 516);
            this.btn_Play.Name = "btn_Play";
            this.btn_Play.Size = new System.Drawing.Size(132, 23);
            this.btn_Play.TabIndex = 45;
            this.btn_Play.Text = "Play";
            this.btn_Play.UseVisualStyleBackColor = false;
            this.btn_Play.Click += new System.EventHandler(this.Btn_Play_Click);
            // 
            // btn_RefreshMods
            // 
            this.btn_RefreshMods.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_RefreshMods.FlatAppearance.BorderSize = 0;
            this.btn_RefreshMods.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_RefreshMods.Location = new System.Drawing.Point(398, 545);
            this.btn_RefreshMods.Name = "btn_RefreshMods";
            this.btn_RefreshMods.Size = new System.Drawing.Size(132, 23);
            this.btn_RefreshMods.TabIndex = 48;
            this.btn_RefreshMods.Text = "Refresh Mods";
            this.btn_RefreshMods.UseVisualStyleBackColor = false;
            this.btn_RefreshMods.Click += new System.EventHandler(this.Btn_RefreshMods_Click);
            // 
            // btn_CreateNewMod
            // 
            this.btn_CreateNewMod.BackColor = System.Drawing.Color.LightGreen;
            this.btn_CreateNewMod.FlatAppearance.BorderSize = 0;
            this.btn_CreateNewMod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CreateNewMod.Location = new System.Drawing.Point(147, 545);
            this.btn_CreateNewMod.Name = "btn_CreateNewMod";
            this.btn_CreateNewMod.Size = new System.Drawing.Size(120, 23);
            this.btn_CreateNewMod.TabIndex = 47;
            this.btn_CreateNewMod.Text = "Create New Mod";
            this.btn_CreateNewMod.UseVisualStyleBackColor = false;
            this.btn_CreateNewMod.Click += new System.EventHandler(this.Btn_CreateNewMod_Click);
            // 
            // btn_ModInfo
            // 
            this.btn_ModInfo.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_ModInfo.FlatAppearance.BorderSize = 0;
            this.btn_ModInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ModInfo.Location = new System.Drawing.Point(9, 545);
            this.btn_ModInfo.Name = "btn_ModInfo";
            this.btn_ModInfo.Size = new System.Drawing.Size(132, 23);
            this.btn_ModInfo.TabIndex = 46;
            this.btn_ModInfo.Text = "Mod Info";
            this.btn_ModInfo.UseVisualStyleBackColor = false;
            this.btn_ModInfo.Click += new System.EventHandler(this.Btn_ModInfo_Click);
            // 
            // status_Main
            // 
            this.status_Main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.status_Main.Location = new System.Drawing.Point(0, 579);
            this.status_Main.Name = "status_Main";
            this.status_Main.Size = new System.Drawing.Size(538, 22);
            this.status_Main.SizingGrip = false;
            this.status_Main.TabIndex = 49;
            // 
            // statuslbl_Status
            // 
            this.statuslbl_Status.ForeColor = System.Drawing.SystemColors.Control;
            this.statuslbl_Status.Name = "statuslbl_Status";
            this.statuslbl_Status.Size = new System.Drawing.Size(42, 17);
            this.statuslbl_Status.Text = "Ready.";
            // 
            // radio_All
            // 
            this.radio_All.AutoSize = true;
            this.radio_All.ForeColor = System.Drawing.SystemColors.Control;
            this.radio_All.Location = new System.Drawing.Point(339, 1);
            this.radio_All.Name = "radio_All";
            this.radio_All.Size = new System.Drawing.Size(36, 17);
            this.radio_All.TabIndex = 50;
            this.radio_All.Text = "All";
            this.radio_All.UseVisualStyleBackColor = true;
            this.radio_All.CheckedChanged += new System.EventHandler(this.Radio_All_CheckedChanged);
            // 
            // radio_Xbox360
            // 
            this.radio_Xbox360.AutoSize = true;
            this.radio_Xbox360.ForeColor = System.Drawing.SystemColors.Control;
            this.radio_Xbox360.Location = new System.Drawing.Point(378, 1);
            this.radio_Xbox360.Name = "radio_Xbox360";
            this.radio_Xbox360.Size = new System.Drawing.Size(70, 17);
            this.radio_Xbox360.TabIndex = 51;
            this.radio_Xbox360.Text = "Xbox 360";
            this.radio_Xbox360.UseVisualStyleBackColor = true;
            this.radio_Xbox360.CheckedChanged += new System.EventHandler(this.Radio_Xbox360_CheckedChanged);
            // 
            // radio_PlayStation3
            // 
            this.radio_PlayStation3.AutoSize = true;
            this.radio_PlayStation3.ForeColor = System.Drawing.SystemColors.Control;
            this.radio_PlayStation3.Location = new System.Drawing.Point(452, 1);
            this.radio_PlayStation3.Name = "radio_PlayStation3";
            this.radio_PlayStation3.Size = new System.Drawing.Size(87, 17);
            this.radio_PlayStation3.TabIndex = 52;
            this.radio_PlayStation3.Text = "PlayStation 3";
            this.radio_PlayStation3.UseVisualStyleBackColor = true;
            this.radio_PlayStation3.CheckedChanged += new System.EventHandler(this.Radio_PlayStation3_CheckedChanged);
            // 
            // btn_UninstallMods
            // 
            this.btn_UninstallMods.BackColor = System.Drawing.Color.Tomato;
            this.btn_UninstallMods.FlatAppearance.BorderSize = 0;
            this.btn_UninstallMods.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_UninstallMods.Location = new System.Drawing.Point(273, 516);
            this.btn_UninstallMods.Name = "btn_UninstallMods";
            this.btn_UninstallMods.Size = new System.Drawing.Size(119, 23);
            this.btn_UninstallMods.TabIndex = 53;
            this.btn_UninstallMods.Text = "Uninstall Mods";
            this.btn_UninstallMods.UseVisualStyleBackColor = false;
            this.btn_UninstallMods.Visible = false;
            this.btn_UninstallMods.Click += new System.EventHandler(this.Btn_UninstallMods_Click);
            // 
            // btn_EditMod
            // 
            this.btn_EditMod.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_EditMod.Enabled = false;
            this.btn_EditMod.FlatAppearance.BorderSize = 0;
            this.btn_EditMod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_EditMod.Location = new System.Drawing.Point(273, 545);
            this.btn_EditMod.Name = "btn_EditMod";
            this.btn_EditMod.Size = new System.Drawing.Size(119, 23);
            this.btn_EditMod.TabIndex = 54;
            this.btn_EditMod.Text = "Edit Mod";
            this.btn_EditMod.UseVisualStyleBackColor = false;
            this.btn_EditMod.Visible = false;
            this.btn_EditMod.Click += new System.EventHandler(this.Btn_EditMod_Click);
            // 
            // unifytb_Main
            // 
            this.unifytb_Main.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.unifytb_Main.AllowDrop = true;
            this.unifytb_Main.BackTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.unifytb_Main.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.unifytb_Main.ClosingButtonColor = System.Drawing.Color.WhiteSmoke;
            this.unifytb_Main.ClosingMessage = null;
            this.unifytb_Main.Controls.Add(this.unifytb_Tab_Mods);
            this.unifytb_Main.Controls.Add(this.unifytb_Tab_Emulator);
            this.unifytb_Main.Controls.Add(this.unifytb_Tab_Patches);
            this.unifytb_Main.Controls.Add(this.unifytb_Tab_Settings);
            this.unifytb_Main.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unifytb_Main.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.unifytb_Main.HorizontalLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.unifytb_Main.ItemSize = new System.Drawing.Size(240, 16);
            this.unifytb_Main.Location = new System.Drawing.Point(0, 0);
            this.unifytb_Main.Name = "unifytb_Main";
            this.unifytb_Main.SelectedIndex = 0;
            this.unifytb_Main.SelectedTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.unifytb_Main.ShowClosingButton = false;
            this.unifytb_Main.ShowClosingMessage = false;
            this.unifytb_Main.Size = new System.Drawing.Size(538, 507);
            this.unifytb_Main.TabIndex = 0;
            this.unifytb_Main.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.unifytb_Main.SelectedIndexChanged += new System.EventHandler(this.Unifytb_Main_SelectedIndexChanged);
            // 
            // unifytb_Tab_Mods
            // 
            this.unifytb_Tab_Mods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.unifytb_Tab_Mods.Controls.Add(this.btn_Priority);
            this.unifytb_Tab_Mods.Controls.Add(this.btn_DownerPriority);
            this.unifytb_Tab_Mods.Controls.Add(this.btn_UpperPriority);
            this.unifytb_Tab_Mods.Controls.Add(this.btn_DeselectAll);
            this.unifytb_Tab_Mods.Controls.Add(this.btn_SelectAll);
            this.unifytb_Tab_Mods.Controls.Add(this.clb_ModsList);
            this.unifytb_Tab_Mods.Location = new System.Drawing.Point(4, 20);
            this.unifytb_Tab_Mods.Name = "unifytb_Tab_Mods";
            this.unifytb_Tab_Mods.Padding = new System.Windows.Forms.Padding(3);
            this.unifytb_Tab_Mods.Size = new System.Drawing.Size(530, 483);
            this.unifytb_Tab_Mods.TabIndex = 0;
            this.unifytb_Tab_Mods.Text = "Mods";
            // 
            // btn_Priority
            // 
            this.btn_Priority.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Priority.FlatAppearance.BorderSize = 0;
            this.btn_Priority.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Priority.Location = new System.Drawing.Point(348, 453);
            this.btn_Priority.Name = "btn_Priority";
            this.btn_Priority.Size = new System.Drawing.Size(174, 23);
            this.btn_Priority.TabIndex = 42;
            this.btn_Priority.Text = "Priority: Top to Bottom";
            this.btn_Priority.UseVisualStyleBackColor = false;
            this.btn_Priority.Click += new System.EventHandler(this.Btn_Priority_Click);
            // 
            // btn_DownerPriority
            // 
            this.btn_DownerPriority.BackColor = System.Drawing.Color.White;
            this.btn_DownerPriority.Enabled = false;
            this.btn_DownerPriority.FlatAppearance.BorderSize = 0;
            this.btn_DownerPriority.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DownerPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DownerPriority.Location = new System.Drawing.Point(315, 453);
            this.btn_DownerPriority.Name = "btn_DownerPriority";
            this.btn_DownerPriority.Size = new System.Drawing.Size(26, 23);
            this.btn_DownerPriority.TabIndex = 41;
            this.btn_DownerPriority.Text = "▼";
            this.btn_DownerPriority.UseVisualStyleBackColor = false;
            this.btn_DownerPriority.Click += new System.EventHandler(this.Btn_DownerPriority_Click);
            // 
            // btn_UpperPriority
            // 
            this.btn_UpperPriority.BackColor = System.Drawing.Color.White;
            this.btn_UpperPriority.Enabled = false;
            this.btn_UpperPriority.FlatAppearance.BorderSize = 0;
            this.btn_UpperPriority.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_UpperPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_UpperPriority.Location = new System.Drawing.Point(285, 453);
            this.btn_UpperPriority.Name = "btn_UpperPriority";
            this.btn_UpperPriority.Size = new System.Drawing.Size(26, 23);
            this.btn_UpperPriority.TabIndex = 40;
            this.btn_UpperPriority.Text = "▲";
            this.btn_UpperPriority.UseVisualStyleBackColor = false;
            this.btn_UpperPriority.Click += new System.EventHandler(this.Btn_UpperPriority_Click);
            // 
            // btn_DeselectAll
            // 
            this.btn_DeselectAll.BackColor = System.Drawing.Color.Tomato;
            this.btn_DeselectAll.FlatAppearance.BorderSize = 0;
            this.btn_DeselectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DeselectAll.Location = new System.Drawing.Point(146, 453);
            this.btn_DeselectAll.Name = "btn_DeselectAll";
            this.btn_DeselectAll.Size = new System.Drawing.Size(132, 23);
            this.btn_DeselectAll.TabIndex = 2;
            this.btn_DeselectAll.Text = "Deselect All";
            this.btn_DeselectAll.UseVisualStyleBackColor = false;
            this.btn_DeselectAll.Click += new System.EventHandler(this.Btn_DeselectAll_Click);
            // 
            // btn_SelectAll
            // 
            this.btn_SelectAll.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_SelectAll.FlatAppearance.BorderSize = 0;
            this.btn_SelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SelectAll.Location = new System.Drawing.Point(8, 453);
            this.btn_SelectAll.Name = "btn_SelectAll";
            this.btn_SelectAll.Size = new System.Drawing.Size(132, 23);
            this.btn_SelectAll.TabIndex = 1;
            this.btn_SelectAll.Text = "Select All";
            this.btn_SelectAll.UseVisualStyleBackColor = false;
            this.btn_SelectAll.Click += new System.EventHandler(this.Btn_SelectAll_Click);
            // 
            // clb_ModsList
            // 
            this.clb_ModsList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.clb_ModsList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clb_ModsList.ForeColor = System.Drawing.SystemColors.Control;
            this.clb_ModsList.FormattingEnabled = true;
            this.clb_ModsList.Location = new System.Drawing.Point(4, 9);
            this.clb_ModsList.Name = "clb_ModsList";
            this.clb_ModsList.Size = new System.Drawing.Size(522, 434);
            this.clb_ModsList.TabIndex = 0;
            this.clb_ModsList.SelectedIndexChanged += new System.EventHandler(this.Clb_ModsList_SelectedIndexChanged);
            // 
            // unifytb_Tab_Emulator
            // 
            this.unifytb_Tab_Emulator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.unifytb_Tab_Emulator.Controls.Add(this.lbl_SettingsOverlay);
            this.unifytb_Tab_Emulator.Controls.Add(this.lbl_Debug);
            this.unifytb_Tab_Emulator.Controls.Add(this.lbl_Discord);
            this.unifytb_Tab_Emulator.Controls.Add(this.lbl_Fullscreen);
            this.unifytb_Tab_Emulator.Controls.Add(this.lbl_EnableGamma);
            this.unifytb_Tab_Emulator.Controls.Add(this.lbl_ProtectZero);
            this.unifytb_Tab_Emulator.Controls.Add(this.lbl_VSync);
            this.unifytb_Tab_Emulator.Controls.Add(this.lbl_2xResolution);
            this.unifytb_Tab_Emulator.Controls.Add(this.lbl_ForceRTV);
            this.unifytb_Tab_Emulator.Controls.Add(this.group_Settings);
            this.unifytb_Tab_Emulator.Controls.Add(this.group_Setup);
            this.unifytb_Tab_Emulator.Location = new System.Drawing.Point(4, 20);
            this.unifytb_Tab_Emulator.Name = "unifytb_Tab_Emulator";
            this.unifytb_Tab_Emulator.Padding = new System.Windows.Forms.Padding(3);
            this.unifytb_Tab_Emulator.Size = new System.Drawing.Size(530, 483);
            this.unifytb_Tab_Emulator.TabIndex = 1;
            this.unifytb_Tab_Emulator.Text = "Emulator";
            // 
            // lbl_SettingsOverlay
            // 
            this.lbl_SettingsOverlay.AutoSize = true;
            this.lbl_SettingsOverlay.BackColor = System.Drawing.Color.Transparent;
            this.lbl_SettingsOverlay.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_SettingsOverlay.Location = new System.Drawing.Point(10, 128);
            this.lbl_SettingsOverlay.Name = "lbl_SettingsOverlay";
            this.lbl_SettingsOverlay.Size = new System.Drawing.Size(49, 15);
            this.lbl_SettingsOverlay.TabIndex = 17;
            this.lbl_SettingsOverlay.Text = "Settings";
            // 
            // lbl_Debug
            // 
            this.lbl_Debug.AutoSize = true;
            this.lbl_Debug.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_Debug.Location = new System.Drawing.Point(39, 331);
            this.lbl_Debug.Name = "lbl_Debug";
            this.lbl_Debug.Size = new System.Drawing.Size(42, 15);
            this.lbl_Debug.TabIndex = 24;
            this.lbl_Debug.Text = "Debug";
            // 
            // lbl_Discord
            // 
            this.lbl_Discord.AutoSize = true;
            this.lbl_Discord.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_Discord.Location = new System.Drawing.Point(39, 306);
            this.lbl_Discord.Name = "lbl_Discord";
            this.lbl_Discord.Size = new System.Drawing.Size(123, 15);
            this.lbl_Discord.TabIndex = 23;
            this.lbl_Discord.Text = "Discord Rich Presence";
            // 
            // lbl_Fullscreen
            // 
            this.lbl_Fullscreen.AutoSize = true;
            this.lbl_Fullscreen.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_Fullscreen.Location = new System.Drawing.Point(39, 281);
            this.lbl_Fullscreen.Name = "lbl_Fullscreen";
            this.lbl_Fullscreen.Size = new System.Drawing.Size(115, 15);
            this.lbl_Fullscreen.TabIndex = 22;
            this.lbl_Fullscreen.Text = "Launch in Fullscreen";
            // 
            // lbl_EnableGamma
            // 
            this.lbl_EnableGamma.AutoSize = true;
            this.lbl_EnableGamma.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_EnableGamma.Location = new System.Drawing.Point(39, 256);
            this.lbl_EnableGamma.Name = "lbl_EnableGamma";
            this.lbl_EnableGamma.Size = new System.Drawing.Size(87, 15);
            this.lbl_EnableGamma.TabIndex = 21;
            this.lbl_EnableGamma.Text = "Enable Gamma";
            // 
            // lbl_ProtectZero
            // 
            this.lbl_ProtectZero.AutoSize = true;
            this.lbl_ProtectZero.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_ProtectZero.Location = new System.Drawing.Point(39, 231);
            this.lbl_ProtectZero.Name = "lbl_ProtectZero";
            this.lbl_ProtectZero.Size = new System.Drawing.Size(72, 15);
            this.lbl_ProtectZero.TabIndex = 20;
            this.lbl_ProtectZero.Text = "Protect Zero";
            // 
            // lbl_VSync
            // 
            this.lbl_VSync.AutoSize = true;
            this.lbl_VSync.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_VSync.Location = new System.Drawing.Point(39, 206);
            this.lbl_VSync.Name = "lbl_VSync";
            this.lbl_VSync.Size = new System.Drawing.Size(44, 15);
            this.lbl_VSync.TabIndex = 19;
            this.lbl_VSync.Text = "V-Sync";
            // 
            // lbl_2xResolution
            // 
            this.lbl_2xResolution.AutoSize = true;
            this.lbl_2xResolution.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_2xResolution.Location = new System.Drawing.Point(39, 181);
            this.lbl_2xResolution.Name = "lbl_2xResolution";
            this.lbl_2xResolution.Size = new System.Drawing.Size(78, 15);
            this.lbl_2xResolution.TabIndex = 18;
            this.lbl_2xResolution.Text = "2x Resolution";
            // 
            // lbl_ForceRTV
            // 
            this.lbl_ForceRTV.AutoSize = true;
            this.lbl_ForceRTV.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_ForceRTV.Location = new System.Drawing.Point(39, 156);
            this.lbl_ForceRTV.Name = "lbl_ForceRTV";
            this.lbl_ForceRTV.Size = new System.Drawing.Size(144, 15);
            this.lbl_ForceRTV.TabIndex = 17;
            this.lbl_ForceRTV.Text = "Force Render Target Views";
            // 
            // group_Settings
            // 
            this.group_Settings.Controls.Add(this.check_Discord);
            this.group_Settings.Controls.Add(this.check_Fullscreen);
            this.group_Settings.Controls.Add(this.check_Debug);
            this.group_Settings.Controls.Add(this.check_Gamma);
            this.group_Settings.Controls.Add(this.check_ProtectZero);
            this.group_Settings.Controls.Add(this.check_VSync);
            this.group_Settings.Controls.Add(this.check_2xRes);
            this.group_Settings.Controls.Add(this.check_RTV);
            this.group_Settings.ForeColor = System.Drawing.SystemColors.Control;
            this.group_Settings.Location = new System.Drawing.Point(4, 128);
            this.group_Settings.Name = "group_Settings";
            this.group_Settings.Size = new System.Drawing.Size(522, 352);
            this.group_Settings.TabIndex = 10;
            this.group_Settings.TabStop = false;
            this.group_Settings.Text = "Settings";
            // 
            // check_Discord
            // 
            this.check_Discord.AutoSize = true;
            this.check_Discord.ForeColor = System.Drawing.SystemColors.Control;
            this.check_Discord.Location = new System.Drawing.Point(17, 179);
            this.check_Discord.Name = "check_Discord";
            this.check_Discord.Size = new System.Drawing.Size(15, 14);
            this.check_Discord.TabIndex = 16;
            this.check_Discord.UseVisualStyleBackColor = true;
            // 
            // check_Fullscreen
            // 
            this.check_Fullscreen.AutoSize = true;
            this.check_Fullscreen.ForeColor = System.Drawing.SystemColors.Control;
            this.check_Fullscreen.Location = new System.Drawing.Point(17, 154);
            this.check_Fullscreen.Name = "check_Fullscreen";
            this.check_Fullscreen.Size = new System.Drawing.Size(15, 14);
            this.check_Fullscreen.TabIndex = 15;
            this.check_Fullscreen.UseVisualStyleBackColor = true;
            // 
            // check_Debug
            // 
            this.check_Debug.AutoSize = true;
            this.check_Debug.ForeColor = System.Drawing.SystemColors.Control;
            this.check_Debug.Location = new System.Drawing.Point(17, 204);
            this.check_Debug.Name = "check_Debug";
            this.check_Debug.Size = new System.Drawing.Size(15, 14);
            this.check_Debug.TabIndex = 14;
            this.check_Debug.UseVisualStyleBackColor = true;
            // 
            // check_Gamma
            // 
            this.check_Gamma.AutoSize = true;
            this.check_Gamma.ForeColor = System.Drawing.SystemColors.Control;
            this.check_Gamma.Location = new System.Drawing.Point(17, 129);
            this.check_Gamma.Name = "check_Gamma";
            this.check_Gamma.Size = new System.Drawing.Size(15, 14);
            this.check_Gamma.TabIndex = 13;
            this.check_Gamma.UseVisualStyleBackColor = true;
            // 
            // check_ProtectZero
            // 
            this.check_ProtectZero.AutoSize = true;
            this.check_ProtectZero.ForeColor = System.Drawing.SystemColors.Control;
            this.check_ProtectZero.Location = new System.Drawing.Point(17, 104);
            this.check_ProtectZero.Name = "check_ProtectZero";
            this.check_ProtectZero.Size = new System.Drawing.Size(15, 14);
            this.check_ProtectZero.TabIndex = 12;
            this.check_ProtectZero.UseVisualStyleBackColor = true;
            // 
            // check_VSync
            // 
            this.check_VSync.AutoSize = true;
            this.check_VSync.ForeColor = System.Drawing.SystemColors.Control;
            this.check_VSync.Location = new System.Drawing.Point(17, 79);
            this.check_VSync.Name = "check_VSync";
            this.check_VSync.Size = new System.Drawing.Size(15, 14);
            this.check_VSync.TabIndex = 11;
            this.check_VSync.UseVisualStyleBackColor = true;
            // 
            // check_2xRes
            // 
            this.check_2xRes.AutoSize = true;
            this.check_2xRes.ForeColor = System.Drawing.SystemColors.Control;
            this.check_2xRes.Location = new System.Drawing.Point(17, 54);
            this.check_2xRes.Name = "check_2xRes";
            this.check_2xRes.Size = new System.Drawing.Size(15, 14);
            this.check_2xRes.TabIndex = 10;
            this.check_2xRes.UseVisualStyleBackColor = true;
            // 
            // check_RTV
            // 
            this.check_RTV.AutoSize = true;
            this.check_RTV.ForeColor = System.Drawing.SystemColors.Control;
            this.check_RTV.Location = new System.Drawing.Point(17, 29);
            this.check_RTV.Name = "check_RTV";
            this.check_RTV.Size = new System.Drawing.Size(15, 14);
            this.check_RTV.TabIndex = 9;
            this.check_RTV.UseVisualStyleBackColor = true;
            // 
            // group_Setup
            // 
            this.group_Setup.Controls.Add(this.combo_Emulator_System);
            this.group_Setup.Controls.Add(this.lbl_Emulator_System);
            this.group_Setup.Controls.Add(this.combo_API);
            this.group_Setup.Controls.Add(this.lbl_API);
            this.group_Setup.Controls.Add(this.btn_EmulatorPath);
            this.group_Setup.Controls.Add(this.text_EmulatorPath);
            this.group_Setup.Controls.Add(this.lbl_EmulatorEXE);
            this.group_Setup.ForeColor = System.Drawing.SystemColors.Control;
            this.group_Setup.Location = new System.Drawing.Point(4, 1);
            this.group_Setup.Name = "group_Setup";
            this.group_Setup.Size = new System.Drawing.Size(522, 121);
            this.group_Setup.TabIndex = 4;
            this.group_Setup.TabStop = false;
            this.group_Setup.Text = "Setup";
            // 
            // combo_Emulator_System
            // 
            this.combo_Emulator_System.BackColor = System.Drawing.SystemColors.Window;
            this.combo_Emulator_System.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_Emulator_System.FormattingEnabled = true;
            this.combo_Emulator_System.Items.AddRange(new object[] {
            "Xbox 360",
            "PlayStation 3"});
            this.combo_Emulator_System.Location = new System.Drawing.Point(97, 53);
            this.combo_Emulator_System.Name = "combo_Emulator_System";
            this.combo_Emulator_System.Size = new System.Drawing.Size(411, 23);
            this.combo_Emulator_System.TabIndex = 11;
            this.combo_Emulator_System.SelectedIndexChanged += new System.EventHandler(this.Combo_Emulator_System_SelectedIndexChanged);
            // 
            // lbl_Emulator_System
            // 
            this.lbl_Emulator_System.AutoSize = true;
            this.lbl_Emulator_System.Location = new System.Drawing.Point(43, 57);
            this.lbl_Emulator_System.Name = "lbl_Emulator_System";
            this.lbl_Emulator_System.Size = new System.Drawing.Size(48, 15);
            this.lbl_Emulator_System.TabIndex = 10;
            this.lbl_Emulator_System.Text = "System:";
            // 
            // combo_API
            // 
            this.combo_API.BackColor = System.Drawing.SystemColors.Window;
            this.combo_API.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_API.FormattingEnabled = true;
            this.combo_API.Items.AddRange(new object[] {
            "Vulkan",
            "DirectX 12"});
            this.combo_API.Location = new System.Drawing.Point(97, 82);
            this.combo_API.Name = "combo_API";
            this.combo_API.Size = new System.Drawing.Size(411, 23);
            this.combo_API.TabIndex = 9;
            this.combo_API.SelectedIndexChanged += new System.EventHandler(this.Combo_API_SelectedIndexChanged);
            // 
            // lbl_API
            // 
            this.lbl_API.AutoSize = true;
            this.lbl_API.Location = new System.Drawing.Point(14, 86);
            this.lbl_API.Name = "lbl_API";
            this.lbl_API.Size = new System.Drawing.Size(77, 15);
            this.lbl_API.TabIndex = 8;
            this.lbl_API.Text = "Graphics API:";
            // 
            // btn_EmulatorPath
            // 
            this.btn_EmulatorPath.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_EmulatorPath.FlatAppearance.BorderSize = 0;
            this.btn_EmulatorPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_EmulatorPath.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_EmulatorPath.Location = new System.Drawing.Point(483, 24);
            this.btn_EmulatorPath.Name = "btn_EmulatorPath";
            this.btn_EmulatorPath.Size = new System.Drawing.Size(25, 23);
            this.btn_EmulatorPath.TabIndex = 4;
            this.btn_EmulatorPath.Text = "...";
            this.btn_EmulatorPath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_EmulatorPath.UseVisualStyleBackColor = false;
            this.btn_EmulatorPath.Click += new System.EventHandler(this.Btn_EmulatorPath_Click);
            // 
            // text_EmulatorPath
            // 
            this.text_EmulatorPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.text_EmulatorPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_EmulatorPath.ForeColor = System.Drawing.SystemColors.Control;
            this.text_EmulatorPath.Location = new System.Drawing.Point(97, 24);
            this.text_EmulatorPath.Name = "text_EmulatorPath";
            this.text_EmulatorPath.Size = new System.Drawing.Size(380, 23);
            this.text_EmulatorPath.TabIndex = 2;
            // 
            // lbl_EmulatorEXE
            // 
            this.lbl_EmulatorEXE.AutoSize = true;
            this.lbl_EmulatorEXE.Location = new System.Drawing.Point(11, 28);
            this.lbl_EmulatorEXE.Name = "lbl_EmulatorEXE";
            this.lbl_EmulatorEXE.Size = new System.Drawing.Size(80, 15);
            this.lbl_EmulatorEXE.TabIndex = 0;
            this.lbl_EmulatorEXE.Text = "Emulator EXE:";
            // 
            // unifytb_Tab_Patches
            // 
            this.unifytb_Tab_Patches.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.unifytb_Tab_Patches.Controls.Add(this.group_Tweaks);
            this.unifytb_Tab_Patches.Controls.Add(this.clb_PatchesList);
            this.unifytb_Tab_Patches.Location = new System.Drawing.Point(4, 20);
            this.unifytb_Tab_Patches.Name = "unifytb_Tab_Patches";
            this.unifytb_Tab_Patches.Size = new System.Drawing.Size(530, 483);
            this.unifytb_Tab_Patches.TabIndex = 2;
            this.unifytb_Tab_Patches.Text = "Patches";
            // 
            // group_Tweaks
            // 
            this.group_Tweaks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.group_Tweaks.Controls.Add(this.btn_ResetCameraHeight);
            this.group_Tweaks.Controls.Add(this.nud_CameraHeight);
            this.group_Tweaks.Controls.Add(this.lbl_CameraHeight);
            this.group_Tweaks.Controls.Add(this.btn_ResetViewportX);
            this.group_Tweaks.Controls.Add(this.btn_ResetReflections);
            this.group_Tweaks.Controls.Add(this.btn_ResetViewportY);
            this.group_Tweaks.Controls.Add(this.btn_ResetCameraDistance);
            this.group_Tweaks.Controls.Add(this.nud_CameraDistance);
            this.group_Tweaks.Controls.Add(this.lbl_CameraDistance);
            this.group_Tweaks.Controls.Add(this.nud_ViewportY);
            this.group_Tweaks.Controls.Add(this.nud_ViewportX);
            this.group_Tweaks.Controls.Add(this.lbl_ViewportY);
            this.group_Tweaks.Controls.Add(this.lbl_ViewportX);
            this.group_Tweaks.Controls.Add(this.lbl_Reflections);
            this.group_Tweaks.Controls.Add(this.combo_Reflections);
            this.group_Tweaks.ForeColor = System.Drawing.SystemColors.Control;
            this.group_Tweaks.Location = new System.Drawing.Point(267, 1);
            this.group_Tweaks.Name = "group_Tweaks";
            this.group_Tweaks.Size = new System.Drawing.Size(259, 479);
            this.group_Tweaks.TabIndex = 2;
            this.group_Tweaks.TabStop = false;
            this.group_Tweaks.Text = "Tweaks";
            // 
            // btn_ResetCameraHeight
            // 
            this.btn_ResetCameraHeight.FlatAppearance.BorderSize = 0;
            this.btn_ResetCameraHeight.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_ResetCameraHeight.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_ResetCameraHeight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ResetCameraHeight.Image = ((System.Drawing.Image)(resources.GetObject("btn_ResetCameraHeight.Image")));
            this.btn_ResetCameraHeight.Location = new System.Drawing.Point(227, 148);
            this.btn_ResetCameraHeight.Name = "btn_ResetCameraHeight";
            this.btn_ResetCameraHeight.Size = new System.Drawing.Size(21, 20);
            this.btn_ResetCameraHeight.TabIndex = 91;
            this.btn_ResetCameraHeight.UseVisualStyleBackColor = true;
            this.btn_ResetCameraHeight.Click += new System.EventHandler(this.Btn_ResetCameraHeight_Click);
            // 
            // nud_CameraHeight
            // 
            this.nud_CameraHeight.Location = new System.Drawing.Point(143, 148);
            this.nud_CameraHeight.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nud_CameraHeight.Name = "nud_CameraHeight";
            this.nud_CameraHeight.Size = new System.Drawing.Size(83, 23);
            this.nud_CameraHeight.TabIndex = 90;
            // 
            // lbl_CameraHeight
            // 
            this.lbl_CameraHeight.AutoSize = true;
            this.lbl_CameraHeight.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CameraHeight.Location = new System.Drawing.Point(141, 130);
            this.lbl_CameraHeight.Name = "lbl_CameraHeight";
            this.lbl_CameraHeight.Size = new System.Drawing.Size(87, 15);
            this.lbl_CameraHeight.TabIndex = 89;
            this.lbl_CameraHeight.Text = "Camera Height";
            // 
            // btn_ResetViewportX
            // 
            this.btn_ResetViewportX.FlatAppearance.BorderSize = 0;
            this.btn_ResetViewportX.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_ResetViewportX.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_ResetViewportX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ResetViewportX.Image = ((System.Drawing.Image)(resources.GetObject("btn_ResetViewportX.Image")));
            this.btn_ResetViewportX.Location = new System.Drawing.Point(99, 95);
            this.btn_ResetViewportX.Name = "btn_ResetViewportX";
            this.btn_ResetViewportX.Size = new System.Drawing.Size(21, 20);
            this.btn_ResetViewportX.TabIndex = 88;
            this.btn_ResetViewportX.UseVisualStyleBackColor = true;
            this.btn_ResetViewportX.Click += new System.EventHandler(this.Btn_ResetViewportX_Click);
            // 
            // btn_ResetReflections
            // 
            this.btn_ResetReflections.FlatAppearance.BorderSize = 0;
            this.btn_ResetReflections.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_ResetReflections.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_ResetReflections.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ResetReflections.Image = ((System.Drawing.Image)(resources.GetObject("btn_ResetReflections.Image")));
            this.btn_ResetReflections.Location = new System.Drawing.Point(227, 43);
            this.btn_ResetReflections.Name = "btn_ResetReflections";
            this.btn_ResetReflections.Size = new System.Drawing.Size(21, 20);
            this.btn_ResetReflections.TabIndex = 87;
            this.btn_ResetReflections.UseVisualStyleBackColor = true;
            this.btn_ResetReflections.Click += new System.EventHandler(this.Btn_ResetReflections_Click);
            // 
            // btn_ResetViewportY
            // 
            this.btn_ResetViewportY.FlatAppearance.BorderSize = 0;
            this.btn_ResetViewportY.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_ResetViewportY.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_ResetViewportY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ResetViewportY.Image = ((System.Drawing.Image)(resources.GetObject("btn_ResetViewportY.Image")));
            this.btn_ResetViewportY.Location = new System.Drawing.Point(227, 95);
            this.btn_ResetViewportY.Name = "btn_ResetViewportY";
            this.btn_ResetViewportY.Size = new System.Drawing.Size(21, 20);
            this.btn_ResetViewportY.TabIndex = 86;
            this.btn_ResetViewportY.UseVisualStyleBackColor = true;
            this.btn_ResetViewportY.Click += new System.EventHandler(this.Btn_ResetViewportY_Click);
            // 
            // btn_ResetCameraDistance
            // 
            this.btn_ResetCameraDistance.FlatAppearance.BorderSize = 0;
            this.btn_ResetCameraDistance.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_ResetCameraDistance.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_ResetCameraDistance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ResetCameraDistance.Image = ((System.Drawing.Image)(resources.GetObject("btn_ResetCameraDistance.Image")));
            this.btn_ResetCameraDistance.Location = new System.Drawing.Point(99, 148);
            this.btn_ResetCameraDistance.Name = "btn_ResetCameraDistance";
            this.btn_ResetCameraDistance.Size = new System.Drawing.Size(21, 20);
            this.btn_ResetCameraDistance.TabIndex = 85;
            this.btn_ResetCameraDistance.UseVisualStyleBackColor = true;
            this.btn_ResetCameraDistance.Click += new System.EventHandler(this.Btn_ResetCameraDistance_Click);
            // 
            // nud_CameraDistance
            // 
            this.nud_CameraDistance.Location = new System.Drawing.Point(15, 148);
            this.nud_CameraDistance.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nud_CameraDistance.Name = "nud_CameraDistance";
            this.nud_CameraDistance.Size = new System.Drawing.Size(83, 23);
            this.nud_CameraDistance.TabIndex = 84;
            this.nud_CameraDistance.Value = new decimal(new int[] {
            650,
            0,
            0,
            0});
            // 
            // lbl_CameraDistance
            // 
            this.lbl_CameraDistance.AutoSize = true;
            this.lbl_CameraDistance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CameraDistance.Location = new System.Drawing.Point(9, 130);
            this.lbl_CameraDistance.Name = "lbl_CameraDistance";
            this.lbl_CameraDistance.Size = new System.Drawing.Size(96, 15);
            this.lbl_CameraDistance.TabIndex = 83;
            this.lbl_CameraDistance.Text = "Camera Distance";
            // 
            // nud_ViewportY
            // 
            this.nud_ViewportY.Location = new System.Drawing.Point(143, 95);
            this.nud_ViewportY.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nud_ViewportY.Name = "nud_ViewportY";
            this.nud_ViewportY.Size = new System.Drawing.Size(83, 23);
            this.nud_ViewportY.TabIndex = 82;
            this.nud_ViewportY.Value = new decimal(new int[] {
            720,
            0,
            0,
            0});
            // 
            // nud_ViewportX
            // 
            this.nud_ViewportX.Location = new System.Drawing.Point(15, 95);
            this.nud_ViewportX.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nud_ViewportX.Name = "nud_ViewportX";
            this.nud_ViewportX.Size = new System.Drawing.Size(83, 23);
            this.nud_ViewportX.TabIndex = 81;
            this.nud_ViewportX.Value = new decimal(new int[] {
            1280,
            0,
            0,
            0});
            // 
            // lbl_ViewportY
            // 
            this.lbl_ViewportY.AutoSize = true;
            this.lbl_ViewportY.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ViewportY.Location = new System.Drawing.Point(140, 77);
            this.lbl_ViewportY.Name = "lbl_ViewportY";
            this.lbl_ViewportY.Size = new System.Drawing.Size(64, 15);
            this.lbl_ViewportY.TabIndex = 80;
            this.lbl_ViewportY.Text = "Viewport Y";
            // 
            // lbl_ViewportX
            // 
            this.lbl_ViewportX.AutoSize = true;
            this.lbl_ViewportX.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ViewportX.Location = new System.Drawing.Point(12, 77);
            this.lbl_ViewportX.Name = "lbl_ViewportX";
            this.lbl_ViewportX.Size = new System.Drawing.Size(64, 15);
            this.lbl_ViewportX.TabIndex = 79;
            this.lbl_ViewportX.Text = "Viewport X";
            // 
            // lbl_Reflections
            // 
            this.lbl_Reflections.AutoSize = true;
            this.lbl_Reflections.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Reflections.Location = new System.Drawing.Point(12, 25);
            this.lbl_Reflections.Name = "lbl_Reflections";
            this.lbl_Reflections.Size = new System.Drawing.Size(65, 15);
            this.lbl_Reflections.TabIndex = 77;
            this.lbl_Reflections.Text = "Reflections";
            // 
            // combo_Reflections
            // 
            this.combo_Reflections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_Reflections.FormattingEnabled = true;
            this.combo_Reflections.Items.AddRange(new object[] {
            "Disabled",
            "Quarter",
            "Half",
            "Full"});
            this.combo_Reflections.Location = new System.Drawing.Point(15, 43);
            this.combo_Reflections.Name = "combo_Reflections";
            this.combo_Reflections.Size = new System.Drawing.Size(211, 23);
            this.combo_Reflections.TabIndex = 78;
            this.combo_Reflections.SelectedIndexChanged += new System.EventHandler(this.Combo_Reflections_SelectedIndexChanged);
            // 
            // clb_PatchesList
            // 
            this.clb_PatchesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clb_PatchesList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.clb_PatchesList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clb_PatchesList.ForeColor = System.Drawing.SystemColors.Control;
            this.clb_PatchesList.FormattingEnabled = true;
            this.clb_PatchesList.Items.AddRange(new object[] {
            "Disable HUD",
            "Disable Shadows",
            "Omega Blur Fix",
            "Unlock Mid-air Momentum",
            "Use Dynamic Bones for Snowboarding",
            "Vulkan API Compatibility"});
            this.clb_PatchesList.Location = new System.Drawing.Point(4, 9);
            this.clb_PatchesList.Name = "clb_PatchesList";
            this.clb_PatchesList.Size = new System.Drawing.Size(257, 470);
            this.clb_PatchesList.TabIndex = 1;
            // 
            // unifytb_Tab_Settings
            // 
            this.unifytb_Tab_Settings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.unifytb_Tab_Settings.Controls.Add(this.group_Options);
            this.unifytb_Tab_Settings.Controls.Add(this.group_FTP);
            this.unifytb_Tab_Settings.Controls.Add(this.group_Directories);
            this.unifytb_Tab_Settings.Location = new System.Drawing.Point(4, 20);
            this.unifytb_Tab_Settings.Name = "unifytb_Tab_Settings";
            this.unifytb_Tab_Settings.Size = new System.Drawing.Size(530, 483);
            this.unifytb_Tab_Settings.TabIndex = 3;
            this.unifytb_Tab_Settings.Text = "Settings";
            // 
            // group_Options
            // 
            this.group_Options.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.group_Options.Controls.Add(this.btn_ReportBug);
            this.group_Options.Controls.Add(this.lbl_GameBanana);
            this.group_Options.Controls.Add(this.check_GameBanana);
            this.group_Options.Controls.Add(this.btn_Update);
            this.group_Options.Controls.Add(this.lbl_ManualInstall);
            this.group_Options.Controls.Add(this.btn_Reset);
            this.group_Options.Controls.Add(this.btn_GitHub);
            this.group_Options.Controls.Add(this.btn_About);
            this.group_Options.Controls.Add(this.btn_ColourPicker_Default);
            this.group_Options.Controls.Add(this.lbl_AccentColour);
            this.group_Options.Controls.Add(this.btn_ColourPicker);
            this.group_Options.Controls.Add(this.check_ManualInstall);
            this.group_Options.Controls.Add(this.btn_Theme);
            this.group_Options.ForeColor = System.Drawing.SystemColors.Control;
            this.group_Options.Location = new System.Drawing.Point(4, 283);
            this.group_Options.Name = "group_Options";
            this.group_Options.Size = new System.Drawing.Size(522, 197);
            this.group_Options.TabIndex = 6;
            this.group_Options.TabStop = false;
            this.group_Options.Text = "Options";
            // 
            // btn_ReportBug
            // 
            this.btn_ReportBug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_ReportBug.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_ReportBug.FlatAppearance.BorderSize = 0;
            this.btn_ReportBug.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ReportBug.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_ReportBug.Location = new System.Drawing.Point(14, 130);
            this.btn_ReportBug.Name = "btn_ReportBug";
            this.btn_ReportBug.Size = new System.Drawing.Size(119, 23);
            this.btn_ReportBug.TabIndex = 94;
            this.btn_ReportBug.Text = "Report a bug";
            this.btn_ReportBug.UseVisualStyleBackColor = false;
            this.btn_ReportBug.Click += new System.EventHandler(this.Btn_ReportBug_Click);
            // 
            // lbl_GameBanana
            // 
            this.lbl_GameBanana.AutoSize = true;
            this.lbl_GameBanana.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_GameBanana.Location = new System.Drawing.Point(32, 49);
            this.lbl_GameBanana.Name = "lbl_GameBanana";
            this.lbl_GameBanana.Size = new System.Drawing.Size(151, 15);
            this.lbl_GameBanana.TabIndex = 93;
            this.lbl_GameBanana.Text = "GameBanana 1-Click Install";
            // 
            // check_GameBanana
            // 
            this.check_GameBanana.AutoSize = true;
            this.check_GameBanana.ForeColor = System.Drawing.SystemColors.Control;
            this.check_GameBanana.Location = new System.Drawing.Point(15, 50);
            this.check_GameBanana.Name = "check_GameBanana";
            this.check_GameBanana.Size = new System.Drawing.Size(15, 14);
            this.check_GameBanana.TabIndex = 92;
            this.check_GameBanana.UseVisualStyleBackColor = true;
            this.check_GameBanana.CheckedChanged += new System.EventHandler(this.Check_GameBanana_CheckedChanged);
            // 
            // btn_Update
            // 
            this.btn_Update.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Update.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Update.FlatAppearance.BorderSize = 0;
            this.btn_Update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Update.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Update.Location = new System.Drawing.Point(139, 130);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(245, 23);
            this.btn_Update.TabIndex = 91;
            this.btn_Update.Text = "Check for Updates";
            this.btn_Update.UseVisualStyleBackColor = false;
            // 
            // lbl_ManualInstall
            // 
            this.lbl_ManualInstall.AutoSize = true;
            this.lbl_ManualInstall.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_ManualInstall.Location = new System.Drawing.Point(32, 24);
            this.lbl_ManualInstall.Name = "lbl_ManualInstall";
            this.lbl_ManualInstall.Size = new System.Drawing.Size(136, 15);
            this.lbl_ManualInstall.TabIndex = 19;
            this.lbl_ManualInstall.Text = "Manual mod installation";
            // 
            // btn_Reset
            // 
            this.btn_Reset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Reset.BackColor = System.Drawing.Color.Tomato;
            this.btn_Reset.FlatAppearance.BorderSize = 0;
            this.btn_Reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Reset.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Reset.Location = new System.Drawing.Point(390, 159);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(119, 23);
            this.btn_Reset.TabIndex = 90;
            this.btn_Reset.Text = "Reset";
            this.btn_Reset.UseVisualStyleBackColor = false;
            this.btn_Reset.Click += new System.EventHandler(this.Btn_Reset_Click);
            // 
            // btn_GitHub
            // 
            this.btn_GitHub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_GitHub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(218)))), ((int)(((byte)(240)))));
            this.btn_GitHub.FlatAppearance.BorderSize = 0;
            this.btn_GitHub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_GitHub.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_GitHub.Location = new System.Drawing.Point(14, 159);
            this.btn_GitHub.Name = "btn_GitHub";
            this.btn_GitHub.Size = new System.Drawing.Size(119, 23);
            this.btn_GitHub.TabIndex = 89;
            this.btn_GitHub.Text = "GitHub";
            this.btn_GitHub.UseVisualStyleBackColor = false;
            this.btn_GitHub.Click += new System.EventHandler(this.Btn_GitHub_Click);
            // 
            // btn_About
            // 
            this.btn_About.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_About.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_About.FlatAppearance.BorderSize = 0;
            this.btn_About.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_About.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_About.Location = new System.Drawing.Point(139, 159);
            this.btn_About.Name = "btn_About";
            this.btn_About.Size = new System.Drawing.Size(245, 23);
            this.btn_About.TabIndex = 50;
            this.btn_About.Text = "About Sonic \'06 Mod Manager";
            this.btn_About.UseVisualStyleBackColor = false;
            this.btn_About.Click += new System.EventHandler(this.Btn_About_Click);
            // 
            // btn_ColourPicker_Default
            // 
            this.btn_ColourPicker_Default.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ColourPicker_Default.FlatAppearance.BorderSize = 0;
            this.btn_ColourPicker_Default.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_ColourPicker_Default.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_ColourPicker_Default.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ColourPicker_Default.Image = ((System.Drawing.Image)(resources.GetObject("btn_ColourPicker_Default.Image")));
            this.btn_ColourPicker_Default.Location = new System.Drawing.Point(492, 21);
            this.btn_ColourPicker_Default.Name = "btn_ColourPicker_Default";
            this.btn_ColourPicker_Default.Size = new System.Drawing.Size(21, 20);
            this.btn_ColourPicker_Default.TabIndex = 88;
            this.btn_ColourPicker_Default.UseVisualStyleBackColor = true;
            this.btn_ColourPicker_Default.Click += new System.EventHandler(this.Btn_ColourPicker_Default_Click);
            // 
            // lbl_AccentColour
            // 
            this.lbl_AccentColour.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_AccentColour.AutoSize = true;
            this.lbl_AccentColour.Location = new System.Drawing.Point(373, 24);
            this.lbl_AccentColour.Name = "lbl_AccentColour";
            this.lbl_AccentColour.Size = new System.Drawing.Size(86, 15);
            this.lbl_AccentColour.TabIndex = 45;
            this.lbl_AccentColour.Text = "Accent Colour:";
            // 
            // btn_ColourPicker
            // 
            this.btn_ColourPicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ColourPicker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_ColourPicker.FlatAppearance.BorderSize = 0;
            this.btn_ColourPicker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ColourPicker.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_ColourPicker.Location = new System.Drawing.Point(463, 20);
            this.btn_ColourPicker.Name = "btn_ColourPicker";
            this.btn_ColourPicker.Size = new System.Drawing.Size(25, 23);
            this.btn_ColourPicker.TabIndex = 44;
            this.btn_ColourPicker.UseVisualStyleBackColor = false;
            this.btn_ColourPicker.Click += new System.EventHandler(this.Btn_ColourPicker_Click);
            // 
            // check_ManualInstall
            // 
            this.check_ManualInstall.AutoSize = true;
            this.check_ManualInstall.ForeColor = System.Drawing.SystemColors.Control;
            this.check_ManualInstall.Location = new System.Drawing.Point(15, 25);
            this.check_ManualInstall.Name = "check_ManualInstall";
            this.check_ManualInstall.Size = new System.Drawing.Size(15, 14);
            this.check_ManualInstall.TabIndex = 9;
            this.check_ManualInstall.UseVisualStyleBackColor = true;
            this.check_ManualInstall.CheckedChanged += new System.EventHandler(this.Check_ManualInstall_CheckedChanged);
            // 
            // btn_Theme
            // 
            this.btn_Theme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Theme.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Theme.FlatAppearance.BorderSize = 0;
            this.btn_Theme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Theme.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Theme.Location = new System.Drawing.Point(390, 130);
            this.btn_Theme.Name = "btn_Theme";
            this.btn_Theme.Size = new System.Drawing.Size(119, 23);
            this.btn_Theme.TabIndex = 43;
            this.btn_Theme.Text = "Theme: None";
            this.btn_Theme.UseVisualStyleBackColor = false;
            this.btn_Theme.Click += new System.EventHandler(this.Btn_Theme_Click);
            // 
            // group_FTP
            // 
            this.group_FTP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.group_FTP.Controls.Add(this.lbl_FTP);
            this.group_FTP.Controls.Add(this.check_FTP);
            this.group_FTP.Controls.Add(this.combo_FTP_System);
            this.group_FTP.Controls.Add(this.text_Password);
            this.group_FTP.Controls.Add(this.lbl_System);
            this.group_FTP.Controls.Add(this.lbl_Password);
            this.group_FTP.Controls.Add(this.text_Username);
            this.group_FTP.Controls.Add(this.text_FTPLocation);
            this.group_FTP.Controls.Add(this.lbl_Username);
            this.group_FTP.Controls.Add(this.lbl_FTPLocation);
            this.group_FTP.ForeColor = System.Drawing.SystemColors.Control;
            this.group_FTP.Location = new System.Drawing.Point(4, 102);
            this.group_FTP.Name = "group_FTP";
            this.group_FTP.Size = new System.Drawing.Size(522, 175);
            this.group_FTP.TabIndex = 6;
            this.group_FTP.TabStop = false;
            this.group_FTP.Text = "File Transfer Protocol";
            // 
            // lbl_FTP
            // 
            this.lbl_FTP.AutoSize = true;
            this.lbl_FTP.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_FTP.Location = new System.Drawing.Point(113, 145);
            this.lbl_FTP.Name = "lbl_FTP";
            this.lbl_FTP.Size = new System.Drawing.Size(189, 15);
            this.lbl_FTP.TabIndex = 18;
            this.lbl_FTP.Text = "Use FTP server for mod installation";
            // 
            // check_FTP
            // 
            this.check_FTP.AutoSize = true;
            this.check_FTP.ForeColor = System.Drawing.SystemColors.Control;
            this.check_FTP.Location = new System.Drawing.Point(97, 146);
            this.check_FTP.Name = "check_FTP";
            this.check_FTP.Size = new System.Drawing.Size(15, 14);
            this.check_FTP.TabIndex = 8;
            this.check_FTP.UseVisualStyleBackColor = true;
            this.check_FTP.CheckedChanged += new System.EventHandler(this.Check_FTP_CheckedChanged);
            // 
            // combo_FTP_System
            // 
            this.combo_FTP_System.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_FTP_System.BackColor = System.Drawing.SystemColors.Window;
            this.combo_FTP_System.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_FTP_System.FormattingEnabled = true;
            this.combo_FTP_System.Items.AddRange(new object[] {
            "Xbox 360",
            "PlayStation 3"});
            this.combo_FTP_System.Location = new System.Drawing.Point(97, 112);
            this.combo_FTP_System.Name = "combo_FTP_System";
            this.combo_FTP_System.Size = new System.Drawing.Size(411, 23);
            this.combo_FTP_System.TabIndex = 7;
            this.combo_FTP_System.SelectedIndexChanged += new System.EventHandler(this.Combo_FTP_System_SelectedIndexChanged);
            // 
            // text_Password
            // 
            this.text_Password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_Password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.text_Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_Password.ForeColor = System.Drawing.SystemColors.Control;
            this.text_Password.Location = new System.Drawing.Point(97, 82);
            this.text_Password.Name = "text_Password";
            this.text_Password.Size = new System.Drawing.Size(411, 23);
            this.text_Password.TabIndex = 6;
            // 
            // lbl_System
            // 
            this.lbl_System.AutoSize = true;
            this.lbl_System.Location = new System.Drawing.Point(43, 116);
            this.lbl_System.Name = "lbl_System";
            this.lbl_System.Size = new System.Drawing.Size(48, 15);
            this.lbl_System.TabIndex = 5;
            this.lbl_System.Text = "System:";
            // 
            // lbl_Password
            // 
            this.lbl_Password.AutoSize = true;
            this.lbl_Password.Location = new System.Drawing.Point(31, 86);
            this.lbl_Password.Name = "lbl_Password";
            this.lbl_Password.Size = new System.Drawing.Size(60, 15);
            this.lbl_Password.TabIndex = 4;
            this.lbl_Password.Text = "Password:";
            // 
            // text_Username
            // 
            this.text_Username.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_Username.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.text_Username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_Username.ForeColor = System.Drawing.SystemColors.Control;
            this.text_Username.Location = new System.Drawing.Point(97, 53);
            this.text_Username.Name = "text_Username";
            this.text_Username.Size = new System.Drawing.Size(411, 23);
            this.text_Username.TabIndex = 3;
            // 
            // text_FTPLocation
            // 
            this.text_FTPLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_FTPLocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.text_FTPLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_FTPLocation.ForeColor = System.Drawing.SystemColors.Control;
            this.text_FTPLocation.Location = new System.Drawing.Point(97, 24);
            this.text_FTPLocation.Name = "text_FTPLocation";
            this.text_FTPLocation.Size = new System.Drawing.Size(411, 23);
            this.text_FTPLocation.TabIndex = 2;
            // 
            // lbl_Username
            // 
            this.lbl_Username.AutoSize = true;
            this.lbl_Username.Location = new System.Drawing.Point(28, 57);
            this.lbl_Username.Name = "lbl_Username";
            this.lbl_Username.Size = new System.Drawing.Size(63, 15);
            this.lbl_Username.TabIndex = 1;
            this.lbl_Username.Text = "Username:";
            // 
            // lbl_FTPLocation
            // 
            this.lbl_FTPLocation.AutoSize = true;
            this.lbl_FTPLocation.Location = new System.Drawing.Point(13, 28);
            this.lbl_FTPLocation.Name = "lbl_FTPLocation";
            this.lbl_FTPLocation.Size = new System.Drawing.Size(78, 15);
            this.lbl_FTPLocation.TabIndex = 0;
            this.lbl_FTPLocation.Text = "FTP Location:";
            // 
            // group_Directories
            // 
            this.group_Directories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.group_Directories.Controls.Add(this.btn_GameFolder);
            this.group_Directories.Controls.Add(this.btn_ModsFolder);
            this.group_Directories.Controls.Add(this.text_GameDirectory);
            this.group_Directories.Controls.Add(this.text_ModsDirectory);
            this.group_Directories.Controls.Add(this.lbl_GameDirectory);
            this.group_Directories.Controls.Add(this.lbl_ModsDirectory);
            this.group_Directories.ForeColor = System.Drawing.SystemColors.Control;
            this.group_Directories.Location = new System.Drawing.Point(4, 1);
            this.group_Directories.Name = "group_Directories";
            this.group_Directories.Size = new System.Drawing.Size(522, 95);
            this.group_Directories.TabIndex = 3;
            this.group_Directories.TabStop = false;
            this.group_Directories.Text = "Directories";
            // 
            // btn_GameFolder
            // 
            this.btn_GameFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_GameFolder.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_GameFolder.FlatAppearance.BorderSize = 0;
            this.btn_GameFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_GameFolder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_GameFolder.Location = new System.Drawing.Point(483, 53);
            this.btn_GameFolder.Name = "btn_GameFolder";
            this.btn_GameFolder.Size = new System.Drawing.Size(25, 23);
            this.btn_GameFolder.TabIndex = 5;
            this.btn_GameFolder.Text = "...";
            this.btn_GameFolder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_GameFolder.UseVisualStyleBackColor = false;
            this.btn_GameFolder.Click += new System.EventHandler(this.Btn_GameFolder_Click);
            // 
            // btn_ModsFolder
            // 
            this.btn_ModsFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ModsFolder.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_ModsFolder.FlatAppearance.BorderSize = 0;
            this.btn_ModsFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ModsFolder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_ModsFolder.Location = new System.Drawing.Point(483, 24);
            this.btn_ModsFolder.Name = "btn_ModsFolder";
            this.btn_ModsFolder.Size = new System.Drawing.Size(25, 23);
            this.btn_ModsFolder.TabIndex = 4;
            this.btn_ModsFolder.Text = "...";
            this.btn_ModsFolder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_ModsFolder.UseVisualStyleBackColor = false;
            this.btn_ModsFolder.Click += new System.EventHandler(this.Btn_ModsFolder_Click);
            // 
            // text_GameDirectory
            // 
            this.text_GameDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_GameDirectory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.text_GameDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_GameDirectory.ForeColor = System.Drawing.SystemColors.Control;
            this.text_GameDirectory.Location = new System.Drawing.Point(110, 53);
            this.text_GameDirectory.Name = "text_GameDirectory";
            this.text_GameDirectory.Size = new System.Drawing.Size(367, 23);
            this.text_GameDirectory.TabIndex = 3;
            // 
            // text_ModsDirectory
            // 
            this.text_ModsDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_ModsDirectory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.text_ModsDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_ModsDirectory.ForeColor = System.Drawing.SystemColors.Control;
            this.text_ModsDirectory.Location = new System.Drawing.Point(110, 24);
            this.text_ModsDirectory.Name = "text_ModsDirectory";
            this.text_ModsDirectory.Size = new System.Drawing.Size(367, 23);
            this.text_ModsDirectory.TabIndex = 2;
            // 
            // lbl_GameDirectory
            // 
            this.lbl_GameDirectory.AutoSize = true;
            this.lbl_GameDirectory.Location = new System.Drawing.Point(12, 57);
            this.lbl_GameDirectory.Name = "lbl_GameDirectory";
            this.lbl_GameDirectory.Size = new System.Drawing.Size(92, 15);
            this.lbl_GameDirectory.TabIndex = 1;
            this.lbl_GameDirectory.Text = "Game Directory:";
            this.lbl_GameDirectory.Click += new System.EventHandler(this.Lbl_GameDirectory_Click);
            // 
            // lbl_ModsDirectory
            // 
            this.lbl_ModsDirectory.AutoSize = true;
            this.lbl_ModsDirectory.Location = new System.Drawing.Point(13, 28);
            this.lbl_ModsDirectory.Name = "lbl_ModsDirectory";
            this.lbl_ModsDirectory.Size = new System.Drawing.Size(91, 15);
            this.lbl_ModsDirectory.TabIndex = 0;
            this.lbl_ModsDirectory.Text = "Mods Directory:";
            this.lbl_ModsDirectory.Click += new System.EventHandler(this.Lbl_ModsDirectory_Click);
            // 
            // ModManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(538, 601);
            this.Controls.Add(this.btn_EditMod);
            this.Controls.Add(this.btn_UninstallMods);
            this.Controls.Add(this.radio_PlayStation3);
            this.Controls.Add(this.radio_Xbox360);
            this.Controls.Add(this.radio_All);
            this.Controls.Add(this.status_Main);
            this.Controls.Add(this.btn_RefreshMods);
            this.Controls.Add(this.btn_CreateNewMod);
            this.Controls.Add(this.btn_ModInfo);
            this.Controls.Add(this.btn_Play);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.unifytb_Main);
            this.Controls.Add(this.btn_SaveAndPlay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(554, 640);
            this.Name = "ModManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sonic \'06 Mod Manager";
            this.Shown += new System.EventHandler(this.ModManager_Shown);
            this.unifytb_Main.ResumeLayout(false);
            this.unifytb_Tab_Mods.ResumeLayout(false);
            this.unifytb_Tab_Emulator.ResumeLayout(false);
            this.unifytb_Tab_Emulator.PerformLayout();
            this.group_Settings.ResumeLayout(false);
            this.group_Settings.PerformLayout();
            this.group_Setup.ResumeLayout(false);
            this.group_Setup.PerformLayout();
            this.unifytb_Tab_Patches.ResumeLayout(false);
            this.group_Tweaks.ResumeLayout(false);
            this.group_Tweaks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_CameraHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_CameraDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ViewportY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ViewportX)).EndInit();
            this.unifytb_Tab_Settings.ResumeLayout(false);
            this.group_Options.ResumeLayout(false);
            this.group_Options.PerformLayout();
            this.group_FTP.ResumeLayout(false);
            this.group_FTP.PerformLayout();
            this.group_Directories.ResumeLayout(false);
            this.group_Directories.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UnifyTabControl.UnifyTabControl unifytb_Main;
        private System.Windows.Forms.TabPage unifytb_Tab_Mods;
        private System.Windows.Forms.TabPage unifytb_Tab_Emulator;
        private System.Windows.Forms.TabPage unifytb_Tab_Patches;
        private System.Windows.Forms.TabPage unifytb_Tab_Settings;
        private System.Windows.Forms.CheckedListBox clb_ModsList;
        private System.Windows.Forms.Button btn_DeselectAll;
        private System.Windows.Forms.Button btn_SelectAll;
        private System.Windows.Forms.Button btn_Priority;
        private System.Windows.Forms.Button btn_DownerPriority;
        private System.Windows.Forms.Button btn_UpperPriority;
        private System.Windows.Forms.Button btn_SaveAndPlay;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Play;
        private System.Windows.Forms.Button btn_RefreshMods;
        private System.Windows.Forms.Button btn_CreateNewMod;
        private System.Windows.Forms.Button btn_ModInfo;
        private System.Windows.Forms.CheckedListBox clb_PatchesList;
        private System.Windows.Forms.StatusStrip status_Main;
        private System.Windows.Forms.ToolStripStatusLabel statuslbl_Status;
        private System.Windows.Forms.GroupBox group_Tweaks;
        private System.Windows.Forms.Button btn_ResetCameraHeight;
        private System.Windows.Forms.NumericUpDown nud_CameraHeight;
        private System.Windows.Forms.Label lbl_CameraHeight;
        private System.Windows.Forms.Button btn_ResetViewportX;
        private System.Windows.Forms.Button btn_ResetReflections;
        private System.Windows.Forms.Button btn_ResetViewportY;
        private System.Windows.Forms.Button btn_ResetCameraDistance;
        private System.Windows.Forms.NumericUpDown nud_CameraDistance;
        private System.Windows.Forms.Label lbl_CameraDistance;
        private System.Windows.Forms.NumericUpDown nud_ViewportY;
        private System.Windows.Forms.NumericUpDown nud_ViewportX;
        private System.Windows.Forms.Label lbl_ViewportY;
        private System.Windows.Forms.Label lbl_ViewportX;
        private System.Windows.Forms.Label lbl_Reflections;
        private System.Windows.Forms.ComboBox combo_Reflections;
        private System.Windows.Forms.GroupBox group_Directories;
        private System.Windows.Forms.TextBox text_ModsDirectory;
        private System.Windows.Forms.Label lbl_GameDirectory;
        private System.Windows.Forms.Label lbl_ModsDirectory;
        private System.Windows.Forms.Button btn_GameFolder;
        private System.Windows.Forms.Button btn_ModsFolder;
        private System.Windows.Forms.TextBox text_GameDirectory;
        private System.Windows.Forms.GroupBox group_FTP;
        private System.Windows.Forms.ComboBox combo_FTP_System;
        private System.Windows.Forms.TextBox text_Password;
        private System.Windows.Forms.Label lbl_System;
        private System.Windows.Forms.Label lbl_Password;
        private System.Windows.Forms.TextBox text_Username;
        private System.Windows.Forms.TextBox text_FTPLocation;
        private System.Windows.Forms.Label lbl_Username;
        private System.Windows.Forms.Label lbl_FTPLocation;
        private System.Windows.Forms.GroupBox group_Options;
        private System.Windows.Forms.CheckBox check_FTP;
        private System.Windows.Forms.Button btn_ColourPicker;
        private System.Windows.Forms.CheckBox check_ManualInstall;
        private System.Windows.Forms.Button btn_Theme;
        private System.Windows.Forms.Label lbl_AccentColour;
        private System.Windows.Forms.Button btn_ColourPicker_Default;
        private System.Windows.Forms.GroupBox group_Setup;
        private System.Windows.Forms.Button btn_EmulatorPath;
        private System.Windows.Forms.TextBox text_EmulatorPath;
        private System.Windows.Forms.Label lbl_EmulatorEXE;
        private System.Windows.Forms.ComboBox combo_API;
        private System.Windows.Forms.Label lbl_API;
        private System.Windows.Forms.Button btn_About;
        private System.Windows.Forms.Button btn_GitHub;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.ComboBox combo_Emulator_System;
        private System.Windows.Forms.Label lbl_Emulator_System;
        private System.Windows.Forms.CheckBox check_Debug;
        private System.Windows.Forms.CheckBox check_Gamma;
        private System.Windows.Forms.CheckBox check_ProtectZero;
        private System.Windows.Forms.CheckBox check_VSync;
        private System.Windows.Forms.CheckBox check_2xRes;
        private System.Windows.Forms.CheckBox check_RTV;
        private System.Windows.Forms.CheckBox check_Discord;
        private System.Windows.Forms.CheckBox check_Fullscreen;
        private System.Windows.Forms.GroupBox group_Settings;
        private System.Windows.Forms.Label lbl_Debug;
        private System.Windows.Forms.Label lbl_Discord;
        private System.Windows.Forms.Label lbl_Fullscreen;
        private System.Windows.Forms.Label lbl_EnableGamma;
        private System.Windows.Forms.Label lbl_ProtectZero;
        private System.Windows.Forms.Label lbl_VSync;
        private System.Windows.Forms.Label lbl_2xResolution;
        private System.Windows.Forms.Label lbl_ForceRTV;
        private System.Windows.Forms.RadioButton radio_All;
        private System.Windows.Forms.RadioButton radio_Xbox360;
        private System.Windows.Forms.RadioButton radio_PlayStation3;
        private System.Windows.Forms.Button btn_UninstallMods;
        private System.Windows.Forms.Button btn_EditMod;
        private System.Windows.Forms.Label lbl_ManualInstall;
        private System.Windows.Forms.Label lbl_FTP;
        private System.Windows.Forms.Label lbl_GameBanana;
        private System.Windows.Forms.CheckBox check_GameBanana;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Label lbl_SettingsOverlay;
        private System.Windows.Forms.Button btn_ReportBug;
    }
}