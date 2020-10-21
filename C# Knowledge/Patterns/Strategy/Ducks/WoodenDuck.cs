using System;
using System.Collections.Generic;
using System.Text;
using Strategy.Fly;
using Strategy.Quack;

namespace Strategy.Ducks
{
    class WoodenDuck : DucksTypes
    {
        public WoodenDuck()
        {
            flyBehavior = new NoFly();
            quackBehavior = new NoQuack();
        }
        public override void ShowType()
        {
            Console.WriteLine("Hi, I'm a wooden duck");
        }
    }
}
