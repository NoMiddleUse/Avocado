namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Records
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Weight { get; set; }

        [Required]
        [StringLength(50)]
        public string Height { get; set; }

        [Required]
        [StringLength(50)]
        public string Waist { get; set; }

        [Required]
        public string UserId { get; set; }

        public DateTime Date { get; set; }
    }
}
