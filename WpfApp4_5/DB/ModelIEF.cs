using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WpfApp4_5.DB
{
    public partial class ModelIEF : DbContext
    {
        public ModelIEF()
            : base("name=ModelIEF")
        {
        }

        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Statuses> Statuses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Roles>()
                .HasMany(e => e.Accounts)
                .WithRequired(e => e.Roles)
                .HasForeignKey(e => e.RoleID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Statuses>()
                .HasMany(e => e.Accounts)
                .WithRequired(e => e.Statuses)
                .HasForeignKey(e => e.StatusID)
                .WillCascadeOnDelete(false);
        }
    }
}
