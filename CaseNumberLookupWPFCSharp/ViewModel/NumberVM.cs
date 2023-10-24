using CaseNumberLookupWPFApp.DataModel;
using CaseNumberLookupWPFApp.Handler;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace CaseNumberLookupWPFApp.ViewModel
{
    public class NumberVM : INotifyPropertyChanged
    {
        #region PrivateProperties
        private NumberDTO data { get; set; }
        private string _input { get; set; }
        #endregion

        #region PrivateCommand
        private ICommand _addCommand;
        private ICommand _sortAscCommand;
        private ICommand _sortDescCommand;
        #endregion

        #region PublicProperties
        public event PropertyChangedEventHandler PropertyChanged;
        public string input {
            get
            {
                return _input;
            }
            set
            {
                _input = value;
                OnPropertyChanged();
            }
        }
        
        public ObservableCollection<int> numbers {
            get
            {
                return new ObservableCollection<int>(data.data);
            }

            set
            {
                data.data = value.ToList();
                OnPropertyChanged();
            }
        }
        #endregion

        #region PublicCommand
        public ICommand addCommand => _addCommand ?? (_addCommand = new CommandHandler(() => add(), () => true));
        public ICommand sortAscCommand => _sortAscCommand ?? (_sortAscCommand = new CommandHandler(() => orderASC(), () => true));
        public ICommand sortDescCommand => _sortDescCommand ?? (_sortDescCommand = new CommandHandler(() => orderDESC(), () => true));
        #endregion

        #region Constructors
        public NumberVM()
        {
            input = string.Empty;
            data = new NumberDTO();
        }
        #endregion

        #region PublicMethods
        public void add()
        {
            try
            {
                this.validate();
                int.TryParse(this.input, out int number);
                this.data.data.Add(number);
                this.numbers = this.data.ToObservable();
                // OnPropertyChanged(name: "numbers");
                this.clearInupt();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void orderASC() => this.numbers = this.data.Sort();

        public void orderDESC() => this.numbers = this.data.Reverse();
        #endregion

        #region PrivateMethods
        private void validate()
        {
            if (string.IsNullOrEmpty(this.input) || string.IsNullOrWhiteSpace(this.input))
                throw new Exception("Please fill the input");

            if (!int.TryParse(this.input, out int number))
                throw new Exception("Numbers only");
        }

        private void clearInupt() => this.input = string.Empty;
        #endregion

        #region Protected
        protected void OnPropertyChanged([CallerMemberName] string name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        #endregion
    }
}
