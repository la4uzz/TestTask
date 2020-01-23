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
                new BankNotifyDTO{ Id=1, BankName="ВТБ", DateTimeCreated=DateTime.Parse("2019-01-10 09:11:01"), IsReaded=false, NotifyDescription="Данные загружены в систему" },
                new BankNotifyDTO{ Id=2, BankName="Сбербанк", DateTimeCreated=DateTime.Parse("2019-01-11 12:01:15"), IsReaded=true, NotifyDescription="Данные загружены в систему" },
                new BankNotifyDTO{ Id=3, BankName="Газпромбанк", DateTimeCreated=DateTime.Parse("2019-01-12 18:19:23"), IsReaded=false, NotifyDescription="Данные загружены в систему" },
                new BankNotifyDTO{ Id=4, BankName="Точка", DateTimeCreated=DateTime.Parse("2019-01-13 23:00:01"), IsReaded=true, NotifyDescription="Данные загружены в систему" },
                new BankNotifyDTO{ Id=5, BankName="Открытие", DateTimeCreated=DateTime.Parse("2019-01-14 10:51:30"), IsReaded=false, NotifyDescription="Данные загружены в систему" }
            };
        }

        public MemoryDataService() { }

        public async Task<BankNotifyDTO> CreateBankNotifyAsync(BankNotifyDTO dto)
        {
            await Task.Delay(100);
            long id = 1;
            if (_bankNotifies.Count > 0)
                id = _bankNotifies.Select(x => x.Id).Max() + 1;

            dto.Id = id;
            dto.DateTimeCreated = DateTime.Now;
            dto.IsReaded = false;
            _bankNotifies.Add(dto);
            return dto;
        }

        public async Task<int> DeleteAllBankNotifiesAsync()
        {
            await Task.Delay(100);
            _bankNotifies.Clear();
            return 0;
        }

        public async Task<int> DeleteBankNotifyAsync(BankNotifyDTO dto)
        {
            await Task.Delay(100);
            _bankNotifies.Remove(dto);
            return 0;
        }

        public async Task<IList<BankNotifyDTO>> GetBankNotifiesAsync()
        {
            await Task.Delay(100);
            return _bankNotifies;
        }

        public async Task<int> GetBankNotifiesCountAsync()
        {
            await Task.Delay(100);
            return _bankNotifies.Count;
        }

        public async Task<BankNotifyDTO> GetBankNotifyAsync(long id)
        {
            await Task.Delay(100);
            return _bankNotifies.FirstOrDefault(nt => nt.Id == id);
        }

        public async Task<int> UpdateBankNotifyAsync(BankNotifyDTO dto)
        {
            await Task.Delay(100);
            var notify = _bankNotifies.FirstOrDefault(nt => nt.Id == dto.Id);
            if(notify!=null)
            {
                notify.BankName = dto.BankName;
                notify.NotifyDescription = dto.NotifyDescription;
            }
            return 0;
        }

        public async Task SetBankNotifyReaded(long id)
        {
            await Task.Delay(100);
            var notify = _bankNotifies.FirstOrDefault(nt => nt.Id == id);
            if (notify != null)
                _bankNotifies.FirstOrDefault(nt => nt.Id == id).IsReaded = true;
        }
    }
}
