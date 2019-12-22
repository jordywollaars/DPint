using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.DrinkDecorators
{
    class EspressoDrinkDecorator : BaseDrinkDecorator
    {
        public EspressoDrinkDecorator(IDrink drink) : base(drink)
        {
            base.Name = "Espresso";
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            log.Add($"Setting coffee strength to {Strength.Strong}.");
            log.Add($"Setting coffee amount to {Amount.Few}.");
            log.Add("Filling with coffee...");

            log.Add("Creaming milk...");
            log.Add("Adding milk to coffee...");
        }

        public override double GetPrice()
        {
            return base.GetPrice() + 0.7;
        }
    }
}
