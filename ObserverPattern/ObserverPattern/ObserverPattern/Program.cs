using System;
using System.Collections.Generic;

namespace ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //模拟业务：订阅银行短信业务，当我们账户发生改变，我们就会收到相应的短信
            Depositor czs = new BeijingDepositor("czs", 3000);
            Depositor czhenzheng = new BeijingDepositor("czhenzheng", 4000);
            Depositor chenzhensheng = new BeijingDepositor("chenzhensheng", 5000);

            BankMessageSystem beijingBank = new BeijingBankMessageSystem();
            beijingBank.Add(czs);
            beijingBank.Add(czhenzheng);
            beijingBank.Add(chenzhensheng);

            czs.GetMoney(100);
            beijingBank.Notify();

            czhenzheng.GetMoney(200);
            chenzhensheng.GetMoney(300);
            beijingBank.Notify();

            czs.GetMoney(300);
            czhenzheng.GetMoney(400);
            chenzhensheng.GetMoney(500);
            beijingBank.Notify();
        }
    }


    public abstract class BankMessageSystem
    {
        protected IList<Depositor> observers;

        public BankMessageSystem()
        {
            observers = new List<Depositor>();

        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="depositor"></param>
        public abstract void Add(Depositor depositor);

        public abstract void Delete(Depositor depositor);

        /// <summary>
        ///通知
        /// </summary>
        public void Notify()
        {
            foreach (Depositor depositor in observers)
            {
                depositor.Update(depositor.Balance, depositor.OperationDateTime);
                depositor.AccountIsChanged = false;
            }
        }
    }

    public sealed class BeijingBankMessageSystem : BankMessageSystem
    {
        public override void Add(Depositor depositor)
        {
            observers.Add(depositor);
        }

        public override void Delete(Depositor depositor)
        {
            if (observers.Contains(depositor))
            {
                observers.Remove(depositor);
            }
        }
    }

    //储户的抽象接口--相当于抽象观察者角色（Observer）
    public abstract class Depositor
    {
        //状态数据
        private string _name;
        private int _balance;
        private int _total;
        private bool _isChanged;

        //初始化状态数据
        protected Depositor(string name, int total)
        {
            this._name = name;
            this._balance = total;//存款总额等于余额
            this._isChanged = false;//账户未发生变化
        }

        //储户的名称，假设可以唯一区别的
        public string Name
        {
            get { return _name; }
            private set { this._name = value; }
        }

        public int Balance
        {
            get { return this._balance; }
        }

        //账户操作时间
        public DateTime OperationDateTime { get; set; }

        //账户是否发生变化
        public bool AccountIsChanged
        {
            get { return this._isChanged; }
            set { this._isChanged = value; }
        }

        //取钱
        public void GetMoney(int num)
        {
            if (num <= this._balance && num > 0)
            {
                this._balance = this._balance - num;
                this._isChanged = true;
                OperationDateTime = DateTime.Now;
            }
        }



        //更新储户状态
        public abstract void Update(int currentBalance, DateTime dateTime);
    }

    public sealed class BeijingDepositor : Depositor
    {
        public BeijingDepositor(string name, int total) : base(name, total)
        {

        }
        public override void Update(int currentBalance, DateTime dateTime)
        {
            Console.WriteLine(Name + ":账户发生了变化，时间是：" + dateTime.ToString() + ",当前余额是" + currentBalance.ToString());
        }
    }
}
