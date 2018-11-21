using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalogAPI.Models
{
    public class CatalogContext : DbContext
    {

        public CatalogContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<CatalogType> CatalogBrands { get; set; }
        public virtual DbSet<catalogType> CatalogTypes { get; set; }
        public virtual DbSet<catalogItem> CatalogItems { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogType>(ConfigureCatalogBrand);
            modelBuilder.Entity<catalogType>(ConfigureCatalogType);
            modelBuilder.Entity<catalogItem>(ConfigureCatalogItem);
        }

        private void ConfigureCatalogItem(EntityTypeBuilder<catalogItem> builder)
        {
            builder.ToTable("Catalog");
            builder.Property(b => b.ID).IsRequired().ForSqlServerUseSequenceHiLo("Catalog_hilo");

            builder.Property(b => b.Name).IsRequired().HasMaxLength(50);

            builder.Property(c => c.Price).IsRequired();

            builder.HasOne(c => c.CatalogBrand).WithMany().HasForeignKey(c => c.BrandID);

            builder.HasOne(c => c.CatalogType).WithMany().HasForeignKey(c => c.TypeID);
        }

        private void ConfigureCatalogType(EntityTypeBuilder<CatalogType> builder)
        {
            builder.ToTable("CatalogType");
            builder.Property(b => b.TypeID).IsRequired().ForSqlServerUseSequenceHiLo("Catalog_type_hilo");

            builder.Property(b => b.Name).IsRequired().HasMaxLength(100);
        }

        private void ConfigureCatalogBrand(EntityTypeBuilder<CatalogType> builder)
        {
            builder.ToTable("CatalogBrand");
            builder.Property(b => b.BrandID).IsRequired().ForSqlServerUseSequenceHiLo("Catalog_brand_hilo");

            builder.Property(b => b.Name).IsRequired().HasMaxLength(100);
            
        }
    }
}
