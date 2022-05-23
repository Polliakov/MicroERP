using DataBase.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataBase.Entities
{
    public class ProductWriteOf : IProductOperation
    {
        [Browsable(false)]
        public int Id { get; set; }

        [Browsable(false)]
        public int UserId { get; set; }

        [Browsable(false)]
        public int WarehouseId { get; set; }

        [Required]
        [DisplayName("Описание")]
        public string Description { get; set; }

        [DisplayName("Время")]
        public DateTime Timestamp { get; set; }

        public virtual List<ProductInWriteOf> Items { get; set; } = new List<ProductInWriteOf>();
        [Browsable(false)]
        public virtual User User { get; set; }
        [Browsable(false)]
        public virtual Warehouse Warehouse { get; set; }
    }
}
