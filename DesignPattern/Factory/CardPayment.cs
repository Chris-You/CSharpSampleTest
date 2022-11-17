using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Factory
{

    public class CardPayment : IPayment
    {
        public void Display()
        {
            Console.WriteLine("CardPayment~~");
        }

        public PayResult PayProcess()
        {
            Console.WriteLine("card auth~~");

            Console.WriteLine("card pay~~");

            return new PayResult { isOk = true, message = "ok" };
        }

        /*
        public void auth()
        {
            Console.WriteLine("card auth~~");
        }
        */
    }




}
