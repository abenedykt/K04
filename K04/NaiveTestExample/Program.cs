using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NaiveTestExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var tests = Assembly.GetCallingAssembly()
                 .GetTypes()
                 .Where(t => !t.IsAbstract)
                 .Where(t => t.IsClass)
                 .Where(t => t.IsPublic)
                 .SelectMany(t => t.GetMethods())
                 .Where(m => m.IsPublic)
                 //.Where(m => m.Name.Contains("Test"));
                 .Where(m => m.GetCustomAttribute<AwesomeTestAttribute>() != null);

            foreach (var test in tests)
            {
                Console.WriteLine($"found test: {test.Name}");
            }


        }

        private static void Trim_should_remove_spaces_from_beginning_and_end()
        {
            // arrange
            var toTest = " a b c ";

            // act
            var result = toTest.Trim();


            //assert
            MyAssert.Equals("a b c", result);
        }

        private static void Trim_should_remove_spaces_from_beginning_and_end2()
        {
            // arrange
            var toTest = " a b c ";

            // act
            var result = toTest.Trim();


            //assert
            MyAssert.Equals("a b c", result);
        }

        private static void Trim_should_remove_spaces_from_beginning_and_end3()
        {
            // arrange
            var toTest = " a b c ";

            // act
            var result = toTest.Trim();


            //assert
            MyAssert.Equals("a b c", result);
        }

        private static void Trim_should_remove_spaces_from_beginning_and_end4()
        {
            // arrange
            var toTest = " a b c ";

            // act
            var result = toTest.Trim();


            //assert
            MyAssert.Equals("a b c", result);
        }
    }

    public class AwesomeTestAttribute : Attribute
    {
    }

    public class MyExampleTests
    {
        public void SimpleTest1()
        {

        }

        public void SimpleTest2()
        {

        }
    }

    public class MyExampleTests2
    {

        [AwesomeTest]
        public void SimpleTest21()
        {

        }

        [AwesomeTest]
        public void SimpleTest22()
        {

        }
    }

    internal class MyAssert
    {
        internal static void Equals(string expected, string result, [CallerMemberName]string testName = "")
        {
            var c = Console.ForegroundColor;
            Console.Write(testName + " ");
            if (expected == result)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Pass");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fail");
            }

            Console.ForegroundColor = c;
        }
    }
}
