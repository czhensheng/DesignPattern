namespace CalculationFactory
{
    /// <summary>
    /// 乘法
    /// </summary>
    public class Multiply:Operation
    {
        public override double GetResult(){
            return NumberA*NumberB;
        }
    }
}