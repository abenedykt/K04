using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaTest
{
    class Example
    {
    }

    public class A : IA { }
    public interface IA
    {
    }

    public class B
    {
        private readonly IFactory factory;

        public B(IFactory factory)
        {
            this.factory = factory;
        }
        public void Example()
        {
            IA a = factory.GetA();
        }
    }

    public interface IFactory
    {
        IA GetA();
    }

    public class ConcreteFactory : IFactory
    {
        public IA GetA()
        {
            throw new NotImplementedException();
        }
    }


}
