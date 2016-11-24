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
    }
}