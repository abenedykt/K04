using Xunit;

namespace Pizza
{
    public class OrderItemTests
    {
        [Fact]
        public void When_pieces_is_lower_than_1_should_throw_exception()
        {
            Assert.Throws<PiecesMustBeGreatherThanZeroException>(() => new OrderItem("Jan", 0, "whatever"));
        }
    }
}
