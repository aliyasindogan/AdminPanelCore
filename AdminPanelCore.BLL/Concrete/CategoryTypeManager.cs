using AdminPanelCore.BLL.Abstarct;
using AdminPanelCore.DAL.Abstarct;
using AdminPanelCore.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdminPanelCore.BLL.Concrete
{
    public class CategoryTypeManager : ICategoryTypeService
    {
        private ICategoryTypeDal _categoryTypeDal;
        public CategoryTypeManager(ICategoryTypeDal categoryTypeDal)
        {
            _categoryTypeDal = categoryTypeDal;
        }

        public CategoryType Add(CategoryType entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Category entity)
        {
            throw new NotImplementedException();
        }

        public CategoryType Get(Expression<Func<CategoryType, bool>> filter)
        {
            return _categoryTypeDal.Get(filter);
        }

        public List<CategoryType> GetList(Expression<Func<CategoryType, bool>> filter = null)
        {
            return filter == null ? _categoryTypeDal.GetList() : _categoryTypeDal.GetList(filter);
        }

        public CategoryType Update(CategoryType entity)
        {
            throw new NotImplementedException();
        }
    }
}
