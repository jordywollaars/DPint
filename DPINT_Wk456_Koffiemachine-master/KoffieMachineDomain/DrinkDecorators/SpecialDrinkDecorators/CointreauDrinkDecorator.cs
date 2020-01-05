using KoffieMachineDomain.DrinkDecorators;
using System.Collections.Generic;

namespace KoffieMachineDomain.DrinkDecorators
{
    public class CointreauDrinkDecorator : BaseDrinkDecorator
    {
        public CointreauDrinkDecorator(IDrink drink) : base(drink)
        {
        }

        public override double GetPrice()
        {
            return base.GetPrice() + 1.50;
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            log.Add($"Filling bottom with Cointreau...");
        }
    }
}