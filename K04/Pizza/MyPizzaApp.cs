﻿using Pizza.Abstract;
using System;

namespace Pizza
{
    public class MyPizzaApp : IMyPizzaApp
    {
        private readonly IPizzaFactory _factory;
        private readonly IOrdersRepository _orders;
        private CommandExecutor _executor;

        public MyPizzaApp(IPizzaFactory factory, IOrdersRepository ordersRepository)
        {
            _factory = factory;
            _orders = ordersRepository;
            _executor = new CommandExecutor();
        }

        public IMenu GetMenu()
        {
            return _executor.Execute(new CommandGetMenu(_factory), null);
        }

        public IClientOrder StartOrder()
        {
            return _executor.Execute(new CommandStartNewOrder(_orders), null);
        }

        public void AddToOrder(IClientOrder order, IMenuItem menuItem, int pieces)
        {
            _executor.Execute(new CommandAddToOrder(_orders), new AddToOrderParam(order.Value, new OrderItem("", pieces, menuItem.Name)));
        }
        public void SendOrder(IClientOrder clientOrder)
        {
            // todo to command

            var order = _orders.Find(clientOrder.Value);

            if (order.IsValid())
            {
                _factory.Sender().Send(order);
                _orders.Remove(clientOrder.Value);
            } else
            {
                throw new OrderIsNotValidException();
            }
        }

        internal class OrderIsNotValidException : Exception
        {

        }

        internal class ClientOrder : IClientOrder
        {
            public string Value { get; }

            public ClientOrder(string guid)
            {
                Value = guid;
            }
        }
    }

}
