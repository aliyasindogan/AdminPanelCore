using AdminPanelCore.CORE.DataAccess.EntityFramework;
using AdminPanelCore.DAL.Abstarct;
using AdminPanelCore.DAL.Concrete.Contexts;
using AdminPanelCore.ENTITIES.Abstarct.Enums;
using AdminPanelCore.ENTITIES.ComplexTypes;
using AdminPanelCore.ENTITIES.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace AdminPanelCore.DAL.Concrete.EntityFramework
{
    public class EfCategoryDal : EfRepository<Category, DatabaseContext>, ICategoryDal
    {
        public CategoryDetail GetByIdCategoryDetails(int? id)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var result = (from c in context.Categories
                              join ct in context.CategoryTypes on c.CategoryTypeID equals ct.Id
                              select new CategoryDetail
                              {
                                  Id = c.Id,
                                  CategoryName = c.CategoryName,
                                  CategoryTypeName = ct.CategoryTypeName,
                                  DisplayOrder = c.DisplayOrder,
                                  SubCategoryName = context.Categories.FirstOrDefault(x => x.Id == c.SubCategoryID).CategoryName,
                                  MetaDescription = c.MetaDescription,
                                  MetaKeywords = c.MetaKeywords,
                                  Title = c.Title,
                                  SeoLink = c.SeoLink
                              }).FirstOrDefault(x => x.Id == id);
                return result;
            }
        }

        public List<CategoryDetail> GetCategoryDetails(int RolID)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                if (RolID == (int)Roles.Admin)
                {
                    //Admin de admin ve web kategorileri geliyor
                    var result = (from c in context.Categories
                                  join ct in context.CategoryTypes on c.CategoryTypeID equals ct.Id
                                  select new CategoryDetail
                                  {
                                      Id = c.Id,
                                      CategoryName = c.CategoryName,
                                      CategoryTypeName = ct.CategoryTypeName,
                                      DisplayOrder = c.DisplayOrder,
                                      IsDisplay = c.IsDisplay,
                                      SubCategoryName = context.Categories.FirstOrDefault(x => x.Id == c.SubCategoryID).CategoryName,
                                      MetaDescription = c.MetaDescription,
                                      MetaKeywords = c.MetaKeywords,
                                      Title = c.Title,
                                      CategoryTypeID = c.CategoryTypeID,
                                      SeoLink = c.SeoLink
                                  }).Where(x => x.CategoryTypeID != 4);
                    return result.ToList();
                }
                else  //Developer
                {
                    //Developer da tüm kategoriler geliyor
                    var result = (from c in context.Categories
                                  join ct in context.CategoryTypes on c.CategoryTypeID equals ct.Id
                                  select new CategoryDetail
                                  {
                                      Id = c.Id,
                                      CategoryName = c.CategoryName,
                                      CategoryTypeName = ct.CategoryTypeName,
                                      DisplayOrder = c.DisplayOrder,
                                      IsDisplay = c.IsDisplay,
                                      SubCategoryName = context.Categories.FirstOrDefault(x => x.Id == c.SubCategoryID).CategoryName,
                                      MetaDescription = c.MetaDescription,
                                      MetaKeywords = c.MetaKeywords,
                                      Title = c.Title,
                                      CategoryTypeID = c.CategoryTypeID,
                                      SeoLink = c.SeoLink
                                  });
                    return result.ToList();
                }
            }
        }
    }
}