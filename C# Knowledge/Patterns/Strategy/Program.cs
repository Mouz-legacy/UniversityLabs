using Strategy.Ducks;
using System.Collections.Generic;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            List<DucksTypes> ducks = new List<DucksTypes>();
            ducks.Add(new BelarusDuck());
            ducks.Add(new RussianDuck());
            ducks.Add(new WoodenDuck());

            foreach (var duck in ducks)
            {
                duck.ShowType();
                duck.Swim();
                duck.Quack();
                duck.Fly();
            }
        }
    }
}
