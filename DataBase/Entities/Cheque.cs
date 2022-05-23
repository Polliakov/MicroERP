using System;
using System.Collections.Generic;
using System.ComponentModel;
using DataBase.Attributes;
using DataBase.Interfaces;

namespace DataBase.Entities
{
    public class Cheque : IProductOperation
    {
        [Browsable(false)]
        public int Id { get; set; }

        [Browsable(false)]
        public int UserId { get; set; }

        [Browsable(false)]
        public int WarehouseId { get; set; }

        [DecimalPrecision(14, 2)]
        [DisplayName("Сумма")]
        public decimal Total { get; set; }

        [DisplayName("Время")]
        public DateTime Timestamp { get; set; }

        public virtual List<ProductSell> Items { get; set; } = new List<ProductSell>();
        [Browsable(false)]
        public virtual User User { get; set; }
        [Browsable(false)]
        public virtual Warehouse Warehouse { get; set; }
    }
}
