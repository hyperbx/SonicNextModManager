using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;

namespace SonicNextModManager
{
    public class CheckedListBoxItem
    {
        public string? Text { get; set; }

        public string? Tag { get; set; }

        public bool Checked { get; set; }
    }

    /// <summary>
    /// Interaction logic for CheckedListBox.xaml
    /// </summary>
    public partial class CheckedListBox : UserControl
    {
        public static readonly DependencyProperty MultiColumnProperty = DependencyProperty.Register
        (
            nameof(MultiColumn),
            typeof(bool),
            typeof(CheckedListBox),
            new PropertyMetadata(false)
        );

        public bool MultiColumn
        {
            get => (bool)GetValue(MultiColumnProperty);
            set
            {
                SetValue(MultiColumnProperty, value);

                // Set ScrollViewer properties for scrolling orientation.
                ScrollViewer.Orientation = value ? Orientation.Horizontal : Orientation.Vertical;
                ScrollViewer.HorizontalScrollBarVisibility = value ? ScrollBarVisibility.Visible : ScrollBarVisibility.Disabled;
                ScrollViewer.VerticalScrollBarVisibility = value ? ScrollBarVisibility.Disabled : ScrollBarVisibility.Visible;
            }
        }

        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register
        (
            nameof(ItemsSource),
            typeof(IEnumerable),
            typeof(CheckedListBox),
            new PropertyMetadata(null, (s, e) =>
            {
                if (s is CheckedListBox uc)
                {
                    if (e.OldValue is INotifyCollectionChanged oldValueINotifyCollectionChanged)
                        oldValueINotifyCollectionChanged.CollectionChanged -= uc.ItemsSource_CollectionChanged;

                    if (e.NewValue is INotifyCollectionChanged newValueINotifyCollectionChanged)
                        newValueINotifyCollectionChanged.CollectionChanged += uc.ItemsSource_CollectionChanged;
                }
            }
        ));

        public IEnumerable ItemsSource
        {
            get => (IEnumerable)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        private void ItemsSource_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // TODO
        }

        public CheckedListBox()
        {
            InitializeComponent();

            DataContext = this;
        }
    }
}
