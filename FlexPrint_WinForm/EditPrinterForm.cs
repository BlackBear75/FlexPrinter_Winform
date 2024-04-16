using FlexPrint_Console.Enum;
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
	public partial class EditPrinterForm : Form
	{
		public string PrinterCode { get; set; }
		public string Model { get; set; }
		public string Manufacturer { get; set; }
		public decimal Price { get; set; }
		public MaxPrinterSize PrinterSize { get; set; }
		public PrinterPurpose Purpose { get; set; }
		public string? LaserType { get; set; }
		public bool? Duplex { get; set; }
		// Конструктор класу
		public EditPrinterForm(string printerCode, string model, string manufacturer, decimal price, MaxPrinterSize printerSize, PrinterPurpose purpose, string laserType, bool? duplex)
		{
			PrinterCode = printerCode;
			Model = model;
			Manufacturer = manufacturer;
			Price = price;
			PrinterSize = printerSize;
			Purpose = purpose;
			LaserType = laserType;
			Duplex = duplex;

			InitializeComponent();
			// Заповнення поля ProductCodeView отриманим значенням printerCode
			ProductCodeView.Text = printerCode;

			// Заповнення полів для редагування зі значеннями, що ми отримали
			ModelView.Text = model;
			ManufactureView.Text = manufacturer;
			PriceView.Text = price.ToString();

			// Встановлення значення комбо-боксів відповідно до отриманих значень
			PurposeCombobox.SelectedItem = purpose.ToString();
			PrintSizeCombobox.SelectedItem = printerSize.ToString();

			// Перевірка і встановлення значень комбо-боксів для LaserType або Duplex
			if (laserType != null)
			{
				LaserTypeCombobox.SelectedItem = laserType;
				LaserTypeCombobox.Visible = true;
				LaserTypeT.Visible = true;
			}
			else if (duplex != null)
			{
				if (duplex == true)
				{
					DuplexCombobox.SelectedIndex = 0; 
				}
				else
				{
					DuplexCombobox.SelectedIndex = 1; 
				}

				DuplexCombobox.Visible = true;
				DuplexT.Visible = true;
			}
		}


	}
}
