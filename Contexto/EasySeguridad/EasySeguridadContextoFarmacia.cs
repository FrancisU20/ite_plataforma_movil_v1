using Entidades.bdgeneral;
using Entidades.EasyGestionEmpresarial;
using Entidades.EasySeguridad;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Contexto.EasySeguridad
{
    public partial class EasySeguridadContextoFarmacia : DbContext
    {
        public EasySeguridadContextoFarmacia()
        : base("Name=EasySeguridadContextoFarmacia")
        {
            //Database.SetInitializer<ITEInventariosExternosContext>(null);
            this.Configuration.ValidateOnSaveEnabled = true;
        }
        //static EasySeguridadContextoFarmacia()
        //{
        //    Database.SetInitializer<EasySeguridadContextoFarmacia>(null);
        //}
        //public EasySeguridadContextoFarmacia()
        //{
        //    //try
        //    //{
        //    base.Database.Connection.ConnectionString =
        //        EasySoft.Util.AccessPoint.GetParametro("PUNTOVENTA", "CONSEG");
        //    Database.SetInitializer<EasySeguridadContextoFarmacia>(null);
        //    //}
        //    //catch(Exception ex)
        //    //{
        //    //    System.Diagnostics.EventLog objLog = new System.Diagnostics.EventLog();
        //    //    if (!System.Diagnostics.EventLog.SourceExists("PMOV_INVENTARIO_MOVIL"))
        //    //        System.Diagnostics.EventLog.CreateEventSource("PMOV_INVENTARIO_MOVIL", "Application");
        //    //    objLog.Source = "PMOV_INVENTARIO_MOVIL";

        //    //    objLog.WriteEntry("RESP: " + ex.Message+ " "+ ex.StackTrace);
        //    //    Database.SetInitializer<EasySeguridadContextoFarmacia>(null);
        //    //}
        //}
        public DbSet<Atribuciones> atribuciones { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AtribucionesMap());
        }
    }
}
