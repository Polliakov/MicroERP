using DataBase.Interfaces;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.Entities
{
    public class ProductInWriteOf : IProductEntry
    {
        [Key]
        [Column(Order = 1)]
        [Browsable(false)]
        public int ProductId { get; set; }

        [Key]
        [Column(Order = 2)]
        [Browsable(false)]
        public int WriteOfId { get; set; }

        [Range(1, int.MaxValue)]
        public int Count { get; set; }

        public virtual Product Product { get; set; }
        public virtual ProductWriteOf WriteOf { get; set; }
    }
}
