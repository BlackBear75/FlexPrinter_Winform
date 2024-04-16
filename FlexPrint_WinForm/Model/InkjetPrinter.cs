using FlexPrint_WinForm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexPrint_Console.Model
{
	public class InkjetPrinter : Printer
	{
		public bool Duplex { get; set; }

		public override decimal CalculatePurchaseCost()
		{
			return base.CalculatePurchaseCost();
		}
	}
}
