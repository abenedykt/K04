using System.Collections.Generic;

namespace TDD.Legacy
{
    public interface ITravel
    {
        IList<IExpense> Expenses { get; set; }
        IPerson Person { get; set; }
    }
}