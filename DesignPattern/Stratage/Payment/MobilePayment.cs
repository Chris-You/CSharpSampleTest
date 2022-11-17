using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Stratage.Payment
{

    public class MobilePayment : Payment
    {
        public MobilePayment()
        {
            authProcess = new AuthProcess();
            payProcess = new PayProcess();
        }


        override
        public void PayDisplay()
        {
            Console.WriteLine("Mobile Pay~~");
        }

    }



}
