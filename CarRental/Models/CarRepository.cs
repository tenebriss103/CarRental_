using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;

namespace CarRental.Models
{
    public class CarRepository : ICarRepository
    {
        string connectionString = null;
        public CarRepository(string connection)
        {
            connectionString = connection;
        }
        public void Create(Car car)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Car_rental (Brand, BodyType, ModelYear, RentPrice, CollateralValue) VALUES(@Brand, @BodyType, @ModelYear, @RentPrice, @CollateralValue)"; 
                db.Execute(sqlQuery, car);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Car_rental WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

        public Car Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Car>("SELECT * FROM Car_rental WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        public List<Car> GetCars()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Car>("SELECT * FROM Car_rental").ToList();
            }
        }

        public void Update(Car car)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Car_rental SET Brand = @Brand, BodyType = @BodyType, ModelYear = @ModelYear, RentPrice = @RentPrice, CollateralValue = @CollateralValue  WHERE Id = @id";
                db.Execute(sqlQuery, car);
            }
        }
    }
}
