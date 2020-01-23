using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Data.Data;
using TestTask.Data.DataServices;
using TestTask.ViewModels.Models;
using TestTask.ViewModels.Services;

namespace TestTask.App.Services
{
    public class BankNotifyService : IBankNotifyService
    {
        private IDataService _dataService;
        public BankNotifyService(IDataService dataService)
        {
            _dataService = dataService;
        }
        public async Task<int> DeleteAllBankNotifiesAsync()
        {
            return await _dataService.DeleteAllBankNotifiesAsync();
        }

        public async Task<int> DeleteBankNotifyAsync(BankNotifyModel model)
        {
            return await _dataService.DeleteBankNotifyAsync(GenerateBankNotifyDTOFromModel(model));
        }

        public async Task<IList<BankNotifyModel>> GetBankNotifiesAsync()
        {
            var models = new List<BankNotifyModel>();
            var items = await _dataService.GetBankNotifiesAsync();
            foreach(var item in items)
            {
                models.Add(GenerateBankNotifyModelFromDTO(item));
            }
            return models;
        }

        public async Task<int> GetBankNotifiesCountAsync()
        {
            return await _dataService.GetBankNotifiesCountAsync();
        }

        public async Task<BankNotifyModel> GetBankNotifyAsync(long id)
        {
            var dto = await _dataService.GetBankNotifyAsync(id);
            return GenerateBankNotifyModelFromDTO(dto);
        }

        public async Task<int> UpdateBankNotifyAsync(BankNotifyModel model)
        {
            return await _dataService.UpdateBankNotifyAsync(GenerateBankNotifyDTOFromModel(model));
        }

        public async Task Initialize()
        {
            await _dataService.Initialize();
        }

        public async Task<BankNotifyModel> CreateBankNotifyAsync(BankNotifyModel model)
        {
            var newDTO = await _dataService.CreateBankNotifyAsync(GenerateBankNotifyDTOFromModel(model));
            return GenerateBankNotifyModelFromDTO(newDTO);
        }

        public async Task SetBankNotifyReaded(long id)
        {
            await _dataService.SetBankNotifyReaded(id);
        }

        #region static methods
        private static BankNotifyModel GenerateBankNotifyModelFromDTO(BankNotifyDTO dto)
        {
            var model = new BankNotifyModel(dto.Id, dto.BankName, dto.NotifyDescription, dto.DateTimeCreated, dto.IsReaded);
            return model;
        }

        private static BankNotifyDTO GenerateBankNotifyDTOFromModel(BankNotifyModel model)
        {
            var bankNotifyDTO = new BankNotifyDTO
            {
                Id = model.Id,
                IsReaded = model.IsReaded,
                BankName = model.BankName,
                DateTimeCreated = model.DateTimeCreated,
                NotifyDescription = model.NotifyDescription
            };

            return bankNotifyDTO;
        }
        #endregion
    }
}
