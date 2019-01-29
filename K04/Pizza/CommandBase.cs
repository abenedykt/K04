namespace Pizza
{
    public abstract class CommandBase<TParam, TResult>
    {
        public abstract TResult Execute(TParam param);
    }
}