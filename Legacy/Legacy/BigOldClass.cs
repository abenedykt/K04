using System;

namespace TDD.Legacy
{
    public class BigOldClass
    {
        public bool CanAcceptTravelExpenses(Travel travel)
        {
            if (travel.Person.IsManager)
            {
                var total = 0.0;

                foreach (var expense in travel.Expenses)
                {
                    total += expense.Value;
                }
                return total <= 5000;
            }
            else
            {
                if ((DateTime.Now.Subtract(travel.Person.Hired).TotalDays < 365))
                {
                    return false;
                } else
                {
                    var total = 0.0;
                    foreach (var expense in travel.Expenses)
                    {
                        if (!expense.Transport)
                        {
                            total += expense.Value;
                        }
                    }

                    return total <= 5000;
                }
            }
        }
    }
}
