using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage_2._5.Models
{
    public class VehicleViewModel
    {
        public string Owner { get; set; }

        public string RegNr { get; set; }

        public VehicleTypes VType { get; set; }

        public Colors Color { get; set; }

        public int wheels { get; set; }
    }
}