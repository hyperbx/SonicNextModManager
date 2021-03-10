using System.Drawing;
using System.Windows.Forms;

namespace Unify
{
    public class ListViewDrawing
    {
        public static void DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            // Draws the column background colour
            Color theme = Color.FromArgb(35, 35, 38);
            e.Graphics.FillRectangle(new SolidBrush(theme), e.Bounds);
            Point point = new Point(0, 4);
            point.X = e.Bounds.X;

            // Draws the column header by sender
            ColumnHeader column = ((ListView)sender).Columns[e.ColumnIndex];
            e.Graphics.FillRectangle(new SolidBrush(theme), point.X, 0, 2, e.Bounds.Height);
            point.X += column.Width / 2 - TextRenderer.MeasureText(column.Text, ((ListView)sender).Font).Width / 2;
            TextRenderer.DrawText(e.Graphics, column.Text, ((ListView)sender).Font, point, ((ListView)sender).ForeColor);
        }

        public static void DrawDarkItems(ListView sender)
        {
            int i = 0;

            foreach (ListViewItem lvi in sender.Items)
            {
                if (++i % 2 == 0)
                {
                    lvi.BackColor = Color.FromArgb(45, 45, 48);
                }
                else
                {
                    lvi.BackColor = Color.FromArgb(55, 55, 58);
                }
            }
        }
    }
}
