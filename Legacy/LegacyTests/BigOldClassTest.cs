using FluentAssert;
using NSubstitute;
using System.Collections.Generic;
using TDD.Legacy;
using Xunit;

namespace LegacyTests
{
    public class BigOldClassTest
    {
        [Fact]
        public void CanAcceptTravelExpenses_should_return_some_value()
        {
            var sut = new BigOldClass();

            var travel = NSubstitute.Substitute.For<ITravel>();
            travel.Expenses.Returns(new List<IExpense>()
            {
                new Expense()
                {
                    DateTime = "2008-02-01",
                    Description = "tak",
                    Transport = true,
                    Value = 100
                }
            });
            var result = sut.CanAcceptTravelExpenses(travel);
            result.ShouldBeTrue();


        }
    }
}
