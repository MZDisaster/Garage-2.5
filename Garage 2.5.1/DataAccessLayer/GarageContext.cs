using Garage_2._5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Garage_2._5._1.DataAccessLayer
{
    public class GarageContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public GarageContext()
            : base("DefaultConnection")
        {

        }
    }
}