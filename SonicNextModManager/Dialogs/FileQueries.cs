using Microsoft.Win32;
using System.Collections.Generic;
using System.Text;

namespace SonicNextModManager
{
    public class FileQueries
    {
        private static string BasicFileQuery(string title, Dictionary<string, string> filter)
        {
            StringBuilder filterBuilder = new();
            {
                // Create filter using dictionary values.
                foreach (var entry in filter)
                    filterBuilder.Append($"{entry.Key} ({entry.Value})|{entry.Value.Replace(" ", "")}|");

                // Remove last pipe to make it a valid filter.
                filterBuilder.Remove(filterBuilder.Length - 1, 1);
            }

            OpenFileDialog ofd = new()
            {
                Filter = filterBuilder.ToString(),
                Title = title
            };

            if (ofd.ShowDialog() == true)
                return ofd.FileName;

            return string.Empty;
        }

        public static string QueryGameExecutable()
        {
            return BasicFileQuery
            (
                "Please select your game executable...",
                new Dictionary<string, string>
                {
                    { "Supported files", "*.xex; *.bin" },
                    { "Xbox 360 executable", "*.xex" },
                    { "PlayStation 3 executable", "*.bin" }
                }
            );
        }

        public static string QueryEmulatorExecutable()
        {
            OpenFileDialog ofd = new()
            {
                Filter = "Supported files (*.exe)|*.exe",
                Title = "Please select your emulator executable..."
            };

            if (ofd.ShowDialog() == true)
                return ofd.FileName;

            return string.Empty;
        }
    }
}
