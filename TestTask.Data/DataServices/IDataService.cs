using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Data.Data;

namespace TestTask.Data.DataServices
{
    public interface IDataService
    {
        Task Initialize();
        Task<BankNotifyDTO> GetBankNotifyAsync(long id);
        Task<IList<BankNotifyDTO>> GetBankNotifiesAsync();
        Task<int> GetBankNotifiesCountAsync();
        Task<int> UpdateBankNotifyAsync(BankNotifyDTO dto);
        Task<int> DeleteBankNotifyAsync(BankNotifyDTO dto);
        Task<int> DeleteAllBankNotifiesAsync();
    }
}
