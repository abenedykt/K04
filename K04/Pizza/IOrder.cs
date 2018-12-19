using System.Collections.Generic;

namespace Pizza
{
    internal interface IOrder
    {
        void Add(OrderItem orderItem);
        List<OrderItem> Positions { get; }
        bool IsValid();
    }
}