using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlexPrint_WinForm
{
	public partial class InfoForm : Form
	{
		public InfoForm()
		{
			InitializeComponent();
			Load += new System.EventHandler(this.InfoForm_Load);
			Resize += new System.EventHandler(this.InfoForm_Resize);
		}
		private void InfoForm_Load(object sender, EventArgs e)
		{
			HeaderInfo.Text = "FlexPrint";
			paragraphinfo1.Text = "Welcome";
			Indotextbox.Text = "faf";
		}
		private void InfoForm_Resize(object sender, EventArgs e)
		{
			int verticalSpacing = 10;
			int horizontalMargin = 20;
			int currentY = HeaderInfo.Bottom + verticalSpacing;

			// Параграф
			int paragraphX = horizontalMargin;
			paragraphinfo1.Location = new Point(paragraphX, currentY);

			// Оновлюємо координати для наступного елемента
			currentY += paragraphinfo1.Height + verticalSpacing;

			// TextBox
			int textboxX = horizontalMargin;
			Indotextbox.Location = new Point(textboxX, currentY);
		}

		
	}
}
