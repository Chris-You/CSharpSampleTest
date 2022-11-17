using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Stratage.Robot
{
    public abstract class Robot
    {

        public IAttack attackBehavior;
        public IMove moveBehavior;

        public void Attack()
        {
            attackBehavior.attack();
            
        }

        public void Move()
        {
            moveBehavior.move();
        }

        public abstract void Display();


        public void setAttack(IAttack attack)
        {
            this.attackBehavior = attack;
        }

        public void setMove(IMove move)
        {
            this.moveBehavior = move;
        }
    }

    


    




    public class Atom :  Robot
    {
        public Atom()
        {
            attackBehavior = new AttackRazor();
            moveBehavior = new MoveFly();
        }


        override
        public void Display()
        {
            Console.WriteLine("아톰");
        }
    }

    public class TaekwanV : Robot
    {

        public TaekwanV()
        {
            attackBehavior = new AttackMisile();
            moveBehavior = new MoveRun();
        }

        override
        public void Display()
        {
            Console.WriteLine("태권V");
        }
    }


    public class KkangTong : Robot
    {

        public KkangTong()
        {
            attackBehavior = new AttackPunch();
            moveBehavior = new MoveRun();
        }

        override
        public void Display()
        {
            Console.WriteLine("깡통로봇");
        }
    }

}
