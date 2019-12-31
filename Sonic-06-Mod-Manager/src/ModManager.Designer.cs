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
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Play = new System.Windows.Forms.Button();
            this.btn_RefreshMods = new System.Windows.Forms.Button();
            this.btn_ModInfo = new System.Windows.Forms.Button();
            this.status_Main = new System.Windows.Forms.StatusStrip();
            this.lbl_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.statuslbl_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.radio_All = new System.Windows.Forms.RadioButton();
            this.radio_Xbox360 = new System.Windows.Forms.RadioButton();
            this.radio_PlayStation3 = new System.Windows.Forms.RadioButton();
            this.lbl_MainStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_SetStatus = new System.Windows.Forms.Label();
            this.sonic06mm_Aldi = new System.Windows.Forms.Button();
            this.split_MainControls = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.split_MainControlsWidthModifier = new System.Windows.Forms.SplitContainer();
            this.split_Mods = new System.Windows.Forms.SplitContainer();
            this.btn_InstallMods = new System.Windows.Forms.Button();
            this.btn_UninstallMods = new System.Windows.Forms.Button();
            this.btn_SaveAndPlayFull = new System.Windows.Forms.Button();
            this.split_ListControls = new System.Windows.Forms.SplitContainer();
            this.btn_CreateNewMod = new System.Windows.Forms.Button();
            this.btn_EditMod = new System.Windows.Forms.Button();
            this.btn_CreateNewModFull = new System.Windows.Forms.Button();
            this.unifytb_Main = new UnifyTabControl.UnifyTabControl();
            this.unifytb_Tab_Mods = new System.Windows.Forms.TabPage();
            this.btn_Priority = new System.Windows.Forms.Button();
            this.btn_DownerPriority = new System.Windows.Forms.Button();
            this.btn_UpperPriority = new System.Windows.Forms.Button();
            this.btn_DeselectAll = new System.Windows.Forms.Button();
            this.btn_SelectAll = new System.Windows.Forms.Button();
            this.pnl_ModBackdrop = new System.Windows.Forms.Panel();
            this.view_ModsList = new System.Windows.Forms.ListView();
            this.column_Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_Version = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_Author = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_System = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_Merge = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_Blank = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.unifytb_Tab_Emulator = new System.Windows.Forms.TabPage();
            this.lbl_SetupOverlay = new System.Windows.Forms.Label();
            this.lbl_SettingsOverlay = new System.Windows.Forms.Label();
            this.lbl_Debug = new System.Windows.Forms.Label();
            this.lbl_Discord = new System.Windows.Forms.Label();
            this.lbl_Fullscreen = new System.Windows.Forms.Label();
            this.lbl_EnableGamma = new System.Windows.Forms.Label();
            this.lbl_ProtectZero = new System.Windows.Forms.Label();
            this.lbl_VSync = new System.Windows.Forms.Label();
            this.lbl_2xResolution = new System.Windows.Forms.Label();
            this.lbl_ForceRTV = new System.Windows.Forms.Label();
            this.lbl_API = new System.Windows.Forms.Label();
            this.group_Settings = new System.Windows.Forms.GroupBox();
            this.check_Discord = new System.Windows.Forms.CheckBox();
            this.check_Fullscreen = new System.Windows.Forms.CheckBox();
            this.combo_API = new System.Windows.Forms.ComboBox();
            this.check_Debug = new System.Windows.Forms.CheckBox();
            this.check_Gamma = new System.Windows.Forms.CheckBox();
            this.check_ProtectZero = new System.Windows.Forms.CheckBox();
            this.check_VSync = new System.Windows.Forms.CheckBox();
            this.check_2xRes = new System.Windows.Forms.CheckBox();
            this.check_RTV = new System.Windows.Forms.CheckBox();
            this.group_Setup = new System.Windows.Forms.GroupBox();
            this.combo_Emulator_System = new System.Windows.Forms.ComboBox();
            this.lbl_Emulator_System = new System.Windows.Forms.Label();
            this.btn_EmulatorPath = new System.Windows.Forms.Button();
            this.text_EmulatorPath = new System.Windows.Forms.TextBox();
            this.lbl_EmulatorEXE = new System.Windows.Forms.Label();
            this.btn_SaveData = new System.Windows.Forms.Button();
            this.text_SaveData = new System.Windows.Forms.TextBox();
            this.lbl_SaveData = new System.Windows.Forms.Label();
            this.unifytb_Tab_Patches = new System.Windows.Forms.TabPage();
            this.split_Patches = new System.Windows.Forms.SplitContainer();
            this.pnl_PatchBackdrop = new System.Windows.Forms.Panel();
            this.clb_PatchesList = new System.Windows.Forms.CheckedListBox();
            this.group_CameraTweaks = new System.Windows.Forms.GroupBox();
            this.lbl_CameraTweaks = new System.Windows.Forms.Label();
            this.combo_CameraType = new System.Windows.Forms.ComboBox();
            this.nud_CameraDistance = new System.Windows.Forms.NumericUpDown();
            this.lbl_CameraDistance = new System.Windows.Forms.Label();
            this.nud_CameraHeight = new System.Windows.Forms.NumericUpDown();
            this.lbl_CameraHeight = new System.Windows.Forms.Label();
            this.help_FieldOfView = new System.Windows.Forms.LinkLabel();
            this.btn_ResetCameraHeight = new System.Windows.Forms.Button();
            this.btn_ResetCameraDistance = new System.Windows.Forms.Button();
            this.btn_ResetFOV = new System.Windows.Forms.Button();
            this.help_CameraHeight = new System.Windows.Forms.LinkLabel();
            this.nud_FieldOfView = new System.Windows.Forms.NumericUpDown();
            this.lbl_CameraType = new System.Windows.Forms.Label();
            this.lbl_FieldOfView = new System.Windows.Forms.Label();
            this.help_CameraDistance = new System.Windows.Forms.LinkLabel();
            this.help_CameraType = new System.Windows.Forms.LinkLabel();
            this.btn_ResetCameraType = new System.Windows.Forms.Button();
            this.group_GraphicsTweaks = new System.Windows.Forms.GroupBox();
            this.help_ForceAA = new System.Windows.Forms.LinkLabel();
            this.help_MSAA = new System.Windows.Forms.LinkLabel();
            this.btn_ResetMSAA = new System.Windows.Forms.Button();
            this.lbl_MSAA = new System.Windows.Forms.Label();
            this.combo_MSAA = new System.Windows.Forms.ComboBox();
            this.help_Reflections = new System.Windows.Forms.LinkLabel();
            this.help_Renderer = new System.Windows.Forms.LinkLabel();
            this.lbl_GraphicsTweaksOverlay = new System.Windows.Forms.Label();
            this.btn_ResetReflections = new System.Windows.Forms.Button();
            this.lbl_Reflections = new System.Windows.Forms.Label();
            this.combo_Reflections = new System.Windows.Forms.ComboBox();
            this.btn_ResetRenderer = new System.Windows.Forms.Button();
            this.lbl_Renderer = new System.Windows.Forms.Label();
            this.combo_Renderer = new System.Windows.Forms.ComboBox();
            this.lbl_ForceAA = new System.Windows.Forms.Label();
            this.check_ForceAA = new System.Windows.Forms.CheckBox();
            this.unifytb_Tab_Settings = new System.Windows.Forms.TabPage();
            this.group_Options = new System.Windows.Forms.GroupBox();
            this.lbl_CancelChristmas = new System.Windows.Forms.Label();
            this.check_CancelChristmas = new System.Windows.Forms.CheckBox();
            this.group_Appearance = new System.Windows.Forms.GroupBox();
            this.lbl_HighContrastText = new System.Windows.Forms.Label();
            this.check_HighContrastText = new System.Windows.Forms.CheckBox();
            this.btn_GridStyle_Default = new System.Windows.Forms.Button();
            this.combo_GridStyle = new System.Windows.Forms.ComboBox();
            this.lbl_GridStyle = new System.Windows.Forms.Label();
            this.btn_ColourPicker = new System.Windows.Forms.Button();
            this.lbl_AccentColour = new System.Windows.Forms.Label();
            this.btn_ColourPicker_Default = new System.Windows.Forms.Button();
            this.lbl_DisableSoftwareUpdater = new System.Windows.Forms.Label();
            this.check_DisableSoftwareUpdater = new System.Windows.Forms.CheckBox();
            this.lbl_SaveRedirect = new System.Windows.Forms.Label();
            this.check_SaveRedirect = new System.Windows.Forms.CheckBox();
            this.lbl_GameBanana = new System.Windows.Forms.Label();
            this.check_GameBanana = new System.Windows.Forms.CheckBox();
            this.lbl_ManualInstall = new System.Windows.Forms.Label();
            this.check_ManualInstall = new System.Windows.Forms.CheckBox();
            this.lbl_ManualPatches = new System.Windows.Forms.Label();
            this.check_ManualPatches = new System.Windows.Forms.CheckBox();
            this.split_Options = new System.Windows.Forms.SplitContainer();
            this.btn_ReportBug = new System.Windows.Forms.Button();
            this.btn_GitHub = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btn_About = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.btn_Theme = new System.Windows.Forms.Button();
            this.group_FTP = new System.Windows.Forms.GroupBox();
            this.lbl_FTP = new System.Windows.Forms.Label();
            this.check_FTP = new System.Windows.Forms.CheckBox();
            this.text_Password = new System.Windows.Forms.TextBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.split_MainControls)).BeginInit();
            this.split_MainControls.Panel1.SuspendLayout();
            this.split_MainControls.Panel2.SuspendLayout();
            this.split_MainControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_MainControlsWidthModifier)).BeginInit();
            this.split_MainControlsWidthModifier.Panel1.SuspendLayout();
            this.split_MainControlsWidthModifier.Panel2.SuspendLayout();
            this.split_MainControlsWidthModifier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_Mods)).BeginInit();
            this.split_Mods.Panel1.SuspendLayout();
            this.split_Mods.Panel2.SuspendLayout();
            this.split_Mods.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_ListControls)).BeginInit();
            this.split_ListControls.Panel1.SuspendLayout();
            this.split_ListControls.Panel2.SuspendLayout();
            this.split_ListControls.SuspendLayout();
            this.unifytb_Main.SuspendLayout();
            this.unifytb_Tab_Mods.SuspendLayout();
            this.pnl_ModBackdrop.SuspendLayout();
            this.unifytb_Tab_Emulator.SuspendLayout();
            this.group_Settings.SuspendLayout();
            this.group_Setup.SuspendLayout();
            this.unifytb_Tab_Patches.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_Patches)).BeginInit();
            this.split_Patches.Panel1.SuspendLayout();
            this.split_Patches.Panel2.SuspendLayout();
            this.split_Patches.SuspendLayout();
            this.pnl_PatchBackdrop.SuspendLayout();
            this.group_CameraTweaks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_CameraDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_CameraHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_FieldOfView)).BeginInit();
            this.group_GraphicsTweaks.SuspendLayout();
            this.unifytb_Tab_Settings.SuspendLayout();
            this.group_Options.SuspendLayout();
            this.group_Appearance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_Options)).BeginInit();
            this.split_Options.Panel1.SuspendLayout();
            this.split_Options.Panel2.SuspendLayout();
            this.split_Options.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.group_FTP.SuspendLayout();
            this.group_Directories.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Save
            // 
            this.btn_Save.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Save.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Save.FlatAppearance.BorderSize = 0;
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_Save.Location = new System.Drawing.Point(9, 10);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(132, 23);
            this.btn_Save.TabIndex = 43;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // btn_Play
            // 
            this.btn_Play.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Play.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Play.FlatAppearance.BorderSize = 0;
            this.btn_Play.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Play.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_Play.Location = new System.Drawing.Point(1, 10);
            this.btn_Play.Name = "btn_Play";
            this.btn_Play.Size = new System.Drawing.Size(133, 23);
            this.btn_Play.TabIndex = 45;
            this.btn_Play.Text = "Play";
            this.btn_Play.UseVisualStyleBackColor = false;
            this.btn_Play.Click += new System.EventHandler(this.Btn_Play_Click);
            // 
            // btn_RefreshMods
            // 
            this.btn_RefreshMods.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_RefreshMods.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_RefreshMods.FlatAppearance.BorderSize = 0;
            this.btn_RefreshMods.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_RefreshMods.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_RefreshMods.Location = new System.Drawing.Point(1, 39);
            this.btn_RefreshMods.Name = "btn_RefreshMods";
            this.btn_RefreshMods.Size = new System.Drawing.Size(133, 23);
            this.btn_RefreshMods.TabIndex = 48;
            this.btn_RefreshMods.Text = "Refresh Mods";
            this.btn_RefreshMods.UseVisualStyleBackColor = false;
            this.btn_RefreshMods.Click += new System.EventHandler(this.Btn_RefreshMods_Click);
            // 
            // btn_ModInfo
            // 
            this.btn_ModInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ModInfo.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_ModInfo.FlatAppearance.BorderSize = 0;
            this.btn_ModInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ModInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_ModInfo.Location = new System.Drawing.Point(9, 39);
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
            this.status_Main.Location = new System.Drawing.Point(0, 594);
            this.status_Main.Name = "status_Main";
            this.status_Main.Size = new System.Drawing.Size(538, 22);
            this.status_Main.SizingGrip = false;
            this.status_Main.TabIndex = 49;
            this.status_Main.Text = "Ready.";
            // 
            // lbl_Status
            // 
            this.lbl_Status.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Size = new System.Drawing.Size(42, 17);
            this.lbl_Status.Text = "Ready.";
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
            this.radio_All.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.radio_Xbox360.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.radio_PlayStation3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            // lbl_MainStatus
            // 
            this.lbl_MainStatus.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_MainStatus.Name = "lbl_MainStatus";
            this.lbl_MainStatus.Size = new System.Drawing.Size(42, 17);
            this.lbl_MainStatus.Text = "Ready.";
            // 
            // lbl_SetStatus
            // 
            this.lbl_SetStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_SetStatus.AutoSize = true;
            this.lbl_SetStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.lbl_SetStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SetStatus.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_SetStatus.Location = new System.Drawing.Point(3, 597);
            this.lbl_SetStatus.Name = "lbl_SetStatus";
            this.lbl_SetStatus.Size = new System.Drawing.Size(42, 15);
            this.lbl_SetStatus.TabIndex = 55;
            this.lbl_SetStatus.Text = "Ready.";
            // 
            // sonic06mm_Aldi
            // 
            this.sonic06mm_Aldi.FlatAppearance.BorderSize = 0;
            this.sonic06mm_Aldi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sonic06mm_Aldi.Location = new System.Drawing.Point(535, -20);
            this.sonic06mm_Aldi.Name = "sonic06mm_Aldi";
            this.sonic06mm_Aldi.Size = new System.Drawing.Size(75, 23);
            this.sonic06mm_Aldi.TabIndex = 56;
            this.sonic06mm_Aldi.UseVisualStyleBackColor = true;
            this.sonic06mm_Aldi.Click += new System.EventHandler(this.Aldi);
            // 
            // split_MainControls
            // 
            this.split_MainControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.split_MainControls.IsSplitterFixed = true;
            this.split_MainControls.Location = new System.Drawing.Point(0, 521);
            this.split_MainControls.Name = "split_MainControls";
            // 
            // split_MainControls.Panel1
            // 
            this.split_MainControls.Panel1.Controls.Add(this.btn_Save);
            this.split_MainControls.Panel1.Controls.Add(this.btn_ModInfo);
            // 
            // split_MainControls.Panel2
            // 
            this.split_MainControls.Panel2.Controls.Add(this.splitContainer3);
            this.split_MainControls.Size = new System.Drawing.Size(538, 73);
            this.split_MainControls.SplitterDistance = 142;
            this.split_MainControls.TabIndex = 57;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.split_MainControlsWidthModifier);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.btn_Play);
            this.splitContainer3.Panel2.Controls.Add(this.btn_RefreshMods);
            this.splitContainer3.Size = new System.Drawing.Size(392, 73);
            this.splitContainer3.SplitterDistance = 246;
            this.splitContainer3.TabIndex = 0;
            // 
            // split_MainControlsWidthModifier
            // 
            this.split_MainControlsWidthModifier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split_MainControlsWidthModifier.IsSplitterFixed = true;
            this.split_MainControlsWidthModifier.Location = new System.Drawing.Point(0, 0);
            this.split_MainControlsWidthModifier.Name = "split_MainControlsWidthModifier";
            this.split_MainControlsWidthModifier.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // split_MainControlsWidthModifier.Panel1
            // 
            this.split_MainControlsWidthModifier.Panel1.Controls.Add(this.split_Mods);
            this.split_MainControlsWidthModifier.Panel1.Controls.Add(this.btn_SaveAndPlayFull);
            // 
            // split_MainControlsWidthModifier.Panel2
            // 
            this.split_MainControlsWidthModifier.Panel2.Controls.Add(this.split_ListControls);
            this.split_MainControlsWidthModifier.Panel2.Controls.Add(this.btn_CreateNewModFull);
            this.split_MainControlsWidthModifier.Size = new System.Drawing.Size(246, 73);
            this.split_MainControlsWidthModifier.SplitterDistance = 34;
            this.split_MainControlsWidthModifier.TabIndex = 0;
            // 
            // split_Mods
            // 
            this.split_Mods.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.split_Mods.IsSplitterFixed = true;
            this.split_Mods.Location = new System.Drawing.Point(0, 0);
            this.split_Mods.Name = "split_Mods";
            // 
            // split_Mods.Panel1
            // 
            this.split_Mods.Panel1.Controls.Add(this.btn_InstallMods);
            // 
            // split_Mods.Panel2
            // 
            this.split_Mods.Panel2.Controls.Add(this.btn_UninstallMods);
            this.split_Mods.Size = new System.Drawing.Size(246, 34);
            this.split_Mods.SplitterDistance = 122;
            this.split_Mods.TabIndex = 0;
            this.split_Mods.Visible = false;
            // 
            // btn_InstallMods
            // 
            this.btn_InstallMods.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_InstallMods.BackColor = System.Drawing.Color.LightGreen;
            this.btn_InstallMods.FlatAppearance.BorderSize = 0;
            this.btn_InstallMods.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_InstallMods.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_InstallMods.Location = new System.Drawing.Point(1, 10);
            this.btn_InstallMods.Name = "btn_InstallMods";
            this.btn_InstallMods.Size = new System.Drawing.Size(120, 23);
            this.btn_InstallMods.TabIndex = 0;
            this.btn_InstallMods.Text = "Install Mods";
            this.btn_InstallMods.UseVisualStyleBackColor = false;
            this.btn_InstallMods.Click += new System.EventHandler(this.Btn_SaveAndPlay_Click);
            // 
            // btn_UninstallMods
            // 
            this.btn_UninstallMods.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_UninstallMods.BackColor = System.Drawing.Color.Tomato;
            this.btn_UninstallMods.FlatAppearance.BorderSize = 0;
            this.btn_UninstallMods.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_UninstallMods.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_UninstallMods.Location = new System.Drawing.Point(1, 10);
            this.btn_UninstallMods.Name = "btn_UninstallMods";
            this.btn_UninstallMods.Size = new System.Drawing.Size(118, 23);
            this.btn_UninstallMods.TabIndex = 2;
            this.btn_UninstallMods.Text = "Uninstall Mods";
            this.btn_UninstallMods.UseVisualStyleBackColor = false;
            this.btn_UninstallMods.Click += new System.EventHandler(this.Btn_UninstallMods_Click);
            // 
            // btn_SaveAndPlayFull
            // 
            this.btn_SaveAndPlayFull.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SaveAndPlayFull.BackColor = System.Drawing.Color.LightGreen;
            this.btn_SaveAndPlayFull.FlatAppearance.BorderSize = 0;
            this.btn_SaveAndPlayFull.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SaveAndPlayFull.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_SaveAndPlayFull.Location = new System.Drawing.Point(1, 10);
            this.btn_SaveAndPlayFull.Name = "btn_SaveAndPlayFull";
            this.btn_SaveAndPlayFull.Size = new System.Drawing.Size(244, 23);
            this.btn_SaveAndPlayFull.TabIndex = 5;
            this.btn_SaveAndPlayFull.Text = "Save and Play";
            this.btn_SaveAndPlayFull.UseVisualStyleBackColor = false;
            this.btn_SaveAndPlayFull.Click += new System.EventHandler(this.Btn_SaveAndPlay_Click);
            // 
            // split_ListControls
            // 
            this.split_ListControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.split_ListControls.IsSplitterFixed = true;
            this.split_ListControls.Location = new System.Drawing.Point(0, 0);
            this.split_ListControls.Name = "split_ListControls";
            // 
            // split_ListControls.Panel1
            // 
            this.split_ListControls.Panel1.Controls.Add(this.btn_CreateNewMod);
            // 
            // split_ListControls.Panel2
            // 
            this.split_ListControls.Panel2.Controls.Add(this.btn_EditMod);
            this.split_ListControls.Size = new System.Drawing.Size(246, 35);
            this.split_ListControls.SplitterDistance = 122;
            this.split_ListControls.TabIndex = 0;
            this.split_ListControls.Visible = false;
            // 
            // btn_CreateNewMod
            // 
            this.btn_CreateNewMod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_CreateNewMod.BackColor = System.Drawing.Color.LightGreen;
            this.btn_CreateNewMod.FlatAppearance.BorderSize = 0;
            this.btn_CreateNewMod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CreateNewMod.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_CreateNewMod.Location = new System.Drawing.Point(1, 1);
            this.btn_CreateNewMod.Name = "btn_CreateNewMod";
            this.btn_CreateNewMod.Size = new System.Drawing.Size(120, 23);
            this.btn_CreateNewMod.TabIndex = 1;
            this.btn_CreateNewMod.Text = "Create New Mod";
            this.btn_CreateNewMod.UseVisualStyleBackColor = false;
            this.btn_CreateNewMod.Click += new System.EventHandler(this.Btn_CreateNewMod_Click);
            // 
            // btn_EditMod
            // 
            this.btn_EditMod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_EditMod.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_EditMod.FlatAppearance.BorderSize = 0;
            this.btn_EditMod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_EditMod.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_EditMod.Location = new System.Drawing.Point(1, 1);
            this.btn_EditMod.Name = "btn_EditMod";
            this.btn_EditMod.Size = new System.Drawing.Size(118, 23);
            this.btn_EditMod.TabIndex = 3;
            this.btn_EditMod.Text = "Edit Mod";
            this.btn_EditMod.UseVisualStyleBackColor = false;
            this.btn_EditMod.Click += new System.EventHandler(this.Btn_EditMod_Click);
            // 
            // btn_CreateNewModFull
            // 
            this.btn_CreateNewModFull.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_CreateNewModFull.BackColor = System.Drawing.Color.LightGreen;
            this.btn_CreateNewModFull.FlatAppearance.BorderSize = 0;
            this.btn_CreateNewModFull.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CreateNewModFull.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_CreateNewModFull.Location = new System.Drawing.Point(1, 1);
            this.btn_CreateNewModFull.Name = "btn_CreateNewModFull";
            this.btn_CreateNewModFull.Size = new System.Drawing.Size(244, 23);
            this.btn_CreateNewModFull.TabIndex = 4;
            this.btn_CreateNewModFull.Text = "Create New Mod";
            this.btn_CreateNewModFull.UseVisualStyleBackColor = false;
            this.btn_CreateNewModFull.Click += new System.EventHandler(this.Btn_CreateNewMod_Click);
            // 
            // unifytb_Main
            // 
            this.unifytb_Main.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.unifytb_Main.AllowDrop = true;
            this.unifytb_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.unifytb_Main.SelectedTextColor = System.Drawing.SystemColors.Control;
            this.unifytb_Main.ShowClosingButton = false;
            this.unifytb_Main.ShowClosingMessage = false;
            this.unifytb_Main.Size = new System.Drawing.Size(538, 522);
            this.unifytb_Main.TabIndex = 0;
            this.unifytb_Main.TextColor = System.Drawing.SystemColors.Control;
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
            this.unifytb_Tab_Mods.Controls.Add(this.pnl_ModBackdrop);
            this.unifytb_Tab_Mods.Location = new System.Drawing.Point(4, 20);
            this.unifytb_Tab_Mods.Name = "unifytb_Tab_Mods";
            this.unifytb_Tab_Mods.Padding = new System.Windows.Forms.Padding(3);
            this.unifytb_Tab_Mods.Size = new System.Drawing.Size(530, 498);
            this.unifytb_Tab_Mods.TabIndex = 0;
            this.unifytb_Tab_Mods.Text = "Mods";
            // 
            // btn_Priority
            // 
            this.btn_Priority.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Priority.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Priority.FlatAppearance.BorderSize = 0;
            this.btn_Priority.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Priority.Location = new System.Drawing.Point(348, 471);
            this.btn_Priority.Name = "btn_Priority";
            this.btn_Priority.Size = new System.Drawing.Size(178, 23);
            this.btn_Priority.TabIndex = 42;
            this.btn_Priority.Text = "Priority: Top to Bottom";
            this.btn_Priority.UseVisualStyleBackColor = false;
            this.btn_Priority.Click += new System.EventHandler(this.Btn_Priority_Click);
            // 
            // btn_DownerPriority
            // 
            this.btn_DownerPriority.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_DownerPriority.BackColor = System.Drawing.Color.White;
            this.btn_DownerPriority.Enabled = false;
            this.btn_DownerPriority.FlatAppearance.BorderSize = 0;
            this.btn_DownerPriority.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DownerPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DownerPriority.Location = new System.Drawing.Point(316, 471);
            this.btn_DownerPriority.Name = "btn_DownerPriority";
            this.btn_DownerPriority.Size = new System.Drawing.Size(26, 23);
            this.btn_DownerPriority.TabIndex = 41;
            this.btn_DownerPriority.Text = "▼";
            this.btn_DownerPriority.UseVisualStyleBackColor = false;
            this.btn_DownerPriority.Click += new System.EventHandler(this.Btn_DownerPriority_Click);
            // 
            // btn_UpperPriority
            // 
            this.btn_UpperPriority.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_UpperPriority.BackColor = System.Drawing.Color.White;
            this.btn_UpperPriority.Enabled = false;
            this.btn_UpperPriority.FlatAppearance.BorderSize = 0;
            this.btn_UpperPriority.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_UpperPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_UpperPriority.Location = new System.Drawing.Point(285, 471);
            this.btn_UpperPriority.Name = "btn_UpperPriority";
            this.btn_UpperPriority.Size = new System.Drawing.Size(26, 23);
            this.btn_UpperPriority.TabIndex = 40;
            this.btn_UpperPriority.Text = "▲";
            this.btn_UpperPriority.UseVisualStyleBackColor = false;
            this.btn_UpperPriority.Click += new System.EventHandler(this.Btn_UpperPriority_Click);
            // 
            // btn_DeselectAll
            // 
            this.btn_DeselectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_DeselectAll.BackColor = System.Drawing.Color.Tomato;
            this.btn_DeselectAll.FlatAppearance.BorderSize = 0;
            this.btn_DeselectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DeselectAll.Location = new System.Drawing.Point(145, 471);
            this.btn_DeselectAll.Name = "btn_DeselectAll";
            this.btn_DeselectAll.Size = new System.Drawing.Size(134, 23);
            this.btn_DeselectAll.TabIndex = 2;
            this.btn_DeselectAll.Text = "Deselect All";
            this.btn_DeselectAll.UseVisualStyleBackColor = false;
            this.btn_DeselectAll.Click += new System.EventHandler(this.Btn_DeselectAll_Click);
            // 
            // btn_SelectAll
            // 
            this.btn_SelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_SelectAll.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_SelectAll.FlatAppearance.BorderSize = 0;
            this.btn_SelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SelectAll.Location = new System.Drawing.Point(5, 471);
            this.btn_SelectAll.Name = "btn_SelectAll";
            this.btn_SelectAll.Size = new System.Drawing.Size(134, 23);
            this.btn_SelectAll.TabIndex = 1;
            this.btn_SelectAll.Text = "Select All";
            this.btn_SelectAll.UseVisualStyleBackColor = false;
            this.btn_SelectAll.Click += new System.EventHandler(this.Btn_SelectAll_Click);
            // 
            // pnl_ModBackdrop
            // 
            this.pnl_ModBackdrop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_ModBackdrop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pnl_ModBackdrop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_ModBackdrop.Controls.Add(this.view_ModsList);
            this.pnl_ModBackdrop.Location = new System.Drawing.Point(4, 9);
            this.pnl_ModBackdrop.Name = "pnl_ModBackdrop";
            this.pnl_ModBackdrop.Size = new System.Drawing.Size(522, 453);
            this.pnl_ModBackdrop.TabIndex = 43;
            // 
            // view_ModsList
            // 
            this.view_ModsList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.view_ModsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.view_ModsList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.view_ModsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.view_ModsList.CheckBoxes = true;
            this.view_ModsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_Title,
            this.column_Version,
            this.column_Author,
            this.column_System,
            this.column_Merge,
            this.column_Blank});
            this.view_ModsList.FullRowSelect = true;
            this.view_ModsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.view_ModsList.HideSelection = false;
            this.view_ModsList.Location = new System.Drawing.Point(0, 0);
            this.view_ModsList.MultiSelect = false;
            this.view_ModsList.Name = "view_ModsList";
            this.view_ModsList.OwnerDraw = true;
            this.view_ModsList.Size = new System.Drawing.Size(520, 468);
            this.view_ModsList.TabIndex = 1;
            this.view_ModsList.UseCompatibleStateImageBehavior = false;
            this.view_ModsList.View = System.Windows.Forms.View.Details;
            this.view_ModsList.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.view_ModsList_DrawColumnHeader);
            this.view_ModsList.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.view_ModsList_DrawItem);
            this.view_ModsList.SelectedIndexChanged += new System.EventHandler(this.view_ModsList_SelectedIndexChanged);
            // 
            // column_Title
            // 
            this.column_Title.Text = "Title";
            this.column_Title.Width = 250;
            // 
            // column_Version
            // 
            this.column_Version.Text = "Version";
            this.column_Version.Width = 52;
            // 
            // column_Author
            // 
            this.column_Author.Text = "Author";
            this.column_Author.Width = 90;
            // 
            // column_System
            // 
            this.column_System.Text = "System";
            this.column_System.Width = 80;
            // 
            // column_Merge
            // 
            this.column_Merge.Text = "Merge";
            this.column_Merge.Width = 48;
            // 
            // column_Blank
            // 
            this.column_Blank.Text = "";
            // 
            // unifytb_Tab_Emulator
            // 
            this.unifytb_Tab_Emulator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.unifytb_Tab_Emulator.Controls.Add(this.lbl_SetupOverlay);
            this.unifytb_Tab_Emulator.Controls.Add(this.lbl_SettingsOverlay);
            this.unifytb_Tab_Emulator.Controls.Add(this.lbl_Debug);
            this.unifytb_Tab_Emulator.Controls.Add(this.lbl_Discord);
            this.unifytb_Tab_Emulator.Controls.Add(this.lbl_Fullscreen);
            this.unifytb_Tab_Emulator.Controls.Add(this.lbl_EnableGamma);
            this.unifytb_Tab_Emulator.Controls.Add(this.lbl_ProtectZero);
            this.unifytb_Tab_Emulator.Controls.Add(this.lbl_VSync);
            this.unifytb_Tab_Emulator.Controls.Add(this.lbl_2xResolution);
            this.unifytb_Tab_Emulator.Controls.Add(this.lbl_ForceRTV);
            this.unifytb_Tab_Emulator.Controls.Add(this.lbl_API);
            this.unifytb_Tab_Emulator.Controls.Add(this.group_Settings);
            this.unifytb_Tab_Emulator.Controls.Add(this.group_Setup);
            this.unifytb_Tab_Emulator.Location = new System.Drawing.Point(4, 20);
            this.unifytb_Tab_Emulator.Name = "unifytb_Tab_Emulator";
            this.unifytb_Tab_Emulator.Padding = new System.Windows.Forms.Padding(3);
            this.unifytb_Tab_Emulator.Size = new System.Drawing.Size(530, 498);
            this.unifytb_Tab_Emulator.TabIndex = 1;
            this.unifytb_Tab_Emulator.Text = "Emulator";
            // 
            // lbl_SetupOverlay
            // 
            this.lbl_SetupOverlay.AutoSize = true;
            this.lbl_SetupOverlay.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_SetupOverlay.Location = new System.Drawing.Point(10, 1);
            this.lbl_SetupOverlay.Name = "lbl_SetupOverlay";
            this.lbl_SetupOverlay.Size = new System.Drawing.Size(37, 15);
            this.lbl_SetupOverlay.TabIndex = 25;
            this.lbl_SetupOverlay.Text = "Setup";
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
            this.lbl_Debug.Location = new System.Drawing.Point(39, 364);
            this.lbl_Debug.Name = "lbl_Debug";
            this.lbl_Debug.Size = new System.Drawing.Size(42, 15);
            this.lbl_Debug.TabIndex = 24;
            this.lbl_Debug.Text = "Debug";
            // 
            // lbl_Discord
            // 
            this.lbl_Discord.AutoSize = true;
            this.lbl_Discord.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_Discord.Location = new System.Drawing.Point(39, 339);
            this.lbl_Discord.Name = "lbl_Discord";
            this.lbl_Discord.Size = new System.Drawing.Size(123, 15);
            this.lbl_Discord.TabIndex = 23;
            this.lbl_Discord.Text = "Discord Rich Presence";
            // 
            // lbl_Fullscreen
            // 
            this.lbl_Fullscreen.AutoSize = true;
            this.lbl_Fullscreen.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_Fullscreen.Location = new System.Drawing.Point(39, 314);
            this.lbl_Fullscreen.Name = "lbl_Fullscreen";
            this.lbl_Fullscreen.Size = new System.Drawing.Size(115, 15);
            this.lbl_Fullscreen.TabIndex = 22;
            this.lbl_Fullscreen.Text = "Launch in Fullscreen";
            // 
            // lbl_EnableGamma
            // 
            this.lbl_EnableGamma.AutoSize = true;
            this.lbl_EnableGamma.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_EnableGamma.Location = new System.Drawing.Point(39, 289);
            this.lbl_EnableGamma.Name = "lbl_EnableGamma";
            this.lbl_EnableGamma.Size = new System.Drawing.Size(87, 15);
            this.lbl_EnableGamma.TabIndex = 21;
            this.lbl_EnableGamma.Text = "Enable Gamma";
            // 
            // lbl_ProtectZero
            // 
            this.lbl_ProtectZero.AutoSize = true;
            this.lbl_ProtectZero.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_ProtectZero.Location = new System.Drawing.Point(39, 264);
            this.lbl_ProtectZero.Name = "lbl_ProtectZero";
            this.lbl_ProtectZero.Size = new System.Drawing.Size(72, 15);
            this.lbl_ProtectZero.TabIndex = 20;
            this.lbl_ProtectZero.Text = "Protect Zero";
            // 
            // lbl_VSync
            // 
            this.lbl_VSync.AutoSize = true;
            this.lbl_VSync.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_VSync.Location = new System.Drawing.Point(39, 239);
            this.lbl_VSync.Name = "lbl_VSync";
            this.lbl_VSync.Size = new System.Drawing.Size(44, 15);
            this.lbl_VSync.TabIndex = 19;
            this.lbl_VSync.Text = "V-Sync";
            // 
            // lbl_2xResolution
            // 
            this.lbl_2xResolution.AutoSize = true;
            this.lbl_2xResolution.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_2xResolution.Location = new System.Drawing.Point(39, 214);
            this.lbl_2xResolution.Name = "lbl_2xResolution";
            this.lbl_2xResolution.Size = new System.Drawing.Size(78, 15);
            this.lbl_2xResolution.TabIndex = 18;
            this.lbl_2xResolution.Text = "2x Resolution";
            // 
            // lbl_ForceRTV
            // 
            this.lbl_ForceRTV.AutoSize = true;
            this.lbl_ForceRTV.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_ForceRTV.Location = new System.Drawing.Point(39, 189);
            this.lbl_ForceRTV.Name = "lbl_ForceRTV";
            this.lbl_ForceRTV.Size = new System.Drawing.Size(144, 15);
            this.lbl_ForceRTV.TabIndex = 17;
            this.lbl_ForceRTV.Text = "Force Render Target Views";
            // 
            // lbl_API
            // 
            this.lbl_API.AutoSize = true;
            this.lbl_API.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_API.Location = new System.Drawing.Point(18, 157);
            this.lbl_API.Name = "lbl_API";
            this.lbl_API.Size = new System.Drawing.Size(77, 15);
            this.lbl_API.TabIndex = 8;
            this.lbl_API.Text = "Graphics API:";
            // 
            // group_Settings
            // 
            this.group_Settings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.group_Settings.Controls.Add(this.check_Discord);
            this.group_Settings.Controls.Add(this.check_Fullscreen);
            this.group_Settings.Controls.Add(this.combo_API);
            this.group_Settings.Controls.Add(this.check_Debug);
            this.group_Settings.Controls.Add(this.check_Gamma);
            this.group_Settings.Controls.Add(this.check_ProtectZero);
            this.group_Settings.Controls.Add(this.check_VSync);
            this.group_Settings.Controls.Add(this.check_2xRes);
            this.group_Settings.Controls.Add(this.check_RTV);
            this.group_Settings.ForeColor = System.Drawing.SystemColors.Control;
            this.group_Settings.Location = new System.Drawing.Point(4, 128);
            this.group_Settings.Name = "group_Settings";
            this.group_Settings.Size = new System.Drawing.Size(522, 367);
            this.group_Settings.TabIndex = 10;
            this.group_Settings.TabStop = false;
            this.group_Settings.Text = "Settings";
            // 
            // check_Discord
            // 
            this.check_Discord.AutoSize = true;
            this.check_Discord.ForeColor = System.Drawing.SystemColors.Control;
            this.check_Discord.Location = new System.Drawing.Point(17, 212);
            this.check_Discord.Name = "check_Discord";
            this.check_Discord.Size = new System.Drawing.Size(15, 14);
            this.check_Discord.TabIndex = 16;
            this.check_Discord.UseVisualStyleBackColor = true;
            // 
            // check_Fullscreen
            // 
            this.check_Fullscreen.AutoSize = true;
            this.check_Fullscreen.ForeColor = System.Drawing.SystemColors.Control;
            this.check_Fullscreen.Location = new System.Drawing.Point(17, 187);
            this.check_Fullscreen.Name = "check_Fullscreen";
            this.check_Fullscreen.Size = new System.Drawing.Size(15, 14);
            this.check_Fullscreen.TabIndex = 15;
            this.check_Fullscreen.UseVisualStyleBackColor = true;
            // 
            // combo_API
            // 
            this.combo_API.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_API.BackColor = System.Drawing.SystemColors.Window;
            this.combo_API.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_API.FormattingEnabled = true;
            this.combo_API.Items.AddRange(new object[] {
            "Vulkan",
            "DirectX 12"});
            this.combo_API.Location = new System.Drawing.Point(97, 25);
            this.combo_API.Name = "combo_API";
            this.combo_API.Size = new System.Drawing.Size(411, 23);
            this.combo_API.TabIndex = 9;
            this.combo_API.SelectedIndexChanged += new System.EventHandler(this.Combo_API_SelectedIndexChanged);
            // 
            // check_Debug
            // 
            this.check_Debug.AutoSize = true;
            this.check_Debug.ForeColor = System.Drawing.SystemColors.Control;
            this.check_Debug.Location = new System.Drawing.Point(17, 237);
            this.check_Debug.Name = "check_Debug";
            this.check_Debug.Size = new System.Drawing.Size(15, 14);
            this.check_Debug.TabIndex = 14;
            this.check_Debug.UseVisualStyleBackColor = true;
            // 
            // check_Gamma
            // 
            this.check_Gamma.AutoSize = true;
            this.check_Gamma.ForeColor = System.Drawing.SystemColors.Control;
            this.check_Gamma.Location = new System.Drawing.Point(17, 162);
            this.check_Gamma.Name = "check_Gamma";
            this.check_Gamma.Size = new System.Drawing.Size(15, 14);
            this.check_Gamma.TabIndex = 13;
            this.check_Gamma.UseVisualStyleBackColor = true;
            // 
            // check_ProtectZero
            // 
            this.check_ProtectZero.AutoSize = true;
            this.check_ProtectZero.ForeColor = System.Drawing.SystemColors.Control;
            this.check_ProtectZero.Location = new System.Drawing.Point(17, 137);
            this.check_ProtectZero.Name = "check_ProtectZero";
            this.check_ProtectZero.Size = new System.Drawing.Size(15, 14);
            this.check_ProtectZero.TabIndex = 12;
            this.check_ProtectZero.UseVisualStyleBackColor = true;
            // 
            // check_VSync
            // 
            this.check_VSync.AutoSize = true;
            this.check_VSync.ForeColor = System.Drawing.SystemColors.Control;
            this.check_VSync.Location = new System.Drawing.Point(17, 112);
            this.check_VSync.Name = "check_VSync";
            this.check_VSync.Size = new System.Drawing.Size(15, 14);
            this.check_VSync.TabIndex = 11;
            this.check_VSync.UseVisualStyleBackColor = true;
            // 
            // check_2xRes
            // 
            this.check_2xRes.AutoSize = true;
            this.check_2xRes.ForeColor = System.Drawing.SystemColors.Control;
            this.check_2xRes.Location = new System.Drawing.Point(17, 87);
            this.check_2xRes.Name = "check_2xRes";
            this.check_2xRes.Size = new System.Drawing.Size(15, 14);
            this.check_2xRes.TabIndex = 10;
            this.check_2xRes.UseVisualStyleBackColor = true;
            // 
            // check_RTV
            // 
            this.check_RTV.AutoSize = true;
            this.check_RTV.ForeColor = System.Drawing.SystemColors.Control;
            this.check_RTV.Location = new System.Drawing.Point(17, 62);
            this.check_RTV.Name = "check_RTV";
            this.check_RTV.Size = new System.Drawing.Size(15, 14);
            this.check_RTV.TabIndex = 9;
            this.check_RTV.UseVisualStyleBackColor = true;
            // 
            // group_Setup
            // 
            this.group_Setup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.group_Setup.Controls.Add(this.combo_Emulator_System);
            this.group_Setup.Controls.Add(this.lbl_Emulator_System);
            this.group_Setup.Controls.Add(this.btn_EmulatorPath);
            this.group_Setup.Controls.Add(this.text_EmulatorPath);
            this.group_Setup.Controls.Add(this.lbl_EmulatorEXE);
            this.group_Setup.Controls.Add(this.btn_SaveData);
            this.group_Setup.Controls.Add(this.text_SaveData);
            this.group_Setup.Controls.Add(this.lbl_SaveData);
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
            this.combo_Emulator_System.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_Emulator_System.BackColor = System.Drawing.SystemColors.Window;
            this.combo_Emulator_System.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_Emulator_System.FormattingEnabled = true;
            this.combo_Emulator_System.Items.AddRange(new object[] {
            "Xbox 360",
            "PlayStation 3"});
            this.combo_Emulator_System.Location = new System.Drawing.Point(97, 82);
            this.combo_Emulator_System.Name = "combo_Emulator_System";
            this.combo_Emulator_System.Size = new System.Drawing.Size(411, 23);
            this.combo_Emulator_System.TabIndex = 11;
            this.combo_Emulator_System.SelectedIndexChanged += new System.EventHandler(this.Combo_Emulator_System_SelectedIndexChanged);
            // 
            // lbl_Emulator_System
            // 
            this.lbl_Emulator_System.AutoSize = true;
            this.lbl_Emulator_System.Location = new System.Drawing.Point(43, 86);
            this.lbl_Emulator_System.Name = "lbl_Emulator_System";
            this.lbl_Emulator_System.Size = new System.Drawing.Size(48, 15);
            this.lbl_Emulator_System.TabIndex = 10;
            this.lbl_Emulator_System.Text = "System:";
            // 
            // btn_EmulatorPath
            // 
            this.btn_EmulatorPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.text_EmulatorPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.lbl_EmulatorEXE.Click += new System.EventHandler(this.Lbl_EmulatorEXE_Click);
            // 
            // btn_SaveData
            // 
            this.btn_SaveData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SaveData.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_SaveData.FlatAppearance.BorderSize = 0;
            this.btn_SaveData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SaveData.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_SaveData.Location = new System.Drawing.Point(483, 53);
            this.btn_SaveData.Name = "btn_SaveData";
            this.btn_SaveData.Size = new System.Drawing.Size(25, 23);
            this.btn_SaveData.TabIndex = 14;
            this.btn_SaveData.Text = "...";
            this.btn_SaveData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_SaveData.UseVisualStyleBackColor = false;
            this.btn_SaveData.Click += new System.EventHandler(this.btn_SaveData_Click);
            // 
            // text_SaveData
            // 
            this.text_SaveData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_SaveData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.text_SaveData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_SaveData.ForeColor = System.Drawing.SystemColors.Control;
            this.text_SaveData.Location = new System.Drawing.Point(97, 53);
            this.text_SaveData.Name = "text_SaveData";
            this.text_SaveData.Size = new System.Drawing.Size(380, 23);
            this.text_SaveData.TabIndex = 13;
            // 
            // lbl_SaveData
            // 
            this.lbl_SaveData.AutoSize = true;
            this.lbl_SaveData.Location = new System.Drawing.Point(30, 57);
            this.lbl_SaveData.Name = "lbl_SaveData";
            this.lbl_SaveData.Size = new System.Drawing.Size(61, 15);
            this.lbl_SaveData.TabIndex = 12;
            this.lbl_SaveData.Text = "Save Data:";
            // 
            // unifytb_Tab_Patches
            // 
            this.unifytb_Tab_Patches.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.unifytb_Tab_Patches.Controls.Add(this.split_Patches);
            this.unifytb_Tab_Patches.Location = new System.Drawing.Point(4, 20);
            this.unifytb_Tab_Patches.Name = "unifytb_Tab_Patches";
            this.unifytb_Tab_Patches.Size = new System.Drawing.Size(530, 498);
            this.unifytb_Tab_Patches.TabIndex = 2;
            this.unifytb_Tab_Patches.Text = "Patches";
            // 
            // split_Patches
            // 
            this.split_Patches.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.split_Patches.IsSplitterFixed = true;
            this.split_Patches.Location = new System.Drawing.Point(2, 3);
            this.split_Patches.Name = "split_Patches";
            // 
            // split_Patches.Panel1
            // 
            this.split_Patches.Panel1.Controls.Add(this.pnl_PatchBackdrop);
            // 
            // split_Patches.Panel2
            // 
            this.split_Patches.Panel2.Controls.Add(this.group_CameraTweaks);
            this.split_Patches.Panel2.Controls.Add(this.group_GraphicsTweaks);
            this.split_Patches.Size = new System.Drawing.Size(530, 495);
            this.split_Patches.SplitterDistance = 262;
            this.split_Patches.TabIndex = 3;
            // 
            // pnl_PatchBackdrop
            // 
            this.pnl_PatchBackdrop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_PatchBackdrop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pnl_PatchBackdrop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_PatchBackdrop.Controls.Add(this.clb_PatchesList);
            this.pnl_PatchBackdrop.Location = new System.Drawing.Point(2, 6);
            this.pnl_PatchBackdrop.Name = "pnl_PatchBackdrop";
            this.pnl_PatchBackdrop.Size = new System.Drawing.Size(259, 484);
            this.pnl_PatchBackdrop.TabIndex = 2;
            // 
            // clb_PatchesList
            // 
            this.clb_PatchesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clb_PatchesList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.clb_PatchesList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clb_PatchesList.ForeColor = System.Drawing.SystemColors.Control;
            this.clb_PatchesList.FormattingEnabled = true;
            this.clb_PatchesList.Items.AddRange(new object[] {
            "Action Gauge Fixes for Sonic",
            "Curved Homing Attack for Sonic",
            "Debug Mode",
            "Disable Bloom",
            "Disable HUD",
            "Disable Intro Logos",
            "Disable Music",
            "Disable Shadows",
            "Omega Blur Fix",
            "Silver Grind Trick Fix",
            "Unlock Mid-air Momentum",
            "Unlock Tails\' Flight Limit",
            "Use Dynamic Bones for Snowboard States",
            "Xbox Live Arcade Radial Blur"});
            this.clb_PatchesList.Location = new System.Drawing.Point(3, 2);
            this.clb_PatchesList.Name = "clb_PatchesList";
            this.clb_PatchesList.Size = new System.Drawing.Size(257, 468);
            this.clb_PatchesList.TabIndex = 1;
            this.clb_PatchesList.SelectedIndexChanged += new System.EventHandler(this.clb_PatchesList_SelectedIndexChanged);
            // 
            // group_CameraTweaks
            // 
            this.group_CameraTweaks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.group_CameraTweaks.Controls.Add(this.lbl_CameraTweaks);
            this.group_CameraTweaks.Controls.Add(this.combo_CameraType);
            this.group_CameraTweaks.Controls.Add(this.nud_CameraDistance);
            this.group_CameraTweaks.Controls.Add(this.lbl_CameraDistance);
            this.group_CameraTweaks.Controls.Add(this.nud_CameraHeight);
            this.group_CameraTweaks.Controls.Add(this.lbl_CameraHeight);
            this.group_CameraTweaks.Controls.Add(this.help_FieldOfView);
            this.group_CameraTweaks.Controls.Add(this.btn_ResetCameraHeight);
            this.group_CameraTweaks.Controls.Add(this.btn_ResetCameraDistance);
            this.group_CameraTweaks.Controls.Add(this.btn_ResetFOV);
            this.group_CameraTweaks.Controls.Add(this.help_CameraHeight);
            this.group_CameraTweaks.Controls.Add(this.nud_FieldOfView);
            this.group_CameraTweaks.Controls.Add(this.lbl_CameraType);
            this.group_CameraTweaks.Controls.Add(this.lbl_FieldOfView);
            this.group_CameraTweaks.Controls.Add(this.help_CameraDistance);
            this.group_CameraTweaks.Controls.Add(this.help_CameraType);
            this.group_CameraTweaks.Controls.Add(this.btn_ResetCameraType);
            this.group_CameraTweaks.ForeColor = System.Drawing.SystemColors.Control;
            this.group_CameraTweaks.Location = new System.Drawing.Point(1, 204);
            this.group_CameraTweaks.Name = "group_CameraTweaks";
            this.group_CameraTweaks.Size = new System.Drawing.Size(257, 229);
            this.group_CameraTweaks.TabIndex = 3;
            this.group_CameraTweaks.TabStop = false;
            this.group_CameraTweaks.Text = "Camera Tweaks";
            // 
            // lbl_CameraTweaks
            // 
            this.lbl_CameraTweaks.AutoSize = true;
            this.lbl_CameraTweaks.Location = new System.Drawing.Point(7, 0);
            this.lbl_CameraTweaks.Name = "lbl_CameraTweaks";
            this.lbl_CameraTweaks.Size = new System.Drawing.Size(88, 15);
            this.lbl_CameraTweaks.TabIndex = 115;
            this.lbl_CameraTweaks.Text = "Camera Tweaks";
            // 
            // combo_CameraType
            // 
            this.combo_CameraType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_CameraType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_CameraType.FormattingEnabled = true;
            this.combo_CameraType.Items.AddRange(new object[] {
            "Retail",
            "Tokyo Game Show (TGS)",
            "Electronic Entertainment Expo (E3)"});
            this.combo_CameraType.Location = new System.Drawing.Point(14, 41);
            this.combo_CameraType.Name = "combo_CameraType";
            this.combo_CameraType.Size = new System.Drawing.Size(209, 23);
            this.combo_CameraType.TabIndex = 94;
            this.combo_CameraType.SelectedIndexChanged += new System.EventHandler(this.Combo_CameraType_SelectedIndexChanged);
            // 
            // nud_CameraDistance
            // 
            this.nud_CameraDistance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nud_CameraDistance.Location = new System.Drawing.Point(14, 90);
            this.nud_CameraDistance.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nud_CameraDistance.Name = "nud_CameraDistance";
            this.nud_CameraDistance.Size = new System.Drawing.Size(209, 23);
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
            this.lbl_CameraDistance.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_CameraDistance.Location = new System.Drawing.Point(11, 72);
            this.lbl_CameraDistance.Name = "lbl_CameraDistance";
            this.lbl_CameraDistance.Size = new System.Drawing.Size(96, 15);
            this.lbl_CameraDistance.TabIndex = 83;
            this.lbl_CameraDistance.Text = "Camera Distance";
            // 
            // nud_CameraHeight
            // 
            this.nud_CameraHeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nud_CameraHeight.DecimalPlaces = 1;
            this.nud_CameraHeight.Location = new System.Drawing.Point(14, 139);
            this.nud_CameraHeight.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nud_CameraHeight.Name = "nud_CameraHeight";
            this.nud_CameraHeight.Size = new System.Drawing.Size(209, 23);
            this.nud_CameraHeight.TabIndex = 103;
            this.nud_CameraHeight.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            // 
            // lbl_CameraHeight
            // 
            this.lbl_CameraHeight.AutoSize = true;
            this.lbl_CameraHeight.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CameraHeight.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_CameraHeight.Location = new System.Drawing.Point(11, 121);
            this.lbl_CameraHeight.Name = "lbl_CameraHeight";
            this.lbl_CameraHeight.Size = new System.Drawing.Size(87, 15);
            this.lbl_CameraHeight.TabIndex = 102;
            this.lbl_CameraHeight.Text = "Camera Height";
            // 
            // help_FieldOfView
            // 
            this.help_FieldOfView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.help_FieldOfView.AutoSize = true;
            this.help_FieldOfView.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.help_FieldOfView.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.help_FieldOfView.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.help_FieldOfView.LinkColor = System.Drawing.SystemColors.ControlDark;
            this.help_FieldOfView.Location = new System.Drawing.Point(210, 170);
            this.help_FieldOfView.Name = "help_FieldOfView";
            this.help_FieldOfView.Size = new System.Drawing.Size(18, 15);
            this.help_FieldOfView.TabIndex = 110;
            this.help_FieldOfView.TabStop = true;
            this.help_FieldOfView.Text = " ? ";
            this.help_FieldOfView.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.help_FieldOfView_LinkClicked);
            // 
            // btn_ResetCameraHeight
            // 
            this.btn_ResetCameraHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ResetCameraHeight.FlatAppearance.BorderSize = 0;
            this.btn_ResetCameraHeight.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_ResetCameraHeight.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_ResetCameraHeight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ResetCameraHeight.Image = ((System.Drawing.Image)(resources.GetObject("btn_ResetCameraHeight.Image")));
            this.btn_ResetCameraHeight.Location = new System.Drawing.Point(225, 140);
            this.btn_ResetCameraHeight.Name = "btn_ResetCameraHeight";
            this.btn_ResetCameraHeight.Size = new System.Drawing.Size(21, 20);
            this.btn_ResetCameraHeight.TabIndex = 104;
            this.btn_ResetCameraHeight.UseVisualStyleBackColor = true;
            this.btn_ResetCameraHeight.Click += new System.EventHandler(this.Btn_ResetCameraHeight_Click);
            // 
            // btn_ResetCameraDistance
            // 
            this.btn_ResetCameraDistance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ResetCameraDistance.FlatAppearance.BorderSize = 0;
            this.btn_ResetCameraDistance.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_ResetCameraDistance.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_ResetCameraDistance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ResetCameraDistance.Image = ((System.Drawing.Image)(resources.GetObject("btn_ResetCameraDistance.Image")));
            this.btn_ResetCameraDistance.Location = new System.Drawing.Point(225, 91);
            this.btn_ResetCameraDistance.Name = "btn_ResetCameraDistance";
            this.btn_ResetCameraDistance.Size = new System.Drawing.Size(21, 20);
            this.btn_ResetCameraDistance.TabIndex = 85;
            this.btn_ResetCameraDistance.UseVisualStyleBackColor = true;
            this.btn_ResetCameraDistance.Click += new System.EventHandler(this.Btn_ResetCameraDistance_Click);
            // 
            // btn_ResetFOV
            // 
            this.btn_ResetFOV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ResetFOV.FlatAppearance.BorderSize = 0;
            this.btn_ResetFOV.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_ResetFOV.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_ResetFOV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ResetFOV.Image = ((System.Drawing.Image)(resources.GetObject("btn_ResetFOV.Image")));
            this.btn_ResetFOV.Location = new System.Drawing.Point(225, 189);
            this.btn_ResetFOV.Name = "btn_ResetFOV";
            this.btn_ResetFOV.Size = new System.Drawing.Size(21, 20);
            this.btn_ResetFOV.TabIndex = 98;
            this.btn_ResetFOV.UseVisualStyleBackColor = true;
            this.btn_ResetFOV.Click += new System.EventHandler(this.Btn_ResetFOV_Click);
            // 
            // help_CameraHeight
            // 
            this.help_CameraHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.help_CameraHeight.AutoSize = true;
            this.help_CameraHeight.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.help_CameraHeight.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.help_CameraHeight.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.help_CameraHeight.LinkColor = System.Drawing.SystemColors.ControlDark;
            this.help_CameraHeight.Location = new System.Drawing.Point(210, 121);
            this.help_CameraHeight.Name = "help_CameraHeight";
            this.help_CameraHeight.Size = new System.Drawing.Size(18, 15);
            this.help_CameraHeight.TabIndex = 109;
            this.help_CameraHeight.TabStop = true;
            this.help_CameraHeight.Text = " ? ";
            this.help_CameraHeight.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.help_CameraHeight_LinkClicked);
            // 
            // nud_FieldOfView
            // 
            this.nud_FieldOfView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nud_FieldOfView.Location = new System.Drawing.Point(14, 188);
            this.nud_FieldOfView.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_FieldOfView.Name = "nud_FieldOfView";
            this.nud_FieldOfView.Size = new System.Drawing.Size(209, 23);
            this.nud_FieldOfView.TabIndex = 97;
            this.nud_FieldOfView.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.nud_FieldOfView.ValueChanged += new System.EventHandler(this.Nud_FieldOfView_ValueChanged);
            // 
            // lbl_CameraType
            // 
            this.lbl_CameraType.AutoSize = true;
            this.lbl_CameraType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CameraType.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_CameraType.Location = new System.Drawing.Point(11, 23);
            this.lbl_CameraType.Name = "lbl_CameraType";
            this.lbl_CameraType.Size = new System.Drawing.Size(75, 15);
            this.lbl_CameraType.TabIndex = 93;
            this.lbl_CameraType.Text = "Camera Type";
            // 
            // lbl_FieldOfView
            // 
            this.lbl_FieldOfView.AutoSize = true;
            this.lbl_FieldOfView.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_FieldOfView.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_FieldOfView.Location = new System.Drawing.Point(11, 170);
            this.lbl_FieldOfView.Name = "lbl_FieldOfView";
            this.lbl_FieldOfView.Size = new System.Drawing.Size(74, 15);
            this.lbl_FieldOfView.TabIndex = 96;
            this.lbl_FieldOfView.Text = "Field of View";
            // 
            // help_CameraDistance
            // 
            this.help_CameraDistance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.help_CameraDistance.AutoSize = true;
            this.help_CameraDistance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.help_CameraDistance.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.help_CameraDistance.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.help_CameraDistance.LinkColor = System.Drawing.SystemColors.ControlDark;
            this.help_CameraDistance.Location = new System.Drawing.Point(210, 72);
            this.help_CameraDistance.Name = "help_CameraDistance";
            this.help_CameraDistance.Size = new System.Drawing.Size(18, 15);
            this.help_CameraDistance.TabIndex = 108;
            this.help_CameraDistance.TabStop = true;
            this.help_CameraDistance.Text = " ? ";
            this.help_CameraDistance.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.help_CameraDistance_LinkClicked);
            // 
            // help_CameraType
            // 
            this.help_CameraType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.help_CameraType.AutoSize = true;
            this.help_CameraType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.help_CameraType.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.help_CameraType.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.help_CameraType.LinkColor = System.Drawing.SystemColors.ControlDark;
            this.help_CameraType.Location = new System.Drawing.Point(210, 23);
            this.help_CameraType.Name = "help_CameraType";
            this.help_CameraType.Size = new System.Drawing.Size(18, 15);
            this.help_CameraType.TabIndex = 107;
            this.help_CameraType.TabStop = true;
            this.help_CameraType.Text = " ? ";
            this.help_CameraType.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Help_CameraType_LinkClicked);
            // 
            // btn_ResetCameraType
            // 
            this.btn_ResetCameraType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ResetCameraType.FlatAppearance.BorderSize = 0;
            this.btn_ResetCameraType.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_ResetCameraType.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_ResetCameraType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ResetCameraType.Image = ((System.Drawing.Image)(resources.GetObject("btn_ResetCameraType.Image")));
            this.btn_ResetCameraType.Location = new System.Drawing.Point(225, 42);
            this.btn_ResetCameraType.Name = "btn_ResetCameraType";
            this.btn_ResetCameraType.Size = new System.Drawing.Size(21, 20);
            this.btn_ResetCameraType.TabIndex = 95;
            this.btn_ResetCameraType.UseVisualStyleBackColor = true;
            this.btn_ResetCameraType.Click += new System.EventHandler(this.Btn_ResetCameraType_Click);
            // 
            // group_GraphicsTweaks
            // 
            this.group_GraphicsTweaks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.group_GraphicsTweaks.Controls.Add(this.help_ForceAA);
            this.group_GraphicsTweaks.Controls.Add(this.help_MSAA);
            this.group_GraphicsTweaks.Controls.Add(this.btn_ResetMSAA);
            this.group_GraphicsTweaks.Controls.Add(this.lbl_MSAA);
            this.group_GraphicsTweaks.Controls.Add(this.combo_MSAA);
            this.group_GraphicsTweaks.Controls.Add(this.help_Reflections);
            this.group_GraphicsTweaks.Controls.Add(this.help_Renderer);
            this.group_GraphicsTweaks.Controls.Add(this.lbl_GraphicsTweaksOverlay);
            this.group_GraphicsTweaks.Controls.Add(this.btn_ResetReflections);
            this.group_GraphicsTweaks.Controls.Add(this.lbl_Reflections);
            this.group_GraphicsTweaks.Controls.Add(this.combo_Reflections);
            this.group_GraphicsTweaks.Controls.Add(this.btn_ResetRenderer);
            this.group_GraphicsTweaks.Controls.Add(this.lbl_Renderer);
            this.group_GraphicsTweaks.Controls.Add(this.combo_Renderer);
            this.group_GraphicsTweaks.Controls.Add(this.lbl_ForceAA);
            this.group_GraphicsTweaks.Controls.Add(this.check_ForceAA);
            this.group_GraphicsTweaks.ForeColor = System.Drawing.SystemColors.Control;
            this.group_GraphicsTweaks.Location = new System.Drawing.Point(1, -2);
            this.group_GraphicsTweaks.Name = "group_GraphicsTweaks";
            this.group_GraphicsTweaks.Size = new System.Drawing.Size(257, 205);
            this.group_GraphicsTweaks.TabIndex = 2;
            this.group_GraphicsTweaks.TabStop = false;
            this.group_GraphicsTweaks.Text = "Graphics Tweaks";
            // 
            // help_ForceAA
            // 
            this.help_ForceAA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.help_ForceAA.AutoSize = true;
            this.help_ForceAA.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.help_ForceAA.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.help_ForceAA.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.help_ForceAA.LinkColor = System.Drawing.SystemColors.ControlDark;
            this.help_ForceAA.Location = new System.Drawing.Point(210, 175);
            this.help_ForceAA.Name = "help_ForceAA";
            this.help_ForceAA.Size = new System.Drawing.Size(18, 15);
            this.help_ForceAA.TabIndex = 118;
            this.help_ForceAA.TabStop = true;
            this.help_ForceAA.Text = " ? ";
            this.help_ForceAA.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.help_ForceAA_LinkClicked);
            // 
            // help_MSAA
            // 
            this.help_MSAA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.help_MSAA.AutoSize = true;
            this.help_MSAA.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.help_MSAA.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.help_MSAA.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.help_MSAA.LinkColor = System.Drawing.SystemColors.ControlDark;
            this.help_MSAA.Location = new System.Drawing.Point(210, 122);
            this.help_MSAA.Name = "help_MSAA";
            this.help_MSAA.Size = new System.Drawing.Size(18, 15);
            this.help_MSAA.TabIndex = 114;
            this.help_MSAA.TabStop = true;
            this.help_MSAA.Text = " ? ";
            this.help_MSAA.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.help_MSAA_LinkClicked);
            // 
            // btn_ResetMSAA
            // 
            this.btn_ResetMSAA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ResetMSAA.FlatAppearance.BorderSize = 0;
            this.btn_ResetMSAA.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_ResetMSAA.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_ResetMSAA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ResetMSAA.Image = ((System.Drawing.Image)(resources.GetObject("btn_ResetMSAA.Image")));
            this.btn_ResetMSAA.Location = new System.Drawing.Point(225, 141);
            this.btn_ResetMSAA.Name = "btn_ResetMSAA";
            this.btn_ResetMSAA.Size = new System.Drawing.Size(21, 20);
            this.btn_ResetMSAA.TabIndex = 113;
            this.btn_ResetMSAA.UseVisualStyleBackColor = true;
            this.btn_ResetMSAA.Click += new System.EventHandler(this.btn_ResetMSAA_Click);
            // 
            // lbl_MSAA
            // 
            this.lbl_MSAA.AutoSize = true;
            this.lbl_MSAA.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MSAA.Location = new System.Drawing.Point(11, 122);
            this.lbl_MSAA.Name = "lbl_MSAA";
            this.lbl_MSAA.Size = new System.Drawing.Size(76, 15);
            this.lbl_MSAA.TabIndex = 111;
            this.lbl_MSAA.Text = "Anti-Aliasing";
            // 
            // combo_MSAA
            // 
            this.combo_MSAA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_MSAA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_MSAA.FormattingEnabled = true;
            this.combo_MSAA.Items.AddRange(new object[] {
            "Disabled",
            "2x MSAA",
            "4x MSAA"});
            this.combo_MSAA.Location = new System.Drawing.Point(14, 140);
            this.combo_MSAA.Name = "combo_MSAA";
            this.combo_MSAA.Size = new System.Drawing.Size(209, 23);
            this.combo_MSAA.TabIndex = 112;
            this.combo_MSAA.SelectedIndexChanged += new System.EventHandler(this.combo_MSAA_SelectedIndexChanged);
            // 
            // help_Reflections
            // 
            this.help_Reflections.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.help_Reflections.AutoSize = true;
            this.help_Reflections.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.help_Reflections.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.help_Reflections.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.help_Reflections.LinkColor = System.Drawing.SystemColors.ControlDark;
            this.help_Reflections.Location = new System.Drawing.Point(210, 73);
            this.help_Reflections.Name = "help_Reflections";
            this.help_Reflections.Size = new System.Drawing.Size(18, 15);
            this.help_Reflections.TabIndex = 106;
            this.help_Reflections.TabStop = true;
            this.help_Reflections.Text = " ? ";
            this.help_Reflections.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Help_Reflections_LinkClicked);
            // 
            // help_Renderer
            // 
            this.help_Renderer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.help_Renderer.AutoSize = true;
            this.help_Renderer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.help_Renderer.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.help_Renderer.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.help_Renderer.LinkColor = System.Drawing.SystemColors.ControlDark;
            this.help_Renderer.Location = new System.Drawing.Point(210, 24);
            this.help_Renderer.Name = "help_Renderer";
            this.help_Renderer.Size = new System.Drawing.Size(18, 15);
            this.help_Renderer.TabIndex = 105;
            this.help_Renderer.TabStop = true;
            this.help_Renderer.Text = " ? ";
            this.help_Renderer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Help_Renderer_LinkClicked);
            // 
            // lbl_GraphicsTweaksOverlay
            // 
            this.lbl_GraphicsTweaksOverlay.AutoSize = true;
            this.lbl_GraphicsTweaksOverlay.Location = new System.Drawing.Point(7, 0);
            this.lbl_GraphicsTweaksOverlay.Name = "lbl_GraphicsTweaksOverlay";
            this.lbl_GraphicsTweaksOverlay.Size = new System.Drawing.Size(93, 15);
            this.lbl_GraphicsTweaksOverlay.TabIndex = 92;
            this.lbl_GraphicsTweaksOverlay.Text = "Graphics Tweaks";
            // 
            // btn_ResetReflections
            // 
            this.btn_ResetReflections.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ResetReflections.FlatAppearance.BorderSize = 0;
            this.btn_ResetReflections.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_ResetReflections.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_ResetReflections.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ResetReflections.Image = ((System.Drawing.Image)(resources.GetObject("btn_ResetReflections.Image")));
            this.btn_ResetReflections.Location = new System.Drawing.Point(225, 92);
            this.btn_ResetReflections.Name = "btn_ResetReflections";
            this.btn_ResetReflections.Size = new System.Drawing.Size(21, 20);
            this.btn_ResetReflections.TabIndex = 87;
            this.btn_ResetReflections.UseVisualStyleBackColor = true;
            this.btn_ResetReflections.Click += new System.EventHandler(this.Btn_ResetReflections_Click);
            // 
            // lbl_Reflections
            // 
            this.lbl_Reflections.AutoSize = true;
            this.lbl_Reflections.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Reflections.Location = new System.Drawing.Point(11, 73);
            this.lbl_Reflections.Name = "lbl_Reflections";
            this.lbl_Reflections.Size = new System.Drawing.Size(65, 15);
            this.lbl_Reflections.TabIndex = 77;
            this.lbl_Reflections.Text = "Reflections";
            // 
            // combo_Reflections
            // 
            this.combo_Reflections.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_Reflections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_Reflections.FormattingEnabled = true;
            this.combo_Reflections.Items.AddRange(new object[] {
            "Disabled",
            "Quarter",
            "Half",
            "Full"});
            this.combo_Reflections.Location = new System.Drawing.Point(14, 91);
            this.combo_Reflections.Name = "combo_Reflections";
            this.combo_Reflections.Size = new System.Drawing.Size(209, 23);
            this.combo_Reflections.TabIndex = 78;
            this.combo_Reflections.SelectedIndexChanged += new System.EventHandler(this.Combo_Reflections_SelectedIndexChanged);
            // 
            // btn_ResetRenderer
            // 
            this.btn_ResetRenderer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ResetRenderer.FlatAppearance.BorderSize = 0;
            this.btn_ResetRenderer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_ResetRenderer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_ResetRenderer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ResetRenderer.Image = ((System.Drawing.Image)(resources.GetObject("btn_ResetRenderer.Image")));
            this.btn_ResetRenderer.Location = new System.Drawing.Point(225, 43);
            this.btn_ResetRenderer.Name = "btn_ResetRenderer";
            this.btn_ResetRenderer.Size = new System.Drawing.Size(21, 20);
            this.btn_ResetRenderer.TabIndex = 101;
            this.btn_ResetRenderer.UseVisualStyleBackColor = true;
            this.btn_ResetRenderer.Click += new System.EventHandler(this.Btn_ResetRenderer_Click);
            // 
            // lbl_Renderer
            // 
            this.lbl_Renderer.AutoSize = true;
            this.lbl_Renderer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Renderer.Location = new System.Drawing.Point(11, 24);
            this.lbl_Renderer.Name = "lbl_Renderer";
            this.lbl_Renderer.Size = new System.Drawing.Size(54, 15);
            this.lbl_Renderer.TabIndex = 99;
            this.lbl_Renderer.Text = "Renderer";
            // 
            // combo_Renderer
            // 
            this.combo_Renderer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_Renderer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_Renderer.FormattingEnabled = true;
            this.combo_Renderer.Items.AddRange(new object[] {
            "Default",
            "Optimised",
            "Destructive (Vulkan)",
            "Cheap (Not Recommended)"});
            this.combo_Renderer.Location = new System.Drawing.Point(14, 42);
            this.combo_Renderer.Name = "combo_Renderer";
            this.combo_Renderer.Size = new System.Drawing.Size(209, 23);
            this.combo_Renderer.TabIndex = 100;
            this.combo_Renderer.SelectedIndexChanged += new System.EventHandler(this.Combo_Renderer_SelectedIndexChanged);
            // 
            // lbl_ForceAA
            // 
            this.lbl_ForceAA.AutoSize = true;
            this.lbl_ForceAA.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_ForceAA.Location = new System.Drawing.Point(30, 175);
            this.lbl_ForceAA.Name = "lbl_ForceAA";
            this.lbl_ForceAA.Size = new System.Drawing.Size(72, 15);
            this.lbl_ForceAA.TabIndex = 117;
            this.lbl_ForceAA.Text = "Force MSAA";
            // 
            // check_ForceAA
            // 
            this.check_ForceAA.AutoSize = true;
            this.check_ForceAA.ForeColor = System.Drawing.SystemColors.Control;
            this.check_ForceAA.Location = new System.Drawing.Point(14, 176);
            this.check_ForceAA.Name = "check_ForceAA";
            this.check_ForceAA.Size = new System.Drawing.Size(15, 14);
            this.check_ForceAA.TabIndex = 116;
            this.check_ForceAA.UseVisualStyleBackColor = true;
            this.check_ForceAA.CheckedChanged += new System.EventHandler(this.check_ForceAA_CheckedChanged);
            // 
            // unifytb_Tab_Settings
            // 
            this.unifytb_Tab_Settings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.unifytb_Tab_Settings.Controls.Add(this.group_Options);
            this.unifytb_Tab_Settings.Controls.Add(this.group_FTP);
            this.unifytb_Tab_Settings.Controls.Add(this.group_Directories);
            this.unifytb_Tab_Settings.Location = new System.Drawing.Point(4, 20);
            this.unifytb_Tab_Settings.Name = "unifytb_Tab_Settings";
            this.unifytb_Tab_Settings.Size = new System.Drawing.Size(530, 498);
            this.unifytb_Tab_Settings.TabIndex = 3;
            this.unifytb_Tab_Settings.Text = "Settings";
            // 
            // group_Options
            // 
            this.group_Options.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.group_Options.Controls.Add(this.lbl_CancelChristmas);
            this.group_Options.Controls.Add(this.check_CancelChristmas);
            this.group_Options.Controls.Add(this.group_Appearance);
            this.group_Options.Controls.Add(this.lbl_DisableSoftwareUpdater);
            this.group_Options.Controls.Add(this.check_DisableSoftwareUpdater);
            this.group_Options.Controls.Add(this.lbl_SaveRedirect);
            this.group_Options.Controls.Add(this.check_SaveRedirect);
            this.group_Options.Controls.Add(this.lbl_GameBanana);
            this.group_Options.Controls.Add(this.check_GameBanana);
            this.group_Options.Controls.Add(this.lbl_ManualInstall);
            this.group_Options.Controls.Add(this.check_ManualInstall);
            this.group_Options.Controls.Add(this.lbl_ManualPatches);
            this.group_Options.Controls.Add(this.check_ManualPatches);
            this.group_Options.Controls.Add(this.split_Options);
            this.group_Options.ForeColor = System.Drawing.SystemColors.Control;
            this.group_Options.Location = new System.Drawing.Point(4, 256);
            this.group_Options.Name = "group_Options";
            this.group_Options.Size = new System.Drawing.Size(522, 239);
            this.group_Options.TabIndex = 6;
            this.group_Options.TabStop = false;
            this.group_Options.Text = "Options";
            // 
            // lbl_CancelChristmas
            // 
            this.lbl_CancelChristmas.AutoSize = true;
            this.lbl_CancelChristmas.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_CancelChristmas.Location = new System.Drawing.Point(32, 144);
            this.lbl_CancelChristmas.Name = "lbl_CancelChristmas";
            this.lbl_CancelChristmas.Size = new System.Drawing.Size(99, 15);
            this.lbl_CancelChristmas.TabIndex = 105;
            this.lbl_CancelChristmas.Text = "Cancel Christmas";
            this.lbl_CancelChristmas.Visible = false;
            // 
            // check_CancelChristmas
            // 
            this.check_CancelChristmas.AutoSize = true;
            this.check_CancelChristmas.ForeColor = System.Drawing.SystemColors.Control;
            this.check_CancelChristmas.Location = new System.Drawing.Point(15, 145);
            this.check_CancelChristmas.Name = "check_CancelChristmas";
            this.check_CancelChristmas.Size = new System.Drawing.Size(15, 14);
            this.check_CancelChristmas.TabIndex = 104;
            this.check_CancelChristmas.UseVisualStyleBackColor = true;
            this.check_CancelChristmas.Visible = false;
            this.check_CancelChristmas.CheckedChanged += new System.EventHandler(this.check_CancelChristmas_CheckedChanged);
            // 
            // group_Appearance
            // 
            this.group_Appearance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.group_Appearance.Controls.Add(this.lbl_HighContrastText);
            this.group_Appearance.Controls.Add(this.check_HighContrastText);
            this.group_Appearance.Controls.Add(this.btn_GridStyle_Default);
            this.group_Appearance.Controls.Add(this.combo_GridStyle);
            this.group_Appearance.Controls.Add(this.lbl_GridStyle);
            this.group_Appearance.Controls.Add(this.btn_ColourPicker);
            this.group_Appearance.Controls.Add(this.lbl_AccentColour);
            this.group_Appearance.Controls.Add(this.btn_ColourPicker_Default);
            this.group_Appearance.ForeColor = System.Drawing.SystemColors.Control;
            this.group_Appearance.Location = new System.Drawing.Point(261, 16);
            this.group_Appearance.Name = "group_Appearance";
            this.group_Appearance.Size = new System.Drawing.Size(248, 116);
            this.group_Appearance.TabIndex = 103;
            this.group_Appearance.TabStop = false;
            this.group_Appearance.Text = "Appearance";
            // 
            // lbl_HighContrastText
            // 
            this.lbl_HighContrastText.AutoSize = true;
            this.lbl_HighContrastText.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_HighContrastText.Location = new System.Drawing.Point(119, 87);
            this.lbl_HighContrastText.Name = "lbl_HighContrastText";
            this.lbl_HighContrastText.Size = new System.Drawing.Size(105, 15);
            this.lbl_HighContrastText.TabIndex = 107;
            this.lbl_HighContrastText.Text = "High Contrast Text";
            // 
            // check_HighContrastText
            // 
            this.check_HighContrastText.AutoSize = true;
            this.check_HighContrastText.ForeColor = System.Drawing.SystemColors.Control;
            this.check_HighContrastText.Location = new System.Drawing.Point(102, 88);
            this.check_HighContrastText.Name = "check_HighContrastText";
            this.check_HighContrastText.Size = new System.Drawing.Size(15, 14);
            this.check_HighContrastText.TabIndex = 106;
            this.check_HighContrastText.UseVisualStyleBackColor = true;
            this.check_HighContrastText.CheckedChanged += new System.EventHandler(this.check_HighContrastText_CheckedChanged);
            // 
            // btn_GridStyle_Default
            // 
            this.btn_GridStyle_Default.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_GridStyle_Default.FlatAppearance.BorderSize = 0;
            this.btn_GridStyle_Default.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_GridStyle_Default.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_GridStyle_Default.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_GridStyle_Default.Image = ((System.Drawing.Image)(resources.GetObject("btn_GridStyle_Default.Image")));
            this.btn_GridStyle_Default.Location = new System.Drawing.Point(216, 54);
            this.btn_GridStyle_Default.Name = "btn_GridStyle_Default";
            this.btn_GridStyle_Default.Size = new System.Drawing.Size(21, 20);
            this.btn_GridStyle_Default.TabIndex = 102;
            this.btn_GridStyle_Default.UseVisualStyleBackColor = true;
            this.btn_GridStyle_Default.Click += new System.EventHandler(this.btn_GridStyle_Default_Click);
            // 
            // combo_GridStyle
            // 
            this.combo_GridStyle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_GridStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_GridStyle.FormattingEnabled = true;
            this.combo_GridStyle.Items.AddRange(new object[] {
            "Traditional",
            "Original"});
            this.combo_GridStyle.Location = new System.Drawing.Point(102, 52);
            this.combo_GridStyle.Name = "combo_GridStyle";
            this.combo_GridStyle.Size = new System.Drawing.Size(112, 23);
            this.combo_GridStyle.TabIndex = 101;
            this.combo_GridStyle.SelectedIndexChanged += new System.EventHandler(this.combo_GridStyle_SelectedIndexChanged);
            // 
            // lbl_GridStyle
            // 
            this.lbl_GridStyle.AutoSize = true;
            this.lbl_GridStyle.Location = new System.Drawing.Point(38, 56);
            this.lbl_GridStyle.Name = "lbl_GridStyle";
            this.lbl_GridStyle.Size = new System.Drawing.Size(60, 15);
            this.lbl_GridStyle.TabIndex = 89;
            this.lbl_GridStyle.Text = "Grid Style:";
            // 
            // btn_ColourPicker
            // 
            this.btn_ColourPicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ColourPicker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_ColourPicker.FlatAppearance.BorderSize = 0;
            this.btn_ColourPicker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ColourPicker.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_ColourPicker.Location = new System.Drawing.Point(102, 23);
            this.btn_ColourPicker.Name = "btn_ColourPicker";
            this.btn_ColourPicker.Size = new System.Drawing.Size(112, 23);
            this.btn_ColourPicker.TabIndex = 44;
            this.btn_ColourPicker.Text = "#BA0000";
            this.btn_ColourPicker.UseVisualStyleBackColor = false;
            this.btn_ColourPicker.Click += new System.EventHandler(this.Btn_ColourPicker_Click);
            // 
            // lbl_AccentColour
            // 
            this.lbl_AccentColour.AutoSize = true;
            this.lbl_AccentColour.Location = new System.Drawing.Point(12, 27);
            this.lbl_AccentColour.Name = "lbl_AccentColour";
            this.lbl_AccentColour.Size = new System.Drawing.Size(86, 15);
            this.lbl_AccentColour.TabIndex = 45;
            this.lbl_AccentColour.Text = "Accent Colour:";
            // 
            // btn_ColourPicker_Default
            // 
            this.btn_ColourPicker_Default.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ColourPicker_Default.FlatAppearance.BorderSize = 0;
            this.btn_ColourPicker_Default.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_ColourPicker_Default.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_ColourPicker_Default.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ColourPicker_Default.Image = ((System.Drawing.Image)(resources.GetObject("btn_ColourPicker_Default.Image")));
            this.btn_ColourPicker_Default.Location = new System.Drawing.Point(216, 25);
            this.btn_ColourPicker_Default.Name = "btn_ColourPicker_Default";
            this.btn_ColourPicker_Default.Size = new System.Drawing.Size(21, 20);
            this.btn_ColourPicker_Default.TabIndex = 88;
            this.btn_ColourPicker_Default.UseVisualStyleBackColor = true;
            this.btn_ColourPicker_Default.Click += new System.EventHandler(this.Btn_ColourPicker_Default_Click);
            // 
            // lbl_DisableSoftwareUpdater
            // 
            this.lbl_DisableSoftwareUpdater.AutoSize = true;
            this.lbl_DisableSoftwareUpdater.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_DisableSoftwareUpdater.Location = new System.Drawing.Point(32, 120);
            this.lbl_DisableSoftwareUpdater.Name = "lbl_DisableSoftwareUpdater";
            this.lbl_DisableSoftwareUpdater.Size = new System.Drawing.Size(137, 15);
            this.lbl_DisableSoftwareUpdater.TabIndex = 101;
            this.lbl_DisableSoftwareUpdater.Text = "Disable software updater";
            // 
            // check_DisableSoftwareUpdater
            // 
            this.check_DisableSoftwareUpdater.AutoSize = true;
            this.check_DisableSoftwareUpdater.ForeColor = System.Drawing.SystemColors.Control;
            this.check_DisableSoftwareUpdater.Location = new System.Drawing.Point(15, 121);
            this.check_DisableSoftwareUpdater.Name = "check_DisableSoftwareUpdater";
            this.check_DisableSoftwareUpdater.Size = new System.Drawing.Size(15, 14);
            this.check_DisableSoftwareUpdater.TabIndex = 100;
            this.check_DisableSoftwareUpdater.UseVisualStyleBackColor = true;
            this.check_DisableSoftwareUpdater.CheckedChanged += new System.EventHandler(this.Check_DisableSoftwareUpdater_CheckedChanged);
            // 
            // lbl_SaveRedirect
            // 
            this.lbl_SaveRedirect.AutoSize = true;
            this.lbl_SaveRedirect.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_SaveRedirect.Location = new System.Drawing.Point(32, 72);
            this.lbl_SaveRedirect.Name = "lbl_SaveRedirect";
            this.lbl_SaveRedirect.Size = new System.Drawing.Size(110, 15);
            this.lbl_SaveRedirect.TabIndex = 99;
            this.lbl_SaveRedirect.Text = "Save file redirection";
            // 
            // check_SaveRedirect
            // 
            this.check_SaveRedirect.AutoSize = true;
            this.check_SaveRedirect.ForeColor = System.Drawing.SystemColors.Control;
            this.check_SaveRedirect.Location = new System.Drawing.Point(15, 73);
            this.check_SaveRedirect.Name = "check_SaveRedirect";
            this.check_SaveRedirect.Size = new System.Drawing.Size(15, 14);
            this.check_SaveRedirect.TabIndex = 98;
            this.check_SaveRedirect.UseVisualStyleBackColor = true;
            this.check_SaveRedirect.CheckedChanged += new System.EventHandler(this.Check_SaveRedirect_CheckedChanged);
            // 
            // lbl_GameBanana
            // 
            this.lbl_GameBanana.AutoSize = true;
            this.lbl_GameBanana.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_GameBanana.Location = new System.Drawing.Point(32, 96);
            this.lbl_GameBanana.Name = "lbl_GameBanana";
            this.lbl_GameBanana.Size = new System.Drawing.Size(151, 15);
            this.lbl_GameBanana.TabIndex = 93;
            this.lbl_GameBanana.Text = "GameBanana 1-Click Install";
            // 
            // check_GameBanana
            // 
            this.check_GameBanana.AutoSize = true;
            this.check_GameBanana.ForeColor = System.Drawing.SystemColors.Control;
            this.check_GameBanana.Location = new System.Drawing.Point(15, 97);
            this.check_GameBanana.Name = "check_GameBanana";
            this.check_GameBanana.Size = new System.Drawing.Size(15, 14);
            this.check_GameBanana.TabIndex = 92;
            this.check_GameBanana.UseVisualStyleBackColor = true;
            this.check_GameBanana.CheckedChanged += new System.EventHandler(this.Check_GameBanana_CheckedChanged);
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
            // lbl_ManualPatches
            // 
            this.lbl_ManualPatches.AutoSize = true;
            this.lbl_ManualPatches.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_ManualPatches.Location = new System.Drawing.Point(32, 48);
            this.lbl_ManualPatches.Name = "lbl_ManualPatches";
            this.lbl_ManualPatches.Size = new System.Drawing.Size(141, 15);
            this.lbl_ManualPatches.TabIndex = 97;
            this.lbl_ManualPatches.Text = "Manual patch installation";
            // 
            // check_ManualPatches
            // 
            this.check_ManualPatches.AutoSize = true;
            this.check_ManualPatches.ForeColor = System.Drawing.SystemColors.Control;
            this.check_ManualPatches.Location = new System.Drawing.Point(15, 49);
            this.check_ManualPatches.Name = "check_ManualPatches";
            this.check_ManualPatches.Size = new System.Drawing.Size(15, 14);
            this.check_ManualPatches.TabIndex = 96;
            this.check_ManualPatches.UseVisualStyleBackColor = true;
            this.check_ManualPatches.CheckedChanged += new System.EventHandler(this.Check_ManualPatches_CheckedChanged);
            // 
            // split_Options
            // 
            this.split_Options.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.split_Options.IsSplitterFixed = true;
            this.split_Options.Location = new System.Drawing.Point(6, 168);
            this.split_Options.Name = "split_Options";
            // 
            // split_Options.Panel1
            // 
            this.split_Options.Panel1.Controls.Add(this.btn_ReportBug);
            this.split_Options.Panel1.Controls.Add(this.btn_GitHub);
            // 
            // split_Options.Panel2
            // 
            this.split_Options.Panel2.Controls.Add(this.splitContainer2);
            this.split_Options.Size = new System.Drawing.Size(510, 60);
            this.split_Options.SplitterDistance = 128;
            this.split_Options.TabIndex = 102;
            // 
            // btn_ReportBug
            // 
            this.btn_ReportBug.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ReportBug.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_ReportBug.FlatAppearance.BorderSize = 0;
            this.btn_ReportBug.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ReportBug.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_ReportBug.Location = new System.Drawing.Point(8, 4);
            this.btn_ReportBug.Name = "btn_ReportBug";
            this.btn_ReportBug.Size = new System.Drawing.Size(119, 23);
            this.btn_ReportBug.TabIndex = 94;
            this.btn_ReportBug.Text = "Report a bug";
            this.btn_ReportBug.UseVisualStyleBackColor = false;
            this.btn_ReportBug.Click += new System.EventHandler(this.Btn_ReportBug_Click);
            // 
            // btn_GitHub
            // 
            this.btn_GitHub.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_GitHub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(218)))), ((int)(((byte)(240)))));
            this.btn_GitHub.FlatAppearance.BorderSize = 0;
            this.btn_GitHub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_GitHub.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_GitHub.Location = new System.Drawing.Point(8, 33);
            this.btn_GitHub.Name = "btn_GitHub";
            this.btn_GitHub.Size = new System.Drawing.Size(119, 23);
            this.btn_GitHub.TabIndex = 89;
            this.btn_GitHub.Text = "GitHub";
            this.btn_GitHub.UseVisualStyleBackColor = false;
            this.btn_GitHub.Click += new System.EventHandler(this.Btn_GitHub_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btn_About);
            this.splitContainer2.Panel1.Controls.Add(this.btn_Update);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btn_Reset);
            this.splitContainer2.Panel2.Controls.Add(this.btn_Theme);
            this.splitContainer2.Size = new System.Drawing.Size(378, 60);
            this.splitContainer2.SplitterDistance = 247;
            this.splitContainer2.TabIndex = 0;
            // 
            // btn_About
            // 
            this.btn_About.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_About.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_About.FlatAppearance.BorderSize = 0;
            this.btn_About.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_About.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_About.Location = new System.Drawing.Point(1, 33);
            this.btn_About.Name = "btn_About";
            this.btn_About.Size = new System.Drawing.Size(245, 23);
            this.btn_About.TabIndex = 50;
            this.btn_About.Text = "About Sonic \'06 Mod Manager";
            this.btn_About.UseVisualStyleBackColor = false;
            this.btn_About.Click += new System.EventHandler(this.Btn_About_Click);
            this.btn_About.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_About_MouseUp);
            // 
            // btn_Update
            // 
            this.btn_Update.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Update.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Update.FlatAppearance.BorderSize = 0;
            this.btn_Update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Update.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Update.Location = new System.Drawing.Point(1, 4);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(245, 23);
            this.btn_Update.TabIndex = 91;
            this.btn_Update.Text = "Check for Updates";
            this.btn_Update.UseVisualStyleBackColor = false;
            this.btn_Update.Click += new System.EventHandler(this.Btn_Update_Click);
            // 
            // btn_Reset
            // 
            this.btn_Reset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Reset.BackColor = System.Drawing.Color.Tomato;
            this.btn_Reset.FlatAppearance.BorderSize = 0;
            this.btn_Reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Reset.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Reset.Location = new System.Drawing.Point(1, 33);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(119, 23);
            this.btn_Reset.TabIndex = 90;
            this.btn_Reset.Text = "Reset";
            this.btn_Reset.UseVisualStyleBackColor = false;
            this.btn_Reset.Click += new System.EventHandler(this.Btn_Reset_Click);
            // 
            // btn_Theme
            // 
            this.btn_Theme.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Theme.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Theme.FlatAppearance.BorderSize = 0;
            this.btn_Theme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Theme.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Theme.Location = new System.Drawing.Point(1, 4);
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
            this.group_FTP.Controls.Add(this.text_Password);
            this.group_FTP.Controls.Add(this.lbl_Password);
            this.group_FTP.Controls.Add(this.text_Username);
            this.group_FTP.Controls.Add(this.text_FTPLocation);
            this.group_FTP.Controls.Add(this.lbl_Username);
            this.group_FTP.Controls.Add(this.lbl_FTPLocation);
            this.group_FTP.ForeColor = System.Drawing.SystemColors.Control;
            this.group_FTP.Location = new System.Drawing.Point(4, 102);
            this.group_FTP.Name = "group_FTP";
            this.group_FTP.Size = new System.Drawing.Size(522, 148);
            this.group_FTP.TabIndex = 6;
            this.group_FTP.TabStop = false;
            this.group_FTP.Text = "File Transfer Protocol (Deprecated)";
            // 
            // lbl_FTP
            // 
            this.lbl_FTP.AutoSize = true;
            this.lbl_FTP.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_FTP.Location = new System.Drawing.Point(113, 116);
            this.lbl_FTP.Name = "lbl_FTP";
            this.lbl_FTP.Size = new System.Drawing.Size(189, 15);
            this.lbl_FTP.TabIndex = 18;
            this.lbl_FTP.Text = "Use FTP server for mod installation";
            // 
            // check_FTP
            // 
            this.check_FTP.AutoSize = true;
            this.check_FTP.ForeColor = System.Drawing.SystemColors.Control;
            this.check_FTP.Location = new System.Drawing.Point(97, 117);
            this.check_FTP.Name = "check_FTP";
            this.check_FTP.Size = new System.Drawing.Size(15, 14);
            this.check_FTP.TabIndex = 8;
            this.check_FTP.UseVisualStyleBackColor = true;
            this.check_FTP.CheckedChanged += new System.EventHandler(this.Check_FTP_CheckedChanged);
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
            this.text_Password.PasswordChar = '•';
            this.text_Password.Size = new System.Drawing.Size(411, 23);
            this.text_Password.TabIndex = 6;
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
            this.text_Username.TextChanged += new System.EventHandler(this.Text_Username_TextChanged);
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
            this.text_FTPLocation.TextChanged += new System.EventHandler(this.Text_FTPLocation_TextChanged);
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
            this.ClientSize = new System.Drawing.Size(538, 616);
            this.Controls.Add(this.sonic06mm_Aldi);
            this.Controls.Add(this.lbl_SetStatus);
            this.Controls.Add(this.radio_PlayStation3);
            this.Controls.Add(this.radio_Xbox360);
            this.Controls.Add(this.radio_All);
            this.Controls.Add(this.status_Main);
            this.Controls.Add(this.unifytb_Main);
            this.Controls.Add(this.split_MainControls);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(554, 655);
            this.Name = "ModManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sonic \'06 Mod Manager";
            this.Shown += new System.EventHandler(this.ModManager_Shown);
            this.ResizeEnd += new System.EventHandler(this.ModManager_ResizeEnd);
            this.Resize += new System.EventHandler(this.ModManager_Resize);
            this.split_MainControls.Panel1.ResumeLayout(false);
            this.split_MainControls.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_MainControls)).EndInit();
            this.split_MainControls.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.split_MainControlsWidthModifier.Panel1.ResumeLayout(false);
            this.split_MainControlsWidthModifier.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_MainControlsWidthModifier)).EndInit();
            this.split_MainControlsWidthModifier.ResumeLayout(false);
            this.split_Mods.Panel1.ResumeLayout(false);
            this.split_Mods.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_Mods)).EndInit();
            this.split_Mods.ResumeLayout(false);
            this.split_ListControls.Panel1.ResumeLayout(false);
            this.split_ListControls.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_ListControls)).EndInit();
            this.split_ListControls.ResumeLayout(false);
            this.unifytb_Main.ResumeLayout(false);
            this.unifytb_Tab_Mods.ResumeLayout(false);
            this.pnl_ModBackdrop.ResumeLayout(false);
            this.unifytb_Tab_Emulator.ResumeLayout(false);
            this.unifytb_Tab_Emulator.PerformLayout();
            this.group_Settings.ResumeLayout(false);
            this.group_Settings.PerformLayout();
            this.group_Setup.ResumeLayout(false);
            this.group_Setup.PerformLayout();
            this.unifytb_Tab_Patches.ResumeLayout(false);
            this.split_Patches.Panel1.ResumeLayout(false);
            this.split_Patches.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_Patches)).EndInit();
            this.split_Patches.ResumeLayout(false);
            this.pnl_PatchBackdrop.ResumeLayout(false);
            this.group_CameraTweaks.ResumeLayout(false);
            this.group_CameraTweaks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_CameraDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_CameraHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_FieldOfView)).EndInit();
            this.group_GraphicsTweaks.ResumeLayout(false);
            this.group_GraphicsTweaks.PerformLayout();
            this.unifytb_Tab_Settings.ResumeLayout(false);
            this.group_Options.ResumeLayout(false);
            this.group_Options.PerformLayout();
            this.group_Appearance.ResumeLayout(false);
            this.group_Appearance.PerformLayout();
            this.split_Options.Panel1.ResumeLayout(false);
            this.split_Options.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_Options)).EndInit();
            this.split_Options.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
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
        private System.Windows.Forms.Button btn_DeselectAll;
        private System.Windows.Forms.Button btn_SelectAll;
        private System.Windows.Forms.Button btn_Priority;
        private System.Windows.Forms.Button btn_DownerPriority;
        private System.Windows.Forms.Button btn_UpperPriority;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Play;
        private System.Windows.Forms.Button btn_RefreshMods;
        private System.Windows.Forms.Button btn_ModInfo;
        private System.Windows.Forms.CheckedListBox clb_PatchesList;
        private System.Windows.Forms.StatusStrip status_Main;
        private System.Windows.Forms.ToolStripStatusLabel statuslbl_Status;
        private System.Windows.Forms.GroupBox group_GraphicsTweaks;
        private System.Windows.Forms.Button btn_ResetReflections;
        private System.Windows.Forms.Button btn_ResetCameraDistance;
        private System.Windows.Forms.NumericUpDown nud_CameraDistance;
        private System.Windows.Forms.Label lbl_CameraDistance;
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
        private System.Windows.Forms.TextBox text_Password;
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
        private System.Windows.Forms.Label lbl_ManualInstall;
        private System.Windows.Forms.Label lbl_FTP;
        private System.Windows.Forms.Label lbl_GameBanana;
        private System.Windows.Forms.CheckBox check_GameBanana;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Label lbl_SettingsOverlay;
        private System.Windows.Forms.Button btn_ReportBug;
        private System.Windows.Forms.ToolStripStatusLabel lbl_Status;
        private System.Windows.Forms.Label lbl_ManualPatches;
        private System.Windows.Forms.CheckBox check_ManualPatches;
        private System.Windows.Forms.ToolStripStatusLabel lbl_MainStatus;
        private System.Windows.Forms.Label lbl_SetStatus;
        private System.Windows.Forms.Button sonic06mm_Aldi;
        private System.Windows.Forms.Label lbl_GraphicsTweaksOverlay;
        private System.Windows.Forms.Label lbl_SetupOverlay;
        private System.Windows.Forms.Label lbl_SaveRedirect;
        private System.Windows.Forms.CheckBox check_SaveRedirect;
        private System.Windows.Forms.Button btn_ResetCameraType;
        private System.Windows.Forms.Label lbl_CameraType;
        private System.Windows.Forms.ComboBox combo_CameraType;
        private System.Windows.Forms.Button btn_ResetFOV;
        private System.Windows.Forms.NumericUpDown nud_FieldOfView;
        private System.Windows.Forms.Label lbl_FieldOfView;
        private System.Windows.Forms.Button btn_ResetRenderer;
        private System.Windows.Forms.Label lbl_Renderer;
        private System.Windows.Forms.ComboBox combo_Renderer;
        private System.Windows.Forms.Button btn_ResetCameraHeight;
        private System.Windows.Forms.NumericUpDown nud_CameraHeight;
        private System.Windows.Forms.Label lbl_CameraHeight;
        private System.Windows.Forms.Label lbl_DisableSoftwareUpdater;
        private System.Windows.Forms.CheckBox check_DisableSoftwareUpdater;
        private System.Windows.Forms.LinkLabel help_Renderer;
        private System.Windows.Forms.LinkLabel help_FieldOfView;
        private System.Windows.Forms.LinkLabel help_CameraHeight;
        private System.Windows.Forms.LinkLabel help_CameraDistance;
        private System.Windows.Forms.LinkLabel help_CameraType;
        private System.Windows.Forms.LinkLabel help_Reflections;
        private System.Windows.Forms.SplitContainer split_Patches;
        private System.Windows.Forms.Panel pnl_PatchBackdrop;
        private System.Windows.Forms.Panel pnl_ModBackdrop;
        private System.Windows.Forms.SplitContainer split_MainControls;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer split_MainControlsWidthModifier;
        private System.Windows.Forms.Button btn_CreateNewMod;
        private System.Windows.Forms.Button btn_InstallMods;
        private System.Windows.Forms.Button btn_EditMod;
        private System.Windows.Forms.Button btn_UninstallMods;
        private System.Windows.Forms.Button btn_CreateNewModFull;
        private System.Windows.Forms.Button btn_SaveAndPlayFull;
        private System.Windows.Forms.SplitContainer split_Mods;
        private System.Windows.Forms.SplitContainer split_ListControls;
        private System.Windows.Forms.SplitContainer split_Options;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btn_SaveData;
        private System.Windows.Forms.TextBox text_SaveData;
        private System.Windows.Forms.Label lbl_SaveData;
        private System.Windows.Forms.ListView view_ModsList;
        private System.Windows.Forms.ColumnHeader column_Title;
        private System.Windows.Forms.ColumnHeader column_Version;
        private System.Windows.Forms.ColumnHeader column_Author;
        private System.Windows.Forms.ColumnHeader column_System;
        private System.Windows.Forms.ColumnHeader column_Merge;
        private System.Windows.Forms.ColumnHeader column_Blank;
        private System.Windows.Forms.GroupBox group_Appearance;
        private System.Windows.Forms.Button btn_GridStyle_Default;
        private System.Windows.Forms.ComboBox combo_GridStyle;
        private System.Windows.Forms.Label lbl_GridStyle;
        private System.Windows.Forms.Label lbl_CancelChristmas;
        private System.Windows.Forms.CheckBox check_CancelChristmas;
        private System.Windows.Forms.Label lbl_HighContrastText;
        private System.Windows.Forms.CheckBox check_HighContrastText;
        private System.Windows.Forms.LinkLabel help_MSAA;
        private System.Windows.Forms.Button btn_ResetMSAA;
        private System.Windows.Forms.Label lbl_MSAA;
        private System.Windows.Forms.ComboBox combo_MSAA;
        private System.Windows.Forms.GroupBox group_CameraTweaks;
        private System.Windows.Forms.Label lbl_CameraTweaks;
        private System.Windows.Forms.Label lbl_ForceAA;
        private System.Windows.Forms.CheckBox check_ForceAA;
        private System.Windows.Forms.LinkLabel help_ForceAA;
    }
}