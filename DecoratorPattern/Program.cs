using System;

/* The following code scenario shows a Dragon which is both a Bird and a Lizard. 
 * Complete the Dragon's interface (there's no need to extract IBird  or ILizard). 
 * Take special care when implementing the Age property!
 */

namespace DecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var dragon = new Dragon { Age = 157 };

            Console.WriteLine($"The dragon is {dragon.Age} yo");
            Console.WriteLine($"The dragon is {dragon.Fly()}");
            Console.WriteLine($"The dragon is {dragon.Crawl()}");
        }
    }

    public class Bird
    {
        public int Age { get; set; }

        public string Fly()
        {
            return (Age < 10) ? "flying" : "too old";
        }
    }

    public class Lizard
    {
        public int Age { get; set; }

        public string Crawl()
        {
            return (Age > 1) ? "crawling" : "too young";
        }
    }

    public class Dragon // no need for interfaces
    {
        private int _age;
        private Bird bird = new Bird();
        private Lizard lizard = new Lizard();

        public int Age
        {
            set { _age = bird.Age = lizard.Age = value; }
            get { return _age; }
        }

        public string Fly()
        {
            return bird.Fly();
        }

        public string Crawl()
        {
            return lizard.Crawl();
        }
    }
}
