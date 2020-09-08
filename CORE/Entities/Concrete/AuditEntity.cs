using CORE.Entities.Abstarct;
using System;

namespace CORE.Entities.Concrete
{
    public class AuditEntity : IBaseEntity, ICreatedEntity, IModifiableEntity, IDisplayEntity
    {
        public int Id { get; set; }
        public int CreatedUserID { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedUserID { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsDisplay { get; set; }
    }
}