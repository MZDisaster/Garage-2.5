using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage_2._5.Models
{
    public class VehicleCreateViewModel
    {
        [Required]
        [RegularExpression("/^[A-Z]{3}[0-9]{3}/")]
        public string RegNr { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public int OwnerPNR { get; set; }

        [Required]
        public VehicleType VehicleType { get; set; }
    }
}