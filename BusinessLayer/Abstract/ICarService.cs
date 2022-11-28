using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICarService
    {
        public int AddCar(Car c);
        public int UpdateCar(Car c);
        public int DeleteCar(Car c);

        List<Car> ListAllCar(Expression<Func<Car, bool>> filter = null);

        Car GetById(int id);
       

    }
}
