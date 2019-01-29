using Pizza.Abstract;
using System;

namespace Pizza
{
    internal class CommandStartNewOrder : CommandBase<IClientOrder>
    {
        private IOrdersRepository _orders;

        public CommandStartNewOrder(IOrdersRepository orders)
        {
            _orders = orders;
        }

        public override IClientOrder Execute()
        {
            var clientOrder = new MyPizzaApp.ClientOrder(Guid.NewGuid().ToString()); ;
            _orders.Add(clientOrder.Value, new Order());

            return clientOrder;
        }
    }
}