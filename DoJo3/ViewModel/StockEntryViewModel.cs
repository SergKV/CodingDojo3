using CodingDojo4DataLib;
using CodingDojo4DataLib.Converter;
using DoJo3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoJo3.ViewModel
{
    class StockEntryViewModel : BaseViewModel
    {
        private StockEntry stockEntry;

        private double salesPriceInEuro;

        private double purchasePriceInEuro;

        public StockEntryViewModel(StockEntry entry)
        {
            stockEntry = entry;
            salesPriceInEuro = entry.SoftwarePackage.SalesPrice;
            purchasePriceInEuro = entry.SoftwarePackage.PurchasePrice;
        }

        public void CalculateSalesPriceFromEuro(Currencies currency)
        {
            this.SalesPrice = CurrencyConverter.ConvertFromEuroTo(currency, salesPriceInEuro);
            this.PurchasePrice = CurrencyConverter.ConvertFromEuroTo(currency, purchasePriceInEuro);
        }

        public string Name
        {
            get { return stockEntry.SoftwarePackage.Name; }
            set
            {
                stockEntry.SoftwarePackage.Name = value;
                OnChange("Name");
            }
        }
        public double SalesPrice
        {
            get { return stockEntry.SoftwarePackage.SalesPrice; }
            set
            {
                stockEntry.SoftwarePackage.SalesPrice = value;
                OnChange("SalesPrice");
            }
        }

        public double PurchasePrice
        {
            get { return stockEntry.SoftwarePackage.PurchasePrice; }
            set
            {
                stockEntry.SoftwarePackage.PurchasePrice = value;
                OnChange("PurchasePrice");
            }
        }


        public string Category
        {
            get { return stockEntry.SoftwarePackage.Category.Name; }
            set
            {
                stockEntry.SoftwarePackage.Category.Name = value;
                OnChange("Category");
            }
        }

        public int OnStock
        {
            get { return stockEntry.Amount; }
            set
            {
                stockEntry.Amount = value;
                OnChange("OnStock");
            }
        }

    }
}
