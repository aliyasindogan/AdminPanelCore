using AdminPanelCore.ENTITIES.ComplexTypes;
using AdminPanelCore.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdminPanelCore.BLL.Abstarct
{
    public interface IUserService
    {
        List<User> GetList(Expression<Func<User, bool>> filter = null); //tümünü getir
        User Get(Expression<Func<User, bool>> filter); //ID ye göre getir
        User Add(User entity);
        User Update(User entity);
        void Delete(User entity);
        bool Any(Expression<Func<User, bool>> filter);
        int? Max(Expression<Func<User, bool>> filter, Expression<Func<User, Nullable<int>>> column);

        User GetByUserNameAndPassword(string userName, string password);
        List<UserRoleItem> GetUserRoles(User user);
        List<UserDetail> GetUserDetails(int RolID);
        UserDetail GetByIdUserDetails(int? id);
     

    }
}
