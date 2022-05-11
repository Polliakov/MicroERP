using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataBase.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [MaxLength(64)]
        public byte[] Password { get; set; }
        public UserRole Role { get; set; }

        public virtual List<Cheque> Cheques { get; set; } = new List<Cheque>();
        public virtual List<ProductPicking> ProductPickings { get; set; } = new List<ProductPicking>();
        public virtual List<ProductWriteOf> ProductWriteOfs { get; set; } = new List<ProductWriteOf>();
    }
}
