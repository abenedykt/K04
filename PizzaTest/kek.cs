using NSubstitute;
using Xunit;
using FluentAssertions;

namespace PizzaTest
{
    public class kek
    {
        
        [Fact]
        public void Substitute_example_with_other_object()
        {
            var x = Substitute.For<ISomeInterface>();

            x.Other.Returns((c) => new Other());

            var aaa = x.Other;
            var bbb = x.Other;

            aaa.GetHashCode().Should().NotBe(bbb.GetHashCode());
        }
    }
    internal class Other : IOtherInterface
    {

    }

    public interface ISomeInterface
    {
        IOtherInterface Other { get; }
    }

    public interface IOtherInterface
    {

    }
}
