namespace DPINT_Wk2_Decorator.Model.FighterDecorator
{
    public class MinionFighterDecorator : BaseFighterDecorator
    {
        public MinionFighterDecorator(IFighter fighter) : base(fighter)
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
