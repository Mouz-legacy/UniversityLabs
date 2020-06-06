using System;
using System.Collections.Generic;
using System.Text;

namespace LAB5
{
    class Schoolkids : Human
    {
        public Schoolkids(string a, string b) : base(a, b)
        {
            Schooler.TeacherName = a;
            Schooler.SchoolName = b;
        }

        public struct Abilities
        {
            public bool MathClass;
            public bool ScienceClass;
            public string TeacherName;
            public string SchoolName;
        }

        Abilities Schooler;


        enum NumberofClass
        {
            A = 1,
            B,
            C
        }

        NumberofClass First;


        public void SetClass(int value, bool type1, bool type2)
        {
            int Switcher = value;
            switch (Switcher)
            {
                case 1: First = NumberofClass.A; break;
                case 2: First = NumberofClass.B; break;
                case 3: First = NumberofClass.C; break;
            }

            _ = type1 ? Schooler.MathClass = false : Schooler.MathClass = true;
            _ = type2 ? Schooler.ScienceClass = false : Schooler.ScienceClass = true;
        }

        public override void Show()
        {
            Console.WriteLine($@"Teacher name: {Schooler.TeacherName}
School name: {Schooler.SchoolName}
Is attednding Math class: {Schooler.MathClass}
Is attednding Science class: {Schooler.ScienceClass}");
            switch (First)
            {
                case NumberofClass.A: Console.WriteLine("Attend A class"); break;
                case NumberofClass.B: Console.WriteLine("Attend B class"); break;
                case NumberofClass.C: Console.WriteLine("Attend C class"); break;
            }
        }
    }
}
