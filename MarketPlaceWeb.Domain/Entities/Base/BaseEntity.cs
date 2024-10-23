using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceWeb.Domain.Entities.Base
{
    public abstract class BaseEntity
    {
        public long  Id { get; set; }
        public DateTime IsCreated { get; set; }=DateTime.UtcNow.AddHours(5);
    }
}
