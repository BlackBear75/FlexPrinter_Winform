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
			// Отримання списку принтерів з допомогою вашого PrinterManager
			LinkedList<Printer> printers = printerManager.GetPrinters();

			// Очищення даних у DataGridView
			dataGridView1.Rows.Clear();

			// Додавання даних у DataGridView
			foreach (var printer in printers)
			{
				if (printer is LaserPrinter)
				{
					dataGridView1.Rows.Add(printer.ProductCode, printer.Model, printer.Manufacturer, printer.Price, printer.PrinterSize, printer.Purpose, ((LaserPrinter)(object)printer).LaserType);
				}
				if (printer is InkjetPrinter)
				{
					dataGridView1.Rows.Add(printer.ProductCode, printer.Model, printer.Manufacturer, printer.Price, printer.PrinterSize, printer.Purpose, ((InkjetPrinter)(object)printer).Duplex);
				}
			}
		}

		private void Remove_Click(object sender, EventArgs e)
		{
			// Перевіряємо, чи вибрано який-небудь рядок у DataGridView
			if (dataGridView1.SelectedRows.Count > 0)
			{
				// Отримуємо обраний рядок
				DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

				// Виводимо підтвердження видалення за допомогою MessageBox
				DialogResult result = MessageBox.Show("Ви впевнені, що хочете видалити цей запис?", "Підтвердження видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

				// Перевіряємо результат підтвердження
				if (result == DialogResult.Yes)
				{
					// Отримуємо код продукту з обраного рядка (передбачається, що перший стовпчик містить код продукту)
					string productCode = selectedRow.Cells[0].Value.ToString();

					// Видаляємо принтер зі списку із відповідним кодом продукту
					printerManager.RemovePrinter(productCode);

					// Видаляємо обраний рядок з DataGridView
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
			// Створення нової форми для додавання принтера
			AddPrinterForm addPrinterForm = new AddPrinterForm();

			
			DialogResult result = addPrinterForm.ShowDialog();

	
			if (result == DialogResult.OK)
			{
				
				Printer printer = addPrinterForm.GetPrinterData();

				// Додавання принтера до списку або бази даних
				// Наприклад:
				// printers.Add(printer); // додати до списку
				// SavePrinterToDatabase(printer); // зберегти у базі даних

				// Оновлення списку у головному вікні (якщо потрібно)
				// Наприклад:
				// UpdatePrintersList();
			}
		}
	}
}
