using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestTask.Data.Data;
using TestTask.Data.DataServices;
using TestTask.ViewModels.Infrastructure;

namespace TestTask.ViewModels.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IDataService _dataService;
        private BankNotifyItemViewModel _selectedBankNotify;
        public ObservableCollection<BankNotifyItemViewModel> BankNotifies { get; }

        public ICommand SaveBankNotifyCommand => new RelayCommand<BankNotifyItemViewModel>(SaveBankNotifyAsync);
        public ICommand AddNewBankNotifyCommand => new RelayCommand(AddEmptySelectedValue);
        public ICommand DeleteBankNotifyCommand => new RelayCommand(DeleteBankNotifyAsync);
        
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
            _selectedBankNotify = new BankNotifyItemViewModel();
            this.PropertyChanged += MainViewModel_PropertyChanged;
        }

        private async void MainViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch(e.PropertyName)
            {
                case "IsReaded":
                    await _dataService.upda
                    break;
            }
        }

        public async Task Load()
        {
            await _dataService.Initialize();
            
            var notifies = await _dataService.GetBankNotifiesAsync();
            foreach (var notify in notifies)
            {
                BankNotifies.Add(GenerateBankNotifyItemModel(notify));
            }
        }

        public async void SaveBankNotifyAsync(BankNotifyItemViewModel model)
        {
            if (_selectedBankNotify.Id == 0)
            {
                if (String.IsNullOrWhiteSpace(model.DisplayName) && String.IsNullOrWhiteSpace(model.Description))
                    return;
             
                var dto = await _dataService.CreateBankNotifyAsync(GenerateBankNotifyDTO(_selectedBankNotify));
                BankNotifies.Add(GenerateBankNotifyItemModel(dto));
            }
            else
            {
                await _dataService.UpdateBankNotifyAsync(GenerateBankNotifyDTO(model));
            }
        }

        public async void AddEmptySelectedValue()
        {
            SelectedBankNotify = new BankNotifyItemViewModel();
        }

        public async void DeleteBankNotifyAsync()
        {
            if(_selectedBankNotify.Id!=0)
            {
                await _dataService.DeleteBankNotifyAsync(GenerateBankNotifyDTO(_selectedBankNotify));
                BankNotifies.Remove(_selectedBankNotify);
                SelectedBankNotify = new BankNotifyItemViewModel();
            }
        }

        public async void SetBankNotifyReadedAsync(long id)
        {
        }

        #region static methods
        private static BankNotifyDTO GenerateBankNotifyDTO(BankNotifyItemViewModel model)
        {
            return new BankNotifyDTO
            {
                BankName = model.DisplayName,
                NotifyDescription = model.Description,
                DateTimeCreated = model.Created,
                Id = model.Id,
                IsReaded = model.IsReaded
            };
        }

        private static BankNotifyItemViewModel GenerateBankNotifyItemModel(BankNotifyDTO dto)
        {
            return new BankNotifyItemViewModel(dto.Id, dto.DateTimeCreated, dto.IsReaded, dto.BankName, dto.NotifyDescription);
        }
        #endregion
    }
}
