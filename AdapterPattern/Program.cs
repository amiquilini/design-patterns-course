using System;

/* Adapter Coding Exercise
 * You are given an IRectangle  interface and an extension method on it. 
 * Try to define a SquareToRectangleAdapter  that adapts the Square  to 
 * the IRectangle  interface.
 */

namespace AdapterPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var square = new Square(4);
            var rectangle = new SquareToRectangleAdapter(square);

            var area = rectangle.Area();

            Console.WriteLine($"Area = {area}");
        }
    }

    public class Square
    {
        public int Side { get; private set; }

        public Square(int side)
        {
            Side = side;
        }
    }

    public interface IRectangle
    {
        int Width { get; }
        int Height { get; }
    }

    public static class ExtensionMethods
    {
        public static int Area(this IRectangle rc)
        {
            return rc.Width * rc.Height;
        }
    }

    public class SquareToRectangleAdapter : IRectangle
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public SquareToRectangleAdapter(Square square)
        {
            Width = square.Side;
            Height = square.Side;
        }
    }

}
