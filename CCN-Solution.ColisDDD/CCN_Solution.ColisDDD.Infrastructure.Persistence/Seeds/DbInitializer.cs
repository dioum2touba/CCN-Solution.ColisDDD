using System;
using System.Linq;
using CCN_Solution.ColisDDD.Domain.Entities;
using CCN_Solution.ColisDDD.Infrastructure.Persistence.Contexts;
using NLog.Fluent;

namespace CCN_Solution.ColisDDD.Infrastructure.Persistence.Seeds
{
    public static class DbInitializer
    {
        public static Agence Seed(ApplicationDbContext context)
        {
            var region = context.Region.FirstOrDefault(r => r.Label == "Dakar");
            if (region == null)
            {
                region = new Region { Label = "Dakar" };
                try
                {
                    context.Region.Add(region);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Log.Warn(ex.Message + ": \n" + ex.InnerException?.Message + ": " + " \nAn error occurred seeding the DB => context.Region.Add(region)");
                }
            }

            var agence = context.Agence.FirstOrDefault(a => a.RegionId == region.Id && a.NomAgence == "Cap Manuel");
            if (agence == null)
            {
                agence = new Agence { NomAgence = "Cap Manuel", RegionId = region.Id };
                try
                {
                    context.Agence.Add(agence);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Log.Warn(ex.Message + ": \n" + ex.InnerException?.Message + ": " + " \nAn error occurred seeding the DB => context.Agence.Add(agence)");
                }
            }

            return agence;
        }
    }
}