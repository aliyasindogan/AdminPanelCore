using System;

namespace CORE.Entities.Abstarct
{
    public interface ICreatedEntity
    {
        int CreatedUserID { get; set; }
        DateTime CreatedDate { get; set; }
    }
}