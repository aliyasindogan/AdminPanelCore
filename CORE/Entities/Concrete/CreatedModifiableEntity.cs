using CORE.Entities.Abstarct;
using System;

namespace CORE.Entities.Concrete
{
    public class CreatedModifiableEntity : IBaseEntity, ICreatedEntity, IModifiableEntity
    {
        public int Id { get; set; }
        public int CreatedUserID { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedUserID { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}