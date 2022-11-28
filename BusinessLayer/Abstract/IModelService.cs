using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IModelService
    {
        public int AddModel(Model m);
        public int UpdateModel(Model m);
        public int DeleteModel(Model m);

        List<Model> ListAllModel(Expression<Func<Model, bool>> filter = null);

        Model GetById(int id);
    }
}
