using System.Collections.Generic;

namespace Pizza
{
    public interface IOrder
    {
        void Add(OrderItem orderItem);
        bool IsValid();
        IEnumerable<IOrderItem> Positions { get; }
    }
}