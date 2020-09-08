using CORE.Entities.Abstarct;
using System;

namespace CORE.Entities.Concrete
{
    public class ModifiableEntity : IBaseEntity, IModifiableEntity
    {
        public int Id { get; set; }

        public int? ModifiedUserID { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}