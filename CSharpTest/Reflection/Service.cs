using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTest.Reflection
{
    public interface IService
    {
        void Print(string echo);
        string PrintReturn(string echo);
    }


    public class Service : IService
    {
        public void Print(string echo)
        {
            Console.WriteLine(echo);
        }

        public string PrintReturn(string echo)
        {
            return echo;
        }
    }
}
