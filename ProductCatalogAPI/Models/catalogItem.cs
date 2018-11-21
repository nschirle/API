using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalogAPI.Models
{
    public class catalogItem
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public int BrandID { get; set; }
        public CatalogType CatalogBrand { get; set; }
        public int TypeID { get; set; }
        public CatalogType CatalogType { get; set; }
        public String Description { get; set; }
        public String PictureURL { get; set; }
        public decimal Price { get; set; }

    }
}
