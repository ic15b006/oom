using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            //string neuerPreis;
            var MeinAuto = new Auto("Audi", "A4", 50000);
            Console.WriteLine("Marke: {0} Modell: {1} Preis: {2}", MeinAuto.Marke, MeinAuto.Modell, MeinAuto.Preis);
            MeinAuto.UpdatePrice(10000);
            Console.WriteLine("Marke: {0} Modell: {1} Preis: {2}", MeinAuto.Marke, MeinAuto.Modell, MeinAuto.Preis);

            /*Console.WriteLine("Geben Sie den neuen Preis ein: ");
            neuerPreis = Console.ReadLine();
            MeinAuto.SetGetPrice = Convert.ToDecimal(neuerPreis);
            Console.WriteLine("Marke: {0} Modell: {1}, Preis: {2}", MeinAuto.m_marke, MeinAuto.m_modell, MeinAuto.SetGetPrice);*/
        }
    }
}
