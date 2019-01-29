using FluentAssert;
using NSubstitute;
using System;
using System.Collections.Generic;
using TDD.Legacy;
using Xunit;

namespace LegacyTests
{
    public class BigOldClassTest
    {
        private ITravel _travel;
        private BigOldClass _sut;

        public BigOldClassTest()
        {
            _travel = Substitute.For<ITravel>();
            _sut = new BigOldClass();
        }

        [Fact]
        public void When_person_is_manager_returns_true_and_expenses_below_5000_return_true()
        {
            _travel.Person.IsManager.Returns(true);
            ExampleExpenses(100);
            var result = _sut.CanAcceptTravelExpenses(_travel);
            result.ShouldBeTrue();
        }

        private void ExampleExpenses(int expenses)
        {
            var exp = expenses / 2;
            _travel.Expenses.Returns(new List<IExpense>()
            {
                new Expense()
                {
                    DateTime = "2008-02-01",
                    Description = "tak",
                    Transport = true,
                    Value = exp
                },
                new Expense()
                {
                    DateTime = "2008-02-01",
                    Description = "tak",
                    Transport = false,
                    Value = exp
                }
            });
        }

        [Fact]
        public void When_person_is_manager_returns_true_and_expenses_over_5000_returns_false()
        {
            _travel.Person.IsManager.Returns(true);
            ExampleExpenses(6000);
            var result = _sut.CanAcceptTravelExpenses(_travel);
            result.ShouldBeFalse();
        }

        [Fact]
        public void When_person_is_manager_returns_false_and_person_is_hired_less_than_364_days_returns_false()
        {
            _travel.Person.IsManager.Returns(false);
            _travel.Person.Hired.Returns(DateTime.Now.AddDays(-364));
            var result = _sut.CanAcceptTravelExpenses(_travel);
            result.ShouldBeFalse();
        }

        [Fact]
        public void When_person_is_manager_returns_false_and_person_is_hired_more_than_364_days_and_total_below_5001_returns_true()
        {
            _travel.Person.IsManager.Returns(false);
            _travel.Person.Hired.Returns(DateTime.Now.AddDays(-400));
            ExampleExpenses(100);
            var result = _sut.CanAcceptTravelExpenses(_travel);
            result.ShouldBeTrue();
        }

        [Fact]
        public void When_person_is_manager_returns_false_and_person_is_hired_more_than_364_days_and_total_greater_than_5000_returns_false()
        {
            _travel.Person.IsManager.Returns(false);
            _travel.Person.Hired.Returns(DateTime.Now.AddDays(-400));
            ExampleExpenses(100);
            var result = _sut.CanAcceptTravelExpenses(_travel);
            result.ShouldBeTrue();
        }
    }
}
