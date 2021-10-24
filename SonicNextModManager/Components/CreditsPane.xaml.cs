using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SonicNextModManager
{
    /// <summary>
    /// Interaction logic for CreditsPane.xaml
    /// </summary>
    public partial class CreditsPane : UserControl
    {
        public static readonly DependencyProperty CreditsProperty = DependencyProperty.Register
        (
            nameof(Credits),
            typeof(Credits),
            typeof(CreditsPane),
            new PropertyMetadata()
        );

        public Credits Credits
        {
            get => (Credits)GetValue(CreditsProperty);
            set => SetValue(CreditsProperty, value);
        }

        public CreditsPane(Credits? credits)
        {
            InitializeComponent();

            if (credits != null)
            {
                Credits = credits;

                // Localise description text.
                Description.Text = SonicNextModManager.Language.Localise(Credits.Description);
            }
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string url = ((Credits.Contributor)((ListViewItem)sender).Content).URL;

            // Direct to user webpage (if available) when double-clicked.
            if (!string.IsNullOrEmpty(url))
                ProcessExtensions.StartWithDefaultProgram(url);
        }

        private void GitHub_Click(object sender, RoutedEventArgs e)
        {
            // Direct to GitHub repository when clicked.
            if (!string.IsNullOrEmpty(Credits.GitHub))
                ProcessExtensions.StartWithDefaultProgram(Credits.GitHub);
        }
    }
}
