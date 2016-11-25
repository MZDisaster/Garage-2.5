using Garage_2._5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage_2._5.ViewModels
{
    public class OwnerViewModel
    {
        public Owner Owner { get; set; }
        public IEnumerable<Vehicle> Vehicles { get; set; }
    }
}