using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drink.DrinkDecorators
{
    public abstract class BaseDrinkDecorator : IDrink
    {
        private IDrink _wrappee;

        public virtual string Name
        {
            get { return _wrappee.Name; }
            set { _wrappee.Name = value; }
        }

        public BaseDrinkDecorator(IDrink drink)
        {
            _wrappee = drink;
        }

        public virtual void LogDrinkMaking(ICollection<string> log)
        {
            _wrappee.LogDrinkMaking(log);
        }

        public virtual double GetPrice()
        {
            return _wrappee.GetPrice();
        }
    }
}
