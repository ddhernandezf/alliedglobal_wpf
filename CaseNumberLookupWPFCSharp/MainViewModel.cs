using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CaseNumberLookupWPFApp
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;        

    }

    class SimpleDelegateCommand : ICommand
    {
        Action<object> _executeDelegateParam;
        Action _executeDelegate;

        public SimpleDelegateCommand(Action executeDelegate)
        {

            _executeDelegate = executeDelegate;

        }

        public SimpleDelegateCommand(Action<object> executeDelegate)
        {

            _executeDelegateParam = executeDelegate;

        }

        public void Execute(object parameter)
        {

            if (_executeDelegate == null)
                _executeDelegateParam(parameter);
            else
                _executeDelegate();

        }


        public bool CanExecute(object parameter) { return true; }

        public event EventHandler CanExecuteChanged;
    }

}
