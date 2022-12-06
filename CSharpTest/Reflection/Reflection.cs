using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTest.Reflection
{
    public class Reflection
    {
        public int number { get; set; }

        public Reflection()
        {
        }

        public Reflection(int num)
        {
            number = num;
        }

        public void Plus()
        {
            Console.WriteLine("plue method");
        }

        public int Calc(int a, int b)
        {
            return number = (a + b);
        }


        public void GetInfo()
        {
            Type type = this.GetType();

            foreach(var construct in type.GetConstructors())
            {
                Console.WriteLine("constructor : " + construct.Name);
                foreach(var p in construct.GetParameters())
                {
                    Console.WriteLine("            ㄴ" + p.Name);
                }
            }

            foreach (var prop in type.GetProperties())
            {
                Console.WriteLine("Property : " + prop.Name);
            }

            foreach (var mehod in type.GetMethods())
            {
                Console.WriteLine("Methods : " + mehod.Name);
            }
        }

    }
}
