using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Data.Data
{
    [Table("Customers")]
    public class BankNotifyDTO
    {
        [Key]
        public long Id { get; set; }
        [MaxLength(100)]
        public string BankName { get; set; }
        [MaxLength(200)]
        public string NotifyDescription { get; set; }
        [Required]
        public DateTime DateTimeCreated { get; set; }
        public bool IsReaded { get; set; }
    }
}
