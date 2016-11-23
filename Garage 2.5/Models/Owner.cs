using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Garage_2._5.Models
{
    public class Owner
    {
        [Key]
        public int PNR { get; set; }

        public string Name { get; set; }
    }
}