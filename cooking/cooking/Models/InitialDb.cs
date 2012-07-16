using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Infrastructure;

namespace cooking.Models
{
    public class CookingInitializer :System.Data.Entity.DropCreateDatabaseIfModelChanges<Cookingdb>
    {
        protected override void Seed(Cookingdb context)
        {
            var dinners = new List<Cook>
            {
                new Cook { Title = "Sample Dinner 1", 
                             EventDate=DateTime.Parse("12/31/2010"), 
                             Address="One Microsoft Way",
                             HostedBy="scottgu@microsoft.com" },
                new Cook { Title = "Sample Dinner 2", 
                             EventDate=DateTime.Parse("05/31/2011"), 
                             Address="Somewhere else",
                             HostedBy="scottgu@microsoft.com" }
            };
            dinners.ForEach(d => context.Cooks.Add(d));
        }
    }
}