using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drink.DrinkDecorators
{
    class MilkDrinkDecorator : BaseDrinkDecorator
    {
        public bool IsCreamed { get; set; }
        public Amount MilkAmount { get; set; }

        public MilkDrinkDecorator(IDrink drink, Amount milkAmount, bool isCreamed) : base(drink)
        {
            MilkAmount = milkAmount;
            IsCreamed = isCreamed;
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);

            if (!IsCreamed)
            {
                log.Add($"Setting milk amount to {MilkAmount}.");
            }

            if (IsCreamed)
            {
                log.Add("Creaming milk...");
            }

            log.Add($"Adding milk to {base.Name}...");
        }

        public override double GetPrice()
        {
            return base.GetPrice() + 0.15;
        }
    }
}
