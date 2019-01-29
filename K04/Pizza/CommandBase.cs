namespace Pizza
{
    public abstract class CommandBase<TResult>
    {

        public abstract TResult Execute();
    }
}