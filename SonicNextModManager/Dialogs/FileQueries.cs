using Microsoft.Win32;
using System.Collections.Generic;
using System.Text;

namespace SonicNextModManager
{
    public class FileQueries
    {
        private static string BasicFileQuery(string title, Dictionary<string, string> filters)
        {
            OpenFileDialog ofd = new()
            {
                Filter = new FilterBuilder(filters).Result,
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
                Language.Localise("Query_GameExecutable"),

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
            return BasicFileQuery
            (
                Language.Localise("Query_EmulatorExecutable"),

                new Dictionary<string, string>
                {
                    { "Supported files", "*.exe" }
                }
            );
        }
    }
}
