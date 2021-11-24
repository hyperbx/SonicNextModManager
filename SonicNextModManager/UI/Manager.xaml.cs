using SonicNextModManager.UI.ViewModel;
using System.Windows.Shapes;

namespace SonicNextModManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Manager : ImmersiveWindow
    {
        ManagerViewModel ViewModel { get; set; } = new();

        /// <summary>
        /// Property storage for <see cref="InfoDisplayMargin"/>.
        /// </summary>
        internal static readonly DependencyProperty InfoDisplayMarginProperty = DependencyProperty.Register
        (
            nameof(InfoDisplayMargin),
            typeof(Thickness),
            typeof(Manager),
            new PropertyMetadata(new Thickness(-40, 15, -930, 0))
        );

        /// <summary>
        /// The margin used for the info display - the right margin is used as the width.
        /// </summary>
        internal Thickness InfoDisplayMargin
        {
            get => (Thickness)GetValue(InfoDisplayMarginProperty);
            set => SetValue(InfoDisplayMarginProperty, value);
        }

        public Manager()
        {
            InitializeComponent();
            InvokeUserExperienceAmendments();

            // Set data context to new view model.
            DataContext = ViewModel;
        }

        /// <summary>
        /// Sets the new width of the info display based on the current window size.
        /// </summary>
        private void Manager_SizeChanged(object sender, SizeChangedEventArgs e)
            => InfoDisplayMargin = new Thickness(-40, 15, (e.NewSize.Width - 30) * -1, 0);

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

        /// <summary>
        /// Various key down events for list views.
        /// </summary>
        /// <param name="sender">List view calling this function.</param>
        /// <param name="e">Key event handler.</param>
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

                    // Save updated content list.
                    ViewModel.Database.Save();

                    break;
                }
            }
        }

        private void ModsList_KeyDown(object sender, KeyEventArgs e)
            => InvokeListViewKeyDown(ModsList, e);

        private void PatchesList_KeyDown(object sender, KeyEventArgs e)
            => InvokeListViewKeyDown(PatchesList, e);

        /// <summary>
        /// Saves the content list upon check box click.
        /// </summary>
        private void ListViewItem_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is Rectangle)
                ViewModel.Database.Save();
        }

        /// <summary>
        /// Opens or closes the info display for the selected content.
        /// </summary>
        private void ModsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Metadata selectedItem = (Metadata)ModsList.SelectedItem;

            // Do not handle for check boxes or null items.
            if (e.OriginalSource is Rectangle || selectedItem == null)
                return;

            // Close all info displays.
            foreach (Metadata item in ModsList.Items)
            {
                // Don't close the current info display - we invert it later.
                if (item == selectedItem && selectedItem.InfoDisplay)
                    continue;

                item.InfoDisplay = false;
            }

            // Invert info display visibility (description required).
            if (!string.IsNullOrEmpty(selectedItem.Description))
                selectedItem.InfoDisplay ^= true;
        }

        /// <summary>
        /// TODO: https://github.com/Big-Endian-32/SonicNextModManager/projects/3#card-72800882
        /// </summary>
        private void Install_Click(object sender, RoutedEventArgs e)
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
                    ViewModel.Database.CurrentContentInQueue = metadata;
                    metadata.State = InstallState.Installing;

                    System.Timers.Timer t = new();
                    t.Interval = interval;
                    interval += 1000;

                    t.Elapsed += (s, te) => metadata.State = InstallState.Installed;

                    t.Start();
                }
            }
        }

        /// <summary>
        /// TODO: https://github.com/Big-Endian-32/SonicNextModManager/projects/3#card-73379659
        /// </summary>
        private void Uninstall_Click(object sender, RoutedEventArgs e)
            => throw new NotImplementedException();

        /// <summary>
        /// Performs a hard refresh of the content database.
        /// </summary>
        private void Refresh_Click(object sender, RoutedEventArgs e)
            => ViewModel.InvokeDatabaseContentUpdate();

        /// <summary>
        /// Opens the Settings window.
        /// </summary>
        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            new Settings
            {
                // Set owner to centre window.
                Owner = this
            }
            .ShowDialog();
        }
    }
}
