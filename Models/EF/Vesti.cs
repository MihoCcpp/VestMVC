namespace Prodyna.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vesti")]
    public partial class Vesti
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [StringLength(1000)]
        public string Category { get; set; }

        [Required]
        public string Author { get; set; }

        public DateTime? CreatedTimeStamp { get; set; }
    }
}
