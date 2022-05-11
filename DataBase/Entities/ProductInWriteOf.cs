using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.Entities
{
    public class ProductInWriteOf
    {
        [Key]
        [Column(Order = 1)]
        public int ProductId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int WriteOfId { get; set; }
        [Range(1, int.MaxValue)]
        public int Count { get; set; }

        public Product Product { get; set; }
        public ProductWriteOf WriteOf { get; set; }
    }
}
