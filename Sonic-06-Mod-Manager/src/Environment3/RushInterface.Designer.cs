using Unify;

namespace Unify.Environment3
{
    partial class RushInterface
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RushInterface));
            this.StatusStrip_Main = new System.Windows.Forms.StatusStrip();
            this.Label_Status = new System.Windows.Forms.Label();
            this.Panel_MainControls = new System.Windows.Forms.Panel();
            this.SplitContainer_MainControls = new System.Windows.Forms.SplitContainer();
            this.SectionButton_InstallMods = new Unify.Environment3.SectionButton();
            this.SectionButton_LaunchGame = new Unify.Environment3.SectionButton();
            this.ToolTip_Information = new System.Windows.Forms.ToolTip(this.components);
            this.Button_Mods_DownerPriority = new System.Windows.Forms.Button();
            this.Button_Mods_UpperPriority = new System.Windows.Forms.Button();
            this.Button_Patches_DownerPriority = new System.Windows.Forms.Button();
            this.Button_Patches_UpperPriority = new System.Windows.Forms.Button();
            this.TabControl_Rush = new Unify.Environment3.UnifyTabControl();
            this.Tab_Section_Mods = new System.Windows.Forms.TabPage();
            this.SplitContainer_ModsControls = new System.Windows.Forms.SplitContainer();
            this.SectionButton_SaveChecks = new Unify.Environment3.SectionButton();
            this.SectionButton_RefreshMods = new Unify.Environment3.SectionButton();
            this.Button_Mods_Priority = new System.Windows.Forms.Button();
            this.Button_Mods_DeselectAll = new System.Windows.Forms.Button();
            this.Button_Mods_SelectAll = new System.Windows.Forms.Button();
            this.Panel_ModBackdrop = new System.Windows.Forms.Panel();
            this.ListView_ModsList = new System.Windows.Forms.ListView();
            this.Column_ModsList_Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Column_ModsList_Version = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Column_ModsList_Author = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Column_ModsList_System = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Column_ModsList_Merge = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Column_ModsList_Blank = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tab_Section_Emulator = new System.Windows.Forms.TabPage();
            this.Label_Description_Resolution = new System.Windows.Forms.Label();
            this.Label_Resolution = new System.Windows.Forms.Label();
            this.ComboBox_Resolution = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TextBox_Arguments = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Label_Description_UserLanguage = new System.Windows.Forms.Label();
            this.Label_UserLanguage = new System.Windows.Forms.Label();
            this.ComboBox_UserLanguage = new System.Windows.Forms.ComboBox();
            this.Label_Description_DiscordRPC = new System.Windows.Forms.Label();
            this.Label_Description_Fullscreen = new System.Windows.Forms.Label();
            this.Label_Description_Gamma = new System.Windows.Forms.Label();
            this.Label_Description_VerticalSync = new System.Windows.Forms.Label();
            this.Label_Description_API = new System.Windows.Forms.Label();
            this.Button_Open_SaveData = new System.Windows.Forms.Button();
            this.Button_Open_EmulatorExecutable = new System.Windows.Forms.Button();
            this.Label_RPCS3Warning = new System.Windows.Forms.Label();
            this.CheckBox_Xenia_DiscordRPC = new System.Windows.Forms.CheckBox();
            this.CheckBox_Xenia_Fullscreen = new System.Windows.Forms.CheckBox();
            this.CheckBox_Xenia_Gamma = new System.Windows.Forms.CheckBox();
            this.CheckBox_Xenia_VerticalSync = new System.Windows.Forms.CheckBox();
            this.Label_API = new System.Windows.Forms.Label();
            this.ComboBox_API = new System.Windows.Forms.ComboBox();
            this.Label_Subtitle_Emulator_Options = new System.Windows.Forms.Label();
            this.TextBox_SaveData = new System.Windows.Forms.TextBox();
            this.Label_Description_EmulatorExecutable = new System.Windows.Forms.Label();
            this.Button_SaveData = new System.Windows.Forms.Button();
            this.Label_Description_SaveData = new System.Windows.Forms.Label();
            this.Label_Subtitle_Emulator_Paths = new System.Windows.Forms.Label();
            this.Button_EmulatorExecutable = new System.Windows.Forms.Button();
            this.TextBox_EmulatorExecutable = new System.Windows.Forms.TextBox();
            this.Label_EmulatorExecutable = new System.Windows.Forms.Label();
            this.Label_SaveData = new System.Windows.Forms.Label();
            this.Label_Optional_SaveData = new System.Windows.Forms.Label();
            this.Tab_Section_Patches = new System.Windows.Forms.TabPage();
            this.Button_Patches_Priority = new System.Windows.Forms.Button();
            this.Button_Patches_DeselectAll = new System.Windows.Forms.Button();
            this.Button_Patches_SelectAll = new System.Windows.Forms.Button();
            this.SplitContainer_PatchesControls = new System.Windows.Forms.SplitContainer();
            this.SectionButton_SaveCheckedPatches = new Unify.Environment3.SectionButton();
            this.SectionButton_RefreshPatches = new Unify.Environment3.SectionButton();
            this.Panel_PatchBackdrop = new System.Windows.Forms.Panel();
            this.ListView_PatchesList = new System.Windows.Forms.ListView();
            this.Column_PatchesList_Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Column_PatchesList_Author = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Column_PatchesList_System = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Column_PatchesList_Blurb = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Column_PatchesList_Blank = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tab_Section_Tweaks = new System.Windows.Forms.TabPage();
            this.Button_BeginWithRings_Default = new System.Windows.Forms.Button();
            this.Label_Description_BeginWithRings = new System.Windows.Forms.Label();
            this.Label_BeginWithRings = new System.Windows.Forms.Label();
            this.NumericUpDown_BeginWithRings = new System.Windows.Forms.NumericUpDown();
            this.Button_AmyHammerRange_Default = new System.Windows.Forms.Button();
            this.Button_FieldOfView_Default = new System.Windows.Forms.Button();
            this.Button_CameraHeight_Default = new System.Windows.Forms.Button();
            this.Button_CameraDistance_Default = new System.Windows.Forms.Button();
            this.Button_CameraType_Default = new System.Windows.Forms.Button();
            this.Button_AntiAliasing_Default = new System.Windows.Forms.Button();
            this.Button_Reflections_Default = new System.Windows.Forms.Button();
            this.Button_Renderer_Default = new System.Windows.Forms.Button();
            this.Label_Description_AmyHammerRange = new System.Windows.Forms.Label();
            this.Label_AmyHammerRange = new System.Windows.Forms.Label();
            this.Label_Subtitle_CharacterTweaks = new System.Windows.Forms.Label();
            this.Label_Description_FieldOfView = new System.Windows.Forms.Label();
            this.Label_FieldOfView = new System.Windows.Forms.Label();
            this.NumericUpDown_FieldOfView = new System.Windows.Forms.NumericUpDown();
            this.Label_Description_CameraHeight = new System.Windows.Forms.Label();
            this.Label_CameraHeight = new System.Windows.Forms.Label();
            this.NumericUpDown_CameraHeight = new System.Windows.Forms.NumericUpDown();
            this.Label_Description_CameraDistance = new System.Windows.Forms.Label();
            this.Label_CameraDistance = new System.Windows.Forms.Label();
            this.NumericUpDown_CameraDistance = new System.Windows.Forms.NumericUpDown();
            this.Label_Description_CameraType = new System.Windows.Forms.Label();
            this.Label_CameraType = new System.Windows.Forms.Label();
            this.ComboBox_CameraType = new System.Windows.Forms.ComboBox();
            this.Label_Subtitle_CameraTweaks = new System.Windows.Forms.Label();
            this.Label_Description_ForceMSAA = new System.Windows.Forms.Label();
            this.CheckBox_ForceMSAA = new System.Windows.Forms.CheckBox();
            this.Label_Description_AntiAliasing = new System.Windows.Forms.Label();
            this.Label_AntiAliasing = new System.Windows.Forms.Label();
            this.ComboBox_AntiAliasing = new System.Windows.Forms.ComboBox();
            this.Label_Description_Reflections = new System.Windows.Forms.Label();
            this.Label_Reflections = new System.Windows.Forms.Label();
            this.ComboBox_Reflections = new System.Windows.Forms.ComboBox();
            this.Label_Description_Renderer = new System.Windows.Forms.Label();
            this.Label_Renderer = new System.Windows.Forms.Label();
            this.ComboBox_Renderer = new System.Windows.Forms.ComboBox();
            this.Label_Subtitle_GraphicsTweaks = new System.Windows.Forms.Label();
            this.NumericUpDown_AmyHammerRange = new System.Windows.Forms.NumericUpDown();
            this.Panel_Tweaks_UICleanSpace = new System.Windows.Forms.Panel();
            this.Tab_Section_Debug = new System.Windows.Forms.TabPage();
            this.LinkLabel_Troubleshoot_Mod = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.LinkLabel_Snapshot_Load = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Panel_DebugControls = new System.Windows.Forms.Panel();
            this.SectionButton_ClearLog = new Unify.Environment3.SectionButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ListBox_Debug = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CheckBox_AllowModStacking = new System.Windows.Forms.CheckBox();
            this.Tab_Section_Updates = new System.Windows.Forms.TabPage();
            this.Panel_Updates_UICleanSpace = new System.Windows.Forms.Panel();
            this.SectionButton_FetchPatches = new Unify.Environment3.SectionButton();
            this.Label_LastPatchUpdate = new System.Windows.Forms.Label();
            this.Label_LastModUpdate = new System.Windows.Forms.Label();
            this.SectionButton_CheckForModUpdates = new Unify.Environment3.SectionButton();
            this.Label_LastSoftwareUpdate = new System.Windows.Forms.Label();
            this.SplitContainer_ModUpdate = new System.Windows.Forms.SplitContainer();
            this.Panel_ModUpdateBackdrop = new System.Windows.Forms.Panel();
            this.ListView_ModUpdates = new System.Windows.Forms.ListView();
            this.Column_ModUpdates_Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Column_ModUpdates_Blank = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SectionButton_UpdateMods = new Unify.Environment3.SectionButton();
            this.ProgressBar_ModUpdate = new System.Windows.Forms.ProgressBar();
            this.Panel_ModInfoBackdrop = new System.Windows.Forms.Panel();
            this.ListBox_UpdateLogs = new System.Windows.Forms.ListBox();
            this.Label_Title_ModsAndPatches = new System.Windows.Forms.Label();
            this.Label_Subtitle_Changelogs = new System.Windows.Forms.Label();
            this.Label_UpdaterStatus = new System.Windows.Forms.Label();
            this.Panel_ChangelogsBackdrop = new System.Windows.Forms.Panel();
            this.RichTextBox_Changelogs = new System.Windows.Forms.RichTextBox();
            this.Label_Title_Software = new System.Windows.Forms.Label();
            this.CheckBox_CheckUpdatesOnLaunch = new System.Windows.Forms.CheckBox();
            this.PictureBox_UpdaterIcon = new System.Windows.Forms.PictureBox();
            this.SectionButton_CheckForSoftwareUpdates = new Unify.Environment3.SectionButton();
            this.ProgressBar_SoftwareUpdate = new System.Windows.Forms.ProgressBar();
            this.Tab_Section_Settings = new System.Windows.Forms.TabPage();
            this.LinkLabel_OpenProfilesDirectory = new System.Windows.Forms.LinkLabel();
            this.label11 = new System.Windows.Forms.Label();
            this.LinkLabel_LoadProfile = new System.Windows.Forms.LinkLabel();
            this.label10 = new System.Windows.Forms.Label();
            this.LinkLabel_CreateProfile = new System.Windows.Forms.LinkLabel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.LinkLabel_Snapshot_Create = new System.Windows.Forms.LinkLabel();
            this.Label_Description_UninstallOnLaunch = new System.Windows.Forms.Label();
            this.CheckBox_UninstallOnLaunch = new System.Windows.Forms.CheckBox();
            this.Label_Description_Reset = new System.Windows.Forms.Label();
            this.LinkLabel_Reset = new System.Windows.Forms.LinkLabel();
            this.Label_Description_DebugMode = new System.Windows.Forms.Label();
            this.Label_Description_HighContrastText = new System.Windows.Forms.Label();
            this.Label_Description_SaveFileRedirect = new System.Windows.Forms.Label();
            this.CheckBox_SaveFileRedirection = new System.Windows.Forms.CheckBox();
            this.CheckBox_DebugMode = new System.Windows.Forms.CheckBox();
            this.Label_Description_LaunchEmulator = new System.Windows.Forms.Label();
            this.CheckBox_LaunchEmulator = new System.Windows.Forms.CheckBox();
            this.Label_Subtitle_General_Options = new System.Windows.Forms.Label();
            this.WindowsColourPicker_AccentColour = new Unify.Environment3.WindowsColourPicker();
            this.TextBox_GameDirectory = new System.Windows.Forms.TextBox();
            this.Label_Title_Appearance = new System.Windows.Forms.Label();
            this.CheckBox_HighContrastText = new System.Windows.Forms.CheckBox();
            this.Label_Title_General = new System.Windows.Forms.Label();
            this.Label_Subtitle_AccentColour = new System.Windows.Forms.Label();
            this.Label_GameExecutable = new System.Windows.Forms.Label();
            this.Label_WindowsColours = new System.Windows.Forms.Label();
            this.Button_GameDirectory = new System.Windows.Forms.Button();
            this.Label_Subtitle_Appearance_Options = new System.Windows.Forms.Label();
            this.CheckBox_AutoColour = new System.Windows.Forms.CheckBox();
            this.Label_Description_GameExecutable = new System.Windows.Forms.Label();
            this.Button_ColourPicker_Preview = new System.Windows.Forms.Button();
            this.Label_Subtitle_Settings_Paths = new System.Windows.Forms.Label();
            this.Button_ModsDirectory = new System.Windows.Forms.Button();
            this.TextBox_ModsDirectory = new System.Windows.Forms.TextBox();
            this.Label_ModsDirectory = new System.Windows.Forms.Label();
            this.Panel_Settings_UICleanSpace = new System.Windows.Forms.Panel();
            this.Button_Open_GameDirectory = new System.Windows.Forms.Button();
            this.Button_Open_ModsDirectory = new System.Windows.Forms.Button();
            this.Button_ColourPicker_Default = new System.Windows.Forms.Button();
            this.Section_Appearance_ColourPicker = new Unify.Environment3.SectionButton();
            this.Label_Description_1ClickURLHandler = new System.Windows.Forms.Label();
            this.LinkLabel_1ClickURLHandler = new System.Windows.Forms.LinkLabel();
            this.Label_Warning_ModsDirectoryInvalid = new System.Windows.Forms.Label();
            this.Label_Description_ModsDirectory = new System.Windows.Forms.Label();
            this.Label_Description_Snapshot = new System.Windows.Forms.Label();
            this.Tab_Section_About = new System.Windows.Forms.TabPage();
            this.LinkLabel_Contributors_VolcanoTheBat = new System.Windows.Forms.LinkLabel();
            this.LinkLabel_Testers_Radfordhound = new System.Windows.Forms.LinkLabel();
            this.LinkLabel_Velcomia = new System.Windows.Forms.LinkLabel();
            this.LinkLabel_Melpontro = new System.Windows.Forms.LinkLabel();
            this.LinkLabel_sharu6262 = new System.Windows.Forms.LinkLabel();
            this.Label_Testers = new System.Windows.Forms.Label();
            this.Title_Testers = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.LinkLabel_Contributors_Radfordhound = new System.Windows.Forms.LinkLabel();
            this.LinkLabel_SuperSonic16 = new System.Windows.Forms.LinkLabel();
            this.LinkLabel_GerbilSoft = new System.Windows.Forms.LinkLabel();
            this.LinkLabel_Knuxfan24 = new System.Windows.Forms.LinkLabel();
            this.LinkLabel_HyperBE32 = new System.Windows.Forms.LinkLabel();
            this.Label_Contributors = new System.Windows.Forms.Label();
            this.Title_Contributors = new System.Windows.Forms.Label();
            this.Label_Version = new System.Windows.Forms.Label();
            this.Rush_Section_Debug = new Unify.Environment3.SectionButton();
            this.Rush_Section_Updates = new Unify.Environment3.SectionButton();
            this.Rush_Section_Tweaks = new Unify.Environment3.SectionButton();
            this.Rush_Section_Settings = new Unify.Environment3.SectionButton();
            this.Rush_Section_Patches = new Unify.Environment3.SectionButton();
            this.Rush_Section_About = new Unify.Environment3.SectionButton();
            this.Rush_Section_Emulator = new Unify.Environment3.SectionButton();
            this.Rush_Section_Mods = new Unify.Environment3.SectionButton();
            this.Container_Rush = new Unify.Environment3.UserContainer();
            this.Panel_MainControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_MainControls)).BeginInit();
            this.SplitContainer_MainControls.Panel1.SuspendLayout();
            this.SplitContainer_MainControls.Panel2.SuspendLayout();
            this.SplitContainer_MainControls.SuspendLayout();
            this.TabControl_Rush.SuspendLayout();
            this.Tab_Section_Mods.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_ModsControls)).BeginInit();
            this.SplitContainer_ModsControls.Panel1.SuspendLayout();
            this.SplitContainer_ModsControls.Panel2.SuspendLayout();
            this.SplitContainer_ModsControls.SuspendLayout();
            this.Panel_ModBackdrop.SuspendLayout();
            this.Tab_Section_Emulator.SuspendLayout();
            this.Tab_Section_Patches.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_PatchesControls)).BeginInit();
            this.SplitContainer_PatchesControls.Panel1.SuspendLayout();
            this.SplitContainer_PatchesControls.Panel2.SuspendLayout();
            this.SplitContainer_PatchesControls.SuspendLayout();
            this.Panel_PatchBackdrop.SuspendLayout();
            this.Tab_Section_Tweaks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_BeginWithRings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_FieldOfView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_CameraHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_CameraDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_AmyHammerRange)).BeginInit();
            this.Tab_Section_Debug.SuspendLayout();
            this.Panel_DebugControls.SuspendLayout();
            this.panel1.SuspendLayout();
            this.Tab_Section_Updates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_ModUpdate)).BeginInit();
            this.SplitContainer_ModUpdate.Panel1.SuspendLayout();
            this.SplitContainer_ModUpdate.Panel2.SuspendLayout();
            this.SplitContainer_ModUpdate.SuspendLayout();
            this.Panel_ModUpdateBackdrop.SuspendLayout();
            this.Panel_ModInfoBackdrop.SuspendLayout();
            this.Panel_ChangelogsBackdrop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_UpdaterIcon)).BeginInit();
            this.Tab_Section_Settings.SuspendLayout();
            this.Tab_Section_About.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusStrip_Main
            // 
            this.StatusStrip_Main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.StatusStrip_Main.Location = new System.Drawing.Point(0, 1178);
            this.StatusStrip_Main.Name = "StatusStrip_Main";
            this.StatusStrip_Main.Size = new System.Drawing.Size(849, 22);
            this.StatusStrip_Main.TabIndex = 26;
            this.StatusStrip_Main.Text = "statusStrip1";
            // 
            // Label_Status
            // 
            this.Label_Status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label_Status.AutoSize = true;
            this.Label_Status.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Label_Status.Location = new System.Drawing.Point(3, 1181);
            this.Label_Status.Name = "Label_Status";
            this.Label_Status.Size = new System.Drawing.Size(42, 15);
            this.Label_Status.TabIndex = 27;
            this.Label_Status.Text = "Ready.";
            // 
            // Panel_MainControls
            // 
            this.Panel_MainControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_MainControls.Controls.Add(this.SplitContainer_MainControls);
            this.Panel_MainControls.Location = new System.Drawing.Point(250, 1135);
            this.Panel_MainControls.Name = "Panel_MainControls";
            this.Panel_MainControls.Size = new System.Drawing.Size(599, 43);
            this.Panel_MainControls.TabIndex = 30;
            // 
            // SplitContainer_MainControls
            // 
            this.SplitContainer_MainControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SplitContainer_MainControls.IsSplitterFixed = true;
            this.SplitContainer_MainControls.Location = new System.Drawing.Point(5, -20);
            this.SplitContainer_MainControls.Name = "SplitContainer_MainControls";
            // 
            // SplitContainer_MainControls.Panel1
            // 
            this.SplitContainer_MainControls.Panel1.Controls.Add(this.SectionButton_InstallMods);
            // 
            // SplitContainer_MainControls.Panel2
            // 
            this.SplitContainer_MainControls.Panel2.Controls.Add(this.SectionButton_LaunchGame);
            this.SplitContainer_MainControls.Size = new System.Drawing.Size(586, 77);
            this.SplitContainer_MainControls.SplitterDistance = 292;
            this.SplitContainer_MainControls.SplitterWidth = 1;
            this.SplitContainer_MainControls.TabIndex = 3;
            // 
            // SectionButton_InstallMods
            // 
            this.SectionButton_InstallMods.AccentColour = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SectionButton_InstallMods.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SectionButton_InstallMods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(45)))));
            this.SectionButton_InstallMods.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SectionButton_InstallMods.Location = new System.Drawing.Point(2, 20);
            this.SectionButton_InstallMods.Name = "SectionButton_InstallMods";
            this.SectionButton_InstallMods.SectionImage = global::Unify.Properties.Resources.InstallMods;
            this.SectionButton_InstallMods.SectionText = "Save and install content";
            this.SectionButton_InstallMods.SelectedSection = false;
            this.SectionButton_InstallMods.Size = new System.Drawing.Size(293, 35);
            this.SectionButton_InstallMods.TabIndex = 50;
            this.SectionButton_InstallMods.TextColour = System.Drawing.SystemColors.Control;
            this.ToolTip_Information.SetToolTip(this.SectionButton_InstallMods, "Right-click for more options...");
            this.SectionButton_InstallMods.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SectionButton_InstallMods_MouseClick);
            // 
            // SectionButton_LaunchGame
            // 
            this.SectionButton_LaunchGame.AccentColour = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SectionButton_LaunchGame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SectionButton_LaunchGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(45)))));
            this.SectionButton_LaunchGame.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SectionButton_LaunchGame.Location = new System.Drawing.Point(0, 20);
            this.SectionButton_LaunchGame.Name = "SectionButton_LaunchGame";
            this.SectionButton_LaunchGame.SectionImage = global::Unify.Properties.Resources.Run_16x;
            this.SectionButton_LaunchGame.SectionText = "Launch Sonic \'06";
            this.SectionButton_LaunchGame.SelectedSection = false;
            this.SectionButton_LaunchGame.Size = new System.Drawing.Size(1509, 35);
            this.SectionButton_LaunchGame.TabIndex = 51;
            this.SectionButton_LaunchGame.TextColour = System.Drawing.SystemColors.Control;
            this.SectionButton_LaunchGame.Click += new System.EventHandler(this.SectionButton_LaunchGame_Click);
            // 
            // ToolTip_Information
            // 
            this.ToolTip_Information.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ToolTip_Information.ForeColor = System.Drawing.SystemColors.Control;
            this.ToolTip_Information.OwnerDraw = true;
            this.ToolTip_Information.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ToolTip_Information.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.ToolTip_Draw);
            // 
            // Button_Mods_DownerPriority
            // 
            this.Button_Mods_DownerPriority.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Mods_DownerPriority.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Button_Mods_DownerPriority.Enabled = false;
            this.Button_Mods_DownerPriority.FlatAppearance.BorderSize = 0;
            this.Button_Mods_DownerPriority.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Mods_DownerPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Mods_DownerPriority.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Button_Mods_DownerPriority.Location = new System.Drawing.Point(377, 1044);
            this.Button_Mods_DownerPriority.Name = "Button_Mods_DownerPriority";
            this.Button_Mods_DownerPriority.Size = new System.Drawing.Size(26, 23);
            this.Button_Mods_DownerPriority.TabIndex = 48;
            this.Button_Mods_DownerPriority.Text = "▼";
            this.ToolTip_Information.SetToolTip(this.Button_Mods_DownerPriority, "Right-click to move the mod to the bottom of the list...");
            this.Button_Mods_DownerPriority.UseVisualStyleBackColor = false;
            this.Button_Mods_DownerPriority.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_Priority_Iteration_MouseUp);
            // 
            // Button_Mods_UpperPriority
            // 
            this.Button_Mods_UpperPriority.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Mods_UpperPriority.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Button_Mods_UpperPriority.Enabled = false;
            this.Button_Mods_UpperPriority.FlatAppearance.BorderSize = 0;
            this.Button_Mods_UpperPriority.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Mods_UpperPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Mods_UpperPriority.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Button_Mods_UpperPriority.Location = new System.Drawing.Point(346, 1044);
            this.Button_Mods_UpperPriority.Name = "Button_Mods_UpperPriority";
            this.Button_Mods_UpperPriority.Size = new System.Drawing.Size(26, 23);
            this.Button_Mods_UpperPriority.TabIndex = 47;
            this.Button_Mods_UpperPriority.Text = "▲";
            this.ToolTip_Information.SetToolTip(this.Button_Mods_UpperPriority, "Right-click to move the mod to the top of the list...");
            this.Button_Mods_UpperPriority.UseVisualStyleBackColor = false;
            this.Button_Mods_UpperPriority.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_Priority_Iteration_MouseUp);
            // 
            // Button_Patches_DownerPriority
            // 
            this.Button_Patches_DownerPriority.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Patches_DownerPriority.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Button_Patches_DownerPriority.Enabled = false;
            this.Button_Patches_DownerPriority.FlatAppearance.BorderSize = 0;
            this.Button_Patches_DownerPriority.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Patches_DownerPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Patches_DownerPriority.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Button_Patches_DownerPriority.Location = new System.Drawing.Point(377, 1044);
            this.Button_Patches_DownerPriority.Name = "Button_Patches_DownerPriority";
            this.Button_Patches_DownerPriority.Size = new System.Drawing.Size(26, 23);
            this.Button_Patches_DownerPriority.TabIndex = 55;
            this.Button_Patches_DownerPriority.Text = "▼";
            this.ToolTip_Information.SetToolTip(this.Button_Patches_DownerPriority, "Right-click to move the patch to the bottom of the list...");
            this.Button_Patches_DownerPriority.UseVisualStyleBackColor = false;
            this.Button_Patches_DownerPriority.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_Priority_Iteration_MouseUp);
            // 
            // Button_Patches_UpperPriority
            // 
            this.Button_Patches_UpperPriority.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Patches_UpperPriority.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Button_Patches_UpperPriority.Enabled = false;
            this.Button_Patches_UpperPriority.FlatAppearance.BorderSize = 0;
            this.Button_Patches_UpperPriority.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Patches_UpperPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Patches_UpperPriority.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Button_Patches_UpperPriority.Location = new System.Drawing.Point(346, 1044);
            this.Button_Patches_UpperPriority.Name = "Button_Patches_UpperPriority";
            this.Button_Patches_UpperPriority.Size = new System.Drawing.Size(26, 23);
            this.Button_Patches_UpperPriority.TabIndex = 54;
            this.Button_Patches_UpperPriority.Text = "▲";
            this.ToolTip_Information.SetToolTip(this.Button_Patches_UpperPriority, "Right-click to move the patch to the top of the list...");
            this.Button_Patches_UpperPriority.UseVisualStyleBackColor = false;
            this.Button_Patches_UpperPriority.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_Priority_Iteration_MouseUp);
            // 
            // TabControl_Rush
            // 
            this.TabControl_Rush.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.TabControl_Rush.AllowDragging = false;
            this.TabControl_Rush.AllowDrop = true;
            this.TabControl_Rush.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl_Rush.BackTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.TabControl_Rush.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.TabControl_Rush.ClosingButtonColor = System.Drawing.Color.WhiteSmoke;
            this.TabControl_Rush.ClosingMessage = null;
            this.TabControl_Rush.Controls.Add(this.Tab_Section_Mods);
            this.TabControl_Rush.Controls.Add(this.Tab_Section_Emulator);
            this.TabControl_Rush.Controls.Add(this.Tab_Section_Patches);
            this.TabControl_Rush.Controls.Add(this.Tab_Section_Tweaks);
            this.TabControl_Rush.Controls.Add(this.Tab_Section_Debug);
            this.TabControl_Rush.Controls.Add(this.Tab_Section_Updates);
            this.TabControl_Rush.Controls.Add(this.Tab_Section_Settings);
            this.TabControl_Rush.Controls.Add(this.Tab_Section_About);
            this.TabControl_Rush.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.TabControl_Rush.HorizontalLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.TabControl_Rush.ItemSize = new System.Drawing.Size(240, 16);
            this.TabControl_Rush.Location = new System.Drawing.Point(250, 3);
            this.TabControl_Rush.Name = "TabControl_Rush";
            this.TabControl_Rush.NoTabDisplay = true;
            this.TabControl_Rush.SelectedIndex = 0;
            this.TabControl_Rush.SelectedTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TabControl_Rush.ShowClosingButton = false;
            this.TabControl_Rush.ShowClosingMessage = false;
            this.TabControl_Rush.Size = new System.Drawing.Size(599, 1132);
            this.TabControl_Rush.TabIndex = 22;
            this.TabControl_Rush.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TabControl_Rush.SelectedIndexChanged += new System.EventHandler(this.TabControl_Rush_SelectedIndexChanged);
            // 
            // Tab_Section_Mods
            // 
            this.Tab_Section_Mods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Tab_Section_Mods.Controls.Add(this.SplitContainer_ModsControls);
            this.Tab_Section_Mods.Controls.Add(this.Button_Mods_Priority);
            this.Tab_Section_Mods.Controls.Add(this.Button_Mods_DownerPriority);
            this.Tab_Section_Mods.Controls.Add(this.Button_Mods_UpperPriority);
            this.Tab_Section_Mods.Controls.Add(this.Button_Mods_DeselectAll);
            this.Tab_Section_Mods.Controls.Add(this.Button_Mods_SelectAll);
            this.Tab_Section_Mods.Controls.Add(this.Panel_ModBackdrop);
            this.Tab_Section_Mods.Location = new System.Drawing.Point(4, 20);
            this.Tab_Section_Mods.Name = "Tab_Section_Mods";
            this.Tab_Section_Mods.Size = new System.Drawing.Size(591, 1108);
            this.Tab_Section_Mods.TabIndex = 0;
            this.Tab_Section_Mods.Text = "Mods";
            this.Tab_Section_Mods.Visible = false;
            // 
            // SplitContainer_ModsControls
            // 
            this.SplitContainer_ModsControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SplitContainer_ModsControls.IsSplitterFixed = true;
            this.SplitContainer_ModsControls.Location = new System.Drawing.Point(1, 1073);
            this.SplitContainer_ModsControls.Name = "SplitContainer_ModsControls";
            // 
            // SplitContainer_ModsControls.Panel1
            // 
            this.SplitContainer_ModsControls.Panel1.Controls.Add(this.SectionButton_SaveChecks);
            // 
            // SplitContainer_ModsControls.Panel2
            // 
            this.SplitContainer_ModsControls.Panel2.Controls.Add(this.SectionButton_RefreshMods);
            this.SplitContainer_ModsControls.Size = new System.Drawing.Size(586, 35);
            this.SplitContainer_ModsControls.SplitterDistance = 292;
            this.SplitContainer_ModsControls.SplitterWidth = 1;
            this.SplitContainer_ModsControls.TabIndex = 2;
            // 
            // SectionButton_SaveChecks
            // 
            this.SectionButton_SaveChecks.AccentColour = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SectionButton_SaveChecks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SectionButton_SaveChecks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(45)))));
            this.SectionButton_SaveChecks.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SectionButton_SaveChecks.Location = new System.Drawing.Point(2, 0);
            this.SectionButton_SaveChecks.Name = "SectionButton_SaveChecks";
            this.SectionButton_SaveChecks.SectionImage = global::Unify.Properties.Resources.CheckBox_16x_24;
            this.SectionButton_SaveChecks.SectionText = "Save checked mods";
            this.SectionButton_SaveChecks.SelectedSection = false;
            this.SectionButton_SaveChecks.Size = new System.Drawing.Size(398, 35);
            this.SectionButton_SaveChecks.TabIndex = 52;
            this.SectionButton_SaveChecks.TextColour = System.Drawing.SystemColors.Control;
            this.SectionButton_SaveChecks.Click += new System.EventHandler(this.SectionButton_SaveChecks_Click);
            // 
            // SectionButton_RefreshMods
            // 
            this.SectionButton_RefreshMods.AccentColour = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SectionButton_RefreshMods.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SectionButton_RefreshMods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(45)))));
            this.SectionButton_RefreshMods.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SectionButton_RefreshMods.Location = new System.Drawing.Point(0, 0);
            this.SectionButton_RefreshMods.Name = "SectionButton_RefreshMods";
            this.SectionButton_RefreshMods.SectionImage = ((System.Drawing.Bitmap)(resources.GetObject("SectionButton_RefreshMods.SectionImage")));
            this.SectionButton_RefreshMods.SectionText = "Refresh mods list";
            this.SectionButton_RefreshMods.SelectedSection = false;
            this.SectionButton_RefreshMods.Size = new System.Drawing.Size(2459, 35);
            this.SectionButton_RefreshMods.TabIndex = 52;
            this.SectionButton_RefreshMods.TextColour = System.Drawing.SystemColors.Control;
            this.SectionButton_RefreshMods.Click += new System.EventHandler(this.SectionButton_Refresh_Click);
            // 
            // Button_Mods_Priority
            // 
            this.Button_Mods_Priority.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Mods_Priority.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Button_Mods_Priority.FlatAppearance.BorderSize = 0;
            this.Button_Mods_Priority.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Mods_Priority.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Button_Mods_Priority.Location = new System.Drawing.Point(409, 1044);
            this.Button_Mods_Priority.Name = "Button_Mods_Priority";
            this.Button_Mods_Priority.Size = new System.Drawing.Size(178, 23);
            this.Button_Mods_Priority.TabIndex = 49;
            this.Button_Mods_Priority.Text = "Priority: Top to Bottom";
            this.Button_Mods_Priority.UseVisualStyleBackColor = false;
            this.Button_Mods_Priority.Click += new System.EventHandler(this.Button_Priority_Click);
            // 
            // Button_Mods_DeselectAll
            // 
            this.Button_Mods_DeselectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Button_Mods_DeselectAll.BackColor = System.Drawing.Color.Tomato;
            this.Button_Mods_DeselectAll.FlatAppearance.BorderSize = 0;
            this.Button_Mods_DeselectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Mods_DeselectAll.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Button_Mods_DeselectAll.Location = new System.Drawing.Point(175, 1044);
            this.Button_Mods_DeselectAll.Name = "Button_Mods_DeselectAll";
            this.Button_Mods_DeselectAll.Size = new System.Drawing.Size(165, 23);
            this.Button_Mods_DeselectAll.TabIndex = 46;
            this.Button_Mods_DeselectAll.Text = "Deselect All";
            this.Button_Mods_DeselectAll.UseVisualStyleBackColor = false;
            this.Button_Mods_DeselectAll.Click += new System.EventHandler(this.Button_Selection_Click);
            // 
            // Button_Mods_SelectAll
            // 
            this.Button_Mods_SelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Button_Mods_SelectAll.BackColor = System.Drawing.Color.SkyBlue;
            this.Button_Mods_SelectAll.FlatAppearance.BorderSize = 0;
            this.Button_Mods_SelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Mods_SelectAll.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Button_Mods_SelectAll.Location = new System.Drawing.Point(3, 1044);
            this.Button_Mods_SelectAll.Name = "Button_Mods_SelectAll";
            this.Button_Mods_SelectAll.Size = new System.Drawing.Size(166, 23);
            this.Button_Mods_SelectAll.TabIndex = 45;
            this.Button_Mods_SelectAll.Text = "Select All";
            this.Button_Mods_SelectAll.UseVisualStyleBackColor = false;
            this.Button_Mods_SelectAll.Click += new System.EventHandler(this.Button_Selection_Click);
            // 
            // Panel_ModBackdrop
            // 
            this.Panel_ModBackdrop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_ModBackdrop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Panel_ModBackdrop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel_ModBackdrop.Controls.Add(this.ListView_ModsList);
            this.Panel_ModBackdrop.Location = new System.Drawing.Point(3, 4);
            this.Panel_ModBackdrop.Name = "Panel_ModBackdrop";
            this.Panel_ModBackdrop.Size = new System.Drawing.Size(584, 1034);
            this.Panel_ModBackdrop.TabIndex = 44;
            // 
            // ListView_ModsList
            // 
            this.ListView_ModsList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.ListView_ModsList.AllowDrop = true;
            this.ListView_ModsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListView_ModsList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ListView_ModsList.BackgroundImageTiled = true;
            this.ListView_ModsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListView_ModsList.CheckBoxes = true;
            this.ListView_ModsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Column_ModsList_Title,
            this.Column_ModsList_Version,
            this.Column_ModsList_Author,
            this.Column_ModsList_System,
            this.Column_ModsList_Merge,
            this.Column_ModsList_Blank});
            this.ListView_ModsList.ForeColor = System.Drawing.SystemColors.Control;
            this.ListView_ModsList.FullRowSelect = true;
            this.ListView_ModsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListView_ModsList.HideSelection = false;
            this.ListView_ModsList.Location = new System.Drawing.Point(0, 0);
            this.ListView_ModsList.MultiSelect = false;
            this.ListView_ModsList.Name = "ListView_ModsList";
            this.ListView_ModsList.OwnerDraw = true;
            this.ListView_ModsList.Size = new System.Drawing.Size(582, 1049);
            this.ListView_ModsList.TabIndex = 1;
            this.ListView_ModsList.UseCompatibleStateImageBehavior = false;
            this.ListView_ModsList.View = System.Windows.Forms.View.Details;
            this.ListView_ModsList.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.ListView_DrawColumnHeader);
            this.ListView_ModsList.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.ListView_DrawItem);
            this.ListView_ModsList.SelectedIndexChanged += new System.EventHandler(this.ListView_ContentList_SelectedIndexChanged);
            this.ListView_ModsList.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListView_DragDrop);
            this.ListView_ModsList.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListView_DragEnter);
            this.ListView_ModsList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListView_MouseClick);
            this.ListView_ModsList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ListView_MouseUp);
            // 
            // Column_ModsList_Title
            // 
            this.Column_ModsList_Title.Text = "Title";
            this.Column_ModsList_Title.Width = 250;
            // 
            // Column_ModsList_Version
            // 
            this.Column_ModsList_Version.Text = "Version";
            this.Column_ModsList_Version.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Column_ModsList_Version.Width = 52;
            // 
            // Column_ModsList_Author
            // 
            this.Column_ModsList_Author.Text = "Author";
            this.Column_ModsList_Author.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Column_ModsList_Author.Width = 100;
            // 
            // Column_ModsList_System
            // 
            this.Column_ModsList_System.Text = "System";
            this.Column_ModsList_System.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Column_ModsList_System.Width = 85;
            // 
            // Column_ModsList_Merge
            // 
            this.Column_ModsList_Merge.Text = "Merge";
            this.Column_ModsList_Merge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Column_ModsList_Merge.Width = 50;
            // 
            // Column_ModsList_Blank
            // 
            this.Column_ModsList_Blank.Text = "";
            this.Column_ModsList_Blank.Width = 1000;
            // 
            // Tab_Section_Emulator
            // 
            this.Tab_Section_Emulator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Tab_Section_Emulator.Controls.Add(this.Label_Description_Resolution);
            this.Tab_Section_Emulator.Controls.Add(this.Label_Resolution);
            this.Tab_Section_Emulator.Controls.Add(this.ComboBox_Resolution);
            this.Tab_Section_Emulator.Controls.Add(this.label1);
            this.Tab_Section_Emulator.Controls.Add(this.TextBox_Arguments);
            this.Tab_Section_Emulator.Controls.Add(this.label2);
            this.Tab_Section_Emulator.Controls.Add(this.Label_Description_UserLanguage);
            this.Tab_Section_Emulator.Controls.Add(this.Label_UserLanguage);
            this.Tab_Section_Emulator.Controls.Add(this.ComboBox_UserLanguage);
            this.Tab_Section_Emulator.Controls.Add(this.Label_Description_DiscordRPC);
            this.Tab_Section_Emulator.Controls.Add(this.Label_Description_Fullscreen);
            this.Tab_Section_Emulator.Controls.Add(this.Label_Description_Gamma);
            this.Tab_Section_Emulator.Controls.Add(this.Label_Description_VerticalSync);
            this.Tab_Section_Emulator.Controls.Add(this.Label_Description_API);
            this.Tab_Section_Emulator.Controls.Add(this.Button_Open_SaveData);
            this.Tab_Section_Emulator.Controls.Add(this.Button_Open_EmulatorExecutable);
            this.Tab_Section_Emulator.Controls.Add(this.Label_RPCS3Warning);
            this.Tab_Section_Emulator.Controls.Add(this.CheckBox_Xenia_DiscordRPC);
            this.Tab_Section_Emulator.Controls.Add(this.CheckBox_Xenia_Fullscreen);
            this.Tab_Section_Emulator.Controls.Add(this.CheckBox_Xenia_Gamma);
            this.Tab_Section_Emulator.Controls.Add(this.CheckBox_Xenia_VerticalSync);
            this.Tab_Section_Emulator.Controls.Add(this.Label_API);
            this.Tab_Section_Emulator.Controls.Add(this.ComboBox_API);
            this.Tab_Section_Emulator.Controls.Add(this.Label_Subtitle_Emulator_Options);
            this.Tab_Section_Emulator.Controls.Add(this.TextBox_SaveData);
            this.Tab_Section_Emulator.Controls.Add(this.Label_Description_EmulatorExecutable);
            this.Tab_Section_Emulator.Controls.Add(this.Button_SaveData);
            this.Tab_Section_Emulator.Controls.Add(this.Label_Description_SaveData);
            this.Tab_Section_Emulator.Controls.Add(this.Label_Subtitle_Emulator_Paths);
            this.Tab_Section_Emulator.Controls.Add(this.Button_EmulatorExecutable);
            this.Tab_Section_Emulator.Controls.Add(this.TextBox_EmulatorExecutable);
            this.Tab_Section_Emulator.Controls.Add(this.Label_EmulatorExecutable);
            this.Tab_Section_Emulator.Controls.Add(this.Label_SaveData);
            this.Tab_Section_Emulator.Controls.Add(this.Label_Optional_SaveData);
            this.Tab_Section_Emulator.Location = new System.Drawing.Point(4, 20);
            this.Tab_Section_Emulator.Name = "Tab_Section_Emulator";
            this.Tab_Section_Emulator.Size = new System.Drawing.Size(591, 1108);
            this.Tab_Section_Emulator.TabIndex = 1;
            this.Tab_Section_Emulator.Text = "Emulator";
            this.Tab_Section_Emulator.Visible = false;
            // 
            // Label_Description_Resolution
            // 
            this.Label_Description_Resolution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Description_Resolution.AutoSize = true;
            this.Label_Description_Resolution.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Description_Resolution.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Label_Description_Resolution.Location = new System.Drawing.Point(427, 359);
            this.Label_Description_Resolution.Name = "Label_Description_Resolution";
            this.Label_Description_Resolution.Size = new System.Drawing.Size(147, 15);
            this.Label_Description_Resolution.TabIndex = 160;
            this.Label_Description_Resolution.Text = "The resolution to render at.";
            // 
            // Label_Resolution
            // 
            this.Label_Resolution.AutoSize = true;
            this.Label_Resolution.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Label_Resolution.Location = new System.Drawing.Point(11, 357);
            this.Label_Resolution.Name = "Label_Resolution";
            this.Label_Resolution.Size = new System.Drawing.Size(69, 17);
            this.Label_Resolution.TabIndex = 159;
            this.Label_Resolution.Text = "Resolution";
            // 
            // ComboBox_Resolution
            // 
            this.ComboBox_Resolution.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBox_Resolution.BackColor = System.Drawing.SystemColors.Window;
            this.ComboBox_Resolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_Resolution.FormattingEnabled = true;
            this.ComboBox_Resolution.Items.AddRange(new object[] {
            "1280x720",
            "2560x1440",
            "3840x2160"});
            this.ComboBox_Resolution.Location = new System.Drawing.Point(14, 379);
            this.ComboBox_Resolution.Name = "ComboBox_Resolution";
            this.ComboBox_Resolution.Size = new System.Drawing.Size(560, 23);
            this.ComboBox_Resolution.TabIndex = 158;
            this.ComboBox_Resolution.SelectedIndexChanged += new System.EventHandler(this.ComboBox_Emulator_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(212, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(363, 15);
            this.label1.TabIndex = 157;
            this.label1.Text = "User-specific arguments that are fed into the emulator upon launch.";
            // 
            // TextBox_Arguments
            // 
            this.TextBox_Arguments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Arguments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.TextBox_Arguments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBox_Arguments.ForeColor = System.Drawing.SystemColors.Control;
            this.TextBox_Arguments.Location = new System.Drawing.Point(14, 174);
            this.TextBox_Arguments.Name = "TextBox_Arguments";
            this.TextBox_Arguments.Size = new System.Drawing.Size(560, 23);
            this.TextBox_Arguments.TabIndex = 155;
            this.TextBox_Arguments.TextChanged += new System.EventHandler(this.TextBox_Arguments_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label2.Location = new System.Drawing.Point(11, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 154;
            this.label2.Text = "Arguments";
            // 
            // Label_Description_UserLanguage
            // 
            this.Label_Description_UserLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Description_UserLanguage.AutoSize = true;
            this.Label_Description_UserLanguage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Description_UserLanguage.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Label_Description_UserLanguage.Location = new System.Drawing.Point(370, 307);
            this.Label_Description_UserLanguage.Name = "Label_Description_UserLanguage";
            this.Label_Description_UserLanguage.Size = new System.Drawing.Size(204, 15);
            this.Label_Description_UserLanguage.TabIndex = 153;
            this.Label_Description_UserLanguage.Text = "The system language to be emulated.";
            // 
            // Label_UserLanguage
            // 
            this.Label_UserLanguage.AutoSize = true;
            this.Label_UserLanguage.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Label_UserLanguage.Location = new System.Drawing.Point(11, 305);
            this.Label_UserLanguage.Name = "Label_UserLanguage";
            this.Label_UserLanguage.Size = new System.Drawing.Size(65, 17);
            this.Label_UserLanguage.TabIndex = 152;
            this.Label_UserLanguage.Text = "Language";
            // 
            // ComboBox_UserLanguage
            // 
            this.ComboBox_UserLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBox_UserLanguage.BackColor = System.Drawing.SystemColors.Window;
            this.ComboBox_UserLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_UserLanguage.FormattingEnabled = true;
            this.ComboBox_UserLanguage.Items.AddRange(new object[] {
            "English",
            "Japanese",
            "German",
            "French",
            "Spanish",
            "Italian",
            "Korean",
            "Chinese (Simplified)",
            "Portuguese",
            "Polish",
            "Russian",
            "Swedish",
            "Turkish",
            "Norwegian",
            "Dutch",
            "Chinese (Traditional)"});
            this.ComboBox_UserLanguage.Location = new System.Drawing.Point(14, 327);
            this.ComboBox_UserLanguage.Name = "ComboBox_UserLanguage";
            this.ComboBox_UserLanguage.Size = new System.Drawing.Size(560, 23);
            this.ComboBox_UserLanguage.TabIndex = 151;
            this.ComboBox_UserLanguage.SelectedIndexChanged += new System.EventHandler(this.ComboBox_Emulator_SelectedIndexChanged);
            // 
            // Label_Description_DiscordRPC
            // 
            this.Label_Description_DiscordRPC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Description_DiscordRPC.AutoSize = true;
            this.Label_Description_DiscordRPC.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Description_DiscordRPC.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Label_Description_DiscordRPC.Location = new System.Drawing.Point(368, 492);
            this.Label_Description_DiscordRPC.Name = "Label_Description_DiscordRPC";
            this.Label_Description_DiscordRPC.Size = new System.Drawing.Size(206, 15);
            this.Label_Description_DiscordRPC.TabIndex = 150;
            this.Label_Description_DiscordRPC.Text = "Displays the current game on Discord.";
            // 
            // Label_Description_Fullscreen
            // 
            this.Label_Description_Fullscreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Description_Fullscreen.AutoSize = true;
            this.Label_Description_Fullscreen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Description_Fullscreen.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Label_Description_Fullscreen.Location = new System.Drawing.Point(378, 467);
            this.Label_Description_Fullscreen.Name = "Label_Description_Fullscreen";
            this.Label_Description_Fullscreen.Size = new System.Drawing.Size(196, 15);
            this.Label_Description_Fullscreen.TabIndex = 149;
            this.Label_Description_Fullscreen.Text = "Launches the emulator in fullscreen.";
            // 
            // Label_Description_Gamma
            // 
            this.Label_Description_Gamma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Description_Gamma.AutoSize = true;
            this.Label_Description_Gamma.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Description_Gamma.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Label_Description_Gamma.Location = new System.Drawing.Point(207, 442);
            this.Label_Description_Gamma.Name = "Label_Description_Gamma";
            this.Label_Description_Gamma.Size = new System.Drawing.Size(368, 15);
            this.Label_Description_Gamma.TabIndex = 148;
            this.Label_Description_Gamma.Text = "Forces gamma on, resulting in more accurate colours (recommended).";
            // 
            // Label_Description_VerticalSync
            // 
            this.Label_Description_VerticalSync.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Description_VerticalSync.AutoSize = true;
            this.Label_Description_VerticalSync.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Description_VerticalSync.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Label_Description_VerticalSync.Location = new System.Drawing.Point(225, 417);
            this.Label_Description_VerticalSync.Name = "Label_Description_VerticalSync";
            this.Label_Description_VerticalSync.Size = new System.Drawing.Size(349, 15);
            this.Label_Description_VerticalSync.TabIndex = 147;
            this.Label_Description_VerticalSync.Text = "Locks the framerate respective to the game\'s cap (recommended).";
            // 
            // Label_Description_API
            // 
            this.Label_Description_API.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Description_API.AutoSize = true;
            this.Label_Description_API.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Description_API.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Label_Description_API.Location = new System.Drawing.Point(339, 255);
            this.Label_Description_API.Name = "Label_Description_API";
            this.Label_Description_API.Size = new System.Drawing.Size(235, 15);
            this.Label_Description_API.TabIndex = 144;
            this.Label_Description_API.Text = "The API the emulator will use as a backend.";
            // 
            // Button_Open_SaveData
            // 
            this.Button_Open_SaveData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Open_SaveData.FlatAppearance.BorderSize = 0;
            this.Button_Open_SaveData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Button_Open_SaveData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Button_Open_SaveData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Open_SaveData.Image = ((System.Drawing.Image)(resources.GetObject("Button_Open_SaveData.Image")));
            this.Button_Open_SaveData.Location = new System.Drawing.Point(554, 122);
            this.Button_Open_SaveData.Name = "Button_Open_SaveData";
            this.Button_Open_SaveData.Size = new System.Drawing.Size(21, 20);
            this.Button_Open_SaveData.TabIndex = 143;
            this.Button_Open_SaveData.UseVisualStyleBackColor = true;
            this.Button_Open_SaveData.Click += new System.EventHandler(this.Button_Open_Click);
            // 
            // Button_Open_EmulatorExecutable
            // 
            this.Button_Open_EmulatorExecutable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Open_EmulatorExecutable.FlatAppearance.BorderSize = 0;
            this.Button_Open_EmulatorExecutable.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Button_Open_EmulatorExecutable.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Button_Open_EmulatorExecutable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Open_EmulatorExecutable.Image = ((System.Drawing.Image)(resources.GetObject("Button_Open_EmulatorExecutable.Image")));
            this.Button_Open_EmulatorExecutable.Location = new System.Drawing.Point(554, 70);
            this.Button_Open_EmulatorExecutable.Name = "Button_Open_EmulatorExecutable";
            this.Button_Open_EmulatorExecutable.Size = new System.Drawing.Size(21, 20);
            this.Button_Open_EmulatorExecutable.TabIndex = 142;
            this.Button_Open_EmulatorExecutable.UseVisualStyleBackColor = true;
            this.Button_Open_EmulatorExecutable.Click += new System.EventHandler(this.Button_Open_Click);
            // 
            // Label_RPCS3Warning
            // 
            this.Label_RPCS3Warning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_RPCS3Warning.AutoSize = true;
            this.Label_RPCS3Warning.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_RPCS3Warning.ForeColor = System.Drawing.Color.Tomato;
            this.Label_RPCS3Warning.Location = new System.Drawing.Point(271, 222);
            this.Label_RPCS3Warning.Name = "Label_RPCS3Warning";
            this.Label_RPCS3Warning.Size = new System.Drawing.Size(303, 15);
            this.Label_RPCS3Warning.TabIndex = 67;
            this.Label_RPCS3Warning.Text = "RPCS3 does not support these command line arguments!";
            this.Label_RPCS3Warning.Visible = false;
            // 
            // CheckBox_Xenia_DiscordRPC
            // 
            this.CheckBox_Xenia_DiscordRPC.AutoSize = true;
            this.CheckBox_Xenia_DiscordRPC.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox_Xenia_DiscordRPC.Location = new System.Drawing.Point(14, 491);
            this.CheckBox_Xenia_DiscordRPC.Name = "CheckBox_Xenia_DiscordRPC";
            this.CheckBox_Xenia_DiscordRPC.Size = new System.Drawing.Size(142, 19);
            this.CheckBox_Xenia_DiscordRPC.TabIndex = 66;
            this.CheckBox_Xenia_DiscordRPC.Text = "Discord Rich Presence";
            this.CheckBox_Xenia_DiscordRPC.UseVisualStyleBackColor = false;
            this.CheckBox_Xenia_DiscordRPC.CheckedChanged += new System.EventHandler(this.CheckBox_Xenia_CheckedChanged);
            // 
            // CheckBox_Xenia_Fullscreen
            // 
            this.CheckBox_Xenia_Fullscreen.AutoSize = true;
            this.CheckBox_Xenia_Fullscreen.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox_Xenia_Fullscreen.Location = new System.Drawing.Point(14, 466);
            this.CheckBox_Xenia_Fullscreen.Name = "CheckBox_Xenia_Fullscreen";
            this.CheckBox_Xenia_Fullscreen.Size = new System.Drawing.Size(134, 19);
            this.CheckBox_Xenia_Fullscreen.TabIndex = 65;
            this.CheckBox_Xenia_Fullscreen.Text = "Launch in Fullscreen";
            this.CheckBox_Xenia_Fullscreen.UseVisualStyleBackColor = false;
            this.CheckBox_Xenia_Fullscreen.CheckedChanged += new System.EventHandler(this.CheckBox_Xenia_CheckedChanged);
            // 
            // CheckBox_Xenia_Gamma
            // 
            this.CheckBox_Xenia_Gamma.AutoSize = true;
            this.CheckBox_Xenia_Gamma.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox_Xenia_Gamma.Location = new System.Drawing.Point(14, 441);
            this.CheckBox_Xenia_Gamma.Name = "CheckBox_Xenia_Gamma";
            this.CheckBox_Xenia_Gamma.Size = new System.Drawing.Size(127, 19);
            this.CheckBox_Xenia_Gamma.TabIndex = 64;
            this.CheckBox_Xenia_Gamma.Text = "Gamma Correction";
            this.CheckBox_Xenia_Gamma.UseVisualStyleBackColor = false;
            this.CheckBox_Xenia_Gamma.CheckedChanged += new System.EventHandler(this.CheckBox_Xenia_CheckedChanged);
            // 
            // CheckBox_Xenia_VerticalSync
            // 
            this.CheckBox_Xenia_VerticalSync.AutoSize = true;
            this.CheckBox_Xenia_VerticalSync.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox_Xenia_VerticalSync.Location = new System.Drawing.Point(14, 416);
            this.CheckBox_Xenia_VerticalSync.Name = "CheckBox_Xenia_VerticalSync";
            this.CheckBox_Xenia_VerticalSync.Size = new System.Drawing.Size(63, 19);
            this.CheckBox_Xenia_VerticalSync.TabIndex = 63;
            this.CheckBox_Xenia_VerticalSync.Text = "V-Sync";
            this.CheckBox_Xenia_VerticalSync.UseVisualStyleBackColor = false;
            this.CheckBox_Xenia_VerticalSync.CheckedChanged += new System.EventHandler(this.CheckBox_Xenia_CheckedChanged);
            // 
            // Label_API
            // 
            this.Label_API.AutoSize = true;
            this.Label_API.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Label_API.Location = new System.Drawing.Point(11, 253);
            this.Label_API.Name = "Label_API";
            this.Label_API.Size = new System.Drawing.Size(26, 17);
            this.Label_API.TabIndex = 60;
            this.Label_API.Text = "API";
            // 
            // ComboBox_API
            // 
            this.ComboBox_API.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBox_API.BackColor = System.Drawing.SystemColors.Window;
            this.ComboBox_API.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_API.FormattingEnabled = true;
            this.ComboBox_API.Items.AddRange(new object[] {
            "DirectX 12",
            "Vulkan",
            "Custom"});
            this.ComboBox_API.Location = new System.Drawing.Point(14, 275);
            this.ComboBox_API.Name = "ComboBox_API";
            this.ComboBox_API.Size = new System.Drawing.Size(560, 23);
            this.ComboBox_API.TabIndex = 59;
            this.ComboBox_API.SelectedIndexChanged += new System.EventHandler(this.ComboBox_Emulator_SelectedIndexChanged);
            // 
            // Label_Subtitle_Emulator_Options
            // 
            this.Label_Subtitle_Emulator_Options.AutoSize = true;
            this.Label_Subtitle_Emulator_Options.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.Label_Subtitle_Emulator_Options.Location = new System.Drawing.Point(9, 216);
            this.Label_Subtitle_Emulator_Options.Name = "Label_Subtitle_Emulator_Options";
            this.Label_Subtitle_Emulator_Options.Size = new System.Drawing.Size(76, 25);
            this.Label_Subtitle_Emulator_Options.TabIndex = 57;
            this.Label_Subtitle_Emulator_Options.Text = "Options";
            // 
            // TextBox_SaveData
            // 
            this.TextBox_SaveData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_SaveData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.TextBox_SaveData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBox_SaveData.ForeColor = System.Drawing.SystemColors.Control;
            this.TextBox_SaveData.Location = new System.Drawing.Point(14, 122);
            this.TextBox_SaveData.Name = "TextBox_SaveData";
            this.TextBox_SaveData.Size = new System.Drawing.Size(504, 23);
            this.TextBox_SaveData.TabIndex = 54;
            // 
            // Label_Description_EmulatorExecutable
            // 
            this.Label_Description_EmulatorExecutable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Description_EmulatorExecutable.AutoSize = true;
            this.Label_Description_EmulatorExecutable.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Description_EmulatorExecutable.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Label_Description_EmulatorExecutable.Location = new System.Drawing.Point(217, 50);
            this.Label_Description_EmulatorExecutable.Name = "Label_Description_EmulatorExecutable";
            this.Label_Description_EmulatorExecutable.Size = new System.Drawing.Size(301, 15);
            this.Label_Description_EmulatorExecutable.TabIndex = 52;
            this.Label_Description_EmulatorExecutable.Text = "Emulator executable file (EXE) - used for Xenia or RPCS3.";
            // 
            // Button_SaveData
            // 
            this.Button_SaveData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_SaveData.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Button_SaveData.FlatAppearance.BorderSize = 0;
            this.Button_SaveData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_SaveData.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Button_SaveData.Location = new System.Drawing.Point(524, 122);
            this.Button_SaveData.Name = "Button_SaveData";
            this.Button_SaveData.Size = new System.Drawing.Size(25, 23);
            this.Button_SaveData.TabIndex = 55;
            this.Button_SaveData.Text = "...";
            this.Button_SaveData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Button_SaveData.UseVisualStyleBackColor = false;
            this.Button_SaveData.Click += new System.EventHandler(this.Button_Browse_Click);
            // 
            // Label_Description_SaveData
            // 
            this.Label_Description_SaveData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Description_SaveData.AutoSize = true;
            this.Label_Description_SaveData.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Description_SaveData.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Label_Description_SaveData.Location = new System.Drawing.Point(211, 102);
            this.Label_Description_SaveData.Name = "Label_Description_SaveData";
            this.Label_Description_SaveData.Size = new System.Drawing.Size(307, 15);
            this.Label_Description_SaveData.TabIndex = 56;
            this.Label_Description_SaveData.Text = "Sonic \'06 save file currently being used with the emulator.";
            // 
            // Label_Subtitle_Emulator_Paths
            // 
            this.Label_Subtitle_Emulator_Paths.AutoSize = true;
            this.Label_Subtitle_Emulator_Paths.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.Label_Subtitle_Emulator_Paths.Location = new System.Drawing.Point(9, 13);
            this.Label_Subtitle_Emulator_Paths.Name = "Label_Subtitle_Emulator_Paths";
            this.Label_Subtitle_Emulator_Paths.Size = new System.Drawing.Size(54, 25);
            this.Label_Subtitle_Emulator_Paths.TabIndex = 48;
            this.Label_Subtitle_Emulator_Paths.Text = "Paths";
            // 
            // Button_EmulatorExecutable
            // 
            this.Button_EmulatorExecutable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_EmulatorExecutable.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Button_EmulatorExecutable.FlatAppearance.BorderSize = 0;
            this.Button_EmulatorExecutable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_EmulatorExecutable.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Button_EmulatorExecutable.Location = new System.Drawing.Point(524, 70);
            this.Button_EmulatorExecutable.Name = "Button_EmulatorExecutable";
            this.Button_EmulatorExecutable.Size = new System.Drawing.Size(25, 23);
            this.Button_EmulatorExecutable.TabIndex = 51;
            this.Button_EmulatorExecutable.Text = "...";
            this.Button_EmulatorExecutable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Button_EmulatorExecutable.UseVisualStyleBackColor = false;
            this.Button_EmulatorExecutable.Click += new System.EventHandler(this.Button_Browse_Click);
            // 
            // TextBox_EmulatorExecutable
            // 
            this.TextBox_EmulatorExecutable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_EmulatorExecutable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.TextBox_EmulatorExecutable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBox_EmulatorExecutable.ForeColor = System.Drawing.SystemColors.Control;
            this.TextBox_EmulatorExecutable.Location = new System.Drawing.Point(14, 70);
            this.TextBox_EmulatorExecutable.Name = "TextBox_EmulatorExecutable";
            this.TextBox_EmulatorExecutable.Size = new System.Drawing.Size(504, 23);
            this.TextBox_EmulatorExecutable.TabIndex = 50;
            // 
            // Label_EmulatorExecutable
            // 
            this.Label_EmulatorExecutable.AutoSize = true;
            this.Label_EmulatorExecutable.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Label_EmulatorExecutable.Location = new System.Drawing.Point(11, 48);
            this.Label_EmulatorExecutable.Name = "Label_EmulatorExecutable";
            this.Label_EmulatorExecutable.Size = new System.Drawing.Size(126, 17);
            this.Label_EmulatorExecutable.TabIndex = 49;
            this.Label_EmulatorExecutable.Text = "Emulator Executable";
            // 
            // Label_SaveData
            // 
            this.Label_SaveData.AutoSize = true;
            this.Label_SaveData.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Label_SaveData.Location = new System.Drawing.Point(11, 100);
            this.Label_SaveData.Name = "Label_SaveData";
            this.Label_SaveData.Size = new System.Drawing.Size(66, 17);
            this.Label_SaveData.TabIndex = 53;
            this.Label_SaveData.Text = "Save Data";
            // 
            // Label_Optional_SaveData
            // 
            this.Label_Optional_SaveData.AutoSize = true;
            this.Label_Optional_SaveData.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Optional_SaveData.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Label_Optional_SaveData.Location = new System.Drawing.Point(74, 100);
            this.Label_Optional_SaveData.Name = "Label_Optional_SaveData";
            this.Label_Optional_SaveData.Size = new System.Drawing.Size(61, 17);
            this.Label_Optional_SaveData.TabIndex = 68;
            this.Label_Optional_SaveData.Text = "(optional)";
            // 
            // Tab_Section_Patches
            // 
            this.Tab_Section_Patches.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Tab_Section_Patches.Controls.Add(this.Button_Patches_Priority);
            this.Tab_Section_Patches.Controls.Add(this.Button_Patches_DownerPriority);
            this.Tab_Section_Patches.Controls.Add(this.Button_Patches_UpperPriority);
            this.Tab_Section_Patches.Controls.Add(this.Button_Patches_DeselectAll);
            this.Tab_Section_Patches.Controls.Add(this.Button_Patches_SelectAll);
            this.Tab_Section_Patches.Controls.Add(this.SplitContainer_PatchesControls);
            this.Tab_Section_Patches.Controls.Add(this.Panel_PatchBackdrop);
            this.Tab_Section_Patches.Location = new System.Drawing.Point(4, 20);
            this.Tab_Section_Patches.Name = "Tab_Section_Patches";
            this.Tab_Section_Patches.Size = new System.Drawing.Size(591, 1108);
            this.Tab_Section_Patches.TabIndex = 2;
            this.Tab_Section_Patches.Text = "Patches";
            this.Tab_Section_Patches.Visible = false;
            // 
            // Button_Patches_Priority
            // 
            this.Button_Patches_Priority.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Patches_Priority.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Button_Patches_Priority.FlatAppearance.BorderSize = 0;
            this.Button_Patches_Priority.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Patches_Priority.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Button_Patches_Priority.Location = new System.Drawing.Point(409, 1044);
            this.Button_Patches_Priority.Name = "Button_Patches_Priority";
            this.Button_Patches_Priority.Size = new System.Drawing.Size(178, 23);
            this.Button_Patches_Priority.TabIndex = 56;
            this.Button_Patches_Priority.Text = "Priority: Top to Bottom";
            this.Button_Patches_Priority.UseVisualStyleBackColor = false;
            this.Button_Patches_Priority.Click += new System.EventHandler(this.Button_Priority_Click);
            // 
            // Button_Patches_DeselectAll
            // 
            this.Button_Patches_DeselectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Button_Patches_DeselectAll.BackColor = System.Drawing.Color.Tomato;
            this.Button_Patches_DeselectAll.FlatAppearance.BorderSize = 0;
            this.Button_Patches_DeselectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Patches_DeselectAll.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Button_Patches_DeselectAll.Location = new System.Drawing.Point(175, 1044);
            this.Button_Patches_DeselectAll.Name = "Button_Patches_DeselectAll";
            this.Button_Patches_DeselectAll.Size = new System.Drawing.Size(165, 23);
            this.Button_Patches_DeselectAll.TabIndex = 48;
            this.Button_Patches_DeselectAll.Text = "Deselect All";
            this.Button_Patches_DeselectAll.UseVisualStyleBackColor = false;
            this.Button_Patches_DeselectAll.Click += new System.EventHandler(this.Button_Selection_Click);
            // 
            // Button_Patches_SelectAll
            // 
            this.Button_Patches_SelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Button_Patches_SelectAll.BackColor = System.Drawing.Color.SkyBlue;
            this.Button_Patches_SelectAll.FlatAppearance.BorderSize = 0;
            this.Button_Patches_SelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Patches_SelectAll.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Button_Patches_SelectAll.Location = new System.Drawing.Point(3, 1044);
            this.Button_Patches_SelectAll.Name = "Button_Patches_SelectAll";
            this.Button_Patches_SelectAll.Size = new System.Drawing.Size(166, 23);
            this.Button_Patches_SelectAll.TabIndex = 47;
            this.Button_Patches_SelectAll.Text = "Select All";
            this.Button_Patches_SelectAll.UseVisualStyleBackColor = false;
            this.Button_Patches_SelectAll.Click += new System.EventHandler(this.Button_Selection_Click);
            // 
            // SplitContainer_PatchesControls
            // 
            this.SplitContainer_PatchesControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SplitContainer_PatchesControls.IsSplitterFixed = true;
            this.SplitContainer_PatchesControls.Location = new System.Drawing.Point(1, 1073);
            this.SplitContainer_PatchesControls.Name = "SplitContainer_PatchesControls";
            // 
            // SplitContainer_PatchesControls.Panel1
            // 
            this.SplitContainer_PatchesControls.Panel1.Controls.Add(this.SectionButton_SaveCheckedPatches);
            // 
            // SplitContainer_PatchesControls.Panel2
            // 
            this.SplitContainer_PatchesControls.Panel2.Controls.Add(this.SectionButton_RefreshPatches);
            this.SplitContainer_PatchesControls.Size = new System.Drawing.Size(586, 35);
            this.SplitContainer_PatchesControls.SplitterDistance = 292;
            this.SplitContainer_PatchesControls.SplitterWidth = 1;
            this.SplitContainer_PatchesControls.TabIndex = 53;
            // 
            // SectionButton_SaveCheckedPatches
            // 
            this.SectionButton_SaveCheckedPatches.AccentColour = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SectionButton_SaveCheckedPatches.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SectionButton_SaveCheckedPatches.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(45)))));
            this.SectionButton_SaveCheckedPatches.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SectionButton_SaveCheckedPatches.Location = new System.Drawing.Point(2, 0);
            this.SectionButton_SaveCheckedPatches.Name = "SectionButton_SaveCheckedPatches";
            this.SectionButton_SaveCheckedPatches.SectionImage = global::Unify.Properties.Resources.CheckBox_16x_24;
            this.SectionButton_SaveCheckedPatches.SectionText = "Save checked patches";
            this.SectionButton_SaveCheckedPatches.SelectedSection = false;
            this.SectionButton_SaveCheckedPatches.Size = new System.Drawing.Size(398, 35);
            this.SectionButton_SaveCheckedPatches.TabIndex = 52;
            this.SectionButton_SaveCheckedPatches.TextColour = System.Drawing.SystemColors.Control;
            this.SectionButton_SaveCheckedPatches.Click += new System.EventHandler(this.SectionButton_SaveChecks_Click);
            // 
            // SectionButton_RefreshPatches
            // 
            this.SectionButton_RefreshPatches.AccentColour = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SectionButton_RefreshPatches.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SectionButton_RefreshPatches.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(45)))));
            this.SectionButton_RefreshPatches.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SectionButton_RefreshPatches.Location = new System.Drawing.Point(0, 0);
            this.SectionButton_RefreshPatches.Name = "SectionButton_RefreshPatches";
            this.SectionButton_RefreshPatches.SectionImage = ((System.Drawing.Bitmap)(resources.GetObject("SectionButton_RefreshPatches.SectionImage")));
            this.SectionButton_RefreshPatches.SectionText = "Refresh patches list";
            this.SectionButton_RefreshPatches.SelectedSection = false;
            this.SectionButton_RefreshPatches.Size = new System.Drawing.Size(1856, 35);
            this.SectionButton_RefreshPatches.TabIndex = 52;
            this.SectionButton_RefreshPatches.TextColour = System.Drawing.SystemColors.Control;
            this.SectionButton_RefreshPatches.Click += new System.EventHandler(this.SectionButton_Refresh_Click);
            // 
            // Panel_PatchBackdrop
            // 
            this.Panel_PatchBackdrop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_PatchBackdrop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Panel_PatchBackdrop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel_PatchBackdrop.Controls.Add(this.ListView_PatchesList);
            this.Panel_PatchBackdrop.Location = new System.Drawing.Point(3, 4);
            this.Panel_PatchBackdrop.Name = "Panel_PatchBackdrop";
            this.Panel_PatchBackdrop.Size = new System.Drawing.Size(584, 1034);
            this.Panel_PatchBackdrop.TabIndex = 45;
            // 
            // ListView_PatchesList
            // 
            this.ListView_PatchesList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.ListView_PatchesList.AllowDrop = true;
            this.ListView_PatchesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListView_PatchesList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ListView_PatchesList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListView_PatchesList.CheckBoxes = true;
            this.ListView_PatchesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Column_PatchesList_Title,
            this.Column_PatchesList_Author,
            this.Column_PatchesList_System,
            this.Column_PatchesList_Blurb,
            this.Column_PatchesList_Blank});
            this.ListView_PatchesList.ForeColor = System.Drawing.SystemColors.Control;
            this.ListView_PatchesList.FullRowSelect = true;
            this.ListView_PatchesList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListView_PatchesList.HideSelection = false;
            this.ListView_PatchesList.Location = new System.Drawing.Point(0, 0);
            this.ListView_PatchesList.MultiSelect = false;
            this.ListView_PatchesList.Name = "ListView_PatchesList";
            this.ListView_PatchesList.OwnerDraw = true;
            this.ListView_PatchesList.Size = new System.Drawing.Size(582, 1049);
            this.ListView_PatchesList.TabIndex = 1;
            this.ListView_PatchesList.UseCompatibleStateImageBehavior = false;
            this.ListView_PatchesList.View = System.Windows.Forms.View.Details;
            this.ListView_PatchesList.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.ListView_DrawColumnHeader);
            this.ListView_PatchesList.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.ListView_DrawItem);
            this.ListView_PatchesList.SelectedIndexChanged += new System.EventHandler(this.ListView_ContentList_SelectedIndexChanged);
            this.ListView_PatchesList.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListView_DragDrop);
            this.ListView_PatchesList.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListView_DragEnter);
            this.ListView_PatchesList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListView_MouseClick);
            this.ListView_PatchesList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ListView_MouseUp);
            // 
            // Column_PatchesList_Title
            // 
            this.Column_PatchesList_Title.Text = "Title";
            this.Column_PatchesList_Title.Width = 159;
            // 
            // Column_PatchesList_Author
            // 
            this.Column_PatchesList_Author.Text = "Author";
            this.Column_PatchesList_Author.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Column_PatchesList_Author.Width = 90;
            // 
            // Column_PatchesList_System
            // 
            this.Column_PatchesList_System.Text = "System";
            this.Column_PatchesList_System.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Column_PatchesList_System.Width = 90;
            // 
            // Column_PatchesList_Blurb
            // 
            this.Column_PatchesList_Blurb.Text = "Blurb";
            this.Column_PatchesList_Blurb.Width = 243;
            // 
            // Column_PatchesList_Blank
            // 
            this.Column_PatchesList_Blank.Text = "";
            this.Column_PatchesList_Blank.Width = 904;
            // 
            // Tab_Section_Tweaks
            // 
            this.Tab_Section_Tweaks.AutoScroll = true;
            this.Tab_Section_Tweaks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Tab_Section_Tweaks.Controls.Add(this.Button_BeginWithRings_Default);
            this.Tab_Section_Tweaks.Controls.Add(this.Label_Description_BeginWithRings);
            this.Tab_Section_Tweaks.Controls.Add(this.Label_BeginWithRings);
            this.Tab_Section_Tweaks.Controls.Add(this.NumericUpDown_BeginWithRings);
            this.Tab_Section_Tweaks.Controls.Add(this.Button_AmyHammerRange_Default);
            this.Tab_Section_Tweaks.Controls.Add(this.Button_FieldOfView_Default);
            this.Tab_Section_Tweaks.Controls.Add(this.Button_CameraHeight_Default);
            this.Tab_Section_Tweaks.Controls.Add(this.Button_CameraDistance_Default);
            this.Tab_Section_Tweaks.Controls.Add(this.Button_CameraType_Default);
            this.Tab_Section_Tweaks.Controls.Add(this.Button_AntiAliasing_Default);
            this.Tab_Section_Tweaks.Controls.Add(this.Button_Reflections_Default);
            this.Tab_Section_Tweaks.Controls.Add(this.Button_Renderer_Default);
            this.Tab_Section_Tweaks.Controls.Add(this.Label_Description_AmyHammerRange);
            this.Tab_Section_Tweaks.Controls.Add(this.Label_AmyHammerRange);
            this.Tab_Section_Tweaks.Controls.Add(this.Label_Subtitle_CharacterTweaks);
            this.Tab_Section_Tweaks.Controls.Add(this.Label_Description_FieldOfView);
            this.Tab_Section_Tweaks.Controls.Add(this.Label_FieldOfView);
            this.Tab_Section_Tweaks.Controls.Add(this.NumericUpDown_FieldOfView);
            this.Tab_Section_Tweaks.Controls.Add(this.Label_Description_CameraHeight);
            this.Tab_Section_Tweaks.Controls.Add(this.Label_CameraHeight);
            this.Tab_Section_Tweaks.Controls.Add(this.NumericUpDown_CameraHeight);
            this.Tab_Section_Tweaks.Controls.Add(this.Label_Description_CameraDistance);
            this.Tab_Section_Tweaks.Controls.Add(this.Label_CameraDistance);
            this.Tab_Section_Tweaks.Controls.Add(this.NumericUpDown_CameraDistance);
            this.Tab_Section_Tweaks.Controls.Add(this.Label_Description_CameraType);
            this.Tab_Section_Tweaks.Controls.Add(this.Label_CameraType);
            this.Tab_Section_Tweaks.Controls.Add(this.ComboBox_CameraType);
            this.Tab_Section_Tweaks.Controls.Add(this.Label_Subtitle_CameraTweaks);
            this.Tab_Section_Tweaks.Controls.Add(this.Label_Description_ForceMSAA);
            this.Tab_Section_Tweaks.Controls.Add(this.CheckBox_ForceMSAA);
            this.Tab_Section_Tweaks.Controls.Add(this.Label_Description_AntiAliasing);
            this.Tab_Section_Tweaks.Controls.Add(this.Label_AntiAliasing);
            this.Tab_Section_Tweaks.Controls.Add(this.ComboBox_AntiAliasing);
            this.Tab_Section_Tweaks.Controls.Add(this.Label_Description_Reflections);
            this.Tab_Section_Tweaks.Controls.Add(this.Label_Reflections);
            this.Tab_Section_Tweaks.Controls.Add(this.ComboBox_Reflections);
            this.Tab_Section_Tweaks.Controls.Add(this.Label_Description_Renderer);
            this.Tab_Section_Tweaks.Controls.Add(this.Label_Renderer);
            this.Tab_Section_Tweaks.Controls.Add(this.ComboBox_Renderer);
            this.Tab_Section_Tweaks.Controls.Add(this.Label_Subtitle_GraphicsTweaks);
            this.Tab_Section_Tweaks.Controls.Add(this.NumericUpDown_AmyHammerRange);
            this.Tab_Section_Tweaks.Controls.Add(this.Panel_Tweaks_UICleanSpace);
            this.Tab_Section_Tweaks.Location = new System.Drawing.Point(4, 20);
            this.Tab_Section_Tweaks.Name = "Tab_Section_Tweaks";
            this.Tab_Section_Tweaks.Size = new System.Drawing.Size(591, 1108);
            this.Tab_Section_Tweaks.TabIndex = 7;
            this.Tab_Section_Tweaks.Tag = "HideControls";
            this.Tab_Section_Tweaks.Text = "Tweaks";
            // 
            // Button_BeginWithRings_Default
            // 
            this.Button_BeginWithRings_Default.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_BeginWithRings_Default.FlatAppearance.BorderSize = 0;
            this.Button_BeginWithRings_Default.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Button_BeginWithRings_Default.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Button_BeginWithRings_Default.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_BeginWithRings_Default.Image = ((System.Drawing.Image)(resources.GetObject("Button_BeginWithRings_Default.Image")));
            this.Button_BeginWithRings_Default.Location = new System.Drawing.Point(554, 630);
            this.Button_BeginWithRings_Default.Name = "Button_BeginWithRings_Default";
            this.Button_BeginWithRings_Default.Size = new System.Drawing.Size(21, 20);
            this.Button_BeginWithRings_Default.TabIndex = 188;
            this.Button_BeginWithRings_Default.UseVisualStyleBackColor = true;
            this.Button_BeginWithRings_Default.Click += new System.EventHandler(this.Button_Tweaks_Default);
            // 
            // Label_Description_BeginWithRings
            // 
            this.Label_Description_BeginWithRings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Description_BeginWithRings.AutoSize = true;
            this.Label_Description_BeginWithRings.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Description_BeginWithRings.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Label_Description_BeginWithRings.Location = new System.Drawing.Point(324, 608);
            this.Label_Description_BeginWithRings.Name = "Label_Description_BeginWithRings";
            this.Label_Description_BeginWithRings.Size = new System.Drawing.Size(224, 15);
            this.Label_Description_BeginWithRings.TabIndex = 186;
            this.Label_Description_BeginWithRings.Text = "Start with Rings when the player spawns.";
            // 
            // Label_BeginWithRings
            // 
            this.Label_BeginWithRings.AutoSize = true;
            this.Label_BeginWithRings.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Label_BeginWithRings.Location = new System.Drawing.Point(11, 606);
            this.Label_BeginWithRings.Name = "Label_BeginWithRings";
            this.Label_BeginWithRings.Size = new System.Drawing.Size(103, 17);
            this.Label_BeginWithRings.TabIndex = 185;
            this.Label_BeginWithRings.Text = "Begin with Rings";
            // 
            // NumericUpDown_BeginWithRings
            // 
            this.NumericUpDown_BeginWithRings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NumericUpDown_BeginWithRings.Location = new System.Drawing.Point(14, 629);
            this.NumericUpDown_BeginWithRings.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.NumericUpDown_BeginWithRings.Name = "NumericUpDown_BeginWithRings";
            this.NumericUpDown_BeginWithRings.Size = new System.Drawing.Size(534, 23);
            this.NumericUpDown_BeginWithRings.TabIndex = 187;
            this.NumericUpDown_BeginWithRings.ValueChanged += new System.EventHandler(this.NumericUpDown_Tweaks_ValueChanged);
            // 
            // Button_AmyHammerRange_Default
            // 
            this.Button_AmyHammerRange_Default.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_AmyHammerRange_Default.FlatAppearance.BorderSize = 0;
            this.Button_AmyHammerRange_Default.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Button_AmyHammerRange_Default.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Button_AmyHammerRange_Default.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_AmyHammerRange_Default.Image = ((System.Drawing.Image)(resources.GetObject("Button_AmyHammerRange_Default.Image")));
            this.Button_AmyHammerRange_Default.Location = new System.Drawing.Point(554, 577);
            this.Button_AmyHammerRange_Default.Name = "Button_AmyHammerRange_Default";
            this.Button_AmyHammerRange_Default.Size = new System.Drawing.Size(21, 20);
            this.Button_AmyHammerRange_Default.TabIndex = 182;
            this.Button_AmyHammerRange_Default.UseVisualStyleBackColor = true;
            this.Button_AmyHammerRange_Default.Click += new System.EventHandler(this.Button_Tweaks_Default);
            // 
            // Button_FieldOfView_Default
            // 
            this.Button_FieldOfView_Default.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_FieldOfView_Default.FlatAppearance.BorderSize = 0;
            this.Button_FieldOfView_Default.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Button_FieldOfView_Default.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Button_FieldOfView_Default.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_FieldOfView_Default.Image = ((System.Drawing.Image)(resources.GetObject("Button_FieldOfView_Default.Image")));
            this.Button_FieldOfView_Default.Location = new System.Drawing.Point(554, 470);
            this.Button_FieldOfView_Default.Name = "Button_FieldOfView_Default";
            this.Button_FieldOfView_Default.Size = new System.Drawing.Size(21, 20);
            this.Button_FieldOfView_Default.TabIndex = 181;
            this.Button_FieldOfView_Default.UseVisualStyleBackColor = true;
            this.Button_FieldOfView_Default.Click += new System.EventHandler(this.Button_Tweaks_Default);
            // 
            // Button_CameraHeight_Default
            // 
            this.Button_CameraHeight_Default.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_CameraHeight_Default.FlatAppearance.BorderSize = 0;
            this.Button_CameraHeight_Default.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Button_CameraHeight_Default.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Button_CameraHeight_Default.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_CameraHeight_Default.Image = ((System.Drawing.Image)(resources.GetObject("Button_CameraHeight_Default.Image")));
            this.Button_CameraHeight_Default.Location = new System.Drawing.Point(554, 418);
            this.Button_CameraHeight_Default.Name = "Button_CameraHeight_Default";
            this.Button_CameraHeight_Default.Size = new System.Drawing.Size(21, 20);
            this.Button_CameraHeight_Default.TabIndex = 180;
            this.Button_CameraHeight_Default.UseVisualStyleBackColor = true;
            this.Button_CameraHeight_Default.Click += new System.EventHandler(this.Button_Tweaks_Default);
            // 
            // Button_CameraDistance_Default
            // 
            this.Button_CameraDistance_Default.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_CameraDistance_Default.FlatAppearance.BorderSize = 0;
            this.Button_CameraDistance_Default.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Button_CameraDistance_Default.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Button_CameraDistance_Default.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_CameraDistance_Default.Image = ((System.Drawing.Image)(resources.GetObject("Button_CameraDistance_Default.Image")));
            this.Button_CameraDistance_Default.Location = new System.Drawing.Point(554, 366);
            this.Button_CameraDistance_Default.Name = "Button_CameraDistance_Default";
            this.Button_CameraDistance_Default.Size = new System.Drawing.Size(21, 20);
            this.Button_CameraDistance_Default.TabIndex = 179;
            this.Button_CameraDistance_Default.UseVisualStyleBackColor = true;
            this.Button_CameraDistance_Default.Click += new System.EventHandler(this.Button_Tweaks_Default);
            // 
            // Button_CameraType_Default
            // 
            this.Button_CameraType_Default.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_CameraType_Default.FlatAppearance.BorderSize = 0;
            this.Button_CameraType_Default.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Button_CameraType_Default.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Button_CameraType_Default.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_CameraType_Default.Image = ((System.Drawing.Image)(resources.GetObject("Button_CameraType_Default.Image")));
            this.Button_CameraType_Default.Location = new System.Drawing.Point(554, 315);
            this.Button_CameraType_Default.Name = "Button_CameraType_Default";
            this.Button_CameraType_Default.Size = new System.Drawing.Size(21, 20);
            this.Button_CameraType_Default.TabIndex = 178;
            this.Button_CameraType_Default.UseVisualStyleBackColor = true;
            this.Button_CameraType_Default.Click += new System.EventHandler(this.Button_Tweaks_Default);
            // 
            // Button_AntiAliasing_Default
            // 
            this.Button_AntiAliasing_Default.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_AntiAliasing_Default.FlatAppearance.BorderSize = 0;
            this.Button_AntiAliasing_Default.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Button_AntiAliasing_Default.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Button_AntiAliasing_Default.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_AntiAliasing_Default.Image = ((System.Drawing.Image)(resources.GetObject("Button_AntiAliasing_Default.Image")));
            this.Button_AntiAliasing_Default.Location = new System.Drawing.Point(554, 176);
            this.Button_AntiAliasing_Default.Name = "Button_AntiAliasing_Default";
            this.Button_AntiAliasing_Default.Size = new System.Drawing.Size(21, 20);
            this.Button_AntiAliasing_Default.TabIndex = 177;
            this.Button_AntiAliasing_Default.UseVisualStyleBackColor = true;
            this.Button_AntiAliasing_Default.Click += new System.EventHandler(this.Button_Tweaks_Default);
            // 
            // Button_Reflections_Default
            // 
            this.Button_Reflections_Default.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Reflections_Default.FlatAppearance.BorderSize = 0;
            this.Button_Reflections_Default.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Button_Reflections_Default.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Button_Reflections_Default.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Reflections_Default.Image = ((System.Drawing.Image)(resources.GetObject("Button_Reflections_Default.Image")));
            this.Button_Reflections_Default.Location = new System.Drawing.Point(554, 124);
            this.Button_Reflections_Default.Name = "Button_Reflections_Default";
            this.Button_Reflections_Default.Size = new System.Drawing.Size(21, 20);
            this.Button_Reflections_Default.TabIndex = 176;
            this.Button_Reflections_Default.UseVisualStyleBackColor = true;
            this.Button_Reflections_Default.Click += new System.EventHandler(this.Button_Tweaks_Default);
            // 
            // Button_Renderer_Default
            // 
            this.Button_Renderer_Default.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Renderer_Default.FlatAppearance.BorderSize = 0;
            this.Button_Renderer_Default.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Button_Renderer_Default.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Button_Renderer_Default.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Renderer_Default.Image = ((System.Drawing.Image)(resources.GetObject("Button_Renderer_Default.Image")));
            this.Button_Renderer_Default.Location = new System.Drawing.Point(554, 72);
            this.Button_Renderer_Default.Name = "Button_Renderer_Default";
            this.Button_Renderer_Default.Size = new System.Drawing.Size(21, 20);
            this.Button_Renderer_Default.TabIndex = 175;
            this.Button_Renderer_Default.UseVisualStyleBackColor = true;
            this.Button_Renderer_Default.Click += new System.EventHandler(this.Button_Tweaks_Default);
            // 
            // Label_Description_AmyHammerRange
            // 
            this.Label_Description_AmyHammerRange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Description_AmyHammerRange.AutoSize = true;
            this.Label_Description_AmyHammerRange.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Description_AmyHammerRange.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Label_Description_AmyHammerRange.Location = new System.Drawing.Point(179, 555);
            this.Label_Description_AmyHammerRange.Name = "Label_Description_AmyHammerRange";
            this.Label_Description_AmyHammerRange.Size = new System.Drawing.Size(369, 15);
            this.Label_Description_AmyHammerRange.TabIndex = 172;
            this.Label_Description_AmyHammerRange.Text = "The range objects are destroyed at in the boundaries of Amy\'s attack.";
            // 
            // Label_AmyHammerRange
            // 
            this.Label_AmyHammerRange.AutoSize = true;
            this.Label_AmyHammerRange.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Label_AmyHammerRange.Location = new System.Drawing.Point(11, 553);
            this.Label_AmyHammerRange.Name = "Label_AmyHammerRange";
            this.Label_AmyHammerRange.Size = new System.Drawing.Size(137, 17);
            this.Label_AmyHammerRange.TabIndex = 171;
            this.Label_AmyHammerRange.Text = "Amy\'s Hammer Range";
            // 
            // Label_Subtitle_CharacterTweaks
            // 
            this.Label_Subtitle_CharacterTweaks.AutoSize = true;
            this.Label_Subtitle_CharacterTweaks.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.Label_Subtitle_CharacterTweaks.Location = new System.Drawing.Point(9, 518);
            this.Label_Subtitle_CharacterTweaks.Name = "Label_Subtitle_CharacterTweaks";
            this.Label_Subtitle_CharacterTweaks.Size = new System.Drawing.Size(147, 25);
            this.Label_Subtitle_CharacterTweaks.TabIndex = 169;
            this.Label_Subtitle_CharacterTweaks.Text = "Character Tweaks";
            // 
            // Label_Description_FieldOfView
            // 
            this.Label_Description_FieldOfView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Description_FieldOfView.AutoSize = true;
            this.Label_Description_FieldOfView.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Description_FieldOfView.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Label_Description_FieldOfView.Location = new System.Drawing.Point(378, 449);
            this.Label_Description_FieldOfView.Name = "Label_Description_FieldOfView";
            this.Label_Description_FieldOfView.Size = new System.Drawing.Size(170, 15);
            this.Label_Description_FieldOfView.TabIndex = 168;
            this.Label_Description_FieldOfView.Text = "How much the camera can see.";
            // 
            // Label_FieldOfView
            // 
            this.Label_FieldOfView.AutoSize = true;
            this.Label_FieldOfView.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Label_FieldOfView.Location = new System.Drawing.Point(11, 447);
            this.Label_FieldOfView.Name = "Label_FieldOfView";
            this.Label_FieldOfView.Size = new System.Drawing.Size(82, 17);
            this.Label_FieldOfView.TabIndex = 167;
            this.Label_FieldOfView.Text = "Field of View";
            // 
            // NumericUpDown_FieldOfView
            // 
            this.NumericUpDown_FieldOfView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NumericUpDown_FieldOfView.DecimalPlaces = 15;
            this.NumericUpDown_FieldOfView.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NumericUpDown_FieldOfView.Location = new System.Drawing.Point(14, 469);
            this.NumericUpDown_FieldOfView.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.NumericUpDown_FieldOfView.Name = "NumericUpDown_FieldOfView";
            this.NumericUpDown_FieldOfView.Size = new System.Drawing.Size(534, 23);
            this.NumericUpDown_FieldOfView.TabIndex = 166;
            this.NumericUpDown_FieldOfView.ValueChanged += new System.EventHandler(this.NumericUpDown_Tweaks_ValueChanged);
            // 
            // Label_Description_CameraHeight
            // 
            this.Label_Description_CameraHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Description_CameraHeight.AutoSize = true;
            this.Label_Description_CameraHeight.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Description_CameraHeight.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Label_Description_CameraHeight.Location = new System.Drawing.Point(246, 397);
            this.Label_Description_CameraHeight.Name = "Label_Description_CameraHeight";
            this.Label_Description_CameraHeight.Size = new System.Drawing.Size(302, 15);
            this.Label_Description_CameraHeight.TabIndex = 165;
            this.Label_Description_CameraHeight.Text = "How high the camera should be in relation to the player.";
            // 
            // Label_CameraHeight
            // 
            this.Label_CameraHeight.AutoSize = true;
            this.Label_CameraHeight.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Label_CameraHeight.Location = new System.Drawing.Point(11, 395);
            this.Label_CameraHeight.Name = "Label_CameraHeight";
            this.Label_CameraHeight.Size = new System.Drawing.Size(95, 17);
            this.Label_CameraHeight.TabIndex = 164;
            this.Label_CameraHeight.Text = "Camera Height";
            // 
            // NumericUpDown_CameraHeight
            // 
            this.NumericUpDown_CameraHeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NumericUpDown_CameraHeight.Location = new System.Drawing.Point(14, 417);
            this.NumericUpDown_CameraHeight.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.NumericUpDown_CameraHeight.Name = "NumericUpDown_CameraHeight";
            this.NumericUpDown_CameraHeight.Size = new System.Drawing.Size(534, 23);
            this.NumericUpDown_CameraHeight.TabIndex = 163;
            this.NumericUpDown_CameraHeight.ValueChanged += new System.EventHandler(this.NumericUpDown_Tweaks_ValueChanged);
            // 
            // Label_Description_CameraDistance
            // 
            this.Label_Description_CameraDistance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Description_CameraDistance.AutoSize = true;
            this.Label_Description_CameraDistance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Description_CameraDistance.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Label_Description_CameraDistance.Location = new System.Drawing.Point(227, 345);
            this.Label_Description_CameraDistance.Name = "Label_Description_CameraDistance";
            this.Label_Description_CameraDistance.Size = new System.Drawing.Size(321, 15);
            this.Label_Description_CameraDistance.TabIndex = 162;
            this.Label_Description_CameraDistance.Text = "How far back the camera should be in relation to the player.";
            // 
            // Label_CameraDistance
            // 
            this.Label_CameraDistance.AutoSize = true;
            this.Label_CameraDistance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Label_CameraDistance.Location = new System.Drawing.Point(11, 343);
            this.Label_CameraDistance.Name = "Label_CameraDistance";
            this.Label_CameraDistance.Size = new System.Drawing.Size(106, 17);
            this.Label_CameraDistance.TabIndex = 161;
            this.Label_CameraDistance.Text = "Camera Distance";
            // 
            // NumericUpDown_CameraDistance
            // 
            this.NumericUpDown_CameraDistance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NumericUpDown_CameraDistance.Location = new System.Drawing.Point(14, 365);
            this.NumericUpDown_CameraDistance.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.NumericUpDown_CameraDistance.Name = "NumericUpDown_CameraDistance";
            this.NumericUpDown_CameraDistance.Size = new System.Drawing.Size(534, 23);
            this.NumericUpDown_CameraDistance.TabIndex = 160;
            this.NumericUpDown_CameraDistance.ValueChanged += new System.EventHandler(this.NumericUpDown_Tweaks_ValueChanged);
            // 
            // Label_Description_CameraType
            // 
            this.Label_Description_CameraType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Description_CameraType.AutoSize = true;
            this.Label_Description_CameraType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Description_CameraType.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Label_Description_CameraType.Location = new System.Drawing.Point(271, 293);
            this.Label_Description_CameraType.Name = "Label_Description_CameraType";
            this.Label_Description_CameraType.Size = new System.Drawing.Size(277, 15);
            this.Label_Description_CameraType.TabIndex = 159;
            this.Label_Description_CameraType.Text = "How the camera should act with the below settings.";
            // 
            // Label_CameraType
            // 
            this.Label_CameraType.AutoSize = true;
            this.Label_CameraType.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Label_CameraType.Location = new System.Drawing.Point(11, 291);
            this.Label_CameraType.Name = "Label_CameraType";
            this.Label_CameraType.Size = new System.Drawing.Size(84, 17);
            this.Label_CameraType.TabIndex = 158;
            this.Label_CameraType.Text = "Camera Type";
            // 
            // ComboBox_CameraType
            // 
            this.ComboBox_CameraType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBox_CameraType.BackColor = System.Drawing.SystemColors.Window;
            this.ComboBox_CameraType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_CameraType.FormattingEnabled = true;
            this.ComboBox_CameraType.Items.AddRange(new object[] {
            "Retail",
            "Tokyo Game Show",
            "Electronic Entertainment Expo"});
            this.ComboBox_CameraType.Location = new System.Drawing.Point(14, 313);
            this.ComboBox_CameraType.Name = "ComboBox_CameraType";
            this.ComboBox_CameraType.Size = new System.Drawing.Size(534, 23);
            this.ComboBox_CameraType.TabIndex = 157;
            this.ComboBox_CameraType.SelectedIndexChanged += new System.EventHandler(this.ComboBox_Tweaks_SelectedIndexChanged);
            // 
            // Label_Subtitle_CameraTweaks
            // 
            this.Label_Subtitle_CameraTweaks.AutoSize = true;
            this.Label_Subtitle_CameraTweaks.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.Label_Subtitle_CameraTweaks.Location = new System.Drawing.Point(9, 256);
            this.Label_Subtitle_CameraTweaks.Name = "Label_Subtitle_CameraTweaks";
            this.Label_Subtitle_CameraTweaks.Size = new System.Drawing.Size(133, 25);
            this.Label_Subtitle_CameraTweaks.TabIndex = 156;
            this.Label_Subtitle_CameraTweaks.Text = "Camera Tweaks";
            // 
            // Label_Description_ForceMSAA
            // 
            this.Label_Description_ForceMSAA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Description_ForceMSAA.AutoSize = true;
            this.Label_Description_ForceMSAA.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Description_ForceMSAA.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Label_Description_ForceMSAA.Location = new System.Drawing.Point(161, 214);
            this.Label_Description_ForceMSAA.Name = "Label_Description_ForceMSAA";
            this.Label_Description_ForceMSAA.Size = new System.Drawing.Size(414, 15);
            this.Label_Description_ForceMSAA.TabIndex = 155;
            this.Label_Description_ForceMSAA.Text = "Forces 2x MSAA on for sections that disable it (not necessary for other options)." +
    "";
            // 
            // CheckBox_ForceMSAA
            // 
            this.CheckBox_ForceMSAA.AutoSize = true;
            this.CheckBox_ForceMSAA.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox_ForceMSAA.Location = new System.Drawing.Point(14, 213);
            this.CheckBox_ForceMSAA.Name = "CheckBox_ForceMSAA";
            this.CheckBox_ForceMSAA.Size = new System.Drawing.Size(91, 19);
            this.CheckBox_ForceMSAA.TabIndex = 154;
            this.CheckBox_ForceMSAA.Text = "Force MSAA";
            this.CheckBox_ForceMSAA.UseVisualStyleBackColor = false;
            this.CheckBox_ForceMSAA.CheckedChanged += new System.EventHandler(this.CheckBox_Tweaks_CheckedChanged);
            // 
            // Label_Description_AntiAliasing
            // 
            this.Label_Description_AntiAliasing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Description_AntiAliasing.AutoSize = true;
            this.Label_Description_AntiAliasing.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Description_AntiAliasing.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Label_Description_AntiAliasing.Location = new System.Drawing.Point(311, 154);
            this.Label_Description_AntiAliasing.Name = "Label_Description_AntiAliasing";
            this.Label_Description_AntiAliasing.Size = new System.Drawing.Size(237, 15);
            this.Label_Description_AntiAliasing.TabIndex = 153;
            this.Label_Description_AntiAliasing.Text = "The scale jagged edges will be smoothed at.";
            // 
            // Label_AntiAliasing
            // 
            this.Label_AntiAliasing.AutoSize = true;
            this.Label_AntiAliasing.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Label_AntiAliasing.Location = new System.Drawing.Point(11, 152);
            this.Label_AntiAliasing.Name = "Label_AntiAliasing";
            this.Label_AntiAliasing.Size = new System.Drawing.Size(80, 17);
            this.Label_AntiAliasing.TabIndex = 152;
            this.Label_AntiAliasing.Text = "Anti-Aliasing";
            // 
            // ComboBox_AntiAliasing
            // 
            this.ComboBox_AntiAliasing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBox_AntiAliasing.BackColor = System.Drawing.SystemColors.Window;
            this.ComboBox_AntiAliasing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_AntiAliasing.FormattingEnabled = true;
            this.ComboBox_AntiAliasing.Items.AddRange(new object[] {
            "Disabled",
            "2x MSAA",
            "4x MSAA"});
            this.ComboBox_AntiAliasing.Location = new System.Drawing.Point(14, 174);
            this.ComboBox_AntiAliasing.Name = "ComboBox_AntiAliasing";
            this.ComboBox_AntiAliasing.Size = new System.Drawing.Size(534, 23);
            this.ComboBox_AntiAliasing.TabIndex = 151;
            this.ComboBox_AntiAliasing.SelectedIndexChanged += new System.EventHandler(this.ComboBox_Tweaks_SelectedIndexChanged);
            // 
            // Label_Description_Reflections
            // 
            this.Label_Description_Reflections.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Description_Reflections.AutoSize = true;
            this.Label_Description_Reflections.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Description_Reflections.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Label_Description_Reflections.Location = new System.Drawing.Point(289, 102);
            this.Label_Description_Reflections.Name = "Label_Description_Reflections";
            this.Label_Description_Reflections.Size = new System.Drawing.Size(259, 15);
            this.Label_Description_Reflections.TabIndex = 150;
            this.Label_Description_Reflections.Text = "The resolution Sonic \'06 will render reflections at.";
            // 
            // Label_Reflections
            // 
            this.Label_Reflections.AutoSize = true;
            this.Label_Reflections.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Label_Reflections.Location = new System.Drawing.Point(11, 100);
            this.Label_Reflections.Name = "Label_Reflections";
            this.Label_Reflections.Size = new System.Drawing.Size(71, 17);
            this.Label_Reflections.TabIndex = 149;
            this.Label_Reflections.Text = "Reflections";
            // 
            // ComboBox_Reflections
            // 
            this.ComboBox_Reflections.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBox_Reflections.BackColor = System.Drawing.SystemColors.Window;
            this.ComboBox_Reflections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_Reflections.FormattingEnabled = true;
            this.ComboBox_Reflections.Items.AddRange(new object[] {
            "Disabled",
            "Quarter (320x180)",
            "Half (640x360)",
            "Full (1280x720)"});
            this.ComboBox_Reflections.Location = new System.Drawing.Point(14, 122);
            this.ComboBox_Reflections.Name = "ComboBox_Reflections";
            this.ComboBox_Reflections.Size = new System.Drawing.Size(534, 23);
            this.ComboBox_Reflections.TabIndex = 148;
            this.ComboBox_Reflections.SelectedIndexChanged += new System.EventHandler(this.ComboBox_Tweaks_SelectedIndexChanged);
            // 
            // Label_Description_Renderer
            // 
            this.Label_Description_Renderer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Description_Renderer.AutoSize = true;
            this.Label_Description_Renderer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Description_Renderer.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Label_Description_Renderer.Location = new System.Drawing.Point(289, 50);
            this.Label_Description_Renderer.Name = "Label_Description_Renderer";
            this.Label_Description_Renderer.Size = new System.Drawing.Size(259, 15);
            this.Label_Description_Renderer.TabIndex = 147;
            this.Label_Description_Renderer.Text = "The renderer Sonic \'06 will use to process visuals.";
            // 
            // Label_Renderer
            // 
            this.Label_Renderer.AutoSize = true;
            this.Label_Renderer.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Label_Renderer.Location = new System.Drawing.Point(11, 48);
            this.Label_Renderer.Name = "Label_Renderer";
            this.Label_Renderer.Size = new System.Drawing.Size(62, 17);
            this.Label_Renderer.TabIndex = 146;
            this.Label_Renderer.Text = "Renderer";
            // 
            // ComboBox_Renderer
            // 
            this.ComboBox_Renderer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBox_Renderer.BackColor = System.Drawing.SystemColors.Window;
            this.ComboBox_Renderer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_Renderer.FormattingEnabled = true;
            this.ComboBox_Renderer.Items.AddRange(new object[] {
            "Default",
            "Optimised (deprecated - disable MSAA for similar performance)",
            "Destructive (Vulkan)",
            "Cheap (not recommended)"});
            this.ComboBox_Renderer.Location = new System.Drawing.Point(14, 70);
            this.ComboBox_Renderer.Name = "ComboBox_Renderer";
            this.ComboBox_Renderer.Size = new System.Drawing.Size(534, 23);
            this.ComboBox_Renderer.TabIndex = 145;
            this.ComboBox_Renderer.SelectedIndexChanged += new System.EventHandler(this.ComboBox_Tweaks_SelectedIndexChanged);
            // 
            // Label_Subtitle_GraphicsTweaks
            // 
            this.Label_Subtitle_GraphicsTweaks.AutoSize = true;
            this.Label_Subtitle_GraphicsTweaks.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.Label_Subtitle_GraphicsTweaks.Location = new System.Drawing.Point(9, 13);
            this.Label_Subtitle_GraphicsTweaks.Name = "Label_Subtitle_GraphicsTweaks";
            this.Label_Subtitle_GraphicsTweaks.Size = new System.Drawing.Size(141, 25);
            this.Label_Subtitle_GraphicsTweaks.TabIndex = 49;
            this.Label_Subtitle_GraphicsTweaks.Text = "Graphics Tweaks";
            // 
            // NumericUpDown_AmyHammerRange
            // 
            this.NumericUpDown_AmyHammerRange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NumericUpDown_AmyHammerRange.Location = new System.Drawing.Point(14, 576);
            this.NumericUpDown_AmyHammerRange.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.NumericUpDown_AmyHammerRange.Name = "NumericUpDown_AmyHammerRange";
            this.NumericUpDown_AmyHammerRange.Size = new System.Drawing.Size(534, 23);
            this.NumericUpDown_AmyHammerRange.TabIndex = 173;
            this.NumericUpDown_AmyHammerRange.ValueChanged += new System.EventHandler(this.NumericUpDown_Tweaks_ValueChanged);
            // 
            // Panel_Tweaks_UICleanSpace
            // 
            this.Panel_Tweaks_UICleanSpace.Location = new System.Drawing.Point(14, 651);
            this.Panel_Tweaks_UICleanSpace.Name = "Panel_Tweaks_UICleanSpace";
            this.Panel_Tweaks_UICleanSpace.Size = new System.Drawing.Size(214, 17);
            this.Panel_Tweaks_UICleanSpace.TabIndex = 174;
            // 
            // Tab_Section_Debug
            // 
            this.Tab_Section_Debug.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Tab_Section_Debug.Controls.Add(this.LinkLabel_Troubleshoot_Mod);
            this.Tab_Section_Debug.Controls.Add(this.label5);
            this.Tab_Section_Debug.Controls.Add(this.LinkLabel_Snapshot_Load);
            this.Tab_Section_Debug.Controls.Add(this.label4);
            this.Tab_Section_Debug.Controls.Add(this.label3);
            this.Tab_Section_Debug.Controls.Add(this.Panel_DebugControls);
            this.Tab_Section_Debug.Controls.Add(this.panel1);
            this.Tab_Section_Debug.Controls.Add(this.label6);
            this.Tab_Section_Debug.Controls.Add(this.CheckBox_AllowModStacking);
            this.Tab_Section_Debug.Location = new System.Drawing.Point(4, 20);
            this.Tab_Section_Debug.Name = "Tab_Section_Debug";
            this.Tab_Section_Debug.Size = new System.Drawing.Size(591, 1108);
            this.Tab_Section_Debug.TabIndex = 5;
            this.Tab_Section_Debug.Text = "Debug";
            // 
            // LinkLabel_Troubleshoot_Mod
            // 
            this.LinkLabel_Troubleshoot_Mod.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LinkLabel_Troubleshoot_Mod.AutoSize = true;
            this.LinkLabel_Troubleshoot_Mod.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LinkLabel_Troubleshoot_Mod.LinkColor = System.Drawing.Color.SkyBlue;
            this.LinkLabel_Troubleshoot_Mod.Location = new System.Drawing.Point(11, 99);
            this.LinkLabel_Troubleshoot_Mod.Name = "LinkLabel_Troubleshoot_Mod";
            this.LinkLabel_Troubleshoot_Mod.Size = new System.Drawing.Size(122, 15);
            this.LinkLabel_Troubleshoot_Mod.TabIndex = 169;
            this.LinkLabel_Troubleshoot_Mod.TabStop = true;
            this.LinkLabel_Troubleshoot_Mod.Text = "Troubleshoot a mod...";
            this.LinkLabel_Troubleshoot_Mod.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_Debug_LinkClicked);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label5.Location = new System.Drawing.Point(274, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(303, 15);
            this.label5.TabIndex = 170;
            this.label5.Text = "Troubleshoot a mod with your current user configuration.";
            // 
            // LinkLabel_Snapshot_Load
            // 
            this.LinkLabel_Snapshot_Load.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LinkLabel_Snapshot_Load.AutoSize = true;
            this.LinkLabel_Snapshot_Load.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LinkLabel_Snapshot_Load.LinkColor = System.Drawing.Color.SkyBlue;
            this.LinkLabel_Snapshot_Load.Location = new System.Drawing.Point(11, 76);
            this.LinkLabel_Snapshot_Load.Name = "LinkLabel_Snapshot_Load";
            this.LinkLabel_Snapshot_Load.Size = new System.Drawing.Size(102, 15);
            this.LinkLabel_Snapshot_Load.TabIndex = 167;
            this.LinkLabel_Snapshot_Load.TabStop = true;
            this.LinkLabel_Snapshot_Load.Text = "Load a snapshot...";
            this.LinkLabel_Snapshot_Load.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_Debug_LinkClicked);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label4.Location = new System.Drawing.Point(428, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 15);
            this.label4.TabIndex = 168;
            this.label4.Text = "Loads a user configuration.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.label3.Location = new System.Drawing.Point(9, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 25);
            this.label3.TabIndex = 50;
            this.label3.Text = "Debugging";
            // 
            // Panel_DebugControls
            // 
            this.Panel_DebugControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_DebugControls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel_DebugControls.Controls.Add(this.SectionButton_ClearLog);
            this.Panel_DebugControls.Location = new System.Drawing.Point(-1, 1065);
            this.Panel_DebugControls.Name = "Panel_DebugControls";
            this.Panel_DebugControls.Size = new System.Drawing.Size(596, 45);
            this.Panel_DebugControls.TabIndex = 1;
            // 
            // SectionButton_ClearLog
            // 
            this.SectionButton_ClearLog.AccentColour = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SectionButton_ClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SectionButton_ClearLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(45)))));
            this.SectionButton_ClearLog.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SectionButton_ClearLog.Location = new System.Drawing.Point(3, 7);
            this.SectionButton_ClearLog.Name = "SectionButton_ClearLog";
            this.SectionButton_ClearLog.SectionImage = ((System.Drawing.Bitmap)(resources.GetObject("SectionButton_ClearLog.SectionImage")));
            this.SectionButton_ClearLog.SectionText = "Clear debug log";
            this.SectionButton_ClearLog.SelectedSection = false;
            this.SectionButton_ClearLog.Size = new System.Drawing.Size(584, 35);
            this.SectionButton_ClearLog.TabIndex = 24;
            this.SectionButton_ClearLog.TextColour = System.Drawing.SystemColors.Control;
            this.SectionButton_ClearLog.Click += new System.EventHandler(this.SectionButton_ClearLog_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ListBox_Debug);
            this.panel1.Location = new System.Drawing.Point(-1, 132);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(593, 935);
            this.panel1.TabIndex = 2;
            // 
            // ListBox_Debug
            // 
            this.ListBox_Debug.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ListBox_Debug.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListBox_Debug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListBox_Debug.ForeColor = System.Drawing.SystemColors.Control;
            this.ListBox_Debug.FormattingEnabled = true;
            this.ListBox_Debug.ItemHeight = 15;
            this.ListBox_Debug.Location = new System.Drawing.Point(0, 0);
            this.ListBox_Debug.Name = "ListBox_Debug";
            this.ListBox_Debug.Size = new System.Drawing.Size(591, 933);
            this.ListBox_Debug.TabIndex = 0;
            this.ListBox_Debug.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ListBox_Debug_MouseUp);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label6.Location = new System.Drawing.Point(280, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(297, 15);
            this.label6.TabIndex = 172;
            this.label6.Text = "Disables mod uninstallation when installing new mods.";
            // 
            // CheckBox_AllowModStacking
            // 
            this.CheckBox_AllowModStacking.AutoSize = true;
            this.CheckBox_AllowModStacking.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox_AllowModStacking.Location = new System.Drawing.Point(14, 52);
            this.CheckBox_AllowModStacking.Name = "CheckBox_AllowModStacking";
            this.CheckBox_AllowModStacking.Size = new System.Drawing.Size(131, 19);
            this.CheckBox_AllowModStacking.TabIndex = 171;
            this.CheckBox_AllowModStacking.Text = "Allow mod stacking";
            this.CheckBox_AllowModStacking.UseVisualStyleBackColor = false;
            this.CheckBox_AllowModStacking.CheckedChanged += new System.EventHandler(this.CheckBox_AllowModStacking_CheckedChanged);
            // 
            // Tab_Section_Updates
            // 
            this.Tab_Section_Updates.AutoScroll = true;
            this.Tab_Section_Updates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Tab_Section_Updates.Controls.Add(this.Panel_Updates_UICleanSpace);
            this.Tab_Section_Updates.Controls.Add(this.SectionButton_FetchPatches);
            this.Tab_Section_Updates.Controls.Add(this.Label_LastPatchUpdate);
            this.Tab_Section_Updates.Controls.Add(this.Label_LastModUpdate);
            this.Tab_Section_Updates.Controls.Add(this.SectionButton_CheckForModUpdates);
            this.Tab_Section_Updates.Controls.Add(this.Label_LastSoftwareUpdate);
            this.Tab_Section_Updates.Controls.Add(this.SplitContainer_ModUpdate);
            this.Tab_Section_Updates.Controls.Add(this.Label_Title_ModsAndPatches);
            this.Tab_Section_Updates.Controls.Add(this.Label_Subtitle_Changelogs);
            this.Tab_Section_Updates.Controls.Add(this.Label_UpdaterStatus);
            this.Tab_Section_Updates.Controls.Add(this.Panel_ChangelogsBackdrop);
            this.Tab_Section_Updates.Controls.Add(this.Label_Title_Software);
            this.Tab_Section_Updates.Controls.Add(this.CheckBox_CheckUpdatesOnLaunch);
            this.Tab_Section_Updates.Controls.Add(this.PictureBox_UpdaterIcon);
            this.Tab_Section_Updates.Controls.Add(this.SectionButton_CheckForSoftwareUpdates);
            this.Tab_Section_Updates.Controls.Add(this.ProgressBar_SoftwareUpdate);
            this.Tab_Section_Updates.Location = new System.Drawing.Point(4, 20);
            this.Tab_Section_Updates.Name = "Tab_Section_Updates";
            this.Tab_Section_Updates.Size = new System.Drawing.Size(591, 1108);
            this.Tab_Section_Updates.TabIndex = 6;
            this.Tab_Section_Updates.Tag = "HideControls";
            this.Tab_Section_Updates.Text = "Updates";
            // 
            // Panel_Updates_UICleanSpace
            // 
            this.Panel_Updates_UICleanSpace.Location = new System.Drawing.Point(14, 993);
            this.Panel_Updates_UICleanSpace.Name = "Panel_Updates_UICleanSpace";
            this.Panel_Updates_UICleanSpace.Size = new System.Drawing.Size(214, 8);
            this.Panel_Updates_UICleanSpace.TabIndex = 176;
            // 
            // SectionButton_FetchPatches
            // 
            this.SectionButton_FetchPatches.AccentColour = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SectionButton_FetchPatches.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(45)))));
            this.SectionButton_FetchPatches.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SectionButton_FetchPatches.Location = new System.Drawing.Point(14, 564);
            this.SectionButton_FetchPatches.Name = "SectionButton_FetchPatches";
            this.SectionButton_FetchPatches.SectionImage = global::Unify.Properties.Resources.InstallMods;
            this.SectionButton_FetchPatches.SectionText = "Fetch latest patches";
            this.SectionButton_FetchPatches.SelectedSection = false;
            this.SectionButton_FetchPatches.Size = new System.Drawing.Size(233, 35);
            this.SectionButton_FetchPatches.TabIndex = 149;
            this.SectionButton_FetchPatches.TextColour = System.Drawing.SystemColors.Control;
            this.SectionButton_FetchPatches.Click += new System.EventHandler(this.SectionButton_Updates_Click);
            // 
            // Label_LastPatchUpdate
            // 
            this.Label_LastPatchUpdate.AutoSize = true;
            this.Label_LastPatchUpdate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_LastPatchUpdate.Location = new System.Drawing.Point(256, 573);
            this.Label_LastPatchUpdate.Name = "Label_LastPatchUpdate";
            this.Label_LastPatchUpdate.Size = new System.Drawing.Size(218, 17);
            this.Label_LastPatchUpdate.TabIndex = 151;
            this.Label_LastPatchUpdate.Text = "Last updated: 21/01/2020, 08:59 PM";
            // 
            // Label_LastModUpdate
            // 
            this.Label_LastModUpdate.AutoSize = true;
            this.Label_LastModUpdate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_LastModUpdate.Location = new System.Drawing.Point(256, 532);
            this.Label_LastModUpdate.Name = "Label_LastModUpdate";
            this.Label_LastModUpdate.Size = new System.Drawing.Size(216, 17);
            this.Label_LastModUpdate.TabIndex = 150;
            this.Label_LastModUpdate.Text = "Last checked: 21/01/2020, 08:59 PM";
            // 
            // SectionButton_CheckForModUpdates
            // 
            this.SectionButton_CheckForModUpdates.AccentColour = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SectionButton_CheckForModUpdates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(45)))));
            this.SectionButton_CheckForModUpdates.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SectionButton_CheckForModUpdates.Location = new System.Drawing.Point(14, 523);
            this.SectionButton_CheckForModUpdates.Name = "SectionButton_CheckForModUpdates";
            this.SectionButton_CheckForModUpdates.SectionImage = global::Unify.Properties.Resources.Update_4;
            this.SectionButton_CheckForModUpdates.SectionText = "Check for mod updates";
            this.SectionButton_CheckForModUpdates.SelectedSection = false;
            this.SectionButton_CheckForModUpdates.Size = new System.Drawing.Size(233, 35);
            this.SectionButton_CheckForModUpdates.TabIndex = 94;
            this.SectionButton_CheckForModUpdates.TextColour = System.Drawing.SystemColors.Control;
            this.SectionButton_CheckForModUpdates.Click += new System.EventHandler(this.SectionButton_Updates_Click);
            // 
            // Label_LastSoftwareUpdate
            // 
            this.Label_LastSoftwareUpdate.AutoSize = true;
            this.Label_LastSoftwareUpdate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_LastSoftwareUpdate.Location = new System.Drawing.Point(72, 87);
            this.Label_LastSoftwareUpdate.Name = "Label_LastSoftwareUpdate";
            this.Label_LastSoftwareUpdate.Size = new System.Drawing.Size(216, 17);
            this.Label_LastSoftwareUpdate.TabIndex = 147;
            this.Label_LastSoftwareUpdate.Text = "Last checked: 21/01/2020, 08:59 PM";
            // 
            // SplitContainer_ModUpdate
            // 
            this.SplitContainer_ModUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SplitContainer_ModUpdate.Location = new System.Drawing.Point(14, 614);
            this.SplitContainer_ModUpdate.Name = "SplitContainer_ModUpdate";
            // 
            // SplitContainer_ModUpdate.Panel1
            // 
            this.SplitContainer_ModUpdate.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.SplitContainer_ModUpdate.Panel1.Controls.Add(this.Panel_ModUpdateBackdrop);
            this.SplitContainer_ModUpdate.Panel1.Controls.Add(this.SectionButton_UpdateMods);
            this.SplitContainer_ModUpdate.Panel1MinSize = 201;
            // 
            // SplitContainer_ModUpdate.Panel2
            // 
            this.SplitContainer_ModUpdate.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.SplitContainer_ModUpdate.Panel2.Controls.Add(this.ProgressBar_ModUpdate);
            this.SplitContainer_ModUpdate.Panel2.Controls.Add(this.Panel_ModInfoBackdrop);
            this.SplitContainer_ModUpdate.Panel2MinSize = 300;
            this.SplitContainer_ModUpdate.Size = new System.Drawing.Size(561, 380);
            this.SplitContainer_ModUpdate.SplitterDistance = 225;
            this.SplitContainer_ModUpdate.TabIndex = 44;
            // 
            // Panel_ModUpdateBackdrop
            // 
            this.Panel_ModUpdateBackdrop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_ModUpdateBackdrop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Panel_ModUpdateBackdrop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel_ModUpdateBackdrop.Controls.Add(this.ListView_ModUpdates);
            this.Panel_ModUpdateBackdrop.Location = new System.Drawing.Point(0, 0);
            this.Panel_ModUpdateBackdrop.Name = "Panel_ModUpdateBackdrop";
            this.Panel_ModUpdateBackdrop.Size = new System.Drawing.Size(223, 337);
            this.Panel_ModUpdateBackdrop.TabIndex = 1;
            // 
            // ListView_ModUpdates
            // 
            this.ListView_ModUpdates.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.ListView_ModUpdates.AllowDrop = true;
            this.ListView_ModUpdates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ListView_ModUpdates.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListView_ModUpdates.CheckBoxes = true;
            this.ListView_ModUpdates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Column_ModUpdates_Title,
            this.Column_ModUpdates_Blank});
            this.ListView_ModUpdates.ForeColor = System.Drawing.SystemColors.Control;
            this.ListView_ModUpdates.FullRowSelect = true;
            this.ListView_ModUpdates.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListView_ModUpdates.HideSelection = false;
            this.ListView_ModUpdates.Location = new System.Drawing.Point(0, 0);
            this.ListView_ModUpdates.MultiSelect = false;
            this.ListView_ModUpdates.Name = "ListView_ModUpdates";
            this.ListView_ModUpdates.OwnerDraw = true;
            this.ListView_ModUpdates.Size = new System.Drawing.Size(221, 352);
            this.ListView_ModUpdates.TabIndex = 2;
            this.ListView_ModUpdates.UseCompatibleStateImageBehavior = false;
            this.ListView_ModUpdates.View = System.Windows.Forms.View.Details;
            this.ListView_ModUpdates.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.ListView_DrawColumnHeader);
            this.ListView_ModUpdates.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.ListView_DrawItem);
            this.ListView_ModUpdates.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ListView_ModUpdates_ItemChecked);
            // 
            // Column_ModUpdates_Title
            // 
            this.Column_ModUpdates_Title.Text = "Title";
            this.Column_ModUpdates_Title.Width = 221;
            // 
            // Column_ModUpdates_Blank
            // 
            this.Column_ModUpdates_Blank.Text = "";
            // 
            // SectionButton_UpdateMods
            // 
            this.SectionButton_UpdateMods.AccentColour = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SectionButton_UpdateMods.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SectionButton_UpdateMods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(45)))));
            this.SectionButton_UpdateMods.Enabled = false;
            this.SectionButton_UpdateMods.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SectionButton_UpdateMods.Location = new System.Drawing.Point(1, 343);
            this.SectionButton_UpdateMods.Name = "SectionButton_UpdateMods";
            this.SectionButton_UpdateMods.SectionImage = global::Unify.Properties.Resources.Update_4;
            this.SectionButton_UpdateMods.SectionText = "Update selected mods";
            this.SectionButton_UpdateMods.SelectedSection = false;
            this.SectionButton_UpdateMods.Size = new System.Drawing.Size(223, 35);
            this.SectionButton_UpdateMods.TabIndex = 45;
            this.SectionButton_UpdateMods.TextColour = System.Drawing.SystemColors.GrayText;
            this.SectionButton_UpdateMods.Click += new System.EventHandler(this.SectionButton_Updates_Click);
            // 
            // ProgressBar_ModUpdate
            // 
            this.ProgressBar_ModUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBar_ModUpdate.Enabled = false;
            this.ProgressBar_ModUpdate.Location = new System.Drawing.Point(2, 343);
            this.ProgressBar_ModUpdate.Name = "ProgressBar_ModUpdate";
            this.ProgressBar_ModUpdate.Size = new System.Drawing.Size(329, 35);
            this.ProgressBar_ModUpdate.TabIndex = 94;
            // 
            // Panel_ModInfoBackdrop
            // 
            this.Panel_ModInfoBackdrop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_ModInfoBackdrop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Panel_ModInfoBackdrop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel_ModInfoBackdrop.Controls.Add(this.ListBox_UpdateLogs);
            this.Panel_ModInfoBackdrop.Location = new System.Drawing.Point(2, 0);
            this.Panel_ModInfoBackdrop.Name = "Panel_ModInfoBackdrop";
            this.Panel_ModInfoBackdrop.Size = new System.Drawing.Size(329, 337);
            this.Panel_ModInfoBackdrop.TabIndex = 21;
            // 
            // ListBox_UpdateLogs
            // 
            this.ListBox_UpdateLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ListBox_UpdateLogs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListBox_UpdateLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListBox_UpdateLogs.ForeColor = System.Drawing.SystemColors.Control;
            this.ListBox_UpdateLogs.FormattingEnabled = true;
            this.ListBox_UpdateLogs.ItemHeight = 15;
            this.ListBox_UpdateLogs.Location = new System.Drawing.Point(0, 0);
            this.ListBox_UpdateLogs.Name = "ListBox_UpdateLogs";
            this.ListBox_UpdateLogs.Size = new System.Drawing.Size(327, 335);
            this.ListBox_UpdateLogs.TabIndex = 1;
            // 
            // Label_Title_ModsAndPatches
            // 
            this.Label_Title_ModsAndPatches.AutoSize = true;
            this.Label_Title_ModsAndPatches.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.Label_Title_ModsAndPatches.Location = new System.Drawing.Point(6, 466);
            this.Label_Title_ModsAndPatches.Name = "Label_Title_ModsAndPatches";
            this.Label_Title_ModsAndPatches.Size = new System.Drawing.Size(280, 45);
            this.Label_Title_ModsAndPatches.TabIndex = 43;
            this.Label_Title_ModsAndPatches.Text = "Mods and Patches";
            // 
            // Label_Subtitle_Changelogs
            // 
            this.Label_Subtitle_Changelogs.AutoSize = true;
            this.Label_Subtitle_Changelogs.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.Label_Subtitle_Changelogs.Location = new System.Drawing.Point(10, 160);
            this.Label_Subtitle_Changelogs.Name = "Label_Subtitle_Changelogs";
            this.Label_Subtitle_Changelogs.Size = new System.Drawing.Size(106, 25);
            this.Label_Subtitle_Changelogs.TabIndex = 42;
            this.Label_Subtitle_Changelogs.Text = "Changelogs";
            // 
            // Label_UpdaterStatus
            // 
            this.Label_UpdaterStatus.AutoSize = true;
            this.Label_UpdaterStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_UpdaterStatus.Location = new System.Drawing.Point(69, 62);
            this.Label_UpdaterStatus.Name = "Label_UpdaterStatus";
            this.Label_UpdaterStatus.Size = new System.Drawing.Size(156, 25);
            this.Label_UpdaterStatus.TabIndex = 37;
            this.Label_UpdaterStatus.Text = "You\'re up to date";
            // 
            // Panel_ChangelogsBackdrop
            // 
            this.Panel_ChangelogsBackdrop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_ChangelogsBackdrop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel_ChangelogsBackdrop.Controls.Add(this.RichTextBox_Changelogs);
            this.Panel_ChangelogsBackdrop.Location = new System.Drawing.Point(14, 194);
            this.Panel_ChangelogsBackdrop.Name = "Panel_ChangelogsBackdrop";
            this.Panel_ChangelogsBackdrop.Size = new System.Drawing.Size(560, 257);
            this.Panel_ChangelogsBackdrop.TabIndex = 35;
            // 
            // RichTextBox_Changelogs
            // 
            this.RichTextBox_Changelogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.RichTextBox_Changelogs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RichTextBox_Changelogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RichTextBox_Changelogs.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.RichTextBox_Changelogs.ForeColor = System.Drawing.SystemColors.Control;
            this.RichTextBox_Changelogs.Location = new System.Drawing.Point(0, 0);
            this.RichTextBox_Changelogs.Name = "RichTextBox_Changelogs";
            this.RichTextBox_Changelogs.ReadOnly = true;
            this.RichTextBox_Changelogs.Size = new System.Drawing.Size(558, 255);
            this.RichTextBox_Changelogs.TabIndex = 34;
            this.RichTextBox_Changelogs.Text = "";
            // 
            // Label_Title_Software
            // 
            this.Label_Title_Software.AutoSize = true;
            this.Label_Title_Software.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.Label_Title_Software.Location = new System.Drawing.Point(6, 6);
            this.Label_Title_Software.Name = "Label_Title_Software";
            this.Label_Title_Software.Size = new System.Drawing.Size(144, 45);
            this.Label_Title_Software.TabIndex = 33;
            this.Label_Title_Software.Text = "Software";
            // 
            // CheckBox_CheckUpdatesOnLaunch
            // 
            this.CheckBox_CheckUpdatesOnLaunch.AutoSize = true;
            this.CheckBox_CheckUpdatesOnLaunch.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox_CheckUpdatesOnLaunch.Location = new System.Drawing.Point(259, 124);
            this.CheckBox_CheckUpdatesOnLaunch.Name = "CheckBox_CheckUpdatesOnLaunch";
            this.CheckBox_CheckUpdatesOnLaunch.Size = new System.Drawing.Size(190, 19);
            this.CheckBox_CheckUpdatesOnLaunch.TabIndex = 41;
            this.CheckBox_CheckUpdatesOnLaunch.Text = "Check automatically on launch";
            this.CheckBox_CheckUpdatesOnLaunch.UseVisualStyleBackColor = false;
            this.CheckBox_CheckUpdatesOnLaunch.CheckedChanged += new System.EventHandler(this.CheckBox_Settings_CheckedChanged);
            // 
            // PictureBox_UpdaterIcon
            // 
            this.PictureBox_UpdaterIcon.BackgroundImage = global::Unify.Properties.Resources.Corner_Logo_Colour;
            this.PictureBox_UpdaterIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PictureBox_UpdaterIcon.Location = new System.Drawing.Point(14, 58);
            this.PictureBox_UpdaterIcon.Name = "PictureBox_UpdaterIcon";
            this.PictureBox_UpdaterIcon.Size = new System.Drawing.Size(50, 50);
            this.PictureBox_UpdaterIcon.TabIndex = 38;
            this.PictureBox_UpdaterIcon.TabStop = false;
            // 
            // SectionButton_CheckForSoftwareUpdates
            // 
            this.SectionButton_CheckForSoftwareUpdates.AccentColour = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SectionButton_CheckForSoftwareUpdates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(45)))));
            this.SectionButton_CheckForSoftwareUpdates.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SectionButton_CheckForSoftwareUpdates.Location = new System.Drawing.Point(14, 114);
            this.SectionButton_CheckForSoftwareUpdates.Name = "SectionButton_CheckForSoftwareUpdates";
            this.SectionButton_CheckForSoftwareUpdates.SectionImage = global::Unify.Properties.Resources.Update_4;
            this.SectionButton_CheckForSoftwareUpdates.SectionText = "Check for software updates";
            this.SectionButton_CheckForSoftwareUpdates.SelectedSection = false;
            this.SectionButton_CheckForSoftwareUpdates.Size = new System.Drawing.Size(233, 35);
            this.SectionButton_CheckForSoftwareUpdates.TabIndex = 36;
            this.SectionButton_CheckForSoftwareUpdates.TextColour = System.Drawing.SystemColors.Control;
            this.SectionButton_CheckForSoftwareUpdates.Click += new System.EventHandler(this.SectionButton_Updates_Click);
            // 
            // ProgressBar_SoftwareUpdate
            // 
            this.ProgressBar_SoftwareUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBar_SoftwareUpdate.Location = new System.Drawing.Point(14, 114);
            this.ProgressBar_SoftwareUpdate.Name = "ProgressBar_SoftwareUpdate";
            this.ProgressBar_SoftwareUpdate.Size = new System.Drawing.Size(233, 35);
            this.ProgressBar_SoftwareUpdate.TabIndex = 148;
            this.ProgressBar_SoftwareUpdate.Visible = false;
            // 
            // Tab_Section_Settings
            // 
            this.Tab_Section_Settings.AutoScroll = true;
            this.Tab_Section_Settings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Tab_Section_Settings.Controls.Add(this.LinkLabel_OpenProfilesDirectory);
            this.Tab_Section_Settings.Controls.Add(this.label11);
            this.Tab_Section_Settings.Controls.Add(this.LinkLabel_LoadProfile);
            this.Tab_Section_Settings.Controls.Add(this.label10);
            this.Tab_Section_Settings.Controls.Add(this.LinkLabel_CreateProfile);
            this.Tab_Section_Settings.Controls.Add(this.label9);
            this.Tab_Section_Settings.Controls.Add(this.label8);
            this.Tab_Section_Settings.Controls.Add(this.LinkLabel_Snapshot_Create);
            this.Tab_Section_Settings.Controls.Add(this.Label_Description_UninstallOnLaunch);
            this.Tab_Section_Settings.Controls.Add(this.CheckBox_UninstallOnLaunch);
            this.Tab_Section_Settings.Controls.Add(this.Label_Description_Reset);
            this.Tab_Section_Settings.Controls.Add(this.LinkLabel_Reset);
            this.Tab_Section_Settings.Controls.Add(this.Label_Description_DebugMode);
            this.Tab_Section_Settings.Controls.Add(this.Label_Description_HighContrastText);
            this.Tab_Section_Settings.Controls.Add(this.Label_Description_SaveFileRedirect);
            this.Tab_Section_Settings.Controls.Add(this.CheckBox_SaveFileRedirection);
            this.Tab_Section_Settings.Controls.Add(this.CheckBox_DebugMode);
            this.Tab_Section_Settings.Controls.Add(this.Label_Description_LaunchEmulator);
            this.Tab_Section_Settings.Controls.Add(this.CheckBox_LaunchEmulator);
            this.Tab_Section_Settings.Controls.Add(this.Label_Subtitle_General_Options);
            this.Tab_Section_Settings.Controls.Add(this.WindowsColourPicker_AccentColour);
            this.Tab_Section_Settings.Controls.Add(this.TextBox_GameDirectory);
            this.Tab_Section_Settings.Controls.Add(this.Label_Title_Appearance);
            this.Tab_Section_Settings.Controls.Add(this.CheckBox_HighContrastText);
            this.Tab_Section_Settings.Controls.Add(this.Label_Title_General);
            this.Tab_Section_Settings.Controls.Add(this.Label_Subtitle_AccentColour);
            this.Tab_Section_Settings.Controls.Add(this.Label_GameExecutable);
            this.Tab_Section_Settings.Controls.Add(this.Label_WindowsColours);
            this.Tab_Section_Settings.Controls.Add(this.Button_GameDirectory);
            this.Tab_Section_Settings.Controls.Add(this.Label_Subtitle_Appearance_Options);
            this.Tab_Section_Settings.Controls.Add(this.CheckBox_AutoColour);
            this.Tab_Section_Settings.Controls.Add(this.Label_Description_GameExecutable);
            this.Tab_Section_Settings.Controls.Add(this.Button_ColourPicker_Preview);
            this.Tab_Section_Settings.Controls.Add(this.Label_Subtitle_Settings_Paths);
            this.Tab_Section_Settings.Controls.Add(this.Button_ModsDirectory);
            this.Tab_Section_Settings.Controls.Add(this.TextBox_ModsDirectory);
            this.Tab_Section_Settings.Controls.Add(this.Label_ModsDirectory);
            this.Tab_Section_Settings.Controls.Add(this.Panel_Settings_UICleanSpace);
            this.Tab_Section_Settings.Controls.Add(this.Button_Open_GameDirectory);
            this.Tab_Section_Settings.Controls.Add(this.Button_Open_ModsDirectory);
            this.Tab_Section_Settings.Controls.Add(this.Button_ColourPicker_Default);
            this.Tab_Section_Settings.Controls.Add(this.Section_Appearance_ColourPicker);
            this.Tab_Section_Settings.Controls.Add(this.Label_Description_1ClickURLHandler);
            this.Tab_Section_Settings.Controls.Add(this.LinkLabel_1ClickURLHandler);
            this.Tab_Section_Settings.Controls.Add(this.Label_Warning_ModsDirectoryInvalid);
            this.Tab_Section_Settings.Controls.Add(this.Label_Description_ModsDirectory);
            this.Tab_Section_Settings.Controls.Add(this.Label_Description_Snapshot);
            this.Tab_Section_Settings.Location = new System.Drawing.Point(4, 20);
            this.Tab_Section_Settings.Name = "Tab_Section_Settings";
            this.Tab_Section_Settings.Size = new System.Drawing.Size(591, 1108);
            this.Tab_Section_Settings.TabIndex = 3;
            this.Tab_Section_Settings.Tag = "HideControls";
            this.Tab_Section_Settings.Text = "Settings";
            // 
            // LinkLabel_OpenProfilesDirectory
            // 
            this.LinkLabel_OpenProfilesDirectory.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LinkLabel_OpenProfilesDirectory.AutoSize = true;
            this.LinkLabel_OpenProfilesDirectory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LinkLabel_OpenProfilesDirectory.LinkColor = System.Drawing.SystemColors.Control;
            this.LinkLabel_OpenProfilesDirectory.Location = new System.Drawing.Point(11, 490);
            this.LinkLabel_OpenProfilesDirectory.Name = "LinkLabel_OpenProfilesDirectory";
            this.LinkLabel_OpenProfilesDirectory.Size = new System.Drawing.Size(137, 15);
            this.LinkLabel_OpenProfilesDirectory.TabIndex = 172;
            this.LinkLabel_OpenProfilesDirectory.TabStop = true;
            this.LinkLabel_OpenProfilesDirectory.Text = "Open profiles directory...";
            this.LinkLabel_OpenProfilesDirectory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_OpenProfilesDirectory_LinkClicked);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label11.Location = new System.Drawing.Point(342, 490);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(232, 15);
            this.label11.TabIndex = 173;
            this.label11.Text = "Opens the directory containing the profiles.";
            // 
            // LinkLabel_LoadProfile
            // 
            this.LinkLabel_LoadProfile.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LinkLabel_LoadProfile.AutoSize = true;
            this.LinkLabel_LoadProfile.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LinkLabel_LoadProfile.LinkColor = System.Drawing.Color.LightGreen;
            this.LinkLabel_LoadProfile.Location = new System.Drawing.Point(11, 466);
            this.LinkLabel_LoadProfile.Name = "LinkLabel_LoadProfile";
            this.LinkLabel_LoadProfile.Size = new System.Drawing.Size(88, 15);
            this.LinkLabel_LoadProfile.TabIndex = 170;
            this.LinkLabel_LoadProfile.TabStop = true;
            this.LinkLabel_LoadProfile.Text = "Load a profile...";
            this.LinkLabel_LoadProfile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_LoadProfile_LinkClicked);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label10.Location = new System.Drawing.Point(200, 466);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(374, 15);
            this.label10.TabIndex = 171;
            this.label10.Text = "Opens the profile selector so you can choose a previously saved profile.";
            // 
            // LinkLabel_CreateProfile
            // 
            this.LinkLabel_CreateProfile.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LinkLabel_CreateProfile.AutoSize = true;
            this.LinkLabel_CreateProfile.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LinkLabel_CreateProfile.LinkColor = System.Drawing.Color.SkyBlue;
            this.LinkLabel_CreateProfile.Location = new System.Drawing.Point(11, 442);
            this.LinkLabel_CreateProfile.Name = "LinkLabel_CreateProfile";
            this.LinkLabel_CreateProfile.Size = new System.Drawing.Size(96, 15);
            this.LinkLabel_CreateProfile.TabIndex = 168;
            this.LinkLabel_CreateProfile.TabStop = true;
            this.LinkLabel_CreateProfile.Text = "Create a profile...";
            this.LinkLabel_CreateProfile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_CreateProfile_LinkClicked);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label9.Location = new System.Drawing.Point(165, 442);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(409, 15);
            this.label9.TabIndex = 169;
            this.label9.Text = "Creates a profile based on your currently selected mods, patches and tweaks.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.label8.Location = new System.Drawing.Point(9, 405);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 25);
            this.label8.TabIndex = 167;
            this.label8.Text = "Profiles";
            // 
            // LinkLabel_Snapshot_Create
            // 
            this.LinkLabel_Snapshot_Create.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LinkLabel_Snapshot_Create.AutoSize = true;
            this.LinkLabel_Snapshot_Create.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LinkLabel_Snapshot_Create.LinkColor = System.Drawing.Color.SkyBlue;
            this.LinkLabel_Snapshot_Create.Location = new System.Drawing.Point(11, 348);
            this.LinkLabel_Snapshot_Create.Name = "LinkLabel_Snapshot_Create";
            this.LinkLabel_Snapshot_Create.Size = new System.Drawing.Size(110, 15);
            this.LinkLabel_Snapshot_Create.TabIndex = 165;
            this.LinkLabel_Snapshot_Create.TabStop = true;
            this.LinkLabel_Snapshot_Create.Text = "Create a snapshot...";
            this.LinkLabel_Snapshot_Create.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_Debug_LinkClicked);
            // 
            // Label_Description_UninstallOnLaunch
            // 
            this.Label_Description_UninstallOnLaunch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Description_UninstallOnLaunch.AutoSize = true;
            this.Label_Description_UninstallOnLaunch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Description_UninstallOnLaunch.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Label_Description_UninstallOnLaunch.Location = new System.Drawing.Point(222, 273);
            this.Label_Description_UninstallOnLaunch.Name = "Label_Description_UninstallOnLaunch";
            this.Label_Description_UninstallOnLaunch.Size = new System.Drawing.Size(352, 15);
            this.Label_Description_UninstallOnLaunch.TabIndex = 164;
            this.Label_Description_UninstallOnLaunch.Text = "Disable if you plan to keep mods installed for long periods of time.";
            // 
            // CheckBox_UninstallOnLaunch
            // 
            this.CheckBox_UninstallOnLaunch.AutoSize = true;
            this.CheckBox_UninstallOnLaunch.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox_UninstallOnLaunch.Location = new System.Drawing.Point(14, 272);
            this.CheckBox_UninstallOnLaunch.Name = "CheckBox_UninstallOnLaunch";
            this.CheckBox_UninstallOnLaunch.Size = new System.Drawing.Size(180, 19);
            this.CheckBox_UninstallOnLaunch.TabIndex = 163;
            this.CheckBox_UninstallOnLaunch.Text = "Uninstall mods automatically";
            this.CheckBox_UninstallOnLaunch.UseVisualStyleBackColor = false;
            this.CheckBox_UninstallOnLaunch.CheckedChanged += new System.EventHandler(this.CheckBox_Settings_CheckedChanged);
            // 
            // Label_Description_Reset
            // 
            this.Label_Description_Reset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Description_Reset.AutoSize = true;
            this.Label_Description_Reset.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Description_Reset.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Label_Description_Reset.Location = new System.Drawing.Point(224, 373);
            this.Label_Description_Reset.Name = "Label_Description_Reset";
            this.Label_Description_Reset.Size = new System.Drawing.Size(352, 15);
            this.Label_Description_Reset.TabIndex = 158;
            this.Label_Description_Reset.Text = "Resets all settings and removes files created by the Mod Manager.";
            // 
            // LinkLabel_Reset
            // 
            this.LinkLabel_Reset.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LinkLabel_Reset.AutoSize = true;
            this.LinkLabel_Reset.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LinkLabel_Reset.LinkColor = System.Drawing.Color.Tomato;
            this.LinkLabel_Reset.Location = new System.Drawing.Point(11, 373);
            this.LinkLabel_Reset.Name = "LinkLabel_Reset";
            this.LinkLabel_Reset.Size = new System.Drawing.Size(172, 15);
            this.LinkLabel_Reset.TabIndex = 157;
            this.LinkLabel_Reset.TabStop = true;
            this.LinkLabel_Reset.Text = "Reset Sonic \'06 Mod Manager...";
            this.LinkLabel_Reset.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_Reset_LinkClicked);
            // 
            // Label_Description_DebugMode
            // 
            this.Label_Description_DebugMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Description_DebugMode.AutoSize = true;
            this.Label_Description_DebugMode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Description_DebugMode.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Label_Description_DebugMode.Location = new System.Drawing.Point(441, 1082);
            this.Label_Description_DebugMode.Name = "Label_Description_DebugMode";
            this.Label_Description_DebugMode.Size = new System.Drawing.Size(133, 15);
            this.Label_Description_DebugMode.TabIndex = 156;
            this.Label_Description_DebugMode.Text = "Unlocks debug features.";
            // 
            // Label_Description_HighContrastText
            // 
            this.Label_Description_HighContrastText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Description_HighContrastText.AutoSize = true;
            this.Label_Description_HighContrastText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Description_HighContrastText.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Label_Description_HighContrastText.Location = new System.Drawing.Point(324, 1057);
            this.Label_Description_HighContrastText.Name = "Label_Description_HighContrastText";
            this.Label_Description_HighContrastText.Size = new System.Drawing.Size(250, 15);
            this.Label_Description_HighContrastText.TabIndex = 155;
            this.Label_Description_HighContrastText.Text = "Sets text affected by the accent colour to black.";
            // 
            // Label_Description_SaveFileRedirect
            // 
            this.Label_Description_SaveFileRedirect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Description_SaveFileRedirect.AutoSize = true;
            this.Label_Description_SaveFileRedirect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Description_SaveFileRedirect.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Label_Description_SaveFileRedirect.Location = new System.Drawing.Point(343, 298);
            this.Label_Description_SaveFileRedirect.Name = "Label_Description_SaveFileRedirect";
            this.Label_Description_SaveFileRedirect.Size = new System.Drawing.Size(233, 15);
            this.Label_Description_SaveFileRedirect.TabIndex = 154;
            this.Label_Description_SaveFileRedirect.Text = "Used for mods that have custom save data.";
            // 
            // CheckBox_SaveFileRedirection
            // 
            this.CheckBox_SaveFileRedirection.AutoSize = true;
            this.CheckBox_SaveFileRedirection.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox_SaveFileRedirection.Location = new System.Drawing.Point(14, 297);
            this.CheckBox_SaveFileRedirection.Name = "CheckBox_SaveFileRedirection";
            this.CheckBox_SaveFileRedirection.Size = new System.Drawing.Size(129, 19);
            this.CheckBox_SaveFileRedirection.TabIndex = 153;
            this.CheckBox_SaveFileRedirection.Text = "Save file redirection";
            this.CheckBox_SaveFileRedirection.UseVisualStyleBackColor = false;
            this.CheckBox_SaveFileRedirection.CheckedChanged += new System.EventHandler(this.CheckBox_Settings_CheckedChanged);
            // 
            // CheckBox_DebugMode
            // 
            this.CheckBox_DebugMode.AutoSize = true;
            this.CheckBox_DebugMode.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox_DebugMode.Location = new System.Drawing.Point(14, 1081);
            this.CheckBox_DebugMode.Name = "CheckBox_DebugMode";
            this.CheckBox_DebugMode.Size = new System.Drawing.Size(95, 19);
            this.CheckBox_DebugMode.TabIndex = 150;
            this.CheckBox_DebugMode.Text = "Debug mode";
            this.CheckBox_DebugMode.UseVisualStyleBackColor = false;
            this.CheckBox_DebugMode.CheckedChanged += new System.EventHandler(this.CheckBox_Settings_CheckedChanged);
            // 
            // Label_Description_LaunchEmulator
            // 
            this.Label_Description_LaunchEmulator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Description_LaunchEmulator.AutoSize = true;
            this.Label_Description_LaunchEmulator.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Description_LaunchEmulator.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Label_Description_LaunchEmulator.Location = new System.Drawing.Point(289, 248);
            this.Label_Description_LaunchEmulator.Name = "Label_Description_LaunchEmulator";
            this.Label_Description_LaunchEmulator.Size = new System.Drawing.Size(285, 15);
            this.Label_Description_LaunchEmulator.TabIndex = 149;
            this.Label_Description_LaunchEmulator.Text = "Disable if installing mods on real modified hardware.";
            // 
            // CheckBox_LaunchEmulator
            // 
            this.CheckBox_LaunchEmulator.AutoSize = true;
            this.CheckBox_LaunchEmulator.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox_LaunchEmulator.Location = new System.Drawing.Point(14, 247);
            this.CheckBox_LaunchEmulator.Name = "CheckBox_LaunchEmulator";
            this.CheckBox_LaunchEmulator.Size = new System.Drawing.Size(227, 19);
            this.CheckBox_LaunchEmulator.TabIndex = 148;
            this.CheckBox_LaunchEmulator.Text = "Launch emulator after installing mods";
            this.CheckBox_LaunchEmulator.UseVisualStyleBackColor = false;
            this.CheckBox_LaunchEmulator.CheckedChanged += new System.EventHandler(this.CheckBox_Settings_CheckedChanged);
            // 
            // Label_Subtitle_General_Options
            // 
            this.Label_Subtitle_General_Options.AutoSize = true;
            this.Label_Subtitle_General_Options.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.Label_Subtitle_General_Options.Location = new System.Drawing.Point(9, 210);
            this.Label_Subtitle_General_Options.Name = "Label_Subtitle_General_Options";
            this.Label_Subtitle_General_Options.Size = new System.Drawing.Size(76, 25);
            this.Label_Subtitle_General_Options.TabIndex = 147;
            this.Label_Subtitle_General_Options.Text = "Options";
            // 
            // WindowsColourPicker_AccentColour
            // 
            this.WindowsColourPicker_AccentColour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.WindowsColourPicker_AccentColour.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WindowsColourPicker_AccentColour.Location = new System.Drawing.Point(11, 675);
            this.WindowsColourPicker_AccentColour.Name = "WindowsColourPicker_AccentColour";
            this.WindowsColourPicker_AccentColour.Size = new System.Drawing.Size(379, 285);
            this.WindowsColourPicker_AccentColour.TabIndex = 146;
            this.WindowsColourPicker_AccentColour.ButtonClick += new System.EventHandler(this.WindowsColourPicker_AccentColour_ButtonClick);
            // 
            // TextBox_GameDirectory
            // 
            this.TextBox_GameDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_GameDirectory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.TextBox_GameDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBox_GameDirectory.ForeColor = System.Drawing.SystemColors.Control;
            this.TextBox_GameDirectory.Location = new System.Drawing.Point(14, 170);
            this.TextBox_GameDirectory.Name = "TextBox_GameDirectory";
            this.TextBox_GameDirectory.Size = new System.Drawing.Size(504, 23);
            this.TextBox_GameDirectory.TabIndex = 44;
            // 
            // Label_Title_Appearance
            // 
            this.Label_Title_Appearance.AutoSize = true;
            this.Label_Title_Appearance.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Title_Appearance.Location = new System.Drawing.Point(6, 521);
            this.Label_Title_Appearance.Name = "Label_Title_Appearance";
            this.Label_Title_Appearance.Size = new System.Drawing.Size(189, 45);
            this.Label_Title_Appearance.TabIndex = 10;
            this.Label_Title_Appearance.Text = "Appearance";
            // 
            // CheckBox_HighContrastText
            // 
            this.CheckBox_HighContrastText.AutoSize = true;
            this.CheckBox_HighContrastText.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox_HighContrastText.Location = new System.Drawing.Point(14, 1056);
            this.CheckBox_HighContrastText.Name = "CheckBox_HighContrastText";
            this.CheckBox_HighContrastText.Size = new System.Drawing.Size(121, 19);
            this.CheckBox_HighContrastText.TabIndex = 144;
            this.CheckBox_HighContrastText.Text = "High contrast text";
            this.CheckBox_HighContrastText.UseVisualStyleBackColor = false;
            this.CheckBox_HighContrastText.CheckedChanged += new System.EventHandler(this.CheckBox_Settings_CheckedChanged);
            // 
            // Label_Title_General
            // 
            this.Label_Title_General.AutoSize = true;
            this.Label_Title_General.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.Label_Title_General.Location = new System.Drawing.Point(6, 6);
            this.Label_Title_General.Name = "Label_Title_General";
            this.Label_Title_General.Size = new System.Drawing.Size(129, 45);
            this.Label_Title_General.TabIndex = 32;
            this.Label_Title_General.Text = "General";
            // 
            // Label_Subtitle_AccentColour
            // 
            this.Label_Subtitle_AccentColour.AutoSize = true;
            this.Label_Subtitle_AccentColour.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.Label_Subtitle_AccentColour.Location = new System.Drawing.Point(9, 576);
            this.Label_Subtitle_AccentColour.Name = "Label_Subtitle_AccentColour";
            this.Label_Subtitle_AccentColour.Size = new System.Drawing.Size(223, 25);
            this.Label_Subtitle_AccentColour.TabIndex = 45;
            this.Label_Subtitle_AccentColour.Text = "Choose your accent colour";
            // 
            // Label_GameExecutable
            // 
            this.Label_GameExecutable.AutoSize = true;
            this.Label_GameExecutable.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Label_GameExecutable.Location = new System.Drawing.Point(11, 148);
            this.Label_GameExecutable.Name = "Label_GameExecutable";
            this.Label_GameExecutable.Size = new System.Drawing.Size(108, 17);
            this.Label_GameExecutable.TabIndex = 43;
            this.Label_GameExecutable.Text = "Game Executable";
            // 
            // Label_WindowsColours
            // 
            this.Label_WindowsColours.AutoSize = true;
            this.Label_WindowsColours.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Label_WindowsColours.Location = new System.Drawing.Point(11, 650);
            this.Label_WindowsColours.Name = "Label_WindowsColours";
            this.Label_WindowsColours.Size = new System.Drawing.Size(108, 17);
            this.Label_WindowsColours.TabIndex = 89;
            this.Label_WindowsColours.Text = "Windows colours";
            // 
            // Button_GameDirectory
            // 
            this.Button_GameDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_GameDirectory.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Button_GameDirectory.FlatAppearance.BorderSize = 0;
            this.Button_GameDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_GameDirectory.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Button_GameDirectory.Location = new System.Drawing.Point(524, 170);
            this.Button_GameDirectory.Name = "Button_GameDirectory";
            this.Button_GameDirectory.Size = new System.Drawing.Size(25, 23);
            this.Button_GameDirectory.TabIndex = 45;
            this.Button_GameDirectory.Text = "...";
            this.Button_GameDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Button_GameDirectory.UseVisualStyleBackColor = false;
            this.Button_GameDirectory.Click += new System.EventHandler(this.Button_Browse_Click);
            // 
            // Label_Subtitle_Appearance_Options
            // 
            this.Label_Subtitle_Appearance_Options.AutoSize = true;
            this.Label_Subtitle_Appearance_Options.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.Label_Subtitle_Appearance_Options.Location = new System.Drawing.Point(9, 1019);
            this.Label_Subtitle_Appearance_Options.Name = "Label_Subtitle_Appearance_Options";
            this.Label_Subtitle_Appearance_Options.Size = new System.Drawing.Size(76, 25);
            this.Label_Subtitle_Appearance_Options.TabIndex = 143;
            this.Label_Subtitle_Appearance_Options.Text = "Options";
            // 
            // CheckBox_AutoColour
            // 
            this.CheckBox_AutoColour.AutoSize = true;
            this.CheckBox_AutoColour.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox_AutoColour.Location = new System.Drawing.Point(14, 614);
            this.CheckBox_AutoColour.Name = "CheckBox_AutoColour";
            this.CheckBox_AutoColour.Size = new System.Drawing.Size(354, 19);
            this.CheckBox_AutoColour.TabIndex = 142;
            this.CheckBox_AutoColour.Text = "Automatically pick an accent colour from my Windows theme";
            this.CheckBox_AutoColour.UseVisualStyleBackColor = false;
            this.CheckBox_AutoColour.CheckedChanged += new System.EventHandler(this.CheckBox_Settings_CheckedChanged);
            // 
            // Label_Description_GameExecutable
            // 
            this.Label_Description_GameExecutable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Description_GameExecutable.AutoSize = true;
            this.Label_Description_GameExecutable.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Description_GameExecutable.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Label_Description_GameExecutable.Location = new System.Drawing.Point(162, 150);
            this.Label_Description_GameExecutable.Name = "Label_Description_GameExecutable";
            this.Label_Description_GameExecutable.Size = new System.Drawing.Size(354, 15);
            this.Label_Description_GameExecutable.TabIndex = 46;
            this.Label_Description_GameExecutable.Text = "Sonic \'06 executable file (XEX/BIN) - auto-detects the console used.";
            // 
            // Button_ColourPicker_Preview
            // 
            this.Button_ColourPicker_Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Button_ColourPicker_Preview.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.Button_ColourPicker_Preview.FlatAppearance.BorderSize = 0;
            this.Button_ColourPicker_Preview.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Button_ColourPicker_Preview.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Button_ColourPicker_Preview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_ColourPicker_Preview.Location = new System.Drawing.Point(357, 967);
            this.Button_ColourPicker_Preview.Name = "Button_ColourPicker_Preview";
            this.Button_ColourPicker_Preview.Size = new System.Drawing.Size(25, 25);
            this.Button_ColourPicker_Preview.TabIndex = 140;
            this.Button_ColourPicker_Preview.UseVisualStyleBackColor = false;
            this.Button_ColourPicker_Preview.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_ColourPicker_Preview_MouseDown);
            this.Button_ColourPicker_Preview.MouseEnter += new System.EventHandler(this.Button_ColourPicker_Preview_MouseEnter);
            this.Button_ColourPicker_Preview.MouseLeave += new System.EventHandler(this.Button_ColourPicker_Preview_MouseLeave);
            this.Button_ColourPicker_Preview.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_ColourPicker_Preview_MouseUp);
            // 
            // Label_Subtitle_Settings_Paths
            // 
            this.Label_Subtitle_Settings_Paths.AutoSize = true;
            this.Label_Subtitle_Settings_Paths.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.Label_Subtitle_Settings_Paths.Location = new System.Drawing.Point(9, 61);
            this.Label_Subtitle_Settings_Paths.Name = "Label_Subtitle_Settings_Paths";
            this.Label_Subtitle_Settings_Paths.Size = new System.Drawing.Size(54, 25);
            this.Label_Subtitle_Settings_Paths.TabIndex = 33;
            this.Label_Subtitle_Settings_Paths.Text = "Paths";
            // 
            // Button_ModsDirectory
            // 
            this.Button_ModsDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_ModsDirectory.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Button_ModsDirectory.FlatAppearance.BorderSize = 0;
            this.Button_ModsDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_ModsDirectory.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Button_ModsDirectory.Location = new System.Drawing.Point(524, 118);
            this.Button_ModsDirectory.Name = "Button_ModsDirectory";
            this.Button_ModsDirectory.Size = new System.Drawing.Size(25, 23);
            this.Button_ModsDirectory.TabIndex = 36;
            this.Button_ModsDirectory.Text = "...";
            this.Button_ModsDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Button_ModsDirectory.UseVisualStyleBackColor = false;
            this.Button_ModsDirectory.Click += new System.EventHandler(this.Button_Browse_Click);
            // 
            // TextBox_ModsDirectory
            // 
            this.TextBox_ModsDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_ModsDirectory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.TextBox_ModsDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBox_ModsDirectory.ForeColor = System.Drawing.SystemColors.Control;
            this.TextBox_ModsDirectory.Location = new System.Drawing.Point(14, 118);
            this.TextBox_ModsDirectory.Name = "TextBox_ModsDirectory";
            this.TextBox_ModsDirectory.Size = new System.Drawing.Size(504, 23);
            this.TextBox_ModsDirectory.TabIndex = 35;
            // 
            // Label_ModsDirectory
            // 
            this.Label_ModsDirectory.AutoSize = true;
            this.Label_ModsDirectory.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Label_ModsDirectory.Location = new System.Drawing.Point(11, 96);
            this.Label_ModsDirectory.Name = "Label_ModsDirectory";
            this.Label_ModsDirectory.Size = new System.Drawing.Size(99, 17);
            this.Label_ModsDirectory.TabIndex = 34;
            this.Label_ModsDirectory.Text = "Mods Directory";
            // 
            // Panel_Settings_UICleanSpace
            // 
            this.Panel_Settings_UICleanSpace.Location = new System.Drawing.Point(12, 1099);
            this.Panel_Settings_UICleanSpace.Name = "Panel_Settings_UICleanSpace";
            this.Panel_Settings_UICleanSpace.Size = new System.Drawing.Size(214, 8);
            this.Panel_Settings_UICleanSpace.TabIndex = 145;
            // 
            // Button_Open_GameDirectory
            // 
            this.Button_Open_GameDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Open_GameDirectory.FlatAppearance.BorderSize = 0;
            this.Button_Open_GameDirectory.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Button_Open_GameDirectory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Button_Open_GameDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Open_GameDirectory.Image = ((System.Drawing.Image)(resources.GetObject("Button_Open_GameDirectory.Image")));
            this.Button_Open_GameDirectory.Location = new System.Drawing.Point(555, 170);
            this.Button_Open_GameDirectory.Name = "Button_Open_GameDirectory";
            this.Button_Open_GameDirectory.Size = new System.Drawing.Size(21, 20);
            this.Button_Open_GameDirectory.TabIndex = 152;
            this.Button_Open_GameDirectory.UseVisualStyleBackColor = true;
            this.Button_Open_GameDirectory.Click += new System.EventHandler(this.Button_Open_Click);
            // 
            // Button_Open_ModsDirectory
            // 
            this.Button_Open_ModsDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Open_ModsDirectory.FlatAppearance.BorderSize = 0;
            this.Button_Open_ModsDirectory.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Button_Open_ModsDirectory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Button_Open_ModsDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Open_ModsDirectory.Image = ((System.Drawing.Image)(resources.GetObject("Button_Open_ModsDirectory.Image")));
            this.Button_Open_ModsDirectory.Location = new System.Drawing.Point(555, 118);
            this.Button_Open_ModsDirectory.Name = "Button_Open_ModsDirectory";
            this.Button_Open_ModsDirectory.Size = new System.Drawing.Size(21, 20);
            this.Button_Open_ModsDirectory.TabIndex = 151;
            this.Button_Open_ModsDirectory.UseVisualStyleBackColor = true;
            this.Button_Open_ModsDirectory.Click += new System.EventHandler(this.Button_Open_Click);
            // 
            // Button_ColourPicker_Default
            // 
            this.Button_ColourPicker_Default.FlatAppearance.BorderSize = 0;
            this.Button_ColourPicker_Default.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Button_ColourPicker_Default.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Button_ColourPicker_Default.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_ColourPicker_Default.Image = ((System.Drawing.Image)(resources.GetObject("Button_ColourPicker_Default.Image")));
            this.Button_ColourPicker_Default.Location = new System.Drawing.Point(393, 969);
            this.Button_ColourPicker_Default.Name = "Button_ColourPicker_Default";
            this.Button_ColourPicker_Default.Size = new System.Drawing.Size(21, 20);
            this.Button_ColourPicker_Default.TabIndex = 141;
            this.Button_ColourPicker_Default.UseVisualStyleBackColor = true;
            this.Button_ColourPicker_Default.Click += new System.EventHandler(this.Button_ColourPicker_Default_Click);
            // 
            // Section_Appearance_ColourPicker
            // 
            this.Section_Appearance_ColourPicker.AccentColour = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Section_Appearance_ColourPicker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(45)))));
            this.Section_Appearance_ColourPicker.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Section_Appearance_ColourPicker.Location = new System.Drawing.Point(14, 962);
            this.Section_Appearance_ColourPicker.Name = "Section_Appearance_ColourPicker";
            this.Section_Appearance_ColourPicker.SectionImage = ((System.Drawing.Bitmap)(resources.GetObject("Section_Appearance_ColourPicker.SectionImage")));
            this.Section_Appearance_ColourPicker.SectionText = "Custom colour";
            this.Section_Appearance_ColourPicker.SelectedSection = false;
            this.Section_Appearance_ColourPicker.Size = new System.Drawing.Size(373, 35);
            this.Section_Appearance_ColourPicker.TabIndex = 138;
            this.Section_Appearance_ColourPicker.TextColour = System.Drawing.SystemColors.Control;
            this.Section_Appearance_ColourPicker.Click += new System.EventHandler(this.Section_Appearance_ColourPicker_Click);
            // 
            // Label_Description_1ClickURLHandler
            // 
            this.Label_Description_1ClickURLHandler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Description_1ClickURLHandler.AutoSize = true;
            this.Label_Description_1ClickURLHandler.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Description_1ClickURLHandler.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Label_Description_1ClickURLHandler.Location = new System.Drawing.Point(270, 323);
            this.Label_Description_1ClickURLHandler.Name = "Label_Description_1ClickURLHandler";
            this.Label_Description_1ClickURLHandler.Size = new System.Drawing.Size(304, 15);
            this.Label_Description_1ClickURLHandler.TabIndex = 160;
            this.Label_Description_1ClickURLHandler.Text = "Modifies the registry key for GameBanana 1-Click Install.";
            // 
            // LinkLabel_1ClickURLHandler
            // 
            this.LinkLabel_1ClickURLHandler.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LinkLabel_1ClickURLHandler.AutoSize = true;
            this.LinkLabel_1ClickURLHandler.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LinkLabel_1ClickURLHandler.LinkColor = System.Drawing.Color.Gold;
            this.LinkLabel_1ClickURLHandler.Location = new System.Drawing.Point(11, 323);
            this.LinkLabel_1ClickURLHandler.Name = "LinkLabel_1ClickURLHandler";
            this.LinkLabel_1ClickURLHandler.Size = new System.Drawing.Size(147, 15);
            this.LinkLabel_1ClickURLHandler.TabIndex = 159;
            this.LinkLabel_1ClickURLHandler.TabStop = true;
            this.LinkLabel_1ClickURLHandler.Text = "Install 1-Click URL Handler";
            this.LinkLabel_1ClickURLHandler.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_1ClickURLHandler_LinkClicked);
            // 
            // Label_Warning_ModsDirectoryInvalid
            // 
            this.Label_Warning_ModsDirectoryInvalid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Warning_ModsDirectoryInvalid.AutoSize = true;
            this.Label_Warning_ModsDirectoryInvalid.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Warning_ModsDirectoryInvalid.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Label_Warning_ModsDirectoryInvalid.Location = new System.Drawing.Point(305, 98);
            this.Label_Warning_ModsDirectoryInvalid.Name = "Label_Warning_ModsDirectoryInvalid";
            this.Label_Warning_ModsDirectoryInvalid.Size = new System.Drawing.Size(213, 15);
            this.Label_Warning_ModsDirectoryInvalid.TabIndex = 162;
            this.Label_Warning_ModsDirectoryInvalid.Text = "(ensure it\'s outside the game directory).";
            // 
            // Label_Description_ModsDirectory
            // 
            this.Label_Description_ModsDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Description_ModsDirectory.AutoSize = true;
            this.Label_Description_ModsDirectory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Description_ModsDirectory.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Label_Description_ModsDirectory.Location = new System.Drawing.Point(156, 98);
            this.Label_Description_ModsDirectory.Name = "Label_Description_ModsDirectory";
            this.Label_Description_ModsDirectory.Size = new System.Drawing.Size(153, 15);
            this.Label_Description_ModsDirectory.TabIndex = 161;
            this.Label_Description_ModsDirectory.Text = "Where the mods are located";
            // 
            // Label_Description_Snapshot
            // 
            this.Label_Description_Snapshot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Description_Snapshot.AutoSize = true;
            this.Label_Description_Snapshot.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Description_Snapshot.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Label_Description_Snapshot.Location = new System.Drawing.Point(328, 348);
            this.Label_Description_Snapshot.Name = "Label_Description_Snapshot";
            this.Label_Description_Snapshot.Size = new System.Drawing.Size(248, 15);
            this.Label_Description_Snapshot.TabIndex = 166;
            this.Label_Description_Snapshot.Text = "Dumps your user configuration for debuggers.";
            // 
            // Tab_Section_About
            // 
            this.Tab_Section_About.AutoScroll = true;
            this.Tab_Section_About.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Tab_Section_About.Controls.Add(this.LinkLabel_Contributors_VolcanoTheBat);
            this.Tab_Section_About.Controls.Add(this.LinkLabel_Testers_Radfordhound);
            this.Tab_Section_About.Controls.Add(this.LinkLabel_Velcomia);
            this.Tab_Section_About.Controls.Add(this.LinkLabel_Melpontro);
            this.Tab_Section_About.Controls.Add(this.LinkLabel_sharu6262);
            this.Tab_Section_About.Controls.Add(this.Label_Testers);
            this.Tab_Section_About.Controls.Add(this.Title_Testers);
            this.Tab_Section_About.Controls.Add(this.label7);
            this.Tab_Section_About.Controls.Add(this.LinkLabel_Contributors_Radfordhound);
            this.Tab_Section_About.Controls.Add(this.LinkLabel_SuperSonic16);
            this.Tab_Section_About.Controls.Add(this.LinkLabel_GerbilSoft);
            this.Tab_Section_About.Controls.Add(this.LinkLabel_Knuxfan24);
            this.Tab_Section_About.Controls.Add(this.LinkLabel_HyperBE32);
            this.Tab_Section_About.Controls.Add(this.Label_Contributors);
            this.Tab_Section_About.Controls.Add(this.Title_Contributors);
            this.Tab_Section_About.Controls.Add(this.Label_Version);
            this.Tab_Section_About.Location = new System.Drawing.Point(4, 20);
            this.Tab_Section_About.Name = "Tab_Section_About";
            this.Tab_Section_About.Size = new System.Drawing.Size(591, 1108);
            this.Tab_Section_About.TabIndex = 4;
            this.Tab_Section_About.Tag = "HideControls";
            this.Tab_Section_About.Text = "About";
            this.Tab_Section_About.Visible = false;
            // 
            // LinkLabel_Contributors_VolcanoTheBat
            // 
            this.LinkLabel_Contributors_VolcanoTheBat.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LinkLabel_Contributors_VolcanoTheBat.AutoSize = true;
            this.LinkLabel_Contributors_VolcanoTheBat.DisabledLinkColor = System.Drawing.SystemColors.GrayText;
            this.LinkLabel_Contributors_VolcanoTheBat.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.LinkLabel_Contributors_VolcanoTheBat.LinkColor = System.Drawing.SystemColors.Control;
            this.LinkLabel_Contributors_VolcanoTheBat.Location = new System.Drawing.Point(30, 210);
            this.LinkLabel_Contributors_VolcanoTheBat.Name = "LinkLabel_Contributors_VolcanoTheBat";
            this.LinkLabel_Contributors_VolcanoTheBat.Size = new System.Drawing.Size(128, 25);
            this.LinkLabel_Contributors_VolcanoTheBat.TabIndex = 196;
            this.LinkLabel_Contributors_VolcanoTheBat.TabStop = true;
            this.LinkLabel_Contributors_VolcanoTheBat.Text = "VolcanoTheBat";
            this.LinkLabel_Contributors_VolcanoTheBat.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Link_About_LinkClicked);
            // 
            // LinkLabel_Testers_Radfordhound
            // 
            this.LinkLabel_Testers_Radfordhound.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LinkLabel_Testers_Radfordhound.AutoSize = true;
            this.LinkLabel_Testers_Radfordhound.DisabledLinkColor = System.Drawing.SystemColors.GrayText;
            this.LinkLabel_Testers_Radfordhound.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.LinkLabel_Testers_Radfordhound.LinkColor = System.Drawing.SystemColors.Control;
            this.LinkLabel_Testers_Radfordhound.Location = new System.Drawing.Point(30, 460);
            this.LinkLabel_Testers_Radfordhound.Name = "LinkLabel_Testers_Radfordhound";
            this.LinkLabel_Testers_Radfordhound.Size = new System.Drawing.Size(129, 25);
            this.LinkLabel_Testers_Radfordhound.TabIndex = 195;
            this.LinkLabel_Testers_Radfordhound.TabStop = true;
            this.LinkLabel_Testers_Radfordhound.Text = "Radfordhound";
            this.LinkLabel_Testers_Radfordhound.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Link_About_LinkClicked);
            // 
            // LinkLabel_Velcomia
            // 
            this.LinkLabel_Velcomia.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LinkLabel_Velcomia.AutoSize = true;
            this.LinkLabel_Velcomia.DisabledLinkColor = System.Drawing.SystemColors.GrayText;
            this.LinkLabel_Velcomia.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.LinkLabel_Velcomia.LinkColor = System.Drawing.SystemColors.Control;
            this.LinkLabel_Velcomia.Location = new System.Drawing.Point(30, 435);
            this.LinkLabel_Velcomia.Name = "LinkLabel_Velcomia";
            this.LinkLabel_Velcomia.Size = new System.Drawing.Size(83, 25);
            this.LinkLabel_Velcomia.TabIndex = 194;
            this.LinkLabel_Velcomia.TabStop = true;
            this.LinkLabel_Velcomia.Text = "Velcomia";
            this.LinkLabel_Velcomia.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Link_About_LinkClicked);
            // 
            // LinkLabel_Melpontro
            // 
            this.LinkLabel_Melpontro.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LinkLabel_Melpontro.AutoSize = true;
            this.LinkLabel_Melpontro.DisabledLinkColor = System.Drawing.SystemColors.GrayText;
            this.LinkLabel_Melpontro.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.LinkLabel_Melpontro.LinkColor = System.Drawing.SystemColors.Control;
            this.LinkLabel_Melpontro.Location = new System.Drawing.Point(30, 386);
            this.LinkLabel_Melpontro.Name = "LinkLabel_Melpontro";
            this.LinkLabel_Melpontro.Size = new System.Drawing.Size(96, 25);
            this.LinkLabel_Melpontro.TabIndex = 193;
            this.LinkLabel_Melpontro.TabStop = true;
            this.LinkLabel_Melpontro.Text = "Melpontro";
            this.LinkLabel_Melpontro.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Link_About_LinkClicked);
            // 
            // LinkLabel_sharu6262
            // 
            this.LinkLabel_sharu6262.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LinkLabel_sharu6262.AutoSize = true;
            this.LinkLabel_sharu6262.DisabledLinkColor = System.Drawing.SystemColors.GrayText;
            this.LinkLabel_sharu6262.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.LinkLabel_sharu6262.LinkColor = System.Drawing.SystemColors.Control;
            this.LinkLabel_sharu6262.Location = new System.Drawing.Point(30, 361);
            this.LinkLabel_sharu6262.Name = "LinkLabel_sharu6262";
            this.LinkLabel_sharu6262.Size = new System.Drawing.Size(95, 25);
            this.LinkLabel_sharu6262.TabIndex = 192;
            this.LinkLabel_sharu6262.TabStop = true;
            this.LinkLabel_sharu6262.Text = "sharu6262";
            this.LinkLabel_sharu6262.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Link_About_LinkClicked);
            // 
            // Label_Testers
            // 
            this.Label_Testers.AutoSize = true;
            this.Label_Testers.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.Label_Testers.Location = new System.Drawing.Point(9, 361);
            this.Label_Testers.Name = "Label_Testers";
            this.Label_Testers.Size = new System.Drawing.Size(150, 150);
            this.Label_Testers.TabIndex = 190;
            this.Label_Testers.Text = "► sharu6262\r\n► Melpontro\r\n► ChrisHighwind\r\n► Velcomia\r\n► Radfordhound\r\n► Dunker";
            // 
            // Title_Testers
            // 
            this.Title_Testers.AutoSize = true;
            this.Title_Testers.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.Title_Testers.Location = new System.Drawing.Point(6, 307);
            this.Title_Testers.Name = "Title_Testers";
            this.Title_Testers.Size = new System.Drawing.Size(118, 45);
            this.Title_Testers.TabIndex = 189;
            this.Title_Testers.Text = "Testers";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label7.Location = new System.Drawing.Point(11, 1082);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(176, 15);
            this.label7.TabIndex = 188;
            this.label7.Text = "Brought to you by British idiots™";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LinkLabel_Contributors_Radfordhound
            // 
            this.LinkLabel_Contributors_Radfordhound.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LinkLabel_Contributors_Radfordhound.AutoSize = true;
            this.LinkLabel_Contributors_Radfordhound.DisabledLinkColor = System.Drawing.SystemColors.GrayText;
            this.LinkLabel_Contributors_Radfordhound.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.LinkLabel_Contributors_Radfordhound.LinkColor = System.Drawing.SystemColors.Control;
            this.LinkLabel_Contributors_Radfordhound.Location = new System.Drawing.Point(30, 185);
            this.LinkLabel_Contributors_Radfordhound.Name = "LinkLabel_Contributors_Radfordhound";
            this.LinkLabel_Contributors_Radfordhound.Size = new System.Drawing.Size(129, 25);
            this.LinkLabel_Contributors_Radfordhound.TabIndex = 180;
            this.LinkLabel_Contributors_Radfordhound.TabStop = true;
            this.LinkLabel_Contributors_Radfordhound.Text = "Radfordhound";
            this.LinkLabel_Contributors_Radfordhound.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Link_About_LinkClicked);
            // 
            // LinkLabel_SuperSonic16
            // 
            this.LinkLabel_SuperSonic16.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LinkLabel_SuperSonic16.AutoSize = true;
            this.LinkLabel_SuperSonic16.DisabledLinkColor = System.Drawing.SystemColors.GrayText;
            this.LinkLabel_SuperSonic16.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.LinkLabel_SuperSonic16.LinkColor = System.Drawing.SystemColors.Control;
            this.LinkLabel_SuperSonic16.Location = new System.Drawing.Point(30, 160);
            this.LinkLabel_SuperSonic16.Name = "LinkLabel_SuperSonic16";
            this.LinkLabel_SuperSonic16.Size = new System.Drawing.Size(121, 25);
            this.LinkLabel_SuperSonic16.TabIndex = 179;
            this.LinkLabel_SuperSonic16.TabStop = true;
            this.LinkLabel_SuperSonic16.Text = "SuperSonic16";
            this.LinkLabel_SuperSonic16.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Link_About_LinkClicked);
            // 
            // LinkLabel_GerbilSoft
            // 
            this.LinkLabel_GerbilSoft.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LinkLabel_GerbilSoft.AutoSize = true;
            this.LinkLabel_GerbilSoft.DisabledLinkColor = System.Drawing.SystemColors.GrayText;
            this.LinkLabel_GerbilSoft.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.LinkLabel_GerbilSoft.LinkColor = System.Drawing.SystemColors.Control;
            this.LinkLabel_GerbilSoft.Location = new System.Drawing.Point(30, 135);
            this.LinkLabel_GerbilSoft.Name = "LinkLabel_GerbilSoft";
            this.LinkLabel_GerbilSoft.Size = new System.Drawing.Size(91, 25);
            this.LinkLabel_GerbilSoft.TabIndex = 178;
            this.LinkLabel_GerbilSoft.TabStop = true;
            this.LinkLabel_GerbilSoft.Text = "GerbilSoft";
            this.LinkLabel_GerbilSoft.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Link_About_LinkClicked);
            // 
            // LinkLabel_Knuxfan24
            // 
            this.LinkLabel_Knuxfan24.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LinkLabel_Knuxfan24.AutoSize = true;
            this.LinkLabel_Knuxfan24.DisabledLinkColor = System.Drawing.SystemColors.GrayText;
            this.LinkLabel_Knuxfan24.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.LinkLabel_Knuxfan24.LinkColor = System.Drawing.SystemColors.Control;
            this.LinkLabel_Knuxfan24.Location = new System.Drawing.Point(30, 85);
            this.LinkLabel_Knuxfan24.Name = "LinkLabel_Knuxfan24";
            this.LinkLabel_Knuxfan24.Size = new System.Drawing.Size(95, 25);
            this.LinkLabel_Knuxfan24.TabIndex = 177;
            this.LinkLabel_Knuxfan24.TabStop = true;
            this.LinkLabel_Knuxfan24.Text = "Knuxfan24";
            this.LinkLabel_Knuxfan24.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Link_About_LinkClicked);
            // 
            // LinkLabel_HyperBE32
            // 
            this.LinkLabel_HyperBE32.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LinkLabel_HyperBE32.AutoSize = true;
            this.LinkLabel_HyperBE32.DisabledLinkColor = System.Drawing.SystemColors.GrayText;
            this.LinkLabel_HyperBE32.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.LinkLabel_HyperBE32.LinkColor = System.Drawing.SystemColors.Control;
            this.LinkLabel_HyperBE32.Location = new System.Drawing.Point(30, 60);
            this.LinkLabel_HyperBE32.Name = "LinkLabel_HyperBE32";
            this.LinkLabel_HyperBE32.Size = new System.Drawing.Size(99, 25);
            this.LinkLabel_HyperBE32.TabIndex = 176;
            this.LinkLabel_HyperBE32.TabStop = true;
            this.LinkLabel_HyperBE32.Text = "HyperBE32";
            this.LinkLabel_HyperBE32.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Link_About_LinkClicked);
            this.LinkLabel_HyperBE32.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Ugh);
            // 
            // Label_Contributors
            // 
            this.Label_Contributors.AutoSize = true;
            this.Label_Contributors.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.Label_Contributors.Location = new System.Drawing.Point(9, 60);
            this.Label_Contributors.Name = "Label_Contributors";
            this.Label_Contributors.Size = new System.Drawing.Size(556, 225);
            this.Label_Contributors.TabIndex = 35;
            this.Label_Contributors.Text = resources.GetString("Label_Contributors.Text");
            // 
            // Title_Contributors
            // 
            this.Title_Contributors.AutoSize = true;
            this.Title_Contributors.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.Title_Contributors.Location = new System.Drawing.Point(6, 6);
            this.Title_Contributors.Name = "Title_Contributors";
            this.Title_Contributors.Size = new System.Drawing.Size(199, 45);
            this.Title_Contributors.TabIndex = 34;
            this.Title_Contributors.Text = "Contributors";
            // 
            // Label_Version
            // 
            this.Label_Version.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Version.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Version.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Label_Version.Location = new System.Drawing.Point(2, 1077);
            this.Label_Version.Name = "Label_Version";
            this.Label_Version.Size = new System.Drawing.Size(582, 25);
            this.Label_Version.TabIndex = 0;
            this.Label_Version.Text = "Rush 3.0";
            this.Label_Version.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Rush_Section_Debug
            // 
            this.Rush_Section_Debug.AccentColour = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Rush_Section_Debug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Rush_Section_Debug.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(45)))));
            this.Rush_Section_Debug.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rush_Section_Debug.Location = new System.Drawing.Point(0, 1034);
            this.Rush_Section_Debug.Name = "Rush_Section_Debug";
            this.Rush_Section_Debug.SectionImage = global::Unify.Properties.Resources.debug_6;
            this.Rush_Section_Debug.SectionText = "Debug";
            this.Rush_Section_Debug.SelectedSection = false;
            this.Rush_Section_Debug.Size = new System.Drawing.Size(250, 35);
            this.Rush_Section_Debug.TabIndex = 25;
            this.Rush_Section_Debug.TextColour = System.Drawing.SystemColors.Control;
            this.Rush_Section_Debug.Visible = false;
            this.Rush_Section_Debug.Click += new System.EventHandler(this.Rush_Section_Click);
            // 
            // Rush_Section_Updates
            // 
            this.Rush_Section_Updates.AccentColour = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Rush_Section_Updates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Rush_Section_Updates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(45)))));
            this.Rush_Section_Updates.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rush_Section_Updates.Location = new System.Drawing.Point(0, 1070);
            this.Rush_Section_Updates.Name = "Rush_Section_Updates";
            this.Rush_Section_Updates.SectionImage = global::Unify.Properties.Resources.Update_4;
            this.Rush_Section_Updates.SectionText = "Updates";
            this.Rush_Section_Updates.SelectedSection = false;
            this.Rush_Section_Updates.Size = new System.Drawing.Size(250, 35);
            this.Rush_Section_Updates.TabIndex = 28;
            this.Rush_Section_Updates.TextColour = System.Drawing.SystemColors.Control;
            this.Rush_Section_Updates.Click += new System.EventHandler(this.Rush_Section_Click);
            // 
            // Rush_Section_Tweaks
            // 
            this.Rush_Section_Tweaks.AccentColour = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Rush_Section_Tweaks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(45)))));
            this.Rush_Section_Tweaks.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rush_Section_Tweaks.Location = new System.Drawing.Point(0, 171);
            this.Rush_Section_Tweaks.Name = "Rush_Section_Tweaks";
            this.Rush_Section_Tweaks.SectionImage = global::Unify.Properties.Resources.ConfigurationEditor_16x;
            this.Rush_Section_Tweaks.SectionText = "Tweaks";
            this.Rush_Section_Tweaks.SelectedSection = false;
            this.Rush_Section_Tweaks.Size = new System.Drawing.Size(250, 35);
            this.Rush_Section_Tweaks.TabIndex = 29;
            this.Rush_Section_Tweaks.TextColour = System.Drawing.SystemColors.Control;
            this.Rush_Section_Tweaks.Click += new System.EventHandler(this.Rush_Section_Click);
            // 
            // Rush_Section_Settings
            // 
            this.Rush_Section_Settings.AccentColour = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Rush_Section_Settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Rush_Section_Settings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(45)))));
            this.Rush_Section_Settings.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rush_Section_Settings.Location = new System.Drawing.Point(0, 1106);
            this.Rush_Section_Settings.Name = "Rush_Section_Settings";
            this.Rush_Section_Settings.SectionImage = global::Unify.Properties.Resources.Monaco_Settings_16x;
            this.Rush_Section_Settings.SectionText = "Settings";
            this.Rush_Section_Settings.SelectedSection = false;
            this.Rush_Section_Settings.Size = new System.Drawing.Size(250, 35);
            this.Rush_Section_Settings.TabIndex = 23;
            this.Rush_Section_Settings.TextColour = System.Drawing.SystemColors.Control;
            this.Rush_Section_Settings.Click += new System.EventHandler(this.Rush_Section_Click);
            // 
            // Rush_Section_Patches
            // 
            this.Rush_Section_Patches.AccentColour = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Rush_Section_Patches.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(45)))));
            this.Rush_Section_Patches.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rush_Section_Patches.Location = new System.Drawing.Point(0, 135);
            this.Rush_Section_Patches.Name = "Rush_Section_Patches";
            this.Rush_Section_Patches.SectionImage = global::Unify.Properties.Resources.PatchPackage_16x;
            this.Rush_Section_Patches.SectionText = "Patches";
            this.Rush_Section_Patches.SelectedSection = false;
            this.Rush_Section_Patches.Size = new System.Drawing.Size(250, 35);
            this.Rush_Section_Patches.TabIndex = 22;
            this.Rush_Section_Patches.TextColour = System.Drawing.SystemColors.Control;
            this.Rush_Section_Patches.Click += new System.EventHandler(this.Rush_Section_Click);
            // 
            // Rush_Section_About
            // 
            this.Rush_Section_About.AccentColour = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Rush_Section_About.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Rush_Section_About.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(45)))));
            this.Rush_Section_About.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rush_Section_About.Location = new System.Drawing.Point(0, 1142);
            this.Rush_Section_About.Name = "Rush_Section_About";
            this.Rush_Section_About.SectionImage = global::Unify.Properties.Resources.InformationSymbol_16x;
            this.Rush_Section_About.SectionText = "About";
            this.Rush_Section_About.SelectedSection = false;
            this.Rush_Section_About.Size = new System.Drawing.Size(250, 35);
            this.Rush_Section_About.TabIndex = 20;
            this.Rush_Section_About.TextColour = System.Drawing.SystemColors.Control;
            this.Rush_Section_About.Click += new System.EventHandler(this.Rush_Section_Click);
            // 
            // Rush_Section_Emulator
            // 
            this.Rush_Section_Emulator.AccentColour = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Rush_Section_Emulator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(45)))));
            this.Rush_Section_Emulator.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rush_Section_Emulator.Location = new System.Drawing.Point(0, 99);
            this.Rush_Section_Emulator.Name = "Rush_Section_Emulator";
            this.Rush_Section_Emulator.SectionImage = global::Unify.Properties.Resources.Disc;
            this.Rush_Section_Emulator.SectionText = "Emulator";
            this.Rush_Section_Emulator.SelectedSection = false;
            this.Rush_Section_Emulator.Size = new System.Drawing.Size(250, 35);
            this.Rush_Section_Emulator.TabIndex = 19;
            this.Rush_Section_Emulator.TextColour = System.Drawing.SystemColors.Control;
            this.Rush_Section_Emulator.Click += new System.EventHandler(this.Rush_Section_Click);
            // 
            // Rush_Section_Mods
            // 
            this.Rush_Section_Mods.AccentColour = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Rush_Section_Mods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(45)))));
            this.Rush_Section_Mods.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rush_Section_Mods.Location = new System.Drawing.Point(0, 63);
            this.Rush_Section_Mods.Name = "Rush_Section_Mods";
            this.Rush_Section_Mods.SectionImage = global::Unify.Properties.Resources.ConfigurationFile_16x;
            this.Rush_Section_Mods.SectionText = "Mods";
            this.Rush_Section_Mods.SelectedSection = true;
            this.Rush_Section_Mods.Size = new System.Drawing.Size(250, 35);
            this.Rush_Section_Mods.TabIndex = 18;
            this.Rush_Section_Mods.TextColour = System.Drawing.SystemColors.Control;
            this.Rush_Section_Mods.Click += new System.EventHandler(this.Rush_Section_Click);
            // 
            // Container_Rush
            // 
            this.Container_Rush.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Container_Rush.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Container_Rush.IsSplitterFixed = true;
            this.Container_Rush.LeftPanelMinimumSize = 250;
            this.Container_Rush.Location = new System.Drawing.Point(0, 0);
            this.Container_Rush.Name = "Container_Rush";
            this.Container_Rush.SideColour = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Container_Rush.Size = new System.Drawing.Size(849, 1178);
            this.Container_Rush.SplitterDistance = 250;
            this.Container_Rush.TabIndex = 17;
            this.Container_Rush.Title = "Mods";
            // 
            // RushInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Controls.Add(this.Panel_MainControls);
            this.Controls.Add(this.TabControl_Rush);
            this.Controls.Add(this.Label_Status);
            this.Controls.Add(this.StatusStrip_Main);
            this.Controls.Add(this.Rush_Section_Debug);
            this.Controls.Add(this.Rush_Section_Updates);
            this.Controls.Add(this.Rush_Section_Tweaks);
            this.Controls.Add(this.Rush_Section_Settings);
            this.Controls.Add(this.Rush_Section_Patches);
            this.Controls.Add(this.Rush_Section_About);
            this.Controls.Add(this.Rush_Section_Emulator);
            this.Controls.Add(this.Rush_Section_Mods);
            this.Controls.Add(this.Container_Rush);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Name = "RushInterface";
            this.Size = new System.Drawing.Size(849, 1200);
            this.Load += new System.EventHandler(this.RushInterface_Load);
            this.Resize += new System.EventHandler(this.RushInterface_Resize);
            this.Panel_MainControls.ResumeLayout(false);
            this.SplitContainer_MainControls.Panel1.ResumeLayout(false);
            this.SplitContainer_MainControls.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_MainControls)).EndInit();
            this.SplitContainer_MainControls.ResumeLayout(false);
            this.TabControl_Rush.ResumeLayout(false);
            this.Tab_Section_Mods.ResumeLayout(false);
            this.SplitContainer_ModsControls.Panel1.ResumeLayout(false);
            this.SplitContainer_ModsControls.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_ModsControls)).EndInit();
            this.SplitContainer_ModsControls.ResumeLayout(false);
            this.Panel_ModBackdrop.ResumeLayout(false);
            this.Tab_Section_Emulator.ResumeLayout(false);
            this.Tab_Section_Emulator.PerformLayout();
            this.Tab_Section_Patches.ResumeLayout(false);
            this.SplitContainer_PatchesControls.Panel1.ResumeLayout(false);
            this.SplitContainer_PatchesControls.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_PatchesControls)).EndInit();
            this.SplitContainer_PatchesControls.ResumeLayout(false);
            this.Panel_PatchBackdrop.ResumeLayout(false);
            this.Tab_Section_Tweaks.ResumeLayout(false);
            this.Tab_Section_Tweaks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_BeginWithRings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_FieldOfView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_CameraHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_CameraDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_AmyHammerRange)).EndInit();
            this.Tab_Section_Debug.ResumeLayout(false);
            this.Tab_Section_Debug.PerformLayout();
            this.Panel_DebugControls.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.Tab_Section_Updates.ResumeLayout(false);
            this.Tab_Section_Updates.PerformLayout();
            this.SplitContainer_ModUpdate.Panel1.ResumeLayout(false);
            this.SplitContainer_ModUpdate.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_ModUpdate)).EndInit();
            this.SplitContainer_ModUpdate.ResumeLayout(false);
            this.Panel_ModUpdateBackdrop.ResumeLayout(false);
            this.Panel_ModInfoBackdrop.ResumeLayout(false);
            this.Panel_ChangelogsBackdrop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_UpdaterIcon)).EndInit();
            this.Tab_Section_Settings.ResumeLayout(false);
            this.Tab_Section_Settings.PerformLayout();
            this.Tab_Section_About.ResumeLayout(false);
            this.Tab_Section_About.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private UserContainer Container_Rush;
        private SectionButton Rush_Section_About;
        private SectionButton Rush_Section_Emulator;
        private SectionButton Rush_Section_Mods;
        private SectionButton Rush_Section_Patches;
        private SectionButton Rush_Section_Settings;
        private System.Windows.Forms.TabPage Tab_Section_Mods;
        private System.Windows.Forms.TabPage Tab_Section_Emulator;
        private System.Windows.Forms.TabPage Tab_Section_Patches;
        private WindowsColourPicker WindowsColourPicker_AccentColour;
        private System.Windows.Forms.TextBox TextBox_GameDirectory;
        private System.Windows.Forms.Label Label_Title_Appearance;
        private System.Windows.Forms.CheckBox CheckBox_HighContrastText;
        private System.Windows.Forms.Label Label_Title_General;
        private System.Windows.Forms.Label Label_Subtitle_AccentColour;
        private System.Windows.Forms.Label Label_GameExecutable;
        private System.Windows.Forms.Panel Panel_Settings_UICleanSpace;
        private System.Windows.Forms.Label Label_WindowsColours;
        private System.Windows.Forms.Button Button_GameDirectory;
        private System.Windows.Forms.Label Label_Subtitle_Appearance_Options;
        private System.Windows.Forms.CheckBox CheckBox_AutoColour;
        private System.Windows.Forms.Label Label_Description_GameExecutable;
        private System.Windows.Forms.Button Button_ColourPicker_Preview;
        private System.Windows.Forms.Label Label_Subtitle_Settings_Paths;
        private System.Windows.Forms.Button Button_ColourPicker_Default;
        private System.Windows.Forms.Button Button_ModsDirectory;
        private SectionButton Section_Appearance_ColourPicker;
        private System.Windows.Forms.TextBox TextBox_ModsDirectory;
        private System.Windows.Forms.CheckBox CheckBox_CheckUpdatesOnLaunch;
        private System.Windows.Forms.Label Label_ModsDirectory;
        private System.Windows.Forms.TabPage Tab_Section_Settings;
        private System.Windows.Forms.TabPage Tab_Section_About;
        private UnifyTabControl TabControl_Rush;
        private System.Windows.Forms.TabPage Tab_Section_Debug;
        private SectionButton Rush_Section_Debug;
        private System.Windows.Forms.ListBox ListBox_Debug;
        private System.Windows.Forms.Panel Panel_DebugControls;
        private SectionButton SectionButton_ClearLog;
        private System.Windows.Forms.Panel Panel_ModBackdrop;
        private System.Windows.Forms.ListView ListView_ModsList;
        private System.Windows.Forms.ColumnHeader Column_ModsList_Title;
        private System.Windows.Forms.ColumnHeader Column_ModsList_Version;
        private System.Windows.Forms.ColumnHeader Column_ModsList_Author;
        private System.Windows.Forms.ColumnHeader Column_ModsList_System;
        private System.Windows.Forms.ColumnHeader Column_ModsList_Merge;
        private System.Windows.Forms.ColumnHeader Column_ModsList_Blank;
        private System.Windows.Forms.Button Button_Mods_Priority;
        private System.Windows.Forms.Button Button_Mods_DownerPriority;
        private System.Windows.Forms.Button Button_Mods_UpperPriority;
        private System.Windows.Forms.Button Button_Mods_DeselectAll;
        private System.Windows.Forms.Button Button_Mods_SelectAll;
        private SectionButton SectionButton_InstallMods;
        private SectionButton SectionButton_LaunchGame;
        private System.Windows.Forms.StatusStrip StatusStrip_Main;
        private System.Windows.Forms.Label Label_Status;
        private System.Windows.Forms.TextBox TextBox_SaveData;
        private System.Windows.Forms.Label Label_SaveData;
        private System.Windows.Forms.Label Label_Description_EmulatorExecutable;
        private System.Windows.Forms.Button Button_SaveData;
        private System.Windows.Forms.Label Label_Description_SaveData;
        private System.Windows.Forms.Label Label_Subtitle_Emulator_Paths;
        private System.Windows.Forms.Button Button_EmulatorExecutable;
        private System.Windows.Forms.TextBox TextBox_EmulatorExecutable;
        private System.Windows.Forms.Label Label_EmulatorExecutable;
        private System.Windows.Forms.Label Label_API;
        private System.Windows.Forms.ComboBox ComboBox_API;
        private System.Windows.Forms.Label Label_Subtitle_Emulator_Options;
        private System.Windows.Forms.CheckBox CheckBox_Xenia_Gamma;
        private System.Windows.Forms.CheckBox CheckBox_Xenia_VerticalSync;
        private System.Windows.Forms.Label Label_RPCS3Warning;
        private System.Windows.Forms.CheckBox CheckBox_Xenia_DiscordRPC;
        private System.Windows.Forms.CheckBox CheckBox_Xenia_Fullscreen;
        private System.Windows.Forms.Panel Panel_PatchBackdrop;
        private System.Windows.Forms.ListView ListView_PatchesList;
        private System.Windows.Forms.ColumnHeader Column_PatchesList_Title;
        private System.Windows.Forms.ColumnHeader Column_PatchesList_Author;
        private System.Windows.Forms.ColumnHeader Column_PatchesList_System;
        private System.Windows.Forms.ColumnHeader Column_PatchesList_Blank;
        private System.Windows.Forms.ColumnHeader Column_PatchesList_Blurb;
        private System.Windows.Forms.Button Button_Patches_DeselectAll;
        private System.Windows.Forms.Button Button_Patches_SelectAll;
        private SectionButton Rush_Section_Updates;
        private System.Windows.Forms.TabPage Tab_Section_Updates;
        private System.Windows.Forms.Label Label_Version;
        private System.Windows.Forms.Label Label_Optional_SaveData;
        private System.Windows.Forms.Label Label_Title_Software;
        private System.Windows.Forms.RichTextBox RichTextBox_Changelogs;
        private System.Windows.Forms.PictureBox PictureBox_UpdaterIcon;
        private System.Windows.Forms.Label Label_UpdaterStatus;
        private SectionButton SectionButton_CheckForSoftwareUpdates;
        private System.Windows.Forms.Panel Panel_ChangelogsBackdrop;
        private System.Windows.Forms.Label Label_Subtitle_Changelogs;
        private SectionButton SectionButton_UpdateMods;
        private System.Windows.Forms.SplitContainer SplitContainer_ModUpdate;
        private System.Windows.Forms.Panel Panel_ModUpdateBackdrop;
        private System.Windows.Forms.ProgressBar ProgressBar_ModUpdate;
        private System.Windows.Forms.Panel Panel_ModInfoBackdrop;
        private System.Windows.Forms.Label Label_Title_ModsAndPatches;
        private System.Windows.Forms.Label Label_Description_LaunchEmulator;
        private System.Windows.Forms.CheckBox CheckBox_LaunchEmulator;
        private System.Windows.Forms.Label Label_Subtitle_General_Options;
        private System.Windows.Forms.CheckBox CheckBox_DebugMode;
        private System.Windows.Forms.Button Button_Open_EmulatorExecutable;
        private System.Windows.Forms.Button Button_Open_SaveData;
        private System.Windows.Forms.Button Button_Open_GameDirectory;
        private System.Windows.Forms.Button Button_Open_ModsDirectory;
        private System.Windows.Forms.Label Label_Description_DebugMode;
        private System.Windows.Forms.Label Label_Description_HighContrastText;
        private System.Windows.Forms.Label Label_Description_SaveFileRedirect;
        private System.Windows.Forms.CheckBox CheckBox_SaveFileRedirection;
        private SectionButton SectionButton_SaveChecks;
        private System.Windows.Forms.SplitContainer SplitContainer_ModsControls;
        private System.Windows.Forms.Label Label_Description_Reset;
        private System.Windows.Forms.LinkLabel LinkLabel_Reset;
        private System.Windows.Forms.Label Label_LastSoftwareUpdate;
        private System.Windows.Forms.ProgressBar ProgressBar_SoftwareUpdate;
        private System.Windows.Forms.Label Label_Description_API;
        private SectionButton SectionButton_RefreshMods;
        private SectionButton SectionButton_CheckForModUpdates;
        private System.Windows.Forms.ListBox ListBox_UpdateLogs;
        private System.Windows.Forms.Label Label_LastPatchUpdate;
        private System.Windows.Forms.Label Label_LastModUpdate;
        private SectionButton SectionButton_FetchPatches;
        private System.Windows.Forms.Label Label_Description_1ClickURLHandler;
        private System.Windows.Forms.LinkLabel LinkLabel_1ClickURLHandler;
        private System.Windows.Forms.Label Label_Warning_ModsDirectoryInvalid;
        private System.Windows.Forms.Label Label_Description_ModsDirectory;
        private System.Windows.Forms.Label Label_Contributors;
        private System.Windows.Forms.Label Title_Contributors;
        private SectionButton SectionButton_RefreshPatches;
        private System.Windows.Forms.SplitContainer SplitContainer_PatchesControls;
        private SectionButton SectionButton_SaveCheckedPatches;
        private SectionButton Rush_Section_Tweaks;
        private System.Windows.Forms.TabPage Tab_Section_Tweaks;
        private System.Windows.Forms.Label Label_Description_AmyHammerRange;
        private System.Windows.Forms.Label Label_AmyHammerRange;
        private System.Windows.Forms.Label Label_Subtitle_CharacterTweaks;
        private System.Windows.Forms.Label Label_Description_FieldOfView;
        private System.Windows.Forms.Label Label_FieldOfView;
        private System.Windows.Forms.NumericUpDown NumericUpDown_FieldOfView;
        private System.Windows.Forms.Label Label_Description_CameraHeight;
        private System.Windows.Forms.Label Label_CameraHeight;
        private System.Windows.Forms.NumericUpDown NumericUpDown_CameraHeight;
        private System.Windows.Forms.Label Label_Description_CameraDistance;
        private System.Windows.Forms.Label Label_CameraDistance;
        private System.Windows.Forms.NumericUpDown NumericUpDown_CameraDistance;
        private System.Windows.Forms.Label Label_Description_CameraType;
        private System.Windows.Forms.Label Label_CameraType;
        private System.Windows.Forms.ComboBox ComboBox_CameraType;
        private System.Windows.Forms.Label Label_Subtitle_CameraTweaks;
        private System.Windows.Forms.Label Label_Description_ForceMSAA;
        private System.Windows.Forms.CheckBox CheckBox_ForceMSAA;
        private System.Windows.Forms.Label Label_Description_AntiAliasing;
        private System.Windows.Forms.Label Label_AntiAliasing;
        private System.Windows.Forms.ComboBox ComboBox_AntiAliasing;
        private System.Windows.Forms.Label Label_Description_Reflections;
        private System.Windows.Forms.Label Label_Reflections;
        private System.Windows.Forms.ComboBox ComboBox_Reflections;
        private System.Windows.Forms.Label Label_Description_Renderer;
        private System.Windows.Forms.Label Label_Renderer;
        private System.Windows.Forms.ComboBox ComboBox_Renderer;
        private System.Windows.Forms.Label Label_Subtitle_GraphicsTweaks;
        private System.Windows.Forms.NumericUpDown NumericUpDown_AmyHammerRange;
        private System.Windows.Forms.Panel Panel_Tweaks_UICleanSpace;
        private System.Windows.Forms.Button Button_AmyHammerRange_Default;
        private System.Windows.Forms.Button Button_FieldOfView_Default;
        private System.Windows.Forms.Button Button_CameraHeight_Default;
        private System.Windows.Forms.Button Button_CameraDistance_Default;
        private System.Windows.Forms.Button Button_CameraType_Default;
        private System.Windows.Forms.Button Button_AntiAliasing_Default;
        private System.Windows.Forms.Button Button_Reflections_Default;
        private System.Windows.Forms.Button Button_Renderer_Default;
        private System.Windows.Forms.LinkLabel LinkLabel_Contributors_Radfordhound;
        private System.Windows.Forms.LinkLabel LinkLabel_SuperSonic16;
        private System.Windows.Forms.LinkLabel LinkLabel_GerbilSoft;
        private System.Windows.Forms.LinkLabel LinkLabel_Knuxfan24;
        private System.Windows.Forms.LinkLabel LinkLabel_HyperBE32;
        private System.Windows.Forms.Label Label_Description_UninstallOnLaunch;
        private System.Windows.Forms.CheckBox CheckBox_UninstallOnLaunch;
        private System.Windows.Forms.LinkLabel LinkLabel_Snapshot_Create;
        private System.Windows.Forms.Label Label_Description_Snapshot;
        private System.Windows.Forms.Panel Panel_MainControls;
        private System.Windows.Forms.SplitContainer SplitContainer_MainControls;
        private System.Windows.Forms.Panel Panel_Updates_UICleanSpace;
        private System.Windows.Forms.Label Label_Description_DiscordRPC;
        private System.Windows.Forms.Label Label_Description_Fullscreen;
        private System.Windows.Forms.Label Label_Description_Gamma;
        private System.Windows.Forms.Label Label_Description_VerticalSync;
        private System.Windows.Forms.Label Label_Description_UserLanguage;
        private System.Windows.Forms.Label Label_UserLanguage;
        private System.Windows.Forms.ComboBox ComboBox_UserLanguage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBox_Arguments;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Button_BeginWithRings_Default;
        private System.Windows.Forms.Label Label_Description_BeginWithRings;
        private System.Windows.Forms.Label Label_BeginWithRings;
        private System.Windows.Forms.NumericUpDown NumericUpDown_BeginWithRings;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel LinkLabel_Snapshot_Load;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView ListView_ModUpdates;
        private System.Windows.Forms.ColumnHeader Column_ModUpdates_Title;
        private System.Windows.Forms.ColumnHeader Column_ModUpdates_Blank;
        private System.Windows.Forms.LinkLabel LinkLabel_Troubleshoot_Mod;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox CheckBox_AllowModStacking;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button Button_Patches_Priority;
        private System.Windows.Forms.Button Button_Patches_DownerPriority;
        private System.Windows.Forms.Button Button_Patches_UpperPriority;
        private System.Windows.Forms.ToolTip ToolTip_Information;
        private System.Windows.Forms.LinkLabel LinkLabel_Testers_Radfordhound;
        private System.Windows.Forms.LinkLabel LinkLabel_Velcomia;
        private System.Windows.Forms.LinkLabel LinkLabel_Melpontro;
        private System.Windows.Forms.LinkLabel LinkLabel_sharu6262;
        private System.Windows.Forms.Label Label_Testers;
        private System.Windows.Forms.Label Title_Testers;
        private System.Windows.Forms.LinkLabel LinkLabel_LoadProfile;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.LinkLabel LinkLabel_CreateProfile;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.LinkLabel LinkLabel_OpenProfilesDirectory;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label Label_Description_Resolution;
        private System.Windows.Forms.Label Label_Resolution;
        private System.Windows.Forms.ComboBox ComboBox_Resolution;
        private System.Windows.Forms.LinkLabel LinkLabel_Contributors_VolcanoTheBat;
    }
}