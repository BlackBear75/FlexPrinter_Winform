namespace FlexPrint_WinForm
{
	partial class MainWindow
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			dataGridView1 = new DataGridView();
			dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
			dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
			dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
			dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
			dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
			dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
			dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
			Remove = new Button();
			Add = new Button();
			SortingMethod = new ComboBox();
			comboBox2 = new ComboBox();
			textBox1 = new TextBox();
			button3 = new Button();
			Load_Data = new Button();
			Sort_by = new Button();
			GetPrinter = new Button();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			SuspendLayout();
			// 
			// dataGridView1
			// 
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8 });
			dataGridView1.Location = new Point(3, 117);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.RowHeadersWidth = 70;
			dataGridView1.RowTemplate.Height = 40;
			dataGridView1.Size = new Size(1030, 274);
			dataGridView1.TabIndex = 0;
			// 
			// dataGridViewTextBoxColumn1
			// 
			dataGridViewTextBoxColumn1.HeaderText = "ProductCode";
			dataGridViewTextBoxColumn1.MinimumWidth = 6;
			dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			// 
			// dataGridViewTextBoxColumn2
			// 
			dataGridViewTextBoxColumn2.HeaderText = "Model";
			dataGridViewTextBoxColumn2.MinimumWidth = 6;
			dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			// 
			// dataGridViewTextBoxColumn3
			// 
			dataGridViewTextBoxColumn3.HeaderText = "Manufacturer";
			dataGridViewTextBoxColumn3.MinimumWidth = 6;
			dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			// 
			// dataGridViewTextBoxColumn4
			// 
			dataGridViewTextBoxColumn4.HeaderText = "Price";
			dataGridViewTextBoxColumn4.MinimumWidth = 6;
			dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			// 
			// dataGridViewTextBoxColumn5
			// 
			dataGridViewTextBoxColumn5.HeaderText = "PrinterSize";
			dataGridViewTextBoxColumn5.MinimumWidth = 6;
			dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			// 
			// dataGridViewTextBoxColumn6
			// 
			dataGridViewTextBoxColumn6.HeaderText = "Purpose";
			dataGridViewTextBoxColumn6.MinimumWidth = 6;
			dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			// 
			// dataGridViewTextBoxColumn7
			// 
			dataGridViewTextBoxColumn7.HeaderText = "LaserType";
			dataGridViewTextBoxColumn7.MinimumWidth = 6;
			dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
			// 
			// dataGridViewTextBoxColumn8
			// 
			dataGridViewTextBoxColumn8.HeaderText = "Duplex";
			dataGridViewTextBoxColumn8.MinimumWidth = 6;
			dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
			// 
			// Remove
			// 
			Remove.Location = new Point(12, 59);
			Remove.Name = "Remove";
			Remove.Size = new Size(113, 41);
			Remove.TabIndex = 1;
			Remove.Text = "Remove";
			Remove.UseVisualStyleBackColor = true;
			Remove.Click += Remove_Click;
			// 
			// Add
			// 
			Add.Location = new Point(131, 59);
			Add.Name = "Add";
			Add.Size = new Size(115, 41);
			Add.TabIndex = 2;
			Add.Text = "Add";
			Add.UseVisualStyleBackColor = true;
			Add.Click += Add_Click;
			// 
			// SortingMethod
			// 
			SortingMethod.DropDownStyle = ComboBoxStyle.DropDownList;
			SortingMethod.FormattingEnabled = true;
			SortingMethod.Items.AddRange(new object[] { "Price" });
			SortingMethod.Location = new Point(355, 66);
			SortingMethod.Name = "SortingMethod";
			SortingMethod.Size = new Size(151, 28);
			SortingMethod.TabIndex = 3;
			// 
			// comboBox2
			// 
			comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBox2.FormattingEnabled = true;
			comboBox2.Items.AddRange(new object[] { "Office", "Home", "Laser Printer" });
			comboBox2.Location = new Point(578, 65);
			comboBox2.Name = "comboBox2";
			comboBox2.Size = new Size(156, 28);
			comboBox2.TabIndex = 4;
			// 
			// textBox1
			// 
			textBox1.Location = new Point(805, 67);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(125, 27);
			textBox1.TabIndex = 5;
			// 
			// button3
			// 
			button3.Location = new Point(939, 65);
			button3.Name = "button3";
			button3.Size = new Size(94, 29);
			button3.TabIndex = 6;
			button3.Text = "Find";
			button3.UseVisualStyleBackColor = true;
			// 
			// Load_Data
			// 
			Load_Data.Location = new Point(12, 12);
			Load_Data.Name = "Load_Data";
			Load_Data.Size = new Size(113, 41);
			Load_Data.TabIndex = 7;
			Load_Data.Text = "Load Data";
			Load_Data.UseVisualStyleBackColor = true;
			Load_Data.Click += Load_Data_Click;
			// 
			// Sort_by
			// 
			Sort_by.Location = new Point(282, 65);
			Sort_by.Name = "Sort_by";
			Sort_by.Size = new Size(67, 29);
			Sort_by.TabIndex = 8;
			Sort_by.Text = "Sort by";
			Sort_by.UseVisualStyleBackColor = true;
			Sort_by.Click += Sort_by_Click;
			// 
			// GetPrinter
			// 
			GetPrinter.Location = new Point(525, 65);
			GetPrinter.Name = "GetPrinter";
			GetPrinter.Size = new Size(47, 29);
			GetPrinter.TabIndex = 9;
			GetPrinter.Text = "Get";
			GetPrinter.UseVisualStyleBackColor = true;
			GetPrinter.Click += GetPrinter_Click;
			// 
			// MainWindow
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ActiveCaption;
			ClientSize = new Size(1051, 403);
			Controls.Add(GetPrinter);
			Controls.Add(Sort_by);
			Controls.Add(Load_Data);
			Controls.Add(button3);
			Controls.Add(textBox1);
			Controls.Add(comboBox2);
			Controls.Add(SortingMethod);
			Controls.Add(Add);
			Controls.Add(Remove);
			Controls.Add(dataGridView1);
			Name = "MainWindow";
			Text = "FlexPrint";
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private DataGridView dataGridView1;
		private Button Remove;
		private Button Add;
		private ComboBox SortingMethod;
		private ComboBox comboBox2;
		private TextBox textBox1;
		private Button button3;
		private Button Load_Data;
		private Button Sort_by;
		private Button GetPrinter;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
	}
}