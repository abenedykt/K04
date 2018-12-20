using PizzaAbstract;

namespace Pizza
{
    public class MenuItem : IMenuItem
    {
        public int Price { get; set; }
        public string Name { get; set; }
    }
}