using System;

/*
* Factory Coding Exercise
* You are given a class called Person . The person has two fields: Id , and Name.
* Please implement a non-static PersonFactory  that has a CreatePerson()  method that takes a person's name.
* The Id of the person should be set as a 0-based index of the object created. So, the first person the factory makes should have Id=0, second Id=1 and so on.
*/

namespace FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var person1 = new Person.PersonFactory().CreatePerson("Amanda");
            var person2 = new Person.PersonFactory().CreatePerson("Rafael");

            Console.WriteLine(person1);
            Console.WriteLine(person2);
        }
    }
    public class Person
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        private Person(string name, int id)
        {
            this.Name = name;
            this.Id = id;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}";
        }

        public class PersonFactory
        {
            private static int _id = 0;
            public Person CreatePerson(string name)
            {
                return new Person(name, _id++);
            }
        }
    }
}
