using System;
using FluentAssertions;
using Xunit;

namespace Pizza.Tests
{
    public class OrderItemTests
    {
        [Fact]
        public void Constructor_GivenNegative_ThrowsException()
        {
            Action act = () => new OrderItem("whatever", -3, "w/e");

            act.Should().Throw<ArgumentException>();
        }
    }
}