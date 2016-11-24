using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Web;


namespace Garage_2._5.Models
{
    public class Owner
    {
        
        [Key]
        public string PNR { get; set; }

        public string Name { get; set; }
    }
}