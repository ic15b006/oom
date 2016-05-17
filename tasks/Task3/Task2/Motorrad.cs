using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Motorrad : Fahrzeug
    {
        private decimal m_preis;
        private string m_marke;
        private string m_modell;

        public Motorrad(string marke, string modell, decimal preis)
        {
            if (string.IsNullOrWhiteSpace(marke))
                throw new Exception("Motorradmarke muss einen Namen haben");
            if (string.IsNullOrWhiteSpace(modell))
                throw new Exception("Modell muss einen Namen haben");
            if (preis < 0)
                throw new Exception("Preis darf nicht kleiner als 0 betragen");


            m_marke = marke;
            m_modell = modell;
            m_preis = preis;
        }

        public void UpdatePrice(decimal Price)
        {
            if (Price < 0)
                throw new Exception("Preis darf nicht kleiner als 0 betragen");
            m_preis = Price;
        }

        public string Marke
        {
            get
            {
                return m_marke;
            }
        }

        public string Modell
        {
            get
            {
                return m_modell;
            }
        }

        public decimal Preis
        {
            get
            {
                return m_preis;
            }
        }

    }
}
