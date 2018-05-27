namespace CalculationFactory
{
    /// <summary>
    /// 运算类
    /// </summary>
    public class Operation
    {
        public double NumberA{get;set;}
        public double NumberB { get; set; }      

        public virtual double GetResult(){
            const double result=0;
            return result;
        }
    }
}