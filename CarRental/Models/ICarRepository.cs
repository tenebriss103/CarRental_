using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Models
{
    public interface ICarRepository
    {
        void Create(Car car);
        void Delete(int id);
        Car Get(int id);
        List<Car> GetCars();
        void Update(Car car);
    }
}
