using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Data.Data;

namespace TestTask.Data.DataServices
{
    /// <summary>
    /// Just example class
    /// </summary>
    public class MSSQLDataService : IDataService
    {
        public Task<BankNotifyDTO> CreateBankNotifyAsync(BankNotifyDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAllBankNotifiesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteBankNotifyAsync(BankNotifyDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<IList<BankNotifyDTO>> GetBankNotifiesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> GetBankNotifiesCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BankNotifyDTO> GetBankNotifyAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task Initialize()
        {
            throw new NotImplementedException();
        }

        public Task SetBankNotifyReaded(long id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateBankNotifyAsync(BankNotifyDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
