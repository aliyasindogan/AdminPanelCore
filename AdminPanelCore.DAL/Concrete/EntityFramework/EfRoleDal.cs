using AdminPanelCore.CORE.DataAccess.EntityFramework;
using AdminPanelCore.DAL.Abstarct;
using AdminPanelCore.DAL.Concrete.Contexts;
using AdminPanelCore.ENTITIES.Concrete;

namespace AdminPanelCore.DAL.Concrete.EntityFramework
{
    public class EfRoleDal : EfRepository<Role, DatabaseContext>, IRoleDal
    {
    }
}