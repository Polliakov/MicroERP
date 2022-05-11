using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataBase.Entities
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }

        public virtual List<ProductInWarehouse> Products { get; set; } = new List<ProductInWarehouse>();
    }
}
