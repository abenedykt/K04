using System;
using System.Diagnostics;

namespace Pizza
{
    internal class CommandExecutor
    {
        internal TResult Execute<TParam, TResult>(CommandBase<TParam, TResult> command, TParam param)
        {
            try
            {
                return command.Execute(param);
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
            }

            return default(TResult);
            
        }
    }
}
