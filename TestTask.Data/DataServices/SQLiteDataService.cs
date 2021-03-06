﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Data.Data;

namespace TestTask.Data.DataServices
{
    /// <summary>
    /// Just example class
    /// </summary>
    public class SQLiteDataService : IDataService
    {
        public async Task Initialize()
        {
            await CheckCreateDatabase();
            await FillTableIfEmpty();
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

        public Task<int> UpdateBankNotifyAsync(BankNotifyDTO dto)
        {
            throw new NotImplementedException();
        }

        private async Task CheckCreateDatabase()
        {
            throw new NotImplementedException();
        }

        private async Task FillTableIfEmpty()
        {
            throw new NotImplementedException();
        }

        public Task<BankNotifyDTO> CreateBankNotifyAsync(BankNotifyDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task SetBankNotifyReaded(long id)
        {
            throw new NotImplementedException();
        }
    }
}
