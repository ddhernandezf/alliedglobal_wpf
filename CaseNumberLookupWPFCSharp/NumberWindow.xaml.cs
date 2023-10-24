using CaseNumberLookupWPFApp.ViewModel;
using System.Collections.ObjectModel;
using System.Windows;

namespace CaseNumberLookupWPFApp
{
    public partial class NumberWindow : Window
    {
        NumberVM model = new NumberVM();

        public NumberWindow()
        {
            InitializeComponent();

            model.numbers = new ObservableCollection<int>() { 2, 23, 12, 44 };
            this.DataContext = model;
        }
    }
}
