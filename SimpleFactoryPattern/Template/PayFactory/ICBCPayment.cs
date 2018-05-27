using System;
namespace PayFactory
{
    public class ICBCPayment:IPayment
    {
        public bool PayFor(decimal money){
            return true;
        }
    }
}