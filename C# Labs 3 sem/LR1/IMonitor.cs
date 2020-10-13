using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    interface IMonitor
    {
        string Model { get; }
        string Company { get; }
        int Id { get; }
        void ChangeModel(string newModel);
        void ChangeId(int newId);
        void ChangeCompany(string newCompany);
    }
}
