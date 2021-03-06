using DataBase.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataBase.Entities
{
    public class ProductCategory : IDeletable
    {
        [Browsable(false)]
        public int Id { get; set; }

        [Required]
        [DisplayName("Название")]
        public string Name { get; set; }

        [Browsable(false)]
        public int? ParentCategoryId { get; set; }

        [Browsable(false)]
        public DateTime? Deleted { get; set; }

        [Browsable(false)]
        public virtual ProductCategory ParentCategory { get; set; }
        public virtual List<Product> Products { get; set; } = new List<Product>();

        public override string ToString() => Name;
    }
}
