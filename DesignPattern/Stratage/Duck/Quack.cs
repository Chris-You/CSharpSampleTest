using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Stratage.Duck
{

    public interface IQuackHehavior
    {
        void quack();
    }

    public class Quack : IQuackHehavior
    {
        public void quack()
        {
            Console.WriteLine("quack quack~~");
        }
    }

    public class QuackPeek : IQuackHehavior
    {
        public void quack()
        {
            Console.WriteLine("peek peek~~");
        }
    }
    public class NoQuack : IQuackHehavior
    {
        public void quack()
        {
            Console.WriteLine("not sound~~");
        }
    }
}
