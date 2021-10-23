using System.Windows;
using System.Windows.Controls;

namespace SonicNextModManager
{
    /// <summary>
    /// Interaction logic for IconControl.xaml
    /// </summary>
    public partial class IconFontControl : UserControl
    {
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register
        (
            nameof(Text),
            typeof(string),
            typeof(IconFontControl),
            new PropertyMetadata("block")
        );

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public IconFontControl()
        {
            InitializeComponent();
        }
    }
}
