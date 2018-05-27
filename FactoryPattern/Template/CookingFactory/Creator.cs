using System;
namespace CookingFactory {
    /// <summary>
    /// 抽象工厂类
    /// </summary>
    public abstract class Creator {
        public abstract Food CreateFoodFactory ();
    }
}