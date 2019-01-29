using System;
using System.Diagnostics;

namespace Pizza
{
    internal class CommandExecutor<T>
    {
        internal T Execute(CommandBase<T> command)
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