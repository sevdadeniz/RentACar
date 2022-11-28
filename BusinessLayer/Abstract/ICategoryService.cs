using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        public int AddCategory(Category c);
        public int UpdateCategory(Category c);
        public int DeleteCategory(Category c);

        List<Category> ListAllCategory(Expression<Func<Category, bool>> filter = null);

        Category GetById(int id);


    }
}
