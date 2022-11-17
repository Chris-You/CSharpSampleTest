using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Stratage.Payment
{
    public abstract class Payment : IDisposable
    {
        public IAuthProcess authProcess;
        public IPayProcess payProcess;
        
        public void Pay()
        {
            payProcess.Pay();
        }

        public void Auth()
        {
            authProcess.Auth();
        }

        public abstract void PayDisplay();

        
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Console.WriteLine("dispose~~");
        }
    }




   
}
