namespace Pizza
{
    internal class OrderItem
    {
        public OrderItem(string name, int pieces, string pizzaName)
        {
            Pieces = pieces;
            PizzaName = pizzaName;
        }

        public int Pieces { get; }
        public string PizzaName { get; }
    }
}
