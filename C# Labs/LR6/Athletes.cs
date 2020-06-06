using System;
using System.Collections.Generic;
using System.Text;

namespace LAB5
{
    class Athletes : Human
    {
        private struct Charackters
        {
            public string _Country;
            public string _Sporttype;
        }

        Charackters ForAll;
        public string _Country { get; set; }
        protected string _Sporttype { get; set; }

        public Athletes(string a, string b, int c) : base(a, b)
        {
            ForAll._Country = a;
            ForAll._Sporttype = b;
            _expir = c;
        }

        public void ShowInfo()
        {
            Console.WriteLine($@"Country: {ForAll._Country} 
            Type Of Sport: {ForAll._Sporttype}
            Expirience: {_expir}");
        }
    }
}
