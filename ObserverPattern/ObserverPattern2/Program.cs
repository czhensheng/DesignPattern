using System;
using System.Collections.Generic;

namespace ObserverPattern2
{
    class Program
    {
        static void Main(string[] args)
        {
              // Configure Observer pattern
            ConcreteSubject s = new ConcreteSubject();

            s.Attach(new ConcreteObserver(s, "X"));
            s.Attach(new ConcreteObserver(s, "Y"));
            s.Attach(new ConcreteObserver(s, "Z"));

            // Change subject and notify observers
            s.SubjectState = "ABC";
            s.Notify();
        }
    }

    public abstract class Observer{
        public abstract void Update();
    }
    
    public class Subject{
        private List<Observer> _observers=new List<Observer>();
        public void Attach(Observer observer){
            _observers.Add(observer);
        }

        public void Detach(Observer observer){
            _observers.Remove(observer);
        }
        public void Notify(){
            foreach (Observer observer in _observers)
            {
                observer.Update();
            }
        }
    }

    public class ConcreteSubject :Subject{
        public string  SubjectState { get; set; } 
    }
 
    public class ConcreteObserver:Observer{
          private string _name;
        private string _observerState;
        private ConcreteSubject _subject;

        public ConcreteObserver(ConcreteSubject subject, string name)
        {
            this._subject = subject;
            this._name = name;
        }

        public override void Update()
        {
            _observerState = _subject.SubjectState;
            Console.WriteLine("Observer {0}'s new state is {1}", _name, _observerState);
        }

        public ConcreteSubject Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }
    }

}
