namespace Garage_2._5.Migrations
{
    using Garage_2._5.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Garage_2._5.DAL.GarageContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Garage_2._5.DAL.GarageContext context)
        {
           
            context.VehicleTypes.AddOrUpdate(
                vt => vt.Name,
                new VehicleType { Name = "Car" },
                new VehicleType { Name = "Boat" },
                new VehicleType { Name = "Truck" },
                new VehicleType { Name = "Motorcycle" }
                );

            Owner[] owners = new Owner[] {
                 new Owner { PNR = "610722" , Name = "Olle Ollesson"      },
                 new Owner { PNR = "880310" , Name = "Pelle Pellesson"    },
                 new Owner { PNR = "711001" , Name = "Ernst Ernstsson"    },
                 new Owner { PNR = "990101" , Name = "Bert Bertsson"      },
                 new Owner { PNR = "930101" , Name = "Kalle Kallesson"    },
                 new Owner { PNR = "960105" , Name = "Ludvig Ludvigsson"  },
                 new Owner { PNR = "900101" , Name = "Rolf Rolfsson"      },
                 new Owner { PNR = "860103" , Name = "Egon Egonsson"      },
                 new Owner { PNR = "760303" , Name = "Leif Leifsson"      },
                 new Owner { PNR = "790403" , Name = "Eva Evasson"        }};

            context.Owners.AddOrUpdate(
                 o => o.PNR,
                 owners
                );

            ;

            //Owner o1 = context.Owners.Find(1);
            //VehicleType vt1 = context.VehicleTypes.Find(1);


            //Vehicle[] vehicles = new Vehicle[] {
            //     new Vehicle { RegNr = "342UYT", Color = "Blue", PNR = o1.PNR, TypeId = vt1.TypeId , Owner = o1, VehicleType = vt1}};
            //     //new Vehicle { RegNr = "123ABC", Color = "White", PNR = "880310", TypeId = 2 },
            //     //new Vehicle {  RegNr = "777DDD", Color = "Black", PNR = "711001", TypeId = 3 },
            //     //new Vehicle {  RegNr = "745GHF", Color = "Red", PNR = "990101", TypeId = 4 }};

            //context.Vehicles.AddOrUpdate(
            //     v => v.RegNr, vehicles                
            //    );
            //, Owner = owners.ElementAt(2), VehicleType = context.VehicleTypes.ElementAt(1)

            //context.Vehicles.AddOrUpdate(
               // v => v.RegNr,
                //new Vehicle {  RegNr = "342UYT", Color = "Blue", PNR = o1.PNR.ToString(), TypeId = vt1.TypeId , Owner = o1, VehicleType = vt1}
                              //  );
        }
    }
}
