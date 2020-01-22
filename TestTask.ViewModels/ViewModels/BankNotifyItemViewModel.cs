using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestTask.ViewModels.Infrastructure;
using TestTask.ViewModels.Models;
using TestTask.ViewModels.Services;

namespace TestTask.ViewModels.ViewModels
{
    public class BankNotifyItemViewModel :BaseViewModel
    {
        public ICommand SetBankNotifyReaded => new RelayCommand<bool>((r)=> { IsReaded = r; });

        public long Id { get; }
        public DateTime Created { get; }
        
        private bool _isReaded;
        public bool IsReaded {
            get { return _isReaded; }
            set
            {
                _isReaded = value;
                OnPropertyChanged();
            }
        }

        private string _displayName;
        public string DisplayName {
            get { return _displayName; }
            set 
            { 
                _displayName = value;
                OnPropertyChanged();
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }
        public BankNotifyItemViewModel() { }
        public BankNotifyItemViewModel(long id, DateTime created, bool isReaded, string displayName, string description)
        {
            Id = id;
            Created = created;
            IsReaded = isReaded;
            _displayName = displayName;
            _description = description;
        }
    }
}
