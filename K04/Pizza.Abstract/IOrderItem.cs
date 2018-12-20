namespace Pizza.Abstract
{
    public interface IOrderItem
    {
        int Pieces { get; }
        string PizzaName { get; }
    }
}