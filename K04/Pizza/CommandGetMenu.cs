using Pizza.Abstract;

namespace Pizza
{
    public class CommandGetMenu : CommandBase<object, IMenu>
    {
        private readonly IPizzaFactory _factory;

        public CommandGetMenu(IPizzaFactory factory)
        {
            _factory = factory;
        }

        public override IMenu Execute(object param)
        {
            return _factory.Menu();
        }
    }
}