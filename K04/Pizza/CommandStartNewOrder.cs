using Pizza.Abstract;
using System;
using static Pizza.MyPizzaApp;

namespace Pizza
{
    internal class CommandStartNewOrder : CommandBase<object, IClientOrder>
    {
        private IOrdersRepository _orders;

        public CommandStartNewOrder(IOrdersRepository orders)
        {
            _orders = orders;
        }

        public override IClientOrder Execute(object param)
        {
            var clientOrder = new ClientOrder(Guid.NewGuid().ToString()); ;
            _orders.Add(clientOrder.Value, new Order());

            return clientOrder;
        }
    }
}