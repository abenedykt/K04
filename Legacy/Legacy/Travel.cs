using System.Collections.Generic;

namespace TDD.Legacy
{
    public class Travel : ITravel
    {
        public IPerson Person { get; set; }
        public IList<IExpense> Expenses { get; set; }
    }
}