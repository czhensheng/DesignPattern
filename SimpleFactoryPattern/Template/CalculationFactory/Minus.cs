namespace CalculationFactory
{
    /// <summary>
    /// 减法运算
    /// </summary>
    public class Minus:Operation
    {
        public override double  GetResult(){
            return NumberA-NumberB;
        }    
    }
}