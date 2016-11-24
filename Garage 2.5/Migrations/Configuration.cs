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

        }
    }
}
