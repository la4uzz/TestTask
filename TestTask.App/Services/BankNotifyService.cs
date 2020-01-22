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
        public Task<int> DeleteAllBankNotifiesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteBankNotifyAsync(BankNotifyModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<BankNotifyModel>> GetBankNotifiesAsync()
        {
            var models = new List<BankNotifyModel>();
            var items = await _dataService.GetBankNotifiesAsync();
            foreach(var item in items)
            {
                models.Add(await CreateBankNotifyModel(item));
            }
            return models;
        }

        public Task<int> GetBankNotifiesCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BankNotifyModel> GetBankNotifyAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateBankNotifyAsync(BankNotifyModel model)
        {
            throw new NotImplementedException();
        }

        static public async Task<BankNotifyModel> CreateBankNotifyModel(BankNotifyDTO dto)
        {
            await Task.Delay(100);
            var model = new BankNotifyModel()
            {
                Id = dto.Id,
                BankName = dto.BankName,
                NotifyDescription = dto.NotifyDescription,
                DateTimeCreated = dto.DateTimeCreated,
                IsReaded = dto.IsReaded
            };

            return model;
        }
    }
}
