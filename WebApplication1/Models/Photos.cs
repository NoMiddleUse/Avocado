namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class photos
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Path { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public string UserId { get; set; }

        public DateTime Date { get; set; }
    }
}
