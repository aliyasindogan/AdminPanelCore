using System;

namespace AdminPanelCore.CORE.Entities.Abstarct
{
    public interface IBaseEntity:IEntity
    {
        int CreatedUserID { get; set; }
        DateTime CreatedDate { get; set; }
    }
}
