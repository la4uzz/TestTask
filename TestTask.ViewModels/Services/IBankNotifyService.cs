using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.ViewModels.Models;

namespace TestTask.ViewModels.Services
{
    public interface IBankNotifyService
    {
        Task<BankNotifyModel> GetBankNotifyAsync(long id);
        Task<IList<BankNotifyModel>> GetBankNotifiesAsync();
        Task<int> GetBankNotifiesCountAsync();
        Task<int> UpdateBankNotifyAsync(BankNotifyModel model);
        Task<int> DeleteBankNotifyAsync(BankNotifyModel model);
        Task<int> DeleteAllBankNotifiesAsync();
    }
}
