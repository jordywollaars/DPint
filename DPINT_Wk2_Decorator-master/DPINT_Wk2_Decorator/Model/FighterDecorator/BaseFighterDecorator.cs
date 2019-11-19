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

        public int Lives
        {
            get { return _wrappee.Lives; }
            set { _wrappee.Lives = value; }
        }
        public int AttackValue
        {
            get { return _wrappee.AttackValue; }
            set { _wrappee.AttackValue = value; }
        }
        public int DefenseValue
        {
            get { return _wrappee.DefenseValue; }
            set { _wrappee.DefenseValue = value; }
        }

        public BaseFighterDecorator(IFighter fighter)
        {
            _wrappee = fighter;
        }

        public virtual Attack Attack()
        {
            return _wrappee.Attack();
        }

        public virtual void Defend(Attack attack)
        {
            _wrappee.Defend(attack);
        }
    }
}
