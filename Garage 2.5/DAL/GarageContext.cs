using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Garage_2._5.Models;

namespace Garage_2._5.DAL
{
    public class GarageContext : DbContext
    {
        public GarageContext() : base("DefaultConnection")
        {

        }
        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Owner> Owners { get; set; }

        public DbSet<VehicleType> VehicleTypes { get; set; }
    }
}