using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.DrinkDecorators
{
    public class StrengthDrinkDecorator : BaseDrinkDecorator
    {
        public Strength DrinkStrength { get; set; }

        public StrengthDrinkDecorator(IDrink drink, Strength drinkStrength) : base(drink)
        {
            DrinkStrength = drinkStrength;
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            log.Add($"Setting coffee strength to {DrinkStrength}.");
        }
    }
}
