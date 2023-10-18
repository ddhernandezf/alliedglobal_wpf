using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace CaseNumberLookupWPFApp
{
    public class NumberViewModel : INotifyPropertyChanged
    {
        private NumberModel model { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public string input { get; set; }
        public ObservableCollection<int> numbers { get; set; }

        public NumberViewModel(Button addButton, Button ascButton, Button descButton)
        {
            this.model = new NumberModel();
            addButton.Click += add;
            ascButton.Click += orderASC;
            descButton.Click += orderDESC;
        }

        public void add(object sender, RoutedEventArgs e)
        {
            try {
                this.validate();
                int.TryParse(this.input, out int number);
                this.numbers.Add(number);
                OnPropertyChanged(name: "numbers");
                this.clearInupt();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        public void orderASC(object sender, RoutedEventArgs e)
        {
            this.model.data = this.numbers.ToList();
            this.numbers = this.model.Sort();
            OnPropertyChanged(name: "numbers");
        }

        public void orderDESC(object sender, RoutedEventArgs e)
        {
            this.model.data = this.numbers.ToList();
            this.numbers = this.model.Reverse();
            OnPropertyChanged(name: "numbers");
        }

        private void validate()
        {
            if (string.IsNullOrEmpty(this.input) || string.IsNullOrWhiteSpace(this.input))
                throw new Exception("Please fill the input");

            if (!int.TryParse(this.input, out int number))
                throw new Exception("Numbers only");
        }

        private void clearInupt()
        {
            this.input = string.Empty;
            OnPropertyChanged(name: "input");
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
