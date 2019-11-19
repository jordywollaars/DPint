using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk2_Decorator.Model.FighterDecorator
{
    public class StrengthenFighterDecorator : BaseFighterDecorator
    {
        public StrengthenFighterDecorator(IFighter fighter) : base(fighter)
        {
            AttackValue = (int)(AttackValue * 1.1);
            DefenseValue = (int)(DefenseValue * 1.1);
        }

        public override Attack Attack()
        {
            var attack = base.Attack();

            return attack;
        }

        public override void Defend(Attack attack)
        {
            base.Defend(attack);
        }
    }
}
