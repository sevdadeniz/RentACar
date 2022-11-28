﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUserService
    {
        public int AddUser(User u);
        public int UpdateUser(User u);
        public int DeleteUser(User u);

        List<User> ListAllUser(Expression<Func<User, bool>> filter = null);

        User GetById(int id);



    }
}
