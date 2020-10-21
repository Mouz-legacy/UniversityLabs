using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy.Ducks
{
    class RussianDuck : DucksTypes
    {
        public override void ShowType()
        {
            Console.WriteLine("I'm a russian duck");
        }
    }
}
