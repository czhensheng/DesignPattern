using System;

namespace classCharger
{
    class Program
    {
        static void Main(string[] args)
        {
            ITarget t=new Adapter(new Power());
            t.GetPower();
            Console.ReadLine();
        }
    }


    public interface ITarget
    {
        void GetPower();
    }

    public class Power{
        public void GetPower220(){
            System.Console.WriteLine("从电源那里获取220V电压 ");
        }
    }

    public class Adapter:ITarget{
        public Power _power;
        public Adapter(Power power)
        {
            _power=power;
        }
        public void GetPower(){
            _power.GetPower220();
            System.Console.WriteLine("得到手机充电电压");
        }
    }

}

