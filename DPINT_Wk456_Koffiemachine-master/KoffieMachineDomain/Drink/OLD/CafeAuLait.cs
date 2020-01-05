﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drink.OLD
{
    public class CafeAuLait : Drink
    {
        public string Name => "Café au Lait";

        public override double GetPrice()
        {
            return BaseDrinkPrice + 0.5;
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            log.Add("Filling half with coffee...");
            log.Add("Filling other half with milk...");
            log.Add($"Finished making {Name}");
        }
    }
}