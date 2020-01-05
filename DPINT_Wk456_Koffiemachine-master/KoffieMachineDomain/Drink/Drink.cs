using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drink
{
    public class Drink : IDrink
    {
        public static readonly double SugarPrice = 0.1;
        public static readonly double MilkPrice = 0.15;

        protected const double BaseDrinkPrice = 1.0;
        
        public string Name { get; set; }

        public Drink()
        {

        }

        public virtual void LogDrinkMaking(ICollection<string> log)
        {
            log.Add($"Making {Name}...");
            log.Add($"Heating up...");
        }

        public virtual double GetPrice()
        {
            return BaseDrinkPrice;
        }
    }
}
