using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaAndChocoLibrary;

namespace KoffieMachineDomain.DispenserAdapter
{
    public class HotChocolateAdapter : IDrink
    {
        private HotChocolate _adaptee;

        public HotChocolateAdapter(bool isDeluxe)
        {
            _adaptee = new HotChocolate();

            if(isDeluxe)
            {
                _adaptee.MakeDeluxe();
            }

            Name = _adaptee.GetNameOfDrink();
        }

        public string Name { get; set; }

        public double GetPrice()
        {
            return _adaptee.Cost();
        }

        public void LogDrinkMaking(ICollection<string> log)
        {
            var buildSteps = _adaptee.GetBuildSteps().ToList();
            buildSteps.Remove(buildSteps.Last());

            buildSteps.ForEach(x => {
                log.Add(x);
            });
        }
    }
}
