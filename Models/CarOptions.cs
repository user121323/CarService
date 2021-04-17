using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Models
{
    public class CarOptions
    {
        public long Id { get; set; }
        public Car car { get; set; }
        public Options options { get; set; }
    }
}
