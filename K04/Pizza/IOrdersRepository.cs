using Pizza.Abstract;

namespace Pizza
{
    public interface IOrdersRepository
    {
        void Add(string value, IOrder order);
        IOrder Find(string value);
        void Remove(string value);
    }
}
