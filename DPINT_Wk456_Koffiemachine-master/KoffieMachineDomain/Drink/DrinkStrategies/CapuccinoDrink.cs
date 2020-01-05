using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drink.DrinkDecorators
{
    class CapuccinoDrink : Drink
    {
        public Strength DrinkStrength { get; set; }

        public CapuccinoDrink() : base()
        {
            base.Name = "Capuccino";
            DrinkStrength = Strength.Normal;
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            log.Add($"Setting coffee strength to {DrinkStrength}");
            log.Add("Filling with coffee...");

            log.Add("Creaming milk...");
            log.Add("Adding milk to coffee...");
        }

        public override double GetPrice()
        {
            return base.GetPrice() + 0.8;
        }
    }
}
