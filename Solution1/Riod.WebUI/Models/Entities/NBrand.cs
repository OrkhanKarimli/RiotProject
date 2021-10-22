using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Riod.WebUI.Models.Entities
{
    public class NBrand:BaseEntity
    {

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
