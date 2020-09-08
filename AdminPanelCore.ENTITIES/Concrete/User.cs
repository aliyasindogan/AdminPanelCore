using CORE.Entities.Concrete;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminPanelCore.ENTITIES.Concrete
{
    public class User : AuditEntity
    {
        [Required, Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required, Display(Name = "Adı")]
        public string FirstName { get; set; }

        [Required, Display(Name = "Soyadı")]
        public string LastName { get; set; }

        public string Email { get; set; }

        [Required, Display(Name = "Şifre")]
        public string Password { get; set; }

        [ForeignKey("Role")]
        public int RoleID { get; set; }

        public virtual Role Role { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}