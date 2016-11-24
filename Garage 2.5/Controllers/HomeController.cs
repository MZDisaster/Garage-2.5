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
        public ActionResult Index(int Type = 0, string RegNr = "")
        {
            return View(Repo.SearchInIndex(Type, RegNr));
        }

        public ActionResult DetailedList (int Type = 0, string RegNr = "")
        {
            return View(Repo.SearchInDetails(Type, RegNr));
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
            ViewBag.VehicleTypeId = types;

            List<SelectListItem> owners = new List<SelectListItem>();
            foreach (Owner owner in Repo.GContext.Owners)
            {
                owners.Add(new SelectListItem() { Text = owner.Name, Value = owner.PNR });
            }
            ViewBag.OwnerPNR = owners;

            return View(new VehicleCreateViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult  Create([Bind(Include = "RegNr, Color, OwnerPNR, VehicleTypeId")]VehicleCreateViewModel newVehicle)
        {
            if (ModelState.IsValid)
            {
                Repo.AddVehicle(newVehicle);
            }
            
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? Id)
        {
            if (Id.HasValue)
            {
                Vehicle vehicleToEdit = Repo.GetVehicleById(Id.Value);
                List<SelectListItem> types = new List<SelectListItem>();
                foreach (VehicleType type in Repo.GContext.VehicleTypes)
                {
                    types.Add(new SelectListItem() { Text = type.Name, Value = type.TypeId.ToString() });
                }
                ViewBag.TypeId = types;

                List<SelectListItem> owners = new List<SelectListItem>();
                foreach (Owner owner in Repo.GContext.Owners)
                {
                    owners.Add(new SelectListItem() { Text = owner.Name, Value = owner.PNR });
                }
                ViewBag.PNR = owners;
                return View(vehicleToEdit);
            }
            else
                return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VehicleId, RegNr, Color, PNR, TypeId")] Vehicle editVehicle)
        {
            if (ModelState.IsValid)
            {
                Repo.EditVehicle(editVehicle);
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Edit", new { Id = editVehicle.VehicleId });
        }
    }
}