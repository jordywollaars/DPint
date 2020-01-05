using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drink.DrinkDecorators
{
    public class CoffeeDrinkDecorator : BaseDrinkDecorator
    {
        public Strength DrinkStrength { get; set; }

        public CoffeeDrinkDecorator(IDrink drink, Strength drinkStrength) : base(drink)
        {
            if (base.Name == null)
            {
                base.Name = "Coffee";
            }
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            log.Add($"Setting coffee strength to {DrinkStrength}.");
            log.Add($"Filling with coffee");
        }
    }
}
