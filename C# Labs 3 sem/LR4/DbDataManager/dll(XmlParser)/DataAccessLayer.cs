using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbEssense
{
    public class DataAccessLayer : IValidator
    {
        public MuzShopEssence Essence { get; set; }

        public void ValidateModel(MuzShopEssence dbMember, out bool transProgress)
        {
            if (dbMember.Shop.GroupId == dbMember.Group.Id && dbMember.Shop.DeliveryManId == dbMember.Delivery.Id 
            && dbMember.Shop.EmployeId == dbMember.Employe.Id && dbMember.Shop.LocationId == dbMember.Location.Id)
            {
                Essence = dbMember;
                transProgress = true;
            }
            else
            {
                Essence = new MuzShopEssence();
                transProgress = false;
            }
        }
    }
}
