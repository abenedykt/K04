using System;
using System.Collections.Generic;
using System.Linq;

namespace TDD.Legacy
{
    public interface ICostAccepter
    {
        bool CanAccept(IEnumerable<IExpense> expenses);
    }

    public class ManagerExpenses : ICostAccepter
    {
        public bool CanAccept(IEnumerable<IExpense> expenses)
        {
            return expenses.Sum(x => x.Value) <= 5000;
        }
    }
    public class OldEmployee : ICostAccepter
    {
        public bool CanAccept(IEnumerable<IExpense> expenses)
        {
            return expenses.Where(NotTransportExpense).Sum(x => x.Value) <= 5000;
        }

        private bool NotTransportExpense(IExpense x)
        {
            return !x.Transport;
        }
    }

    public class NullableAccepter : ICostAccepter
    {
        public bool CanAccept(IEnumerable<IExpense> expenses)
        {
            return false;
        }
    }

    public class BigOldClass
    {
        private ExpensesFactory _factory = new ExpensesFactory();

        public bool CanAcceptTravelExpenses(ITravel travel)
        {
            var accepter = _factory.GetFor(travel.Person);
            return accepter.CanAccept(travel.Expenses);
        }
    }

    internal class ExpensesFactory
    {
        internal ICostAccepter GetFor(IPerson person)
        {
            if (person.IsManager)
            {
                return new ManagerExpenses();
            }

            if (DateTime.Now.Subtract(person.Hired).TotalDays >= 365)
            {
                return new OldEmployee();
            }

            return new NullableAccepter();
        }
    }
}
