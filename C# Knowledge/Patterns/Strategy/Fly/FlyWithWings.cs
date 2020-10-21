using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy.Fly
{
    class FlyWithWings : IFlyable
    {
        public void Fly()
        {
            Console.WriteLine("I'm a flying");
        }
    }
}
