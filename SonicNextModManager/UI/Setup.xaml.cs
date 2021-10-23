using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using HandyControl.Controls;

namespace SonicNextModManager
{
    /// <summary>
    /// Interaction logic for Setup.xaml
    /// </summary>
    public partial class Setup : ImmersiveWindow
    {
        public Setup()
        {
            InitializeComponent();
        }

        private void Language_SelectionChanged(object sender, SelectionChangedEventArgs e)
            => App.UpdateCultureResources();

        private void Click_ToPreviousMajorStep(object sender, RoutedEventArgs e)
        {
            Steps.StepIndex -= 1;
            MajorStepPages.SelectedIndex -= 1;
        }

        private void Click_ToNextMajorStep(object sender, RoutedEventArgs e)
        {
            Steps.StepIndex += 1;
            MajorStepPages.SelectedIndex += 1;
        }

        private void Click_ReturnToEmulatorPrompt(object sender, RoutedEventArgs e)
            => EmulatorStepPages.SelectedItem = Emulator_Prompt;

        private void Click_ToRelevantEmulatorWarning(object sender, RoutedEventArgs e)
        {
            switch (Path.GetExtension(Game_Path.Text))
            {
                case ".xex":
                    EmulatorStepPages.SelectedItem = Emulator_Xenia;
                    break;

                case ".bin":
                    EmulatorStepPages.SelectedItem = Emulator_RPCS3;
                    break;
            }
        }

        private void Click_ToEmulatorPathSetup(object sender, RoutedEventArgs e)
            => EmulatorStepPages.SelectedItem = Emulator_Setup;

        private void Game_Path_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Set Continue button enabled state.
            Game_Continue.IsEnabled = Game_Path.Text.Length != 0;

            // Set global game executable path.
            Properties.Settings.Default.Path_GameExecutable = Game_Path.Text;
        }

        private void Game_Browse_Click(object sender, RoutedEventArgs e)
        {
            string executable = FileQueries.QueryGameExecutable();

            if (!string.IsNullOrEmpty(executable))
                Game_Path.Text = executable;
        }

        private void Emulator_Path_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Set Continue button enabled state.
            Emulator_Continue.IsEnabled = Emulator_Path.Text.Length != 0;

            // Set global emulator executable path.
            Properties.Settings.Default.Path_EmulatorExecutable = Emulator_Path.Text;
        }

        private void Emulator_Browse_Click(object sender, RoutedEventArgs e)
        {
            string executable = FileQueries.QueryEmulatorExecutable();

            if (!string.IsNullOrEmpty(executable))
                Emulator_Path.Text = executable;
        }

        private void Click_FinishSetup(object sender, RoutedEventArgs e)
        {
            // Set completion flag.
            Properties.Settings.Default.Setup_Complete = true;

            // Save current settings.
            Properties.Settings.Default.Save();

            // Load mod manager window.
            new Manager().Show();

            // Close current window.
            Close();
        }

        /// <summary>
        /// Displays a full preview upon double-clicking an image in a carousel.
        /// </summary>
        private void Image_Carousel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
                new ImageBrowser(new Uri(((BitmapFrame)((Image)sender).Source).Decoder.ToString())).Show();
        }
    }
}
