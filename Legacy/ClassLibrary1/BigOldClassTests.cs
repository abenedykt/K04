using FluentAssertions;
using NSubstitute;
using System;
using Xunit;

namespace TDD.Legacy
{
    public class BigOldClassTests
    {
        [Fact]
        public void When_person_is_manager_and_expenses_below_5000_should_accept()
        {
            var sut = new BigOldClass();

            var travel = Substitute.For<ITravel>();
            travel.Person.IsManager.Returns(true);
            travel.Expenses.Returns(new[]{
                new Expense
                {
                    Value = 1000
                },
                new Expense
                {
                    Value = 2000
                }
            });
            var result = sut.CanAcceptTravelExpenses(travel);

            result.Should().BeTrue();
        }

        [Fact]
        public void When_person_is_manager_and_expenses_equals_5000_should_accept()
        {
            var sut = new BigOldClass();

            var travel = Substitute.For<ITravel>();
            travel.Person.IsManager.Returns(true);
            travel.Expenses.Returns(new[]{
                new Expense
                {
                    Value = 3000
                },
                new Expense
                {
                    Value = 2000
                }
            });
            var result = sut.CanAcceptTravelExpenses(travel);

            result.Should().BeTrue();
        }

        [Fact]
        public void When_person_is_manager_and_expenses_above_5000_should_not_accept()
        {
            var sut = new BigOldClass();

            var travel = Substitute.For<ITravel>();
            travel.Person.IsManager.Returns(true);
            travel.Expenses.Returns(new[]{
                new Expense
                {
                    Value = 5000
                },
                new Expense
                {
                    Value = 2000
                }
            });
            var result = sut.CanAcceptTravelExpenses(travel);

            result.Should().BeFalse();
        }

        [Fact]
        public void When_person_is_not_manager_and_works_less_than_365_days_should_not_accept()
        {
            var sut = new BigOldClass();

            var travel = Substitute.For<ITravel>();
            travel.Person.IsManager.Returns(false);
            travel.Person.Hired.Returns(DateTime.Now.AddDays(-100));
            
            var result = sut.CanAcceptTravelExpenses(travel);

            result.Should().BeFalse();
        }

        [Fact]
        public void When_person_is_not_manager_and_works_than_365_days_and_has_trave_expenses_below_5000_should_accept()
        {
            var sut = new BigOldClass();

            var travel = Substitute.For<ITravel>();
            travel.Person.IsManager.Returns(false);
            travel.Person.Hired.Returns(DateTime.Now.AddDays(-365));
            travel.Expenses.Returns(new[]{
                new Expense
                {
                    Value = 1000
                }
            });
            var result = sut.CanAcceptTravelExpenses(travel);

            result.Should().BeTrue();
        }

        [Fact]
        public void When_person_is_not_manager_and_works_more_than_365_days_and_has_trave_expenses_below_5000_should_accept()
        {
            var sut = new BigOldClass();

            var travel = Substitute.For<ITravel>();
            travel.Person.IsManager.Returns(false);
            travel.Person.Hired.Returns(DateTime.Now.AddDays(-366));
            travel.Expenses.Returns(new[]{
                new Expense
                {
                    Value = 1000
                }
            });
            var result = sut.CanAcceptTravelExpenses(travel);

            result.Should().BeTrue();
        }

        [Fact]
        public void When_person_is_not_manager_and_works_than_365_days_and_has_trave_expenses_above_5000_should_accept()
        {
            var sut = new BigOldClass();

            var travel = Substitute.For<ITravel>();
            travel.Person.IsManager.Returns(false);
            travel.Person.Hired.Returns(DateTime.Now.AddDays(-365));
            travel.Expenses.Returns(new[]{
                new Expense
                {
                    Value = 6000
                }
            });
            var result = sut.CanAcceptTravelExpenses(travel);

            result.Should().BeFalse();
        }

        [Fact]
        public void When_person_is_not_manager_and_works_more_than_365_days_and_has_trave_expenses_above_5000_should_accept()
        {
            var sut = new BigOldClass();

            var travel = Substitute.For<ITravel>();
            travel.Person.IsManager.Returns(false);
            travel.Person.Hired.Returns(DateTime.Now.AddDays(-366));
            travel.Expenses.Returns(new[]{
                new Expense
                {
                    Value = 6000
                }
            });
            var result = sut.CanAcceptTravelExpenses(travel);

            result.Should().BeFalse();
        }

        [Fact]
        public void When_person_is_not_manager_and_works_more_than_365_days_and_has_travel_expenses_above_5000_should_accept()
        {
            var sut = new BigOldClass();

            var travel = Substitute.For<ITravel>();
            travel.Person.IsManager.Returns(false);
            travel.Person.Hired.Returns(DateTime.Now.AddDays(-366));
            travel.Expenses.Returns(new[]{
                new Expense
                {
                    Value = 6000,
                    Transport = true
                }
            });
            var result = sut.CanAcceptTravelExpenses(travel);

            result.Should().BeTrue();
        }
    }
}
