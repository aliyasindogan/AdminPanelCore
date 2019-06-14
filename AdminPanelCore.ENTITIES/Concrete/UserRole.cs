using AdminPanelCore.CORE.Entities.Concrete;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminPanelCore.ENTITIES.Concrete
{
    [Table("UserRole")]
    public class UserRole : SoftDeleteEntity
    {
        /// <summary>
        /// Kullanıcı ID
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// Rol ID
        /// </summary>
        public int RolID { get; set; }
    }
}