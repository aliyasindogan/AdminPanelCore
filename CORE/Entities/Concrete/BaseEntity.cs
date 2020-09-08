using CORE.Entities.Abstarct;
using System;
using System.ComponentModel.DataAnnotations;

namespace CORE.Entities.Concrete
{
    public class BaseEntity : IBaseEntity
    {
        [Required, Key]
        public int Id { get; set; }

        [Required, Display(Name = "Kaydeden Kullanıcı ID ")]
        public int CreatedUserID { get; set; }

        [Required, Display(Name = "Kayıt Tarihi")]
        public DateTime CreatedDate { get; set; }
    }
}