using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Stratage.Payment
{

    public class CardPayment : Payment
    {
        public CardPayment()
        {
            authProcess = new AuthProcess();
            payProcess = new PayProcess();
        }


        override
        public void PayDisplay()
        {
            Console.WriteLine("Card Pay~~");
        }

    }



}
