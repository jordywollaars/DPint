using System;

namespace DPINT_Wk2_Decorator.Model.FighterDecorator
{
    public class ShieldFighterDecorator : BaseFighterDecorator
    {
        public int ShieldDefends { get; set; }

        public ShieldFighterDecorator(IFighter fighter) : base(fighter)
        {
            ShieldDefends = 3;
        }

        public override Attack Attack()
        {
            return base.Attack();
        }

        public override void Defend(Attack attack)
        {
            if (ShieldDefends > 0)
            {
                attack.Messages.Add("Shield protected, attack value = 0");
                attack.Value = 0;
                ShieldDefends--;
            }
            else
            {
                base.Defend(attack);
            }
        }
    }
}
