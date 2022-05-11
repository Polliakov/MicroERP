using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.Entities
{
    public class Cheque
    {
        [Browsable(false)]
        public int Id { get; set; }

        [Browsable(false)]
        public int UserId { get; set; }

        [Column(TypeName = "money")]
        public decimal Total { get; set; }

        public DateTime Timestamp { get; set; }

        public virtual List<ProductSell> Items { get; set; } = new List<ProductSell>();
        [Browsable(false)]
        public User User { get; set; }
    }
}
