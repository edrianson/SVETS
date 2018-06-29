namespace SVETSAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<Pet> Pets { get; set; }
        public virtual DbSet<Procedure> Procedures { get; set; }
        public virtual DbSet<Treatment> Treatments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>()
                .Property(e => e.SurName)
                .IsUnicode(false);

            modelBuilder.Entity<Owner>()
                .Property(e => e.GivenName)
                .IsUnicode(false);

            modelBuilder.Entity<Owner>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Owner>()
                .HasMany(e => e.Pets)
                .WithRequired(e => e.Owner)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pet>()
                .Property(e => e.PetName)
                .IsFixedLength();

            modelBuilder.Entity<Pet>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<Pet>()
                .HasMany(e => e.Treatments)
                .WithRequired(e => e.Pet)
                .HasForeignKey(e => new { e.PetName, e.OwnerId })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Procedure>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Procedure>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Procedure>()
                .HasMany(e => e.Treatments)
                .WithRequired(e => e.Procedure)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Treatment>()
                .Property(e => e.PetName)
                .IsFixedLength();

            modelBuilder.Entity<Treatment>()
                .Property(e => e.Notes)
                .IsUnicode(false);
        }
    }
}
