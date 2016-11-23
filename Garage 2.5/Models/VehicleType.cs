using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage_2._5.Models
{
    public class VehicleType
    {
        [Key]
        public int TypeId { get; set; }

        public string Name { get; set; }
    }
}