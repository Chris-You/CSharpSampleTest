using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Stratage.Payment
{
    public interface IAuthProcess
    {
        public void Auth();
    }



    public class AuthProcess : IAuthProcess
    {

        public void Auth()
        {
            Console.WriteLine("auth~~");
        }
    }







}
