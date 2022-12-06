using System;
using DesignPattern.Stratage.Duck;
using DesignPattern.Stratage.Robot;
using DesignPattern.Stratage.Payment;
//using DesignPattern.Factory;
using DesignPattern.Singleton;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPattern
{
    class TestModel
    {
        public string name { get; set; }
    }

    class Program
    {

        static void Print()
        {
            Singleton.Singleton.getInstance();
            Singleton.Singleton single = Singleton.Singleton.getInstance();

            Console.WriteLine(single.GetHashCode());
        }

        static void PrintParam(object param)
        {
            var model = param as TestModel;

            Console.WriteLine(model.name);
        }

        static string PrintRetvalue(string echo)
        {
            return echo;
        }

        static void Main(string[] args)
        {
            /*
            using (PaymentFactory card = new CardFactory())
            {
                var pay = card.FactoryMethod();
                pay.PayProcess();
                pay.Display();
            }


            using (PaymentFactory bank = new BankFactory())
            {
                var pay = bank.FactoryMethod();
                pay.PayProcess();
                pay.Display();
            }
            */



            var array = new string[] { "say", "hello", "task", "!!" };
            

            Thread t1 = new Thread(new ParameterizedThreadStart(PrintParam));

            Thread t2 = new Thread(new ThreadStart(Print));

            t1.Start(new TestModel { name = "aaa" });
            t2.Start();

            t1.Join();
            t2.Join();
            
            var taskValue = Task.Factory.StartNew(() => {
                return array;
            }) ;

            foreach(var str in taskValue.Result)
            {
                Console.WriteLine(str);
            }

            Console.WriteLine(taskValue.Result);
            Console.WriteLine("======");

            


            //using (Payment card = new CardPayment())
            //{
            //    card.PayDisplay();
            //    card.Auth();
            //    card.Pay();
            //}

            //using (Payment bank = new BankPayment())
            //{
            //    bank.PayDisplay();
            //    bank.Auth();
            //    bank.Pay();
            //}

            //using (Payment mobile = new MobilePayment())
            //{
            //    mobile.PayDisplay();
            //    mobile.Auth();
            //    mobile.Pay();
            //}


            /*
            Duck mallerDuck = new MallardDuck();
            mallerDuck.display();
            mallerDuck.performQuack();
            mallerDuck.performFly();


            Duck rubberDuck = new RubberDuck();
            rubberDuck.display();
            rubberDuck.performQuack();
            rubberDuck.performFly();
            */

            /*
            Robot kkang = new KkangTong();
            kkang.Display();
            kkang.Attack();
            kkang.Move();

            Robot atom = new Atom();
            atom.Display();
            atom.Attack();
            atom.Move();


            Robot taekwnan= new TaekwanV();
            taekwnan.Display();
            taekwnan.Attack();
            taekwnan.Move();

            taekwnan.setAttack(new AttackPunch());
            taekwnan.setMove(new MoveFly());
            taekwnan.Attack();
            taekwnan.Move();
            taekwnan.Display();
            */
        }
    }
}
