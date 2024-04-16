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

					LinkedList<Printer> printers = GetPrintersFromDataGridView();
					
					LinkedList<Printer> sortedPrinters = printerManager.SortPrintersByPrice(printers);
					
					PrintforView(sortedPrinters);
					break;

				default:
					MessageBox.Show("Please select a valid sorting method.");
					break;
			}

		}
		private void GetPrinter_Click(object sender, EventArgs e)
		{
			LinkedList<Printer> printers = GetPrintersFromDataGridView();
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
				
					LinkedList<Printer> officePrinters = printerManager.GetOfficePrinters(printers);
					if(officePrinters.Count==0)
					{
						MessageBox.Show($"There are no printers in the current list, {selectedOption}");
						return;
					}
					PrintforView(officePrinters);

					break;
				case "Home":
					LinkedList<Printer> homePrinters = printerManager.GetHomePrinters(printers);
					if (homePrinters.Count == 0)
					{
						MessageBox.Show($"There are no printers in the current list, {selectedOption}");
						return;
					}
					PrintforView(homePrinters);
					break;
				case "Laser Printer":
					LinkedList<Printer> laserPrinters = printerManager.GetLaserPrinters(printers);
					if (laserPrinters.Count == 0)
					{
						MessageBox.Show($"There are no printers in the current list, {selectedOption}");
						return;
					}
					PrintforView(laserPrinters);
					break;
				case "Inkject Printer":
					LinkedList<Printer> inkjetPrinters = printerManager.GetInkjetPrinters(printers);
					if (inkjetPrinters.Count == 0)
					{
						MessageBox.Show($"There are no printers in the current list, {selectedOption}");
						return;
					}
					PrintforView(inkjetPrinters);
					break;

				default:

					break;
			}
		}
		private void Findbutton_Click(object sender, EventArgs e)
		{
			LinkedList<Printer> printers = GetPrintersFromDataGridView();
			string manufacturer = FindTextbox.Text;

			if (string.IsNullOrEmpty(manufacturer))
			{
				MessageBox.Show("Please enter a manufacturer name.");
				return;
			}

			LinkedList<Printer> printersByManufacturer = printerManager.GetPrintersByManufacturer(manufacturer, printers);
			if (printersByManufacturer.Count == 0)
			{
				MessageBox.Show($"No printers found for manufacturer {manufacturer}.");
				return;
			}
			PrintforView(printersByManufacturer);

		}

		private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

			if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
			{
				DataGridViewColumn column = dataGridView1.Columns[e.ColumnIndex];
				if (column is DataGridViewButtonColumn && column.HeaderText == "Edit")
				{
					DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
					string productCode = row.Cells["ProductCode"].Value.ToString();
					string model = row.Cells["Model"].Value.ToString();
					string manufacturer = row.Cells["Manufacturer"].Value.ToString();
					decimal price = Convert.ToDecimal(row.Cells["Price"].Value);
					string printerSizeString = row.Cells["PrinterSize"].Value.ToString();
					MaxPrinterSize printerSize;
					Enum.TryParse(printerSizeString, out printerSize);
					string purposeString = row.Cells["Purpose"].Value.ToString();
					PrinterPurpose purpose;
					Enum.TryParse(purposeString, out purpose);
					string laserType = row.Cells["LaserType"].Value?.ToString();
					bool? duplex = row.Cells["Duplex"].Value as bool?;

					// Відкриваємо нову форму редагування і передаємо дані рядка
					EditPrinterForm editForm = new EditPrinterForm(productCode, model, manufacturer, price, printerSize, purpose, laserType, duplex);
					editForm.ShowDialog();

					// Оновлення даних у випадку, якщо вони були змінені
					if (editForm.DialogResult == DialogResult.OK)
					{
						// Отримуємо відредаговані дані з форми редагування
						string editedModel = editForm.Model;
						string editedManufacturer = editForm.Manufacturer;
						decimal editedPrice = editForm.Price;
						MaxPrinterSize editedPrinterSize = editForm.PrinterSize;
						PrinterPurpose editedPurpose = editForm.Purpose;
						string editedLaserType = editForm.LaserType;
						bool? editedDuplex = editForm.Duplex;

						// Виконуємо оновлення даних у вашому джерелі даних або списку

						// Наприклад, оновіть значення у відповідному рядку вашого DataGridView
						row.Cells["Model"].Value = editedModel;
						row.Cells["Manufacturer"].Value = editedManufacturer;
						row.Cells["Price"].Value = editedPrice;
						row.Cells["PrinterSize"].Value = editedPrinterSize;
						row.Cells["Purpose"].Value = editedPurpose;
						row.Cells["LaserType"].Value = editedLaserType;
						row.Cells["Duplex"].Value = editedDuplex;
					}
				}
			}
		}

		private LinkedList<Printer> GetPrintersFromDataGridView()
		{
			LinkedList<Printer> printers = new LinkedList<Printer>();

			foreach (DataGridViewRow row in dataGridView1.Rows)
			{
				string productcode = row.Cells["ProductCode"].Value.ToString();
				string model = row.Cells["Model"].Value.ToString();
				string manufacturer = row.Cells["Manufacturer"].Value.ToString();
				decimal price = Convert.ToDecimal(row.Cells["Price"].Value);

				string printerSizeString = row.Cells["PrinterSize"].Value.ToString();
				MaxPrinterSize printerSize;
				if (!Enum.TryParse(printerSizeString, out printerSize))
				{
					MessageBox.Show("Invalid value for PrinterSize.");
					return null;
				}
				
				string purposeString = row.Cells["Purpose"].Value.ToString();
				PrinterPurpose purpose;
				if (!Enum.TryParse(purposeString, out purpose))
				{
					MessageBox.Show("Invalid value for Purpose.");
					return null;
				}
				if (row.Cells["LaserType"].Value != null)
				{
					string laserType = row.Cells["LaserType"].Value.ToString();
					LaserPrinterType laserPrinterType;

					// Перевіряємо, чи вдалося перетворити значення в перерахування
					if (!Enum.TryParse(laserType, out laserPrinterType))
					{
						MessageBox.Show("Invalid value for LaserType.");
						return null;
					}

					// Створюємо об'єкт типу LaserPrinter
					LaserPrinter laserPrinter = new LaserPrinter
					{
						ProductCode = productcode,
						Model = model,
						Manufacturer = manufacturer,
						Price = price,
						PrinterSize = printerSize,
						Purpose = purpose,
						LaserType = laserPrinterType
					};

					// Додаємо принтер до списку
					printers.AddLast(laserPrinter);
				}
			
				else if (row.Cells["Duplex"].Value != null)
				{
					string duplexValue = row.Cells["Duplex"].Value.ToString();
					bool duplex;

					// Перевіряємо, чи вдалося перетворити значення в логічний тип
					if (!bool.TryParse(duplexValue, out duplex))
					{
						MessageBox.Show("Invalid value for Duplex.");
						return null;
					}

					// Створюємо об'єкт типу InkjetPrinter
					InkjetPrinter inkjetPrinter = new InkjetPrinter
					{
						ProductCode= productcode,
						Model = model,
						Manufacturer = manufacturer,
						Price = price,
						PrinterSize = printerSize,
						Purpose = purpose,
						Duplex = duplex
					};

					// Додаємо принтер до списку
					printers.AddLast(inkjetPrinter);
				}
				else
				{
					MessageBox.Show("Either LaserType or Duplex must have a value.");
					return null;
				}
			}

			return printers;
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
