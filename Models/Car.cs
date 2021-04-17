using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Models
{
    public class Car
    {
        public long Id { get; set; }
        public CarBrand carBrand { get; set; }
        public CarModel carModel{ get; set; }
        public CarCountryOrigin carCountryOrigin { get; set; }
        public CarBody carBody { get; set; }
        public CarEngine carEngine { get; set; }
        public CarColor carColor { get; set; }
        public CarDrive carDrive { get; set; }
        public CarRegion carRegion { get; set; }
        public CarSteeringWheel carSteeringWheel { get; set; }
        public CarTransmission carTransmission { get; set; }
    }
}
