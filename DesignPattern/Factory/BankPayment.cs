using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Factory
{

    public class BankPayment : IPayment
    {
        public void Display()
        {
            Console.WriteLine("Bank Payment~~");
        }

        public PayResult PayProcess()
        {

            Console.WriteLine("Bank auth~~");

            Console.WriteLine("Bank pay~~");

            return new PayResult { isOk = true, message = "ok" };
        }

    }




}
