using System;
using System.Collections.Generic;
using System.Text;

namespace LAB5
{
    class DrugsAddicts : Human
    {
        public DrugsAddicts(string time, string Type) : base(time, Type)
        {
            Everyone._DependencyTime = Convert.ToInt32(time);
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
            public int _DependencyTime;
            public Drugs _BeginType;
            public Drugs _TodayType;
        }

        public void SetType(Drugs value, Drugs value2)
        {
            Everyone._BeginType = value;
            Everyone._TodayType = value2;
        }
        public Characteristics Everyone;

        public void ShowInfo()
        {
            int converting = Convert.ToInt32(Everyone._BeginType);
            switch (converting)
            {
                case 1: Console.WriteLine("Begin Drug type: opium"); break;
                case 2: Console.WriteLine("Begin Drug type: cannabis"); break;
                case 3: Console.WriteLine("Begin Drug type: amphetamine"); break;
                case 4: Console.WriteLine("Begin Drug type: ecstasy"); break;
            }

            converting = Convert.ToInt32(Everyone._TodayType);
            switch (converting)
            {
                case 1: Console.WriteLine("Drug type: opium"); break;
                case 2: Console.WriteLine("Drug type: cannabis"); break;
                case 3: Console.WriteLine("Drug type: amphetamine"); break;
                case 4: Console.WriteLine("Drug type: ecstasy"); break;
            }

            Console.WriteLine($"Expirience: {Everyone._DependencyTime}");
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
