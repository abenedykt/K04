namespace Pizza
{
    public class PappaJonesOrderCalculator : IOrderCalculator
    {
        private PappaJonesMenu pappaJonesMenu;
        public PappaJonesOrderCalculator(PappaJonesMenu pappaJonesMenu)
        {
            this.pappaJonesMenu = pappaJonesMenu;
        }
    }
}
