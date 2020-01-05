using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoffieMachineDomain.Drink.DrinkDecorators;
using KoffieMachineDomain.Drink.DrinkDecorators.SpecialDrinkDecorators;
using KoffieMachineDomain.Drink.DispenserAdapter.SpecialCoffee;
using KoffieMachineDomain.Drink.DispenserAdapter.TeaBlendAndHotChoc;

namespace KoffieMachineDomain.Drink.DrinkFactory
{
    public class DrinkFactory
    {
        private Strength _drinkStrength;
        private Amount _sugarAmount;
        private Amount _milkAmount;

        private string _teaBlend;
        private string _specialCoffee;

        private Dictionary<string, IDrink> _drinks;

        //public DrinkFactory()
        //{
        //    _drinks = new Dictionary<string, IDrink>();

        //    _drinks = new CoffeeDrinkDecorator(_drinkStrength);
        //}

        public IDrink CreateDrink(string drinkName, IEnumerable<string> options)
        {
            IDrink drink = new Drink();
            List<string> configurations = SetupConfiguarions(drinkName, options);

            bool creamMilk = false;

            for (int i = 0; i < configurations.Count; i++)
            {
                switch (configurations[i])
                {
                    case "Special":
                        drink = new SpecialCoffeeAdapter(_specialCoffee);
                        configurations = ((SpecialCoffeeAdapter)drink).GetOptions().ToList();
                        i--;
                        break;
                    case "Tea":
                        drink = new TeaAdapter(_teaBlend);
                        break;
                    case "Chocolate":
                        drink = new HotChocolateAdapter(false);
                        break;
                    case "Chocolate Deluxe":
                        drink = new HotChocolateAdapter(true);
                        break;
                    case "Coffee":
                        drink = new CoffeeDrinkDecorator(drink, _drinkStrength);
                        break;
                    case "Espresso":
                        drink = new EspressoDrinkDecorator(drink);
                        creamMilk = true;
                        drink = new MilkDrinkDecorator(drink, _milkAmount, creamMilk);
                        break;
                    case "Capuccino":
                        drink = new CapuccinoDrinkDecorator(drink);
                        creamMilk = true;
                        drink = new MilkDrinkDecorator(drink, _milkAmount, creamMilk);
                        break;
                    case "Wiener Melange":
                        drink = new WienerMelangeDrinkDecorator(drink);
                        creamMilk = true;
                        drink = new MilkDrinkDecorator(drink, _milkAmount, creamMilk);
                        break;
                    case "Café au Lait":
                        drink = new CafeAuLaitDrinkDecorator(drink);
                        break;
                    case "Sugar":
                        drink = new SugarDrinkDecorator(drink, _sugarAmount);
                        break;
                    case "Milk":
                        if (!creamMilk)
                        {
                            drink = new MilkDrinkDecorator(drink, _milkAmount, creamMilk);
                        }
                        break;
                    case "Whippedcream":
                        drink = new WhippedcreamDrinkDecorator(drink);
                        break;
                    case "Whiskey":
                        drink = new WiskeyDrinkDecorator(drink);
                        break;
                    case "Cointreau":
                        drink = new CointreauDrinkDecorator(drink);
                        break;
                    case "Amaretto":
                        drink = new AmarettoDrinkDecorator(drink);
                        break;
                    case "Cognac":
                        drink = new CognacDrinkDecorator(drink);
                        break;
                    default:
                        drink = new MissingIngrediëntDrinkDecorator(drink);
                        break;
                }
            }

            return drink;
        }

        private List<string> SetupConfiguarions(string drinkName, IEnumerable<string> options)
        {
            List<string> configurations = new List<string>();
            configurations.Add(drinkName);
            options.ToList().ForEach(x => configurations.Add(x));
            return configurations;
        }

        public void SetFactorySettings(Strength strength, Amount milk, Amount sugar, string teaBlend, string specialCoffee)
        {
            _drinkStrength = strength;
            _milkAmount = milk;
            _sugarAmount = sugar;
            _teaBlend = teaBlend;
            _specialCoffee = specialCoffee;
        }
    }
}
