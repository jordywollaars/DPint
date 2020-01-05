using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drink.DrinkDecorators
{
    class MissingIngrediëntDrinkDecorator : CapuccinoDrinkDecorator
    {

        public MissingIngrediëntDrinkDecorator(IDrink drink) : base(drink)
        {
        }

        public override double GetPrice()
        {
            return base.GetPrice();
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            log.Add($"Missing ingrediënt...");
        }
    }
}
