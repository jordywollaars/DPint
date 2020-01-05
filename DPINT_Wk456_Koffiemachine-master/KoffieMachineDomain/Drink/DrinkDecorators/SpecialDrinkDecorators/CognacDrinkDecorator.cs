using System.Collections.Generic;

namespace KoffieMachineDomain.Drink.DrinkDecorators.SpecialDrinkDecorators
{
    public class CognacDrinkDecorator : BaseDrinkDecorator
    {
        public CognacDrinkDecorator(IDrink drink) : base(drink)
        {
        }

        public override double GetPrice()
        {
            return base.GetPrice() + 1.50;
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            log.Add($"Filling bottom with Cognac...");
        }
    }
}