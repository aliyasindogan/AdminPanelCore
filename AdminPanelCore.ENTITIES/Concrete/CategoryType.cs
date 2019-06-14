using AdminPanelCore.CORE.Entities.Abstarct;
using AdminPanelCore.CORE.Entities.Concrete;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminPanelCore.ENTITIES.Concrete
{
    [Table("CategoryType")]
    public class CategoryType : SoftDeleteEntity, IDisplayEntity
    {
        public string CategoryTypeName { get; set; }
        public bool IsDisplay { get; set; }
        public int DisplayOrder { get; set; }
    }
}