using AdminPanelCore.BLL.Abstarct;
using AdminPanelCore.DAL.Abstarct;
using AdminPanelCore.ENTITIES.ComplexTypes;
using AdminPanelCore.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdminPanelCore.BLL.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public User Add(User entity)
        {
            return _userDal.Add(entity);
        }

        public bool Any(Expression<Func<User, bool>> filter)
        {
            return _userDal.Any(filter);
        }

        public void Delete(User entity)
        {
            _userDal.Delete(entity);
        }

        public User Get(Expression<Func<User, bool>> filter)
        {
            return _userDal.Get(filter);
        }

        public UserDetail GetByIdUserDetails(int? id)
        {
            return _userDal.GetByIdUserDetails(id);
        }

        public User GetByUserNameAndPassword(string userName, string password)
        {
            return _userDal.Get(x => x.UserName == userName && x.Password == password);
        }

        public List<User> GetList(Expression<Func<User, bool>> filter = null)
        {
            return filter == null
                ? _userDal.GetList()
            : _userDal.GetList(filter);
        }

        public List<UserDetail> GetUserDetails(int RolID)
        {
            return _userDal.GetUserDetails(RolID);
        }

        public List<UserRoleItem> GetUserRoles(User user)
        {
            return _userDal.GetUserRoles(user);
        }

        public int? Max(Expression<Func<User, bool>> filter, Expression<Func<User, int?>> column)
        {
            return _userDal.Max(filter, column);
        }

        public User Update(User entity)
        {
            return _userDal.Update(entity);
        }
    }
}
