using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Factory
{

    public class PayResult
    {
        public bool isOk;
        public string message;
    }

    public abstract class PaymentFactory :  IDisposable
    {
        public IPayment payment;

        public PayResult PaytoPG(string type)
        {
            return payment.PayProcess();
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Console.WriteLine("dispose");
        }

        public abstract IPayment FactoryMethod();

    }


    public class CardFactory : PaymentFactory
    {
        override
        public IPayment FactoryMethod()
        {
            return new CardPayment();
        }
    }

    public class BankFactory : PaymentFactory
    {
        override
        public IPayment FactoryMethod()
        {
            return new BankPayment();
        }
    }
}
