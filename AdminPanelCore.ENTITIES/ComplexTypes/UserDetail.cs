using System.ComponentModel.DataAnnotations;

namespace AdminPanelCore.ENTITIES.ComplexTypes
{
    public class UserDetail
    {
        public int Id { get; set; }

        [Required, Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required, Display(Name = "Adı")]
        public string FirstName { get; set; }

        [Required, Display(Name = "Soyadı")]
        public string LastName { get; set; }

        public string Email { get; set; }

        [Required, Display(Name = "Şifre")]
        public string Password { get; set; }

        [Required, Display(Name = "Rol")]
        public string RoleName { get; set; }

        public int RolID { get; set; }

        [Required, Display(Name = "Sıra No")]
        public int DisplayOrder { get; set; }

        [Required, Display(Name = "Görüntülensin Mi?")]
        public bool IsDisplay { get; set; }

        [Required, Display(Name = "Aktif Mi?")]
        public bool IsActive { get; set; }
    }
}