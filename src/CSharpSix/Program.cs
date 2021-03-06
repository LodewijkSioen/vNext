﻿using System;
using System.Collections;
using System.Collections.Generic;
using static System.Math; //Using Static

namespace CSharpSix
{
    public class Program
    {
        public void Main(string[] args)
        {
            var test = new Test("lalal");
            Console.WriteLine(test);
            Console.ReadLine();

            Console.WriteLine(test.DivideLength(0));
            Console.ReadLine();

            Console.WriteLine(new Badcollection { "one", "two", "three" });//Collection Initializers with Extension 'Add'
        }
    }

    public class Test
    {
        public Test(string initialName)
        {
            Name = initialName;
            Length = initialName?.Length ?? 0; //Null Conditional Operator
            NameOfParameter = nameof(initialName); //NameOf Expression
        }

        public string Name { get; } //Private Auto Properties
        public string NameOfParameter { get; }
        public int Length { get; }

        public IEnumerable<String> Collection { get; set; } = new[] { "One", "Two" }; //Initializers for Auto Properties
        public IDictionary<int, string> Dictionary { get; } = new Dictionary<int, String> { [1] = "Test", [2] = "lalal" }; //Index Initializers

        public override string ToString() => $"Name: {Name} - Set By: {NameOfParameter} - Length: {Length}"; //Expression Bodied Functions/Properties + String interpolation

        public double DivideLength(double by)
        {
            try
            {
                return Round(Length / by); //Using Static
            }
            catch (DivideByZeroException ex) when (ex.Message.Length > 0) //Exception Filters
            {
                return 0;
            }
        }
    }

    public class Badcollection : IEnumerable<string>
    {
        private List<string> _internalCollection = new List<string>();

        public void BadAdd(string value) => _internalCollection.Add(value);

        public override string ToString() => String.Join(",", _internalCollection);

        public IEnumerator<string> GetEnumerator()=>_internalCollection.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()=>_internalCollection.GetEnumerator();
    }

    public static class Extensions
    {
        public static void Add(this Badcollection collection, string value)=> collection.BadAdd(value);
    }
}
