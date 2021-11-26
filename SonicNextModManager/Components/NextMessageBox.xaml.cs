using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Drawing;
using System.Media;

namespace SonicNextModManager
{
    /// <summary>
    /// Interaction logic for NextMessageBox.xaml
    /// </summary>
    public partial class NextMessageBox : ImmersiveWindow
    {
        public static readonly DependencyProperty CaptionProperty = DependencyProperty.Register
        (
            nameof(Caption),
            typeof(string),
            typeof(NextMessageBox),
            new PropertyMetadata("Placeholder")
        );

        public string Caption
        {
            get => (string)GetValue(CaptionProperty);
            set => SetValue(CaptionProperty, value);
        }

        public static readonly DependencyProperty MessageProperty = DependencyProperty.Register
        (
            nameof(Message),
            typeof(string),
            typeof(NextMessageBox),
            new PropertyMetadata("Placeholder")
        );

        public string Message
        {
            get => (string)GetValue(MessageProperty);
            set => SetValue(MessageProperty, value);
        }

        public static readonly DependencyProperty ButtonWidthProperty = DependencyProperty.Register
        (
            nameof(ButtonWidth),
            typeof(int),
            typeof(NextMessageBox),
            new PropertyMetadata(120)
        );

        public int ButtonWidth
        {
            get => (int)GetValue(ButtonWidthProperty);
            set => SetValue(ButtonWidthProperty, value);
        }

        internal ObservableCollection<Button> Buttons { get; private set; } = new();

        public NextDialogResult Result { get; private set; }

        public NextMessageBox()
        {
            // Set owner to last active window calling this class.
            Owner = WindowHelper.GetActiveWindow();

            InitializeComponent();

            // Subscribe to events.
            Buttons.CollectionChanged += Buttons_CollectionChanged;

            DataContext = this;
        }

        /// <summary>
        /// Displays the message box dialog with the specified parameters.
        /// </summary>
        /// <param name="message">Message to display.</param>
        /// <param name="caption">Title bar caption to use.</param>
        /// <param name="buttons">Win32 buttons to display.</param>
        /// <param name="icon">Win32 icon to display.</param>
        public NextDialogResult Show
        (
            string message,
            string caption,
            NextMessageBoxButton buttons = NextMessageBoxButton.None,
            NextMessageBoxIcon icon = NextMessageBoxIcon.None
        )
        {
            Message = message;
            Caption = caption;

            // Add generic Win32 buttons.
            SetButtons(buttons);

            // Set dialog icon.
            SetIcon(icon);

            // Open message box.
            ShowDialog();

            return Result;
        }

        /// <summary>
        /// Refreshes the buttons if the observable collection was changed.
        /// </summary>
        private void Buttons_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            // Clear all message box buttons.
            MessageButtons.Children.Clear();

            // Add all buttons to the panel.
            foreach (var button in Buttons)
                MessageButtons.Children.Add(button);
        }

        /// <summary>
        /// Adds a button to the message box.
        /// </summary>
        /// <param name="caption">Text shown on the button.</param>
        /// <param name="action">Actions performed once the button is clicked.</param>
        public void AddButton(string caption, Action action)
        {
            Button button = Buttons.SingleOrDefault(x => x.Content == caption);

            // Remove button if it already exists.
            if (button != null)
                Buttons.Remove(button);

            // Create a new button.
            button = new()
            {
                Content = caption,
                Height = 32
            };

            // Set button click event.
            button.Click += (s, e) => action?.Invoke();

            Buttons.Add(button);
        }

        /// <summary>
        /// Adds the generic Win32 default buttons using <see cref="NextMessageBoxButton"/>.
        /// </summary>
        /// <param name="buttons">Buttons to use.</param>
        public void SetButtons(NextMessageBoxButton buttons)
        {
            switch (buttons)
            {
                case NextMessageBoxButton.OK:
                    SetButtonResultAndClose("Common_OK", NextDialogResult.OK);
                    break;

                case NextMessageBoxButton.OKCancel:
                    SetButtonResultAndClose("Common_Cancel", NextDialogResult.Cancel);
                    SetButtonResultAndClose("Common_OK", NextDialogResult.OK);
                    break;

                case NextMessageBoxButton.AbortRetryIgnore:
                    SetButtonResultAndClose("Common_Ignore", NextDialogResult.Ignore);
                    SetButtonResultAndClose("Common_Retry", NextDialogResult.Retry);
                    SetButtonResultAndClose("Common_Abort", NextDialogResult.Abort);
                    break;

                case NextMessageBoxButton.YesNoCancel:
                    SetButtonResultAndClose("Common_Cancel", NextDialogResult.Cancel);
                    SetButtonResultAndClose("Common_No", NextDialogResult.No);
                    SetButtonResultAndClose("Common_Yes", NextDialogResult.Yes);
                    break;

                case NextMessageBoxButton.YesNo:
                    SetButtonResultAndClose("Common_No", NextDialogResult.No);
                    SetButtonResultAndClose("Common_Yes", NextDialogResult.Yes);
                    break;

                case NextMessageBoxButton.RetryCancel:
                    SetButtonResultAndClose("Common_Cancel", NextDialogResult.Cancel);
                    SetButtonResultAndClose("Common_Retry", NextDialogResult.Retry);
                    break;
            }

            void SetButtonResultAndClose(string localisedResource, NextDialogResult result)
            {
                AddButton
                (
                    SonicNextModManager.Language.Localise(localisedResource), () =>
                    {
                        Result = result;
                        Close();
                    }
                );
            }
        }

        /// <summary>
        /// Sets the icon used by the message using <see cref="NextMessageBoxIcon"/>.
        /// </summary>
        /// <param name="icon">Icon to display.</param>
        public void SetIcon(NextMessageBoxIcon icon)
        {
            // Set default width in case this changes whilst the dialog is open.
            IconColumn.Width = new GridLength(64);

            // TODO: use local icon resources - these return the Windows Vista icons.
            switch (icon)
            {
                case NextMessageBoxIcon.None:
                    IconColumn.Width = new GridLength(0);
                    break;

                case NextMessageBoxIcon.Error:
                    SystemSounds.Hand.Play();
                    MessageIcon.Source = ImageHelper.GdiBitmapToBitmapSource(SystemIcons.Error.ToBitmap());
                    break;

                case NextMessageBoxIcon.Question:
                    SystemSounds.Question.Play();
                    MessageIcon.Source = ImageHelper.GdiBitmapToBitmapSource(SystemIcons.Question.ToBitmap());
                    break;

                case NextMessageBoxIcon.Warning:
                    SystemSounds.Asterisk.Play();
                    MessageIcon.Source = ImageHelper.GdiBitmapToBitmapSource(SystemIcons.Warning.ToBitmap());
                    break;

                case NextMessageBoxIcon.Information:
                    SystemSounds.Asterisk.Play();
                    MessageIcon.Source = ImageHelper.GdiBitmapToBitmapSource(SystemIcons.Information.ToBitmap());
                    break;
            }
        }

        /// <summary>
        /// Removes a button from the message box matching the input caption.
        /// </summary>
        /// <param name="caption">Caption to remove.</param>
        public void RemoveButton(string caption)
        {
            Button button = Buttons.SingleOrDefault(x => x.Content == caption);

            if (button != null)
            {
                // Remove button based on caption - generally you wouldn't have identical buttons.
                Buttons.Remove(button);
            }
        }
    }

    public enum NextMessageBoxButton
    {
        None,
        OK,
        OKCancel,
        AbortRetryIgnore,
        YesNoCancel,
        YesNo,
        RetryCancel
    }

    public enum NextMessageBoxIcon
    {
        None,
        Error,
        Question,
        Warning,
        Information,
    }

    public enum NextDialogResult
    {
        None,
        OK,
        Cancel,
        Abort,
        Retry,
        Ignore,
        Yes,
        No
    }
}
