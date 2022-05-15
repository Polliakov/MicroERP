using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataBase.Entities
{
    public class ProductWriteOf
    {
        [Browsable(false)]
        public int Id { get; set; }

        [Browsable(false)]
        public int UserId { get; set; }

        [Required]
        [DisplayName("Описание")]
        public string Description { get; set; }

        [DisplayName("Время")]
        public DateTime Timestamp { get; set; }

        public virtual List<ProductInWriteOf> Items { get; set; } = new List<ProductInWriteOf>();
        public User User { get; set; }
    }
}
