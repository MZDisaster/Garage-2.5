using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Garage_2._5.Models;

namespace Garage_2._5.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }

        public string Owner { get; set; }

        public string RegNr { get; set; }

        public VehicleTypes VType { get; set; }

        public Colors Color { get; set; }

        public int wheels { get; set; }
    }
}