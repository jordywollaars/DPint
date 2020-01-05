using KoffieMachineDomain.DrinkDecorators;
using System.Collections.Generic;

namespace KoffieMachineDomain.DrinkFactory
{
    public class WhippedcreamDrinkDecorator : BaseDrinkDecorator
    {
        public WhippedcreamDrinkDecorator(IDrink drink) : base(drink)
        {

        }

        public override double GetPrice()
        {
            return base.GetPrice() + 0.20;
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            log.Add($"Adding Whippedcream...");
        }
    }
}