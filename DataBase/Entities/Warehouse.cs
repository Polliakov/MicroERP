using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataBase.Entities
{
    public class Warehouse
    {
        [Browsable(false)]
        public int Id { get; set; }

        [DisplayName("Название")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Адрес")]
        public string Address { get; set; }

        public virtual List<ProductInWarehouse> Products { get; set; } = new List<ProductInWarehouse>();
    }
}
