using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Stratage.Robot
{
    public interface IAttack
    {
        void attack();
    }


    public class AttackRazor : IAttack
    {
        public void attack()
        {
            Console.WriteLine("레이저 공격");
        }
    }

    public class AttackMisile : IAttack
    {
        public void attack()
        {
            Console.WriteLine("미사일 공격");
        }
    }

    public class AttackPunch : IAttack
    {
        public void attack()
        {
            Console.WriteLine("주먹 공격");
        }
    }
}
