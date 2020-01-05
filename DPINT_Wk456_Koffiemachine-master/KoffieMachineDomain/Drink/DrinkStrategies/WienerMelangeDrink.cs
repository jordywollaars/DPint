using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drink.DrinkDecorators
{
    class WienerMelangeDrink : CapuccinoDrink
    {

        public WienerMelangeDrink() : base()
        {
            base.Name = "Wiener Melange";
            DrinkStrength = Strength.Weak;
        }

        public override double GetPrice()
        {
            return BaseDrinkPrice * 2;
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
        }
    }
}
