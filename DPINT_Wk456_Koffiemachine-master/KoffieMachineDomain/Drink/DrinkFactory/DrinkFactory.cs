﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoffieMachineDomain.Drink.DrinkDecorators;
using KoffieMachineDomain.Drink.DrinkDecorators.SpecialDrinkDecorators;
using KoffieMachineDomain.Drink.DrinkStrategies;
using KoffieMachineDomain.Drink.DrinkStrategies.DispenserAdapter.SpecialCoffee;
using KoffieMachineDomain.Drink.DrinkStrategies.DispenserAdapter.TeaBlendAndHotChoc;

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

        public DrinkFactory()
        {
            SetupDrinkStrategies();
        }

        public IDrink CreateDrink(string drinkName, IEnumerable<string> options)
        {
            IDrink drink = GetDrink(drinkName);

            if(drinkName == "Special")
            {
                options = ((SpecialCoffeeAdapter)drink).GetOptions(_specialCoffee).ToList();
            }

            if (drinkName == "Tea")
            {
                ((TeaAdapter)drink).SetTeaBlend(_teaBlend);
            }

            List<string> configurations = options.ToList();

            for (int i = 0; i < configurations.Count; i++)
            {
                switch (configurations[i])
                {
                    case "Sugar":
                        drink = new SugarDrinkDecorator(drink, _sugarAmount);
                        break;
                    case "Milk":
                        drink = new MilkDrinkDecorator(drink, _milkAmount);
                        break;
                    case "Whippedcream":
                        drink = new WhippedcreamDrinkDecorator(drink);
                        break;
                    case "Coffee":
                        drink = new CoffeeDrinkDecorator(drink, _drinkStrength);
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

        private IDrink GetDrink(string name)
        {
            if (!_drinks.Keys.Contains(name))
            {
                return null;
            }

            IDrink drink = _drinks[name];

            return drink;
        }

        private void SetupDrinkStrategies()
        {
            _drinks = new Dictionary<string, IDrink>();

            _drinks["Coffee"] = new Coffee(_drinkStrength);
            _drinks["Espresso"] = new Espresso();
            _drinks["Capuccino"] = new Capuccino();
            _drinks["Wiener Melange"] = new WienerMelange();
            _drinks["Café au Lait"] = new CafeAuLait();
            _drinks["Chocolate"] = new HotChocolateAdapter(false);
            _drinks["Chocolate Deluxe"] = new HotChocolateAdapter(true);
            _drinks["Tea"] = new TeaAdapter();
            _drinks["Special"] = new SpecialCoffeeAdapter();
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
