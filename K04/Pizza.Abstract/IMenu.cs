namespace Pizza.Abstract
{
    public interface IMenu
    {
        IPrice PizzaPrice(string pizzaName);
    }
}