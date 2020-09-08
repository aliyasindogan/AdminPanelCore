using AdminPanelCore.CORE.DataAccess.EntityFramework;
using AdminPanelCore.DAL.Abstarct;
using AdminPanelCore.DAL.Concrete.Contexts;
using AdminPanelCore.ENTITIES.Concrete;

namespace AdminPanelCore.DAL.Concrete.EntityFramework
{
    public class EfCategoryTypeDal : EfRepository<CategoryType, DatabaseContext>, ICategoryTypeDal
    {
    }
}