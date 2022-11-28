using BusinessLayer.Abstract;
using DataAccess.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserMan : IUserService
    {
        IUserDAL userDal;

        public UserMan(IUserDAL userDal)
        {
            this.userDal = userDal;
        }

        public int AddUser(User u)
        {
            return userDal.Add(u);
        }

        public int DeleteUser(User u)
        {
            return userDal.Delete(u);
        }

        public User GetById(int id)
        {
            return userDal.GetById(id);
        }

        public List<User> ListAllUser(Expression<Func<User, bool>> filter = null)
        {
            return userDal.ListAll();
        }

        public int UpdateUser(User u)
        {
            return userDal.Update(u);
        }
    }
}
