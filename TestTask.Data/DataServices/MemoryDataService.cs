using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Data.Data;

namespace TestTask.Data.DataServices
{
    public class MemoryDataService : IDataService
    {
        private List<BankNotifyDTO> _bankNotifies;

        public async Task Initialize()
        {
            await Task.Delay(100);
            _bankNotifies = new List<BankNotifyDTO>
            {
                new BankNotifyDTO{ Id=1, BankName="ВТБ", DateTimeCreated=DateTime.Parse("2019-01-10"), IsReaded=false, NotifyDescription="Данные загружены в систему" },
                new BankNotifyDTO{ Id=2, BankName="Сбербанк", DateTimeCreated=DateTime.Parse("2019-01-11"), IsReaded=true, NotifyDescription="Данные загружены в систему" },
                new BankNotifyDTO{ Id=3, BankName="Газпромбанк", DateTimeCreated=DateTime.Parse("2019-01-12"), IsReaded=false, NotifyDescription="Данные загружены в систему" },
                new BankNotifyDTO{ Id=4, BankName="Точка", DateTimeCreated=DateTime.Parse("2019-01-13"), IsReaded=true, NotifyDescription="Данные загружены в систему" },
                new BankNotifyDTO{ Id=5, BankName="Открытие", DateTimeCreated=DateTime.Parse("2019-01-14"), IsReaded=false, NotifyDescription="Данные загружены в систему" }
            };
        }

        public MemoryDataService()
        {
            
        }
        public Task<int> DeleteAllBankNotifiesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteBankNotifyAsync(BankNotifyDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<BankNotifyDTO>> GetBankNotifiesAsync()
        {
            await Task.Delay(100);
            return _bankNotifies;
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
    }
}
