using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riod.WebUI.Models.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public int? CreatedbyUserId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int? DeletedByUserId { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
