using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk2_Decorator.Model.FighterDecorator
{
    public class DoubleHandedFighterDecorator : BaseFighterDecorator
    {
        public DoubleHandedFighterDecorator(IFighter fighter) : base(fighter)
        {

        }

        public override Attack Attack()
        {
            return base.Attack();
        }

        public override void Defend(Attack attack)
        {
            base.Defend(attack);
        }
    }
}
