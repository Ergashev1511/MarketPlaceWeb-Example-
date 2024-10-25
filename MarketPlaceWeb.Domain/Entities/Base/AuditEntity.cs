using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceWeb.Domain.Entities.Base
{
    public abstract class AuditEntity
    {
        public DateTime CreateAt { get; set; }=DateTime.UtcNow.AddHours(5);
        public DateTime UpdateAt { get; set; }=DateTime.UtcNow.AddHours(5);
        public string CreateBy { get; set; } = string.Empty;
        public string UpdateBy { get; set;} = string.Empty;
    }
}
