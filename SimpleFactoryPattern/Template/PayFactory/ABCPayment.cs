using System;
namespace PayFactory
{
    public class ABCPayment:IPayment
    {
        public bool PayFor(decimal money){
            return true;
        }
    }
}