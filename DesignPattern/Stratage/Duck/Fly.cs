using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Stratage.Duck
{
    public interface IFlyHehavior
    {
        void fly();
    }

    public class FlyWing : IFlyHehavior
    {
        public void fly()
        {
            Console.WriteLine("i can fly~~");
        }
    }
    public class FlyNo : IFlyHehavior
    {
        public void fly()
        {
            Console.WriteLine("i can not fly~~");
        }
    }

}
