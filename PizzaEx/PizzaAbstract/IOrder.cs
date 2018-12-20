using System.Collections.Generic;

namespace PizzaAbstract
{
    public interface IOrder
    {
        void Add(IOrderItem orderItem);
        bool isVaild();
        IEnumerable<IOrderItem> Positions { get; }
    }
}
