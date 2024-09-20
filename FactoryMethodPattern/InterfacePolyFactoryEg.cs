using System;
namespace FactoryMethodPattern
{
    public class InterfacePolyFactoryEg
    {
        public static void InterfacePolyFactory()
        {
            Console.WriteLine("Hello World");
            int method = Convert.ToInt32(Console.ReadLine());

            IPay paymentMethod = PaymentFactory.GetPaymentMethod(method);

            if (paymentMethod == null)
            {
                Console.WriteLine("Invalid method");
                return;
            }


            ProcessPayment pp = new ProcessPayment(paymentMethod);
            pp.startProcess();
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
            Console.WriteLine("started Process, chosen method");
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

    public static class PaymentFactory
    {
        public static IPay GetPaymentMethod(int method)
        {
            return method switch
            {
                1 => new CardPayment(),
                2 => new CreditPayment(),
                _ => null,
            };
        }
    }
}