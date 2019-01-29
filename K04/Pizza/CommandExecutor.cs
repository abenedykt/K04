using System;
using System.Diagnostics;

namespace Pizza
{
    internal class CommandExecutor
    {
        internal TResult Execute<TResult>(CommandBase<TResult> command)
        {
            try
            {
                return command.Execute();
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
            }

            return default(TResult);
            
        }
    }
}
