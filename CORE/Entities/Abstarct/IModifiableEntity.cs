using System;

namespace CORE.Entities.Abstarct
{
    public interface IModifiableEntity
    {
        int? ModifiedUserID { get; set; }
        DateTime? ModifiedDate { get; set; }
    }
}