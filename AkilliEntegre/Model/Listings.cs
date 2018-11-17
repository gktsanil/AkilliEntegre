using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkilliEntegre.Model
{
    class Listings
    {

        public String UniqueIdentifier { get; set; }
        public String HBSku { get; set; }
        public String MerchantSku { get; set; }
        public String ProductName { get; set; }
        public String Price { get; set; }
        public String AvailableStock { get; set; }
        public String DispatchTime { get; set; }
        public List<String> CargoCompany { get; set; }
        public String MaxPurchasableQuantity { get; set; }
    }
}
