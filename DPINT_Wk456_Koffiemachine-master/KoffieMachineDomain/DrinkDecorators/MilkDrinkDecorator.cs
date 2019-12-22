using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.DrinkDecorators
{
    class MilkDrinkDecorator : BaseDrinkDecorator
    {
        public Amount MilkAmount { get; set; }

        public MilkDrinkDecorator(IDrink drink, Amount milkAmount) : base(drink)
        {
            MilkAmount = milkAmount;
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);

            log.Add($"Setting milk amount to {MilkAmount}.");
            log.Add("Adding milk...");
        }

        public override double GetPrice()
        {
            return base.GetPrice() + 0.15;
        }
    }
}
