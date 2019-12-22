using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoffieMachineDomain;
using KoffieMachineDomain.DrinkDecorators;

namespace KoffieMachineDomain.DrinkFactory
{
    public class DrinkFactory
    {
        private Strength _drinkStrength;
        private Amount _sugarAmount;
        private Amount _milkAmount;

        public IDrink CreateDrink(string drinkName, IEnumerable<string> options)
        {
            IDrink drink = new Drink();

            switch (drinkName)
            {
                case "Coffee":
                    drink = new CoffeeDrinkDecorator(drink);
                    drink = new StrengthDrinkDecorator(drink, _drinkStrength);
                    break;
                case "Espresso":
                    drink = new EspressoDrinkDecorator(drink);
                    break;
                case "Capuccino":
                    drink = new CapuccinoDrinkDecorator(drink);
                    break;
                case "Wiener Melange":
                    drink = new WienerMelangeDrinkDecorator(drink);
                    drink = new StrengthDrinkDecorator(drink, Strength.Weak);
                    break;
                case "Café au Lait":
                    drink = new CafeAuLaitDrinkDecorator(drink);
                    break;
                default:
                    return drink;
            }

            foreach (string option in options)
            {
                switch (option)
                {
                    case "Sugar":
                        drink = new SugarDrinkDecorator(drink, _sugarAmount);
                        break;

                    case "Milk":
                        drink = new MilkDrinkDecorator(drink, _milkAmount);
                        break;
                }
            }

            return drink;
        }

        public void SetFactorySettings(Strength strength, Amount milk, Amount sugar)
        {
            _drinkStrength = strength;
            _milkAmount = milk;
            _sugarAmount = sugar;
        }
    }
}
