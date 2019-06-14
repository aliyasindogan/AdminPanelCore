using AdminPanelCore.CORE.Entities.Abstarct;
using AdminPanelCore.CORE.Entities.Concrete;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminPanelCore.ENTITIES.Concrete
{
    [Table("User")]
    public class User : SoftDeleteEntity, IDisplayEntity
    {
        [Required, Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required, Display(Name = "Adı")]
        public string Name { get; set; }

        [Required, Display(Name = "Soyadı")]
        public string SurName { get; set; }

        public string Email { get; set; }

        [Required, Display(Name = "Şifre")]
        public string Password { get; set; }

        [Required, Display(Name = "Rol")]
        public int RolID { get; set; }

        [Required, Display(Name = "Sıra No")]
        public int DisplayOrder { get; set; }

        [Required, Display(Name = "Görüntülensin Mi?")]
        public bool IsDisplay { get; set; }
    }
}