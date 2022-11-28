using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRepository<T>
    {
        public int Add(T t);
        public int Delete(T t);
        public int Update(T t);
        T GetById(int id);

         List<T> ListAll(Expression<Func<T, bool>> filter = null);

        

    }
}
