using FlexPrint_Console.Enum;
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

		// Метод, що повертає дані про новий принтер
		public Printer GetPrinterData()
		{
			// Отримуємо дані про принтер з полів форми
			string model = txtModel.Text;
			string manufacturer = txtManufacturer.Text;
			// Отримуємо і перетворюємо ціну
			decimal price;
			decimal.TryParse(txtPrice.Text, out price);
			// Отримуємо і перетворюємо розмір принтера
			int printerSize;
			int.TryParse(txtPrinterSize.Text, out printerSize);
			// Отримуємо призначення принтера з комбобокса
			PrinterPurpose purpose = (PrinterPurpose)comboBoxPurpose.SelectedItem;

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

		// Обробник події для кнопки "Додати"
		private void btnAdd_Click(object sender, EventArgs e)
		{
			// Перевіряємо, чи всі поля заповнені
			if (string.IsNullOrWhiteSpace(txtModel.Text) ||
				string.IsNullOrWhiteSpace(txtManufacturer.Text) ||
				string.IsNullOrWhiteSpace(txtPrice.Text) ||
				string.IsNullOrWhiteSpace(txtPrinterSize.Text))
			{
				MessageBox.Show("Please fill in all fields.");
				return;
			}

			// Перевіряємо, чи введена правильна ціна
			decimal price;
			if (!decimal.TryParse(txtPrice.Text, out price))
			{
				MessageBox.Show("Please enter a valid price.");
				return;
			}

			// Перевіряємо, чи введено правильний розмір принтера
			int printerSize;
			if (!int.TryParse(txtPrinterSize.Text, out printerSize))
			{
				MessageBox.Show("Please enter a valid printer size.");
				return;
			}

			// Закриваємо форму з результатом DialogResult.OK
			DialogResult = DialogResult.OK;
			Close();
		}

		// Обробник події для кнопки "Відмінити"
		private void btnCancel_Click(object sender, EventArgs e)
		{
			// Закриваємо форму з результатом DialogResult.Cancel
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
