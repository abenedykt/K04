using System;
using System.Collections.Generic;
using System.Linq;

namespace Pizza
{
    public interface IOrder
    {
        void Add(OrderItem orderItem);
        bool isVaild();
        IEnumerable<IOrderItem> Positions { get; }
    }

    public class Order : IOrder
    {
        List<OrderItem> items;

        public Order()
        {
            items = new List<OrderItem>();
        }

        public void Add(OrderItem orderItem)
        {
            items.Add(orderItem);
        }

        public IEnumerable<IOrderItem> Positions { get; }

        public bool isVaild()
        {
            int sum = 0;
            Dictionary<string, int> hashMap = new Dictionary<string, int>();
            foreach (var item in items)
            {
                sum += item.howMany;
                if (hashMap.Keys.Contains(item.which))
                    hashMap[item.which] += item.howMany;
                else hashMap[item.which] = item.howMany;
            }

            bool temp1 = hashMap.All(n => n.Value % 4 == 0);
            bool temp2 = sum % 8 == 0;

            return items.Any() && temp1 && temp2;
        }
    }
}