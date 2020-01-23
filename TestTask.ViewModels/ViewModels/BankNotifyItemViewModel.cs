using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestTask.Data.DataServices;
using TestTask.ViewModels.Infrastructure;
using TestTask.ViewModels.Models;
using TestTask.ViewModels.Services;

namespace TestTask.ViewModels.ViewModels
{
    public class BankNotifyItemViewModel :BaseViewModel
    {
        private readonly IBankNotifyService _notifyService;
        public ICommand SetBankNotifyReaded => new RelayCommand<bool>(SetBankNotifyReadedAsync);
        private async void SetBankNotifyReadedAsync(bool read)
        {
            this.IsReaded = !read;
            await _notifyService.SetBankNotifyReaded(this.Id);
        }

        public long Id { get; }
        public DateTime Created { get; }
        
        public string CreatedTime
        {
            get
            {
                if (DateTime.Now == DateTime.Today)
                    return Created.ToString("HH:mm");
                else
                    return Created.ToString("ddd, HH:mm");
            }
        }

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
        public BankNotifyItemViewModel() 
        {
            
        }
        public BankNotifyItemViewModel(IBankNotifyService notifyService, long id, DateTime created, bool isReaded, string displayName, string description)
        {
            _notifyService = notifyService;
            Id = id;
            Created = created;
            IsReaded = isReaded;
            _displayName = displayName;
            _description = description;
        }
    }
}
