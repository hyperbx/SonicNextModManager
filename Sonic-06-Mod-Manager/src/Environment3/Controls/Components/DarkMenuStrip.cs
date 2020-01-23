using System.Drawing;
using System.Windows.Forms;

namespace Unify.Environment3 {
	public partial class DarkMenuStrip : MenuStrip {
		public DarkMenuStrip() {
			InitializeComponent();
			this.RenderMode = ToolStripRenderMode.Professional;
			this.Renderer = new ToolStripProfessionalRenderer(new ColorTable());
			ForeColor = SystemColors.Control;
		}
	}

	internal class ColorTable : ProfessionalColorTable {
		public override Color MenuItemBorder => MenuItemSelected;
		public override Color ButtonSelectedBorder => MenuItemBorder;
		public override Color ToolStripDropDownBackground => Color.FromArgb(0x1B, 0x1B, 0x1C);
		public override Color MenuItemSelected => Color.FromArgb(0x33, 0x33, 0x34);
		public override Color ButtonCheckedHighlight => MenuItemSelected;
		public override Color ButtonPressedHighlight => MenuItemSelected;
		public override Color ButtonSelectedGradientBegin => Color.FromArgb(0x18, 0x18, 0x18);
		public override Color ButtonSelectedGradientMiddle => ButtonSelectedGradientBegin;
		public override Color ButtonSelectedGradientEnd => ButtonSelectedGradientBegin;
		public override Color MenuItemPressedGradientBegin => Color.FromArgb(0x1B, 0x1B, 0x1C);
		public override Color MenuItemPressedGradientMiddle => MenuItemPressedGradientBegin;
		public override Color MenuItemPressedGradientEnd => MenuItemPressedGradientBegin;
		public override Color CheckBackground => Color.FromArgb(0x50, 0x50, 0x50);
		public override Color CheckPressedBackground => Color.FromArgb(0x30, 0x30, 0x30);
		public override Color CheckSelectedBackground => Color.FromArgb(0x68, 0x68, 0x68);
		public override Color MenuItemSelectedGradientBegin => Color.FromArgb(0x3E, 0x3E, 0x40);
		public override Color MenuItemSelectedGradientEnd => MenuItemSelectedGradientBegin;
		public override Color ImageMarginGradientBegin => Color.FromArgb(0x1B, 0x1B, 0x1C);
		public override Color ImageMarginGradientMiddle => ImageMarginGradientBegin;
		public override Color ImageMarginGradientEnd => ImageMarginGradientBegin;
		public override Color SeparatorDark => Color.FromArgb(0x33, 0x33, 0x37);
	}
}
