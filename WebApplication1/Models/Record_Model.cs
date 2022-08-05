using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebApplication1.Models
{
    public partial class Record_Model : DbContext
    {
        public Record_Model()
            : base("name=Record_Model")
        {
        }

        public virtual DbSet<Records> Records { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public System.Data.Entity.DbSet<WebApplication1.Models.photos> photos { get; set; }
    }
}
