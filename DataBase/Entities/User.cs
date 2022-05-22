using DataBase.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.Entities
{
    public class User : IDeletable
    {

        [Browsable(false)]
        public int Id { get; set; }

        [Required]
        [DisplayName("Фамилия")]
        public string Surname { get; set; }

        [Required]
        [DisplayName("Имя")]
        public string Name { get; set; }

        [DisplayName("Отчество")]
        public string Patronymic { get; set; }

        [Required]
        [Phone]
        [MinLength(6)]
        [MaxLength(11)]
        [DisplayName("Телефон")]
        public string PhoneNumber { get; set; }

        [MaxLength(64)]
        [Browsable(false)]
        public byte[] Password { get; set; }

        [DisplayName("Роль")]
        public UserRole Role { get; set; }

        [Browsable(false)]
        public DateTime? Deleted { get; set; }

        public virtual List<Cheque> Cheques { get; set; } = new List<Cheque>();
        public virtual List<ProductPicking> ProductPickings { get; set; } = new List<ProductPicking>();
        public virtual List<ProductWriteOf> ProductWriteOfs { get; set; } = new List<ProductWriteOf>();

        public override string ToString()
        {
            return GetFullNameShort() + " тел. " + PhoneNumber;
        }

        public string GetFullName() => $"{Surname} {Name} {Patronymic ?? ""}";

        public string GetFullNameShort()
        {
            string fullName = Surname;
            if (!string.IsNullOrEmpty(Name))
                fullName += " " + Name[0];
            if (!string.IsNullOrEmpty(Patronymic))
                fullName += " " + Patronymic[0];
            return fullName;
        }
    }
}
