using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.DrinkDecorators
{
    public class CoffeeDrinkDecorator : BaseDrinkDecorator
    {
        public CoffeeDrinkDecorator(IDrink drink) : base(drink)
        {
            if (base.Name == null)
            {
                base.Name = "Coffee";
            }
        }
    }
}
