using FluentAssertions;
using System;
using Xunit;

namespace Pizza
{
    public class OrderItemTests
    {
        [Fact]
        public void OrderItem_pieces_must_be_greater_than_zero()
        {
            Action x = () => new OrderItem("Jan", 0, "whatever");
            x.Should().Throw<PiecesMustBeGreatherThanZeroException>();
        }
    }
}
