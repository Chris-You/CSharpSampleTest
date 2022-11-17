using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Stratage.Payment
{
    public interface IPayProcess
    {
        public void Pay();
    }



    public class PayProcess : IPayProcess
    {
        public void Pay()
        {
            Console.WriteLine("pay~~");
        }
    }







}
