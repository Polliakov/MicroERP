using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataBase.Entities
{
    public class ProductWriteOf
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }

        public virtual List<ProductSell> Items { get; set; } = new List<ProductSell>();
        public User User { get; set; }
    }
}
