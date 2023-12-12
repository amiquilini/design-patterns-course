using System;

/*
 * Proxy Coding Exercise
 * 
 * You are given the Person  class and asked to write a ResponsiblePerson  proxy that does the following:
 * Allows person to drink unless they are younger than 18 (in that case, return "too young")
 * Allows person to drive unless they are younger than 16 (otherwise, "too young")
 * In case of driving while drinking, returns "dead"
 */

namespace ProxyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person { Age = 16 };
            var personProxy = new ResponsiblePerson(person);

            Console.WriteLine($"Age: {person.Age}");
            Console.WriteLine($"Drive(): {personProxy.Drive()}");
            Console.WriteLine($"Drink(): {personProxy.Drink()}");
            Console.WriteLine($"DrinkAndDrive(): {personProxy.DrinkAndDrive()}");

            personProxy.Age = 18;

            Console.WriteLine($"Age: {person.Age}");
            Console.WriteLine($"Drive(): {personProxy.Drive()}");
            Console.WriteLine($"Drink(): {personProxy.Drink()}");
            Console.WriteLine($"DrinkAndDrive(): {personProxy.DrinkAndDrive()}");
        }
    }

    public class Person
    {
        public int Age { get; set; }

        public string Drink()
        {
            return "drinking";
        }

        public string Drive()
        {
            return "driving";
        }

        public string DrinkAndDrive()
        {
            return "driving while drunk";
        }
    }

    public class ResponsiblePerson
    {
        private Person person;
        public ResponsiblePerson(Person person)
        {
            this.person = person;
        }

        public int Age
        {
            get => person.Age;
            set => person.Age = value;
        }

        public string Drink()
        {
            if (person.Age >= 18) return person.Drink();
            return "too young";
        }

        public string Drive()
        {
            if (person.Age >= 16) return person.Drive();
            return "too young";
        }

        public string DrinkAndDrive()
        {
            return "dead";
        }
    }
}
