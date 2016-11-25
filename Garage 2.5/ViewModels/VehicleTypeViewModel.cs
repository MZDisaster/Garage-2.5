using Garage_2._5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage_2._5.ViewModels
{
    public class VehicleTypeViewModel
    {
        public VehicleType VehicleType { set; get; }
        public IEnumerable<Vehicle> Vehicles { get; set; }
    }
}