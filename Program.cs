using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace bdc_Operatorok
{
    class Program
    {
        static List<Operatorok> oLista = new List<Operatorok>();

        static void Main(string[] args)
        {
            f01_beolvasas();
            f02();
            f03();
            f04();
            f05();
            f07();
            f08();
            Console.ReadKey();
        }

        private static void f08()
        {
            StreamWriter sw = new StreamWriter("eredmenyek.txt");
            foreach (var item in oLista)
            {
                sw.WriteLine($"{item.Elso} {item.Op} {item.Masodik} = {item.szamol()}");
            }
            sw.Close();
            Console.WriteLine("Az adatok kiírva!");
        }

        private static void f07()
        {
            string kif = "";
            do
            {
                Console.WriteLine("kérek egy kifejezést!");
                kif = Console.ReadLine();
                if (kif != "vége")
                {
                    Operatorok ujOp = new Operatorok(kif);
                    Console.WriteLine($"Eredmény: {ujOp.szamol()}");
                }
            } while (kif != "vége");
        }

        private static void f05()
        {
            Console.WriteLine("5. feladat");
            Dictionary<string, int> stat = new Dictionary<string, int>() {
                { "+", 0},
                { "-", 0},
                { "*", 0},
                { "/", 0},
                { "mod", 0},
                { "div", 0},
            };

            foreach (var item in oLista)
            {
                if (stat.ContainsKey(item.Op))
                {
                    stat[item.Op]++;
                }
            }

            foreach (var item in stat)
            {
                Console.WriteLine($"Művelet: {item.Key}: {item.Value} db");
            }
        }

        private static void f04()
        {
            Console.WriteLine("4. feladat");
            if (oLista.Any((x => x.Elso % 10 == 0)) && oLista.Any((x => x.Masodik % 10 == 0)))
            {
                Console.WriteLine("VAN ilyen kifejezés!");
            }
            else
            {
                Console.WriteLine("NINCS ilyen kifejezés!");
            }

            //hagyományos megoldással
            bool van = false;
            int index = 0;
            while (!van && index < oLista.Count)
            {
                if (oLista[index].Elso % 10 == 0 && oLista[index].Masodik % 10 == 0)
                {
                    van = true;
                    Console.WriteLine("Van ilyen kifejezés, az indexe: " + index);
                }
                index++;
            }
            if (!van)
            {
                Console.WriteLine("Nincs ilyen kifejezés!");
            }

        }

        private static void f03()
        {
            Console.WriteLine("3. feladat");
            int modDarab = oLista.Count(x=>x.Op == "mod");
            Console.WriteLine($"Maradékos osztás: {modDarab}");

            //másik megoldás
            int modDarab2 = 0;
            foreach (var item in oLista)
            {
                if (item.Op == "mod")
                {
                    modDarab2++;
                }
            }
            Console.WriteLine($"Maradékos osztás: {modDarab2} db");
        }

        private static void f02()
        {
            Console.WriteLine("2. feladat");
            Console.WriteLine($"Összesen ennyi művelet van: {oLista.Count}");
        }

        private static void f01_beolvasas()
        {
            string[] sorok = File.ReadAllLines("kifejezesek.txt", Encoding.UTF8);
            foreach (string sor in sorok)
            {
                Operatorok o = new Operatorok(sor);
                oLista.Add(o);
            }
            Console.WriteLine("A beolvasás rendben!");
        }
    }
}
