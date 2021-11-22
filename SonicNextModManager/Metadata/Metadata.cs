using System.ComponentModel;

namespace SonicNextModManager
{
    public class Metadata : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public string? Title { get; set; }

        public string? Author { get; set; }

        public Platform Platform { get; set; }

        [JsonIgnore]
        public bool Enabled { get; set; }

        [JsonIgnore]
        public InstallState State { get; set; }

        [JsonIgnore]
        public string? Path { get; set; }
    }

    public enum InstallState
    {
        Idle,
        Installing,
        Installed
    }

    [ValueConversion(typeof(InstallState), typeof(Visibility))]
    public class InstallState2VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => value.Equals(parameter) ? Visibility.Visible : Visibility.Collapsed;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }


    [ValueConversion(typeof(InstallState), typeof(bool))]
    public class InstallState2BooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => value.Equals(InstallState.Idle) ? false : true;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
