using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy.Quack
{
    class SimpleQuack : IQuackable
    {
        public void Quack()
        {
            Console.WriteLine("Quack, quack");
        }
    }
}
