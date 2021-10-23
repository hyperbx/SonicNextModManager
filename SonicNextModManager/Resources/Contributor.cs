using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using Newtonsoft.Json;

namespace SonicNextModManager
{
    public class Contributor
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? URL { get; set; }

        public string? Category { get; set; }

        public static List<Contributor> Parse()
            => JsonConvert.DeserializeObject<List<Contributor>>(Properties.Resources.Contributors);

        public static Dictionary<string, Expander> GetCategorisedExpanders()
        {
            Dictionary<string, Expander> expanders = new();

            foreach (var contributor in Parse())
            {
                string category = contributor.Category;

                if (!expanders.ContainsKey(category))
                {
                    Expander expander = new()
                    {
                        Background = new SolidColorBrush(Color.FromRgb(32, 32, 32)),
                        Content = new ListView(),
                        Header = category,
                        IsExpanded = true,
                        Margin = new Thickness(10, 10, 10, 0)
                    };

                    // Create new category if it doesn't exist.
                    expanders.Add(category, expander);
                }

                // Setup current list view.
                ListView lv = (ListView)expanders[category].Content;
                {
                    GridView lvGridView = new()
                    {
                        AllowsColumnReorder = false,
                        ColumnHeaderContainerStyle = (Style)Application.Current.Resources["SlimGridViewColumnHeader"]
                    };

                    GridViewColumn name = new()
                    {
                        Header = nameof(Name),
                        DisplayMemberBinding = new Binding(nameof(Name)),
                        Width = 95
                    };

                    GridViewColumn desc = new()
                    {
                        Header = nameof(Description),
                        DisplayMemberBinding = new Binding(nameof(Description)),
                        Width = 370
                    };

                    lvGridView.Columns.Add(name);
                    lvGridView.Columns.Add(desc);

                    lv.Background = new SolidColorBrush(Color.FromRgb(25, 25, 25));
                    lv.ItemContainerStyle = (Style)Application.Current.Resources["SlimListViewItem"];
                    lv.View = lvGridView;
                }

                // Add contributor to the list view.
                lv.Items.Add(contributor);
            }

            foreach (var expander in expanders.Values)
            {
                // Setup list view event handlers.
                ListView lv = (ListView)expander.Content;
                {
                    lv.MouseDoubleClick += (s, e) =>
                    {
                        string url = ((Contributor)((ListView)e.Source).SelectedItem).URL;

                        // Direct to user webpage (if available) when double-clicked.
                        if (!string.IsNullOrEmpty(url))
                            ProcessExtensions.OpenWithDefaultProgram(url);
                    };
                }
            }

            return expanders;
        }
    }
}
