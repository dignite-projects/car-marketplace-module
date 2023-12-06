
using System.Linq;
using Dignite.CarMarketplace.Cars;
using Dignite.CarMarketplace.Dealers;
using Dignite.CarMarketplace.UsedCars;
using Microsoft.EntityFrameworkCore;

namespace Dignite.CarMarketplace
{
    public static class CarMarketplaceEntityFrameworkCoreQueryableExtensions
    {
        public static IQueryable<Dealer> IncludeDetails(this IQueryable<Dealer> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                .Include(s => s.Administrators);
        }
        public static IQueryable<Model> IncludeDetails(this IQueryable<Model> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                .Include(s => s.Brand);
        }
        public static IQueryable<Trim> IncludeDetails(this IQueryable<Trim> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                .Include(s => s.Model.Brand);
        }
        public static IQueryable<UsedCar> IncludeDetails(this IQueryable<UsedCar> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable.Include(uc=>uc.Dealer);
        }
        public static IQueryable<SaleCar> IncludeDetails(this IQueryable<SaleCar> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                .Include(s => s.Model);
        }
        public static IQueryable<UsedCarConsultation> IncludeDetails(this IQueryable<UsedCarConsultation> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                .Include(s => s.UsedCar);
        }
    }
}
