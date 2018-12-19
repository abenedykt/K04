namespace Pizza
{
    public interface IOrderItem
    {
        string Name { get; }
        int Pieces { get; }
        string PizzaName { get; }
    }
}