using CodingDojo4DataLib;
using CodingDojo4DataLib.Converter;
using DoJo3.Commands;
using DoJo3.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoJo3.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        public Array Currencies
        {
            get { return Enum.GetValues(typeof(Currencies)); }
        }

        public Currencies SelectedCurrency
        {
            get { return selectedCurrency; }
            set {
                selectedCurrency = value;
                OnChange("SelectedCurrency");
                StartConvertion();
            }
        }

        private void StartConvertion()
        {
            foreach (var item in Items)
            {
                item.CalculateSalesPriceFromEuro(SelectedCurrency);
            }
        }

        private List<StockEntry> stock;
        private ObservableCollection<StockEntryViewModel> items = new ObservableCollection<StockEntryViewModel>();
        private Currencies selectedCurrency;

        public ObservableCollection<StockEntryViewModel> Items
        {
            get { return items; }
            set { items = value; }
        }
        
        public MainViewModel()
        {
            SampleManager manager = new SampleManager();
            stock = manager.CurrentStock.OnStock;

            foreach(var item in manager.CurrentStock.OnStock)
            {
                Items.Add(new StockEntryViewModel(item));
            }

            AddCommand = new RelayCommand(AddNewRow, CanExecute);

            DeleteCommand = new RelayCommand(DeleteSelected, CanExecute);
        }


        private bool CanExecute()
        {
            return true;
        }


        public RelayCommand AddCommand { get; set; }
        public void AddNewRow()
        {
            var current = Items.IndexOf(SelectedRow);
            var next = current + 1;
            var entry = new StockEntry
            {
                SoftwarePackage = new Software(""),
                Amount = 0
            };

            entry.SoftwarePackage.Name = "";
            entry.SoftwarePackage.PurchasePrice = 0;
            entry.SoftwarePackage.SalesPrice = 0;

            entry.SoftwarePackage.Category = new Group
            {
                Name = "",
                Software = new List<Software>()
            };

            Items.Insert(next, new StockEntryViewModel(entry));
        }

        private StockEntryViewModel selectedRow;

        public StockEntryViewModel SelectedRow
        {
            get { return selectedRow; }
            set
            {
                selectedRow = value;
                OnChange("SelectedRow");
            }
        }

        public RelayCommand DeleteCommand { get; set; }

        private void DeleteSelected()
        {
           
            if (SelectedRow != null)
            {
                Items.Remove(SelectedRow);
            }
        }
    }
}
