using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riod.WebUI.Models.Entities
{
    public class Color
    {
        public int Id { get; set; }
        public string HexCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CreatedbyUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? DeletedByUserId { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
