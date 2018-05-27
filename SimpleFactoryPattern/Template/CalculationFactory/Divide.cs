namespace CalculationFactory
{
    /// <summary>
    /// 除法
    /// </summary>
    public class Divide:Operation
    {
        public override double GetResult(){
            return NumberA/NumberB;
        }    
    }
}