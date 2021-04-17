using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Models
{
    public class CarOptics
    {
        public long Id { get; set; }
        public Car car { get; set; }
        public Optics optics { get; set; }
    }
}
