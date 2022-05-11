using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataBase.Entities
{
    public class User
    {

        [Browsable(false)]
        public int Id { get; set; }

        [Required]
        [DisplayName("Имя")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Фамилия")]
        public string Surname { get; set; }

        [DisplayName("Отчество")]
        public string Patronymic { get; set; }

        [Required]
        [Phone]
        [MaxLength(11)]
        [DisplayName("Телефон")]
        public string PhoneNumber { get; set; }

        [MaxLength(64)]
        [Browsable(false)]
        public byte[] Password { get; set; }

        [DisplayName("Роль")]
        public UserRole Role { get; set; }

        public virtual List<Cheque> Cheques { get; set; } = new List<Cheque>();
        public virtual List<ProductPicking> ProductPickings { get; set; } = new List<ProductPicking>();
        public virtual List<ProductWriteOf> ProductWriteOfs { get; set; } = new List<ProductWriteOf>();
    }
}
