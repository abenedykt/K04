using Pizza.Abstract;

namespace Pizza
{
    public interface IMyPizzaApp
    {
        void AddToOrder(IClientOrder order, IMenuItem menuItem, int pieces);
        IMenu GetMenu();
        void SendOrder(IClientOrder clientOrder);
        IClientOrder StartOrder();
    }
}