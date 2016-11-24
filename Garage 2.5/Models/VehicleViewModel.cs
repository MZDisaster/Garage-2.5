using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Garage_2._5.Models
{
    public class VehicleViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Registration Number")]
        public string RegNr { get; set; }

        [Display(Name = "Vehicle Type")]
        public string VehicleType { get; set; }

        [Display(Name = "Owner Name")]
        public string Owner { get; set; }
    }
}