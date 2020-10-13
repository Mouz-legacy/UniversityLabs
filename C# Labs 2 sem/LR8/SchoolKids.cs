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
            First = (NumberofClass)value;
            _ = type1 ? Schooler.MathClass = false : Schooler.MathClass = true;
            _ = type2 ? Schooler.ScienceClass = false : Schooler.ScienceClass = true;
        }

        public override void Show()
        {
            Console.WriteLine($@"Teacher name: {Schooler.TeacherName}
            School name: {Schooler.SchoolName}
            Is attednding Math class: {Schooler.MathClass}
            Is attednding Science class: {Schooler.ScienceClass}
            Number of class: {First}
            Expirience: {_expir}");
        }
    }
}
