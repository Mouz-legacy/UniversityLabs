using System;
using System.Collections.Generic;
using System.Text;

namespace LAB5
{
    class Athletes : Human
    {
        private struct Charackters
        {
            public int _Expirience;
            public string _Country;
            public string _Sporttype;
        }
        Charackters ForAll;
        protected int _Expirience { get; set; }
        public string _Country { get; set; }
        protected string _Sporttype { get; set; }

        public Athletes(string a, string b, int c) : base(a, b)
        {
            ForAll._Country = a;
            ForAll._Sporttype = b;
            ForAll._Expirience = c;
        }


        public void ShowInfo()
        {
            Console.WriteLine($@"Country: {ForAll._Country} 
Type Of Sport: {ForAll._Sporttype}
Expirience: {ForAll._Expirience}");
        }

    }
}
