using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.DrinkDecorators
{
    class WienerMelangeDrinkDecorator : CapuccinoDrinkDecorator
    {

        public WienerMelangeDrinkDecorator(IDrink drink) : base(drink)
        {
            base.Name = "Wiener Melange";
            DrinkStrength = Strength.Weak;
        }

        public override double GetPrice()
        {
            return base.GetPrice() * 2; //TODO: fix price to be baseprice * 2
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
        }
    }
}
