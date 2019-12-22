using System.Collections.Generic;

namespace KoffieMachineDomain
{
    public interface IDrink
    {
        string Name { get; set; }

        void LogDrinkMaking(ICollection<string> log);
        double GetPrice();
    }
}