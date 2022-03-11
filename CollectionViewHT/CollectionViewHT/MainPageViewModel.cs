using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CollectionViewHT
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public string HeaderText { get; set; } = "This is an Collection view header";

        private ObservableCollection<CustomerModel> _customerList;
        public ObservableCollection<CustomerModel> CustomerList
        {
            get
            {
                return _customerList;
            }
            set
            {
                _customerList = value;
                NotifyPropertyChanged();
            }
        }

        private bool _isHeaderVisible = true;
        public bool IsHeaderVisible
        {
            get
            {
                return _isHeaderVisible;
            }
            set
            {
                _isHeaderVisible = value;
                NotifyPropertyChanged();
            }
        }

        private int _headerHeight = 150;
        public int HeaderHeight
        {
            get
            {
                return _headerHeight;
            }
            set
            {
                _headerHeight = value;
                NotifyPropertyChanged();
            }
        }
        public ICommand ShowHideHeaderCommand { private set; get; }
        public MainPageViewModel()
        {
            CustomerList = new ObservableCollection<CustomerModel>
            {
                new CustomerModel{Name ="Person 1"},
                new CustomerModel{Name ="Person 2"},
                new CustomerModel{Name ="Person 3"},
                new CustomerModel{Name ="Person 4"},
                new CustomerModel{Name ="Person 5"},
            };
            ShowHideHeaderCommand = new Command(() =>
            {
                IsHeaderVisible = !IsHeaderVisible;
                HeaderHeight = IsHeaderVisible ? 150 : 0;
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class CustomerModel
    {
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
