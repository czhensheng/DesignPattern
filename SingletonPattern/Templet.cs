public class Singleton {
    //私有变量记录Singleton的唯一实例
    //PS：定义静态变量：每个线程都有自己的线程栈，定义静态主要是为了在多线程情况下确保只有一个实例
    //静态变量在多线程间是共享的
    private static Singleton uniqueInstance;
    //定义一个标识确保线程同步
    private static readonly object locker = new object ();
    //私有构造函数（无法用new生成对象，外界不能创建该类的实例）
    private Singleton () {

    }
    //定义公有方法来提供该类的唯一全局访问点
    public static Singleton GetInstance () {
        //双重锁定
        //为了避免多余的性能开销（对于GetInstance方法来说，我们只需要判断uniqueInstance是否为空就可以了，如果不为空的话直接调用现有的实例就好了，但是如果不加上双重锁定判断，又会浪费在lock判断上面，lock后又要再判断，等于多做了操作）
        if (uniqueInstance == null) {
            //第一个线程访问的时候，对locker进行“加锁”
            //第二个线程访问的时候，首先会检测locker的状态，检测到为“加锁”状态，该线程会挂起等待第一个线程解锁
            //lock内部的语句执行完之后（即线程运行完之后）会对该对象进行“解锁”
            lock (locker) {
                //在多线程的情况下，比如如果有两个线程同时运行GetInstance方法的时候，如果两个线程进程(uniqueInstance==null)这个条件的时候都会返回真，此时两个线程都会创建Singleton实例（已经违背了单例模式）
                //多线程的解决方案就是GetInstance方法同一时间只能由一个线程运行，其他线程等待，保证线程安全
                //如果实例不存在，则NEW一个实例，否则返回一个已有的实例
                if (uniqueInstance == null) {
                    uniqueInstance = new Singleton ();
                }
            }
        }
        return uniqueInstance;
    }
}