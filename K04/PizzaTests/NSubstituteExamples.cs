using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Pizza
{
    public class NSubstituteExamples
    {
        [Fact]
        public void Substitue_example_with_same()
        {
            var x = Substitute.For<ISomeInterface>();

            x.Other.Returns(new Other());

            var aaa = x.Other;
            var bbb = x.Other;

            aaa.GetHashCode().Should().Be(bbb.GetHashCode());
        }

        [Fact]
        public void Substitue_example_with_other_objects()
        {
            var x = Substitute.For<ISomeInterface>();

            x.Other.Returns((c) => new Other());

            var aaa = x.Other;
            var bbb = x.Other;

            aaa.GetHashCode().Should().NotBe(bbb.GetHashCode());
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
}
