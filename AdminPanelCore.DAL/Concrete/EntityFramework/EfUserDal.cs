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
    public class EfUserDal : EfRepository<User, DatabaseContext>, IUserDal
    {
        public UserDetail GetByIdUserDetails(int? id)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var result = (from u in context.Users
                              join ur in context.UserRoles on u.Id equals ur.UserID
                              join r in context.Roles on ur.RoleID equals r.Id
                              select new UserDetail
                              {
                                  Id = u.Id,
                                  UserName = u.UserName,
                                  FirstName = u.FirstName,
                                  LastName = u.LastName,
                                  DisplayOrder = u.DisplayOrder,
                                  IsDisplay = u.IsDisplay,
                                  Email = u.Email,
                                  Password = u.Password,
                                  RoleName = r.RoleName
                              }).FirstOrDefault(x => x.Id == id);
                return result;
            }
        }

        public List<UserDetail> GetUserDetails(int RolID)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                if (RolID == (int)Roles.Admin)
                {
                    //Admin de admin ve web kategorileri geliyor
                    var result = (from u in context.Users
                                  join ur in context.UserRoles on u.Id equals ur.UserID
                                  join r in context.Roles on ur.RoleID equals r.Id
                                  select new UserDetail
                                  {
                                      Id = u.Id,
                                      UserName = u.UserName,
                                      FirstName = u.FirstName,
                                      LastName = u.LastName,
                                      DisplayOrder = u.DisplayOrder,
                                      IsDisplay = u.IsDisplay,
                                      Email = u.Email,
                                      Password = u.Password,
                                      RolID = u.RoleID,
                                      RoleName = r.RoleName
                                  }).Where(x => x.RolID == RolID);
                    return result.ToList();
                }
                else //Developer
                {
                    //Developer da tüm kategoriler geliyor
                    var result = (from u in context.Users
                                  join ur in context.UserRoles on u.Id equals ur.UserID
                                  join r in context.Roles on ur.RoleID equals r.Id
                                  select new UserDetail
                                  {
                                      Id = u.Id,
                                      UserName = u.UserName,
                                      FirstName = u.FirstName,
                                      LastName = u.LastName,
                                      DisplayOrder = u.DisplayOrder,
                                      IsDisplay = u.IsDisplay,
                                      Email = u.Email,
                                      Password = u.Password,
                                      RolID = u.RoleID,
                                      RoleName = r.RoleName
                                  });
                    return result.ToList();
                }
            }
        }

        public List<UserRoleItem> GetUserRoles(User user)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var result = from ur in context.UserRoles
                             join r in context.Roles
                             on ur.UserID equals user.Id
                             where ur.UserID == user.Id
                             select new UserRoleItem
                             {
                                 RoleName = r.RoleName,
                             };
                return result.ToList();
            }
        }
    }
}