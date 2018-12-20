namespace Pizza.Abstract
{
    public interface IOrderCalculator
    {
        IPrice Calculate(IOrder order);
    }
}