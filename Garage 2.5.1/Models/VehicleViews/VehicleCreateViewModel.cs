using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage_2._5.Models
{
    public class VehicleCreateViewModel
    {
        [MinLength(0)]
        public int Id { get; set; }

        [Required]
        [MinLength(6), MaxLength(32)]
        public string Owner { get; set; }

        [Required]
        [RegularExpression("/^[A-Z]{3}[0-9]{3}/")]
        public string RegNr { get; set; }

        [Required]
        [EnumDataType(typeof(VehicleTypes))]
        public VehicleTypes VType { get; set; }

        [Required]
        [EnumDataType(typeof(Colors))]
        public Colors Color { get; set; }

        [Required]
        [Range(0, 18)]
        public int wheels { get; set; }
    }
}