using System;
using System.Collections.Generic;
using System.Text;

namespace LAB5
{
    class DrugsAddicts : Human
    {
        public DrugsAddicts(string time, string Type) : base(time, Type)
        {
            _expir = Convert.ToInt32(time);
        }

        public enum Drugs
        {
            Opium = 1,
            Cannabis,
            Amphetamine,
            Ecstasy,
        }

        public struct Characteristics
        {
            public Drugs _BeginType;
            public Drugs _TodayType;
        }

        public Characteristics Everyone;

        public void SetType(Drugs value, Drugs value2)
        {
            Everyone._BeginType = value;
            Everyone._TodayType = value2;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Expirience: {_expir}" +
            $"Today type: {Everyone._TodayType}" +
            $"Begin type: {Everyone._BeginType}");
        }

        public Drugs this[int index]
        {
                get
                {
                    switch (index)
                    {
                        case 1: return Drugs.Opium;
                        case 2: return Drugs.Cannabis;
                        case 3: return Drugs.Amphetamine;
                        case 4: return Drugs.Ecstasy;
                        default: return 0;
                    }
                }
                set
                {
                    switch (index)
                    {
                    case 1: Everyone._BeginType = value; break;
                    case 2: Everyone._BeginType = value; break;
                    case 3: Everyone._BeginType = value; break;
                    case 4: Everyone._BeginType = value; break;
                    }
                }
        }

    }
}
