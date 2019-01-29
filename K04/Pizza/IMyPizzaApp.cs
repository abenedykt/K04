using Pizza.Abstract;

namespace Pizza
{
    public interface IMyPizzaApp
    {
        IMenu GetMenu();
        IClientOrder StartOrder();
        void AddToOrder(IClientOrder order, IMenuItem menuItem, int pieces);
        void SendOrder(IClientOrder clientOrder);
    }
}