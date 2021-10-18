using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riod.WebUI.Models.Entities
{
    public class Category:BaseEntity
    {
        public int? ParentId { get; set; }
        public virtual Category Parent { get; set; }

        public virtual ICollection<Category> Children { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        

    }
}
