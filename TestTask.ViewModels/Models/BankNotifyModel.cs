using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.ViewModels.Models
{
    public class BankNotifyModel
    {
        public BankNotifyModel() { }
        public BankNotifyModel(long id, string bankName, string notifyDescription, DateTime dateTimeCreated, bool isReaded)
        {
            Id = id;
            BankName = bankName;
            NotifyDescription = notifyDescription;
            DateTimeCreated = dateTimeCreated;
            IsReaded = isReaded;
        }

        public long Id { get; set; }
        public string BankName {get;set;}
        public string NotifyDescription { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public bool IsReaded { get; set; }

    }
}
