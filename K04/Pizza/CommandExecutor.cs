using System;
using System.Diagnostics;

namespace Pizza
{
    internal class CommandExecutor
    {
        internal T Execute<T>(CommandBase<T> command)
        {
            try
            {
                return command.Execute();
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
            }

            return default(T);
        }
    }
}