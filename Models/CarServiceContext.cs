using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarService.Models;

namespace CarService.Models
{
    public class CarServiceContext : DbContext
    {
        public CarServiceContext(DbContextOptions<CarServiceContext> options)
            : base(options)
        {

        }

        public DbSet<user> userItems { get; set; }
        public DbSet<Chat> ChatItems { get; set; }
        public DbSet<outsides> OutsideItems { get; set; }
        public DbSet<Optics> OpticsItems { get; set; }
        public DbSet<Salon> SalonItems { get; set; }
        public DbSet<Options> OptionsItems { get; set; }
        public DbSet<Media> MediaItems { get; set; }
        public DbSet<CarSalon> CarSalonItems { get; set; }
        public DbSet<CarOutsides> CarOutsideItems { get; set; }
        public DbSet<CarOptics> CarOpticsItems { get; set; }
        public DbSet<CarOptions> CarOptionsItems { get; set; }
        public DbSet<CarMedia> CarMediaItems { get; set; }
        public DbSet<Region> RegionItems { get; set; }
        public DbSet<CarBrand> CarBrandItems { get; set; }
        public DbSet<CarModel> CarModelItems { get; set; }
        public DbSet<CarColor> CarColorItems { get; set; }
        public DbSet<CarCountryOrigin> CarCountryOriginItems { get; set; }
        public DbSet<CarBody> CarBodyItems { get; set; }
        public DbSet<CarService.Models.CarRegion> CarRegionItems { get; set; }
        public DbSet<CarService.Models.CarDrive> CarDriveItems { get; set; }
        public DbSet<CarService.Models.CarEngine> CarEngineItems { get; set; }
        public DbSet<CarSteeringWheel> CarSteeringWheelItems { get; set; }
        public DbSet<CarTransmission> CarTransmissionItems { get; set; }
        public DbSet<CarSpareParts> CarSparePartsItems { get; set; }
    }
}
