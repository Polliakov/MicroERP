using System;
using System.Collections.Generic;

namespace DataBase.Entities
{
    public class ProductPicking
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Timestamp { get; set; }

        public virtual List<ProductSell> Items { get; set; } = new List<ProductSell>();
        public User User { get; set; }
    }
}
