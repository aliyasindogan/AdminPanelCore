using System;
using System.ComponentModel.DataAnnotations;
using AdminPanelCore.CORE.Entities.Abstarct;

namespace AdminPanelCore.CORE.Entities.Concrete
{
    public class SoftDeleteEntity : IBaseEntity, IModifiableEntity,ISoftDeleteEntity
    {
        [Required, Key]
        public int Id { get; set; }
        [Required, Display(Name = "Kaydeden Kullanıcı ID ")]
        public int CreatedUserID { get; set; }
        [Required, Display(Name = "Kayıt Tarihi")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Düzenleyen Kullanıcı ID ")]
        public int? ModifiedUserID { get; set; }
        [Display(Name = "Düzenleme Tarihi")]
        public DateTime? ModifiedDate { get; set; }
        [Display(Name = "Aktif Mi?")]
        public bool IsActive { get; set; }
    }
}
