using System;
using System.Collections.Generic;
using System.Text;

namespace LAB5
{
    class Human : IHuman, IComparable<Human>
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

        public Human(int temp, int age)
        {
            _age = age;
            switch (temp)
            {
                case 1: _temp = Temperament.Choleric; break;
                case 2: _temp = Temperament.Sanguine; break;
                case 3: _temp = Temperament.Phlegmatic; break;
                case 4: _temp = Temperament.Melancholy; break;
            }
        }

        protected Temperament _temp;
        private readonly Physique _phys;
        public int _weight { get; set; }
        public string _name { get; set; }
        public string _surName { get; set; }
        public string _leatherColor { get; set; }
        public string _eyeColor { get; set; }
        public string _intelligentDevelopment { get; set; }
        public int _age { get; set; }
        public int _expir { get; set; }

        public void ShowTemp()
        {
            Console.WriteLine($"Temperament: {_temp}");
        }

        public void ShowPhys()
        {
            Console.WriteLine($"Physique {_phys}");
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
            Console.WriteLine($"Name: {_name}" +
            $"\n Surname {_surName}" +
            $"\n Expirience {_expir}");
        }

        public int CompareTo(Human one)
        {
                return _expir.CompareTo(one._expir);
        }
    }
}
