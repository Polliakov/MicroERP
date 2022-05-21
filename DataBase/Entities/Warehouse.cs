using DataBase.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataBase.Entities
{
    public class Warehouse : IDeletable
    {
        [Browsable(false)]
        public int Id { get; set; }

        [DisplayName("Название")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Адрес")]
        public string Address { get; set; }

        [Browsable(false)]
        public DateTime? Deleted { get; set; }

        public virtual List<ProductInWarehouse> Products { get; set; } = new List<ProductInWarehouse>();

        public override string ToString() => (Name ?? "Склад") + " " + Address;
    }
}
