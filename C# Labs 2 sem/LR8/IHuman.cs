using System;
using System.Collections.Generic;
using System.Text;

namespace LAB5
{
    interface IHuman
    {
        int _weight { get; set; }
        string _name { get; set; }
        string _surName { get; set; }
        string _leatherColor { get; set; }
        string _eyeColor { get; set; }
        string _intelligentDevelopment { get; set; }
        int _age { get; set; }
        int _expir { get; set; }
        void ShowTemp();
        void ShowPhys();
        void Show();
    }
}
