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

        public ActionResult Index()
        {
            return View();
        
        }

        public JsonResult getIndex()
        {
            var result = JsonConvert.SerializeObject(Repo.GetVehiclesDetailsList(), Formatting.Indented, jss);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        

        [HttpPost]
        public JsonResult CreateVehicle(VehicleCreateViewModel V)
        {
            if(ModelState.IsValid)
            {
                Repo.AddVehicle(V);
                return Json(new {Status="success"});
            }
            return Json(new { Status = "fail" });
        }

        [HttpPost]
        public JsonResult Edit(Vehicle editVehicle)
        {
            editVehicle.Owner = Repo.GetOwners().Where(o => o.PNR == editVehicle.PNR).First();
            editVehicle.VehicleType = Repo.GetVehicleTypes().Where(vt => vt.TypeId == editVehicle.TypeId).First();
            if (ModelState.IsValid)
            {
                Repo.EditVehicle(editVehicle);
                return Json(new {Status="success"});
            }
            else
                return Json(new {Status = "fail"});
        }
        [HttpPost]
        public JsonResult Delete(Vehicle deleteVehicle)
        {
            if (Repo.RemoveVehicle(deleteVehicle.VehicleId))
            {
                return Json(new { Status = "success" });
            }
            return Json(new { Status = "fail" });
        }
        
        
       
        

        public JsonResult GetOwners()
        {
            var result = JsonConvert.SerializeObject(Repo.GetOwners(), Formatting.Indented, jss);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetVehicleTypes()
        {
            var result = JsonConvert.SerializeObject(Repo.GetVehicleTypes(), Formatting.Indented, jss);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}