using System;

// this can be converted into factory pattern
namespace FactoryMethodPatternNIm
{
    public class InterfacePolyEg
    {
        public static void InterfacePoly()
        {
            Console.WriteLine("Hello World");
            int method = Convert.ToInt32(Console.ReadLine());


            ProcessPayment pp = null;

            switch (method)
            {
                case 1:
                    pp = new ProcessPayment(new CardPayment());
                    break;
                case 2:
                    pp = new ProcessPayment(new CreditPayment());
                    break;
                default:
                    Console.WriteLine("Invalid method");
                    break;
            }

            if (pp != null)
            {
                pp.startProcess();
            }
        }
    }

    public interface IPay
    {
        void makePay();
    }

    public class ProcessPayment
    {
        private IPay _pay;

        public ProcessPayment(IPay pay)
        {
            _pay = pay;
        }

        public void startProcess()
        {
            Console.WriteLine("started Process, choosen method");
            _pay.makePay();
        }
    }

    public class CardPayment : IPay
    {
        public void makePay()
        {
            Console.WriteLine("card pay");
        }
    }

    public class CreditPayment : IPay
    {
        public void makePay()
        {
            Console.WriteLine("credit pay");
        }
    }
}