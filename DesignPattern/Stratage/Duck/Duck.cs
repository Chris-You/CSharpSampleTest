using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Stratage.Duck
{
    public abstract class Duck
    {
        public IFlyHehavior flyHavior;
        public IQuackHehavior quackHavior;

        public void performQuack()
        {
            quackHavior.quack();
        }

        public void performFly()
        {
            flyHavior.fly();
        }

        public void setFlyBehavior(IFlyHehavior fly)
        {
            flyHavior = fly;
        }

        public void setQuackBehavior(IQuackHehavior quack)
        {
            quackHavior = quack;
        }


        public abstract void display();

    }


    public class RedHeadDuck : Duck
    {

        public RedHeadDuck()
        {
            flyHavior = new FlyWing();
            quackHavior = new Quack();
        }

        override
        public void display()
        {
            Console.WriteLine("i RedHead Duck ~~");
        }
    }


    public class MallardDuck : Duck
    {
        public MallardDuck()
        {
            flyHavior = new FlyWing();
            quackHavior = new Quack();
        }


        override
        public void display()
        {
            Console.WriteLine("i mallard duck~~");
        }
    }

    public class RubberDuck : Duck
    {

        public RubberDuck()
        {
            flyHavior = new FlyNo();
            quackHavior = new QuackPeek();
        }

        override
        public void display()
        {
            Console.WriteLine("i rubber duck~~");
        }
    }
}
