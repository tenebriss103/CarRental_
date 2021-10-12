using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string BodyType { get; set; }
        public int ModelYear { get; set; }
        public float RentPrice { get; set; }
        public float CollateralValue { get; set; }
    }
}
