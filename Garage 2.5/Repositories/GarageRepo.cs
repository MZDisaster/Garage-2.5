using Garage_2._5.Conversions;
using Garage_2._5.DAL;
using Garage_2._5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Garage_2._5.Repositories
{
    public class GarageRepo
    {
        public GarageContext GContext { get; set; }

        protected Converter Converter = new Converter();

        public GarageRepo()
        {
            GContext = new GarageContext();
        }

        public IEnumerable<VehicleViewModel> GetVehicleList()
        {
            List<VehicleViewModel> VModelList = Converter.ConvertToVehicleViewModel(GContext.Vehicles.Select(v => v));

            return VModelList.ToList();
        }

        public IEnumerable<VehicleDetailsViewModel> GetVehiclesDetailsList()
        {
            var VDModelList = GContext.Vehicles.Select(v => Converter.ConvertToVehicleDetailsModel(v));

            return VDModelList;
        }

        public IEnumerable<VehicleViewModel> SearchInIndex(int Type, string RegNr)
        {
            List<VehicleViewModel> VModelList = Converter.ConvertToVehicleViewModel(GContext.Vehicles.Where(v =>
                v.VehicleType.TypeId == Type &&
                v.RegNr.Contains(RegNr)
                ));

            return VModelList;
        }

        public IEnumerable<VehicleDetailsViewModel> SearchInDetails(int Type, string RegNr)
        {
            List<VehicleViewModel> VModelList = GContext.Vehicles.Where(v =>
                v.VehicleType.TypeId == Type &&
                v.RegNr.Contains(RegNr)
                ).Select(v => Converter.ConvertToVehicleDetailsModel(v));

            return VModelList;
        }

        // should be working
        public void AddVehicle(VehicleCreateViewModel VCVModel)
        {
            GContext.Vehicles.Add(Converter.ConvertyToVehicleFromCreateModel(VCVModel));
            GContext.SaveChanges();
        }
    }
}