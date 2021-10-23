using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace SonicNextModManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Languages SupportedCultures { get; set; }

        public static Language CurrentCulture { get; set; }

        public static Dictionary<string, string> Directories { get; } = new()
        {
            { "Patches", Path.Combine(Environment.CurrentDirectory, "Patches") },
            { "Profiles", Path.Combine(Environment.CurrentDirectory, "Profiles") }
        };

        /// <summary>
        /// Creates the default directory tree.
        /// </summary>
        private static bool CreateDefaultDirectoryTree()
        {
            try
            {
                // Create default directory tree from the working directory.
                foreach (var directory in Directories)
                    Directory.CreateDirectory(directory.Value);

                string modsDirectory = SonicNextModManager.Properties.Settings.Default.Path_ModsDirectory;
                {
                    // Create default mods directory if the current one is null or doesn't exist.
                    if (string.IsNullOrEmpty(modsDirectory) || !Directory.Exists(modsDirectory))
                    {
                        Directory.CreateDirectory
                        (
                            SonicNextModManager.Properties.Settings.Default.Path_ModsDirectory = Path.Combine(Environment.CurrentDirectory, "Mods")
                        );
                    }
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Loads the requested culture resources from user settings.
        /// </summary>
        private static void LoadCultureResources()
        {
            // Find Languages resource from Languages.xaml.
            object? resource = Current.TryFindResource("Languages");

            // Initialise supported cultures list.
            if (resource is Languages langs)
                SupportedCultures = langs;

            // Load language setting as current language.
            CurrentCulture = Language.GetClosestCulture(SonicNextModManager.Properties.Settings.Default.General_Language);

            // Set current language.
            if (CurrentCulture != null)
                Language.Load(CurrentCulture.FileName);
        }

        /// <summary>
        /// Loads the updated culture and updates the user setting.
        /// </summary>
        public static void UpdateCultureResources()
            => Language.Load(SonicNextModManager.Properties.Settings.Default.General_Language = CurrentCulture.FileName);

        protected override void OnStartup(StartupEventArgs e)
        {
            // Set up language settings.
            LoadCultureResources();

            // Catch any weird errors if writing the default directories somehow fails.
            if (!CreateDefaultDirectoryTree())
            {
                MessageBox.Show(Language.Localise("Exception_DirectoryTreeFailed"), Language.Localise("Exception_IOError"));
                return;
            }

            // Start with Manager.xaml if the step-by-step guide has been completed already.
            if (SonicNextModManager.Properties.Settings.Default.Setup_Complete)
                StartupUri = new Uri("pack://application:,,,/SonicNextModManager;component/UI/Manager.xaml");

            base.OnStartup(e);
        }
    }
}
