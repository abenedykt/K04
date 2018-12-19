using Xunit;

namespace Pizza
{
    public class OrderItemTests
    {
        [Fact]
        public void OrderItem_pieces_must_be_greater_than_zero()
        {
            Assert.Throws<PiecesMustBeGreatherThanZeroException>(() => new OrderItem("Jan", 0, "whatever"));
        }
    }
}
