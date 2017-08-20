using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EntityFrameworkExample.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Amount { get; set; }


        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }


    }
}