using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTest.Reflection
{

    public class CopyConstructor : ICloneable
    {
        public CopyConstructor() { }
        // 카트 복사용 생성자
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public int ordNo { get; set; }
        public int ordSq { get; set; }

        public string UserId { get; set; }
        public double Cnt { get; set; }
        public string OrdSbc { get; set; }
        public string Notice { get; set; }


        public CopyConstructor(CopyConstructor cart)
        {
            foreach (var p in this.GetType().GetProperties())
            {
                foreach (var c in cart.GetType().GetProperties())
                {
                    if (p.Name == c.Name)
                    {
                        //Console.WriteLine();
                        p.SetValue(this, c.GetValue(cart));
                    }
                }
            }
        }

        public void Test()
        {
            CopyConstructor constructor = new CopyConstructor();
            constructor.ordNo = 1;

            CopyConstructor constructor1 = constructor;


            Console.WriteLine("source : " + constructor.GetHashCode());
            Console.WriteLine("target : " + constructor1.GetHashCode());

            Console.WriteLine("source no : " + constructor.ordNo);
            Console.WriteLine("target no : " + constructor1.ordNo);

            // 원본의 값을 변경
            constructor.ordNo = 2;

            //  source 의 값이 변경이 되면 target 도 함께 바뀐다.
            Console.WriteLine("source no : " + constructor.ordNo);
            Console.WriteLine("target no : " + constructor1.ordNo);




            CopyConstructor constructor2 = new CopyConstructor(constructor1);
            Console.WriteLine($"target2 : {constructor2.GetHashCode()}, {constructor2.ordNo} ");
            CopyConstructor constructor3 = (CopyConstructor)constructor2.Clone();
            Console.WriteLine($"target3 : {constructor3.GetHashCode()}, {constructor3.ordNo} ");

            constructor2.ordNo = 10;
            constructor3.ordNo = 20;
            Console.WriteLine($"target2 : {constructor2.GetHashCode()}, {constructor2.ordNo} ");
            Console.WriteLine($"target3 : {constructor3.GetHashCode()}, {constructor3.ordNo} ");

        }
    }



    


}
