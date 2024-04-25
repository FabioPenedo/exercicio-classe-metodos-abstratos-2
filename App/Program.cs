using App.Entities;
using System;
using System.Globalization;

namespace App // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Taxpayer> list = [];

            Console.Write("Enter the number of taxpayers: ");
            int n = int.Parse(Console.ReadLine()!);

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Taxpayer #{i} data:");
                Console.Write("Individual or company (i/c)? ");
                char ch = char.Parse(Console.ReadLine()!);
                Console.Write("Name: ");
                string name = Console.ReadLine()!;
                Console.Write("Anual income: ");
                double anualIncome = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);

                if(ch == 'i')
                {
                    Console.Write("Health expenditures: ");
                    double healthExpenditures = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
                    list.Add(new Individual(name, anualIncome, healthExpenditures));
                }
                else
                {
                    Console.Write("Number of employees: ");
                    int employee = int.Parse(Console.ReadLine()!);
                    list.Add(new Company(name, anualIncome, employee));
                }
            }

            Console.WriteLine();
            Console.WriteLine("TAXES PAID:");

            double sum = 0.0;
            foreach (Taxpayer taxPayer in list)
            {
                Console.WriteLine($"{taxPayer.Name}: $ {taxPayer.Tax().ToString("F2", CultureInfo.InvariantCulture)}");
                sum += taxPayer.Tax();
            }

            Console.WriteLine();
            Console.WriteLine($"TOTAL TAXES: $ {sum.ToString("F2", CultureInfo.InvariantCulture)}");
        }
    }
}