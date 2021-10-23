using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace SonicNextModManager
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : ImmersiveWindow
    {
        public Settings()
        {
            InitializeComponent();

            // Create credits list.
            foreach (var contributor in Contributor.GetCategorisedExpanders())
                Credits.Children.Add(contributor.Value);
        }

        private void OK_Click(object sender, RoutedEventArgs e)
            => Close();

        private void Language_SelectionChanged(object sender, SelectionChangedEventArgs e)
            => App.UpdateCultureResources();

        protected override void OnClosing(CancelEventArgs e)
        {
            // Save current settings.
            Properties.Settings.Default.Save();

            base.OnClosing(e);
        }
    }
}
