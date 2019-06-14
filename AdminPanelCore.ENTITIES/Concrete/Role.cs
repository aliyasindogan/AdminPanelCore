using AdminPanelCore.CORE.Entities.Abstarct;
using AdminPanelCore.CORE.Entities.Concrete;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminPanelCore.ENTITIES.Concrete
{
    [Table("Role")]
    public class Role : SoftDeleteEntity, IDisplayEntity
    {
        [Required, Display(Name = "Rol")]
        public string RoleName { get; set; }
        [Required, Display(Name = "Sıra No")]
        public int DisplayOrder { get; set; }
        [Required, Display(Name = "Görüntülensin Mi?")]
        public bool IsDisplay { get; set; }
    }
}
