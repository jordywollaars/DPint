namespace DPINT_Wk2_Decorator.Model.FighterDecorator
{
    public class PoisonFighterDecorator : BaseFighterDecorator
    {
        public int PoisonStrength { get; set; }

        public PoisonFighterDecorator(IFighter fighter) : base(fighter)
        {
            PoisonStrength = 10;
        }

        public override Attack Attack()
        {
            var attack = base.Attack();

            if (PoisonStrength > 0)
            {
                attack.Messages.Add("Poison weakening, current value: " + PoisonStrength);
                attack.Value += PoisonStrength;
                PoisonStrength -= 2;
            }
            else
            {
                attack.Messages.Add("Poison ran out.");
            }

            return attack;
        }

        public override void Defend(Attack attack)
        {
            base.Defend(attack);

            if (PoisonStrength > 0)
            {
                attack.Messages.Add("Poison weakening, current value: " + PoisonStrength);
                attack.Value += PoisonStrength;
                PoisonStrength -= 2;
            }
            else
            {
                attack.Messages.Add("Poison ran out.");
            }
        }
    }
}
