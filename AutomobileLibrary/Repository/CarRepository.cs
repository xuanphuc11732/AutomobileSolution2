using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomobileLibrary.BusinessObject;
using AutomobileLibrary.DatAccess;

namespace AutomobileLibrary.Repository
{
    public class CarRepository : ICarRepository
    {
        public Car GetCarByID(int carId) => CarDBContext.Instance.GetcarByID(carId);
        public IEnumerable<Car> GetCars() => CarDBContext.Instance.GetCarList;
        public void InsertCar(Car car) => CarDBContext.Instance.AddNew(car);
        public void UpdateCar(Car car) => CarDBContext.Instance.Update(car);
        public void DeleteCar(int carId) => CarDBContext.Instance.Remove(carId);
        
    }
}
