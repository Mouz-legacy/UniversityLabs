using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbEssense
{
    interface IValidator
    {
        void ValidateModel(MuzShopEssence dbMember, out bool transProgress);
    }
}
