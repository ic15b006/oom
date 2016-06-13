using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public interface Fahrzeug
    {
        decimal Preis { get; }
        string Marke { get; }
        string Modell { get; }
        void UpdatePrice(decimal Price);
    }
}
