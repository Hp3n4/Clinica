using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Clinica
{
    public partial class ModelClinica : DbContext
    {
        public ModelClinica()
            : base("name=ModelClinica")
        {
        }

        public virtual DbSet<citas> citas { get; set; }
        public virtual DbSet<especialidades> especialidades { get; set; }
        public virtual DbSet<medicos> medicos { get; set; }
        public virtual DbSet<pacientes> pacientes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<especialidades>()
                .Property(e => e.especialidad)
                .IsUnicode(false);

            modelBuilder.Entity<medicos>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<pacientes>()
                .Property(e => e.nombre)
                .IsUnicode(false);
        }
    }
}
