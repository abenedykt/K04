using Pizza;

namespace PizzaAbstract
{
    public interface IPizzaFactory
    {
        IMenu Menu();
        IOrderCalculator OrderCalculator();
    }
}
