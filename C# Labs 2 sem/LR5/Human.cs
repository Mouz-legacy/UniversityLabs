using System;
using System.Collections.Generic;
using System.Text;

namespace LAB5
{
    abstract class Human
    {
        public enum Temperament
        {
            Choleric = 1,
            Sanguine,
            Phlegmatic,
            Melancholy
        }

        private enum Physique
        {
            Ectomorph = 1,
            Mesomorph,
            Endomorph
        }

        protected Temperament _temp;
        private readonly Physique _phys;

        protected int _weight { get; set; }
        protected string _name { get; set; }
        protected string _surName { get; set; }
        protected string _leatherColor { get; set; }
        protected string _eyeColor { get; set; }
        protected string _intelligentDevelopment { get; set; }
        protected int _age { get; set; }


        public Human(string Name, string SurName)
        {
            _name = Name;
            _surName = SurName;
        }

        public Human(int phys)
        {
            switch (phys)
            {
                case 1: _phys = Physique.Ectomorph; break;
                case 2: _phys = Physique.Endomorph; break;
                case 3: _phys = Physique.Mesomorph; break;
            }
        }

        public void Set(Temperament temp)
        {
            _temp = temp;
        }

        public void ShowTemp()
        {
            int Converting = Convert.ToInt32(_temp);

            switch (Converting)
            {
                case 1: Console.WriteLine("Temperament: Choleric"); break;
                case 2: Console.WriteLine("Temperament: Sanguine"); break;
                case 3: Console.WriteLine("Temperament: Phlegmatic"); break;
                case 4: Console.WriteLine("Temperament: Melancholy"); break;
            }
        }

        public void ShowPhys()
        {
            int Converting = Convert.ToInt32(_phys);

            switch (Converting)
            {
                case 1: Console.WriteLine("Temperament: Choleric"); break;
                case 2: Console.WriteLine("Temperament: Sanguine"); break;
                case 3: Console.WriteLine("Temperament: Phlegmatic"); break;
                case 4: Console.WriteLine("Temperament: Melancholy"); break;
            }
        }

        public void BodyBuilder(int Age, int Weight)
        {
            _age = Age;
            _weight = Weight;
            _leatherColor = "Brown";
            _intelligentDevelopment = "Low";
        }

        public string this[string index]
        {
            get
            {
                switch (index)
                {
                    case "n": return _name;
                    case "s": return _surName;
                    default: return null;
                }

            }
            set
            {
                switch (index)
                {

                    case "n": _name = value; break;
                    case "s": _surName = value; break;
                }
            }
        }

        public virtual void Show()
        {
            Console.WriteLine("It's work");
        }

    }
}
