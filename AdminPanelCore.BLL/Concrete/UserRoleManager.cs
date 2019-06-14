using AdminPanelCore.DAL.Abstarct;
using AdminPanelCore.ENTITIES.Concrete;
using AdWebTemplate.Business.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdminPanelCore.BLL.Concrete
{
    public class UserRoleManager : IUserRoleService
    {
        IUserRoleDal _userRoleDal;

        public UserRoleManager(IUserRoleDal userRoleDal)
        {
            _userRoleDal = userRoleDal;
        }

        public UserRole Add(UserRole entity)
        {
            return _userRoleDal.Add(entity);
        }

        public bool Any(Expression<Func<UserRole, bool>> filter)
        {
            return _userRoleDal.Any(filter);
        }

        public void Delete(UserRole entity)
        {
             _userRoleDal.Delete(entity);
        }

        public UserRole GetById(Expression<Func<UserRole, bool>> filter)
        {
            return _userRoleDal.Get(filter);
        }

        public List<UserRole> GetList(Expression<Func<UserRole, bool>> filter = null)
        {
              return _userRoleDal.GetList(filter);
        }

        public int? Max(Expression<Func<UserRole, bool>> filter, Expression<Func<UserRole, int?>> column)
        {
            return _userRoleDal.Max(filter, column);
        }

        public UserRole Update(UserRole entity)
        {
            return _userRoleDal.Update(entity);
        }
    }
}
