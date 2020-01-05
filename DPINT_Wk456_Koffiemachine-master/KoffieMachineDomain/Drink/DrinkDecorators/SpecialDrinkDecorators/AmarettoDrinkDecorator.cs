using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drink.DrinkDecorators.SpecialDrinkDecorators
{
    public class AmarettoDrinkDecorator : BaseDrinkDecorator
    {
        public AmarettoDrinkDecorator(IDrink drink) : base(drink)
        {

        }

        public override double GetPrice()
        {
            return base.GetPrice() + 2;
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            log.Add($"Filling bottom with Amaretto...");
        }
    }
}
