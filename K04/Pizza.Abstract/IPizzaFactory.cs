namespace Pizza.Abstract
{
    public interface IPizzaFactory
    {
        IMenu Menu();
        IOrderCalculator OrderCalculator();
        IOrderSender Sender();
    }
}