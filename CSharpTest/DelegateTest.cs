using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTest
{
    delegate void ResultHelper(Func<bool, bool> work, Action success, Action fail);

    public class DelegateTest
    {
        public bool Work(bool isOk)
        {
            return isOk;
        }

        public void Success()
        {
            //return 0;
            Console.WriteLine("success method");
        }

        public void Fail()
        {
            Console.WriteLine("fail method");
        }

        public void Result(Func<bool, bool> work, Action success, Action fail)
        {
            
            if (work(true))
            {
                success();
            }
            else
            {
                fail();
            }

            if (work(false))
            {
                success();
            }
            else
            {
                fail();
            }
        }


        public void Process()
        {

            ResultHelper result = new ResultHelper(Result);
            Func<bool, bool> func = Work;
            //func(false);
            result(func, Success, Fail);
        }


    }
}
