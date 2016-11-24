using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage_2._5.Models
{
    public class VehicleDetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Registration Number")]
        public string RegNr { get; set; }

        [Display(Name = "Color")]
        public string Color { get; set; }

        [Display(Name = "Personal Number")]
        public int PNR { get; set; }

        [Display(Name = "Owner Name")]
        public string OwnerName { get; set; }

        [Display(Name = "Vehicle Type")]
        public string VehicleType { get; set; }

    }
}