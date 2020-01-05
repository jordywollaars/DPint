using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drink.DispenserAdapter.SpecialCoffee
{
    public class SpecialCoffeeAdapter : SpecialCoffeeJSONHandler, IDrink
    {
        protected const double BaseDrinkPrice = 1.0;

        public string Name { get; set; }

        public SpecialCoffeeAdapter(string coffeeName) : base()
        {
            Name = coffeeName;
        }

        public virtual double GetPrice()
        {
            return BaseDrinkPrice;
        }

        public virtual void LogDrinkMaking(ICollection<string> log)
        {
            log.Add($"Making {Name}...");
            log.Add($"Heating up...");
        }

        public ICollection<string> GetOptions()
        {
            return base.SpecialCoffees[Name];
        }
    }
}
