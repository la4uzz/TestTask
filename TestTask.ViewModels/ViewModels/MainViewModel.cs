using System.Threading.Tasks;
using System.Windows.Input;
using TestTask.ViewModels.Infrastructure;
using TestTask.ViewModels.Services;

namespace TestTask.ViewModels.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IBankNotifyService _notifyService;

        public BankNotifyViewModel NotifyViewModel { get; }

        public MainViewModel(IBankNotifyService notifyService)
        {
            _notifyService = notifyService;
            NotifyViewModel = new BankNotifyViewModel(notifyService);
        }

        public async Task LoadAsync()
        {
            NotifyViewModel.LoadAsync();
        }

        
    }
}
