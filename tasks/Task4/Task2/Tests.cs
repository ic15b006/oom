using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task2
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void CanCreateAuto()
        {
            var x = new Auto("Audi", "A4", 50000);

            Assert.IsTrue(x.Marke == "Audi");
            Assert.IsTrue(x.Modell == "A4");
            Assert.IsTrue(x.Preis == 50000);
        }

        [Test]
        public void CanCreateMotorrad()
        {
            var x = new Motorrad("BMW", "ABC", 50000);

            Assert.IsTrue(x.Marke == "BMW");
            Assert.IsTrue(x.Modell == "ABC");
            Assert.IsTrue(x.Preis == 50000);
        }

        [Test]
        public void AutoWithEmptyMarke1()
        {
            Assert.Catch(() =>
                {
                    var x = new Auto(null, "A4", 50000);
                });
        }

        [Test]
        public void AutoWithEmptyMarke2()
        {
            Assert.Catch(() =>
            {
                var x = new Auto("", "A4", 50000);
            });
        }

        [Test]
        public void MotorradWithEmptyMarke1()
        {
            Assert.Catch(() =>
            {
                var x = new Motorrad(null, "ABC", 50000);
            });
        }

        [Test]
        public void MotorradWithEmptyMarke2()
        {
            Assert.Catch(() =>
            {
                var x = new Motorrad("", "ABC", 50000);
            });
        }

        [Test]
        public void AutoWithEmptyModell1()
        {
            Assert.Catch(() =>
            {
                var x = new Auto("Audi", null, 50000);
            });
        }

        [Test]
        public void AutoWithEmptyModell2()
        {
            Assert.Catch(() =>
            {
                var x = new Auto("Audi", "", 50000);
            });
        }

        [Test]
        public void MotorradWithEmptyModell1()
        {
            Assert.Catch(() =>
            {
                var x = new Motorrad("BMW", null, 50000);
            });
        }

        [Test]
        public void MotorradWithEmptyModell2()
        {
            Assert.Catch(() =>
            {
                var x = new Motorrad("BMW", "", 50000);
            });
        }

        

    }
}
