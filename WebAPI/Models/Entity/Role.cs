using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.Entity
{
    public class Role
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
