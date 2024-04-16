using FlexPrint_Console.Enum;
using FlexPrint_Console.Manager;
using FlexPrint_Console.Model;
using FlexPrint_WinForm.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlexPrint_WinForm
{
	public partial class MainWindow : Form
	{
		private IPrinterManager printerManager;
		public MainWindow(IConfiguration config)
		{
			printerManager = new PrinterManager(config);
			InitializeComponent();
			MinimumSize = new Size(1060, 500);
		}

		private void Load_Data_Click(object sender, EventArgs e)
		{

			LinkedList<Printer> printers = printerManager.GetPrinters();
			PrintforView(printers);

		}

		private void Remove_Click(object sender, EventArgs e)
		{

			if (dataGridView1.SelectedRows.Count > 0)
			{

				DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
				DialogResult result = MessageBox.Show("Ви впевнені, що хочете видалити цей запис?", "Підтвердження видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


				if (result == DialogResult.Yes)
				{

					string productCode = selectedRow.Cells[0].Value.ToString();

					printerManager.RemovePrinter(productCode);

					dataGridView1.Rows.Remove(selectedRow);
				}
			}
			else
			{
				MessageBox.Show("Будь ласка, виберіть рядок для видалення.", "Помилка видалення", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void Add_Click(object sender, EventArgs e)
		{

			AddPrinterForm addPrinterForm = new AddPrinterForm();

			DialogResult result = addPrinterForm.ShowDialog();


			if (result == DialogResult.OK)
			{

				Printer printer = addPrinterForm.GetPrinterData();

				printerManager.AddPrinter(printer);


				LinkedList<Printer> printers = printerManager.GetPrinters();
				PrintforView(printers);

			}
		}

		private void Sort_by_Click(object sender, EventArgs e)
		{
			string selectedMethod;
			if (SortingMethod.SelectedItem == null)
			{
				MessageBox.Show("Please select a valid sorting method.");
				return;
			}
			else
			{
				selectedMethod = SortingMethod.SelectedItem.ToString();
			}


			switch (selectedMethod)
			{
				case "Price":

					LinkedList<Printer> sortedPrinters = printerManager.SortPrintersByPrice();
					PrintforView(sortedPrinters);
					break;

				default:
					MessageBox.Show("Please select a valid sorting method.");
					break;
			}

		}
		private void GetPrinter_Click(object sender, EventArgs e)
		{
			string selectedOption;
			if (GetPrintersCombobox.SelectedItem == null)
			{
				MessageBox.Show("Please select a GetPtinter method.");
				return;
			}
			else
			{
				selectedOption = GetPrintersCombobox.SelectedItem.ToString();
			}

			switch (selectedOption)
			{
				case "Office":
					LinkedList<Printer> officePrinters = printerManager.GetOfficePrinters();
					PrintforView(officePrinters);

					break;
				case "Home":
					LinkedList<Printer> homePrinters = printerManager.GetHomePrinters();
					PrintforView(homePrinters);
					break;
				case "Laser Printer":
					LinkedList<Printer> laserPrinters = printerManager.GetLaserPrinters();
					PrintforView(laserPrinters);
					break;
				case "Inkject Printer":
					LinkedList<Printer> inkjetPrinters = printerManager.GetInkjetPrinters();
					PrintforView(inkjetPrinters);
					break;

				default:

					break;
			}
		}
		private void Findbutton_Click(object sender, EventArgs e)
		{
		
			string manufacturer = FindTextbox.Text;

			if (string.IsNullOrEmpty(manufacturer))
			{
				MessageBox.Show("Please enter a manufacturer name.");
				return;
			}

			LinkedList<Printer> printersByManufacturer = printerManager.GetPrintersByManufacturer(manufacturer);
			if (printersByManufacturer.Count == 0)
			{
				MessageBox.Show($"No printers found for manufacturer {manufacturer}.");
				return;
			}
			PrintforView(printersByManufacturer);

			

		}



		public void PrintforView(LinkedList<Printer> sortedPrinters)
		{
			dataGridView1.Rows.Clear();
			foreach (var printer in sortedPrinters)
			{
				if (printer is LaserPrinter)
				{
					dataGridView1.Rows.Add(printer.ProductCode, printer.Model, printer.Manufacturer, printer.Price, printer.PrinterSize, printer.Purpose, ((LaserPrinter)printer).LaserType, null);
				}
				else if (printer is InkjetPrinter)
				{
					dataGridView1.Rows.Add(printer.ProductCode, printer.Model, printer.Manufacturer, printer.Price, printer.PrinterSize, printer.Purpose, null, ((InkjetPrinter)printer).Duplex);
				}
			}
		}

	
	}
}
