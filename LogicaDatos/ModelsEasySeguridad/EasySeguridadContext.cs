using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LogicaDatos.ModelsEasySeguridad
{
    public partial class EasySeguridadContext : DbContext
    {
        public EasySeguridadContext()
        {
        }

        public EasySeguridadContext(DbContextOptions<EasySeguridadContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aplicaciones> Aplicaciones { get; set; }
        public virtual DbSet<Atribuciones> Atribuciones { get; set; }
        public virtual DbSet<AtribucionesAplicacionesUsuarioView> AtribucionesAplicacionesUsuarioView { get; set; }
        public virtual DbSet<AtribucionesCuentas> AtribucionesCuentas { get; set; }
        public virtual DbSet<AtribucionesExcepciones> AtribucionesExcepciones { get; set; }
        public virtual DbSet<AtribucionesFavoritos> AtribucionesFavoritos { get; set; }
        public virtual DbSet<AtribucionesPorUsuarioView> AtribucionesPorUsuarioView { get; set; }
        public virtual DbSet<AtribucionesProductos> AtribucionesProductos { get; set; }
        public virtual DbSet<AtribucionesSubtransaccion> AtribucionesSubtransaccion { get; set; }
        public virtual DbSet<AtribucionesTransaccionesView> AtribucionesTransaccionesView { get; set; }
        public virtual DbSet<CampoReferencia> CampoReferencia { get; set; }
        public virtual DbSet<ConsultaAuditoriaView> ConsultaAuditoriaView { get; set; }
        public virtual DbSet<ControlProceso> ControlProceso { get; set; }
        public virtual DbSet<CuerpoMensajeGadget> CuerpoMensajeGadget { get; set; }
        public virtual DbSet<DataUsuarioReporteConsultaView> DataUsuarioReporteConsultaView { get; set; }
        public virtual DbSet<FlujoClaves> FlujoClaves { get; set; }
        public virtual DbSet<FlujoClavesDetalle> FlujoClavesDetalle { get; set; }
        public virtual DbSet<FlujoClavesHistorico> FlujoClavesHistorico { get; set; }
        public virtual DbSet<Grupos> Grupos { get; set; }
        public virtual DbSet<IduLogUsuariosHomologados> IduLogUsuariosHomologados { get; set; }
        public virtual DbSet<IduUsuariosNoNomina> IduUsuariosNoNomina { get; set; }
        public virtual DbSet<ListadoUsuariosSwitchBp> ListadoUsuariosSwitchBp { get; set; }
        public virtual DbSet<MakeCheckerTransacciones> MakeCheckerTransacciones { get; set; }
        public virtual DbSet<MensajesGadget> MensajesGadget { get; set; }
        public virtual DbSet<Modulos> Modulos { get; set; }
        public virtual DbSet<MyServiceAccounts> MyServiceAccounts { get; set; }
        public virtual DbSet<OficinaParametrizacion> OficinaParametrizacion { get; set; }
        public virtual DbSet<ParametrosCabeceraPie> ParametrosCabeceraPie { get; set; }
        public virtual DbSet<ParametrosImpresion> ParametrosImpresion { get; set; }
        public virtual DbSet<SegEmpresa> SegEmpresa { get; set; }

        public virtual DbSet<Sesiones> Sesiones { get; set; }
        public virtual DbSet<SolicitudCambios> SolicitudCambios { get; set; }
        public virtual DbSet<SolicitudCambiosDetalle> SolicitudCambiosDetalle { get; set; }
        public virtual DbSet<SubTransaccion> SubTransaccion { get; set; }
        public virtual DbSet<TblArchivosComunicaciones> TblArchivosComunicaciones { get; set; }
        public virtual DbSet<TblSeguridadSupervisor> TblSeguridadSupervisor { get; set; }
        public virtual DbSet<Transacciones> Transacciones { get; set; }
        public virtual DbSet<TransaccionesExcepciones> TransaccionesExcepciones { get; set; }
        public virtual DbSet<TransaccionesModoProceso> TransaccionesModoProceso { get; set; }
        public virtual DbSet<UserEmpServ> UserEmpServ { get; set; }
        public virtual DbSet<UserEmpServT> UserEmpServT { get; set; }
        public virtual DbSet<UserEmpresaServicioView> UserEmpresaServicioView { get; set; }
        public virtual DbSet<UsuarioPreguntasDesafio> UsuarioPreguntasDesafio { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<UsuariosAgencias> UsuariosAgencias { get; set; }
        public virtual DbSet<UsuariosLogon> UsuariosLogon { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aplicaciones>(entity =>
            {
                entity.HasKey(e => e.Aplicacion)
                    .IsClustered(false);

                entity.Property(e => e.Aplicacion).HasMaxLength(50);

                entity.Property(e => e.AplTieneAtribuciones).HasColumnName("apl_tiene_atribuciones");

                entity.Property(e => e.Descripcion).HasMaxLength(70);

                entity.Property(e => e.EnvioPos)
                    .HasColumnName("ENVIO_POS")
                    .HasMaxLength(2)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasColumnName("link")
                    .HasMaxLength(3000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Orden)
                    .IsRequired()
                    .HasColumnName("orden")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PerteneceA)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('CM')");

                entity.Property(e => e.Visualiza)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Web).HasColumnName("web");
            });

            modelBuilder.Entity<Atribuciones>(entity =>
            {
                entity.HasKey(e => new { e.NombreCorto, e.Aplicacion, e.Modulo, e.Transaccion });

                entity.HasIndex(e => new { e.Aplicacion, e.Modulo, e.Transaccion, e.Habilitado, e.EnvioPos, e.NombreCorto })
                    .HasName("_dta_index_Atribuciones_12_1022626686__K6_K1_2_3_4_5");

                entity.Property(e => e.NombreCorto).HasMaxLength(65);

                entity.Property(e => e.Aplicacion).HasMaxLength(50);

                entity.Property(e => e.Modulo).HasMaxLength(50);

                entity.Property(e => e.Transaccion).HasMaxLength(50);

                entity.Property(e => e.EnvioPos)
                    .HasColumnName("ENVIO_POS")
                    .HasMaxLength(2)
                    .HasDefaultValueSql("('N')");


            });

            modelBuilder.Entity<AtribucionesAplicacionesUsuarioView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Atribuciones_Aplicaciones_Usuario_VIEW");

                entity.Property(e => e.Aplicacion)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CambioClave).HasColumnName("Cambio_Clave");

                entity.Property(e => e.CodigoSucursal)
                    .HasColumnName("Codigo_Sucursal")
                    .HasMaxLength(10);

                entity.Property(e => e.Modulo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NombreCorto)
                    .IsRequired()
                    .HasMaxLength(65);

                entity.Property(e => e.NombreOfBanco)
                    .HasColumnName("Nombre_OfBanco")
                    .HasMaxLength(50);

                entity.Property(e => e.NombreSucursal)
                    .HasColumnName("Nombre_Sucursal")
                    .HasMaxLength(50);

                entity.Property(e => e.OficinaBanco)
                    .HasColumnName("Oficina_Banco")
                    .HasMaxLength(10);

                entity.Property(e => e.PerfilReferencia)
                    .IsRequired()
                    .HasColumnName("Perfil_Referencia")
                    .HasMaxLength(65);

                entity.Property(e => e.Transaccion)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UnicoLogon).HasColumnName("Unico_Logon");

                entity.Property(e => e.UsuarioSupervisor).HasColumnName("Usuario_Supervisor");
            });

            modelBuilder.Entity<AtribucionesCuentas>(entity =>
            {
                entity.HasKey(e => new { e.NombreCorto, e.IdEmpresa, e.IdServicio, e.IdCuenta });

                entity.ToTable("Atribuciones_Cuentas");

                entity.Property(e => e.NombreCorto)
                    .HasMaxLength(65)
                    .IsUnicode(false);

                entity.Property(e => e.IdEmpresa).HasColumnName("Id_Empresa");

                entity.Property(e => e.IdServicio).HasColumnName("Id_Servicio");

                entity.Property(e => e.IdCuenta).HasColumnName("Id_Cuenta");
            });

            modelBuilder.Entity<AtribucionesExcepciones>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Atribuciones_Excepciones");

                entity.Property(e => e.Aplicacion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdEmpresa).HasColumnName("Id_Empresa");

                entity.Property(e => e.IdServicio).HasColumnName("Id_Servicio");

                entity.Property(e => e.Modulo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCorto)
                    .IsRequired()
                    .HasMaxLength(65)
                    .IsUnicode(false);

                entity.Property(e => e.Transaccion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AtribucionesFavoritos>(entity =>
            {
                entity.HasKey(e => new { e.NombreCorto, e.Aplicacion, e.Modulo, e.Transaccion })
                    .IsClustered(false);

                entity.ToTable("Atribuciones_Favoritos");

                entity.Property(e => e.NombreCorto).HasMaxLength(65);

                entity.Property(e => e.Aplicacion).HasMaxLength(50);

                entity.Property(e => e.Modulo).HasMaxLength(50);

                entity.Property(e => e.Transaccion).HasMaxLength(50);

                entity.HasOne(d => d.NombreCortoNavigation)
                    .WithMany(p => p.AtribucionesFavoritos)
                    .HasForeignKey(d => d.NombreCorto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Atribuciones_Favoritos_Usuarios");

                entity.HasOne(d => d.Transacciones)
                    .WithMany(p => p.AtribucionesFavoritos)
                    .HasForeignKey(d => new { d.Aplicacion, d.Modulo, d.Transaccion })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Atribuciones_Favoritos_Transacciones");
            });

            modelBuilder.Entity<AtribucionesPorUsuarioView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Atribuciones_Por_Usuario_View");

                entity.Property(e => e.Aplicacion).HasMaxLength(70);

                entity.Property(e => e.CondicionPago)
                    .IsRequired()
                    .HasColumnName("Condicion_Pago")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Empresa)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.IdAplicacion)
                    .IsRequired()
                    .HasColumnName("Id_Aplicacion")
                    .HasMaxLength(50);

                entity.Property(e => e.IdEmpresa).HasColumnName("Id_Empresa");

                entity.Property(e => e.IdServicio).HasColumnName("Id_Servicio");

                entity.Property(e => e.IdTransaccion)
                    .IsRequired()
                    .HasColumnName("Id_Transaccion")
                    .HasMaxLength(50);

                entity.Property(e => e.Modulo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nombrecorto)
                    .IsRequired()
                    .HasColumnName("nombrecorto")
                    .HasMaxLength(65);

                entity.Property(e => e.Servicio)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Transaccion).HasMaxLength(70);
            });

            modelBuilder.Entity<AtribucionesProductos>(entity =>
            {
                entity.HasKey(e => new { e.Usuario, e.IdEmpresa, e.IdServicio, e.IdProducto });

                entity.ToTable("Atribuciones_Productos");

                entity.Property(e => e.Usuario)
                    .HasColumnName("usuario")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdEmpresa).HasColumnName("id_Empresa");

                entity.Property(e => e.IdServicio).HasColumnName("id_Servicio");

                entity.Property(e => e.IdProducto).HasColumnName("id_Producto");

                entity.Property(e => e.Habilitado).HasColumnName("habilitado");

                entity.Property(e => e.TipoProducto)
                    .HasColumnName("Tipo_Producto")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AtribucionesSubtransaccion>(entity =>
            {
                entity.HasKey(e => new { e.NombreCorto, e.IdSubtransaccion });

                entity.ToTable("Atribuciones_Subtransaccion");

                entity.Property(e => e.NombreCorto).HasMaxLength(65);

                entity.Property(e => e.IdSubtransaccion).HasColumnName("Id_Subtransaccion");

                entity.HasOne(d => d.IdSubtransaccionNavigation)
                    .WithMany(p => p.AtribucionesSubtransaccion)
                    .HasForeignKey(d => d.IdSubtransaccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Atribuciones_Subtransaccion_Sub_Transaccion");

                entity.HasOne(d => d.NombreCortoNavigation)
                    .WithMany(p => p.AtribucionesSubtransaccion)
                    .HasForeignKey(d => d.NombreCorto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Atribuciones_Subtransaccion_Usuarios");
            });

            modelBuilder.Entity<AtribucionesTransaccionesView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Atribuciones_Transacciones_VIEW");

                entity.Property(e => e.Aplicacion)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Modulo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NombreCorto)
                    .IsRequired()
                    .HasMaxLength(65);

                entity.Property(e => e.Transaccion)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CampoReferencia>(entity =>
            {
                entity.HasKey(e => new { e.Campo, e.TipoCampo })
                    .HasName("PK_Campo_Referencia_1");

                entity.ToTable("Campo_Referencia");

                entity.Property(e => e.Campo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipoCampo)
                    .HasColumnName("Tipo_Campo")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CampoEquivalente)
                    .IsRequired()
                    .HasColumnName("Campo_Equivalente")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CampoReferencia1)
                    .IsRequired()
                    .HasColumnName("Campo_Referencia")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TablaReferencia)
                    .IsRequired()
                    .HasColumnName("Tabla_Referencia")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ConsultaAuditoriaView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Consulta_Auditoria_View");

                entity.Property(e => e.Aplicacion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(600)
                    .IsFixedLength();

                entity.Property(e => e.Empresa)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FechaLog)
                    .HasColumnName("Fecha_Log")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FechaTransaccion).HasColumnType("datetime");

                entity.Property(e => e.Hora)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.IdContrato).HasColumnName("Id_Contrato");

                entity.Property(e => e.IdItem).HasColumnName("Id_Item");

                entity.Property(e => e.IdLog).HasColumnName("id_log");

                entity.Property(e => e.IdSobre).HasColumnName("Id_Sobre");

                entity.Property(e => e.MaquinaId)
                    .IsRequired()
                    .HasColumnName("MaquinaID")
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.NodoProceso)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.Servicio)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Transaccion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("UserID")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<ControlProceso>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Control)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('LIBRE')");
            });

            modelBuilder.Entity<CuerpoMensajeGadget>(entity =>
            {
                entity.HasKey(e => e.IdCuerpoMensaje);

                entity.Property(e => e.IdCuerpoMensaje)
                    .HasColumnName("idCuerpoMensaje")
                    .ValueGeneratedNever();

                entity.Property(e => e.CuerpoMensaje)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.IdMensaje).HasColumnName("idMensaje");
            });

            modelBuilder.Entity<DataUsuarioReporteConsultaView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Data_Usuario_ReporteConsulta_VIEW");

                entity.Property(e => e.ActualizaDatos).HasColumnName("Actualiza_Datos");

                entity.Property(e => e.Alias)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AprobacionGeneral).HasColumnName("Aprobacion_General");

                entity.Property(e => e.CambioClave).HasColumnName("Cambio_Clave");

                entity.Property(e => e.Cedula).HasMaxLength(13);

                entity.Property(e => e.CodGrupoFinanciero).HasMaxLength(20);

                entity.Property(e => e.CodigoReferencia)
                    .IsRequired()
                    .HasColumnName("Codigo_Referencia")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoSucursal).HasColumnName("Codigo_Sucursal");

                entity.Property(e => e.Descripcion).HasMaxLength(200);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EnvioNotificacion).HasColumnName("Envio_Notificacion");

                entity.Property(e => e.EnvioPos)
                    .HasColumnName("ENVIO_POS")
                    .HasMaxLength(50);

                entity.Property(e => e.FuenteInformacionXml).HasColumnName("Fuente_Informacion_XML");

                entity.Property(e => e.Grupo).HasMaxLength(65);

                entity.Property(e => e.IdAgencia)
                    .HasColumnName("id_agencia")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IdPersona).HasColumnName("Id_Persona");

                entity.Property(e => e.ManejoGrupo).HasColumnName("Manejo_Grupo");

                entity.Property(e => e.NivelesMontosGeneral)
                    .IsRequired()
                    .HasColumnName("Niveles_Montos_General")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NomGrupoFinanciero).HasMaxLength(50);

                entity.Property(e => e.Nombre).HasMaxLength(40);

                entity.Property(e => e.NombreCorto)
                    .IsRequired()
                    .HasMaxLength(65);

                entity.Property(e => e.NombreOfBanco)
                    .HasColumnName("Nombre_OfBanco")
                    .HasMaxLength(50);

                entity.Property(e => e.NombreSucursal)
                    .HasColumnName("Nombre_Sucursal")
                    .HasMaxLength(50);

                entity.Property(e => e.OficinaBanco)
                    .HasColumnName("Oficina_Banco")
                    .HasMaxLength(10);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PerfilReferencia)
                    .IsRequired()
                    .HasColumnName("Perfil_Referencia")
                    .HasMaxLength(65);

                entity.Property(e => e.PerfilTipo).HasColumnName("Perfil_Tipo");

                entity.Property(e => e.RestriccionCuentas).HasColumnName("Restriccion_Cuentas");

                entity.Property(e => e.TipoEmpresa)
                    .HasColumnName("Tipo_Empresa")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TipoIdent)
                    .IsRequired()
                    .HasColumnName("Tipo_Ident")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TiposFirmasGeneral)
                    .IsRequired()
                    .HasColumnName("Tipos_Firmas_General")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UnicoLogon).HasColumnName("Unico_Logon");

                entity.Property(e => e.UsuarioAd).HasColumnName("UsuarioAD");

                entity.Property(e => e.UsuarioSupervisor).HasColumnName("Usuario_Supervisor");
            });

            modelBuilder.Entity<FlujoClaves>(entity =>
            {
                entity.HasKey(e => e.NumeroDocumento);

                entity.ToTable("Flujo_Claves");

                entity.Property(e => e.NumeroDocumento).HasColumnName("Numero_Documento");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(65)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoImpresion)
                    .IsRequired()
                    .HasColumnName("Estado_Impresion")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('PENDIENTE')");

                entity.Property(e => e.EstadoMakeChecher)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('APROBADO')");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.NumeroPreImpreso)
                    .IsRequired()
                    .HasColumnName("Numero_PreImpreso")
                    .HasMaxLength(65)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Proceso)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(65)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FlujoClavesDetalle>(entity =>
            {
                entity.HasKey(e => new { e.NumeroDocumento, e.SecuencialDetalle, e.Estado });

                entity.ToTable("Flujo_Claves_Detalle");

                entity.Property(e => e.NumeroDocumento).HasColumnName("Numero_Documento");

                entity.Property(e => e.SecuencialDetalle).HasColumnName("Secuencial_Detalle");

                entity.Property(e => e.Estado)
                    .HasMaxLength(65)
                    .IsUnicode(false);

                entity.Property(e => e.EntregadoA)
                    .IsRequired()
                    .HasColumnName("Entregado_A")
                    .HasMaxLength(65)
                    .IsUnicode(false);

                entity.Property(e => e.FechaDetalle)
                    .HasColumnName("Fecha_Detalle")
                    .HasColumnType("datetime");

                entity.Property(e => e.Identificacion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(65)
                    .IsUnicode(false);

                entity.Property(e => e.NomGrupoFinanciero)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NombreUsuario)
                    .IsRequired()
                    .HasColumnName("Nombre_Usuario")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Proceso)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(65)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioCustodio)
                    .IsRequired()
                    .HasColumnName("Usuario_Custodio")
                    .HasMaxLength(65)
                    .IsUnicode(false);

                entity.HasOne(d => d.NumeroDocumentoNavigation)
                    .WithMany(p => p.FlujoClavesDetalle)
                    .HasForeignKey(d => d.NumeroDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Flujo_Claves_Detalle_Flujo_Claves");
            });

            modelBuilder.Entity<FlujoClavesHistorico>(entity =>
            {
                entity.HasKey(e => e.NumeroPreImpresoAnterior)
                    .HasName("PK_Flujo_Claves_Historico_1");

                entity.ToTable("Flujo_Claves_Historico");

                entity.Property(e => e.NumeroPreImpresoAnterior)
                    .HasColumnName("Numero_PreImpreso_Anterior")
                    .HasMaxLength(65)
                    .IsUnicode(false);

                entity.Property(e => e.FechaHora)
                    .HasColumnName("Fecha_Hora")
                    .HasColumnType("datetime");

                entity.Property(e => e.NumeroDocumento).HasColumnName("Numero_Documento");

                entity.Property(e => e.NumeroPreImpreso)
                    .IsRequired()
                    .HasColumnName("Numero_PreImpreso")
                    .HasMaxLength(65)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(65)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Grupos>(entity =>
            {
                entity.HasKey(e => e.Grupo)
                    .IsClustered(false);

                entity.HasIndex(e => e.Grupo)
                    .HasName("IX_Grupos")
                    .IsUnique();

                entity.Property(e => e.Grupo).HasMaxLength(65);

                entity.Property(e => e.Descripcion).HasMaxLength(200);
            });

            modelBuilder.Entity<IduLogUsuariosHomologados>(entity =>
            {
                entity.HasKey(e => e.LogCodigo);

                entity.ToTable("IDU_LogUsuariosHomologados");

                entity.Property(e => e.LogCodigo).HasColumnName("log_codigo");

                entity.Property(e => e.LogEstadoEasy)
                    .HasColumnName("log_estado_easy")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LogFechaHomologa)
                    .HasColumnName("log_fecha_homologa")
                    .HasColumnType("datetime");

                entity.Property(e => e.LogNroUsuariosDeshabilitados).HasColumnName("log_nro_usuarios_deshabilitados");

                entity.Property(e => e.LogNroUsuariosHabilitados).HasColumnName("log_nro_usuarios_habilitados");

                entity.Property(e => e.LogUsuarioHomologa)
                    .IsRequired()
                    .HasColumnName("log_usuario_homologa")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LogUsuarioHomologado)
                    .IsRequired()
                    .HasColumnName("log_usuario_homologado")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<IduUsuariosNoNomina>(entity =>
            {
                entity.HasKey(e => e.UsuCodigo);

                entity.ToTable("IDU_UsuariosNoNomina");

                entity.HasIndex(e => e.UsuCedula)
                    .HasName("UQ__IDU_Usua__A0704FC3468FE55C")
                    .IsUnique();

                entity.Property(e => e.UsuCodigo).HasColumnName("usu_codigo");

                entity.Property(e => e.UsuApellidos)
                    .IsRequired()
                    .HasColumnName("usu_apellidos")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.UsuCedula)
                    .IsRequired()
                    .HasColumnName("usu_cedula")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UsuCentroCosto)
                    .HasColumnName("usu_centro_costo")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UsuEstado).HasColumnName("usu_estado");

                entity.Property(e => e.UsuFechaActualiza)
                    .HasColumnName("usu_fecha_actualiza")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsuFechaCreado)
                    .HasColumnName("usu_fecha_creado")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsuFechaInactivo)
                    .HasColumnName("usu_fecha_inactivo")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsuMimeArchivo)
                    .HasColumnName("usu_mime_archivo")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuMotivo)
                    .HasColumnName("usu_motivo")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UsuNombreArchivo)
                    .HasColumnName("usu_nombre_archivo")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuNombres)
                    .IsRequired()
                    .HasColumnName("usu_nombres")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.UsuTipo)
                    .HasColumnName("usu_tipo")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UsuUsuarioActualiza)
                    .IsRequired()
                    .HasColumnName("usu_usuario_actualiza")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UsuUsuarioCrea)
                    .IsRequired()
                    .HasColumnName("usu_usuario_crea")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ListadoUsuariosSwitchBp>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ListadoUsuarios_Switch_BP");

                entity.Property(e => e.ActualizaDatos).HasColumnName("Actualiza_Datos");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.AprobacionGeneral).HasColumnName("Aprobacion_General");

                entity.Property(e => e.CambioClave).HasColumnName("Cambio_Clave");

                entity.Property(e => e.Cedula).HasMaxLength(13);

                entity.Property(e => e.CodGrupoFinanciero).HasMaxLength(20);

                entity.Property(e => e.CodigoReferencia)
                    .IsRequired()
                    .HasColumnName("Codigo_Referencia")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoSucursal)
                    .HasColumnName("Codigo_Sucursal")
                    .HasMaxLength(10);

                entity.Property(e => e.Descripcion).HasMaxLength(200);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EnvioNotificacion).HasColumnName("Envio_Notificacion");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.FuenteInformacionXml)
                    .IsRequired()
                    .HasColumnName("Fuente_Informacion_XML")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Grupo).HasMaxLength(65);

                entity.Property(e => e.IdAgencia)
                    .HasColumnName("id_agencia")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IdPersona)
                    .IsRequired()
                    .HasColumnName("id_Persona")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ManejoGrupo).HasColumnName("Manejo_Grupo");

                entity.Property(e => e.NivelesMontosGeneral)
                    .IsRequired()
                    .HasColumnName("Niveles_Montos_General")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NomGrupoFinanciero)
                    .IsRequired()
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre).HasMaxLength(40);

                entity.Property(e => e.NombreCorto)
                    .IsRequired()
                    .HasMaxLength(65);

                entity.Property(e => e.NombreOfBanco)
                    .HasColumnName("Nombre_OfBanco")
                    .HasMaxLength(50);

                entity.Property(e => e.NombreSucursal)
                    .HasColumnName("Nombre_Sucursal")
                    .HasMaxLength(50);

                entity.Property(e => e.OficinaBanco)
                    .HasColumnName("Oficina_Banco")
                    .HasMaxLength(10);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.PerfilReferencia)
                    .IsRequired()
                    .HasColumnName("Perfil_Referencia")
                    .HasMaxLength(29)
                    .IsUnicode(false);

                entity.Property(e => e.PerfilTipo)
                    .IsRequired()
                    .HasColumnName("Perfil_Tipo")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.RestriccionCuentas).HasColumnName("Restriccion_Cuentas");

                entity.Property(e => e.TipoEmpresa)
                    .IsRequired()
                    .HasColumnName("Tipo_Empresa")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TipoIdent)
                    .IsRequired()
                    .HasColumnName("Tipo_Ident")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TipoUsuario)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TiposFirmasGeneral)
                    .IsRequired()
                    .HasColumnName("Tipos_Firmas_General")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UnicoLogon).HasColumnName("Unico_Logon");

                entity.Property(e => e.UsuarioAd).HasColumnName("UsuarioAD");

                entity.Property(e => e.UsuarioBancaPersonas)
                    .IsRequired()
                    .HasColumnName("Usuario_BancaPersonas")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioSupervisor).HasColumnName("Usuario_Supervisor");
            });

            modelBuilder.Entity<MakeCheckerTransacciones>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MakeChecker_Transacciones");

                entity.Property(e => e.Aplicacion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Clave)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdTransaccion)
                    .HasColumnName("Id_Transaccion")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<MensajesGadget>(entity =>
            {
                entity.HasKey(e => e.IdMensaje);

                entity.Property(e => e.IdMensaje)
                    .HasColumnName("idMensaje")
                    .ValueGeneratedNever();

                entity.Property(e => e.Mensaje)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Modulos>(entity =>
            {
                entity.HasKey(e => new { e.Aplicacion, e.Modulo })
                    .IsClustered(false);

                entity.Property(e => e.Aplicacion).HasMaxLength(50);

                entity.Property(e => e.Modulo).HasMaxLength(50);

                entity.Property(e => e.Descripcion).HasMaxLength(70);

                entity.Property(e => e.EnvioPos)
                    .HasColumnName("ENVIO_POS")
                    .HasMaxLength(2)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IndiceModulo).HasColumnName("Indice_Modulo");

                entity.HasOne(d => d.AplicacionNavigation)
                    .WithMany(p => p.Modulos)
                    .HasForeignKey(d => d.Aplicacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Modulos_Aplicaciones");
            });

            modelBuilder.Entity<MyServiceAccounts>(entity =>
            {
                entity.HasKey(e => new { e.NombreCorto, e.Servicio, e.Cuenta });

                entity.Property(e => e.NombreCorto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Servicio)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Cuenta)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Habilitado)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Referencia)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OficinaParametrizacion>(entity =>
            {
                entity.HasKey(e => new { e.Sucursal, e.Oficina });

                entity.ToTable("Oficina_Parametrizacion");

                entity.Property(e => e.Sucursal).HasMaxLength(3);

                entity.Property(e => e.Oficina).HasMaxLength(5);

                entity.Property(e => e.EnvioPos)
                    .HasColumnName("ENVIO_POS")
                    .HasMaxLength(2);

                entity.Property(e => e.Horafin).HasMaxLength(10);

                entity.Property(e => e.Horaini).HasMaxLength(10);
            });

            modelBuilder.Entity<ParametrosCabeceraPie>(entity =>
            {
                entity.HasKey(e => new { e.TipoFormulario, e.NumeroLinea });

                entity.ToTable("ParametrosCabecera_Pie");

                entity.Property(e => e.TipoFormulario)
                    .HasColumnName("Tipo_Formulario")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroLinea).HasColumnName("Numero_Linea");

                entity.Property(e => e.Aerolinea)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Clase)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Font)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Idioma)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Modo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('I')");

                entity.Property(e => e.Texto)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<ParametrosImpresion>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Parametros_impresion");

                entity.Property(e => e.Aerolinea)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Campo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Idioma)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Parametro)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tabla)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TipoUso)
                    .IsRequired()
                    .HasColumnName("Tipo_Uso")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('GENERAL')");
            });

            modelBuilder.Entity<SegEmpresa>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK_SEG_Empresa_1");

                entity.ToTable("SEG_Empresa");

                entity.Property(e => e.EmpId)
                    .HasColumnName("emp_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.EmpCodigoPostal)
                    .HasColumnName("emp_codigo_postal")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpDireccion)
                    .HasColumnName("emp_direccion")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.EmpDireccionAccesoUsuario)
                    .HasColumnName("emp_direccion_acceso_usuario")
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.EmpDireccionWeb)
                    .HasColumnName("emp_direccion_web")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.EmpEmail)
                    .HasColumnName("emp_email")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.EmpEstado)
                    .IsRequired()
                    .HasColumnName("emp_estado")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.EmpFechaActualizacion)
                    .HasColumnName("emp_fecha_actualizacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmpFechaCreacion)
                    .HasColumnName("emp_fecha_creacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmpLogo)
                    .HasColumnName("emp_logo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpNombre)
                    .IsRequired()
                    .HasColumnName("emp_nombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpPais)
                    .HasColumnName("emp_pais")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpProvincia)
                    .HasColumnName("emp_provincia")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EmpRuc)
                    .HasColumnName("emp_ruc")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EmpTelefono)
                    .HasColumnName("emp_telefono")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EmpUsuarioActualizacion)
                    .IsRequired()
                    .HasColumnName("emp_usuario_actualizacion")
                    .HasMaxLength(65)
                    .IsUnicode(false);
            });

         
            modelBuilder.Entity<Sesiones>(entity =>
            {
                entity.HasKey(e => new { e.IdSesion, e.Ip, e.Fechahora });

                entity.Property(e => e.IdSesion)
                    .HasColumnName("idSesion")
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.Ip)
                    .HasColumnName("ip")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("(N'localhost')");

                entity.Property(e => e.Fechahora)
                    .HasColumnName("fechahora")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Conexiones)
                    .HasColumnName("conexiones")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.NombreCorto)
                    .IsRequired()
                    .HasColumnName("nombreCorto")
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<SolicitudCambios>(entity =>
            {
                entity.HasKey(e => e.IdSolicitud);

                entity.ToTable("SOLICITUD_CAMBIOS");

                entity.Property(e => e.IdSolicitud).HasColumnName("Id_Solicitud");

                entity.Property(e => e.Aplicacion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Comentario)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('PENDIENTE')");

                entity.Property(e => e.FechaRespuesta)
                    .HasColumnName("Fecha_Respuesta")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaSolicitud)
                    .HasColumnName("Fecha_Solicitud")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Motivo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ObjetoCambio)
                    .IsRequired()
                    .HasColumnName("Objeto_Cambio")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Referencia)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UsuarioChecker)
                    .HasColumnName("Usuario_Checker")
                    .HasMaxLength(65)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioMake)
                    .IsRequired()
                    .HasColumnName("Usuario_Make")
                    .HasMaxLength(65)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<SolicitudCambiosDetalle>(entity =>
            {
                entity.HasKey(e => e.IdSolicitudDetalle);

                entity.ToTable("SOLICITUD_CAMBIOS_DETALLE");

                entity.Property(e => e.IdSolicitudDetalle).HasColumnName("Id_Solicitud_Detalle");

                entity.Property(e => e.Campo)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CampoIdentificador)
                    .IsRequired()
                    .HasColumnName("Campo_Identificador")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Comando)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Entrada)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IdSolicitud).HasColumnName("Id_Solicitud");

                entity.Property(e => e.Tabla)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ValorCambio)
                    .IsRequired()
                    .HasColumnName("Valor_Cambio")
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ValorOriginal)
                    .IsRequired()
                    .HasColumnName("Valor_Original")
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<SubTransaccion>(entity =>
            {
                entity.HasKey(e => e.IdSubtransaccion);

                entity.ToTable("Sub_Transaccion");

                entity.Property(e => e.IdSubtransaccion).HasColumnName("Id_Subtransaccion");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.IdTransaccion).HasColumnName("Id_Transaccion");

                entity.Property(e => e.Subtransaccion1)
                    .IsRequired()
                    .HasColumnName("Subtransaccion")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblArchivosComunicaciones>(entity =>
            {
                entity.HasKey(e => new { e.Compania, e.Sucursal, e.Oficina, e.BaseDatos, e.Tabla, e.Tipo, e.Version });

                entity.ToTable("tbl_archivos_comunicaciones");

                entity.Property(e => e.Compania).HasMaxLength(3);

                entity.Property(e => e.Sucursal).HasMaxLength(3);

                entity.Property(e => e.Oficina).HasMaxLength(5);

                entity.Property(e => e.BaseDatos).HasMaxLength(100);

                entity.Property(e => e.Tabla).HasMaxLength(100);

                entity.Property(e => e.Tipo).HasMaxLength(1);

                entity.Property(e => e.FechaComunicacion)
                    .HasColumnName("Fecha_comunicacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.NombreArchivo)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TblSeguridadSupervisor>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_seguridadSupervisor");

                entity.Property(e => e.IdMenu)
                    .HasColumnName("idMenu")
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.Server)
                    .HasColumnName("SERVER")
                    .HasMaxLength(200)
                    .IsFixedLength();

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasColumnName("TOKEN")
                    .HasMaxLength(100)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Transacciones>(entity =>
            {
                entity.HasKey(e => new { e.Aplicacion, e.Modulo, e.Transaccion })
                    .IsClustered(false);

                entity.Property(e => e.Aplicacion).HasMaxLength(50);

                entity.Property(e => e.Modulo).HasMaxLength(50);

                entity.Property(e => e.Transaccion).HasMaxLength(50);

                entity.Property(e => e.CodigoNivelTres)
                    .IsRequired()
                    .HasColumnName("Codigo_NivelTres")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DescNivelTres)
                    .IsRequired()
                    .HasColumnName("Desc_NivelTres")
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Descripcion).HasMaxLength(70);

                entity.Property(e => e.EnvioPos)
                    .HasColumnName("ENVIO_POS")
                    .HasMaxLength(2)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IdTransaccion)
                    .HasColumnName("Id_Transaccion")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IndiceTransaccion).HasColumnName("Indice_Transaccion");

                entity.Property(e => e.InfoXml)
                    .IsRequired()
                    .HasColumnName("InfoXML")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InfoXmlDependeBco)
                    .IsRequired()
                    .HasColumnName("InfoXML_Depende_BCO")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Panel)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TipoMenu)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('S')");

                entity.HasOne(d => d.Modulos)
                    .WithMany(p => p.Transacciones)
                    .HasForeignKey(d => new { d.Aplicacion, d.Modulo })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transacciones_Modulos");
            });

            modelBuilder.Entity<TransaccionesExcepciones>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Transacciones_Excepciones");

                entity.Property(e => e.Aplicacion)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AplicacionExc)
                    .IsRequired()
                    .HasColumnName("Aplicacion_Exc")
                    .HasMaxLength(50);

                entity.Property(e => e.MensajeAdvertencia)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.MensajeNegacion)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Modulo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModuloExc)
                    .IsRequired()
                    .HasColumnName("Modulo_Exc")
                    .HasMaxLength(50);

                entity.Property(e => e.Transaccion)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TransaccionExc)
                    .IsRequired()
                    .HasColumnName("Transaccion_Exc")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TransaccionesModoProceso>(entity =>
            {
                entity.HasKey(e => e.TransaccionMenu);

                entity.ToTable("Transacciones_ModoProceso");

                entity.Property(e => e.TransaccionMenu)
                    .HasColumnName("Transaccion_Menu")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModoProceso)
                    .IsRequired()
                    .HasColumnName("Modo_Proceso")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Retorno).HasColumnType("text");
            });

            modelBuilder.Entity<UserEmpServ>(entity =>
            {
                entity.HasKey(e => new { e.Usuario, e.IdEmpresa, e.IdServicio })
                    .IsClustered(false);

                entity.Property(e => e.Usuario).HasMaxLength(65);

                entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");

                entity.Property(e => e.IdServicio).HasColumnName("ID_Servicio");

                entity.Property(e => e.CondicionPago)
                    .IsRequired()
                    .HasColumnName("Condicion_Pago")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EnvioPos)
                    .HasColumnName("ENVIO_POS")
                    .HasMaxLength(2)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Estado).HasDefaultValueSql("(0)");

                entity.Property(e => e.VisualizaDetalle)
                    .IsRequired()
                    .HasDefaultValueSql("(1)");
            });

            modelBuilder.Entity<UserEmpServT>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("UserEmpServ_T");

                entity.Property(e => e.CondicionPago)
                    .IsRequired()
                    .HasColumnName("Condicion_Pago")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");

                entity.Property(e => e.IdServicio).HasColumnName("ID_Servicio");

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(65);
            });

            modelBuilder.Entity<UserEmpresaServicioView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("User_Empresa_Servicio_VIEW");

                entity.Property(e => e.CodigoServicio)
                    .IsRequired()
                    .HasColumnName("Codigo_Servicio")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionServicio)
                    .IsRequired()
                    .HasColumnName("Descripcion_Servicio")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCorto)
                    .HasColumnName("Nombre_Corto")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(65);
            });

            modelBuilder.Entity<UsuarioPreguntasDesafio>(entity =>
            {
                entity.HasKey(e => new { e.NombreCorto, e.NumeroPregunta });

                entity.ToTable("Usuario_Preguntas_Desafio");

                entity.Property(e => e.NombreCorto).HasMaxLength(65);

                entity.Property(e => e.NumeroPregunta).HasColumnName("Numero_Pregunta");

                entity.Property(e => e.Pregunta)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Respuesta)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.NombreCortoNavigation)
                    .WithMany(p => p.UsuarioPreguntasDesafio)
                    .HasForeignKey(d => d.NombreCorto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Preguntas_Desafio_Usuarios");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.NombreCorto)
                    .IsClustered(false);

                entity.HasIndex(e => e.Cedula)
                    .HasName("Idx_Usuarios_cedula")
                    .IsClustered();

                entity.HasIndex(e => e.Estado)
                    .HasName("_dta_index_Usuarios_8_1646628909__K36");

                entity.HasIndex(e => e.Grupo)
                    .HasName("_dta_index_Usuarios_c_11_1646628909__K5")
                    .IsClustered();

                entity.HasIndex(e => e.NombreCorto)
                    .HasName("_dta_index_Usuarios_c_10_1646628909__K1")
                    .IsClustered();

                entity.HasIndex(e => e.OficinaBanco)
                    .HasName("_dta_index_Usuarios_8_1646628909__K7");

                entity.HasIndex(e => new { e.Estado, e.OficinaBanco })
                    .HasName("_dta_index_Usuarios_8_1646628909__K36_K7");

                entity.HasIndex(e => new { e.Estado, e.OficinaBanco, e.NombreCorto })
                    .HasName("_dta_index_Usuarios_8_1646628909__K36_K7_K1");

                entity.HasIndex(e => new { e.NombreCorto, e.Email, e.Cedula })
                    .HasName("_dta_index_Usuarios_OPT1");

                entity.HasIndex(e => new { e.NombreCorto, e.Estado, e.OficinaBanco })
                    .HasName("_dta_index_Usuarios_8_1646628909__K1_K36_K7");

                entity.HasIndex(e => new { e.OficinaBanco, e.Estado, e.NombreCorto })
                    .HasName("_dta_index_Usuarios_15_1646628909__K7_K36_K1");

                entity.HasIndex(e => new { e.Nombre, e.Grupo, e.Apellido, e.NombreCorto })
                    .HasName("IND_CO_Usuarios_CatalogoProductos");

                entity.HasIndex(e => new { e.PerfilReferencia, e.Estado, e.OficinaBanco, e.NombreCorto })
                    .HasName("_dta_index_Usuarios_8_1646628909__K36_K7_K1_16");

                entity.HasIndex(e => new { e.PerfilReferencia, e.NombreCorto, e.Estado, e.OficinaBanco })
                    .HasName("_dta_index_Usuarios_8_1646628909__K1_K36_K7_16");

                entity.HasIndex(e => new { e.PerfilReferencia, e.OficinaBanco, e.Estado, e.NombreCorto })
                    .HasName("_dta_index_Usuarios_8_1646628909__K7_K36_K1_16");


                entity.Property(e => e.NombreCorto).HasMaxLength(65);

                entity.Property(e => e.ActualizaDatos).HasColumnName("Actualiza_Datos");

                entity.Property(e => e.Alias)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AprobacionGeneral)
                    .IsRequired()
                    .HasColumnName("Aprobacion_General")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CambioClave).HasColumnName("Cambio_Clave");

                entity.Property(e => e.Cedula).HasMaxLength(13);

                entity.Property(e => e.CodGrupoFinanciero).HasMaxLength(20);

                entity.Property(e => e.CodigoReferencia)
                    .IsRequired()
                    .HasColumnName("Codigo_Referencia")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CodigoSucursal)
                    .HasColumnName("Codigo_Sucursal")
                    .HasMaxLength(10);

                entity.Property(e => e.Descripcion).HasMaxLength(200);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EnvioNotificacion).HasColumnName("Envio_Notificacion");

                entity.Property(e => e.EnvioPos)
                    .HasColumnName("ENVIO_POS")
                    .HasMaxLength(2)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Deshabilitado')");

                entity.Property(e => e.FuenteInformacionXml)
                    .IsRequired()
                    .HasColumnName("Fuente_Informacion_XML")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('FILE')");

                entity.Property(e => e.Grupo).HasMaxLength(65);

                entity.Property(e => e.IdAgencia)
                    .HasColumnName("id_agencia")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IdPersona).HasColumnName("Id_Persona");

                entity.Property(e => e.ManejoGrupo).HasColumnName("Manejo_Grupo");

                entity.Property(e => e.NivelesMontosGeneral)
                    .IsRequired()
                    .HasColumnName("Niveles_Montos_General")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NomGrupoFinanciero).HasMaxLength(50);

                entity.Property(e => e.Nombre).HasMaxLength(40);

                entity.Property(e => e.NombreOfBanco)
                    .HasColumnName("Nombre_OfBanco")
                    .HasMaxLength(50);

                entity.Property(e => e.NombreSucursal)
                    .HasColumnName("Nombre_Sucursal")
                    .HasMaxLength(50);

                entity.Property(e => e.OficinaBanco)
                    .HasColumnName("Oficina_Banco")
                    .HasMaxLength(10);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PerfilReferencia)
                    .IsRequired()
                    .HasColumnName("Perfil_Referencia")
                    .HasMaxLength(65)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PerfilTipo)
                    .HasColumnName("Perfil_Tipo")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RestriccionCuentas).HasColumnName("Restriccion_Cuentas");

                entity.Property(e => e.TipoEmpresa)
                    .IsRequired()
                    .HasColumnName("Tipo_Empresa")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TipoIdent)
                    .IsRequired()
                    .HasColumnName("Tipo_Ident")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('C')");

                entity.Property(e => e.TiposFirmasGeneral)
                    .IsRequired()
                    .HasColumnName("Tipos_Firmas_General")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UnicoLogon).HasColumnName("Unico_Logon");

             

                entity.Property(e => e.UsuarioAd).HasColumnName("UsuarioAD");

                entity.Property(e => e.UsuarioSupervisor).HasColumnName("Usuario_Supervisor");

                entity.HasOne(d => d.GrupoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.Grupo)
                    .HasConstraintName("FK_Usuarios_Grupos");
            });

            modelBuilder.Entity<UsuariosAgencias>(entity =>
            {
                entity.HasKey(e => new { e.NombreCorto, e.CodigoSucursal, e.IdAgencia });

                entity.ToTable("Usuarios_Agencias");

                entity.HasIndex(e => e.OficinaBanco)
                    .HasName("_dta_index_Usuarios_Agencias_8_345768289__K6");

                entity.HasIndex(e => e.UagPredeterminado)
                    .HasName("_dta_index_Usuarios_Agencias_8_345768289__K11");

                entity.HasIndex(e => new { e.NombreCorto, e.OficinaBanco })
                    .HasName("_dta_index_Usuarios_Agencias_8_345768289__K1_K6");

                entity.HasIndex(e => new { e.OficinaBanco, e.NombreCorto })
                    .HasName("_dta_stat_345768289_6_1");

                entity.HasIndex(e => new { e.CodigoSucursal, e.CodAgencia, e.NombreCorto })
                    .HasName("_dta_index_Usuarios_Agencias_OPT1");

                entity.HasIndex(e => new { e.UagPredeterminado, e.NombreCorto, e.OficinaBanco })
                    .HasName("_dta_stat_345768289_11_1_6");

                entity.HasIndex(e => new { e.NombreCorto, e.CodigoSucursal, e.NombreSucursal, e.IdAgencia, e.NombreAgencia, e.NombreOfBanco, e.CodAgencia, e.EnvioPos, e.Estado, e.UagPredeterminado, e.EmpId, e.OficinaBanco })
                    .HasName("_dta_index_Usuarios_Agencias_8_345768289__K6_1_2_3_4_5_7_8_9_10_11_12");

                entity.Property(e => e.NombreCorto).HasMaxLength(130);

                entity.Property(e => e.CodigoSucursal)
                    .HasColumnName("Codigo_Sucursal")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.IdAgencia)
                    .HasColumnName("id_agencia")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.CodAgencia)
                    .IsRequired()
                    .HasColumnName("Cod_Agencia")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.EmpId).HasColumnName("emp_id");

                entity.Property(e => e.EnvioPos)
                    .HasColumnName("ENVIO_POS")
                    .HasMaxLength(2)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasMaxLength(2)
                    .HasDefaultValueSql("('A')");

                entity.Property(e => e.NombreAgencia)
                    .IsRequired()
                    .HasColumnName("Nombre_Agencia")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.NombreOfBanco)
                    .IsRequired()
                    .HasColumnName("Nombre_OfBanco")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.NombreSucursal)
                    .IsRequired()
                    .HasColumnName("Nombre_Sucursal")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.OficinaBanco)
                    .IsRequired()
                    .HasColumnName("Oficina_Banco")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.UagFin)
                    .HasColumnName("uag_fin")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UagInicio)
                    .HasColumnName("uag_inicio")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UagPredeterminado)
                    .IsRequired()
                    .HasColumnName("uag_predeterminado")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");
            });

            modelBuilder.Entity<UsuariosLogon>(entity =>
            {
                entity.HasKey(e => new { e.IdLogon, e.NombreCorto, e.Aplicacion })
                    .IsClustered(false);

                entity.ToTable("Usuarios_Logon");

                entity.Property(e => e.IdLogon)
                    .HasColumnName("Id_Logon")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.NombreCorto).HasMaxLength(65);

                entity.Property(e => e.Aplicacion).HasMaxLength(50);

                entity.Property(e => e.DireccionIp)
                    .IsRequired()
                    .HasColumnName("Direccion_IP")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('0.0.0.0')");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('LOGOFF')");

                entity.Property(e => e.FechaHora)
                    .HasColumnName("Fecha_Hora")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

          

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
