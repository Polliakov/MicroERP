using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.Entities
{
    public class ProductInWarehouse
    {
        [Key]
        [Column(Order = 1)]
        [Browsable(false)]
        public int ProductID { get; set; }

        [Key]
        [Column(Order = 2)]
        [Browsable(false)]
        public int WarehouseID { get; set; }

        [Range(1, int.MaxValue)]
        public int Count { get; set; }

        public Product Product { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}
