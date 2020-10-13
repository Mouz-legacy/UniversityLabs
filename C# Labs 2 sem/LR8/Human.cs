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

        public delegate void ShowHelp(string message);
        public event ShowHelp Notify;
        public delegate void Helper();
        ShowHelp _del;
        private int _sum; // Переменная для хранения суммы

        public void SetSum(int sum)
        {
            _sum = sum;
        }

        public int CurrentSum
        {
            get => _sum;
        }

        public void Put(int sum)
        {
            _sum += sum;
        }

        public void Withdraw(int sum)
        {
            if (sum <= _sum)
            {
                _sum -= sum;

                if (_del != null)
                    _del($"Сумма {sum} снята со счета");
            }
            else
            {
                _del?.Invoke("Недостаточно денег на счете");
            }
        }

        public void ShowDelInfo(ShowHelp del)
        {
            _del = del;
        }

        public Human(string Name, string SurName)
        {
            _name = Name;
            _surName = SurName;
        }

        public Human(int phys)
        {
            if (phys > 3 || phys < 1)
                throw new Exception("Wrong enter");
            _phys = (Physique)phys;
        }

        public Human(int temp, int age)
        {
            if(age >= _minimal)
            {
                Notify?.Invoke($"Your age is normal, value set{_age}");
                _age = age;
            }
            if (temp > 4 || temp < 1)
                throw new Exception("Wrong enter");
            _temp = (Temperament)temp;
            Notify += _name => Console.ForegroundColor = ConsoleColor.Red; 
        }

        protected Temperament _temp;
        private readonly Physique _phys;
        private readonly int _minimal = 0;
        public int _weight { get; set; }
        public string _name { get; set; }
        public string _surName { get; set; }
        public string _leatherColor { get; set; }
        public string _eyeColor { get; set; }
        public string _intelligentDevelopment { get; set; }
        public int _age { get; set; }
        public int _expir { get; set; }

        public int Minimal
        {
            get => _minimal;
        }
        public void ShowTemp()
        {
            Console.WriteLine($"Temperament: {_temp}");
        }

        public void ShowPhys()
        {
            Helper help = () => Console.WriteLine($"Physique {_phys}");
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
            if(one != null)
                 return _expir.CompareTo(one._expir);
            else
                throw new Exception("Unable to compare these objects");
        }
    }

}
