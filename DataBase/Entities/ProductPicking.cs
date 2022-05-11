using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DataBase.Entities
{
    public class ProductPicking
    {
        [Browsable(false)]
        public int Id { get; set; }

        [Browsable(false)]
        public int UserId { get; set; }

        [DisplayName("Время")]
        public DateTime Timestamp { get; set; }

        public virtual List<ProductSell> Items { get; set; } = new List<ProductSell>();
        public User User { get; set; }
    }
}
