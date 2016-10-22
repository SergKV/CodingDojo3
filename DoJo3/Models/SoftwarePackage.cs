using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoJo3.Models
{
    public class SoftwarePackage
    {
        public String Name { get; set; }
        public String Group { get; set; }
        
        public double SalePrice { get; set; }
        public double PurchasePrice { get; set; }

        public int Quantity { get; set; }

        public SoftwarePackage(string name, string group, double salePrice, double purchasePrice, int quantity)
        {
            Name = name;
            Group = group;
            SalePrice = salePrice;
            PurchasePrice = purchasePrice;
            Quantity = quantity;
        }
    }
}
