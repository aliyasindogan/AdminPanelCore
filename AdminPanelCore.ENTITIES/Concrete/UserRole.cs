using CORE.Entities.Concrete;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminPanelCore.ENTITIES.Concrete
{
    public class UserRole : CreatedModifiableEntity
    {
        /// <summary>
        /// Kullanıcı ID
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Rol ID
        /// </summary>
        public int RoleID { get; set; }

        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}