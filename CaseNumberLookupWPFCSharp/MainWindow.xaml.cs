using System.Collections.ObjectModel;
using System.Windows;

namespace CaseNumberLookupWPFApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NumberViewModel model = new NumberViewModel(this.addButton, this.ascButton, this.descButton);

            model.numbers = new ObservableCollection<int>() { 2, 23, 12, 44 };
            this.DataContext = model;
        }
    }
}
