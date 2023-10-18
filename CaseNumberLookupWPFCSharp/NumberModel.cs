using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CaseNumberLookupWPFApp
{
    public class NumberModel
    {
        public List<int> data { get; set; }

        public ObservableCollection<int> Sort()
        {
            this.data.Sort();
            return new ObservableCollection<int>(this.data);
        }

        public ObservableCollection<int> Reverse()
        {
            this.data.Reverse();
            return new ObservableCollection<int>(this.data);
        }
    }
}
