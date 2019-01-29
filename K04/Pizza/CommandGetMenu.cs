using Pizza.Abstract;

namespace Pizza
{
    public class CommandGetMenu : CommandBase<IMenu>
    {
        private readonly IPizzaFactory _factory;

        public CommandGetMenu(IPizzaFactory factory)
        {
            _factory = factory;
        }

        public override IMenu Execute()
        {
            return _factory.Menu();
        }
    }
}