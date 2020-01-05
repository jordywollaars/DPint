using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drink.DrinkStrategies
{
    class CafeAuLait : Drink
    {
        public CafeAuLait() : base()
        {
            base.Name = "Café au Lait";
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            log.Add("Filling half with coffee...");
            log.Add("Filling other half with milk...");
        }

        public override double GetPrice()
        {
            return base.GetPrice() + 0.5;
        }
    }
}
