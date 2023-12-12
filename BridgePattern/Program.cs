using System;

/* You are given an example of an inheritance hierarchy which results in Cartesian-product duplication.
* Please refactor this hierarchy, giving the base class Shape  a constructor that takes an interface 
* IRenderer as well as VectorRenderer and RasterRenderer classes. Each implementer of the Shape 
* abstract class should have a constructor that takes an IRenderer  such that, subsequently, 
* each constructed object's ToString() operates correctly, for example,
* new Triangle(new RasterRenderer()).ToString() // returns "Drawing Triangle as pixels"
*/

namespace BridgePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var triangle = new Triangle(new RasterRenderer()).ToString();
            var square = new Square(new VectorRenderer()).ToString();

            Console.WriteLine(triangle);
            Console.WriteLine(square);
        }

    }

    public interface IRenderer
    {
        string RenderAs { get; }
    }

    public abstract class Shape
    {
        private IRenderer renderer;
        public string Name { get; set; }

        protected Shape(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        public override string ToString()
        {
            return $"Drawing {Name} as {renderer.RenderAs}";
        }
    }

    public class Triangle : Shape
    {
        public Triangle(IRenderer renderer) : base(renderer)
        {
            Name = "Triangle";
        }
    }

    public class Square : Shape
    {
        public Square(IRenderer renderer) : base(renderer)
        {
            Name = "Square";
        }
    }

    public class RasterRenderer : IRenderer
    {
        public string RenderAs
        {
            get { return "pixels"; }
        }
    }

    public class VectorRenderer : IRenderer
    {
        public string RenderAs
        {
            get { return "lines"; }
        }
    }
}
