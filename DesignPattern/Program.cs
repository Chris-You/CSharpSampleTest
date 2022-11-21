using System;
using DesignPattern.Stratage.Duck;
using DesignPattern.Stratage.Robot;
using DesignPattern.Stratage.Payment;
//using DesignPattern.Factory;
using DesignPattern.Singleton;

namespace DesignPattern
{
    class Program
    {
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


            Singleton.Singleton single = Singleton.Singleton.getInstance();

            Singleton.Singleton single2 = Singleton.Singleton.getInstance();

            Console.WriteLine(single);
            Console.WriteLine(single2);


            using (Payment card = new CardPayment())
            {
                card.PayDisplay();
                card.Auth();
                card.Pay();
            }

            using (Payment bank = new BankPayment())
            {
                bank.PayDisplay();
                bank.Auth();
                bank.Pay();
            }

            using (Payment mobile = new MobilePayment())
            {
                mobile.PayDisplay();
                mobile.Auth();
                mobile.Pay();
            }
            

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
