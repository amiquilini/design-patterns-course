using Newtonsoft.Json;
using System;

/* Prototype Coding Exercise
 * Given the definitions, you are asked to implement Line.DeepCopy() to perform a deep copy
 * of the current Line object.
 */

namespace PrototypePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = new Line
            {
                Start = new Point { X = 3, Y = 3 },
                End = new Point { X = 10, Y = 10 }
            };

            var lineCopy = line.DeepCopy();

            Console.WriteLine(line);
            Console.WriteLine(lineCopy);

            line.Start.X = line.End.X = line.Start.Y = line.End.Y = 0;

            Console.WriteLine(line);
            Console.WriteLine(lineCopy);
        }
    }

    public class Point
    {
        public int X, Y;

        public override string ToString()
        {
            return $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";
        }
    }

    public class Line
    {
        public Point Start, End;

        public override string ToString()
        {
            return $"{nameof(Point)} - Start: {Start}, End: {End}";
        }
    }

    public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            if (ReferenceEquals(self, null))
            {
                return default(T);
            }
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(self));
        }
    }
}
