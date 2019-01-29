using Pizza.Abstract;

namespace Pizza
{
    internal class CommandGetMenu : CommandBase<IMenu>
    {
        private readonly IPizzaFactory _factory;

        public CommandGetMenu(IPizzaFactory pizzaFactory)
        {
            _factory = pizzaFactory;
        }

        public override IMenu Execute()
        {
            return _factory.Menu();
        }
    }

    public abstract class CommandBase<TResult>
    {
        public abstract TResult Execute();
    }
}