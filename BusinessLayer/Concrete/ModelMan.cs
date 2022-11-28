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
    public class ModelMan : IModelService
    {
        IModelDAL modelDal;

        public ModelMan(IModelDAL modelDal)
        {
            this.modelDal = modelDal;
        }

        public int AddModel(Model m)
        {
            return modelDal.Add(m);
        }

        public int DeleteModel(Model m)
        {
            return modelDal.Delete(m);
        }

        public Model GetById(int id)
        {
            return modelDal.GetById(id);
        }

        public List<Model> ListAllModel(Expression<Func<Model, bool>> filter = null)
        {
            return modelDal.ListAll();
        }

        public int UpdateModel(Model m)
        {
            return modelDal.Update(m);
        }
    }
}
