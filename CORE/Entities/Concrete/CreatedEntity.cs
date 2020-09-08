using CORE.Entities.Abstarct;
using System;

namespace CORE.Entities.Concrete
{
    public class CreatedEntity : IBaseEntity, ICreatedEntity
    {
        public int Id { get; set; }
        public int CreatedUserID { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}