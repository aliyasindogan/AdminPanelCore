using AdminPanelCore.CORE.DataAccess;
using AdminPanelCore.ENTITIES.ComplexTypes;
using AdminPanelCore.ENTITIES.Concrete;
using System.Collections.Generic;

namespace AdminPanelCore.DAL.Abstarct
{
    public interface ICategoryDal : IRepository<Category>
    {
        List<CategoryDetail> GetCategoryDetails(int RolID);

        CategoryDetail GetByIdCategoryDetails(int? id);
    }
}