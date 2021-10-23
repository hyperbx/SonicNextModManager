using System.Diagnostics;

namespace SonicNextModManager
{
    public class ProcessExtensions
    {
        /// <summary>
        /// Opens the input URL in the default application.
        /// </summary>
        /// <param name="url">URL to open.</param>
        public static void OpenWithDefaultProgram(string url)
        {
            Process.Start
            (
                new ProcessStartInfo("cmd", $"/c start \"\" \"{url}\"")
                {
                    CreateNoWindow = true
                }
            );
        }
    }
}
