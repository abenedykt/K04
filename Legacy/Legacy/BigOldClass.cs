using System;
using System.Collections.Generic;
using System.Linq;

namespace TDD.Legacy
{
    public class BigOldClass
    {


        public bool CanAcceptTravelExpenses(ITravel travel)
        {
            if (travel.Person.IsManager)
            {
                return new ManagerExpenses().CanAccept(travel.Expenses);
            }
            else
            {
                if (DateTime.Now.Subtract(travel.Person.Hired).TotalDays >= 365)
                {
                    return new OldEmployee().CanAccept(travel.Expenses);
                }

                return new NewEmployee().CanAccept(travel.Expenses);
            }
        }

        private static bool CanAcceptManagerExpenses(ITravel travel)
        {
            var total = 0.0;

            foreach (var expense in travel.Expenses)
            {
                total += expense.Value;
            }
            return total <= 5000;
        }
    }

    public class ExpensesFactory
    {
        internal ICostAcceptor GetFor(IPerson person)
        {
            if (person.IsManager)
            {
                return new ManagerExpenses();;
            }

            if (DateTime.Now.Subtract(person.Hired).TotalDays >= 365)
            {
                return new OldEmployee();
            }
            return new NewEmployee();
        }
    }


    internal class NewEmployee : ICostAcceptor
    {
        public bool CanAccept(IEnumerable<IExpense> expense)
        {
            throw new NotImplementedException();
        }
    }

    public interface ICostAcceptor
    {
        bool CanAccept(IEnumerable<IExpense> expense);
    }

    public class ManagerExpenses : ICostAcceptor
    {
        public bool CanAccept(IEnumerable<IExpense> expense)
        {
            return expense.Sum(x => x.Value) <= 5000;
        }
    }

    public class EmployeesExpenses : ICostAcceptor
    {
        public bool CanAccept(IEnumerable<IExpense> expense)
        {
            return false;
        }
    }
}
