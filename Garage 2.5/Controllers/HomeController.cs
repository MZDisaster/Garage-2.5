using Garage_2._5.Models;
using Garage_2._5.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace Garage_2._5.Controllers
{
    public class HomeController : Controller
    {
        GarageRepo Repo = new GarageRepo();

        JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };

        // var result = JsonConvert.SerializeObject((repo result), Formatting.Indented, jss);

        public ActionResult Index(int VehicleTypeId = 0, string RegNr = "")
        {
            List<SelectListItem> types = new List<SelectListItem>();
            types.Add(new SelectListItem() { Text = "All Types", Value = "0" });
            foreach (VehicleType type in Repo.GContext.VehicleTypes)
            {
                types.Add(new SelectListItem() { Text = type.Name, Value = type.TypeId.ToString() });
            }
            ViewBag.VehicleTypeId = types;
            if (Request.IsAjaxRequest()) return PartialView("Index", Repo.SearchInIndex(VehicleTypeId, RegNr));
            return View(Repo.SearchInIndex(VehicleTypeId, RegNr));
        }

        public ActionResult DetailedList (int VehicleTypeId = 0, string RegNr = "")
        {
            List<SelectListItem> types = new List<SelectListItem>();
            types.Add(new SelectListItem() { Text = "All Types", Value = "0" });
            foreach (VehicleType type in Repo.GContext.VehicleTypes)
            {
                types.Add(new SelectListItem() { Text = type.Name, Value = type.TypeId.ToString() });
            }
            ViewBag.VehicleTypeId = types;
            if (Request.IsAjaxRequest()) return PartialView("DetailedList", Repo.SearchInDetails(VehicleTypeId, RegNr));
            return View(Repo.SearchInDetails(VehicleTypeId, RegNr));
        }

        public ActionResult Details(int? Id)
        {
            if (Id.HasValue)
            {
                return View(Repo.GetVehicleDetailsViewModelById(Id.Value));
            }
            else return RedirectToAction("Index");
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
                types.Add(new SelectListItem() { Text = vehicleToEdit.VehicleType.Name, Value = vehicleToEdit.TypeId.ToString() });
                foreach (VehicleType type in Repo.GContext.VehicleTypes.Where(vt => vt.TypeId != vehicleToEdit.TypeId))
                {
                    types.Add(new SelectListItem() { Text = type.Name, Value = type.TypeId.ToString() });
                }
                ViewBag.TypeId = types;

                List<SelectListItem> owners = new List<SelectListItem>();
                owners.Add(new SelectListItem() { Text = vehicleToEdit.Owner.Name, Value = vehicleToEdit.PNR });
                foreach (Owner owner in Repo.GContext.Owners.Where(o => o.PNR != vehicleToEdit.PNR))
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

        public ActionResult OwnerDetails(string id)
        {
            if (id!= null)
            {
                return View(Repo.GetOwnerByPNR(id));
            }
            return RedirectToAction("Index");
        }

        public ActionResult TypeDetails(string id)
        {
            if (id != null)
            {
                return View(Repo.GetTypeByName(id));
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                return View(Repo.GetVehicleById(id.Value));                
            }
            else
                return RedirectToAction("Index");
        }
       
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Repo.RemoveVehicle(id);          
            return RedirectToAction("Index");
        }

    }
}