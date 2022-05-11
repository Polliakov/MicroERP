using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.Entities
{
    public class Product
    {
        [Browsable(false)]
        public int Id { get; set; }

        [DisplayName("Наименование")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }

        [DisplayName("Цена")]
        [Column(TypeName = "money")]
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
