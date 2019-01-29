using System;
using static Pizza.MyPizzaApp;

namespace Pizza
{
    internal class CommandAddToOrder : CommandBase<AddToOrderParam, string>
    {
        private readonly IOrdersRepository _orders;

        public CommandAddToOrder(IOrdersRepository orders)
        {
            _orders = orders;
        }

        public override string Execute(AddToOrderParam param)
        {

            _orders.Find(param.Value).Add(param.OrderItem);
            
            return "ok";
        }
    }

    internal class AddToOrderParam
    {
        public string Value { get; }
        public OrderItem OrderItem { get; }

        public AddToOrderParam(string value, OrderItem orderItem)
        {
            Value = value;
            OrderItem = orderItem;
        }
    }

}