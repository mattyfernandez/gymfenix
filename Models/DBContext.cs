namespace GimnasioFenix.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }

        public virtual DbSet<Actividad> Actividad { get; set; }
        public virtual DbSet<Alumno> Alumno { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Dia> Dia { get; set; }
        public virtual DbSet<Horario> Horario { get; set; }
        public virtual DbSet<Profesor> Profesor { get; set; }
        public virtual DbSet<Table> Table { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actividad>()
                .HasMany(e => e.Alumno)
                .WithRequired(e => e.Actividad)
                .HasForeignKey(e => e.IdActividad)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetRoles>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Dia>()
                .HasMany(e => e.Actividad)
                .WithRequired(e => e.Dia)
                .HasForeignKey(e => e.IdDia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Horario>()
                .HasMany(e => e.Actividad)
                .WithRequired(e => e.Horario)
                .HasForeignKey(e => e.IdHorario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Profesor>()
                .HasMany(e => e.Actividad)
                .WithRequired(e => e.Profesor)
                .HasForeignKey(e => e.IdProfesor)
                .WillCascadeOnDelete(false);
        }
    }
}
