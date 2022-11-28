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
    public class CarMan : ICarService
    {
        ICarDAL carDAL;
        Car car;

        public CarMan(ICarDAL carDAL)
        {
            this.carDAL = carDAL;
        }

        public int AddCar(Car c)
        {
            return carDAL.Add(c);
        }

        public int DeleteCar(Car c)
        {
            return carDAL.Delete(c);
        }

        public Car GetById(int id)
        {
            return carDAL.GetById(id);
        }

        public List<Car> ListAllCar(Expression<Func<Car, bool>> filter = null)
        {
            return carDAL.ListAll();
        }

        public int UpdateCar(Car c)
        {
            return carDAL.Update(c);
        }




    }
}
