using CORE.Entities.Abstarct;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdminPanelCore.ENTITIES.Concrete
{
    public class Role : IBaseEntity
    {
        public Role()
        {
            Users = new HashSet<User>();
            UserRoles = new HashSet<UserRole>();
        }

        public int Id { get; set; }

        [Required, Display(Name = "Rol")]
        public string RoleName { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}