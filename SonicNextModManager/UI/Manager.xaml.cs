using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using SonicNextModManager.UI.ViewModel;

namespace SonicNextModManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Manager : ImmersiveWindow
    {
        ManagerViewModel ViewModel { get; set; } = new();

        public Manager()
        {
            InitializeComponent();
            InvokeUserExperienceAmendments();

            // Set data context to new view model.
            DataContext = ViewModel;
        }

        /// <summary>
        /// Amend erroneous UI elements under certain conditions.
        /// </summary>
        private void InvokeUserExperienceAmendments()
        {
            /* Set visibility of the emulator launcher depending on if there's an emulator specified.
               There's no point in displaying this option if the user is installing for real hardware. */
            Emulator_Launcher.Visibility = string.IsNullOrEmpty(App.Settings.Path_EmulatorExecutable)
                                           ? Visibility.Collapsed
                                           : Visibility.Visible;
        }

        private void InvokeListViewKeyDown(ListView sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                // Set content enabled state upon space key down.
                case Key.Space:
                {
                    // Flip enabled state for each selected item.
                    foreach (Metadata item in sender.SelectedItems)
                        item.Enabled ^= true;

                    break;
                }
            }
        }

        private void ModsList_KeyDown(object sender, KeyEventArgs e)
            => InvokeListViewKeyDown(ModsList, e);

        private void PatchesList_KeyDown(object sender, KeyEventArgs e)
            => InvokeListViewKeyDown(PatchesList, e);

        private void Install_Click(object sender, RoutedEventArgs e)
        {
            // Save active content to the database.
            ViewModel.Database.Save();

            // TODO: localise this and use an XAML converter instead.
            Install.Content = "Installing...";
            Install.IsEnabled = false;
            Uninstall.Content = "Cancel";

            // TODO: replace this pseudo installer with real code.
            {
                int interval = 1000;

                foreach (var item in ViewModel.Database.Mods)
                    SetInstallState(item);

                foreach (var item in ViewModel.Database.Patches)
                    SetInstallState(item);

                void SetInstallState(Metadata metadata)
                {
                    if (metadata.Enabled)
                    {
                        metadata.State = InstallState.Installing;

                        System.Timers.Timer t = new();
                        t.Interval = interval;
                        interval += 1000;

                        t.Elapsed += (s, te) => metadata.State = InstallState.Installed;

                        t.Start();
                    }
                }
            }
        }

        private void Uninstall_Click(object sender, RoutedEventArgs e)
        {
            // TODO: localise this and use an XAML converter instead.
            Install.Content = "Install";
            Install.IsEnabled = true;
            Uninstall.Content = "Uninstall";

            throw new NotImplementedException();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
            => ViewModel.InvokeDatabaseContentUpdate();

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            new Settings
            {
                Owner = this // Set owner to centre window.
            }
            .ShowDialog();
        }
    }
}
