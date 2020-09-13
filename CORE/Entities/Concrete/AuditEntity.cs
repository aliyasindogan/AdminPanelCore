using CORE.Entities.Abstarct;
using System;
using System.ComponentModel.DataAnnotations;

namespace CORE.Entities.Concrete
{
    public class AuditEntity : IBaseEntity, ICreatedEntity, IModifiableEntity, IDisplayEntity
    {
        public int Id { get; set; }
        public int CreatedUserID { get; set; }

        [Display(Name = "Kayıt Tarihi")]
        public DateTime CreatedDate { get; set; }

        public int? ModifiedUserID { get; set; }

        [Display(Name = "Düzenleme Tarihi")]
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "Sıra No")]
        public int DisplayOrder { get; set; }

        [Display(Name = "Görünsün mü?")]
        public bool IsDisplay { get; set; }
    }
}