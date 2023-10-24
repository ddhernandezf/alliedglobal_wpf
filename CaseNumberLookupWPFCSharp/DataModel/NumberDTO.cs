using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CaseNumberLookupWPFApp.DataModel
{
    public class NumberDTO
    {
        public List<int> data { get; set; }

        public NumberDTO()
        {
            data = new List<int>();
        }

        public ObservableCollection<int> ToObservable() => new ObservableCollection<int>(data);

        public ObservableCollection<int> Sort()
        {
            data.Sort();
            return this.ToObservable();
        }

        public ObservableCollection<int> Reverse()
        {
            data.Reverse();
            return this.ToObservable();
        }
    }
}
