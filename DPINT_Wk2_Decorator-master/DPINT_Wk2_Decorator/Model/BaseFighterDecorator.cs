using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk2_Decorator.Model
{
    public abstract class BaseFighterDecorator : IFighter
    {
        private IFighter _wrappee;

        public int Lives { get; set; }
        public int AttackValue { get; set; }
        public int DefenseValue { get; set; }

        public BaseFighterDecorator(IFighter fighter)
        {
            _wrappee = fighter;
        }

        public virtual Attack Attack()
        {
            throw new NotImplementedException();
        }

        public virtual void Defend(Attack attack)
        {
            throw new NotImplementedException();
        }
    }
}
