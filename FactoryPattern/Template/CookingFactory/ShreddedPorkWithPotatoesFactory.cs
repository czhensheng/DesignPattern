using System;
namespace CookingFactory
{
    public class ShreddedPorkWithPotatoesFactory:Creator
    {
        public override Food CreateFoodFactory(){
            return new ShreddedPorkWithPotatoes();
        }
    }
}