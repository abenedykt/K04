using System;
using System.Collections.Generic;
using Pizza;
using PizzaAbstract;

namespace PizzaApp
{
    public class MyPizzaApp
    {
        private IPizzaFactory factory;
        private IDictionary<Guid, IOrder> orders;
        public MyPizzaApp()
        {
            factory = new PappaJonesPizzaFactory();
            orders = new Dictionary<Guid, IOrder>();
        }

        public IMenu GetMenu()
        {
            return factory.Menu();
        }

        public IClientOrder StartOrder()
        {
            var clientOrder = new ClientOrder(Guid.NewGuid());
            orders.Add(clientOrder.Value, new Order());

            return clientOrder;
        }

        public void AddToOrder(IClientOrder order, IMenuItem menuItem, int pieces)
        {
            orders[order.Value].Add(new OrderItem("", pieces, menuItem.Name));
        }

        public void SendOrder(IClientOrder order)
        {
            var orderClient = orders[order.Value];

            if (orderClient.isValid())
            {

            }
            else
            {
                throw new ArgumentException();
            }
        }

    }

    internal class ClientOrder : IClientOrder, IOrder
    {
        public ClientOrder(Guid newGuid)
        {

        }

        public Guid Value { get; set; }
        public void Add(IOrderItem orderItem)
        {
            throw new NotImplementedException();
        }

        public bool isValid()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IOrderItem> Positions { get; }
    }

    public interface IClientOrder
    {
        Guid Value { get; set; }
    }
}
