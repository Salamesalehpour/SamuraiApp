using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Linq;

namespace ConsoleApp
{
    internal class Program
    {
        private static SamuraiContext context = new SamuraiContext();
        static void Main(string[] args)
        {
            context.Database.EnsureCreated();
            GetSamurais("Before Add...");

            AddSamurai("Salam");
            AddSamurai("Barin");

            GetSamurais("After Add...");

            Console.Write("Press any key...");
            Console.ReadKey();
        }

        private static void AddSamurai(string samuraiName)
        {
            var salamSamurai = new Samurai { Name = samuraiName };
            context.Samurais.Add(salamSamurai);
            context.SaveChanges();
        }

        private static void GetSamurais(string text)
        {
            var samurais = context.Samurais.ToList();

            Console.WriteLine($"{text}: Samurai count is {samurais.Count}");

            foreach (var samurai in samurais)
            {
                Console.WriteLine(samurai.Name);
            }
        }
    }
}
