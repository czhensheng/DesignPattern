namespace CalculationFactory
{
    /// <summary>
    /// 加法运算
    /// </summary>
    public class Plus:Operation
    {
        public override double GetResult(){
            return NumberA+NumberB;
        }
    }
}