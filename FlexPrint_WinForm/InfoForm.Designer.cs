namespace FlexPrint_WinForm
{
	partial class InfoForm
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
			Indotextbox = new RichTextBox();
			HeaderInfo = new TextBox();
			paragraphinfo1 = new TextBox();
			SuspendLayout();
			// 
			// Indotextbox
			// 
			Indotextbox.BackColor = SystemColors.ActiveCaption;
			Indotextbox.BorderStyle = BorderStyle.None;
			Indotextbox.Location = new Point(12, 84);
			Indotextbox.Name = "Indotextbox";
			Indotextbox.Size = new Size(765, 354);
			Indotextbox.TabIndex = 0;
			Indotextbox.Text = "";
			// 
			// HeaderInfo
			// 
			HeaderInfo.BackColor = SystemColors.ActiveCaption;
			HeaderInfo.BorderStyle = BorderStyle.None;
			HeaderInfo.Location = new Point(368, 12);
			HeaderInfo.Name = "HeaderInfo";
			HeaderInfo.Size = new Size(61, 20);
			HeaderInfo.TabIndex = 1;
			HeaderInfo.Text = "FlexPrint";
			// 
			// paragraphinfo1
			// 
			paragraphinfo1.BackColor = SystemColors.ActiveCaption;
			paragraphinfo1.BorderStyle = BorderStyle.None;
			paragraphinfo1.Location = new Point(86, 38);
			paragraphinfo1.Name = "paragraphinfo1";
			paragraphinfo1.Size = new Size(631, 20);
			paragraphinfo1.TabIndex = 2;
			// 
			// InfoForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ActiveCaption;
			ClientSize = new Size(800, 450);
			Controls.Add(paragraphinfo1);
			Controls.Add(HeaderInfo);
			Controls.Add(Indotextbox);
			Name = "InfoForm";
			Text = "InfoForm";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private RichTextBox Indotextbox;
		private TextBox HeaderInfo;
		private TextBox paragraphinfo1;
	}
}