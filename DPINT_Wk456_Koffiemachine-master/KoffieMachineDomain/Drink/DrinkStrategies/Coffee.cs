﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drink.DrinkStrategies
{
    public class Coffee : Drink
    {
        public Strength DrinkStrength { get; set; }

        public Coffee(Strength drinkStrength)
        {
            if (base.Name == null)
            {
                base.Name = "Coffee";
            }
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            log.Add($"Setting coffee strength to {DrinkStrength}.");
            log.Add($"Filling with coffee");
        }

        public override double GetPrice()
        {
            return base.GetPrice();
        }
    }
}
