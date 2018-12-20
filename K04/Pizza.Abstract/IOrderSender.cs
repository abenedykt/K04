namespace Pizza.Abstract
{
    public interface IOrderSender
    {
        void Send(IOrder order);
    }
}