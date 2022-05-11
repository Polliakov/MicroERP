using System;
using System.Collections.Generic;
using System.ComponentModel;
using DataBase.Attributes;

namespace DataBase.Entities
{
    public class Cheque
    {
        [Browsable(false)]
        public int Id { get; set; }

        [Browsable(false)]
        public int UserId { get; set; }

        [DecimalPrecision(14, 2)]
        [DisplayName("Сумма")]
        public decimal Total { get; set; }

        [DisplayName("Время")]
        public DateTime Timestamp { get; set; }

        public virtual List<ProductSell> Items { get; set; } = new List<ProductSell>();
        [Browsable(false)]
        public User User { get; set; }
    }
}
