using Garage_2._5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Garage_2._5.Conversions
{
    public static class Converter
    {
        // Convert a vehicle to another view model. (Generic Conversion) NOT TESTED
        public static T Convert<T> (this Vehicle VModel) where T : class, new()
        {
            T newT = new T();

            PropertyInfo[] VProps = typeof(Vehicle).GetProperties();
            foreach(PropertyInfo prop in typeof(T).GetProperties())
            {
                PropertyInfo propinfo = VProps.FirstOrDefault(p => p.Name == prop.Name);
                if(propinfo != null)
                {
                    prop.SetValue(newT, propinfo.GetValue(VModel));
                }
            }

            return newT;
        }

        public static List<VehicleDetailsViewModel> ConvertToVehicleDetailsModel(this IEnumerable<Vehicle> VModel)
        {
            List<VehicleDetailsViewModel> VDVModel = new List<VehicleDetailsViewModel>();

            foreach (var v in VModel)
            {
                VehicleDetailsViewModel VDModel = new VehicleDetailsViewModel();

                VDModel.Color = v.Color;
                VDModel.OwnerName = v.Owner.Name;
                VDModel.PNR = v.Owner.PNR;
                VDModel.RegNr = v.RegNr;
                VDModel.VehicleType = v.VehicleType.Name;

                VDVModel.Add(VDModel);
                
            }


            return VDVModel;
        }

        public static List<VehicleViewModel> ConvertToVehicleViewModel(this IEnumerable<Vehicle> VModel)
        {
            List<VehicleViewModel> VVModel = new List<VehicleViewModel>();

            foreach (var v in VModel)
            {
                VehicleViewModel VVmodel = new VehicleViewModel();

                VVmodel.Owner = v.Owner.Name;
                VVmodel.RegNr = v.RegNr;
                VVmodel.VehicleType = v.VehicleType.Name;

                VVModel.Add(VVmodel);
            }

            return VVModel;
        }

        public static Vehicle ConvertyToVehicleFromCreateModel(this VehicleCreateViewModel CVCModel)
        {
            Vehicle VModel = new Vehicle();
            Owner owner = new Owner(){PNR = CVCModel.OwnerPNR};
            VehicleType Vtype = new VehicleType() { TypeId = CVCModel.VehicleTypeId };

            
            VModel.RegNr = CVCModel.RegNr;
            VModel.PNR = CVCModel.OwnerPNR;
            VModel.TypeId = CVCModel.VehicleTypeId;
            VModel.Color = CVCModel.Color;

            VModel.VehicleType = Vtype;
            VModel.Owner = owner;

            return VModel;

        }

    }
}