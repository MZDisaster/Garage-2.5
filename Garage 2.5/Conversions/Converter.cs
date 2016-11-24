using Garage_2._5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Garage_2._5.Conversions
{
    public class Converter
    {
        // Convert a vehicle to another view model. (Generic Conversion) NOT TESTED
        public T Convert<T> (Vehicle VModel) where T : class, new()
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

        public VehicleDetailsViewModel ConvertToVehicleDetailsModel (Vehicle VModel)
        {
            VehicleDetailsViewModel VDModel = new VehicleDetailsViewModel();

            VDModel.Color = VModel.Color;
            VDModel.OwnerName = VModel.Owner.Name;
            VDModel.PNR = VModel.Owner.PNR;
            VDModel.RegNr = VModel.RegNr;
            VDModel.VehicleType = VModel.VehicleType.Name;

            return VDModel;
        }

        public VehicleViewModel ConvertToVehicleViewModel(Vehicle VModel)
        {
            VehicleViewModel VVmodel = new VehicleViewModel();

            VVmodel.Owner = VModel.Owner.Name;
            VVmodel.RegNr = VModel.RegNr;
            VVmodel.VehicleType = VModel.VehicleType.Name;

            return VVmodel;
        }

        public Vehicle ConvertyToVehicleFromCreateModel (VehicleCreateViewModel CVCModel)
        {
            Vehicle VModel = new Vehicle();

            VModel.Owner = CVCModel.Owner;
            VModel.RegNr = CVCModel.RegNr;
            VModel.PNR = CVCModel.Owner.PNR;
            VModel.VehicleType = CVCModel.VehicleType;
            VModel.TypeId = CVCModel.VehicleType.TypeId;
            VModel.Color = CVCModel.Color;

            return VModel;

        }

    }
}