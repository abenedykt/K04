using System.Collections.Generic;

namespace Pizza.Abstract
{
    public interface IOrder
    {
        void Add(IOrderItem orderItem);
        bool IsValid();
        IEnumerable<IOrderItem> Positions { get; }
    }
}