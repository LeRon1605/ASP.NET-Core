using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstProject_MVC.Models.Entity
{
    public class User: IEntity
    {
        [Key]
        [ForeignKey("Account")]
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual Account Account { get; set; }
    }
}
