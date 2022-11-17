using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Factory
{

    public interface IPayment
    {
        void Display();
        PayResult PayProcess();
        //void auth();
    }


}
