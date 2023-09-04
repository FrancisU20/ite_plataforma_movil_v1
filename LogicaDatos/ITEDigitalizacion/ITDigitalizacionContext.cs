using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaDatos.ITEDigitalizacion
{
    public partial class ITDigitalizacionContext : DbContext
    {
        public ITDigitalizacionContext()
        {
        }

        public ITDigitalizacionContext(DbContextOptions<ITDigitalizacionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<ScUsuarios> ScUsuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.UserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<ScUsuarios>(entity =>
            {
                entity.HasKey(e => e.UsUsuario);

                entity.ToTable("SC_Usuarios");

                entity.Property(e => e.UsUsuario)
                    .HasColumnName("us_usuario")
                    .HasMaxLength(100)
                    .ValueGeneratedNever();

                entity.Property(e => e.UsCedula)
                    .HasColumnName("us_cedula")
                    .HasMaxLength(20);

                entity.Property(e => e.UsCedulaSupervisor)
                    .HasColumnName("us_cedula_supervisor")
                    .HasMaxLength(20);

                entity.Property(e => e.UsClave)
                    .HasColumnName("us_clave")
                    .HasMaxLength(50);

                entity.Property(e => e.UsClaveApi)
                    .HasColumnName("us_clave_api")
                    .HasMaxLength(50);

                entity.Property(e => e.UsDescargaMasiva)
                    .HasColumnName("us_descarga_masiva")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UsEstado)
                    .HasColumnName("us_estado")
                    .HasMaxLength(50);

                entity.Property(e => e.UsExterno)
                    .HasColumnName("us_externo")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UsMail)
                    .HasColumnName("us_mail")
                    .HasMaxLength(50);

                entity.Property(e => e.UsMailSupervisor)
                    .HasColumnName("us_mail_supervisor")
                    .HasMaxLength(50);

                entity.Property(e => e.UsNombres)
                    .HasColumnName("us_nombres")
                    .HasMaxLength(100);
            });
        }
    }
}
