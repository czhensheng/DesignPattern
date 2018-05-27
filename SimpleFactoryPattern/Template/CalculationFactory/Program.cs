using System;

namespace CalculationFactory
{
    class Program
    {
        static void Main(string[] args)
        {
           Operation Operation=OperationFactory.CreateOperate("+");
           Operation.NumberA=1;
           Operation.NumberB=2;
           System.Console.WriteLine(Operation.GetResult());
        }
    }
}
