using FlexPrint_Console.Enum;
using FlexPrint_Console.Model;
using FlexPrint_WinForm.Model;
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
	public partial class AddPrinterForm : Form
	{
		public AddPrinterForm()
		{
			InitializeComponent();
		}

		private void TypePrinter_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Отримуємо вибраний тип принтера
			string selectedType = TypePrinter.SelectedItem.ToString();

			// Перевіряємо, чи вибраний тип - Laser
			if (selectedType == "Laser")
			{
				// Показуємо поле LaserType
				LaserType.Visible = true;
				LaserTypeT.Visible = true;
				InkjectType.Visible = false;
				InkjectTypeT.Visible = false;
			}
			if (selectedType == "Inkject")
			{
				InkjectType.Visible = true;
				InkjectTypeT.Visible = true;
				LaserType.Visible = false;
				LaserTypeT.Visible = false;

			}
		}


		public Printer GetPrinterData()
		{
			string model = EnterName.Text;
			string manufacturer = Manufacturer.Text;
			decimal price;
			decimal.TryParse(Price.Text, out price);
			MaxPrinterSize printerSize;
			if (!Enum.TryParse(PrinterSize.SelectedItem.ToString(), out printerSize))
			{
				MessageBox.Show("Please select a valid purpose.");
				return null;
			}
			PrinterPurpose purpose;
			if (!Enum.TryParse(Purpose.SelectedItem.ToString(), out purpose))
			{
				MessageBox.Show("Please select a valid purpose.");
				return null;
			}

			if (TypePrinter.SelectedItem.ToString() == "Laser")
			{
				
					string selectedLaserType = LaserType.SelectedItem.ToString();
					LaserPrinterType laserPrinterType;
					if (!Enum.TryParse(selectedLaserType, out laserPrinterType))
					{
						MessageBox.Show("Please select a valid laser printer type.");
						return null;
					}
					return new LaserPrinter
					{
						Model = model,
						Manufacturer = manufacturer,
						Price = price,
						PrinterSize = printerSize,
						Purpose = purpose,
						LaserType = laserPrinterType
					};
				
			}

			if (TypePrinter.SelectedItem.ToString() == "Inkject")
			{
			
				bool duplex = false;
				if (InkjectType.SelectedItem.ToString() == "Yes")
				{
					duplex = true;
				}

			
				return new InkjetPrinter
				{
					Model = model,
					Manufacturer = manufacturer,
					Price = price,
					PrinterSize = printerSize,
					Purpose = purpose,
					Duplex = duplex
				};
			}


			// Повертаємо новий об'єкт принтера
			return new Printer
			{
				Model = model,
				Manufacturer = manufacturer,
				Price = price,
				PrinterSize = printerSize,
				Purpose = purpose
			};
		}

		private void AddPrinter_Click(object sender, EventArgs e)
		{
			
			if (string.IsNullOrWhiteSpace(EnterName.Text) ||
				string.IsNullOrWhiteSpace(Manufacturer.Text) ||
				string.IsNullOrWhiteSpace(Price.Text) ||
				string.IsNullOrWhiteSpace(PrinterSize.Text))
			{
				MessageBox.Show("Please fill in all fields.");
				return;
			}
			
			if (!decimal.TryParse(Price.Text, out decimal price))
			{
				MessageBox.Show("Please enter a valid price.");
				return;
			}
			
			if (!Enum.TryParse(PrinterSize.SelectedItem.ToString(), out MaxPrinterSize printerSize))
			{
				MessageBox.Show("Please select a valid printer size.");
				return;
			}

		
			DialogResult = DialogResult.OK;
		}

		private void Cancel_button_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
