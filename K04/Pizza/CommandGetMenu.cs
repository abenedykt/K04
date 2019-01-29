using Pizza.Abstract;

namespace Pizza
{
    public class CommandGetMenu : CommandBase
    {
        private readonly IPizzaFactory _factory;

        public CommandGetMenu(IPizzaFactory factory)
        {
            _factory = factory;
        }

        public override object Execute()
        {
            return _factory.Menu();
        }
    }

    public abstract class CommandBase
    {

        public abstract object Execute();
    }
}