using Garage_2._5.Models;
using Garage_2._5.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Garage_2._5.Controllers
{
    public class HomeController : Controller
    {
        GarageRepo Repo = new GarageRepo();
        public ActionResult Index()
        {
            return View(Repo.GetVehicleList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Create()
        {
            List<SelectListItem> types = new List<SelectListItem>();
            foreach (VehicleType type in Repo.GContext.VehicleTypes)
            {
                types.Add(new SelectListItem() { Text = type.Name, Value = type.TypeId.ToString() });
            }
            ViewBag.VehicleTypes = types;
            List<SelectListItem> owners = new List<SelectListItem>();
            foreach (Owner owner in Repo.GContext.Owners)
            {
                owners.Add(new SelectListItem() { Text = owner.Name, Value = owner.PNR });
            }
            ViewBag.Owners = owners;
            return View(new Vehicle());
        }
    }
}