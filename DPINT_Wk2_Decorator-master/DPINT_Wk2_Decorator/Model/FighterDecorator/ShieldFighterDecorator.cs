namespace DPINT_Wk2_Decorator.Model.FighterDecorator
{
    public class ShieldFighterDecorator : BaseFighterDecorator
    {
        public ShieldFighterDecorator(IFighter fighter) : base(fighter)
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
