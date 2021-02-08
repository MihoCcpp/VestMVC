namespace Prodyna.Models.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProdynaModel : DbContext
    {
        public ProdynaModel()
            : base("name=ProdynaModel")
        {
        }

        public virtual DbSet<Vesti> Vesti { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
