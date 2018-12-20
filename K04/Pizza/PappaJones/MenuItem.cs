using Pizza.Abstract;

namespace Pizza.PappaJones
{
    internal class MenuItem : IMenuItem
    {
        public MenuItem(string name, double price)
        {
            Name = name;
            Price = new Price(price);
        }

        public string Name { get; }

        public IPrice Price { get; }
    }
}