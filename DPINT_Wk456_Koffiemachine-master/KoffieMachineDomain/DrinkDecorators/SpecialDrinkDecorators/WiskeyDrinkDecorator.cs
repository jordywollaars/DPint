using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.DrinkDecorators
{
    public class WiskeyDrinkDecorator : BaseDrinkDecorator
    {
        public WiskeyDrinkDecorator(IDrink drink) : base(drink)
        {

        }

        public override double GetPrice()
        {
            return base.GetPrice() + 2;
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            log.Add($"Filling bottom with Whiskey...");
        }
    }
}
