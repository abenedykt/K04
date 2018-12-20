
using System.Collections.Generic;

namespace PizzaAbstract
{
    public interface IOrder
    {
        void Add(IOrderItem orderItem);
        bool isValid();
        IEnumerable<IOrderItem> Positions { get; }
    }
}
