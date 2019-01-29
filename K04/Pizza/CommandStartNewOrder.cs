using System;
using Pizza.Abstract;

namespace Pizza
{
    internal class CommandStartNewOrder : CommandBase<IClientOrder>
    {
        private readonly IOrdersRepository _ordersRepository;

        public CommandStartNewOrder(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public override IClientOrder Execute()
        {
            var clientOrder = new MyPizzaApp.ClientOrder(Guid.NewGuid().ToString()); ;
            _ordersRepository.Add(clientOrder.Value, new Order());

            return clientOrder;
        }
    }
}