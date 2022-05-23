using DataBase.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DataBase.Entities
{
    public class ProductPicking : IProductOperation
    {
        [Browsable(false)]
        public int Id { get; set; }

        [Browsable(false)]
        public int UserId { get; set; }

        [Browsable(false)]
        public int WarehouseId { get; set; }

        [DisplayName("Время")]
        public DateTime Timestamp { get; set; }

        public virtual List<ProductInPicking> Items { get; set; } = new List<ProductInPicking>();
        [Browsable(false)]
        public virtual User User { get; set; }
        [Browsable(false)]
        public virtual Warehouse Warehouse { get; set; }
    }
}
