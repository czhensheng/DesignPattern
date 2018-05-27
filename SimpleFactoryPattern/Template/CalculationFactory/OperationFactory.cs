namespace CalculationFactory
{
    public class OperationFactory
    {
        public static Operation CreateOperate(string operate)
        {
            Operation Operation=null;
            switch(operate){
                case "+":
                    Operation=new Plus();
                    break;
                case "-":
                    Operation=new Minus();
                    break;
                case "*":
                    Operation=new Multiply();
                    break;
                case "/":
                    Operation=new Divide();
                    break;
            }
            return Operation;
        }
    }
}