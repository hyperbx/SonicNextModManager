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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RushInterface));
            this.StatusStrip_Main = new System.Windows.Forms.StatusStrip();
            this.Label_Status = new System.Windows.Forms.Label();
            this.Rush_Section_Updates = new Unify.Environment3.SectionButton();
            this.Rush_Section_Debug = new Unify.Environment3.SectionButton();
            this.TabControl_Rush = new Unify.Environment3.UnifyTabControl();
            this.Tab_Section_Mods = new System.Windows.Forms.TabPage();
            this.SplitContainer_ModsControls = new System.Windows.Forms.SplitContainer();
            this.SectionButton_InstallMods = new Unify.Environment3.SectionButton();
            this.SectionButton_SaveChecks = new Unify.Environment3.SectionButton();
            this.SectionButton_CreateNewMod = new Unify.Environment3.SectionButton();
            this.Button_Priority = new System.Windows.Forms.Button();
            this.Button_DownerPriority = new System.Windows.Forms.Button();
            this.Button_UpperPriority = new System.Windows.Forms.Button();
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
            this.Tab_Section_ModCreator = new System.Windows.Forms.TabPage();
            this.Tab_Section_Emulator = new System.Windows.Forms.TabPage();
            this.Button_Open_SaveData = new System.Windows.Forms.Button();
            this.Button_Open_EmulatorExecutable = new System.Windows.Forms.Button();
            this.Label_RPCS3Warning = new System.Windows.Forms.Label();
            this.CheckBox_Xenia_DiscordRPC = new System.Windows.Forms.CheckBox();
            this.CheckBox_Xenia_Fullscreen = new System.Windows.Forms.CheckBox();
            this.CheckBox_Xenia_Gamma = new System.Windows.Forms.CheckBox();
            this.CheckBox_Xenia_VerticalSync = new System.Windows.Forms.CheckBox();
            this.CheckBox_Xenia_2xResolution = new System.Windows.Forms.CheckBox();
            this.CheckBox_Xenia_ForceRTV = new System.Windows.Forms.CheckBox();
            this.Label_GraphicsAPI = new System.Windows.Forms.Label();
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
            this.TabControl_Patches = new Unify.Environment3.UnifyTabControl();
            this.Tab_Patches_Simple = new System.Windows.Forms.TabPage();
            this.Button_Patches_DeselectAll = new System.Windows.Forms.Button();
            this.Panel_PatchBackdrop = new System.Windows.Forms.Panel();
            this.ListView_PatchesList = new System.Windows.Forms.ListView();
            this.Column_PatchesList_Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Column_PatchesList_Author = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Column_PatchesList_System = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Column_PatchesList_Blurb = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Column_PatchesList_Blank = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Button_Patches_SelectAll = new System.Windows.Forms.Button();
            this.Tab_Patches_Advanced = new System.Windows.Forms.TabPage();
            this.Tab_Section_Settings = new System.Windows.Forms.TabPage();
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
            this.Label_Description_ModsDirectory = new System.Windows.Forms.Label();
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
            this.Tab_Section_Debug = new System.Windows.Forms.TabPage();
            this.Panel_DebugControls = new System.Windows.Forms.Panel();
            this.SectionButton_ClearLog = new Unify.Environment3.SectionButton();
            this.ListBox_Debug = new System.Windows.Forms.ListBox();
            this.Tab_Section_Updates = new System.Windows.Forms.TabPage();
            this.Label_LastUpdateCheck = new System.Windows.Forms.Label();
            this.SectionButton_FetchLatestPatches = new Unify.Environment3.SectionButton();
            this.SplitContainer_ModUpdate = new System.Windows.Forms.SplitContainer();
            this.Button_ModUpdate = new System.Windows.Forms.Button();
            this.Panel_ModUpdateBackdrop = new System.Windows.Forms.Panel();
            this.ListView_ModUpdate = new System.Windows.Forms.ListBox();
            this.ProgressBar_ModUpdate = new System.Windows.Forms.ProgressBar();
            this.Panel_ModInfoBackdrop = new System.Windows.Forms.Panel();
            this.RichTextBox_ModInformation = new System.Windows.Forms.RichTextBox();
            this.Label_Title_ModsAndPatches = new System.Windows.Forms.Label();
            this.Label_Subtitle_Changelogs = new System.Windows.Forms.Label();
            this.Label_UpdaterStatus = new System.Windows.Forms.Label();
            this.Panel_ChangelogsBackdrop = new System.Windows.Forms.Panel();
            this.RichTextBox_Changelogs = new System.Windows.Forms.RichTextBox();
            this.Label_Title_Software = new System.Windows.Forms.Label();
            this.CheckBox_CheckUpdatesOnLaunch = new System.Windows.Forms.CheckBox();
            this.Panel_Updates_UICleanSpace = new System.Windows.Forms.Panel();
            this.PictureBox_UpdaterIcon = new System.Windows.Forms.PictureBox();
            this.ProgressBar_SoftwareUpdate = new System.Windows.Forms.ProgressBar();
            this.SectionButton_CheckForUpdates = new Unify.Environment3.SectionButton();
            this.Tab_Section_About = new System.Windows.Forms.TabPage();
            this.Label_Version = new System.Windows.Forms.Label();
            this.Rush_Section_Settings = new Unify.Environment3.SectionButton();
            this.Rush_Section_Patches = new Unify.Environment3.SectionButton();
            this.Rush_Section_About = new Unify.Environment3.SectionButton();
            this.Rush_Section_Emulator = new Unify.Environment3.SectionButton();
            this.Rush_Section_Mods = new Unify.Environment3.SectionButton();
            this.Container_Rush = new Unify.Environment3.UserContainer();
            this.TabControl_Rush.SuspendLayout();
            this.Tab_Section_Mods.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_ModsControls)).BeginInit();
            this.SplitContainer_ModsControls.Panel1.SuspendLayout();
            this.SplitContainer_ModsControls.Panel2.SuspendLayout();
            this.SplitContainer_ModsControls.SuspendLayout();
            this.Panel_ModBackdrop.SuspendLayout();
            this.Tab_Section_Emulator.SuspendLayout();
            this.Tab_Section_Patches.SuspendLayout();
            this.TabControl_Patches.SuspendLayout();
            this.Tab_Patches_Simple.SuspendLayout();
            this.Panel_PatchBackdrop.SuspendLayout();
            this.Tab_Section_Settings.SuspendLayout();
            this.Tab_Section_Debug.SuspendLayout();
            this.Panel_DebugControls.SuspendLayout();
            this.Tab_Section_Updates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_ModUpdate)).BeginInit();
            this.SplitContainer_ModUpdate.Panel1.SuspendLayout();
            this.SplitContainer_ModUpdate.Panel2.SuspendLayout();
            this.SplitContainer_ModUpdate.SuspendLayout();
            this.Panel_ModUpdateBackdrop.SuspendLayout();
            this.Panel_ModInfoBackdrop.SuspendLayout();
            this.Panel_ChangelogsBackdrop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_UpdaterIcon)).BeginInit();
            this.Tab_Section_About.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusStrip_Main
            // 
            this.StatusStrip_Main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.StatusStrip_Main.Location = new System.Drawing.Point(0, 944);
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
            this.Label_Status.Location = new System.Drawing.Point(3, 947);
            this.Label_Status.Name = "Label_Status";
            this.Label_Status.Size = new System.Drawing.Size(42, 15);
            this.Label_Status.TabIndex = 27;
            this.Label_Status.Text = "Ready.";
            // 
            // Rush_Section_Updates
            // 
            this.Rush_Section_Updates.AccentColour = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Rush_Section_Updates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Rush_Section_Updates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(45)))));
            this.Rush_Section_Updates.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rush_Section_Updates.Location = new System.Drawing.Point(0, 872);
            this.Rush_Section_Updates.Name = "Rush_Section_Updates";
            this.Rush_Section_Updates.SectionImage = global::Unify.Properties.Resources.Update_4;
            this.Rush_Section_Updates.SectionText = "Updates";
            this.Rush_Section_Updates.SelectedSection = false;
            this.Rush_Section_Updates.Size = new System.Drawing.Size(250, 35);
            this.Rush_Section_Updates.TabIndex = 28;
            this.Rush_Section_Updates.Click += new System.EventHandler(this.Rush_Section_Click);
            // 
            // Rush_Section_Debug
            // 
            this.Rush_Section_Debug.AccentColour = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Rush_Section_Debug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Rush_Section_Debug.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(45)))));
            this.Rush_Section_Debug.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rush_Section_Debug.Location = new System.Drawing.Point(0, 836);
            this.Rush_Section_Debug.Name = "Rush_Section_Debug";
            this.Rush_Section_Debug.SectionImage = global::Unify.Properties.Resources.debug_6;
            this.Rush_Section_Debug.SectionText = "Debug";
            this.Rush_Section_Debug.SelectedSection = false;
            this.Rush_Section_Debug.Size = new System.Drawing.Size(250, 35);
            this.Rush_Section_Debug.TabIndex = 25;
            this.Rush_Section_Debug.Visible = false;
            this.Rush_Section_Debug.Click += new System.EventHandler(this.Rush_Section_Click);
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
            this.TabControl_Rush.Controls.Add(this.Tab_Section_ModCreator);
            this.TabControl_Rush.Controls.Add(this.Tab_Section_Emulator);
            this.TabControl_Rush.Controls.Add(this.Tab_Section_Patches);
            this.TabControl_Rush.Controls.Add(this.Tab_Section_Settings);
            this.TabControl_Rush.Controls.Add(this.Tab_Section_Debug);
            this.TabControl_Rush.Controls.Add(this.Tab_Section_Updates);
            this.TabControl_Rush.Controls.Add(this.Tab_Section_About);
            this.TabControl_Rush.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.TabControl_Rush.HorizontalLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.TabControl_Rush.ItemSize = new System.Drawing.Size(240, 16);
            this.TabControl_Rush.Location = new System.Drawing.Point(250, 2);
            this.TabControl_Rush.Name = "TabControl_Rush";
            this.TabControl_Rush.NoTabDisplay = true;
            this.TabControl_Rush.SelectedIndex = 0;
            this.TabControl_Rush.SelectedTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TabControl_Rush.ShowClosingButton = false;
            this.TabControl_Rush.ShowClosingMessage = false;
            this.TabControl_Rush.Size = new System.Drawing.Size(599, 945);
            this.TabControl_Rush.TabIndex = 22;
            this.TabControl_Rush.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TabControl_Rush.SelectedIndexChanged += new System.EventHandler(this.Rush_TabControl_SelectedIndexChanged);
            // 
            // Tab_Section_Mods
            // 
            this.Tab_Section_Mods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Tab_Section_Mods.Controls.Add(this.SplitContainer_ModsControls);
            this.Tab_Section_Mods.Controls.Add(this.SectionButton_CreateNewMod);
            this.Tab_Section_Mods.Controls.Add(this.Button_Priority);
            this.Tab_Section_Mods.Controls.Add(this.Button_DownerPriority);
            this.Tab_Section_Mods.Controls.Add(this.Button_UpperPriority);
            this.Tab_Section_Mods.Controls.Add(this.Button_Mods_DeselectAll);
            this.Tab_Section_Mods.Controls.Add(this.Button_Mods_SelectAll);
            this.Tab_Section_Mods.Controls.Add(this.Panel_ModBackdrop);
            this.Tab_Section_Mods.Location = new System.Drawing.Point(4, 20);
            this.Tab_Section_Mods.Name = "Tab_Section_Mods";
            this.Tab_Section_Mods.Size = new System.Drawing.Size(591, 921);
            this.Tab_Section_Mods.TabIndex = 0;
            this.Tab_Section_Mods.Text = "Mods";
            this.Tab_Section_Mods.Visible = false;
            // 
            // SplitContainer_ModsControls
            // 
            this.SplitContainer_ModsControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SplitContainer_ModsControls.IsSplitterFixed = true;
            this.SplitContainer_ModsControls.Location = new System.Drawing.Point(1, 841);
            this.SplitContainer_ModsControls.Name = "SplitContainer_ModsControls";
            // 
            // SplitContainer_ModsControls.Panel1
            // 
            this.SplitContainer_ModsControls.Panel1.Controls.Add(this.SectionButton_InstallMods);
            // 
            // SplitContainer_ModsControls.Panel2
            // 
            this.SplitContainer_ModsControls.Panel2.Controls.Add(this.SectionButton_SaveChecks);
            this.SplitContainer_ModsControls.Size = new System.Drawing.Size(586, 35);
            this.SplitContainer_ModsControls.SplitterDistance = 292;
            this.SplitContainer_ModsControls.SplitterWidth = 1;
            this.SplitContainer_ModsControls.TabIndex = 2;
            // 
            // SectionButton_InstallMods
            // 
            this.SectionButton_InstallMods.AccentColour = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SectionButton_InstallMods.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SectionButton_InstallMods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(45)))));
            this.SectionButton_InstallMods.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SectionButton_InstallMods.Location = new System.Drawing.Point(2, 0);
            this.SectionButton_InstallMods.Name = "SectionButton_InstallMods";
            this.SectionButton_InstallMods.SectionImage = global::Unify.Properties.Resources.InstallMods;
            this.SectionButton_InstallMods.SectionText = "Install mods";
            this.SectionButton_InstallMods.SelectedSection = false;
            this.SectionButton_InstallMods.Size = new System.Drawing.Size(293, 35);
            this.SectionButton_InstallMods.TabIndex = 50;
            this.SectionButton_InstallMods.Click += new System.EventHandler(this.SectionButton_InstallMods_Click);
            // 
            // SectionButton_SaveChecks
            // 
            this.SectionButton_SaveChecks.AccentColour = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SectionButton_SaveChecks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SectionButton_SaveChecks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(45)))));
            this.SectionButton_SaveChecks.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SectionButton_SaveChecks.Location = new System.Drawing.Point(0, 0);
            this.SectionButton_SaveChecks.Name = "SectionButton_SaveChecks";
            this.SectionButton_SaveChecks.SectionImage = global::Unify.Properties.Resources.CheckBox_16x_24;
            this.SectionButton_SaveChecks.SectionText = "Save checked mods";
            this.SectionButton_SaveChecks.SelectedSection = false;
            this.SectionButton_SaveChecks.Size = new System.Drawing.Size(407, 35);
            this.SectionButton_SaveChecks.TabIndex = 52;
            this.SectionButton_SaveChecks.Click += new System.EventHandler(this.SectionButton_SaveChecks_Click);
            // 
            // SectionButton_CreateNewMod
            // 
            this.SectionButton_CreateNewMod.AccentColour = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SectionButton_CreateNewMod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SectionButton_CreateNewMod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(45)))));
            this.SectionButton_CreateNewMod.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SectionButton_CreateNewMod.Location = new System.Drawing.Point(3, 877);
            this.SectionButton_CreateNewMod.Name = "SectionButton_CreateNewMod";
            this.SectionButton_CreateNewMod.SectionImage = global::Unify.Properties.Resources.NewFileCollection_16x;
            this.SectionButton_CreateNewMod.SectionText = "Create a new mod";
            this.SectionButton_CreateNewMod.SelectedSection = false;
            this.SectionButton_CreateNewMod.Size = new System.Drawing.Size(584, 35);
            this.SectionButton_CreateNewMod.TabIndex = 51;
            this.SectionButton_CreateNewMod.Click += new System.EventHandler(this.SectionButton_CreateNewMod_Click);
            // 
            // Button_Priority
            // 
            this.Button_Priority.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Priority.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Button_Priority.FlatAppearance.BorderSize = 0;
            this.Button_Priority.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Priority.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Button_Priority.Location = new System.Drawing.Point(409, 812);
            this.Button_Priority.Name = "Button_Priority";
            this.Button_Priority.Size = new System.Drawing.Size(178, 23);
            this.Button_Priority.TabIndex = 49;
            this.Button_Priority.Text = "Priority: Top to Bottom";
            this.Button_Priority.UseVisualStyleBackColor = false;
            this.Button_Priority.Click += new System.EventHandler(this.Button_Priority_Click);
            // 
            // Button_DownerPriority
            // 
            this.Button_DownerPriority.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_DownerPriority.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Button_DownerPriority.Enabled = false;
            this.Button_DownerPriority.FlatAppearance.BorderSize = 0;
            this.Button_DownerPriority.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_DownerPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_DownerPriority.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Button_DownerPriority.Location = new System.Drawing.Point(377, 812);
            this.Button_DownerPriority.Name = "Button_DownerPriority";
            this.Button_DownerPriority.Size = new System.Drawing.Size(26, 23);
            this.Button_DownerPriority.TabIndex = 48;
            this.Button_DownerPriority.Text = "▼";
            this.Button_DownerPriority.UseVisualStyleBackColor = false;
            this.Button_DownerPriority.Click += new System.EventHandler(this.Button_Priority_Iteration_Click);
            // 
            // Button_UpperPriority
            // 
            this.Button_UpperPriority.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_UpperPriority.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Button_UpperPriority.Enabled = false;
            this.Button_UpperPriority.FlatAppearance.BorderSize = 0;
            this.Button_UpperPriority.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_UpperPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_UpperPriority.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Button_UpperPriority.Location = new System.Drawing.Point(346, 812);
            this.Button_UpperPriority.Name = "Button_UpperPriority";
            this.Button_UpperPriority.Size = new System.Drawing.Size(26, 23);
            this.Button_UpperPriority.TabIndex = 47;
            this.Button_UpperPriority.Text = "▲";
            this.Button_UpperPriority.UseVisualStyleBackColor = false;
            this.Button_UpperPriority.Click += new System.EventHandler(this.Button_Priority_Iteration_Click);
            // 
            // Button_Mods_DeselectAll
            // 
            this.Button_Mods_DeselectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Button_Mods_DeselectAll.BackColor = System.Drawing.Color.Tomato;
            this.Button_Mods_DeselectAll.FlatAppearance.BorderSize = 0;
            this.Button_Mods_DeselectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Mods_DeselectAll.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Button_Mods_DeselectAll.Location = new System.Drawing.Point(175, 812);
            this.Button_Mods_DeselectAll.Name = "Button_Mods_DeselectAll";
            this.Button_Mods_DeselectAll.Size = new System.Drawing.Size(165, 23);
            this.Button_Mods_DeselectAll.TabIndex = 46;
            this.Button_Mods_DeselectAll.Text = "Deselect All";
            this.Button_Mods_DeselectAll.UseVisualStyleBackColor = false;
            this.Button_Mods_DeselectAll.Click += new System.EventHandler(this.Button_Mods_Selection_Click);
            // 
            // Button_Mods_SelectAll
            // 
            this.Button_Mods_SelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Button_Mods_SelectAll.BackColor = System.Drawing.Color.SkyBlue;
            this.Button_Mods_SelectAll.FlatAppearance.BorderSize = 0;
            this.Button_Mods_SelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Mods_SelectAll.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Button_Mods_SelectAll.Location = new System.Drawing.Point(3, 812);
            this.Button_Mods_SelectAll.Name = "Button_Mods_SelectAll";
            this.Button_Mods_SelectAll.Size = new System.Drawing.Size(166, 23);
            this.Button_Mods_SelectAll.TabIndex = 45;
            this.Button_Mods_SelectAll.Text = "Select All";
            this.Button_Mods_SelectAll.UseVisualStyleBackColor = false;
            this.Button_Mods_SelectAll.Click += new System.EventHandler(this.Button_Mods_Selection_Click);
            // 
            // Panel_ModBackdrop
            // 
            this.Panel_ModBackdrop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_ModBackdrop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Panel_ModBackdrop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel_ModBackdrop.Controls.Add(this.ListView_ModsList);
            this.Panel_ModBackdrop.Location = new System.Drawing.Point(3, 5);
            this.Panel_ModBackdrop.Name = "Panel_ModBackdrop";
            this.Panel_ModBackdrop.Size = new System.Drawing.Size(584, 801);
            this.Panel_ModBackdrop.TabIndex = 44;
            // 
            // ListView_ModsList
            // 
            this.ListView_ModsList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.ListView_ModsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListView_ModsList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
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
            this.ListView_ModsList.Size = new System.Drawing.Size(582, 816);
            this.ListView_ModsList.TabIndex = 1;
            this.ListView_ModsList.UseCompatibleStateImageBehavior = false;
            this.ListView_ModsList.View = System.Windows.Forms.View.Details;
            this.ListView_ModsList.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.ListView_DrawColumnHeader);
            this.ListView_ModsList.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.ListView_DrawItem);
            this.ListView_ModsList.SelectedIndexChanged += new System.EventHandler(this.ListView_ModsList_SelectedIndexChanged);
            this.ListView_ModsList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListView_ModsList_MouseClick);
            // 
            // Column_ModsList_Title
            // 
            this.Column_ModsList_Title.Text = "Title";
            this.Column_ModsList_Title.Width = 250;
            // 
            // Column_ModsList_Version
            // 
            this.Column_ModsList_Version.Text = "Version";
            this.Column_ModsList_Version.Width = 52;
            // 
            // Column_ModsList_Author
            // 
            this.Column_ModsList_Author.Text = "Author";
            this.Column_ModsList_Author.Width = 90;
            // 
            // Column_ModsList_System
            // 
            this.Column_ModsList_System.Text = "System";
            this.Column_ModsList_System.Width = 86;
            // 
            // Column_ModsList_Merge
            // 
            this.Column_ModsList_Merge.Text = "Merge";
            this.Column_ModsList_Merge.Width = 59;
            // 
            // Column_ModsList_Blank
            // 
            this.Column_ModsList_Blank.Text = "";
            this.Column_ModsList_Blank.Width = 904;
            // 
            // Tab_Section_ModCreator
            // 
            this.Tab_Section_ModCreator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Tab_Section_ModCreator.Location = new System.Drawing.Point(4, 20);
            this.Tab_Section_ModCreator.Name = "Tab_Section_ModCreator";
            this.Tab_Section_ModCreator.Size = new System.Drawing.Size(591, 921);
            this.Tab_Section_ModCreator.TabIndex = 7;
            this.Tab_Section_ModCreator.Text = "Mod Creator";
            // 
            // Tab_Section_Emulator
            // 
            this.Tab_Section_Emulator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Tab_Section_Emulator.Controls.Add(this.Button_Open_SaveData);
            this.Tab_Section_Emulator.Controls.Add(this.Button_Open_EmulatorExecutable);
            this.Tab_Section_Emulator.Controls.Add(this.Label_RPCS3Warning);
            this.Tab_Section_Emulator.Controls.Add(this.CheckBox_Xenia_DiscordRPC);
            this.Tab_Section_Emulator.Controls.Add(this.CheckBox_Xenia_Fullscreen);
            this.Tab_Section_Emulator.Controls.Add(this.CheckBox_Xenia_Gamma);
            this.Tab_Section_Emulator.Controls.Add(this.CheckBox_Xenia_VerticalSync);
            this.Tab_Section_Emulator.Controls.Add(this.CheckBox_Xenia_2xResolution);
            this.Tab_Section_Emulator.Controls.Add(this.CheckBox_Xenia_ForceRTV);
            this.Tab_Section_Emulator.Controls.Add(this.Label_GraphicsAPI);
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
            this.Tab_Section_Emulator.Size = new System.Drawing.Size(591, 921);
            this.Tab_Section_Emulator.TabIndex = 1;
            this.Tab_Section_Emulator.Text = "Emulator";
            this.Tab_Section_Emulator.Visible = false;
            // 
            // Button_Open_SaveData
            // 
            this.Button_Open_SaveData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Open_SaveData.FlatAppearance.BorderSize = 0;
            this.Button_Open_SaveData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Button_Open_SaveData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Button_Open_SaveData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Open_SaveData.Image = global::Unify.Properties.Resources.Open_grey_16x;
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
            this.Button_Open_EmulatorExecutable.Image = global::Unify.Properties.Resources.Open_grey_16x;
            this.Button_Open_EmulatorExecutable.Location = new System.Drawing.Point(554, 70);
            this.Button_Open_EmulatorExecutable.Name = "Button_Open_EmulatorExecutable";
            this.Button_Open_EmulatorExecutable.Size = new System.Drawing.Size(21, 20);
            this.Button_Open_EmulatorExecutable.TabIndex = 142;
            this.Button_Open_EmulatorExecutable.UseVisualStyleBackColor = true;
            this.Button_Open_EmulatorExecutable.Click += new System.EventHandler(this.Button_Open_Click);
            // 
            // Label_RPCS3Warning
            // 
            this.Label_RPCS3Warning.AutoSize = true;
            this.Label_RPCS3Warning.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_RPCS3Warning.ForeColor = System.Drawing.Color.Tomato;
            this.Label_RPCS3Warning.Location = new System.Drawing.Point(149, 172);
            this.Label_RPCS3Warning.Name = "Label_RPCS3Warning";
            this.Label_RPCS3Warning.Size = new System.Drawing.Size(425, 15);
            this.Label_RPCS3Warning.TabIndex = 67;
            this.Label_RPCS3Warning.Text = "RPCS3 does not support command line instructions - please configure internally!";
            this.Label_RPCS3Warning.Visible = false;
            // 
            // CheckBox_Xenia_DiscordRPC
            // 
            this.CheckBox_Xenia_DiscordRPC.AutoSize = true;
            this.CheckBox_Xenia_DiscordRPC.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox_Xenia_DiscordRPC.Location = new System.Drawing.Point(14, 390);
            this.CheckBox_Xenia_DiscordRPC.Name = "CheckBox_Xenia_DiscordRPC";
            this.CheckBox_Xenia_DiscordRPC.Size = new System.Drawing.Size(142, 19);
            this.CheckBox_Xenia_DiscordRPC.TabIndex = 66;
            this.CheckBox_Xenia_DiscordRPC.Text = "Discord Rich Presence";
            this.CheckBox_Xenia_DiscordRPC.UseVisualStyleBackColor = false;
            // 
            // CheckBox_Xenia_Fullscreen
            // 
            this.CheckBox_Xenia_Fullscreen.AutoSize = true;
            this.CheckBox_Xenia_Fullscreen.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox_Xenia_Fullscreen.Location = new System.Drawing.Point(14, 365);
            this.CheckBox_Xenia_Fullscreen.Name = "CheckBox_Xenia_Fullscreen";
            this.CheckBox_Xenia_Fullscreen.Size = new System.Drawing.Size(134, 19);
            this.CheckBox_Xenia_Fullscreen.TabIndex = 65;
            this.CheckBox_Xenia_Fullscreen.Text = "Launch in Fullscreen";
            this.CheckBox_Xenia_Fullscreen.UseVisualStyleBackColor = false;
            // 
            // CheckBox_Xenia_Gamma
            // 
            this.CheckBox_Xenia_Gamma.AutoSize = true;
            this.CheckBox_Xenia_Gamma.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox_Xenia_Gamma.Location = new System.Drawing.Point(14, 340);
            this.CheckBox_Xenia_Gamma.Name = "CheckBox_Xenia_Gamma";
            this.CheckBox_Xenia_Gamma.Size = new System.Drawing.Size(106, 19);
            this.CheckBox_Xenia_Gamma.TabIndex = 64;
            this.CheckBox_Xenia_Gamma.Text = "Enable Gamma";
            this.CheckBox_Xenia_Gamma.UseVisualStyleBackColor = false;
            // 
            // CheckBox_Xenia_VerticalSync
            // 
            this.CheckBox_Xenia_VerticalSync.AutoSize = true;
            this.CheckBox_Xenia_VerticalSync.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox_Xenia_VerticalSync.Location = new System.Drawing.Point(14, 315);
            this.CheckBox_Xenia_VerticalSync.Name = "CheckBox_Xenia_VerticalSync";
            this.CheckBox_Xenia_VerticalSync.Size = new System.Drawing.Size(63, 19);
            this.CheckBox_Xenia_VerticalSync.TabIndex = 63;
            this.CheckBox_Xenia_VerticalSync.Text = "V-Sync";
            this.CheckBox_Xenia_VerticalSync.UseVisualStyleBackColor = false;
            // 
            // CheckBox_Xenia_2xResolution
            // 
            this.CheckBox_Xenia_2xResolution.AutoSize = true;
            this.CheckBox_Xenia_2xResolution.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox_Xenia_2xResolution.Location = new System.Drawing.Point(14, 290);
            this.CheckBox_Xenia_2xResolution.Name = "CheckBox_Xenia_2xResolution";
            this.CheckBox_Xenia_2xResolution.Size = new System.Drawing.Size(97, 19);
            this.CheckBox_Xenia_2xResolution.TabIndex = 62;
            this.CheckBox_Xenia_2xResolution.Text = "2x Resolution";
            this.CheckBox_Xenia_2xResolution.UseVisualStyleBackColor = false;
            // 
            // CheckBox_Xenia_ForceRTV
            // 
            this.CheckBox_Xenia_ForceRTV.AutoSize = true;
            this.CheckBox_Xenia_ForceRTV.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox_Xenia_ForceRTV.Location = new System.Drawing.Point(14, 265);
            this.CheckBox_Xenia_ForceRTV.Name = "CheckBox_Xenia_ForceRTV";
            this.CheckBox_Xenia_ForceRTV.Size = new System.Drawing.Size(273, 19);
            this.CheckBox_Xenia_ForceRTV.TabIndex = 61;
            this.CheckBox_Xenia_ForceRTV.Text = "Force Render Target Views (not recommended)";
            this.CheckBox_Xenia_ForceRTV.UseVisualStyleBackColor = false;
            // 
            // Label_GraphicsAPI
            // 
            this.Label_GraphicsAPI.AutoSize = true;
            this.Label_GraphicsAPI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Label_GraphicsAPI.Location = new System.Drawing.Point(11, 203);
            this.Label_GraphicsAPI.Name = "Label_GraphicsAPI";
            this.Label_GraphicsAPI.Size = new System.Drawing.Size(81, 17);
            this.Label_GraphicsAPI.TabIndex = 60;
            this.Label_GraphicsAPI.Text = "Graphics API";
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
            "Vulkan (not recommended)"});
            this.ComboBox_API.Location = new System.Drawing.Point(14, 225);
            this.ComboBox_API.Name = "ComboBox_API";
            this.ComboBox_API.Size = new System.Drawing.Size(560, 23);
            this.ComboBox_API.TabIndex = 59;
            // 
            // Label_Subtitle_Emulator_Options
            // 
            this.Label_Subtitle_Emulator_Options.AutoSize = true;
            this.Label_Subtitle_Emulator_Options.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.Label_Subtitle_Emulator_Options.Location = new System.Drawing.Point(9, 166);
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
            this.Tab_Section_Patches.Controls.Add(this.TabControl_Patches);
            this.Tab_Section_Patches.Location = new System.Drawing.Point(4, 20);
            this.Tab_Section_Patches.Name = "Tab_Section_Patches";
            this.Tab_Section_Patches.Size = new System.Drawing.Size(591, 921);
            this.Tab_Section_Patches.TabIndex = 2;
            this.Tab_Section_Patches.Text = "Patches";
            this.Tab_Section_Patches.Visible = false;
            // 
            // TabControl_Patches
            // 
            this.TabControl_Patches.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TabControl_Patches.AllowDragging = false;
            this.TabControl_Patches.AllowDrop = true;
            this.TabControl_Patches.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl_Patches.BackTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.TabControl_Patches.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.TabControl_Patches.ClosingButtonColor = System.Drawing.Color.WhiteSmoke;
            this.TabControl_Patches.ClosingMessage = null;
            this.TabControl_Patches.Controls.Add(this.Tab_Patches_Simple);
            this.TabControl_Patches.Controls.Add(this.Tab_Patches_Advanced);
            this.TabControl_Patches.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.TabControl_Patches.HorizontalLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TabControl_Patches.ItemSize = new System.Drawing.Size(240, 16);
            this.TabControl_Patches.Location = new System.Drawing.Point(-1, 0);
            this.TabControl_Patches.Name = "TabControl_Patches";
            this.TabControl_Patches.NoTabDisplay = false;
            this.TabControl_Patches.SelectedIndex = 0;
            this.TabControl_Patches.SelectedTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TabControl_Patches.ShowClosingButton = false;
            this.TabControl_Patches.ShowClosingMessage = false;
            this.TabControl_Patches.Size = new System.Drawing.Size(593, 956);
            this.TabControl_Patches.TabIndex = 0;
            this.TabControl_Patches.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // Tab_Patches_Simple
            // 
            this.Tab_Patches_Simple.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Tab_Patches_Simple.Controls.Add(this.Button_Patches_DeselectAll);
            this.Tab_Patches_Simple.Controls.Add(this.Panel_PatchBackdrop);
            this.Tab_Patches_Simple.Controls.Add(this.Button_Patches_SelectAll);
            this.Tab_Patches_Simple.Location = new System.Drawing.Point(4, 20);
            this.Tab_Patches_Simple.Name = "Tab_Patches_Simple";
            this.Tab_Patches_Simple.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Patches_Simple.Size = new System.Drawing.Size(585, 932);
            this.Tab_Patches_Simple.TabIndex = 0;
            this.Tab_Patches_Simple.Text = "Simple";
            // 
            // Button_Patches_DeselectAll
            // 
            this.Button_Patches_DeselectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Patches_DeselectAll.BackColor = System.Drawing.Color.Tomato;
            this.Button_Patches_DeselectAll.FlatAppearance.BorderSize = 0;
            this.Button_Patches_DeselectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Patches_DeselectAll.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Button_Patches_DeselectAll.Location = new System.Drawing.Point(296, 868);
            this.Button_Patches_DeselectAll.Name = "Button_Patches_DeselectAll";
            this.Button_Patches_DeselectAll.Size = new System.Drawing.Size(289, 23);
            this.Button_Patches_DeselectAll.TabIndex = 48;
            this.Button_Patches_DeselectAll.Text = "Deselect All";
            this.Button_Patches_DeselectAll.UseVisualStyleBackColor = false;
            // 
            // Panel_PatchBackdrop
            // 
            this.Panel_PatchBackdrop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_PatchBackdrop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Panel_PatchBackdrop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel_PatchBackdrop.Controls.Add(this.ListView_PatchesList);
            this.Panel_PatchBackdrop.Location = new System.Drawing.Point(0, 6);
            this.Panel_PatchBackdrop.Name = "Panel_PatchBackdrop";
            this.Panel_PatchBackdrop.Size = new System.Drawing.Size(585, 854);
            this.Panel_PatchBackdrop.TabIndex = 45;
            // 
            // ListView_PatchesList
            // 
            this.ListView_PatchesList.Activation = System.Windows.Forms.ItemActivation.OneClick;
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
            this.ListView_PatchesList.Size = new System.Drawing.Size(583, 869);
            this.ListView_PatchesList.TabIndex = 1;
            this.ListView_PatchesList.UseCompatibleStateImageBehavior = false;
            this.ListView_PatchesList.View = System.Windows.Forms.View.Details;
            this.ListView_PatchesList.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.ListView_DrawColumnHeader);
            this.ListView_PatchesList.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.ListView_DrawItem);
            // 
            // Column_PatchesList_Title
            // 
            this.Column_PatchesList_Title.Text = "Title";
            this.Column_PatchesList_Title.Width = 159;
            // 
            // Column_PatchesList_Author
            // 
            this.Column_PatchesList_Author.Text = "Author";
            this.Column_PatchesList_Author.Width = 90;
            // 
            // Column_PatchesList_System
            // 
            this.Column_PatchesList_System.Text = "System";
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
            // Button_Patches_SelectAll
            // 
            this.Button_Patches_SelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Button_Patches_SelectAll.BackColor = System.Drawing.Color.SkyBlue;
            this.Button_Patches_SelectAll.FlatAppearance.BorderSize = 0;
            this.Button_Patches_SelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Patches_SelectAll.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Button_Patches_SelectAll.Location = new System.Drawing.Point(0, 868);
            this.Button_Patches_SelectAll.Name = "Button_Patches_SelectAll";
            this.Button_Patches_SelectAll.Size = new System.Drawing.Size(289, 23);
            this.Button_Patches_SelectAll.TabIndex = 47;
            this.Button_Patches_SelectAll.Text = "Select All";
            this.Button_Patches_SelectAll.UseVisualStyleBackColor = false;
            // 
            // Tab_Patches_Advanced
            // 
            this.Tab_Patches_Advanced.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Tab_Patches_Advanced.Location = new System.Drawing.Point(4, 20);
            this.Tab_Patches_Advanced.Name = "Tab_Patches_Advanced";
            this.Tab_Patches_Advanced.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Patches_Advanced.Size = new System.Drawing.Size(585, 932);
            this.Tab_Patches_Advanced.TabIndex = 1;
            this.Tab_Patches_Advanced.Text = "Advanced";
            // 
            // Tab_Section_Settings
            // 
            this.Tab_Section_Settings.AutoScroll = true;
            this.Tab_Section_Settings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
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
            this.Tab_Section_Settings.Controls.Add(this.Label_Description_ModsDirectory);
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
            this.Tab_Section_Settings.Location = new System.Drawing.Point(4, 20);
            this.Tab_Section_Settings.Name = "Tab_Section_Settings";
            this.Tab_Section_Settings.Size = new System.Drawing.Size(591, 921);
            this.Tab_Section_Settings.TabIndex = 3;
            this.Tab_Section_Settings.Text = "Settings";
            // 
            // Label_Description_Reset
            // 
            this.Label_Description_Reset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Description_Reset.AutoSize = true;
            this.Label_Description_Reset.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Description_Reset.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Label_Description_Reset.Location = new System.Drawing.Point(224, 298);
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
            this.LinkLabel_Reset.Location = new System.Drawing.Point(11, 298);
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
            this.Label_Description_DebugMode.Location = new System.Drawing.Point(441, 887);
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
            this.Label_Description_HighContrastText.Location = new System.Drawing.Point(324, 862);
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
            this.Label_Description_SaveFileRedirect.Location = new System.Drawing.Point(343, 273);
            this.Label_Description_SaveFileRedirect.Name = "Label_Description_SaveFileRedirect";
            this.Label_Description_SaveFileRedirect.Size = new System.Drawing.Size(233, 15);
            this.Label_Description_SaveFileRedirect.TabIndex = 154;
            this.Label_Description_SaveFileRedirect.Text = "Used for mods that have custom save data.";
            // 
            // CheckBox_SaveFileRedirection
            // 
            this.CheckBox_SaveFileRedirection.AutoSize = true;
            this.CheckBox_SaveFileRedirection.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox_SaveFileRedirection.Location = new System.Drawing.Point(14, 272);
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
            this.CheckBox_DebugMode.Location = new System.Drawing.Point(14, 886);
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
            this.WindowsColourPicker_AccentColour.Location = new System.Drawing.Point(11, 480);
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
            this.Label_Title_Appearance.Location = new System.Drawing.Point(6, 326);
            this.Label_Title_Appearance.Name = "Label_Title_Appearance";
            this.Label_Title_Appearance.Size = new System.Drawing.Size(189, 45);
            this.Label_Title_Appearance.TabIndex = 10;
            this.Label_Title_Appearance.Text = "Appearance";
            // 
            // CheckBox_HighContrastText
            // 
            this.CheckBox_HighContrastText.AutoSize = true;
            this.CheckBox_HighContrastText.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox_HighContrastText.Location = new System.Drawing.Point(14, 861);
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
            this.Label_Subtitle_AccentColour.Location = new System.Drawing.Point(9, 381);
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
            // Label_Description_ModsDirectory
            // 
            this.Label_Description_ModsDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Description_ModsDirectory.AutoSize = true;
            this.Label_Description_ModsDirectory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Description_ModsDirectory.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Label_Description_ModsDirectory.Location = new System.Drawing.Point(156, 98);
            this.Label_Description_ModsDirectory.Name = "Label_Description_ModsDirectory";
            this.Label_Description_ModsDirectory.Size = new System.Drawing.Size(362, 15);
            this.Label_Description_ModsDirectory.TabIndex = 37;
            this.Label_Description_ModsDirectory.Text = "Where the mods are located (ensure it\'s outside the game directory).";
            // 
            // Label_WindowsColours
            // 
            this.Label_WindowsColours.AutoSize = true;
            this.Label_WindowsColours.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Label_WindowsColours.Location = new System.Drawing.Point(11, 455);
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
            this.Label_Subtitle_Appearance_Options.Location = new System.Drawing.Point(9, 824);
            this.Label_Subtitle_Appearance_Options.Name = "Label_Subtitle_Appearance_Options";
            this.Label_Subtitle_Appearance_Options.Size = new System.Drawing.Size(76, 25);
            this.Label_Subtitle_Appearance_Options.TabIndex = 143;
            this.Label_Subtitle_Appearance_Options.Text = "Options";
            // 
            // CheckBox_AutoColour
            // 
            this.CheckBox_AutoColour.AutoSize = true;
            this.CheckBox_AutoColour.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox_AutoColour.Location = new System.Drawing.Point(14, 419);
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
            this.Button_ColourPicker_Preview.Location = new System.Drawing.Point(357, 772);
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
            this.Panel_Settings_UICleanSpace.Location = new System.Drawing.Point(14, 904);
            this.Panel_Settings_UICleanSpace.Name = "Panel_Settings_UICleanSpace";
            this.Panel_Settings_UICleanSpace.Size = new System.Drawing.Size(214, 17);
            this.Panel_Settings_UICleanSpace.TabIndex = 145;
            // 
            // Button_Open_GameDirectory
            // 
            this.Button_Open_GameDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Open_GameDirectory.FlatAppearance.BorderSize = 0;
            this.Button_Open_GameDirectory.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Button_Open_GameDirectory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Button_Open_GameDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Open_GameDirectory.Image = global::Unify.Properties.Resources.Open_grey_16x;
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
            this.Button_Open_ModsDirectory.Image = global::Unify.Properties.Resources.Open_grey_16x;
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
            this.Button_ColourPicker_Default.Location = new System.Drawing.Point(393, 774);
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
            this.Section_Appearance_ColourPicker.Location = new System.Drawing.Point(14, 767);
            this.Section_Appearance_ColourPicker.Name = "Section_Appearance_ColourPicker";
            this.Section_Appearance_ColourPicker.SectionImage = ((System.Drawing.Bitmap)(resources.GetObject("Section_Appearance_ColourPicker.SectionImage")));
            this.Section_Appearance_ColourPicker.SectionText = "Custom colour";
            this.Section_Appearance_ColourPicker.SelectedSection = false;
            this.Section_Appearance_ColourPicker.Size = new System.Drawing.Size(373, 35);
            this.Section_Appearance_ColourPicker.TabIndex = 138;
            this.Section_Appearance_ColourPicker.Click += new System.EventHandler(this.Section_Appearance_ColourPicker_Click);
            // 
            // Tab_Section_Debug
            // 
            this.Tab_Section_Debug.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Tab_Section_Debug.Controls.Add(this.Panel_DebugControls);
            this.Tab_Section_Debug.Controls.Add(this.ListBox_Debug);
            this.Tab_Section_Debug.Location = new System.Drawing.Point(4, 20);
            this.Tab_Section_Debug.Name = "Tab_Section_Debug";
            this.Tab_Section_Debug.Size = new System.Drawing.Size(591, 921);
            this.Tab_Section_Debug.TabIndex = 5;
            this.Tab_Section_Debug.Text = "Debug";
            // 
            // Panel_DebugControls
            // 
            this.Panel_DebugControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_DebugControls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel_DebugControls.Controls.Add(this.SectionButton_ClearLog);
            this.Panel_DebugControls.Location = new System.Drawing.Point(-1, 869);
            this.Panel_DebugControls.Name = "Panel_DebugControls";
            this.Panel_DebugControls.Size = new System.Drawing.Size(596, 53);
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
            this.SectionButton_ClearLog.SectionImage = global::Unify.Properties.Resources.Refresh_grey_16x;
            this.SectionButton_ClearLog.SectionText = "Clear debug log";
            this.SectionButton_ClearLog.SelectedSection = false;
            this.SectionButton_ClearLog.Size = new System.Drawing.Size(584, 35);
            this.SectionButton_ClearLog.TabIndex = 24;
            this.SectionButton_ClearLog.Click += new System.EventHandler(this.SectionButton_ClearLog_Click);
            // 
            // ListBox_Debug
            // 
            this.ListBox_Debug.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListBox_Debug.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ListBox_Debug.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListBox_Debug.ForeColor = System.Drawing.SystemColors.Control;
            this.ListBox_Debug.FormattingEnabled = true;
            this.ListBox_Debug.ItemHeight = 15;
            this.ListBox_Debug.Location = new System.Drawing.Point(0, 4);
            this.ListBox_Debug.Name = "ListBox_Debug";
            this.ListBox_Debug.Size = new System.Drawing.Size(591, 870);
            this.ListBox_Debug.TabIndex = 0;
            // 
            // Tab_Section_Updates
            // 
            this.Tab_Section_Updates.AutoScroll = true;
            this.Tab_Section_Updates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Tab_Section_Updates.Controls.Add(this.Label_LastUpdateCheck);
            this.Tab_Section_Updates.Controls.Add(this.SectionButton_FetchLatestPatches);
            this.Tab_Section_Updates.Controls.Add(this.SplitContainer_ModUpdate);
            this.Tab_Section_Updates.Controls.Add(this.Label_Title_ModsAndPatches);
            this.Tab_Section_Updates.Controls.Add(this.Label_Subtitle_Changelogs);
            this.Tab_Section_Updates.Controls.Add(this.Label_UpdaterStatus);
            this.Tab_Section_Updates.Controls.Add(this.Panel_ChangelogsBackdrop);
            this.Tab_Section_Updates.Controls.Add(this.Label_Title_Software);
            this.Tab_Section_Updates.Controls.Add(this.CheckBox_CheckUpdatesOnLaunch);
            this.Tab_Section_Updates.Controls.Add(this.Panel_Updates_UICleanSpace);
            this.Tab_Section_Updates.Controls.Add(this.PictureBox_UpdaterIcon);
            this.Tab_Section_Updates.Controls.Add(this.ProgressBar_SoftwareUpdate);
            this.Tab_Section_Updates.Controls.Add(this.SectionButton_CheckForUpdates);
            this.Tab_Section_Updates.Location = new System.Drawing.Point(4, 20);
            this.Tab_Section_Updates.Name = "Tab_Section_Updates";
            this.Tab_Section_Updates.Size = new System.Drawing.Size(591, 921);
            this.Tab_Section_Updates.TabIndex = 6;
            this.Tab_Section_Updates.Text = "Updates";
            // 
            // Label_LastUpdateCheck
            // 
            this.Label_LastUpdateCheck.AutoSize = true;
            this.Label_LastUpdateCheck.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_LastUpdateCheck.Location = new System.Drawing.Point(72, 87);
            this.Label_LastUpdateCheck.Name = "Label_LastUpdateCheck";
            this.Label_LastUpdateCheck.Size = new System.Drawing.Size(216, 17);
            this.Label_LastUpdateCheck.TabIndex = 147;
            this.Label_LastUpdateCheck.Text = "Last checked: 21/01/2020, 08:59 PM";
            // 
            // SectionButton_FetchLatestPatches
            // 
            this.SectionButton_FetchLatestPatches.AccentColour = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SectionButton_FetchLatestPatches.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SectionButton_FetchLatestPatches.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(45)))));
            this.SectionButton_FetchLatestPatches.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SectionButton_FetchLatestPatches.Location = new System.Drawing.Point(14, 840);
            this.SectionButton_FetchLatestPatches.Name = "SectionButton_FetchLatestPatches";
            this.SectionButton_FetchLatestPatches.SectionImage = global::Unify.Properties.Resources.Update_4;
            this.SectionButton_FetchLatestPatches.SectionText = "Fetch latest community patches";
            this.SectionButton_FetchLatestPatches.SelectedSection = false;
            this.SectionButton_FetchLatestPatches.Size = new System.Drawing.Size(563, 35);
            this.SectionButton_FetchLatestPatches.TabIndex = 45;
            // 
            // SplitContainer_ModUpdate
            // 
            this.SplitContainer_ModUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SplitContainer_ModUpdate.Location = new System.Drawing.Point(14, 502);
            this.SplitContainer_ModUpdate.Name = "SplitContainer_ModUpdate";
            // 
            // SplitContainer_ModUpdate.Panel1
            // 
            this.SplitContainer_ModUpdate.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.SplitContainer_ModUpdate.Panel1.Controls.Add(this.Button_ModUpdate);
            this.SplitContainer_ModUpdate.Panel1.Controls.Add(this.Panel_ModUpdateBackdrop);
            this.SplitContainer_ModUpdate.Panel1MinSize = 201;
            // 
            // SplitContainer_ModUpdate.Panel2
            // 
            this.SplitContainer_ModUpdate.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.SplitContainer_ModUpdate.Panel2.Controls.Add(this.ProgressBar_ModUpdate);
            this.SplitContainer_ModUpdate.Panel2.Controls.Add(this.Panel_ModInfoBackdrop);
            this.SplitContainer_ModUpdate.Panel2MinSize = 300;
            this.SplitContainer_ModUpdate.Size = new System.Drawing.Size(563, 331);
            this.SplitContainer_ModUpdate.SplitterDistance = 201;
            this.SplitContainer_ModUpdate.TabIndex = 44;
            // 
            // Button_ModUpdate
            // 
            this.Button_ModUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_ModUpdate.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Button_ModUpdate.Enabled = false;
            this.Button_ModUpdate.FlatAppearance.BorderSize = 0;
            this.Button_ModUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_ModUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Button_ModUpdate.Location = new System.Drawing.Point(0, 308);
            this.Button_ModUpdate.Name = "Button_ModUpdate";
            this.Button_ModUpdate.Size = new System.Drawing.Size(199, 23);
            this.Button_ModUpdate.TabIndex = 93;
            this.Button_ModUpdate.Text = "Update Mod";
            this.Button_ModUpdate.UseVisualStyleBackColor = false;
            // 
            // Panel_ModUpdateBackdrop
            // 
            this.Panel_ModUpdateBackdrop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_ModUpdateBackdrop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Panel_ModUpdateBackdrop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel_ModUpdateBackdrop.Controls.Add(this.ListView_ModUpdate);
            this.Panel_ModUpdateBackdrop.Location = new System.Drawing.Point(0, 0);
            this.Panel_ModUpdateBackdrop.Name = "Panel_ModUpdateBackdrop";
            this.Panel_ModUpdateBackdrop.Size = new System.Drawing.Size(199, 301);
            this.Panel_ModUpdateBackdrop.TabIndex = 1;
            // 
            // ListView_ModUpdate
            // 
            this.ListView_ModUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ListView_ModUpdate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListView_ModUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListView_ModUpdate.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ListView_ModUpdate.ForeColor = System.Drawing.SystemColors.Control;
            this.ListView_ModUpdate.FormattingEnabled = true;
            this.ListView_ModUpdate.ItemHeight = 21;
            this.ListView_ModUpdate.Location = new System.Drawing.Point(0, 0);
            this.ListView_ModUpdate.Name = "ListView_ModUpdate";
            this.ListView_ModUpdate.Size = new System.Drawing.Size(197, 299);
            this.ListView_ModUpdate.TabIndex = 0;
            // 
            // ProgressBar_ModUpdate
            // 
            this.ProgressBar_ModUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBar_ModUpdate.Enabled = false;
            this.ProgressBar_ModUpdate.Location = new System.Drawing.Point(2, 308);
            this.ProgressBar_ModUpdate.Name = "ProgressBar_ModUpdate";
            this.ProgressBar_ModUpdate.Size = new System.Drawing.Size(356, 23);
            this.ProgressBar_ModUpdate.TabIndex = 94;
            // 
            // Panel_ModInfoBackdrop
            // 
            this.Panel_ModInfoBackdrop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_ModInfoBackdrop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Panel_ModInfoBackdrop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel_ModInfoBackdrop.Controls.Add(this.RichTextBox_ModInformation);
            this.Panel_ModInfoBackdrop.Location = new System.Drawing.Point(2, 0);
            this.Panel_ModInfoBackdrop.Name = "Panel_ModInfoBackdrop";
            this.Panel_ModInfoBackdrop.Size = new System.Drawing.Size(356, 301);
            this.Panel_ModInfoBackdrop.TabIndex = 21;
            // 
            // RichTextBox_ModInformation
            // 
            this.RichTextBox_ModInformation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.RichTextBox_ModInformation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RichTextBox_ModInformation.Cursor = System.Windows.Forms.Cursors.Default;
            this.RichTextBox_ModInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RichTextBox_ModInformation.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichTextBox_ModInformation.ForeColor = System.Drawing.SystemColors.Control;
            this.RichTextBox_ModInformation.Location = new System.Drawing.Point(0, 0);
            this.RichTextBox_ModInformation.Name = "RichTextBox_ModInformation";
            this.RichTextBox_ModInformation.ReadOnly = true;
            this.RichTextBox_ModInformation.Size = new System.Drawing.Size(354, 299);
            this.RichTextBox_ModInformation.TabIndex = 20;
            this.RichTextBox_ModInformation.Text = "";
            // 
            // Label_Title_ModsAndPatches
            // 
            this.Label_Title_ModsAndPatches.AutoSize = true;
            this.Label_Title_ModsAndPatches.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.Label_Title_ModsAndPatches.Location = new System.Drawing.Point(6, 447);
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
            this.Panel_ChangelogsBackdrop.Size = new System.Drawing.Size(563, 229);
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
            this.RichTextBox_Changelogs.Size = new System.Drawing.Size(561, 227);
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
            this.CheckBox_CheckUpdatesOnLaunch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            // Panel_Updates_UICleanSpace
            // 
            this.Panel_Updates_UICleanSpace.Location = new System.Drawing.Point(14, 874);
            this.Panel_Updates_UICleanSpace.Name = "Panel_Updates_UICleanSpace";
            this.Panel_Updates_UICleanSpace.Size = new System.Drawing.Size(214, 17);
            this.Panel_Updates_UICleanSpace.TabIndex = 146;
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
            // SectionButton_CheckForUpdates
            // 
            this.SectionButton_CheckForUpdates.AccentColour = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SectionButton_CheckForUpdates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SectionButton_CheckForUpdates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(45)))));
            this.SectionButton_CheckForUpdates.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SectionButton_CheckForUpdates.Location = new System.Drawing.Point(14, 114);
            this.SectionButton_CheckForUpdates.Name = "SectionButton_CheckForUpdates";
            this.SectionButton_CheckForUpdates.SectionImage = global::Unify.Properties.Resources.Update_4;
            this.SectionButton_CheckForUpdates.SectionText = "Check for software updates";
            this.SectionButton_CheckForUpdates.SelectedSection = false;
            this.SectionButton_CheckForUpdates.Size = new System.Drawing.Size(233, 35);
            this.SectionButton_CheckForUpdates.TabIndex = 36;
            this.SectionButton_CheckForUpdates.Click += new System.EventHandler(this.SectionButton_CheckForUpdates_Click);
            // 
            // Tab_Section_About
            // 
            this.Tab_Section_About.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Tab_Section_About.Controls.Add(this.Label_Version);
            this.Tab_Section_About.Location = new System.Drawing.Point(4, 20);
            this.Tab_Section_About.Name = "Tab_Section_About";
            this.Tab_Section_About.Size = new System.Drawing.Size(591, 921);
            this.Tab_Section_About.TabIndex = 4;
            this.Tab_Section_About.Text = "About";
            this.Tab_Section_About.Visible = false;
            // 
            // Label_Version
            // 
            this.Label_Version.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Version.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Version.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Label_Version.Location = new System.Drawing.Point(2, 932);
            this.Label_Version.Name = "Label_Version";
            this.Label_Version.Size = new System.Drawing.Size(588, 25);
            this.Label_Version.TabIndex = 0;
            this.Label_Version.Text = "Rush 3.0";
            this.Label_Version.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Rush_Section_Settings
            // 
            this.Rush_Section_Settings.AccentColour = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Rush_Section_Settings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(45)))));
            this.Rush_Section_Settings.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rush_Section_Settings.Location = new System.Drawing.Point(0, 171);
            this.Rush_Section_Settings.Name = "Rush_Section_Settings";
            this.Rush_Section_Settings.SectionImage = global::Unify.Properties.Resources.Monaco_Settings_16x;
            this.Rush_Section_Settings.SectionText = "Settings";
            this.Rush_Section_Settings.SelectedSection = false;
            this.Rush_Section_Settings.Size = new System.Drawing.Size(250, 35);
            this.Rush_Section_Settings.TabIndex = 23;
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
            this.Rush_Section_Patches.Click += new System.EventHandler(this.Rush_Section_Click);
            // 
            // Rush_Section_About
            // 
            this.Rush_Section_About.AccentColour = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Rush_Section_About.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Rush_Section_About.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(45)))));
            this.Rush_Section_About.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rush_Section_About.Location = new System.Drawing.Point(0, 908);
            this.Rush_Section_About.Name = "Rush_Section_About";
            this.Rush_Section_About.SectionImage = global::Unify.Properties.Resources.InformationSymbol_16x;
            this.Rush_Section_About.SectionText = "About";
            this.Rush_Section_About.SelectedSection = false;
            this.Rush_Section_About.Size = new System.Drawing.Size(250, 35);
            this.Rush_Section_About.TabIndex = 20;
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
            this.Container_Rush.Size = new System.Drawing.Size(849, 944);
            this.Container_Rush.SplitterDistance = 250;
            this.Container_Rush.TabIndex = 17;
            this.Container_Rush.Title = "Mods";
            // 
            // RushInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Controls.Add(this.Rush_Section_Updates);
            this.Controls.Add(this.Label_Status);
            this.Controls.Add(this.StatusStrip_Main);
            this.Controls.Add(this.Rush_Section_Debug);
            this.Controls.Add(this.TabControl_Rush);
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
            this.Size = new System.Drawing.Size(849, 966);
            this.Load += new System.EventHandler(this.RushInterface_Load);
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
            this.TabControl_Patches.ResumeLayout(false);
            this.Tab_Patches_Simple.ResumeLayout(false);
            this.Panel_PatchBackdrop.ResumeLayout(false);
            this.Tab_Section_Settings.ResumeLayout(false);
            this.Tab_Section_Settings.PerformLayout();
            this.Tab_Section_Debug.ResumeLayout(false);
            this.Panel_DebugControls.ResumeLayout(false);
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
            this.Tab_Section_About.ResumeLayout(false);
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
        private System.Windows.Forms.Label Label_Description_ModsDirectory;
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
        private System.Windows.Forms.Button Button_Priority;
        private System.Windows.Forms.Button Button_DownerPriority;
        private System.Windows.Forms.Button Button_UpperPriority;
        private System.Windows.Forms.Button Button_Mods_DeselectAll;
        private System.Windows.Forms.Button Button_Mods_SelectAll;
        private SectionButton SectionButton_InstallMods;
        private SectionButton SectionButton_CreateNewMod;
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
        private System.Windows.Forms.Label Label_GraphicsAPI;
        private System.Windows.Forms.ComboBox ComboBox_API;
        private System.Windows.Forms.Label Label_Subtitle_Emulator_Options;
        private System.Windows.Forms.CheckBox CheckBox_Xenia_Gamma;
        private System.Windows.Forms.CheckBox CheckBox_Xenia_VerticalSync;
        private System.Windows.Forms.CheckBox CheckBox_Xenia_2xResolution;
        private System.Windows.Forms.CheckBox CheckBox_Xenia_ForceRTV;
        private System.Windows.Forms.Label Label_RPCS3Warning;
        private System.Windows.Forms.CheckBox CheckBox_Xenia_DiscordRPC;
        private System.Windows.Forms.CheckBox CheckBox_Xenia_Fullscreen;
        private UnifyTabControl TabControl_Patches;
        private System.Windows.Forms.TabPage Tab_Patches_Simple;
        private System.Windows.Forms.TabPage Tab_Patches_Advanced;
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
        private SectionButton SectionButton_CheckForUpdates;
        private System.Windows.Forms.Panel Panel_ChangelogsBackdrop;
        private System.Windows.Forms.Label Label_Subtitle_Changelogs;
        private SectionButton SectionButton_FetchLatestPatches;
        private System.Windows.Forms.SplitContainer SplitContainer_ModUpdate;
        private System.Windows.Forms.Button Button_ModUpdate;
        private System.Windows.Forms.Panel Panel_ModUpdateBackdrop;
        private System.Windows.Forms.ListBox ListView_ModUpdate;
        private System.Windows.Forms.ProgressBar ProgressBar_ModUpdate;
        private System.Windows.Forms.Panel Panel_ModInfoBackdrop;
        private System.Windows.Forms.RichTextBox RichTextBox_ModInformation;
        private System.Windows.Forms.Label Label_Title_ModsAndPatches;
        private System.Windows.Forms.Panel Panel_Updates_UICleanSpace;
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
        private System.Windows.Forms.Label Label_LastUpdateCheck;
        private System.Windows.Forms.TabPage Tab_Section_ModCreator;
        private System.Windows.Forms.ProgressBar ProgressBar_SoftwareUpdate;
    }
}