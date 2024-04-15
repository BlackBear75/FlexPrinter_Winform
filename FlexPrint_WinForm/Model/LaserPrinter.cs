﻿using FlexPrint_Console.Enum;
using FlexPrint_WinForm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexPrint_Console.Model
{
	public class LaserPrinter : Printer
	{

		public LaserPrinterType LaserType { get; set; }

		public override decimal CalculatePurchaseCost()
		{
			decimal discountedPrice = base.CalculatePurchaseCost();
			if (Price > 5000)
			{
				
				discountedPrice *= 0.95m;
     //           Console.WriteLine("After buying a laser printer from 5000 5% discount\n" +
					//$"{discountedPrice}$ due");
				
            }
			
			return discountedPrice;
		}
		//public override string ToString()
		//{
		//	return $"Laser Printer:\n Manufacturer: {Manufacturer}\n Model: " +
		//		$" {Model}\n Product Code: {ProductCode}\n Price: {Price}$\n Purpose:{Purpose}\n " +
		//		$"PrinterSize: {PrinterSize}\n LaserType: {LaserType}\n";
		//}
	}

}
