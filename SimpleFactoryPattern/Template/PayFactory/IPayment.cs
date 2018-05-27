namespace PayFactory
{
    public interface IPayment
    {
        bool PayFor(decimal money);
    }
}