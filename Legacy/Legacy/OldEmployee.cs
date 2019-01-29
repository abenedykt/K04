using System.Collections.Generic;
using System.Linq;

namespace TDD.Legacy
{
    internal class OldEmployee : ICostAcceptor
    {
        public bool CanAccept(IEnumerable<IExpense> expense)
        {
            return expense.Where(x => !x.Transport).Sum(x => x.Value) <=5000;
        }
    }
}