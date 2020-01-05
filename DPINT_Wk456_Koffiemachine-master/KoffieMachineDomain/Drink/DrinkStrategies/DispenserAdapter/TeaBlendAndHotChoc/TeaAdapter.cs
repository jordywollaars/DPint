using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaAndChocoLibrary;

namespace KoffieMachineDomain.Drink.DispenserAdapter.TeaBlendAndHotChoc
{
    public class TeaAdapter : Tea, IDrink
    {
        public static IEnumerable<string> TeaBlends { get { return new TeaBlendRepository().BlendNames; } }

        private TeaBlendRepository _teaBlendRepository;

        public TeaAdapter()
        {

        }

        public string Name { get; set; }

        public double GetPrice()
        {
            return Price;
        }

        public void LogDrinkMaking(ICollection<string> log)
        {
            log.Add($"Making {Name}...");
            log.Add($"Heating up...");
        }

        public void SetTeaBlend(string teaBlend)
        {
            _teaBlendRepository = new TeaBlendRepository();
            this.Blend = _teaBlendRepository.GetTeaBlend(teaBlend);
            Name = Blend.Name;
        }
    }
}
