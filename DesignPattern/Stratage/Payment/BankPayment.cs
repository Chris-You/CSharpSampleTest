using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Stratage.Payment
{

    public class BankPayment : Payment
    {
        public BankPayment()
        {
            authProcess = new AuthProcess();
            payProcess = new PayProcess();
        }

        override
        public void PayDisplay()
        {
            Console.WriteLine("Bank Pay~~");
        }

    }



}
