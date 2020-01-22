using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Data.Data;

namespace TestTask.Data.DataServices
{
    public class SQLiteDataService : IDataService
    {
        private SQLiteAsyncConnection _db;

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
            var dir = Path.Combine(Environment.CurrentDirectory, "db");

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            _db = new SQLiteAsyncConnection(Path.Combine(dir, "db.sqlite"));

            await _db.CreateTableAsync<BankNotifyDTO>();
        }

        private async Task FillTableIfEmpty()
        {
            var counter = await _db.ExecuteScalarAsync<int>("SELECT COUNT(*) As Result FROM BankNotifyDTO");

            if (counter == 0)
            {
                await _db.InsertAsync(new BankNotifyDTO{ Id = 1, BankName = "ВТБ", DateTimeCreated = DateTime.Parse("2019-01-10"), IsReaded = false, NotifyDescription = "Данные загружены в систему" });
                await _db.InsertAsync(new BankNotifyDTO { Id = 2, BankName = "Сбербанк", DateTimeCreated = DateTime.Parse("2019-01-11"), IsReaded = true, NotifyDescription = "Данные загружены в систему" });
                await _db.InsertAsync(new BankNotifyDTO { Id = 3, BankName = "Газпромбанк", DateTimeCreated = DateTime.Parse("2019-01-12"), IsReaded = false, NotifyDescription = "Данные загружены в систему" });
                await _db.InsertAsync(new BankNotifyDTO { Id = 4, BankName = "Точка", DateTimeCreated = DateTime.Parse("2019-01-13"), IsReaded = true, NotifyDescription = "Данные загружены в систему" });
                await _db.InsertAsync(new BankNotifyDTO { Id = 5, BankName = "Открытие", DateTimeCreated = DateTime.Parse("2019-01-14"), IsReaded = false, NotifyDescription = "Данные загружены в систему" });
            }
        }
    }
}
