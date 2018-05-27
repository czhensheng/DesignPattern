using System;

namespace PayFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal money=100m;
            var payment=PaymentFactory.CreatePayment("ABC");
            System.Console.WriteLine( payment.PayFor(money));
        }
    }
}
