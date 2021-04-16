using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Models
{
    public class CarSpareParts
    {
        public long Id { get; set; }
        public CarBrand carBrand { get; set; }
        public CarModel carModel { get; set; }
        public bool isNew { get; set; }
        public double price { get; set; }
        public String Name { get; set; }
        public String description { get; set; }
    }
}
