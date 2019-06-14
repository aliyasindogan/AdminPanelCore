using AdminPanelCore.CORE.DataAccess;
using AdminPanelCore.ENTITIES.ComplexTypes;
using AdminPanelCore.ENTITIES.Concrete;
using System.Collections.Generic;

namespace AdminPanelCore.DAL.Abstarct
{
    public interface IUserDal : IRepository<User>
    {
        List<UserRoleItem> GetUserRoles(User user);
        List<UserDetail> GetUserDetails(int RolID);
        UserDetail GetByIdUserDetails(int? id);
    }
}
