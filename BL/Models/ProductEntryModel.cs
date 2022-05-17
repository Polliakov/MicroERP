using DataBase.Entities;
using System.ComponentModel;

namespace BL.Models
{
    public class ProductEntryModel
    {
        [DisplayName("Наименование")]
        public string Name { get; set; }

        [DisplayName("Цена")]
        public decimal Price { get; set; }

        [DisplayName("На складе")]
        public int Count { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }

        [Browsable(false)]
        public Product Product { get; set; }
    }
}
