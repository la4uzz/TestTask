using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.ViewModels.Services;

namespace TestTask.ViewModels.ViewModels
{
    public class BankNotifyViewModel : BaseViewModel
    {
        private IBankNotifyService _notifyService;
        public BankNotifyViewModel(IBankNotifyService notifyService)
        {
            _notifyService = notifyService;
            BankNotifies = new ObservableCollection<BankNotifyItemViewModel>();
        }

        public ObservableCollection<BankNotifyItemViewModel> BankNotifies { get; set; }

        public async Task LoadNotifies()
        {
            var notifies = await _notifyService.GetBankNotifiesAsync();
            foreach(var notify in notifies)
            {
                BankNotifies.Add(new BankNotifyItemViewModel(notify.Id, notify.DateTimeCreated, notify.IsReaded, notify.BankName, notify.NotifyDescription));
            }
        }
    }
}
