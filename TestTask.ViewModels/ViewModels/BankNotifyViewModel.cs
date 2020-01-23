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
    public class BankNotifyViewModel : BaseViewModel
    {
        private readonly IBankNotifyService _notifyService;
        public ObservableCollection<BankNotifyItemViewModel> BankNotifies { get; }
        public ICommand SaveBankNotifyCommand => new RelayCommand<BankNotifyItemViewModel>(SaveBankNotifyAsync);
        public ICommand AddNewBankNotifyCommand => new RelayCommand(AddEmptySelectedValue);
        public ICommand DeleteBankNotifyCommand => new RelayCommand(DeleteBankNotifyAsync);
        public ICommand DeleteAllBankNotifyCommand => new RelayCommand(DeleteAllBankNotifyAsync);

        private BankNotifyItemViewModel _selectedBankNotify;
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
        public BankNotifyViewModel(IBankNotifyService notifyService)
        {
            _notifyService = notifyService;
            BankNotifies = new ObservableCollection<BankNotifyItemViewModel>();
            SelectedBankNotify = new BankNotifyItemViewModel();
        }

        public async void LoadAsync()
        {
            await _notifyService.Initialize();

            var notifies = await _notifyService.GetBankNotifiesAsync();
            foreach (var notify in notifies)
            {
                BankNotifies.Add(GenerateBankNotifyItemViewModelFromModel(notify));
            }
        }

        public async void SaveBankNotifyAsync(BankNotifyItemViewModel model)
        {
            if (_selectedBankNotify.Id == 0)
            {
                if (String.IsNullOrWhiteSpace(model.DisplayName) && String.IsNullOrWhiteSpace(model.Description))
                    return;

                var notifyModel = await _notifyService.CreateBankNotifyAsync(GenereateBankNotifyModelFromViewModel(model));
                BankNotifies.Add(GenerateBankNotifyItemViewModelFromModel(notifyModel));
                SelectedBankNotify = new BankNotifyItemViewModel();
            }
            else
            {
                await _notifyService.UpdateBankNotifyAsync(GenereateBankNotifyModelFromViewModel(_selectedBankNotify));
            }
        }

        public void AddEmptySelectedValue()
        {
            SelectedBankNotify = new BankNotifyItemViewModel();
        }

        public async void DeleteBankNotifyAsync()
        {
            if(_selectedBankNotify.Id!=0)
            {
                await _notifyService.DeleteBankNotifyAsync(GenereateBankNotifyModelFromViewModel(_selectedBankNotify));
                BankNotifies.Remove(_selectedBankNotify);
                SelectedBankNotify = new BankNotifyItemViewModel();
            }
        }

        public async void DeleteAllBankNotifyAsync()
        {
            await _notifyService.DeleteAllBankNotifiesAsync();
            BankNotifies.Clear();
            SelectedBankNotify = new BankNotifyItemViewModel();
        }

        private BankNotifyItemViewModel GenerateBankNotifyItemViewModelFromModel(BankNotifyModel model)
        {
            return new BankNotifyItemViewModel(_notifyService, model.Id, model.DateTimeCreated, model.IsReaded, model.BankName, model.NotifyDescription);
        }

        private static BankNotifyModel GenereateBankNotifyModelFromViewModel(BankNotifyItemViewModel viewModel)
        {
            return new BankNotifyModel(viewModel.Id, viewModel.DisplayName, viewModel.Description, viewModel.Created, viewModel.IsReaded);
        }
    }
}
