using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities
{
    internal abstract class Taxpayer
    {
        public string Name { get; private set; } = string.Empty;
        public double AnualIncome { get; protected set; }

        public Taxpayer(string name, double anualIncome)
        {
            Name = name;
            AnualIncome = anualIncome;
        }
        public abstract double Tax();
    }
}
