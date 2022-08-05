namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Food_Database
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        public int? Energy { get; set; }

        public decimal? Protein { get; set; }

        public decimal? Carbohydrate { get; set; }

        public decimal? Fat { get; set; }

        public decimal? Fiber { get; set; }
    }
}
