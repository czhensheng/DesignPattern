using System;
namespace CookingFactory
{
    public class TomatoScrambleEggsFactory:Creator
    {
        public override Food CreateFoodFactory(){
            return new TomatoScrambledEggs();
        }
    }
}