using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Garage_2._5.Models
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }

        [Display(Name="Registration Number")]
        [RegularExpression("^[A-Z]{3}[0-9]{3}$")]
        public string RegNr { get; set; }

        public string Color { get; set; }

        [ForeignKey("Owner")]
        [Display(Name = "Owner")]
        public string PNR { get; set; }

        [ForeignKey("VehicleType")]
        [Display(Name = "Vehicle Type")]
        public int TypeId { get; set; }

        public virtual Owner Owner { get; set; }

        public virtual VehicleType VehicleType { get; set; }

    }
}