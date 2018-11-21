using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalogAPI.Models
{
    public static class CatalogSeed
    {
        public static async void SeedAsync(CatalogContext context)
        {
            context.Database.Migrate();
            if (!context.CatalogBrands.Any())
            {
                context.CatalogBrands.AddRange(GetPreConfiguredCatalogBrands());
            }
            if (!context.CatalogTypes.Any())
            {
                await context.CatalogTypes.AddRangeAsync(GetPreConfiguredCatalogTypes());
            }
        }

        private static catalogType[] GetPreConfiguredCatalogTypes()
        {
            return new catalogType[]
            {
                new catalogType
                {
                    TypeID = 1,
                    Name = "Running"
                },
                new catalogType
                {
                   TypeID =2,
                    Name = "Walking"
                },
                 new catalogType
                {
                    TypeID =3,
                    Name = "Jogging"
                }
            };
        }

        private static CatalogType[] GetPreConfiguredCatalogBrands()
        {
            return new CatalogType[]
            {
                new CatalogType
                {
                    BrandID =1,
                    Name = "adidas"
                },
                new CatalogType
                {
                    BrandID =2,
                    Name = "nike"
                },
                 new CatalogType
                {
                    BrandID =3,
                    Name = "puma"
                }
            };
        }
    }
}
