using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace to_do.Model
{
    public class Tasks : INotifyPropertyChanged
    {
        private int _amount;
        public int Id { get; set; }

        public string Task { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
    
        public int Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                OnPropertyChanged(nameof(Amount));

            }
        }

        

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    
}
