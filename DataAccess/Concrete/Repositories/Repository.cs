using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Repositories
{
    public class Repository<T> : IRepository<T> where T : class { 
    
        Context c= new Context();
        DbSet<T> obj;

        public Repository()
        {
            obj = c.Set<T>();
        }

        public int Add(T t)
        {
            obj.Add(t);
            return c.SaveChanges();
        }

        public int Delete(T t)
        {
            obj.Remove(t);
            return c.SaveChanges();
        }

        public T GetById(int id)
        {
            return obj.Find(id);
        }

        public List<T> ListAll(Expression<Func<T, bool>> filter = null)
        {
            return obj.ToList();
        }

        public int Update(T t)
        {
            obj.Update(t);
            return c.SaveChanges();
        }
    }
}
