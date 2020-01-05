using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drink.DrinkDecorators
{
    public class SugarDrinkDecorator : BaseDrinkDecorator
    {
        public Amount SugarAmount { get; set; }

        public SugarDrinkDecorator(IDrink drink, Amount sugarAmount) : base(drink)
        {
            SugarAmount = sugarAmount;
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);

            log.Add($"Setting sugar amount to {SugarAmount}.");
            log.Add($"Adding sugar to {base.Name}...");
        }

        public override double GetPrice()
        {
            return base.GetPrice() + 0.1;
        }
    }
}
