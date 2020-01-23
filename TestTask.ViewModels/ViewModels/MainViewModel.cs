using System.Threading.Tasks;
using System.Windows.Input;
using TestTask.ViewModels.Infrastructure;
using TestTask.ViewModels.Services;

namespace TestTask.ViewModels.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        //private readonly IDataService _dataService;
        private readonly IBankNotifyService _notifyService;

        //public ObservableCollection<BankNotifyItemViewModel> BankNotifies { get; }

        public BankNotifyViewModel NotifyViewModel { get; }

        


        public MainViewModel(IBankNotifyService notifyService)//, ObservableCollection<BankNotifyItemViewModel> bankNotifies)
        {
            //_dataService = dataService;
            _notifyService = notifyService;
            NotifyViewModel = new BankNotifyViewModel(notifyService);
            //BankNotifies = bankNotifies;
            //_selectedBankNotify = new BankNotifyItemViewModel();
        }


        public async Task LoadAsync()
        {
            NotifyViewModel.LoadAsync();
        }

        
    }
}
