using System;
using System.Text;
using System.Collections.Generic;

/*
 * Builder Coding Exercise
 * You are asked to implement the Builder design pattern for rendering simple chunks of code.
 * Sample use of the builder you are asked to create:
 * var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
 * Console.WriteLine(cb);
 * The expected output of the above code is:
 * 
 * public class Person
 * {
 *   public string Name;
 *   public int Age;
 * }
 * Please observe the same placement of curly braces and use two-space indentation.
 */

namespace DesignPatternCourse
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var cb = new CodeBuilder("Person")
                        .AddProperty("Name", "string")
                        .AddProperty("Age", "int")
                        .AddProperty("Height", "float");

                Console.WriteLine(cb);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public class CodeBuilder
        {
            private Class _class;

            public CodeBuilder(string className)
            {
                _class = new Class(className);
            }

            public CodeBuilder AddProperty(string propertyName, string propertyType)
            {
                _class.AddProperty(propertyName, propertyType);
                return this;
            }

            public override string ToString()
            {
                return _class.ToString();
            }
        }

        public class Class
        {
            public string Name;
            public List<Property> Properties;

            public Class(string name)
            {
                Validate(name);

                this.Name = name;
                Properties = new List<Property>();
            }

            private void Validate(string name)
            {
                if (string.IsNullOrEmpty(name))
                    throw new ArgumentException("Class name cannot be empty");
            }

            public void AddProperty(string propertyName, string propertyType)
                => Properties.Add(new Property(propertyName, propertyType));

            public override string ToString()
            {
                var sb = new StringBuilder();
                sb.AppendLine($"public class {Name}");
                sb.AppendLine("{");
                foreach (var property in Properties)
                    sb.AppendLine($"  {property};");
                sb.Append("}");

                return sb.ToString();
            }
        }

        public class Property
        {
            public string Name;
            public string Type;

            public Property(string name, string type)
            {
                Validate(name, type);

                this.Name = name;
                this.Type = type;
            }

            private void Validate(string name, string type)
            {
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(type))
                    throw new ArgumentException("Property values cannot be empty");
            }

            public override string ToString()
            {
                return $"public {Type} {Name}";
            }
        }
    }
}
