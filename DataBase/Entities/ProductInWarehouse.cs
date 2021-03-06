using DataBase.Interfaces;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.Entities
{
    public class ProductInWarehouse : IProductEntry
    {
        [Key]
        [Column(Order = 1)]
        [Browsable(false)]
        public int ProductID { get; set; }

        [Key]
        [Column(Order = 2)]
        [Browsable(false)]
        public int WarehouseID { get; set; }

        [Range(0, int.MaxValue)]
        public int Count { get; set; }

        public virtual Product Product { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}
