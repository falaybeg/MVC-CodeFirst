using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EntityFrameworkExample.Models
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Address { get; set; }
        [StringLength(15)]
        public string Phone { get; set; }
      
        public Nullable<int> CityId { get; set; }

      
        public virtual City City { get; set; }


    }
}