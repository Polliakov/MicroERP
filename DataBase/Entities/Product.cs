using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DataBase.Attributes;

namespace DataBase.Entities
{
    public class Product
    {
        [Browsable(false)]
        public int Id { get; set; }

        [Required]
        [DisplayName("Наименование")]
        public string Name { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }
        
        [DecimalPrecision(12, 2)]
        [DisplayName("Цена")]
        public decimal Price { get; set; }

        [Browsable(false)]
        public int CategoryId { get; set; }

        [Browsable(false)]
        public ProductCategory Category { get; set; }
        public virtual List<ProductInWarehouse> InWarehouses { get; set; } = new List<ProductInWarehouse>();
        public virtual List<ProductSell> Sells { get; set; } = new List<ProductSell>();
        public virtual List<ProductInPicking> InPickings { get; set; } = new List<ProductInPicking>();
        public virtual List<ProductInWriteOf> InWriteOfs { get; set; } = new List<ProductInWriteOf>();

    }
}
