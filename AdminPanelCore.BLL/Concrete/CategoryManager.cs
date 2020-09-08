using AdminPanelCore.BLL.Abstarct;
using AdminPanelCore.DAL.Abstarct;
using AdminPanelCore.ENTITIES.ComplexTypes;
using AdminPanelCore.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AdminPanelCore.BLL.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public Category Add(Category entity)
        {
            return _categoryDal.Add(entity);
        }

        public bool Any(Expression<Func<Category, bool>> filter)
        {
            return _categoryDal.Any(filter);
        }

        public int Count(Expression<Func<Category, bool>> filter)
        {
            return _categoryDal.Count(filter);
        }

        public void Delete(Category entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            return _categoryDal.Get(filter);
        }

        public IQueryable<TResult> GetAllSelect<TResult>(Expression<Func<Category, TResult>> select)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TResult> GetAllSelect<TResult>(Expression<Func<Category, bool>> filter, Expression<Func<Category, TResult>> select)
        {
            throw new NotImplementedException();
        }

        public List<CategoryDetail> GetCategoryDetails(int RolID)
        {
            return _categoryDal.GetCategoryDetails(RolID);
        }

        public CategoryDetail GetByIdCategoryDetails(int? id)
        {
            return _categoryDal.GetByIdCategoryDetails(id);
        }

        public List<Category> GetList(Expression<Func<Category, bool>> filter = null)
        {
            return filter == null ?
                 _categoryDal.GetList()
            : _categoryDal.GetList(filter);
        }

        public decimal Max(Expression<Func<Category, bool>> filter, Expression<Func<Category, decimal>> column)
        {
            return _categoryDal.Max(filter, column);
        }

        public int? Max(Expression<Func<Category, bool>> filter, Expression<Func<Category, Nullable<int>>> column)
        {
            return _categoryDal.Max(filter, column);
        }

        public decimal Min(Expression<Func<Category, bool>> filter, Expression<Func<Category, decimal>> column)
        {
            throw new NotImplementedException();
        }

        public int? Min(Expression<Func<Category, bool>> filter, Expression<Func<Category, Nullable<int>>> column)
        {
            throw new NotImplementedException();
        }

        public decimal Sum(Expression<Func<Category, bool>> filter, Expression<Func<Category, decimal>> column)
        {
            throw new NotImplementedException();
        }

        public Category Update(Category entity)
        {
            return _categoryDal.Update(entity);
        }
    }
}