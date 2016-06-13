using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
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

            var settings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto };
            
            //store to file
            var text = JsonConvert.SerializeObject(item, settings);
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var filename = Path.Combine(desktop, "Fahrzeuge.json");
            File.WriteAllText(filename, text);

            //read file
            var textFromFile = File.ReadAllText(filename);
            Console.WriteLine(textFromFile);

            var itemsFromFile = JsonConvert.DeserializeObject<Fahrzeug[]>(textFromFile, settings);
            foreach (var x in itemsFromFile)
            {
                Console.WriteLine("Marke: {0} Modell: {1} Preis: {2}", x.Marke, x.Modell, x.Preis);
            }


            var source = new Subject<Fahrzeug>();

            source
              .Where(x => x.Preis >20000)
              .Subscribe(x => Console.WriteLine($"received {x.Marke} {x.Modell} {x.Preis}"))
              ;

            var t = new Thread(() =>
            {
                var i = new Fahrzeug[]
                {
                    new Auto("Audi", "A4", 50000),
                    new Auto("BMW", "3er", 40000),
                    new Motorrad("KTM", "ABC", 10000),
                };
                int c = 0;
                while (true)
                {
                    Thread.Sleep(250);
                    source.OnNext(i[c]);
                    Console.WriteLine($"sent {i[c].Marke} {i[c].Modell} {i[c].Preis}");
                    c++;
                    if (c >= 3)
                        c = 0;
                }
            });
            t.Start();
         


            var random = new Random();

            var xs = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            var tasks = new List<Task<int>>();

            foreach (var x in xs)
            {
                var task = Task.Run(() =>
                {
                    Console.WriteLine($"computing result for {x}");
                    Task.Delay(TimeSpan.FromSeconds(5.0)).Wait();
                    Console.WriteLine($"done computing result for {x}");
                    return x * x;
                });

                tasks.Add(task);
            }

            Console.WriteLine("doing something else ...");

            var tasks2 = new List<Task<int>>();
            foreach (var task in tasks.ToArray())
            {
                tasks2.Add(
                    task.ContinueWith(ta => { Console.WriteLine($"result is {ta.Result}"); return ta.Result; })
                );
            }

            var cts = new CancellationTokenSource();
            var evenTask = ComputeEven(cts.Token);

            Console.ReadLine();
            cts.Cancel();
            Console.WriteLine("canceled ComputeEven");

            Console.ReadLine();
        }

        public static Task<bool> Gerade(int x, CancellationToken ct)
        {
            return Task.Run(() =>
            {

                ct.ThrowIfCancellationRequested();
                if (x % 1000000 == 0)
                    return true;
                else
                    return false;
            }, ct);
        }

        public static async Task ComputeEven(CancellationToken ct)
        {
            for (var i = 1; i < int.MaxValue; i++)
            {
                ct.ThrowIfCancellationRequested();
                if (await Gerade(i, ct)) Console.WriteLine($"number: {i}");
            }
        }

    }


}

    

