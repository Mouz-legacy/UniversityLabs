using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy.Fly
{
    class NoFly : IFlyable
    {
        public void Fly()
        {
            Console.WriteLine("This duck have no ability to fly");
        }
    }
}
