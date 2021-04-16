using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Models
{
    public class CarModel
    {
        public long Id { get; set; }
        public String Name { get; set; }
        public CarBrand carBrand { get; set; }
    }
}
