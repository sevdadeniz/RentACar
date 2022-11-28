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
    public class CategoryMan : ICategoryService
    {
        ICategoryDAL categoryDal;

        public CategoryMan(ICategoryDAL categoryDal)
        {
            this.categoryDal = categoryDal;
        }

        public int AddCategory(Category c)
        {
            return categoryDal.Add(c);
        }

        public int DeleteCategory(Category c)
        {
            return categoryDal.Delete(c);
        }

        public Category GetById(int id)
        {
            return categoryDal.GetById(id);
        }

        public List<Category> ListAllCategory(Expression<Func<Category, bool>> filter = null)
        {
            return categoryDal.ListAll();
        }

        public int UpdateCategory(Category c)
        {
            return categoryDal.Update(c);
        }
    }
}
