using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Data.DataServices;

namespace TestTask.ViewModels.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IDataService _dataService;
        private BankNotifyItemViewModel _selectedBankNotify;
        public ObservableCollection<BankNotifyItemViewModel> BankNotifies { get; }

        public BankNotifyItemViewModel SelectedBankNotify
        {
            get { return _selectedBankNotify; }
            set
            {
                if (Equals(value, _selectedBankNotify))
                    return;

                _selectedBankNotify = value;
                OnPropertyChanged();
            }
        }
        public MainViewModel(IDataService dataService, ObservableCollection<BankNotifyItemViewModel> bankNotifies)
        {
            _dataService = dataService;
            BankNotifies = bankNotifies;
        }

        public async Task Load()
        {
            await _dataService.Initialize();
            
            var notifies = await _dataService.GetBankNotifiesAsync();
            foreach (var notify in notifies)
            {
                BankNotifies.Add(new BankNotifyItemViewModel(notify.Id, notify.DateTimeCreated, notify.IsReaded, notify.BankName, notify.NotifyDescription));
            }
        }
    }
}
