using System;
using System.Windows;
using System.Windows.Interop;

namespace SonicNextModManager
{
    public class ImmersiveWindow : Window
    {
        protected override void OnSourceInitialized(EventArgs e)
        {
            // Initialise immersive dark mode for every NoireWindow.
            ImmersiveDarkMode.Initialise(new WindowInteropHelper(this).Handle, true);

            base.OnSourceInitialized(e);
        }
    }
}
