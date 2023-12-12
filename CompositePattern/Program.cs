using System;
using System.Collections;
using System.Collections.Generic;

/* Consider the code presented below. The Sum() extension method adds up all the values 
 * in a list of IValueContainer elements it gets passed. We can have a single value or 
 * a set of values. Complete the implementation of the interfaces so that Sum() begins 
 * to work correctly.
 */

namespace CompositePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            SingleValue value = new(2);
            ManyValues values1 = new() { 1, 2, 3, 5 };
            ManyValues values2 = new() { 2, 3 };

            List<IValueContainer> values = new() { value, values1, values2 };

            var sum = values.Sum();

            Console.WriteLine($"Sum = {sum}");
        }
    }
    public interface IValueContainer : IEnumerable<int>
    {

    }

    public class SingleValue : IValueContainer
    {
        public int Value { get; private set; }

        public SingleValue(int value)
        {
            Value = value;
        }

        public IEnumerator<int> GetEnumerator()
        {
            yield return Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class ManyValues : List<int>, IValueContainer
    {

    }

    public static class ExtensionMethods
    {
        public static int Sum(this List<IValueContainer> containers)
        {
            int result = 0;
            foreach (var c in containers)
                foreach (var i in c)
                    result += i;
            return result;
        }
    }
}
