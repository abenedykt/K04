namespace Pizza.Abstract
{
    public interface IMenuItem
    {
        string Name { get; }
        IPrice Price { get; }
    }
}