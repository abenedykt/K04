using System.Collections.Generic;
using System.Linq;
using PizzaAbstract;

namespace Pizza
{
    public class Order : IOrder
    {
        List<IOrderItem> items;

        public Order()
        {
            items = new List<IOrderItem>();
        }

        public void Add(IOrderItem orderItem)
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
                sum += item.Pieces;
                if (hashMap.Keys.Contains(item.PizzaName))
                    hashMap[item.PizzaName] += item.Pieces;
                else hashMap[item.PizzaName] = item.Pieces;
            }

            bool temp1 = hashMap.All(n => n.Value % 4 == 0);
            bool temp2 = sum % 8 == 0;

            return items.Any() && temp1 && temp2;
        }
    }
}