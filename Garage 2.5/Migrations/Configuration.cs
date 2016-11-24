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


            context.Owners.AddOrUpdate(
                o => o.Name,
                 new Owner { Name = "Olle Ollesson" , PNR = 610722},
                 new Owner { Name = "Pelle Pellesson" , PNR = 880310},
                 new Owner { Name = "Ernst Ernstsson" , PNR = 711001},
                 new Owner { Name = "Bert Bertsson" , PNR = 990101},
                 new Owner { Name = "Kalle Kallesson", PNR = 930101 },
                 new Owner { Name = "Ludvig Ludvigsson" , PNR = 960105},
                 new Owner { Name = "Rolf Rolfsson" , PNR = 900101},
                 new Owner { Name = "Egon Egonsson" , PNR = 860103},
                 new Owner { Name = "Leif Leifsson", PNR = 760303 },
                 new Owner { Name = "Eva Evasson", PNR = 790403 }
                );

        }
    }
}
