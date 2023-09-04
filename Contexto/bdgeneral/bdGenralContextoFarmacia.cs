using Entidades.bdgeneral;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Contexto.bdgeneral
{
    public partial class bdGenralContextoFarmacia : DbContext
    {
        public bdGenralContextoFarmacia()
        : base("Name=bdGenralContextoFarmacia")
        {

            Database.SetInitializer<bdGenralContextoFarmacia>(null);
        }
        //public bdGenralContextoFarmacia()
        //{
        //    //try
        //    //{
        //        base.Database.Connection.ConnectionString =
        //            EasySoft.Util.AccessPoint.GetParametro("PUNTOVENTA", "CONEMP");
        //        Database.SetInitializer<bdGenralContextoFarmacia>(null);
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    System.Diagnostics.EventLog objLog = new System.Diagnostics.EventLog();
        //    //    if (!System.Diagnostics.EventLog.SourceExists("PMOV_INVENTARIO_MOVIL"))
        //    //        System.Diagnostics.EventLog.CreateEventSource("PMOV_INVENTARIO_MOVIL", "Application");
        //    //    objLog.Source = "PMOV_INVENTARIO_MOVIL";

        //    //    objLog.WriteEntry("RESP: " + ex.Message + " " + ex.StackTrace);
        //    //    Database.SetInitializer<bdGenralContextoFarmacia>(null);
        //    //}
        //}
        public DbSet<OFICINA_IP> oFICINA_IPs { get; set; }
        public DbSet<OFICINA> oFICINA { get; set; }

        public DbSet<OFICINA_IPServer> oFICINA_IPServers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new OFICINA_IPMap());
            modelBuilder.Configurations.Add(new OFICINAMap());
            modelBuilder.Configurations.Add(new OFICINA_IPServerMap());
        }
    }
}
