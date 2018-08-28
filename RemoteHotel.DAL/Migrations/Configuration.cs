using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace RemoteHotel.DAL.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<RemoteHotelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(RemoteHotelContext context)
        {

        }
    }
}