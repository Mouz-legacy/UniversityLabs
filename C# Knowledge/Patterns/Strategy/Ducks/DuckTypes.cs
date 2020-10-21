using System;
using System.Collections.Generic;
using System.Text;
using Strategy.Fly;
using Strategy.Quack;

namespace Strategy.Ducks
{
    abstract class DucksTypes : IFlyable, IQuackable
    {
        protected IFlyable flyBehavior;
        protected IQuackable quackBehavior;

        public DucksTypes()
        {
            flyBehavior = new FlyWithWings();
            quackBehavior = new SimpleQuack();
        }
        public void Swim()
        {
            Console.WriteLine("Duck is swimming");
        }

        public virtual void Fly()
        {
            flyBehavior.Fly();
        }

        public virtual void Quack()
        {
            quackBehavior.Quack();
        }

        public abstract void ShowType();
    }
}
