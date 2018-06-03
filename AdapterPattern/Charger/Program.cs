using System;

namespace Charger
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("手机:");
            ITarget t=new Adapter();
            t.GetPower();
            System.Console.WriteLine("-----------------------------------------");

            Console.ReadLine();
        }
    }

    ///类似配器结构
    public interface ITarget
    {
        void GetPower();
    }

    public abstract class Power{
        public void GetPower220(){
            System.Console.WriteLine("从电源中得到220V电压");
        }
    }

    public class Adapter:Power,ITarget{
        public void GetPower(){
            this.GetPower220();
            System.Console.WriteLine("得到手机的充电电压");
        }
    }

}

