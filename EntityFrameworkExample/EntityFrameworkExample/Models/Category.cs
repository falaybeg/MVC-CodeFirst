using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkExample.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [StringLength(30)]
        public string CategoryName { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}