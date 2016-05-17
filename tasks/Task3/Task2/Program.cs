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

            /* var MeinAuto = new Auto("Audi", "A4", 50000);
             Console.WriteLine("Marke: {0} Modell: {1} Preis: {2}", MeinAuto.Marke, MeinAuto.Modell, MeinAuto.Preis);
             MeinAuto.UpdatePrice(10000);
             Console.WriteLine("Marke: {0} Modell: {1} Preis: {2}", MeinAuto.Marke, MeinAuto.Modell, MeinAuto.Preis);
             */

            var item = new Fahrzeug[]
            {
                new Auto("Audi", "A4", 50000),
                new Auto("BMW", "3er", 40000),
                new Motorrad("KTM", "ABC", 10000),
            };

            item[0].UpdatePrice(99999);

            foreach(var x in item)
            {
                Console.WriteLine("Marke: {0} Modell: {1} Preis: {2}", x.Marke, x.Modell, x.Preis);
            }

        }
    }
}
