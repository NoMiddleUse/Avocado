using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebApplication1.Models
{
    public partial class Food_Model : DbContext
    {
        public Food_Model()
            : base("name=Food_Model")
        {
        }

        public virtual DbSet<Food_Database> Food_Database { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Food_Database>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Food_Database>()
                .Property(e => e.Protein)
                .HasPrecision(3, 1);

            modelBuilder.Entity<Food_Database>()
                .Property(e => e.Carbohydrate)
                .HasPrecision(4, 1);

            modelBuilder.Entity<Food_Database>()
                .Property(e => e.Fat)
                .HasPrecision(3, 1);

            modelBuilder.Entity<Food_Database>()
                .Property(e => e.Fiber)
                .HasPrecision(3, 1);
        }
    }
}
