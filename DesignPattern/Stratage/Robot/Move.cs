using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Stratage.Robot
{
    public interface IMove
    {
        void move();
    }

    public class MoveRun : IMove
    {
        public void move()
        {
            Console.WriteLine("달리기 이동");
        }
    }

    public class MoveFly : IMove
    {
        public void move()
        {
            Console.WriteLine("날아가기 이동");
        }
    }
}
