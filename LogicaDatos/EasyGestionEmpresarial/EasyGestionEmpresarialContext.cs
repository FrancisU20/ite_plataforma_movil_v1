using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaDatos.EasyGestionEmpresarial
{
    public partial class EasyGestionEmpresarialContext : DbContext
    {
        public EasyGestionEmpresarialContext()
        {
        }

        public EasyGestionEmpresarialContext(DbContextOptions<EasyGestionEmpresarialContext> options)
            : base(options)
        {
        }

        public virtual DbSet<VComBajarUsuariosEmail> VComBajarUsuariosEmails { get; set; }
        public virtual DbSet<VUsuarioCentroCosto> VUsuarioCentroCostos { get; set; }

        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");
            modelBuilder.Entity<VComBajarUsuariosEmail>(x=>
            {
                x.HasNoKey();
                x.ToView("v_com_bajar_Usuarios_email");
            });

            modelBuilder.Entity<VUsuarioCentroCosto>(x =>
            {
                x.HasNoKey();
            });


        }
    }
}
