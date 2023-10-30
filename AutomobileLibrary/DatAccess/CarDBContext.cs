using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomobileLibrary.BusinessObject;

namespace AutomobileLibrary.DatAccess
{
    public class CarDBContext
    {
        private static List<Car> CarList = new List<Car>() {
        new Car{CarID = 1, CarName="Maxda cx-5",Manufacturer="Maxda",Price=800000,ReleaseYear=2022},
        new Car{CarID = 2, CarName="Ford Raptor",Manufacturer="Ford",Price=600000,ReleaseYear=2021}

        };

        private static CarDBContext instance = null;
        private static readonly object instanceLock = new object();
        private CarDBContext() { }
        public static CarDBContext Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CarDBContext();
                    }
                    return instance;
                }
            }
        }
        //GetCarList
        public List<Car> GetCarList => CarList;

        public Car GetcarByID(int CarID)
        {
            Car car = CarList.SingleOrDefault(pro => pro.CarID == CarID);
            return car;
        }
        //Add new car
        public void AddNew(Car car)
        {
            Car pro = GetcarByID(car.CarID);
            if(pro == null)
            {
                CarList.Add(car);
            }
            else
            {
                throw new Exception("Car is already exisis.");
            }
        }
        //update a car
        public void Update(Car car)
        {
            Car c =GetcarByID(car.CarID);   
            if(c != null)
            {
                var index = CarList.IndexOf(car);
                CarList[index] = car;
            }
            else
            {
                throw new Exception("Car does not already exists.");
            }
        }
        //remove a car
        public void Remove(int CarID)
        {
            Car p = GetcarByID(CarID);
            if(p != null)
            {
                CarList.Remove(p);
            }
            else { throw new Exception("Car does not alredy exists.");
            }
        }
    }
}
