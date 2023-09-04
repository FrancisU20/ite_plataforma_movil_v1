using System;
using LogicaDatos.ModelsServicioDomicilio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class ServicioDomicilioContext : DbContext
    {
        public ServicioDomicilioContext()
        {
        }

        public ServicioDomicilioContext(DbContextOptions<ServicioDomicilioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SdCiudadesServicioDomicilio> SdCiudadesServicioDomicilio { get; set; }
        public virtual DbSet<SdClientes> SdClientes { get; set; }
        public virtual DbSet<SdDatosEcommerce> SdDatosEcommerce { get; set; }
        public virtual DbSet<SdDatosMovil> SdDatosMovil { get; set; }
        public virtual DbSet<SdDirecciones> SdDirecciones { get; set; }
        public virtual DbSet<SdEventos> SdEventos { get; set; }
        public virtual DbSet<SdGestionPedido> SdGestionPedido { get; set; }
        public virtual DbSet<SdMedFreCanje> SdMedFreCanje { get; set; }
        public virtual DbSet<SdMotorizado> SdMotorizado { get; set; }
        public virtual DbSet<SdMotorizadoPedidoCab> SdMotorizadoPedidoCab { get; set; }
        public virtual DbSet<SdParEnlacePrioridad> SdParEnlacePrioridad { get; set; }
        public virtual DbSet<SdParEstadoPedido> SdParEstadoPedido { get; set; }
        public virtual DbSet<SdParSecuencia> SdParSecuencia { get; set; }
        public virtual DbSet<SdPedidoInactivo> SdPedidoInactivo { get; set; }
        public virtual DbSet<SdPedidoTarjetas> SdPedidoTarjetas { get; set; }
        public virtual DbSet<SdPedidosCab> SdPedidosCab { get; set; }
        public virtual DbSet<SdPedidosDet> SdPedidosDet { get; set; }
        public virtual DbSet<SdPsicoArticuloSobrante> SdPsicoArticuloSobrante { get; set; }
        public virtual DbSet<SdPsicoDetalleReceta> SdPsicoDetalleReceta { get; set; }
        public virtual DbSet<SdPsicoResultado> SdPsicoResultado { get; set; }
        public virtual DbSet<SdRelClienteEntrega> SdRelClienteEntrega { get; set; }
        public virtual DbSet<SdRelClienteTelefono> SdRelClienteTelefono { get; set; }
        public virtual DbSet<SdRelFarmaciaZona> SdRelFarmaciaZona { get; set; }
        public virtual DbSet<SdRelMotorizadoZona> SdRelMotorizadoZona { get; set; }
        public virtual DbSet<SdTmpConsultaDescuento> SdTmpConsultaDescuento { get; set; }
        public virtual DbSet<SdTmpDatosRetencion> SdTmpDatosRetencion { get; set; }
        public virtual DbSet<SdTmpFacturasCupoEfectivo> SdTmpFacturasCupoEfectivo { get; set; }
        public virtual DbSet<SdTmpFormasPago> SdTmpFormasPago { get; set; }
        public virtual DbSet<SdTmpFpago> SdTmpFpago { get; set; }
        public virtual DbSet<SdTmpFpbonosCarga> SdTmpFpbonosCarga { get; set; }
        public virtual DbSet<SdTmpFpcheque> SdTmpFpcheque { get; set; }
        public virtual DbSet<SdTmpFpconvenioParametros> SdTmpFpconvenioParametros { get; set; }
        public virtual DbSet<SdTmpFpconveniosAutorizacion> SdTmpFpconveniosAutorizacion { get; set; }
        public virtual DbSet<SdTmpFpdescuentosDePromociones> SdTmpFpdescuentosDePromociones { get; set; }
        public virtual DbSet<SdTmpFpgenerales> SdTmpFpgenerales { get; set; }
        public virtual DbSet<SdTmpFppromocionesDescuentos> SdTmpFppromocionesDescuentos { get; set; }
        public virtual DbSet<SdTmpFptarjetas> SdTmpFptarjetas { get; set; }
        public virtual DbSet<SdTmpMedFrecCanjes> SdTmpMedFrecCanjes { get; set; }
        public virtual DbSet<SdTmpMedFrecFacturasCruces> SdTmpMedFrecFacturasCruces { get; set; }
        public virtual DbSet<SdTmpMedFrecInfoFacturas> SdTmpMedFrecInfoFacturas { get; set; }
        public virtual DbSet<SdTmpMedico> SdTmpMedico { get; set; }
        public virtual DbSet<SdTmpPromocionesCanje> SdTmpPromocionesCanje { get; set; }
        public virtual DbSet<SdTmpPromocionesDescuentoPromocional> SdTmpPromocionesDescuentoPromocional { get; set; }
        public virtual DbSet<SdTmpPromocionesDescuentosArticulos> SdTmpPromocionesDescuentosArticulos { get; set; }
        public virtual DbSet<SdTmpPromocionesFacturas> SdTmpPromocionesFacturas { get; set; }
        public virtual DbSet<SdTmpPromocionesGanadores> SdTmpPromocionesGanadores { get; set; }
        public virtual DbSet<SdTmpPromocionesMovPremios> SdTmpPromocionesMovPremios { get; set; }
        public virtual DbSet<SdTmpPromocionesMovPremiosActual> SdTmpPromocionesMovPremiosActual { get; set; }
        public virtual DbSet<SdTmpPromocionesMovPremiosDisponibles> SdTmpPromocionesMovPremiosDisponibles { get; set; }
        public virtual DbSet<SdTmpPromocionesPinesGanados> SdTmpPromocionesPinesGanados { get; set; }
        public virtual DbSet<SdTmpPromocionesPremios> SdTmpPromocionesPremios { get; set; }
        public virtual DbSet<SdTmpPromocionesPremiosConfirmados> SdTmpPromocionesPremiosConfirmados { get; set; }
        public virtual DbSet<SdTmpPromocionesRecargas> SdTmpPromocionesRecargas { get; set; }
        public virtual DbSet<SdTransferencias> SdTransferencias { get; set; }
        public virtual DbSet<SdZona> SdZona { get; set; }
        public virtual DbSet<SdZonaAdministradores> SdZonaAdministradores { get; set; }
        public virtual DbSet<TblCopagoDescuentoConvenio> TblCopagoDescuentoConvenio { get; set; }
        public virtual DbSet<TblUsuariosAcceso> TblUsuariosAcceso { get; set; }
        public virtual DbSet<PA_ResumenPedidosMotorizado> PA_ResumenPedidosMotorizados { get; set; }
        public virtual DbSet<SdTrackingMotorizadoPedidos> SdTrackingMotorizadoPedidos { get; set; }
        public virtual DbSet<SdClientesOneSignal> SdClientesOneSignal { get; set; }
        public virtual DbSet<SdTrackingVerificacionPedidos> SdTrackingVerificacionPedidos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SdClientesOneSignal>(entity =>
            {
                entity.HasKey(e => e.OsCodigo)
                    .HasName("PK__SD_Clien__E8CAAB15A70FEF9E");

                entity.ToTable("SD_ClientesOneSignal");

                entity.Property(e => e.OsCodigo).HasColumnName("os_codigo");

                entity.Property(e => e.OsFechaRegistro)
                    .HasColumnName("os_fecha_registro")
                    .HasColumnType("datetime");

                entity.Property(e => e.OsIdOnesignal)
                    .HasColumnName("os_id_onesignal")
                    .HasMaxLength(30);

                entity.Property(e => e.MotCodigo)
                    .HasColumnName("mot_codigo");

                entity.Property(e => e.OsUsuarioRegistro)
                    .HasColumnName("os_usuario_registro")
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<SdTrackingMotorizadoPedidos>(entity =>
            {
                entity.HasKey(e => e.TrkCodigo)
                    .HasName("PK__SD_Track__B00E1119F4D789A2");

                entity.ToTable("SD_TrackingMotorizadoPedidos");

                entity.Property(e => e.TrkCodigo).HasColumnName("trk_codigo");

                entity.Property(e => e.MotCodigo).HasColumnName("mot_codigo");

                entity.Property(e => e.TrkEstadoTraking)
                    .HasColumnName("trk_estado_traking")
                    .HasMaxLength(20);

                entity.Property(e => e.TrkFechaRegistro)
                    .HasColumnName("trk_fecha_registro")
                    .HasColumnType("datetime");

                entity.Property(e => e.TrkLatitud).HasColumnName("trk_latitud");

                entity.Property(e => e.TrkLongitud).HasColumnName("trk_longitud");

                entity.Property(e => e.TrkUsuarioRegistro)
                    .HasColumnName("trk_usuario_registro")
                    .HasMaxLength(25);

                entity.Property(e => e.TrkSignalrEnviado).HasColumnName("trk_signalr_enviado").HasMaxLength(1);
                entity.Property(e => e.TrkSignalrObservacion).HasColumnName("trk_signalr_observacion").HasMaxLength(400);
            });

            modelBuilder.Entity<SdTrackingVerificacionPedidos>(entity =>
            {
                entity.HasKey(e => new { e.TrkCodigo, e.PcaCodigo })
                    .HasName("PK__SD_Track__AC6EEF18662E9F46");

                entity.ToTable("SD_TrackingVerificacionPedidos");

                entity.Property(e => e.TrkCodigo).HasColumnName("trk_codigo");

                entity.Property(e => e.PcaCodigo).HasColumnName("pca_codigo");

                entity.Property(e => e.PcsSerieFactura)
                    .HasColumnName("pcs_serie_factura")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TkpFechaRegistro)
                    .HasColumnName("tkp_fecha_registro")
                    .HasColumnType("datetime");

                entity.Property(e => e.TkpObservacion)
                    .HasColumnName("tkp_observacion")
                    .HasMaxLength(200);

                entity.Property(e => e.TrpNumeroTransferencia)
                   .HasColumnName("tkp_numero_transferencia")
                   .HasMaxLength(40);

                entity.HasOne(d => d.PcaCodigoNavigation)
                    .WithMany(p => p.SdTrackingVerificacionPedidos)
                    .HasForeignKey(d => d.PcaCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_SD_TrackingVerificacionPedidos_SD_TrackingPedidosCab");

                entity.HasOne(d => d.TrkCodigoNavigation)
                    .WithMany(p => p.SdTrackingVerificacionPedidos)
                    .HasForeignKey(d => d.TrkCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_SD_TrackingVerificacionPedidos_SD_TrackingMotorizadoPedidos_1");
            });

            modelBuilder.Entity<PA_ResumenPedidosMotorizado>(entity =>
            {
                entity.HasKey(e => e.PcaCodigo)
                    .HasName("PK__TMPTEMPO__C60FE0104C502EE8");

                entity.ToTable("TMPTEMPORALPEDIDOS");

                entity.Property(e => e.PcaCodigo)
                    .HasColumnName("pca_codigo")
                    .ValueGeneratedNever();

                entity.Property(e => e.EspEstado)
                    .IsRequired()
                    .HasColumnName("esp_estado")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EspNombre)
                    .IsRequired()
                    .HasColumnName("esp_nombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PcaDireccionEntrega)
                    .IsRequired()
                    .HasColumnName("pca_direccion_entrega")
                    .IsUnicode(false);

                entity.Property(e => e.PcaFechaEntrega)
                    .HasColumnName("pca_fecha_entrega")
                    .HasColumnType("datetime");

                entity.Property(e => e.PcaFechaFacturado)
                    .HasColumnName("pca_fecha_facturado")
                    .HasColumnType("datetime");

                entity.Property(e => e.PcaFechaFarmacia)
                    .HasColumnName("pca_fecha_farmacia")
                    .HasColumnType("datetime");

                entity.Property(e => e.PcaFechaRecepcion)
                    .HasColumnName("pca_fecha_recepcion")
                    .HasColumnType("datetime");

                entity.Property(e => e.PcaTelefono)
                    .HasColumnName("pca_telefono")
                    .HasMaxLength(50);

                entity.Property(e => e.ZfaOficina)
                    .IsRequired()
                    .HasColumnName("zfa_oficina")
                    .HasMaxLength(3);

                entity.Property(e => e.ZfaOficinaNombre)
                    .IsRequired()
                    .HasColumnName("zfa_oficina_nombre")
                    .HasMaxLength(60);

                entity.Property(e => e.MotCodigo)
                .HasColumnName("mot_codigo");

                entity.Property(e => e.PcaSerieFactura)
                .HasColumnName("pca_serie_factura");

                entity.Property(e => e.PcaObservacion)
                .HasColumnName("pca_observacion");

                entity.Property(e => e.PcaObservacionVoucher)
                .HasColumnName("pca_observacion_voucher");


            });


            modelBuilder.Entity<SdCiudadesServicioDomicilio>(entity =>
            {
                entity.HasKey(e => e.CsdId)
                    .HasName("pk_sd_ciudadesserviciodomicili");

                entity.ToTable("SD_CiudadesServicioDomicilio");

                entity.Property(e => e.CsdId)
                    .HasColumnName("csd_id")
                    .HasMaxLength(3);

                entity.Property(e => e.CsdCiudad)
                    .HasColumnName("csd_ciudad")
                    .HasMaxLength(40);

                entity.Property(e => e.CsdEspectro)
                    .HasColumnName("csd_espectro")
                    .HasMaxLength(100);

                entity.Property(e => e.CsdEstado)
                    .HasColumnName("csd_estado")
                    .HasMaxLength(10);

                entity.Property(e => e.CsdObservacion)
                    .HasColumnName("csd_observacion")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<SdClientes>(entity =>
            {
                entity.HasKey(e => new { e.CliTipoIdCliente, e.CliNumeroIdCliente })
                    .HasName("PK_tbl_clientes");

                entity.ToTable("SD_Clientes");

                entity.HasComment(@"Autor:
Ing. Claudio Guerrón
Tabla que permite almacenar la información de los clientes nuevos que no estan registrados en la base de datos de clientes del EasyGestionClientes
");

                entity.Property(e => e.CliTipoIdCliente)
                    .HasColumnName("cli_tipo_id_cliente")
                    .HasMaxLength(1)
                    .HasComment("Indica el tipo de identificación del cliente, puede ser C=cédula, P=pasaporte, R=ruc,S= sin número, se relaciona con la tabla tbl_tipoident");

                entity.Property(e => e.CliNumeroIdCliente)
                    .HasColumnName("cli_numero_id_cliente")
                    .HasMaxLength(20)
                    .HasComment("Indica el número de identificación del cliente");

                entity.Property(e => e.Ciudad)
                    .HasColumnName("ciudad")
                    .HasMaxLength(3);

                entity.Property(e => e.CliActividadCliente)
                    .HasColumnName("cli_actividad_cliente")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Actividad del Cliente");

                entity.Property(e => e.CliCodigoVendedor)
                    .HasColumnName("cli_codigo_vendedor")
                    .HasMaxLength(10)
                    .HasComment("Indica el código de vendedor o funcionario asignado al cliente, se relaciona con la tabla tbl_vendedores");

                entity.Property(e => e.CliComentario)
                    .HasColumnName("cli_comentario")
                    .HasMaxLength(255)
                    .HasComment("Comentario general");

                entity.Property(e => e.CliCompania)
                    .IsRequired()
                    .HasColumnName("cli_compania")
                    .HasMaxLength(3)
                    .HasComment("Indica el código de la compania");

                entity.Property(e => e.CliContribuyenteEspecial)
                    .HasColumnName("cli_contribuyente_especial")
                    .HasMaxLength(1)
                    .HasComment("Indica si el cliente es contribuyente especial, 1= si es contribuyente, 0= no es contribuyente");

                entity.Property(e => e.CliControlCupo)
                    .IsRequired()
                    .HasColumnName("cli_Control_Cupo")
                    .HasMaxLength(1)
                    .HasComment("Indica si al cliente se le controla cupo o no, S= si se controla, N= no se controla");

                entity.Property(e => e.CliCupoCredito)
                    .HasColumnName("cli_cupo_credito")
                    .HasComment("Indica el cupo ed crédito asignado al cliente");

                entity.Property(e => e.CliEmail)
                    .HasColumnName("cli_email")
                    .HasMaxLength(100)
                    .HasComment("E-mail del cliente");

                entity.Property(e => e.CliEnvioPos)
                    .HasColumnName("cli_envio_pos")
                    .HasMaxLength(2)
                    .HasComment("Valida la comunicación del cliente");

                entity.Property(e => e.CliEsCliente)
                    .HasColumnName("cli_es_cliente")
                    .HasMaxLength(1)
                    .HasComment("Inidica si es cliente, S= cliente, N= no es cliente");

                entity.Property(e => e.CliEsGrupo)
                    .HasColumnName("cli_es_grupo")
                    .HasMaxLength(1)
                    .HasComment("Indica si es grupo o no");

                entity.Property(e => e.CliEsMedico)
                    .IsRequired()
                    .HasColumnName("cli_es_medico")
                    .HasMaxLength(1)
                    .HasComment("Indica si el cliente es Medico o No");

                entity.Property(e => e.CliEsProveedor)
                    .HasColumnName("cli_es_proveedor")
                    .HasMaxLength(1)
                    .HasComment("Inidica si es proveedor, S= proveedor, N= no es proveedor");

                entity.Property(e => e.CliEsempleado)
                    .IsRequired()
                    .HasColumnName("cli_esempleado")
                    .HasMaxLength(1)
                    .HasComment("Inidica si es empleado, S= empleado, N= no es empleado");

                entity.Property(e => e.CliEspecialidad)
                    .IsRequired()
                    .HasColumnName("cli_especialidad")
                    .HasMaxLength(100)
                    .HasComment("Especialidad del Médico");

                entity.Property(e => e.CliEstadoCartera)
                    .HasColumnName("cli_estado_cartera")
                    .HasMaxLength(20)
                    .HasComment("Estado de la cartera del cliente");

                entity.Property(e => e.CliEstatus)
                    .HasColumnName("cli_estatus")
                    .HasComment("Indica el estado del cliente, 0 indica activo y 1 inactivo");

                entity.Property(e => e.CliFechaCreacion)
                    .HasColumnName("cli_fecha_creacion")
                    .HasColumnType("datetime")
                    .HasComment("fecha de Creacion del Cliente");

                entity.Property(e => e.CliFechaIngresoCliente)
                    .HasColumnName("cli_fecha_ingreso_cliente")
                    .HasMaxLength(30)
                    .HasComment("Indica la fecha de ingreso del cliente");

                entity.Property(e => e.CliFechaNacimiento)
                    .HasColumnName("cli_fecha_nacimiento")
                    .HasColumnType("datetime")
                    .HasComment("Fecha de nacimiento del cliente.");

                entity.Property(e => e.CliIdCliente)
                    .HasColumnName("cli_id_cliente")
                    .HasComment("Número de cliente asignado por la base de datos")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CliIdLugarReferencia)
                    .HasColumnName("cli_id_lugar_referencia")
                    .HasMaxLength(5);

                entity.Property(e => e.CliLogicaConvenios)
                    .HasColumnName("cli_logica_convenios")
                    .HasMaxLength(50)
                    .HasComment("Logica Convenios.");

                entity.Property(e => e.CliNombreComercial)
                    .HasColumnName("cli_nombre_comercial")
                    .HasMaxLength(70)
                    .HasComment("Indica el nombre comercial del cliente");

                entity.Property(e => e.CliNombreRazon)
                    .HasColumnName("cli_nombre_razon")
                    .HasMaxLength(70)
                    .HasComment("Indica la razón social del cliente");

                entity.Property(e => e.CliNumeroIdGrupo)
                    .HasColumnName("cli_numero_id_grupo")
                    .HasMaxLength(15)
                    .HasComment("Indica el número de identificación del grupo empresarial donde pertenece el cliente");

                entity.Property(e => e.CliPlazoCredito)
                    .HasColumnName("cli_plazo_credito")
                    .HasComment("Indica los días de crédito concedidos al cliente");

                entity.Property(e => e.CliSaldoActual)
                    .HasColumnName("cli_saldo_actual")
                    .HasComment("Indica el saldo actual del cliente");

                entity.Property(e => e.CliSexo)
                    .HasColumnName("cli_sexo")
                    .HasMaxLength(1)
                    .HasComment("Sexo del Cliente.");

                entity.Property(e => e.CliTipoCliente)
                    .HasColumnName("cli_tipo_cliente")
                    .HasComment("Indica el tipo de cliente, se relaciona con la tbl_clasecliente");

                entity.Property(e => e.CliTipoIdGrupo)
                    .HasColumnName("cli_tipo_id_grupo")
                    .HasMaxLength(1)
                    .HasComment("Indica el tipo de identificación del grupo empresarial donde pertenece el cliente, puede ser C=cédula, P=pasaporte, R=ruc,S= sin número, se relaciona con la tabla tbl_tipoident");

                entity.Property(e => e.CliUsuarioCreacion)
                    .HasColumnName("cli_usuario_creacion")
                    .HasMaxLength(20)
                    .HasComment("Usuario que crea el Cliente");

                entity.Property(e => e.CliValidaCupoCorporativo)
                    .IsRequired()
                    .HasColumnName("cli_Valida_cupo_corporativo")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasComment("Valida el cupo del Corporativo");

                entity.Property(e => e.CodigoCategoria).HasColumnName("codigo_categoria");

                entity.Property(e => e.Convertibildad)
                    .HasColumnName("convertibildad")
                    .HasMaxLength(2);

                entity.Property(e => e.CveIdEstadoValidacion).HasColumnName("cve_id_estado_validacion");

                entity.Property(e => e.DescuentoConvertibilidad).HasColumnName("descuento_convertibilidad");

                entity.Property(e => e.ExcentoIva).HasColumnName("excento_iva");

                entity.Property(e => e.ExcentoRestriccion).HasColumnName("excento_restriccion");

                entity.Property(e => e.FechaVigenciaConsep)
                    .HasColumnName("fechaVigenciaConsep")
                    .HasColumnType("datetime");

                entity.Property(e => e.LicenciaCompraVentaConsep)
                    .HasColumnName("licenciaCompraVentaConsep")
                    .HasMaxLength(20);

                entity.Property(e => e.TieneBonificacion).HasColumnName("tiene_bonificacion");

                entity.Property(e => e.VentaMinimaPedido)
                    .HasColumnName("venta_minima_pedido")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<SdDatosEcommerce>(entity =>
            {
                entity.HasKey(e => new { e.DeReferencia, e.PcaCodigo })
                    .HasName("pk_sd_datosecommerce");

                entity.ToTable("SD_DatosEcommerce");

                entity.Property(e => e.DeReferencia)
                    .HasColumnName("de_referencia")
                    .HasMaxLength(200);

                entity.Property(e => e.PcaCodigo).HasColumnName("pca_codigo");

                entity.Property(e => e.DeCanal)
                    .IsRequired()
                    .HasColumnName("de_canal")
                    .HasMaxLength(50);

                entity.Property(e => e.DeEstado)
                    .HasColumnName("de_estado")
                    .HasMaxLength(50);

                entity.Property(e => e.DeFechaEcommerce)
                    .HasColumnName("de_fecha_ecommerce")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeObservacion).HasColumnName("de_observacion");

                entity.Property(e => e.EnvioPos)
                    .HasColumnName("envio_pos")
                    .HasMaxLength(5);
            });

            modelBuilder.Entity<SdDatosMovil>(entity =>
            {
                entity.HasKey(e => new { e.DmNumeroIdcliente, e.DmNumeroMovil })
                    .HasName("pk_sd_datosmovil");

                entity.ToTable("SD_DatosMovil");

                entity.Property(e => e.DmNumeroIdcliente)
                    .HasColumnName("dm_numero_idcliente")
                    .HasMaxLength(20);

                entity.Property(e => e.DmNumeroMovil)
                    .HasColumnName("dm_numero_movil")
                    .HasMaxLength(20);

                entity.Property(e => e.DmContadorMovil).HasColumnName("dm_contador_movil");

                entity.Property(e => e.DmCoordenadas)
                    .HasColumnName("dm_coordenadas")
                    .HasMaxLength(200);

                entity.Property(e => e.DmObservacion)
                    .HasColumnName("dm_observacion")
                    .HasMaxLength(200);

                entity.Property(e => e.PcaCodigo).HasColumnName("pca_codigo");
            });

            modelBuilder.Entity<SdDirecciones>(entity =>
            {
                entity.HasKey(e => new { e.CliTipoIdCliente, e.CliNumeroIdcliente, e.DirIdDireccion });

                entity.ToTable("SD_Direcciones");

                entity.HasComment(@"Autor:
Ing. Claudio Guerrón

Tabla que me permite almacenar las Direcciones de los clientes nuevos que se creán desde el Servicio a Domicilio.
");

                entity.Property(e => e.CliTipoIdCliente)
                    .HasColumnName("cli_tipo_id_cliente")
                    .HasMaxLength(1)
                    .HasComment("Campo que permite almacenar el tipo de identificación del cliente.");

                entity.Property(e => e.CliNumeroIdcliente)
                    .HasColumnName("cli_numero_idcliente")
                    .HasMaxLength(20)
                    .HasComment("Campo que permite almacenar el numero del id del Cliente. Puede ser Cédula, RUC, Pasaporte.");

                entity.Property(e => e.DirIdDireccion)
                    .HasColumnName("dir_id_direccion")
                    .HasComment("Identificacion de la Dirección del cliente.");

                entity.Property(e => e.DirDireccion)
                    .HasColumnName("dir_direccion")
                    .HasMaxLength(200)
                    .HasComment("Dirección del Cliente ingresado.");

                entity.Property(e => e.DirEMail)
                    .HasColumnName("dir_e_mail")
                    .HasMaxLength(100)
                    .HasComment("correo electrónico del cliente.");

                entity.Property(e => e.DirEnvioPos)
                    .HasColumnName("dir_envio_pos")
                    .HasMaxLength(2)
                    .HasDefaultValueSql("('N')")
                    .HasComment("Envio pos.");

                entity.Property(e => e.DirNoEstablecimiento)
                    .HasColumnName("dir_no_establecimiento")
                    .HasMaxLength(10);

                entity.Property(e => e.DirNombreDireccion)
                    .HasColumnName("dir_nombre_direccion")
                    .HasMaxLength(20)
                    .HasComment("Nombre de la Direccion.");

                entity.Property(e => e.DirNombreEstablecimiento)
                    .HasColumnName("dir_nombre_establecimiento")
                    .HasMaxLength(80);

                entity.Property(e => e.DirNumFono1)
                    .HasColumnName("dir_num_fono1")
                    .HasMaxLength(20)
                    .HasComment("Numero del telefono principal");

                entity.Property(e => e.DirNumFono2)
                    .HasColumnName("dir_num_fono2")
                    .HasMaxLength(20)
                    .HasComment("Numero del teléfono secundario del cliente.");
            });

            modelBuilder.Entity<SdEventos>(entity =>
            {
                entity.HasKey(e => e.EvtId)
                    .HasName("pk_sd_eventos");

                entity.ToTable("SD_Eventos");

                entity.Property(e => e.EvtId).HasColumnName("evt_id");

                entity.Property(e => e.EvtFecha)
                    .HasColumnName("evt_fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.EvtNombre)
                    .HasColumnName("evt_nombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EvtObservacion)
                    .HasColumnName("evt_observacion")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SdGestionPedido>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SD_GestionPedido");

                entity.HasComment(@"Autor: Claudio Guerrón
Tabla que permite gestionar el pedido tanto en la farmacia como en el servidor. Además regulariza los estados del pedido.");

                entity.HasIndex(e => e.PcaCodigo)
                    .HasName("_dta_index_SD_GestionPedido_c_17_997578592__K1")
                    .IsClustered();

                entity.HasIndex(e => new { e.GesEstado, e.PcaCodigo, e.GesIpFarmacia })
                    .HasName("_dta_index_SD_GestionPedido_17_997578592__K9_K1_K4");

                entity.Property(e => e.GesCodigo)
                    .HasColumnName("ges_codigo")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.GesEstado)
                    .HasColumnName("ges_estado")
                    .HasMaxLength(20)
                    .HasComment("Estado del registro de la gestión del pedido. [ACTIVO->Indica que se debe operar con este registro del pedido.][INACTIVO->Indica que esta información ya fue procesada y cambio de estado por la reasignación del pedido a otra farmacia]");

                entity.Property(e => e.GesIpFarmacia)
                    .IsRequired()
                    .HasColumnName("ges_ip_farmacia")
                    .HasMaxLength(20)
                    .HasComment("Direccion IP de la Farmacia");

                entity.Property(e => e.GesMotorizadoFarmacia)
                    .IsRequired()
                    .HasColumnName("ges_motorizado_farmacia")
                    .HasMaxLength(50)
                    .HasComment("Campo que almacena dos tipos de valor [S->Si se guardo la asignación del Motorizado en la farmacia] [N->No se guardó la asignación del Motorizado en la farmacia].");

                entity.Property(e => e.GesMotorizadoServicioDomicilio)
                    .IsRequired()
                    .HasColumnName("ges_motorizado_servicio_domicilio")
                    .HasMaxLength(10)
                    .HasComment("Campo que almacena dos tipos de valor [S->Si se guardo la asignación del Motorizado en el 1800] [N->No se guardó la asignación del Motorizado en el 1800].");

                entity.Property(e => e.GesPedidoFarmacia)
                    .IsRequired()
                    .HasColumnName("ges_pedido_farmacia")
                    .HasMaxLength(10)
                    .HasComment("Campo que almacena dos tipos de valor [S->Si se guardo el pedido en la farmacia] [N->No se guardó el pedido en la farmacia].");

                entity.Property(e => e.GesPedidoServicioDomicilio)
                    .IsRequired()
                    .HasColumnName("ges_pedido_servicio_domicilio")
                    .HasMaxLength(10)
                    .HasComment("Campo que almacena dos tipos de valor [S->Si se guardo el pedido en el 1800] [N->No se guardó el pedido en el 1800].");

                entity.Property(e => e.GesScriptMotorizados)
                    .HasColumnName("ges_script_motorizados")
                    .HasColumnType("ntext")
                    .HasComment("Cadena con la información de inserción en la asignación del Motorizado.");

                entity.Property(e => e.GesScriptServicioDomicilio)
                    .HasColumnName("ges_script_servicio_domicilio")
                    .HasColumnType("ntext")
                    .HasComment("Cadena con la información de inserción del pedido.");

                entity.Property(e => e.PcaCodigo)
                    .HasColumnName("pca_codigo")
                    .HasComment("Campo que almacena el codigo del Pedido.");

                entity.HasOne(d => d.PcaCodigoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.PcaCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SD_GestionPedido_SD_Pedidos_Cab");
            });

            modelBuilder.Entity<SdMedFreCanje>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SD_MedFreCanje");

                entity.HasComment(@"Autor(a): Ing.Claudio Guerrón

Esta Tabla permite almacenar los datos de las facturas canjeadas en el sistema de Servicio a Domicilio, las cuales pasan a estar en estado reservado dentro de la aplicación Punto de Venta, para que no pueda canjear mientras no retire el pedido");

                entity.Property(e => e.CanArticulo)
                    .IsRequired()
                    .HasColumnName("can_articulo")
                    .HasMaxLength(15)
                    .HasComment("Codigo del Articulo ");

                entity.Property(e => e.CanCantidadFactura)
                    .HasColumnName("can_cantidad_factura")
                    .HasComment("Cantidad de articulos de la factura a canjear");

                entity.Property(e => e.CanCantidadPedido)
                    .HasColumnName("can_cantidad_pedido")
                    .HasComment("Cantidad del Pedido 1800");

                entity.Property(e => e.CanEstado)
                    .IsRequired()
                    .HasColumnName("can_estado")
                    .HasMaxLength(50)
                    .HasComment("Estado de este registro [A=Activo.- Cuando todavia no se factura, I=Inactivo.- Cuando el articulo ya se facturo]");

                entity.Property(e => e.CanIdCliente)
                    .IsRequired()
                    .HasColumnName("can_id_cliente")
                    .HasMaxLength(50)
                    .HasComment("Id del Cliente de Medicación Frecuente");

                entity.Property(e => e.CanNumFactura)
                    .IsRequired()
                    .HasColumnName("can_num_factura")
                    .HasMaxLength(20)
                    .HasComment("Numero de la factura con la cual se desea canjear");

                entity.Property(e => e.PcaCodigo)
                    .HasColumnName("pca_codigo")
                    .HasComment("Codigo de la Cabecera del Pedido para asignar a un pedido el valor a canjear");
            });

            modelBuilder.Entity<SdMotorizado>(entity =>
            {
                entity.HasKey(e => e.MotCodigo);

                entity.ToTable("SD_Motorizado");

                entity.HasComment(@"Autor: Ing. Claudio Guerrón

Esta tabla almacena los datos de los motorizados que envian a las farmacias");

                entity.HasIndex(e => e.MotCedula)
                    .HasName("UQ__SD_Motorizado__023D5A04")
                    .IsUnique();

                entity.Property(e => e.MotCodigo)
                    .HasColumnName("mot_codigo")
                    .HasComment(@"Almacena el Codigo del Motorizado
[Empieza en 1 es secuencial]");

                entity.Property(e => e.MotApellido)
                    .IsRequired()
                    .HasColumnName("mot_apellido")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Apellidos del motorizado");

                entity.Property(e => e.MotCedula)
                    .IsRequired()
                    .HasColumnName("mot_cedula")
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasComment("Cedula del motorizado");

                entity.Property(e => e.MotDireccion)
                    .IsRequired()
                    .HasColumnName("mot_direccion")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Dirección del Domicilio del motorizado");

                entity.Property(e => e.MotEstado)
                    .IsRequired()
                    .HasColumnName("mot_estado")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Estado del Motorizado");

                entity.Property(e => e.MotMoto)
                    .IsRequired()
                    .HasColumnName("mot_moto")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Número de placa de la moto ");

                entity.Property(e => e.MotNombre)
                    .IsRequired()
                    .HasColumnName("mot_nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Nombres del Motorizado");

                entity.Property(e => e.MotTelefono)
                    .IsRequired()
                    .HasColumnName("mot_telefono")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Telefono del motorizado");
            });

            modelBuilder.Entity<SdMotorizadoPedidoCab>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SD_MotorizadoPedido_Cab");

                entity.HasComment(@"Autor:Ing. Claudio Guerrón
Tabla donde se almacenará los datos de los pedidos relacionados con el motorizado");

                entity.HasIndex(e => e.PcaCodigo)
                    .HasName("_dta_index_SD_MotorizadoPedido_Cab_c_17_949578421__K1")
                    .IsClustered();

                entity.Property(e => e.MotCodigo)
                    .HasColumnName("mot_codigo")
                    .HasComment("Referencia a la tabla SD_Motorizado al campo [mot_codigo]");

                entity.Property(e => e.MpEstado)
                    .IsRequired()
                    .HasColumnName("mp_estado")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("Estado del Pedido relacionado con el motorizado");

                entity.Property(e => e.MpFecha)
                    .HasColumnName("mp_fecha")
                    .HasColumnType("datetime")
                    .HasComment(@"Fecha que le asignaron el pedido al motorizado
");

                entity.Property(e => e.PcaCodigo)
                    .HasColumnName("pca_codigo")
                    .HasComment("Referencia a la tabla SD_Pedidos_Cab campo [pca_codigo]");

                entity.HasOne(d => d.MotCodigoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MotCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SD_MotorizadoPedidoCab_SD_Motorizado");

                entity.HasOne(d => d.PcaCodigoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.PcaCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SD_MotorizadoPedido_Cab_SD_Pedidos_Cab");
            });

            modelBuilder.Entity<SdParEnlacePrioridad>(entity =>
            {
                entity.HasKey(e => e.EnlpId)
                    .HasName("pk_sd_par_enlaceprioridad");

                entity.ToTable("SD_PAR_EnlacePrioridad");

                entity.Property(e => e.EnlpId).HasColumnName("enlp_id");

                entity.Property(e => e.EnlpEstado)
                    .HasColumnName("enlp_estado")
                    .HasMaxLength(50);

                entity.Property(e => e.EnlpIp)
                    .HasColumnName("enlp_ip")
                    .HasMaxLength(15);

                entity.Property(e => e.EnlpObservacion)
                    .HasColumnName("enlp_observacion")
                    .HasMaxLength(100);

                entity.Property(e => e.EnlpOficina)
                    .HasColumnName("enlp_oficina")
                    .HasMaxLength(5);

                entity.Property(e => e.EnlpPrioridad).HasColumnName("enlp_prioridad");

                entity.Property(e => e.EnlpServidor)
                    .HasColumnName("enlp_servidor")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<SdParEstadoPedido>(entity =>
            {
                entity.HasKey(e => e.EspCodigo)
                    .HasName("PK_DOM_Estado_Pedido");

                entity.ToTable("SD_PAR_EstadoPedido");

                entity.HasComment(@"Autor:Ing. Claudio Guerrón
Almacenamos los estados del pedido para parametrizar");

                entity.Property(e => e.EspCodigo)
                    .HasColumnName("esp_codigo")
                    .HasComment("Almacena el codigo del estado del Pedido.[ Numeros enteros positivos empieza en 1, es secuencial]")
                    .ValueGeneratedNever();

                entity.Property(e => e.EspColorFueraTiempo)
                    .IsRequired()
                    .HasColumnName("esp_color_fuera_tiempo")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("Color fuera de tiempo del estado el cual se activará una vez terminado el tiempo maximo");

                entity.Property(e => e.EspColorPrincipal)
                    .IsRequired()
                    .HasColumnName("esp_color_principal")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("Color principal del estado");

                entity.Property(e => e.EspEstado)
                    .IsRequired()
                    .HasColumnName("esp_estado")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("Verificamos en que estado se encuentra el pedido: [A=Activo,I=Inactivo]");

                entity.Property(e => e.EspNombre)
                    .IsRequired()
                    .HasColumnName("esp_nombre")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Almacena el nombre del estado: [Pendiente es cuando recien se realizar el pedido,Farmacia: Es cuando esta ya almacenado en Farmacia listo para facturar,Facturado: Cuando se imprime en la factura, Entregado:una vez entregado al cliente, Inactivo_caja: Cuando el pedido es autorizado para volver a cargar el Pedido,Inactivo: Cuando el Pedido se inactiva en la farmacia y en el 1800].");

                entity.Property(e => e.EspTiempoMax)
                    .IsRequired()
                    .HasColumnName("esp_tiempo_max")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasComment("Almacena el tiempo máximo que el pedido debe estar en este estado en horas:minutos [00:00]");
            });

            modelBuilder.Entity<SdParSecuencia>(entity =>
            {
                entity.HasKey(e => e.SecNombreSecuencia);

                entity.ToTable("SD_PAR_Secuencia");

                entity.HasComment(@"Autor: Ing. Claudio Guerrón

Tabla que permite almacenar las secuencias de las tablas principales de los pedidos");

                entity.Property(e => e.SecNombreSecuencia)
                    .HasColumnName("sec_nombre_secuencia")
                    .HasMaxLength(100)
                    .HasComment("Campo en el cual se almacenará el nombre del campo que tendrá el valor de la secuencia.");

                entity.Property(e => e.SecValor)
                    .HasColumnName("sec_valor")
                    .HasComment("Valor entero de la secuencia, cada vez que consultamos, se actualiza el valor de la secuencia sumandole 1.");
            });

            modelBuilder.Entity<SdPedidoInactivo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SD_PedidoInactivo");

                entity.HasComment(@"Autor: Ing. Claudio Guerrón
Tabla que permite almacenar la información del motivo porque inactivan y reasignan los pedidos el usuario Administrador del Sistema.");

                entity.Property(e => e.PcaCodigo)
                    .HasColumnName("pca_codigo")
                    .HasComment("Codigo del Pedido");

                entity.Property(e => e.PinEstado)
                    .IsRequired()
                    .HasColumnName("pin_estado")
                    .HasMaxLength(50)
                    .HasComment("Estado de la Operacion.");

                entity.Property(e => e.PinFecha)
                    .HasColumnName("pin_fecha")
                    .HasColumnType("datetime")
                    .HasComment("Fecha completa de la Operación");

                entity.Property(e => e.PinObservacion)
                    .IsRequired()
                    .HasColumnName("pin_observacion")
                    .HasMaxLength(1000)
                    .HasComment("Comentario que se debe ingresar explicando el porque se realiza la operacion.");

                entity.Property(e => e.PinTipoOperacion)
                    .IsRequired()
                    .HasColumnName("pin_tipo_operacion")
                    .HasMaxLength(50)
                    .HasComment("Tipo de Operacion que se realiza[INACTIVA, REASIGNA]");

                entity.HasOne(d => d.PcaCodigoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.PcaCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SD_PedidoInactivo_SD_Pedidos_Cab");
            });

            modelBuilder.Entity<SdPedidoTarjetas>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SD_PedidoTarjetas");

                entity.HasComment(@"Autor: Ing. Claudio Guerrón

En esta tabla se almacenará la información de las tarjetas de Pfizer y Novartis.
");

                entity.Property(e => e.PcaCodigo)
                    .HasColumnName("pca_codigo")
                    .HasComment("Codigo del Pedido en el cuál tiene la tarjeta");

                entity.Property(e => e.PetNumeroTarjeta)
                    .IsRequired()
                    .HasColumnName("pet_numero_tarjeta")
                    .HasMaxLength(50)
                    .HasComment("Indica el Numero de la tarjeta.");

                entity.Property(e => e.PetProducto)
                    .IsRequired()
                    .HasColumnName("pet_producto")
                    .HasMaxLength(50)
                    .HasComment("Indica el codigo del producto.");

                entity.Property(e => e.PetTipo)
                    .IsRequired()
                    .HasColumnName("pet_tipo")
                    .HasMaxLength(50)
                    .HasComment("Indica el tipo de Tarjeta que es[N->NOVARTIS][F-PFIZER]");

                entity.HasOne(d => d.PcaCodigoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.PcaCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SD_PedidoTarjetas_SD_Pedidos_Cab");
            });

            modelBuilder.Entity<SdPedidosCab>(entity =>
            {
                entity.HasKey(e => e.PcaCodigo);

                entity.ToTable("SD_Pedidos_Cab");

                entity.HasIndex(e => new { e.PcaSerieFactura, e.PcaOficina, e.EspCodigo, e.PcaCodigo })
                    .HasName("_dta_index_SD_Pedidos_Cab_17_1669580986__K15_K4_K1_21");

                entity.HasIndex(e => new { e.PcaCliente, e.PcaTipoIdCliente, e.PcaFormaPago, e.PcaDireccionEntrega, e.PcaFechaRecepcion, e.PcaFechaFarmacia, e.PcaFechaFacturado, e.PcaFechaEntrega, e.PcaObservacion, e.PcaSubtotal, e.PcaSubtotalIva, e.PcaTotal, e.PcaListaPrecios, e.PcaUsuarioPedido, e.PcaExisteMf, e.PcaEnFarmacia, e.PcaSerieFactura, e.PcaDescuentoPromocion, e.PcaAplicaPromocion, e.PcaEsReasignacion, e.PcaRazonSocial, e.PcaTelefono, e.PcaCreditoFarmaenlace, e.PcaUsuario, e.PcaObservacionVoucher, e.PcaRespuestaVoucher, e.PcaZona, e.PcaOficina, e.EspCodigo, e.PcaCodigo })
                    .HasName("_dta_index_SD_Pedidos_Cab_17_1669580986__K18_K15_K4_K1_2_3_5_6_7_8_9_10_11_12_13_14_16_17_19_20_21_22_23_24_25_26_27_28_29_30");

                entity.HasIndex(e => new { e.PcaCliente, e.PcaTipoIdCliente, e.PcaFormaPago, e.PcaDireccionEntrega, e.PcaFechaRecepcion, e.PcaFechaFarmacia, e.PcaFechaFacturado, e.PcaFechaEntrega, e.PcaObservacion, e.PcaSubtotal, e.PcaSubtotalIva, e.PcaTotal, e.PcaOficina, e.PcaListaPrecios, e.PcaUsuarioPedido, e.PcaZona, e.PcaExisteMf, e.PcaEnFarmacia, e.PcaSerieFactura, e.PcaDescuentoPromocion, e.PcaAplicaPromocion, e.PcaEsReasignacion, e.PcaRazonSocial, e.PcaTelefono, e.PcaCreditoFarmaenlace, e.PcaUsuario, e.PcaObservacionVoucher, e.PcaRespuestaVoucher, e.EspCodigo, e.PcaCodigo })
                    .HasName("_dta_index_SD_Pedidos_Cab_17_1669580986__K4_K1_2_3_5_6_7_8_9_10_11_12_13_14_15_16_17_18_19_20_21_22_23_24_25_26_27_28_29_30");

                entity.HasIndex(e => new { e.PcaCodigo, e.PcaCliente, e.PcaTipoIdCliente, e.PcaFormaPago, e.PcaDireccionEntrega, e.PcaFechaRecepcion, e.PcaFechaFarmacia, e.PcaFechaFacturado, e.PcaFechaEntrega, e.PcaObservacion, e.PcaSubtotal, e.PcaSubtotalIva, e.PcaTotal, e.PcaOficina, e.PcaListaPrecios, e.PcaUsuarioPedido, e.PcaZona, e.PcaExisteMf, e.PcaEnFarmacia, e.PcaSerieFactura, e.PcaDescuentoPromocion, e.PcaAplicaPromocion, e.PcaEsReasignacion, e.PcaRazonSocial, e.PcaTelefono, e.PcaCreditoFarmaenlace, e.PcaUsuario, e.PcaObservacionVoucher, e.PcaRespuestaVoucher, e.EspCodigo })
                    .HasName("_dta_index_SD_Pedidos_Cab_17_1669580986__K30_K4_1_2_3_5_6_7_8_9_10_11_12_13_14_15_16_17_18_19_20_21_22_23_24_25_26_27_28_29");

                entity.Property(e => e.PcaCodigo)
                    .HasColumnName("pca_codigo")
                    .ValueGeneratedNever();

                entity.Property(e => e.EspCodigo).HasColumnName("esp_codigo");

                entity.Property(e => e.PcaAplicaPromocion)
                    .IsRequired()
                    .HasColumnName("pca_aplica_promocion")
                    .HasMaxLength(50);

                entity.Property(e => e.PcaCliente)
                    .IsRequired()
                    .HasColumnName("pca_cliente")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PcaCreditoFarmaenlace)
                    .HasColumnName("pca_credito_farmaenlace")
                    .HasMaxLength(2);

                entity.Property(e => e.PcaDescuentoPromocion).HasColumnName("pca_descuento_promocion");

                entity.Property(e => e.PcaDireccionEntrega)
                    .IsRequired()
                    .HasColumnName("pca_direccion_entrega")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.PcaEnFarmacia)
                    .IsRequired()
                    .HasColumnName("pca_en_farmacia")
                    .HasMaxLength(10);

                entity.Property(e => e.PcaEsReasignacion)
                    .IsRequired()
                    .HasColumnName("pca_es_reasignacion")
                    .HasMaxLength(50);

                entity.Property(e => e.PcaExisteMf)
                    .IsRequired()
                    .HasColumnName("pca_existe_mf")
                    .HasMaxLength(10);

                entity.Property(e => e.PcaFechaEntrega)
                    .HasColumnName("pca_fecha_entrega")
                    .HasColumnType("datetime");

                entity.Property(e => e.PcaFechaFacturado)
                    .HasColumnName("pca_fecha_facturado")
                    .HasColumnType("datetime");

                entity.Property(e => e.PcaFechaFarmacia)
                    .HasColumnName("pca_fecha_farmacia")
                    .HasColumnType("datetime");

                entity.Property(e => e.PcaFechaRecepcion)
                    .HasColumnName("pca_fecha_recepcion")
                    .HasColumnType("datetime");

                entity.Property(e => e.PcaFormaPago)
                    .IsRequired()
                    .HasColumnName("pca_forma_pago")
                    .HasMaxLength(50);

                entity.Property(e => e.PcaListaPrecios)
                    .IsRequired()
                    .HasColumnName("pca_lista_precios")
                    .HasMaxLength(10);

                entity.Property(e => e.PcaObservacion)
                    .IsRequired()
                    .HasColumnName("pca_observacion")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.PcaObservacionVoucher)
                    .HasColumnName("pca_observacion_voucher")
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.PcaOficina)
                    .IsRequired()
                    .HasColumnName("pca_oficina")
                    .HasMaxLength(3);

                entity.Property(e => e.PcaRazonSocial)
                    .IsRequired()
                    .HasColumnName("pca_razon_social")
                    .HasMaxLength(200);

                entity.Property(e => e.PcaRespuestaVoucher)
                    .HasColumnName("pca_respuesta_voucher")
                    .HasMaxLength(50);

                entity.Property(e => e.PcaSerieFactura)
                    .HasColumnName("pca_serie_factura")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PcaSubtotal).HasColumnName("pca_subtotal");

                entity.Property(e => e.PcaSubtotalIva).HasColumnName("pca_subtotal_iva");

                entity.Property(e => e.PcaTelefono)
                    .HasColumnName("pca_telefono")
                    .HasMaxLength(50);

                entity.Property(e => e.PcaTipoIdCliente)
                    .IsRequired()
                    .HasColumnName("pca_tipo_idCliente")
                    .HasMaxLength(10);

                entity.Property(e => e.PcaTotal).HasColumnName("pca_total");

                entity.Property(e => e.PcaUsuario)
                    .HasColumnName("pca_usuario")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PcaUsuarioPedido)
                    .IsRequired()
                    .HasColumnName("pca_usuario_pedido")
                    .HasMaxLength(30);

                entity.Property(e => e.PcaZona)
                    .IsRequired()
                    .HasColumnName("pca_zona")
                    .HasMaxLength(10);

                entity.HasOne(d => d.EspCodigoNavigation)
                    .WithMany(p => p.SdPedidosCab)
                    .HasForeignKey(d => d.EspCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SD_Pedidos_Cab_SD_PAR_EstadoPedido");
            });

            modelBuilder.Entity<SdPedidosDet>(entity =>
            {
                entity.HasKey(e => e.PdeCodigo);

                entity.ToTable("SD_Pedidos_Det");

                entity.HasComment(@"Autor: Ing. Claudio Guerrón
Tabla para almacenar el detalle de los pedidos");

                entity.HasIndex(e => new { e.PdeCodigo, e.PdeArticulo, e.PdeNombreArticulo, e.PdeCantidadDetalle, e.PdeCantidadFraccion, e.PdePrecio, e.PdeTieneTransferencia, e.PdeValorIva, e.PdeEsMf, e.PdeTieneDescuento, e.PdeValDescuento, e.PdeDescuentoPromocion, e.PdeCantidadTotal, e.PdeDescuentoCabecera, e.PdeEsDelivery, e.PdeValorDescuento, e.PdeEstado, e.PcaCodigo, e.PdeEsPromocion })
                    .HasName("_dta_index_SD_Pedidos_Det_17_1029578706__K8_K2_K14_1_3_4_5_6_7_9_10_11_12_13_15_16_17_18_19");

                entity.Property(e => e.PdeCodigo)
                    .HasColumnName("pde_codigo")
                    .HasComment("Almacena el código del detalle del pedido. [Números positivos empezando en 1 Secuencial]");

                entity.Property(e => e.PcaCodigo)
                    .HasColumnName("pca_codigo")
                    .HasComment("Referencia [SD_Pedidos_Cab campo: pca_codigo]");

                entity.Property(e => e.PdeArticulo)
                    .IsRequired()
                    .HasColumnName("pde_articulo")
                    .HasMaxLength(15)
                    .HasComment("Referencia [EasyGestionEmpresarial.tbl_articulo campo: codigo]");

                entity.Property(e => e.PdeCantidadDetalle)
                    .HasColumnName("pde_cantidad_detalle")
                    .HasComment("Almacena la cantidad en enteros del pedido");

                entity.Property(e => e.PdeCantidadFraccion)
                    .HasColumnName("pde_cantidad_fraccion")
                    .HasComment("Almacena la cantidad en fracción del Pedido");

                entity.Property(e => e.PdeCantidadTotal)
                    .HasColumnName("pde_cantidad_total")
                    .HasComment("Indica la cantidad total del pedido en unidades.");

                entity.Property(e => e.PdeDescuentoCabecera)
                    .HasColumnName("pde_descuento_cabecera")
                    .HasComment("Indica si el articulo tiene descuento de cabecera.");

                entity.Property(e => e.PdeDescuentoPromocion)
                    .HasColumnName("pde_descuento_promocion")
                    .HasComment("Indica el valor del descuento de la promocion.");

                entity.Property(e => e.PdeEsDelivery)
                    .HasColumnName("pde_es_delivery")
                    .HasMaxLength(50)
                    .HasComment("Indica si el Artículo es Delivery o No.");

                entity.Property(e => e.PdeEsMf)
                    .IsRequired()
                    .HasColumnName("pde_es_mf")
                    .HasMaxLength(50)
                    .HasComment("En este campo especificamos si el articulo corresponde a medicación frecuente. [S=SI, Corresponde a Medicación Frecuente,N=NO, Cuando el artículo no corresponde a Medicación Frecuente]");

                entity.Property(e => e.PdeEsPromocion)
                    .HasColumnName("pde_es_promocion")
                    .HasMaxLength(10)
                    .HasComment("Campo que indica si el registo de este articulo es Promoción o No.");

                entity.Property(e => e.PdeEstado)
                    .IsRequired()
                    .HasColumnName("pde_estado")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("Estado del Detalle del Pedido.[ A=Activo, I=Inactivo]");

                entity.Property(e => e.PdeNombreArticulo)
                    .IsRequired()
                    .HasColumnName("pde_nombre_articulo")
                    .HasMaxLength(200)
                    .HasComment("Indica el nombre del artículo");

                entity.Property(e => e.PdePrecio)
                    .HasColumnName("pde_precio")
                    .HasComment("Precio de venta del producto");

                entity.Property(e => e.PdeTieneDescuento)
                    .HasColumnName("pde_tiene_descuento")
                    .HasMaxLength(50)
                    .HasComment("Campo para almacenar si tiene o no el articulo descuentos. [SI,NO]");

                entity.Property(e => e.PdeTieneTransferencia)
                    .IsRequired()
                    .HasColumnName("pde_tiene_transferencia")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("Almacena el valor en caso de tener Transferencia[S=Si,N=No]");

                entity.Property(e => e.PdeValDescuento)
                    .HasColumnName("pde_val_descuento")
                    .HasComment("Campo para almacenar el valor del descuento.[Numero Decimal]");

                entity.Property(e => e.PdeValorDescuento)
                    .HasColumnName("pde_valor_descuento")
                    .HasComment("Indica el valor total del precio menos el descuento ");

                entity.Property(e => e.PdeValorIva)
                    .HasColumnName("pde_valor_iva")
                    .HasComment("Almacena el valor del IVA del total del pedido");

                entity.HasOne(d => d.PcaCodigoNavigation)
                    .WithMany(p => p.SdPedidosDet)
                    .HasForeignKey(d => d.PcaCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SD_Pedidos_Det_SD_Pedidos_Cab");
            });

            modelBuilder.Entity<SdPsicoArticuloSobrante>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SD_PsicoArticuloSobrante");

                entity.HasComment(@"Autor: Ing. Claudio Guerrón

Tabla que permite almacenar los datos de los articulos sobrantes de las recetas de psicotrópicos.");

                entity.Property(e => e.PdrCodigo)
                    .IsRequired()
                    .HasColumnName("pdr_codigo")
                    .HasMaxLength(50)
                    .HasComment("Código del Artículo");

                entity.Property(e => e.PdrDescripcion)
                    .IsRequired()
                    .HasColumnName("pdr_descripcion")
                    .HasMaxLength(300)
                    .HasComment("Descripción del Artículo");

                entity.Property(e => e.PdrEnteroFactura)
                    .HasColumnName("pdr_entero_factura")
                    .HasComment("Cantidad entera del pedido.");

                entity.Property(e => e.PdrEnteroSaldo)
                    .HasColumnName("pdr_entero_saldo")
                    .HasComment("Saldo en enteros de la receta.");

                entity.Property(e => e.PdrEnterosReceta)
                    .HasColumnName("pdr_enteros_receta")
                    .HasComment("Cantidad en enteros de la receta");

                entity.Property(e => e.PdrEnvioPos)
                    .IsRequired()
                    .HasColumnName("pdr_envio_pos")
                    .HasMaxLength(4)
                    .HasComment("Envio Pos");

                entity.Property(e => e.PdrFraccionFactura)
                    .HasColumnName("pdr_fraccion_factura")
                    .HasComment("Cantidad fraccion del Pedido.");

                entity.Property(e => e.PdrFraccionReceta)
                    .HasColumnName("pdr_fraccion_receta")
                    .HasComment("Cantidad fracción de la receta");

                entity.Property(e => e.PdrFraccionSaldo)
                    .HasColumnName("pdr_fraccion_saldo")
                    .HasComment("Saldo en fracción de la receta");

                entity.Property(e => e.PdrItem)
                    .IsRequired()
                    .HasColumnName("pdr_item")
                    .HasMaxLength(50)
                    .HasComment("item de la receta");

                entity.Property(e => e.PdrNumeroIdCliente)
                    .IsRequired()
                    .HasColumnName("pdr_numero_id_cliente")
                    .HasMaxLength(20)
                    .HasComment("Numero de identificación del Cliente");

                entity.Property(e => e.PdrSerieFactura)
                    .IsRequired()
                    .HasColumnName("pdr_serie_factura")
                    .HasMaxLength(20)
                    .HasComment("Indica el numero del Pedido y luego en la facturación indica la serie de la factura.");

                entity.Property(e => e.PdrSerieReceta)
                    .IsRequired()
                    .HasColumnName("pdr_serie_receta")
                    .HasMaxLength(50)
                    .HasComment("Serie de la receta");

                entity.Property(e => e.PdrUnidadPos)
                    .IsRequired()
                    .HasColumnName("pdr_unidad_pos")
                    .HasMaxLength(4)
                    .HasComment("Valor de la unidad pos");

                entity.Property(e => e.PdrValorPos)
                    .IsRequired()
                    .HasColumnName("pdr_valor_pos")
                    .HasMaxLength(4)
                    .HasComment("Valor pos");
            });

            modelBuilder.Entity<SdPsicoDetalleReceta>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SD_PsicoDetalleReceta");

                entity.HasComment(@"Autor: Ing. Claudio Guerrón

Tabla que permite almacenar el detalle de la receta.");

                entity.Property(e => e.PdrCodigo)
                    .IsRequired()
                    .HasColumnName("pdr_codigo")
                    .HasMaxLength(50)
                    .HasComment("Codigo del Artículo");

                entity.Property(e => e.PdrDescripcion)
                    .IsRequired()
                    .HasColumnName("pdr_descripcion")
                    .HasMaxLength(300)
                    .HasComment("Nombre del Articulo");

                entity.Property(e => e.PdrEnteroFactura)
                    .HasColumnName("pdr_entero_factura")
                    .HasComment("Numero de articulos enteros del pedido");

                entity.Property(e => e.PdrEnteroSaldo)
                    .HasColumnName("pdr_entero_saldo")
                    .HasComment("Numero de articulos enteros restando la receta menos el pedido");

                entity.Property(e => e.PdrEnterosReceta)
                    .HasColumnName("pdr_enteros_receta")
                    .HasComment("Número de articulos enteros de la receta");

                entity.Property(e => e.PdrEnvioPos)
                    .HasColumnName("pdr_envio_pos")
                    .HasMaxLength(4)
                    .HasComment("Envio Pos");

                entity.Property(e => e.PdrFraccionFactura)
                    .HasColumnName("pdr_fraccion_factura")
                    .HasComment("Numero de articulos fraccion del Pedido");

                entity.Property(e => e.PdrFraccionReceta)
                    .HasColumnName("pdr_fraccion_receta")
                    .HasComment("Numero de Artículos en fracción de la receta");

                entity.Property(e => e.PdrFraccionSaldo)
                    .HasColumnName("pdr_fraccion_saldo")
                    .HasComment("Numero de articulos fraccion restando la receta menos el pedido");

                entity.Property(e => e.PdrItem)
                    .IsRequired()
                    .HasColumnName("pdr_item")
                    .HasMaxLength(50)
                    .HasComment("Numero de Item");

                entity.Property(e => e.PdrNumeroIdCliente)
                    .IsRequired()
                    .HasColumnName("pdr_numero_id_cliente")
                    .HasMaxLength(20)
                    .HasComment("Numero de identificacion del cliente, Cedula, RUC, pasaporte");

                entity.Property(e => e.PdrSerieFactura)
                    .IsRequired()
                    .HasColumnName("pdr_serie_factura")
                    .HasMaxLength(20)
                    .HasComment("Campo donde se almacena el código del Pedido, y cuando ya sea factura ira la serie de la Factura");

                entity.Property(e => e.PdrSerieReceta)
                    .IsRequired()
                    .HasColumnName("pdr_serie_receta")
                    .HasMaxLength(50)
                    .HasComment("Numero de Serie de la Receta");

                entity.Property(e => e.PdrUnidadPos)
                    .IsRequired()
                    .HasColumnName("pdr_unidad_pos")
                    .HasMaxLength(4)
                    .HasComment("Tipo de Unidad del artículo");

                entity.Property(e => e.PdrValorPos)
                    .IsRequired()
                    .HasColumnName("pdr_valor_pos")
                    .HasMaxLength(4)
                    .HasComment("Valor Pos");
            });

            modelBuilder.Entity<SdPsicoResultado>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SD_PsicoResultado");

                entity.HasComment(@"Autor: Ing. Claudio Guerrón
Tabla con la información de resultados de Psicotrópicos. ");

                entity.Property(e => e.PcaCodigo)
                    .HasColumnName("pca_codigo")
                    .HasComment("Referencia de la tabla SD_Pedido_Cab. [tipo: Bigint]");

                entity.Property(e => e.PreCodigoMedico)
                    .IsRequired()
                    .HasColumnName("pre_codigo_medico")
                    .HasMaxLength(50)
                    .HasComment("Código del Médico");

                entity.Property(e => e.PreDireccionMedico)
                    .IsRequired()
                    .HasColumnName("pre_direccion_medico")
                    .HasMaxLength(150)
                    .HasComment("Dirección del Médico");

                entity.Property(e => e.PreEspecialidad)
                    .IsRequired()
                    .HasColumnName("pre_especialidad")
                    .HasMaxLength(50)
                    .HasComment("Especialidad del Médico");

                entity.Property(e => e.PreEstado)
                    .IsRequired()
                    .HasColumnName("pre_estado")
                    .HasMaxLength(50)
                    .HasComment("estado del Igreso de la información");

                entity.Property(e => e.PreFechaReceta)
                    .IsRequired()
                    .HasColumnName("pre_fecha_receta")
                    .HasMaxLength(50)
                    .HasComment("Fecha de la Receta con la cual se realiza la compra");

                entity.Property(e => e.PreNombreMedico)
                    .IsRequired()
                    .HasColumnName("pre_nombre_medico")
                    .HasMaxLength(80)
                    .HasComment("Nombre del Médico de la Receta");

                entity.Property(e => e.PreNumeroInh)
                    .IsRequired()
                    .HasColumnName("pre_numero_inh")
                    .HasMaxLength(50)
                    .HasComment("Codigo INH del Médico asignado por Operaciones");

                entity.Property(e => e.PreSerieReceta)
                    .IsRequired()
                    .HasColumnName("pre_serie_receta")
                    .HasMaxLength(50)
                    .HasComment("Serie de la Receta ingresado");

                entity.Property(e => e.PreTelefonoMedico)
                    .IsRequired()
                    .HasColumnName("pre_telefono_medico")
                    .HasMaxLength(50)
                    .HasComment("Número de teléfono del médico");

                entity.Property(e => e.PreTipoMedico)
                    .IsRequired()
                    .HasColumnName("pre_tipo_medico")
                    .HasMaxLength(50)
                    .HasComment("Tipo de Médico");

                entity.HasOne(d => d.PcaCodigoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.PcaCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SD_PsicoResultado_SD_Pedidos_Cab");
            });

            modelBuilder.Entity<SdRelClienteEntrega>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SD_REL_ClienteEntrega");

                entity.HasComment(@"Autor: Claudio Guerron
Almacena las direccion de envio del pedido que ha solicitado cada cliente.");

                entity.Property(e => e.CenDireccion)
                    .IsRequired()
                    .HasColumnName("cen_direccion")
                    .HasMaxLength(300)
                    .HasComment("Dirección donde fue entregado el pedido");

                entity.Property(e => e.CenFechaRegistro)
                    .HasColumnName("cen_fecha_registro")
                    .HasColumnType("datetime")
                    .HasComment("Fecha de Registro de este campo");

                entity.Property(e => e.CenNumeroIdCliente)
                    .IsRequired()
                    .HasColumnName("cen_numero_idCliente")
                    .HasMaxLength(20)
                    .HasComment("Referencia[EasyGestionEmpresarial.tbl_clientes campo: numero_idCliente] ");

                entity.Property(e => e.CenProvincia)
                    .IsRequired()
                    .HasColumnName("cen_provincia")
                    .HasMaxLength(2)
                    .HasComment("Referencia [EasyGestionEmpresarial.tbl_zona campo: zona]");

                entity.Property(e => e.CenProvinciaNombre)
                    .HasColumnName("cen_provincia_nombre")
                    .HasMaxLength(50)
                    .HasComment("Almacena el nombre de la provincia donde se entrega el envío");

                entity.Property(e => e.CenZona)
                    .IsRequired()
                    .HasColumnName("cen_zona")
                    .HasMaxLength(50)
                    .HasComment("Codigo de la zona donde se encuentra la dirección");

                entity.Property(e => e.CenZonaNombre)
                    .HasColumnName("cen_zona_nombre")
                    .HasMaxLength(100)
                    .HasComment("Almacena el nombre de la zona donde se entrega el envío");
            });

            modelBuilder.Entity<SdRelClienteTelefono>(entity =>
            {
                entity.HasKey(e => new { e.CteCliente, e.CteTelefono });

                entity.ToTable("SD_REL_ClienteTelefono");

                entity.HasComment(@"Autor:Ing. Claudio Guerrón

Tabla que me permite almacenar los datos de los telefonos del cliente cuando entran las llamadas al Call center del 1800");

                entity.Property(e => e.CteCliente)
                    .HasColumnName("cte_cliente")
                    .HasMaxLength(50)
                    .HasComment("Campo que me permite almacenar el Id del cliente");

                entity.Property(e => e.CteTelefono)
                    .HasColumnName("cte_telefono")
                    .HasMaxLength(50)
                    .HasComment("Campo que me permite almacenar el teléfono del cliente");

                entity.Property(e => e.CteEstado)
                    .IsRequired()
                    .HasColumnName("cte_estado")
                    .HasMaxLength(50)
                    .HasComment("Campo para almacenar el estado del cliente");
            });

            modelBuilder.Entity<SdRelFarmaciaZona>(entity =>
            {
                entity.HasKey(e => e.ZfaCodigo)
                    .HasName("PK_DOM_FarmaciaZona");

                entity.ToTable("SD_REL_FarmaciaZona");

                entity.HasComment(@"Autor: Claudio Guerrón
En esta tabla almacenamos los datos de las oficinas asignadas a cada zona");

                entity.Property(e => e.ZfaCodigo)
                    .HasColumnName("zfa_codigo")
                    .HasComment("Almacena el código de la asignación de la farmacia a la zona");

                entity.Property(e => e.ZfaEstado)
                    .IsRequired()
                    .HasColumnName("zfa_estado")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("Estado del registro [A=Activo,I=Inactivo]");

                entity.Property(e => e.ZfaIp)
                    .IsRequired()
                    .HasColumnName("zfa_ip")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("Almacena la ip del servidor de la máquina");

                entity.Property(e => e.ZfaOficina)
                    .IsRequired()
                    .HasColumnName("zfa_oficina")
                    .HasMaxLength(3)
                    .HasComment("Referencia tabla [EasyGestionEmpresarial.Oficina campo: oficina]");

                entity.Property(e => e.ZfaOficinaNombre)
                    .IsRequired()
                    .HasColumnName("zfa_oficina_nombre")
                    .HasMaxLength(60)
                    .HasComment("Almacenamos el nombre de la oficina");

                entity.Property(e => e.ZfaSucursal)
                    .IsRequired()
                    .HasColumnName("zfa_sucursal")
                    .HasMaxLength(3)
                    .HasComment("Almacenamos la sucursal al cual pertenece la oficina");

                entity.Property(e => e.ZonCodigo)
                    .IsRequired()
                    .HasColumnName("zon_codigo")
                    .HasMaxLength(10)
                    .HasComment("Referencia tabla [SD_Zona campo: zon_codigo]");

                entity.Property(e => e.ZonProvincia)
                    .IsRequired()
                    .HasColumnName("zon_provincia")
                    .HasMaxLength(2)
                    .HasComment("Referencia tabla [EasyGestionEmpresarial.tbl_zona campo: zona]");

                entity.HasOne(d => d.Zon)
                    .WithMany(p => p.SdRelFarmaciaZona)
                    .HasForeignKey(d => new { d.ZonCodigo, d.ZonProvincia })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SD_REL_FarmaciaZona_SD_Zona");
            });

            modelBuilder.Entity<SdRelMotorizadoZona>(entity =>
            {
                entity.HasKey(e => e.MtzCodigo)
                    .HasName("pk_sd_rel_motorizadozona");

                entity.ToTable("SD_REL_MotorizadoZona");

                entity.Property(e => e.MtzCodigo).HasColumnName("mtz_codigo");

                entity.Property(e => e.MotCodigo).HasColumnName("mot_codigo");

                entity.Property(e => e.MtzDescripcion)
                    .HasColumnName("mtz_descripcion")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MtzEstado)
                    .HasColumnName("mtz_estado")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MtzFechaRegistro)
                    .HasColumnName("mtz_fecha_registro")
                    .HasColumnType("datetime");

                entity.Property(e => e.ZonCodigo)
                    .IsRequired()
                    .HasColumnName("zon_codigo")
                    .HasMaxLength(10);

                entity.Property(e => e.ZonProvincia)
                    .IsRequired()
                    .HasColumnName("zon_provincia")
                    .HasMaxLength(2);

                entity.HasOne(d => d.MotCodigoNavigation)
                    .WithMany(p => p.SdRelMotorizadoZona)
                    .HasForeignKey(d => d.MotCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_sd_rel_m_reference_sd_motor");

                entity.HasOne(d => d.Zon)
                    .WithMany(p => p.SdRelMotorizadoZona)
                    .HasForeignKey(d => new { d.ZonCodigo, d.ZonProvincia })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_sd_rel_m_reference_sd_zona");
            });

            modelBuilder.Entity<SdTmpConsultaDescuento>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SD_TMP_ConsultaDescuento");

                entity.Property(e => e.ConCctPorcentaje)
                    .HasColumnName("con_cct_porcentaje")
                    .HasMaxLength(50);

                entity.Property(e => e.ConCompania)
                    .HasColumnName("con_compania")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ConFechaActualizacion)
                    .HasColumnName("con_fecha_actualizacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.ConFechaVencimiento)
                    .HasColumnName("con_fecha_vencimiento")
                    .HasColumnType("datetime");

                entity.Property(e => e.ConIdCliente).HasColumnName("con_id_cliente");

                entity.Property(e => e.ConIdClientesCupo).HasColumnName("con_id_clientes_cupo");

                entity.Property(e => e.ConMontoAutorizado)
                    .HasColumnName("con_monto_autorizado")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.ConMontoAutorizadoE)
                    .HasColumnName("con_monto_autorizado_e")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.ConMontoAutorizadoR)
                    .HasColumnName("con_monto_autorizado_r")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.ConMontoSobregiro)
                    .HasColumnName("con_monto_sobregiro")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.ConMontoUtilizado)
                    .HasColumnName("con_monto_utilizado")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.ConMontoUtilizadoE)
                    .HasColumnName("con_monto_utilizado_e")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.ConMontoUtilizadoR)
                    .HasColumnName("con_monto_utilizado_r")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.PcaCodigo).HasColumnName("pca_codigo");
            });

            modelBuilder.Entity<SdTmpDatosRetencion>(entity =>
            {
                entity.HasKey(e => new { e.PcrImpuesto, e.PcaCodigo })
                    .HasName("PK_PV_DatosRetencion");

                entity.ToTable("SD_TMP_DatosRetencion");

                entity.Property(e => e.PcrImpuesto)
                    .HasColumnName("pcr_impuesto")
                    .HasMaxLength(25);

                entity.Property(e => e.PcaCodigo).HasColumnName("pca_codigo");

                entity.Property(e => e.DrAnioFiscal)
                    .HasColumnName("dr_anio_fiscal")
                    .HasMaxLength(4);

                entity.Property(e => e.DrBaseImponible)
                    .HasColumnName("dr_base_imponible")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.DrComprobanteContable)
                    .HasColumnName("dr_comprobante_contable")
                    .HasMaxLength(50);

                entity.Property(e => e.DrEstado)
                    .HasColumnName("dr_estado")
                    .HasMaxLength(10);

                entity.Property(e => e.DrNumeroAutorizacion)
                    .HasColumnName("dr_numero_autorizacion")
                    .HasMaxLength(50);

                entity.Property(e => e.DrNumeroRetencion)
                    .HasColumnName("dr_numero_retencion")
                    .HasMaxLength(20);

                entity.Property(e => e.DrPorcentajeRetencion)
                    .HasColumnName("dr_porcentaje_retencion")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.DrTipo)
                    .HasColumnName("dr_tipo")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DrTipoComprobante)
                    .HasColumnName("dr_tipo_comprobante")
                    .HasMaxLength(1);

                entity.Property(e => e.DrUsuario)
                    .HasColumnName("dr_usuario")
                    .HasMaxLength(20);

                entity.Property(e => e.DrValidezRetencion)
                    .HasColumnName("dr_validez_retencion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DrValorRetencion)
                    .HasColumnName("dr_valor_retencion")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.EnvioPos)
                    .HasColumnName("envio_pos")
                    .HasMaxLength(2);

                entity.Property(e => e.FechaFactura)
                    .HasColumnName("fecha_factura")
                    .HasColumnType("datetime");

                entity.Property(e => e.NumeroIdcliente)
                    .HasColumnName("numero_idcliente")
                    .HasMaxLength(20);

                entity.Property(e => e.Oficina)
                    .HasColumnName("oficina")
                    .HasMaxLength(3);

                entity.Property(e => e.PcrCodigo)
                    .IsRequired()
                    .HasColumnName("pcr_codigo")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.SerieFactura)
                    .HasColumnName("serie_factura")
                    .HasMaxLength(30);

                entity.Property(e => e.Sucursal)
                    .HasColumnName("sucursal")
                    .HasMaxLength(3);
            });

            modelBuilder.Entity<SdTmpFacturasCupoEfectivo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SD_TMP_FacturasCupoEfectivo");

                entity.Property(e => e.EnvioPos)
                    .HasColumnName("envio_pos")
                    .HasMaxLength(50);

                entity.Property(e => e.FceDescuentoAplicado)
                    .HasColumnName("fce_descuento_aplicado")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.FceEstado)
                    .HasColumnName("fce_estado")
                    .HasMaxLength(50);

                entity.Property(e => e.FceFechaIngreso)
                    .HasColumnName("fce_fecha_ingreso")
                    .HasColumnType("datetime");

                entity.Property(e => e.FceIdRegistro).HasColumnName("fce_id_registro");

                entity.Property(e => e.FceNumeroFactura)
                    .HasColumnName("fce_numero_factura")
                    .HasMaxLength(50);

                entity.Property(e => e.FceNumeroIdcliente)
                    .HasColumnName("fce_numero_idcliente")
                    .HasMaxLength(50);

                entity.Property(e => e.FceOficina)
                    .HasColumnName("fce_oficina")
                    .HasMaxLength(50);

                entity.Property(e => e.FceTipoIdcliente)
                    .HasColumnName("fce_tipo_idcliente")
                    .HasMaxLength(50);

                entity.Property(e => e.FceUsuario)
                    .HasColumnName("fce_usuario")
                    .HasMaxLength(50);

                entity.Property(e => e.FceValorCupo)
                    .HasColumnName("fce_valor_cupo")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.PcaCodigo).HasColumnName("pca_codigo");
            });

            modelBuilder.Entity<SdTmpFormasPago>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SD_TMP_Formas_Pago");

                entity.HasComment(@"Autor: Ing. Claudio Guerrón

Almacenamos los valores de la parametrizacion de las formas de pago. Es importante señalar que es la misma tabla que esta en las farmacias, además la información se almacenará de forma temporal.");

                entity.Property(e => e.PcaCodigo).HasColumnName("pca_codigo");

                entity.Property(e => e.PfDescuento)
                    .HasColumnName("pf_descuento")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PfIdFila).HasColumnName("pf_id_fila");

                entity.Property(e => e.PfTipoPago)
                    .HasColumnName("pf_tipo_pago")
                    .HasMaxLength(200);

                entity.Property(e => e.PfValorPagado)
                    .HasColumnName("pf_valor_pagado")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.PfVuelto)
                    .HasColumnName("pf_vuelto")
                    .HasColumnType("decimal(18, 4)");
            });

            modelBuilder.Entity<SdTmpFpago>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SD_TMP_FPago");

                entity.HasComment(@"Autor: Claudio Guerrón

Tabla que nos permite almacenar la información de todas las Formas pago.  Es importante señalar que es la misma tabla que esta en las farmacias, además la información se almacenará de forma temporal.");

                entity.Property(e => e.FpAbreviatura)
                    .HasColumnName("fp_abreviatura")
                    .HasMaxLength(50);

                entity.Property(e => e.FpAutMatriz)
                    .HasColumnName("fp_aut_matriz")
                    .HasMaxLength(50);

                entity.Property(e => e.FpAutorizacion)
                    .HasColumnName("fp_autorizacion")
                    .HasMaxLength(50);

                entity.Property(e => e.FpCodigoBanco)
                    .HasColumnName("fp_codigo_banco")
                    .HasMaxLength(50);

                entity.Property(e => e.FpCopago)
                    .HasColumnName("fp_copago")
                    .HasMaxLength(50);

                entity.Property(e => e.FpCuenta)
                    .HasColumnName("fp_cuenta")
                    .HasMaxLength(50);

                entity.Property(e => e.FpDeducible)
                    .HasColumnName("fp_deducible")
                    .HasMaxLength(50);

                entity.Property(e => e.FpDescAdicional)
                    .HasColumnName("fp_desc_adicional")
                    .HasMaxLength(50);

                entity.Property(e => e.FpIdEmisor)
                    .HasColumnName("fp_id_emisor")
                    .HasMaxLength(50);

                entity.Property(e => e.FpIdFila).HasColumnName("fp_id_fila");

                entity.Property(e => e.FpLote)
                    .HasColumnName("fp_lote")
                    .HasMaxLength(50);

                entity.Property(e => e.FpNoCheque)
                    .HasColumnName("fp_no_cheque")
                    .HasMaxLength(50);

                entity.Property(e => e.FpNoEmisor)
                    .HasColumnName("fp_no_emisor")
                    .HasMaxLength(50);

                entity.Property(e => e.FpNoRetencion)
                    .HasColumnName("fp_no_retencion")
                    .HasMaxLength(50);

                entity.Property(e => e.FpNoTarjeta)
                    .HasColumnName("fp_no_tarjeta")
                    .HasMaxLength(50);

                entity.Property(e => e.FpNoVaucher)
                    .HasColumnName("fp_no_vaucher")
                    .HasMaxLength(50);

                entity.Property(e => e.FpNombreCorto)
                    .HasColumnName("fp_nombre_corto")
                    .HasMaxLength(50);

                entity.Property(e => e.FpNombreEfp)
                    .HasColumnName("fp_nombre_efp")
                    .HasMaxLength(200);

                entity.Property(e => e.FpPlazoVencimiento)
                    .HasColumnName("fp_plazo_vencimiento")
                    .HasMaxLength(50);

                entity.Property(e => e.FpRecargo)
                    .HasColumnName("fp_recargo")
                    .HasMaxLength(50);

                entity.Property(e => e.FpTarjeta)
                    .HasColumnName("fp_tarjeta")
                    .HasMaxLength(50);

                entity.Property(e => e.FpTelefono)
                    .HasColumnName("fp_telefono")
                    .HasMaxLength(50);

                entity.Property(e => e.FpTipoCredito)
                    .HasColumnName("fp_tipo_credito")
                    .HasMaxLength(50);

                entity.Property(e => e.FpTipoRetencion)
                    .HasColumnName("fp_tipo_retencion")
                    .HasMaxLength(50);

                entity.Property(e => e.FpValidez)
                    .HasColumnName("fp_validez")
                    .HasMaxLength(50);

                entity.Property(e => e.FpValor)
                    .HasColumnName("fp_valor")
                    .HasMaxLength(50);

                entity.Property(e => e.PcaCodigo).HasColumnName("pca_codigo");
            });

            modelBuilder.Entity<SdTmpFpbonosCarga>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SD_TMP_FPBonosCarga");

                entity.HasComment(@"Autor: Ing. Claudio Guerrón

Tabla que permite almacenar los datos de los bonos.  Es importante señalar que es la misma tabla que esta en las farmacias, además la información se almacenará de forma temporal.

");

                entity.Property(e => e.BonCodBonoCab).HasColumnName("bon_cod_bono_cab");

                entity.Property(e => e.BonCodigo).HasColumnName("bon_codigo");

                entity.Property(e => e.BonMonto)
                    .HasColumnName("bon_monto")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.BonRespuesta)
                    .HasColumnName("bon_respuesta")
                    .HasMaxLength(50);

                entity.Property(e => e.PcaCodigo).HasColumnName("pca_codigo");
            });

            modelBuilder.Entity<SdTmpFpcheque>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SD_TMP_FPCheque");

                entity.HasComment(@"Autor: Ing.Claudio Guerrón

Almacenamos la informacion de los cheques cuando se cancela con esta forma de pago.  Es importante señalar que es la misma tabla que esta en las farmacias, además la información se almacenará de forma temporal.");

                entity.Property(e => e.CheAnio)
                    .HasColumnName("che_anio")
                    .HasMaxLength(50);

                entity.Property(e => e.CheAutorizacion)
                    .HasColumnName("che_autorizacion")
                    .HasMaxLength(50);

                entity.Property(e => e.CheBanco)
                    .HasColumnName("che_banco")
                    .HasMaxLength(50);

                entity.Property(e => e.CheCuenta)
                    .HasColumnName("che_cuenta")
                    .HasMaxLength(50);

                entity.Property(e => e.CheIdBanco)
                    .HasColumnName("che_id_banco")
                    .HasMaxLength(50);

                entity.Property(e => e.CheNroCheque)
                    .HasColumnName("che_nro_cheque")
                    .HasMaxLength(50);

                entity.Property(e => e.CheNumeroDoc)
                    .HasColumnName("che_numero_doc")
                    .HasMaxLength(50);

                entity.Property(e => e.CheSexo)
                    .HasColumnName("che_sexo")
                    .HasMaxLength(50);

                entity.Property(e => e.CheTelefono)
                    .HasColumnName("che_telefono")
                    .HasMaxLength(50);

                entity.Property(e => e.CheTipoDoc)
                    .HasColumnName("che_tipo_doc")
                    .HasMaxLength(50);

                entity.Property(e => e.CheValor)
                    .HasColumnName("che_valor")
                    .HasMaxLength(50);

                entity.Property(e => e.PcaCodigo).HasColumnName("pca_codigo");
            });

            modelBuilder.Entity<SdTmpFpconvenioParametros>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SD_TMP_FPConvenioParametros");

                entity.HasComment(@"Autor:Ing. Claudio Guerrón

En esta tabla almacenamos temportalmente los valores de parametrización de convenio.  Es importante señalar que es la misma tabla que esta en las farmacias, además la información se almacenará de forma temporal.");

                entity.Property(e => e.ConAutorizacion)
                    .HasColumnName("con_autorizacion")
                    .HasMaxLength(50);

                entity.Property(e => e.ConClienteFactura)
                    .HasColumnName("con_cliente_factura")
                    .HasMaxLength(50);

                entity.Property(e => e.ConCodBarra)
                    .HasColumnName("con_cod_barra")
                    .HasMaxLength(50);

                entity.Property(e => e.ConCopago)
                    .HasColumnName("con_copago")
                    .HasMaxLength(50);

                entity.Property(e => e.ConCubreIva)
                    .HasColumnName("con_cubre_iva")
                    .HasMaxLength(50);

                entity.Property(e => e.ConDeducible)
                    .HasColumnName("con_deducible")
                    .HasMaxLength(50);

                entity.Property(e => e.ConDescuento)
                    .HasColumnName("con_descuento")
                    .HasMaxLength(50);

                entity.Property(e => e.ConDescuentoBarra)
                    .HasColumnName("con_descuento_barra")
                    .HasMaxLength(50);

                entity.Property(e => e.ConEstado)
                    .HasColumnName("con_estado")
                    .HasMaxLength(50);

                entity.Property(e => e.ConFacturaA)
                    .HasColumnName("con_factura_a")
                    .HasMaxLength(50);

                entity.Property(e => e.ConIdConvenio)
                    .HasColumnName("con_id_convenio")
                    .HasMaxLength(50);

                entity.Property(e => e.ConLeyenda)
                    .HasColumnName("con_leyenda")
                    .HasMaxLength(200);

                entity.Property(e => e.ConListaPrecios)
                    .HasColumnName("con_lista_precios")
                    .HasMaxLength(50);

                entity.Property(e => e.ConNoCopias)
                    .HasColumnName("con_no_copias")
                    .HasMaxLength(50);

                entity.Property(e => e.ConNombreConv)
                    .HasColumnName("con_nombre_conv")
                    .HasMaxLength(200);

                entity.Property(e => e.ConPorCon)
                    .HasColumnName("con_por_con")
                    .HasMaxLength(50);

                entity.Property(e => e.ConPromocionesConvenio)
                    .HasColumnName("con_promociones_convenio")
                    .HasMaxLength(50);

                entity.Property(e => e.ConRucInstitucion)
                    .HasColumnName("con_ruc_institucion")
                    .HasMaxLength(50);

                entity.Property(e => e.ConValDescuento)
                    .HasColumnName("con_val_descuento")
                    .HasMaxLength(50);

                entity.Property(e => e.MesesPlazo).HasColumnName("meses_plazo");

                entity.Property(e => e.PcaCodigo).HasColumnName("pca_codigo");
            });

            modelBuilder.Entity<SdTmpFpconveniosAutorizacion>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SD_TMP_FPConveniosAutorizacion");

                entity.HasComment(@"Autor: Claudio Guerrón
Tabla que permite almacenar temporalmente los datos de la Autorizacion cuando es Crédito Farmaenlace.  Es importante señalar que es la misma tabla que esta en las farmacias, además la información se almacenará de forma temporal.");

                entity.Property(e => e.AutCedulaconvenio)
                    .HasColumnName("aut_cedulaconvenio")
                    .HasMaxLength(50);

                entity.Property(e => e.AutDescripcion)
                    .HasColumnName("aut_descripcion")
                    .HasMaxLength(100);

                entity.Property(e => e.AutSobregiro)
                    .HasColumnName("aut_sobregiro")
                    .HasMaxLength(50);

                entity.Property(e => e.AutStrOficina)
                    .HasColumnName("aut_strOficina")
                    .HasMaxLength(50);

                entity.Property(e => e.AutStrUsuario)
                    .HasColumnName("aut_strUsuario")
                    .HasMaxLength(50);

                entity.Property(e => e.AutTipoconvenio)
                    .HasColumnName("aut_tipoconvenio")
                    .HasMaxLength(50);

                entity.Property(e => e.AutValor)
                    .HasColumnName("aut_valor")
                    .HasMaxLength(50);

                entity.Property(e => e.AutValorYes)
                    .HasColumnName("aut_valor_yes")
                    .HasMaxLength(50);

                entity.Property(e => e.PcaCodigo).HasColumnName("pca_codigo");
            });

            modelBuilder.Entity<SdTmpFpdescuentosDePromociones>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SD_TMP_FPDescuentosDePromociones");

                entity.HasComment(@"Autor:Ing. Claudio Guerrón

Almacenamos los valores del descuento con porcentajes incluidos.  Es importante señalar que es la misma tabla que esta en las farmacias, además la información se almacenará de forma temporal.
");

                entity.Property(e => e.PcaCodigo).HasColumnName("pca_codigo");

                entity.Property(e => e.PrdCantidad)
                    .HasColumnName("prd_cantidad")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PrdCodigoProducto)
                    .HasColumnName("prd_codigo_producto")
                    .HasMaxLength(50);

                entity.Property(e => e.PrdIdPromociones).HasColumnName("prd_id_promociones");

                entity.Property(e => e.PrdNombre).HasColumnName("prd_nombre");

                entity.Property(e => e.PrdNombrePromocion).HasColumnName("prd_nombre_promocion");

                entity.Property(e => e.PrdPorcentaje)
                    .HasColumnName("prd_porcentaje")
                    .HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<SdTmpFpgenerales>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SD_TMP_FPGenerales");

                entity.HasComment(@"Autor: Claudio Guerrón

Tabla que me permite Almacenar temporalmente las variables importantes cuando se cancela con Diferentes formas de Pago.
Además la información se almacenará de forma temporal.");

                entity.Property(e => e.GenAceptaMf)
                    .HasColumnName("gen_acepta_mf")
                    .HasMaxLength(50);

                entity.Property(e => e.GenAplicaPromocion)
                    .HasColumnName("gen_aplica_promocion")
                    .HasMaxLength(50);

                entity.Property(e => e.GenAutorizacion)
                    .HasColumnName("gen_autorizacion")
                    .HasMaxLength(50);

                entity.Property(e => e.GenAutorizacionConv)
                    .HasColumnName("gen_autorizacion_conv")
                    .HasMaxLength(200);

                entity.Property(e => e.GenAutorizacionDescuento)
                    .HasColumnName("gen_autorizacion_descuento")
                    .HasMaxLength(50);

                entity.Property(e => e.GenBanCerrar)
                    .HasColumnName("gen_ban_cerrar")
                    .HasMaxLength(50);

                entity.Property(e => e.GenCedulaConvenio)
                    .HasColumnName("gen_cedula_convenio")
                    .HasMaxLength(50);

                entity.Property(e => e.GenClsSubtotalIva)
                    .HasColumnName("gen_cls_Subtotal_iva")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.GenClsSubtotalNIva)
                    .HasColumnName("gen_cls_subtotal_n_iva")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.GenCodMedicoMf)
                    .HasColumnName("gen_cod_medico_mf")
                    .HasMaxLength(50);

                entity.Property(e => e.GenEsFacturaCanjeMf)
                    .HasColumnName("gen_es_factura_canje_mf")
                    .HasMaxLength(50);

                entity.Property(e => e.GenEsProforma)
                    .HasColumnName("gen_es_proforma")
                    .HasMaxLength(50);

                entity.Property(e => e.GenEsPromocionalPvp)
                    .HasColumnName("gen_es_promocional_pvp")
                    .HasMaxLength(50);

                entity.Property(e => e.GenEsTarjetaD)
                    .HasColumnName("gen_es_tarjeta_d")
                    .HasMaxLength(50);

                entity.Property(e => e.GenIngresoPaciente)
                    .HasColumnName("gen_ingreso_paciente")
                    .HasMaxLength(50);

                entity.Property(e => e.GenNoAplicaCupon)
                    .HasColumnName("gen_no_aplica_cupon")
                    .HasMaxLength(50);

                entity.Property(e => e.GenNombreMedicoMf)
                    .HasColumnName("gen_nombre_medico_mf")
                    .HasMaxLength(200);

                entity.Property(e => e.GenNroReimpresionesMf).HasColumnName("gen_nro_reimpresiones_mf");

                entity.Property(e => e.GenPacienteConv)
                    .HasColumnName("gen_paciente_conv")
                    .HasMaxLength(200);

                entity.Property(e => e.GenPromocionProforma)
                    .HasColumnName("gen_promocion_proforma")
                    .HasMaxLength(50);

                entity.Property(e => e.GenRecargo)
                    .HasColumnName("gen_recargo")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.GenSerieNotaCredito)
                    .HasColumnName("gen_serie_nota_credito")
                    .HasMaxLength(50);

                entity.Property(e => e.GenTipoConvenio)
                    .HasColumnName("gen_tipo_convenio")
                    .HasMaxLength(50);

                entity.Property(e => e.GenValorCopagoReceta)
                    .HasColumnName("gen_valor_copago_receta")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.GenValorExtra)
                    .HasColumnName("gen_valor_extra")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.PcaCodigo).HasColumnName("pca_codigo");
            });

            modelBuilder.Entity<SdTmpFppromocionesDescuentos>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SD_TMP_FPPromocionesDescuentos");

                entity.HasComment(@"Autor: Ing. Claudio Guerrón
En esta tabla almacenamos temporalmente los valores de las promociones con descuentos generadas por otras formas de pago.  Es importante señalar que es la misma tabla que esta en las farmacias, además la información se almacenará de forma temporal.");

                entity.Property(e => e.PcaCodigo).HasColumnName("pca_codigo");

                entity.Property(e => e.PrdCantidad)
                    .HasColumnName("prd_cantidad")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PrdCodigoProducto)
                    .HasColumnName("prd_codigo_producto")
                    .HasMaxLength(50);

                entity.Property(e => e.PrdIdPromociones).HasColumnName("prd_id_promociones");

                entity.Property(e => e.PrdNombre).HasColumnName("prd_nombre");

                entity.Property(e => e.PrdNombrePromocion).HasColumnName("prd_nombre_promocion");
            });

            modelBuilder.Entity<SdTmpFptarjetas>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SD_TMP_FPTarjetas");

                entity.HasComment(@"Autor: Ing. Claudio Guerrón
Tabla que nos permite almacenar temporalmente la información de las tarjetas con la cual cancela el pedido.
 Es importante señalar que es la misma tabla que esta en las farmacias, además la información se almacenará de forma temporal.
");

                entity.Property(e => e.PcaCodigo).HasColumnName("pca_codigo");

                entity.Property(e => e.TarAutorizacion)
                    .HasColumnName("tar_autorizacion")
                    .HasMaxLength(50);

                entity.Property(e => e.TarBanco)
                    .HasColumnName("tar_banco")
                    .HasMaxLength(200);

                entity.Property(e => e.TarBaseCero)
                    .HasColumnName("tar_base_cero")
                    .HasMaxLength(50);

                entity.Property(e => e.TarBaseDoce)
                    .HasColumnName("tar_base_doce")
                    .HasMaxLength(50);

                entity.Property(e => e.TarIva)
                    .HasColumnName("tar_iva")
                    .HasMaxLength(50);

                entity.Property(e => e.TarMinimoTarjeta)
                    .HasColumnName("tar_minimo_tarjeta")
                    .HasMaxLength(50);

                entity.Property(e => e.TarNumero)
                    .HasColumnName("tar_numero")
                    .HasMaxLength(50);

                entity.Property(e => e.TarPlazo)
                    .HasColumnName("tar_plazo")
                    .HasMaxLength(50);

                entity.Property(e => e.TarTarjeta)
                    .HasColumnName("tar_tarjeta")
                    .HasMaxLength(200);

                entity.Property(e => e.TarTelefono)
                    .HasColumnName("tar_telefono")
                    .HasMaxLength(20);

                entity.Property(e => e.TarTipoCredito)
                    .HasColumnName("tar_tipo_credito")
                    .HasMaxLength(200);

                entity.Property(e => e.TarValidez)
                    .HasColumnName("tar_validez")
                    .HasMaxLength(50);

                entity.Property(e => e.TarValor)
                    .HasColumnName("tar_valor")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SdTmpMedFrecCanjes>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SD_TMP_MedFrecCanjes");

                entity.HasComment(@"Autor: Claudio Guerrón
Tabla que permite almacenar temporalmente los datos de Canjes de Medicación Frecuente.  Es importante señalar que es la misma tabla que esta en las farmacias, además la información se almacenará de forma temporal.
");

                entity.Property(e => e.MfcActualizar)
                    .HasColumnName("mfc_actualizar")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("Campo que indica si el canje se debe actualizar[SI,NO]");

                entity.Property(e => e.MfcAuxiliar)
                    .HasColumnName("mfc_auxiliar")
                    .HasMaxLength(50)
                    .HasComment("Nombre del Usuario que realizó el pedido del 1800");

                entity.Property(e => e.MfcCantidad)
                    .HasColumnName("mfc_cantidad")
                    .HasComment("Cantidad de Items del Artículo");

                entity.Property(e => e.MfcCodigo)
                    .HasColumnName("mfc_codigo")
                    .HasMaxLength(50)
                    .HasComment("Código del Artículo");

                entity.Property(e => e.MfcCodigoOriginal)
                    .HasColumnName("mfc_codigo_original")
                    .HasMaxLength(50)
                    .HasComment("Código original del producto");

                entity.Property(e => e.MfcDevolucion)
                    .HasColumnName("mfc_devolucion")
                    .HasMaxLength(50)
                    .HasComment("Si el Artículo lleva o no Devolución");

                entity.Property(e => e.MfcEstado)
                    .HasColumnName("mfc_estado")
                    .HasMaxLength(50)
                    .HasComment("Estado del Canje. [PROCESADA, NOPROCESADA]");

                entity.Property(e => e.MfcFechaCanje)
                    .HasColumnName("mfc_fecha_canje")
                    .HasColumnType("datetime")
                    .HasComment("Fecha del Canje de Medicación Frecuente");

                entity.Property(e => e.MfcFormaPago)
                    .HasColumnName("mfc_forma_pago")
                    .HasMaxLength(50)
                    .HasComment("Detalle de la forma de pago");

                entity.Property(e => e.MfcIdArticulosPromocion)
                    .HasColumnName("mfc_id_articulos_promocion")
                    .HasComment("Id de la Promoción que existe en Medicación Frecuente");

                entity.Property(e => e.MfcIdPremio)
                    .HasColumnName("mfc_id_premio")
                    .HasComment("Id del Premio");

                entity.Property(e => e.MfcNumeroFacturaCanje)
                    .HasColumnName("mfc_numero_factura_canje")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment(@"Número de la Factura del Canje, en este caso seria el Número de Pedido.
");

                entity.Property(e => e.MfcSaldo)
                    .HasColumnName("mfc_saldo")
                    .HasComment("Saldo del Canje [-1 POR DEFAULT]");
            });

            modelBuilder.Entity<SdTmpMedFrecFacturasCruces>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SD_TMP_MedFrecFacturasCruces");

                entity.HasComment(@"Autor: Ing. Claudio Guerrón
Tabla temporal donde se almacenara los cruses de las facturas que se canjean mediante el sistema de Servicio a Domicilio.  Es importante señalar que es la misma tabla que esta en las farmacias, además la información se almacenará de forma temporal.");

                entity.Property(e => e.CruAuxiliar)
                    .IsRequired()
                    .HasColumnName("cru_auxiliar")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('')")
                    .HasComment(@"Usuario que realiza el canje.
[Referencia a la tabla USUARIOS de la bbd EasySeguridad. ""nombrecorto""]
");

                entity.Property(e => e.CruCantidad)
                    .HasColumnName("cru_cantidad")
                    .HasComment("Almacena la cantidad en unidades del artículo facturado.");

                entity.Property(e => e.CruCodigoMedico)
                    .IsRequired()
                    .HasColumnName("cru_codigo_medico")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('')")
                    .HasComment("Almacena el código del médico que se registra al momento de que el cliente adquiere el cupón o realiza el canje del mismo.");

                entity.Property(e => e.CruCodigoProducto)
                    .IsRequired()
                    .HasColumnName("cru_codigo_producto")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("('')")
                    .HasComment(@"Almacena el código del producto.
[Referencia de la tabla TBL_ARTICULOS campo ""codigo""].
");

                entity.Property(e => e.CruCompania)
                    .IsRequired()
                    .HasColumnName("cru_compania")
                    .HasMaxLength(3)
                    .HasDefaultValueSql("('001')")
                    .HasComment("Almacena el código de la compania.");

                entity.Property(e => e.CruDevolucion)
                    .IsRequired()
                    .HasColumnName("cru_devolucion")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CruEsMf)
                    .IsRequired()
                    .HasColumnName("cru_es_MF")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('N')")
                    .HasComment(@"Indica si una factura pertenece a Medicación frecuente.
[S-> Factura de medicación frecuente, N-> No es factura de medicación frecuente]");

                entity.Property(e => e.CruEstablecimientoSri)
                    .IsRequired()
                    .HasColumnName("cru_establecimiento_sri")
                    .HasMaxLength(3)
                    .HasDefaultValueSql("('')")
                    .HasComment(@"Número otorgado por el SRI para el establecimiento y emisión de facturas.
[Referencia a la tabla OFICINA ""establecimiento_SRI""]");

                entity.Property(e => e.CruEstado)
                    .IsRequired()
                    .HasColumnName("cru_estado")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("('NOPROCESADA')")
                    .HasComment(@"Indica el estado de la factura.
[NOPROCESADA-> Factura pendiente de canje, PROCESADA-> Factura utilizada para un canje, PROCESADA CF15-> Facturas inactivadas ya que están a nombre de consumidor final con número de documento de 15 dígitos, INACTIVA COMPMF-> Facturas inactivadas desde el módulo de medicación frecuente Web implementado en Matriz].");

                entity.Property(e => e.CruFechaCanje)
                    .HasColumnName("cru_fecha_canje")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900/01/01')")
                    .HasComment("Almacena la fecha en la que se realizó el canje de una factura.");

                entity.Property(e => e.CruFechaFactura)
                    .HasColumnName("cru_fecha_factura")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('')")
                    .HasComment("Almacena la fecha y hora de emisión de la factura.");

                entity.Property(e => e.CruIdArticulosPromocion)
                    .HasColumnName("cru_id_articulos_promocion")
                    .HasComment("Almacena id del artículo de la promoción.");

                entity.Property(e => e.CruIdBodega)
                    .IsRequired()
                    .HasColumnName("cru_id_bodega")
                    .HasMaxLength(3)
                    .HasDefaultValueSql("('')")
                    .HasComment(@"Almacena el número de bodega donde se emitió la factura.
[Referencia a la tabla tbl_bodegas ""idbodega""].");

                entity.Property(e => e.CruIdPremio)
                    .HasColumnName("cru_id_premio")
                    .HasComment(@"Almacena el id del premio que esta asociado a una promoción.
[Referencia a la tabla tbl_premios de la base de datos  MedicacionFrecuente ""id_premio""]");

                entity.Property(e => e.CruNumeroAutMf)
                    .HasColumnName("cru_numero_aut_MF")
                    .HasComment(@"Almacena el número de autorización de Medicación frecuente.
[Referencia a la tabala TBL_AUTORIZACION de la base de datos MedicacionFrecuente ""numero""]");

                entity.Property(e => e.CruNumeroFactura)
                    .HasColumnName("cru_numero_factura")
                    .HasComment("Número del documento emitido.");

                entity.Property(e => e.CruNumeroFacturaCanje)
                    .IsRequired()
                    .HasColumnName("cru_numero_factura_canje")
                    .HasMaxLength(60)
                    .HasDefaultValueSql("('')")
                    .HasComment("Almacena la serie de las facturas de canje en las que se utilizó la factura original.");

                entity.Property(e => e.CruNumeroIdcliente)
                    .IsRequired()
                    .HasColumnName("cru_numero_idcliente")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('')")
                    .HasComment(@"Almacena el número de documento de un cliente.
[Referencia a la tabla TBL_CLIENTES ""numero_idcliente""].
");

                entity.Property(e => e.CruOficina)
                    .IsRequired()
                    .HasColumnName("cru_oficina")
                    .HasMaxLength(3)
                    .HasDefaultValueSql("('001')")
                    .HasComment(@"Almacena el código de la oficina al que pertenece el registro
[Referencia de la tabla OFICINA campo ""oficina""]
");

                entity.Property(e => e.CruProcesoMf)
                    .IsRequired()
                    .HasColumnName("cru_proceso_MF")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('N')")
                    .HasComment(@"Indica si la factura pertenece al proceso de Medicación Frecuente.
[D|N|R|S|X]");

                entity.Property(e => e.CruSaldo)
                    .HasColumnName("cru_saldo")
                    .HasDefaultValueSql("((-1))")
                    .HasComment("Almacena el saldo de una factura de Medicación Frecuente cuando no se utiliza la cantidad total de la misma.");

                entity.Property(e => e.CruSerieFactura)
                    .IsRequired()
                    .HasColumnName("cru_Serie_Factura")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("('')")
                    .HasComment(@"Almacena la serie de la factura.
[Referencia de la tabla tbl_maestrofact ""serie_factura""].
");

                entity.Property(e => e.CruSucursal)
                    .IsRequired()
                    .HasColumnName("cru_sucursal")
                    .HasMaxLength(3)
                    .HasDefaultValueSql("('001')")
                    .HasComment(@"Almacena el número de sucursal.
[Referencia de la tabla SUCURSAL ""Sucursal""].
");

                entity.Property(e => e.CruTipoDocumento)
                    .IsRequired()
                    .HasColumnName("cru_tipo_documento")
                    .HasMaxLength(2)
                    .HasDefaultValueSql("('')")
                    .HasComment(@"Indica el tipo de documento almacenado.
[F-> Factura, N-> Nota de crédito]");

                entity.Property(e => e.CruTipoIdcliente)
                    .IsRequired()
                    .HasColumnName("cru_tipo_idcliente")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('')")
                    .HasComment(@"Almacena el tipo de documento de un cliente.
[C-> Cédula, P-> Pasaporte, R-> Ruc, Referencia a la tabla TBL_CLIENTES ""tipo_idcliente""].
");

                entity.Property(e => e.CruTipoIdmedico)
                    .IsRequired()
                    .HasColumnName("cru_tipo_idmedico")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('')")
                    .HasComment(@"Indica si el cliente es un médico o no.
[Referencia a la tabla tbl_clientes ""tipo_idcliente""]");

                entity.Property(e => e.CruTipoMf)
                    .IsRequired()
                    .HasColumnName("cru_tipo_MF")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('')")
                    .HasComment(@"Indica el tipo de factura de medicación frecuente.
[Canje| Cupon]");
            });

            modelBuilder.Entity<SdTmpMedFrecInfoFacturas>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SD_TMP_MedFrecInfoFacturas");

                entity.HasComment(@"Autor: Ing. Claudio Guerrón
Tabla que me permite almacenar temporalmente los datos de reimpresión de medicación frecuente. Esta tabla nos permitirá generar de forma automática toda la información de medicación frecuente en el punto de venta.
");

                entity.Property(e => e.MffCadena)
                    .HasColumnName("mff_cadena")
                    .HasMaxLength(800)
                    .HasComment("Almacena la descripción de la cantidad del producto adquirido o la descripción de la promoción canjeada.");

                entity.Property(e => e.MffCadena1)
                    .HasColumnName("mff_cadena1")
                    .HasMaxLength(800)
                    .HasComment("Almacena el título de la Promoción de Medicación frecuente.");

                entity.Property(e => e.MffCadena2)
                    .HasColumnName("mff_cadena2")
                    .HasMaxLength(800)
                    .HasComment("Descripción de la Promoción.");

                entity.Property(e => e.MffCadena3)
                    .HasColumnName("mff_cadena3")
                    .HasComment("Almacena la descripción de total acumulado de facturas comprados de un producto específico o almacena las facturas que se utilizó para realizar un canje.");

                entity.Property(e => e.MffCedula)
                    .HasColumnName("mff_cedula")
                    .HasMaxLength(800)
                    .HasComment("Cédula del Cliente, en este caso ira vacío.");

                entity.Property(e => e.MffCodigo)
                    .HasColumnName("mff_codigo")
                    .HasMaxLength(800)
                    .HasComment(@"Almacena el código del artículo.
[Referencia de la tabla TBL_ARTICULOS campo ""codigo""].
");

                entity.Property(e => e.MffCodigoTarjeta)
                    .HasColumnName("mff_codigo_tarjeta")
                    .HasMaxLength(50)
                    .HasComment("Almacena el código de tarjeta de SANOFI Adventis, cuando una promoción requiere el ingreso del mismo.");

                entity.Property(e => e.MffCupon)
                    .HasColumnName("mff_cupon")
                    .HasMaxLength(800)
                    .HasComment("Almacena el número de cupón que el cliente adquirió o el cupón que utilizó para realizar un canje.");

                entity.Property(e => e.MffDireccion)
                    .HasColumnName("mff_direccion")
                    .HasMaxLength(800)
                    .HasComment("Dirección del Cliente, en este caso ira vacío.");

                entity.Property(e => e.MffFecha)
                    .HasColumnName("mff_fecha")
                    .HasMaxLength(800)
                    .HasComment(@"Almacena la fecha de emisión del cupón o el canje.
[Ejemplo: Fecha: 2011/02/11].");

                entity.Property(e => e.MffMedico)
                    .HasColumnName("mff_medico")
                    .HasMaxLength(800)
                    .HasComment("Médico de Medicación Frecuente.");

                entity.Property(e => e.MffNombre)
                    .HasColumnName("mff_nombre")
                    .HasMaxLength(800)
                    .HasComment("Nombre del Cliente, en este caso ira vacío.");

                entity.Property(e => e.MffNroReimpresion)
                    .HasColumnName("mff_nro_reimpresion")
                    .HasComment("Almacena el número de reimpresiones de la factura.");

                entity.Property(e => e.MffPedido)
                    .HasColumnName("mff_pedido")
                    .HasComment("Almacena el codigo del pedido");

                entity.Property(e => e.MffSaldo)
                    .HasColumnName("mff_saldo")
                    .HasMaxLength(800)
                    .HasComment("Almacena la descripción del saldo de un producto en una factura.");

                entity.Property(e => e.MffTelefono)
                    .HasColumnName("mff_telefono")
                    .HasMaxLength(800)
                    .HasComment("Telefono del Cliente, en este caso ira vacío.");

                entity.Property(e => e.MffTitulo)
                    .HasColumnName("mff_titulo")
                    .HasMaxLength(800)
                    .HasComment(@"Almacena el tipo de acción realizada, canje o cupón.
[PLAN DE MEDICACIÓN FRECUENTE| CANJE MEDICACIÓN FRECUENTE]");
            });

            modelBuilder.Entity<SdTmpMedico>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SD_TMP_Medico");

                entity.HasComment(@"Autor: Ing. Claudio Guerron

Almacena temporalmente los datos del Médico.  Es importante señalar que es la misma tabla que esta en las farmacias, además la información se almacenará de forma temporal.
");

                entity.Property(e => e.MedCodigo).HasColumnName("med_codigo");

                entity.Property(e => e.MedDireccion).HasColumnName("med_direccion");

                entity.Property(e => e.MedEspecialidad)
                    .HasColumnName("med_especialidad")
                    .HasMaxLength(50);

                entity.Property(e => e.MedEstado)
                    .HasColumnName("med_estado")
                    .HasMaxLength(50);

                entity.Property(e => e.MedFechaReceta)
                    .HasColumnName("med_fecha_receta")
                    .HasColumnType("datetime");

                entity.Property(e => e.MedNombre).HasColumnName("med_nombre");

                entity.Property(e => e.MedNumeroInh)
                    .HasColumnName("med_numero_inh")
                    .HasMaxLength(50);

                entity.Property(e => e.MedSerieReceta)
                    .HasColumnName("med_serie_receta")
                    .HasMaxLength(50);

                entity.Property(e => e.MedTelefono)
                    .HasColumnName("med_telefono")
                    .HasMaxLength(50);

                entity.Property(e => e.MedTipoMedico)
                    .HasColumnName("med_tipo_medico")
                    .HasMaxLength(50);

                entity.Property(e => e.PcaCodigo).HasColumnName("pca_codigo");
            });

            modelBuilder.Entity<SdTmpPromocionesCanje>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SD_TMP_PromocionesCanje");

                entity.HasComment(@"Autor: Ing. Claudio Guerron
Tabla que permite almacenar la información de los canjes de las promociones en la facturacion");

                entity.Property(e => e.PcaCodigo).HasColumnName("pca_codigo");

                entity.Property(e => e.PrcCodigoArticulo)
                    .IsRequired()
                    .HasColumnName("prc_codigo_articulo")
                    .HasMaxLength(50);

                entity.Property(e => e.PrcEstado)
                    .IsRequired()
                    .HasColumnName("prc_estado")
                    .HasMaxLength(50);

                entity.Property(e => e.PrcIdCliente)
                    .IsRequired()
                    .HasColumnName("prc_id_cliente")
                    .HasMaxLength(50);

                entity.Property(e => e.PrcIdPromocion)
                    .IsRequired()
                    .HasColumnName("prc_id_promocion")
                    .HasMaxLength(50);

                entity.Property(e => e.PrcSerieFactura)
                    .IsRequired()
                    .HasColumnName("prc_serie_factura")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SdTmpPromocionesDescuentoPromocional>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SD_TMP_PromocionesDescuentoPromocional");

                entity.Property(e => e.EnvioPos)
                    .HasColumnName("envio_pos")
                    .HasMaxLength(50);

                entity.Property(e => e.Idpromociones).HasColumnName("IDPROMOCIONES");

                entity.Property(e => e.PcaCodigo).HasColumnName("pca_codigo");

                entity.Property(e => e.PdpAsumeFarmaenlace)
                    .HasColumnName("pdp_asume_farmaenlace")
                    .HasMaxLength(50);

                entity.Property(e => e.PdpAsumeLab)
                    .HasColumnName("pdp_asume_lab")
                    .HasMaxLength(50);

                entity.Property(e => e.PdpAsumeTotal)
                    .HasColumnName("pdp_asume_total")
                    .HasMaxLength(50);

                entity.Property(e => e.PdpCantidadVendida).HasColumnName("pdp_cantidad_vendida");

                entity.Property(e => e.PdpCodigoProducto)
                    .HasColumnName("pdp_codigo_producto")
                    .HasMaxLength(50);

                entity.Property(e => e.PdpEstado)
                    .HasColumnName("pdp_estado")
                    .HasMaxLength(50);

                entity.Property(e => e.PdpFechaCreacion)
                    .HasColumnName("pdp_fecha_creacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.PdpFechaFactura)
                    .HasColumnName("pdp_fecha_factura")
                    .HasColumnType("datetime");

                entity.Property(e => e.PdpFechaModifica)
                    .HasColumnName("pdp_fecha_modifica")
                    .HasColumnType("datetime");

                entity.Property(e => e.PdpNumeroIdCliente)
                    .HasColumnName("pdp_numero_id_cliente")
                    .HasMaxLength(50);

                entity.Property(e => e.PdpNumeroIdProveedor)
                    .HasColumnName("pdp_numero_id_proveedor")
                    .HasMaxLength(50);

                entity.Property(e => e.PdpOficina)
                    .HasColumnName("pdp_oficina")
                    .HasMaxLength(50);

                entity.Property(e => e.PdpPorcentajeDescuento)
                    .HasColumnName("pdp_porcentaje_descuento")
                    .HasColumnType("decimal(15, 2)");

                entity.Property(e => e.PdpPvf)
                    .HasColumnName("pdp_pvf")
                    .HasColumnType("decimal(15, 2)");

                entity.Property(e => e.PdpPvp)
                    .HasColumnName("pdp_pvp")
                    .HasColumnType("decimal(15, 2)");

                entity.Property(e => e.PdpSerieFactura)
                    .HasColumnName("pdp_serie_factura")
                    .HasMaxLength(50);

                entity.Property(e => e.PdpSucursal)
                    .HasColumnName("pdp_sucursal")
                    .HasMaxLength(50);

                entity.Property(e => e.PdpTipoDocumento)
                    .HasColumnName("pdp_tipo_documento")
                    .HasMaxLength(50);

                entity.Property(e => e.PdpUsuarioCreacion)
                    .HasColumnName("pdp_usuario_creacion")
                    .HasMaxLength(50);

                entity.Property(e => e.PdpUsuarioModifica)
                    .HasColumnName("pdp_usuario_modifica")
                    .HasMaxLength(50);

                entity.Property(e => e.PdpValorAsume)
                    .HasColumnName("pdp_valor_asume")
                    .HasColumnType("decimal(15, 2)");

                entity.Property(e => e.PdpValorDescuento)
                    .HasColumnName("pdp_valor_descuento")
                    .HasColumnType("decimal(15, 2)");

                entity.Property(e => e.PdpValorPos).HasColumnName("pdp_valor_pos");
            });

            modelBuilder.Entity<SdTmpPromocionesDescuentosArticulos>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SD_TMP_PromocionesDescuentosArticulos");

                entity.HasComment(@"Autor: Ing Claudio Guerron

Tabla que almacena las promociones de Descuentos de los articulos.  Es importante señalar que es la misma tabla que esta en las farmacias, además la información se almacenará de forma temporal.");

                entity.Property(e => e.PdaCantidad).HasColumnName("pda_cantidad");

                entity.Property(e => e.PdaCodigo)
                    .IsRequired()
                    .HasColumnName("pda_codigo")
                    .HasMaxLength(15);

                entity.Property(e => e.PdaEnvioPos)
                    .HasColumnName("pda_envio_pos")
                    .HasMaxLength(2);

                entity.Property(e => e.PdaIdPromociones).HasColumnName("pda_id_promociones");

                entity.Property(e => e.PdaNumeroIdcliente)
                    .IsRequired()
                    .HasColumnName("pda_numero_idcliente")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PdaOficina)
                    .IsRequired()
                    .HasColumnName("pda_oficina")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.PdaPorcentajeDescuento)
                    .HasColumnName("pda_porcentaje_descuento")
                    .HasColumnType("decimal(18, 8)");

                entity.Property(e => e.PdaSerieFactura)
                    .IsRequired()
                    .HasColumnName("pda_serie_factura")
                    .HasMaxLength(30);

                entity.Property(e => e.PdaSucursal)
                    .IsRequired()
                    .HasColumnName("pda_sucursal")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.PdaValorDescuento)
                    .HasColumnName("pda_valor_descuento")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.PdaValorExtra)
                    .HasColumnName("pda_valor_extra")
                    .HasColumnType("decimal(18, 8)");
            });

            modelBuilder.Entity<SdTmpPromocionesFacturas>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SD_TMP_PromocionesFacturas");

                entity.HasComment(@"Autor:Ing Claudio Guerron

Tabla temporal que permite almacenar los datos de las promociones facturas. Tomada de la EasyGestionEmpresarial.PV_PromocionesFacturas");

                entity.Property(e => e.PfaCompania)
                    .HasColumnName("pfa_compania")
                    .HasMaxLength(3);

                entity.Property(e => e.PfaEnvioPos)
                    .HasColumnName("pfa_envio_pos")
                    .HasMaxLength(2);

                entity.Property(e => e.PfaEstablecimientoSri)
                    .HasColumnName("pfa_establecimiento_sri")
                    .HasMaxLength(3);

                entity.Property(e => e.PfaFechaFactura)
                    .HasColumnName("pfa_fecha_factura")
                    .HasColumnType("datetime");

                entity.Property(e => e.PfaFechaFin)
                    .HasColumnName("pfa_fecha_fin")
                    .HasColumnType("datetime");

                entity.Property(e => e.PfaFechaInicio)
                    .HasColumnName("pfa_fecha_inicio")
                    .HasColumnType("datetime");

                entity.Property(e => e.PfaIdPromociones).HasColumnName("pfa_id_promociones");

                entity.Property(e => e.PfaNumFactura).HasColumnName("pfa_num_factura");

                entity.Property(e => e.PfaNumeroIdCliente)
                    .IsRequired()
                    .HasColumnName("pfa_numero_id_cliente")
                    .HasMaxLength(20);

                entity.Property(e => e.PfaPuntoFacturacion).HasColumnName("pfa_punto_facturacion");

                entity.Property(e => e.PfaReimprimir)
                    .HasColumnName("pfa_reimprimir")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.PfaSerieFactura)
                    .IsRequired()
                    .HasColumnName("pfa_serie_factura")
                    .HasMaxLength(30);

                entity.Property(e => e.PfaTipoDocumento)
                    .HasColumnName("pfa_tipo_documento")
                    .HasMaxLength(2);

                entity.Property(e => e.PfaTipoIdCliente)
                    .IsRequired()
                    .HasColumnName("pfa_tipo_id_cliente")
                    .HasMaxLength(1);

                entity.Property(e => e.PfaTotalFactura)
                    .HasColumnName("pfa_total_factura")
                    .HasColumnType("decimal(17, 4)");

                entity.Property(e => e.PfaUsuarioFactura)
                    .HasColumnName("pfa_usuario_factura")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PfaValDescuento)
                    .HasColumnName("pfa_val_descuento")
                    .HasColumnType("decimal(13, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PfaValorExtra)
                    .HasColumnName("pfa_valor_extra")
                    .HasColumnType("decimal(13, 2)");
            });

            modelBuilder.Entity<SdTmpPromocionesGanadores>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SD_TMP_PromocionesGanadores");

                entity.HasComment(@"Autor:Ing. Claudio Guerrón
Tabla que almacena la información de las promociones Ganadoras. Es importante señalar que es la misma tabla que esta en las farmacias, además la información se almacenará de forma temporal.");

                entity.Property(e => e.PcaEnvioPos)
                    .HasColumnName("pca_envio_pos")
                    .HasMaxLength(2);

                entity.Property(e => e.PgaCantidad)
                    .HasColumnName("pga_cantidad")
                    .HasColumnType("decimal(18, 2)")
                    .HasComment("Cantidad");

                entity.Property(e => e.PgaCodigoPremio)
                    .IsRequired()
                    .HasColumnName("pga_codigo_premio")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasComment("Identificación del premio ganado por el cliente");

                entity.Property(e => e.PgaCompania)
                    .IsRequired()
                    .HasColumnName("pga_compania")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasComment("Creada como referencia de la compania");

                entity.Property(e => e.PgaEstado)
                    .HasColumnName("pga_estado")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PgaFechaFactura)
                    .HasColumnName("pga_fecha_factura")
                    .HasColumnType("datetime");

                entity.Property(e => e.PgaIdCliente)
                    .IsRequired()
                    .HasColumnName("pga_id_cliente")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("Id del cliente que solicita el pedido");

                entity.Property(e => e.PgaIdPromocion)
                    .HasColumnName("pga_id_promocion")
                    .HasComment("Id de la Promoción ganada");

                entity.Property(e => e.PgaOficina)
                    .IsRequired()
                    .HasColumnName("pga_oficina")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasComment("Farmacia en la cual se esta realizando el pedido. Farmacia seleccionada");

                entity.Property(e => e.PgaSerieFactura)
                    .IsRequired()
                    .HasColumnName("pga_serie_factura")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasComment("Serie de la factura en el cual se almacenará el código del Pedido hasta que sea actualizado en el punto de venta");

                entity.Property(e => e.PgaSucursal)
                    .IsRequired()
                    .HasColumnName("pga_sucursal")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasComment("Sucursal al cual pertenece la farmacia seleccionada");

                entity.Property(e => e.PgaTipoArticulo)
                    .HasColumnName("pga_tipo_articulo")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasComment("Tabla que me permite almacenar temporalmente loa información de las promociones ganadores.");

                entity.Property(e => e.PgaUsuario)
                    .HasColumnName("pga_usuario")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.PgaValorPos).HasColumnName("pga_valor_pos");
            });

            modelBuilder.Entity<SdTmpPromocionesMovPremios>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SD_TMP_PromocionesMovPremios");

                entity.HasComment(@"Autor: Ing. Claudio Guerrón
Tabla que almacena la informacion de las PromocionesMovPremios generadas por la forma de pago.  Es importante señalar que es la misma tabla que esta en las farmacias, además la información se almacenará de forma temporal.");

                entity.Property(e => e.PmpCantidad)
                    .HasColumnName("pmp_cantidad")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PmpCantidadTotal)
                    .HasColumnName("pmp_cantidad_total")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PmpCodigoArticulo)
                    .IsRequired()
                    .HasColumnName("pmp_codigo_articulo")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PmpCompania)
                    .IsRequired()
                    .HasColumnName("pmp_compania")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.PmpEnvioPos)
                    .HasColumnName("pmp_envio_pos")
                    .HasMaxLength(2);

                entity.Property(e => e.PmpEstado)
                    .HasColumnName("pmp_estado")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PmpEstadoCanje)
                    .HasColumnName("pmp_estado_canje")
                    .HasMaxLength(50);

                entity.Property(e => e.PmpFechaMov)
                    .HasColumnName("pmp_fecha_mov")
                    .HasColumnType("datetime");

                entity.Property(e => e.PmpIdCliente)
                    .IsRequired()
                    .HasColumnName("pmp_id_cliente")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PmpIdPromociones)
                    .IsRequired()
                    .HasColumnName("pmp_id_promociones")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PmpNumeroMov)
                    .HasColumnName("pmp_numero_mov")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.PmpObservacion)
                    .HasColumnName("pmp_observacion")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PmpOficina)
                    .IsRequired()
                    .HasColumnName("pmp_oficina")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.PmpSerieFactura)
                    .IsRequired()
                    .HasColumnName("pmp_serie_factura")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PmpSucursal)
                    .IsRequired()
                    .HasColumnName("pmp_sucursal")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.PmpTipo)
                    .HasColumnName("pmp_tipo")
                    .HasMaxLength(50);

                entity.Property(e => e.PmpTipoArticulo)
                    .IsRequired()
                    .HasColumnName("pmp_tipo_articulo")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.PmpTipoMov)
                    .HasColumnName("pmp_tipo_mov")
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SdTmpPromocionesMovPremiosActual>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SD_TMP_PromocionesMovPremiosActual");

                entity.HasComment(@"Autor: 
Ing. Claudio Guerron
Tabla que permite almacenar la información de las promociones acumuladas actuales que se realizan el canje.
");

                entity.Property(e => e.MpnCantidad)
                    .HasColumnName("mpn_cantidad")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.MpnCantidadTotal)
                    .HasColumnName("mpn_cantidad_total")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.MpnCodigoArticulo)
                    .HasColumnName("mpn_codigo_articulo")
                    .HasMaxLength(50);

                entity.Property(e => e.MpnCompania)
                    .HasColumnName("mpn_compania")
                    .HasMaxLength(50);

                entity.Property(e => e.MpnEnvioPos)
                    .HasColumnName("mpn_envio_pos")
                    .HasMaxLength(50);

                entity.Property(e => e.MpnEstado)
                    .HasColumnName("mpn_estado")
                    .HasMaxLength(50);

                entity.Property(e => e.MpnEstadoCanje)
                    .HasColumnName("mpn_estado_canje")
                    .HasMaxLength(50);

                entity.Property(e => e.MpnFechaMov)
                    .HasColumnName("mpn_fecha_mov")
                    .HasColumnType("datetime");

                entity.Property(e => e.MpnIdCliente)
                    .HasColumnName("mpn_id_cliente")
                    .HasMaxLength(50);

                entity.Property(e => e.MpnIdPromociones)
                    .HasColumnName("mpn_id_promociones")
                    .HasMaxLength(50);

                entity.Property(e => e.MpnNumeroMov).HasColumnName("mpn_numero_mov");

                entity.Property(e => e.MpnObservacion)
                    .HasColumnName("mpn_observacion")
                    .HasMaxLength(50);

                entity.Property(e => e.MpnOficina)
                    .HasColumnName("mpn_oficina")
                    .HasMaxLength(50);

                entity.Property(e => e.MpnSerieFactura)
                    .HasColumnName("mpn_serie_factura")
                    .HasMaxLength(50);

                entity.Property(e => e.MpnSucural)
                    .HasColumnName("mpn_sucural")
                    .HasMaxLength(50);

                entity.Property(e => e.MpnTipo)
                    .HasColumnName("mpn_tipo")
                    .HasMaxLength(50);

                entity.Property(e => e.MpnTipoArticulo)
                    .HasColumnName("mpn_tipo_articulo")
                    .HasMaxLength(50);

                entity.Property(e => e.MpnTipoMov)
                    .HasColumnName("mpn_tipo_mov")
                    .HasMaxLength(50);

                entity.Property(e => e.PcaCodigo).HasColumnName("pca_codigo");
            });

            modelBuilder.Entity<SdTmpPromocionesMovPremiosDisponibles>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SD_TMP_PromocionesMovPremiosDisponibles");

                entity.HasComment(@"Autor: 
Ing. Claudio Guerron
Tabla que permite almacenar la información de las promociones acumuladas actuales que se existen en Matriz.

");

                entity.Property(e => e.MpnCantidad)
                    .HasColumnName("mpn_cantidad")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.MpnCantidadTotal)
                    .HasColumnName("mpn_cantidad_total")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.MpnCodigoArticulo)
                    .HasColumnName("mpn_codigo_articulo")
                    .HasMaxLength(50);

                entity.Property(e => e.MpnCompania)
                    .HasColumnName("mpn_compania")
                    .HasMaxLength(50);

                entity.Property(e => e.MpnEnvioPos)
                    .HasColumnName("mpn_envio_pos")
                    .HasMaxLength(50);

                entity.Property(e => e.MpnEstado)
                    .HasColumnName("mpn_estado")
                    .HasMaxLength(50);

                entity.Property(e => e.MpnEstadoCanje)
                    .HasColumnName("mpn_estado_canje")
                    .HasMaxLength(50);

                entity.Property(e => e.MpnFechaMov)
                    .HasColumnName("mpn_fecha_mov")
                    .HasColumnType("datetime");

                entity.Property(e => e.MpnIdCliente)
                    .HasColumnName("mpn_id_cliente")
                    .HasMaxLength(50);

                entity.Property(e => e.MpnIdPromociones)
                    .HasColumnName("mpn_id_promociones")
                    .HasMaxLength(50);

                entity.Property(e => e.MpnNumeroMov).HasColumnName("mpn_numero_mov");

                entity.Property(e => e.MpnObservacion)
                    .HasColumnName("mpn_observacion")
                    .HasMaxLength(50);

                entity.Property(e => e.MpnOficina)
                    .HasColumnName("mpn_oficina")
                    .HasMaxLength(50);

                entity.Property(e => e.MpnSerieFactura)
                    .HasColumnName("mpn_serie_factura")
                    .HasMaxLength(50);

                entity.Property(e => e.MpnSucural)
                    .HasColumnName("mpn_sucural")
                    .HasMaxLength(50);

                entity.Property(e => e.MpnTipoArticulo)
                    .HasColumnName("mpn_tipo_articulo")
                    .HasMaxLength(50);

                entity.Property(e => e.MpnTipoMov)
                    .HasColumnName("mpn_tipo_mov")
                    .HasMaxLength(50);

                entity.Property(e => e.PcaCodigo).HasColumnName("pca_codigo");
            });

            modelBuilder.Entity<SdTmpPromocionesPinesGanados>(entity =>
            {
                entity.HasKey(e => new { e.PpgSerieFactura, e.PpgIdPromocion, e.PpgNumeroPin })
                    .HasName("PK_PV_PromocionesPinesGanados");

                entity.ToTable("SD_TMP_PromocionesPinesGanados");

                entity.Property(e => e.PpgSerieFactura)
                    .HasColumnName("ppg_serie_factura")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PpgIdPromocion).HasColumnName("ppg_id_promocion");

                entity.Property(e => e.PpgNumeroPin)
                    .HasColumnName("ppg_numero_pin")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EnvioPos)
                    .HasColumnName("envio_pos")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.PcaCodigo).HasColumnName("pca_codigo");

                entity.Property(e => e.PpgCodigoArticulo)
                    .HasColumnName("ppg_codigo_articulo")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PpgIdCliente)
                    .HasColumnName("ppg_id_cliente")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PpgOficina)
                    .HasColumnName("ppg_oficina")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.PpgSucursal)
                    .HasColumnName("ppg_sucursal")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.PpgTipoArticulo)
                    .HasColumnName("ppg_tipo_articulo")
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SdTmpPromocionesPremios>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SD_TMP_PromocionesPremios");

                entity.HasComment(@"Autor: Ing. Claudio Guerrón

Tabla para almacenar temporalmente los datos de los premios de las promociones.");

                entity.Property(e => e.PcaCodigo).HasColumnName("pca_codigo");

                entity.Property(e => e.PrpCantidad)
                    .HasColumnName("prp_cantidad")
                    .HasMaxLength(50);

                entity.Property(e => e.PrpClase)
                    .HasColumnName("prp_clase")
                    .HasMaxLength(50);

                entity.Property(e => e.PrpCodigo)
                    .HasColumnName("prp_codigo")
                    .HasMaxLength(50);

                entity.Property(e => e.PrpCompania)
                    .IsRequired()
                    .HasColumnName("prp_compania")
                    .HasMaxLength(50);

                entity.Property(e => e.PrpDescripcion)
                    .HasColumnName("prp_descripcion")
                    .HasMaxLength(200);

                entity.Property(e => e.PrpEsAcumulable)
                    .HasColumnName("prp_es_acumulable")
                    .HasMaxLength(50);

                entity.Property(e => e.PrpIdMarca)
                    .HasColumnName("prp_id_marca")
                    .HasMaxLength(50);

                entity.Property(e => e.PrpIdPromocion)
                    .HasColumnName("prp_id_promocion")
                    .HasMaxLength(50);

                entity.Property(e => e.PrpIngValorExtra)
                    .HasColumnName("prp_ing_valor_extra")
                    .HasMaxLength(50);

                entity.Property(e => e.PrpIva)
                    .HasColumnName("prp_iva")
                    .HasMaxLength(50);

                entity.Property(e => e.PrpLeyendaPremio).HasColumnName("prp_leyenda_premio");

                entity.Property(e => e.PrpLinea)
                    .HasColumnName("prp_linea")
                    .HasMaxLength(50);

                entity.Property(e => e.PrpPpp)
                    .HasColumnName("prp_ppp")
                    .HasMaxLength(50);

                entity.Property(e => e.PrpPvf)
                    .HasColumnName("prp_pvf")
                    .HasMaxLength(50);

                entity.Property(e => e.PrpPvp)
                    .HasColumnName("prp_pvp")
                    .HasMaxLength(50);

                entity.Property(e => e.PrpTipoArticulo)
                    .HasColumnName("prp_tipo_articulo")
                    .HasMaxLength(50);

                entity.Property(e => e.PrpTipoDeducible)
                    .HasColumnName("prp_tipo_deducible")
                    .HasMaxLength(50);

                entity.Property(e => e.PrpValorPos)
                    .HasColumnName("prp_valor_pos")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SdTmpPromocionesPremiosConfirmados>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SD_TMP_PromocionesPremiosConfirmados");

                entity.HasComment(@"Autor:Ing. Claudio Guerrón

Tabla que permite almacenar temporalmente los datos temporales de los premios confirmados ganados en el pedido.");

                entity.Property(e => e.PcaCodigo)
                    .HasColumnName("pca_codigo")
                    .HasMaxLength(50);

                entity.Property(e => e.PpcCantidad)
                    .HasColumnName("ppc_cantidad")
                    .HasMaxLength(50);

                entity.Property(e => e.PpcCodigoArticulo)
                    .HasColumnName("ppc_codigo_articulo")
                    .HasMaxLength(50);

                entity.Property(e => e.PpcEsAcumulable)
                    .HasColumnName("ppc_es_acumulable")
                    .HasMaxLength(50);

                entity.Property(e => e.PpcIdPromociones).HasColumnName("ppc_id_promociones");

                entity.Property(e => e.PpcLeyenda).HasColumnName("ppc_leyenda");

                entity.Property(e => e.PpcLeyendaPremio).HasColumnName("ppc_leyenda_premio");

                entity.Property(e => e.PpcNombrePromocion).HasColumnName("ppc_nombre_promocion");

                entity.Property(e => e.PpcRequiereCupon)
                    .HasColumnName("ppc_requiere_cupon")
                    .HasMaxLength(50);

                entity.Property(e => e.PpcTieneCupon)
                    .HasColumnName("ppc_tiene_cupon")
                    .HasMaxLength(50);

                entity.Property(e => e.PpcTipoArticulo)
                    .HasColumnName("ppc_tipo_articulo")
                    .HasMaxLength(50);

                entity.Property(e => e.PpcTipoMov)
                    .HasColumnName("ppc_tipo_mov")
                    .HasMaxLength(50);

                entity.Property(e => e.PpcUMedida)
                    .HasColumnName("ppc_u_medida")
                    .HasMaxLength(50);

                entity.Property(e => e.PpcVTotal)
                    .HasColumnName("ppc_v_total")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SdTmpPromocionesRecargas>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SD_TMP_PromocionesRecargas");

                entity.Property(e => e.EnvioPos)
                    .HasColumnName("envio_pos")
                    .HasMaxLength(50);

                entity.Property(e => e.PcaCodigo).HasColumnName("pca_codigo");

                entity.Property(e => e.RecgCantidadRecarga).HasColumnName("recg_cantidad_recarga");

                entity.Property(e => e.RecgCodigoRecarga)
                    .HasColumnName("recg_codigo_recarga")
                    .HasMaxLength(50);

                entity.Property(e => e.RecgEstado)
                    .HasColumnName("recg_estado")
                    .HasMaxLength(50);

                entity.Property(e => e.RecgIdCliente)
                    .HasColumnName("recg_id_cliente")
                    .HasMaxLength(50);

                entity.Property(e => e.RecgIdPromociones).HasColumnName("recg_id_promociones");

                entity.Property(e => e.RecgNumeroCaja).HasColumnName("recg_numero_caja");

                entity.Property(e => e.RecgNumeroCelular)
                    .HasColumnName("recg_numero_celular")
                    .HasMaxLength(50);

                entity.Property(e => e.RecgOficina)
                    .HasColumnName("recg_oficina")
                    .HasMaxLength(50);

                entity.Property(e => e.RecgOperadora)
                    .HasColumnName("recg_operadora")
                    .HasMaxLength(50);

                entity.Property(e => e.RecgOrigenRecarga)
                    .HasColumnName("recg_origen_recarga")
                    .HasMaxLength(50);

                entity.Property(e => e.RecgSecuencial).HasColumnName("recg_secuencial");

                entity.Property(e => e.RecgSerieFactura)
                    .HasColumnName("recg_serie_factura")
                    .HasMaxLength(50);

                entity.Property(e => e.RecgSucursal)
                    .HasColumnName("recg_sucursal")
                    .HasMaxLength(50);

                entity.Property(e => e.RecgUsuario)
                    .HasColumnName("recg_usuario")
                    .HasMaxLength(50);

                entity.Property(e => e.RecgValorRecarga).HasColumnName("recg_valor_recarga");
            });

            modelBuilder.Entity<SdTransferencias>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SD_Transferencias");

                entity.HasComment(@"Autor: Ing. Claudio Guerron

Tabla que permite almacenar la informacion mas importante de las transferencias. ");

                entity.HasIndex(e => new { e.TranCodigo, e.TranOficinaOrigen, e.TranOficinaDestino, e.TranComprobante })
                    .HasName("_dta_index_SD_Transferencias_17_117575457__K1_K2_K3_K10");

                entity.HasIndex(e => new { e.TranCodigo, e.TranOficinaOrigen, e.TranOficinaDestino, e.TranIpServidorDestino, e.TranIpServidorOrigen, e.TranIpCajaDestino, e.TranIpUsuarioDestino, e.PcaCodigo, e.TranComprobante, e.TranFechaCreacion, e.TranUsuarioOrigen, e.TranEstado, e.TranEstadoPedido })
                    .HasName("_dta_index_SD_Transferencias_17_117575457__K9_K13_1_2_3_4_5_6_7_8_10_11_12");

                entity.Property(e => e.PcaCodigo)
                    .HasColumnName("pca_codigo")
                    .HasComment("Codigo del Pedido ");

                entity.Property(e => e.TranCodigo)
                    .HasColumnName("tran_codigo")
                    .HasComment("Codigo generado de la Transferencia.");

                entity.Property(e => e.TranComprobante)
                    .IsRequired()
                    .HasColumnName("tran_comprobante")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Comprobante generado para realizar la comprobacion de la transferencia.");

                entity.Property(e => e.TranEstado)
                    .IsRequired()
                    .HasColumnName("tran_estado")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Estado de la transferencia [TRANSITO->Cuando la transferencia no es procesada,ANULADA->Cuando la transferencia esta anulada, RECHAZADA->Cuando la transferencia esta rechazada]");

                entity.Property(e => e.TranEstadoPedido)
                    .HasColumnName("tran_estado_pedido")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Esato de la transferencia en el pedido [ACTIVO->Cuando es enviada y no se inactiva por reenvío de la transferencia][INACTIVO->Cuando la transferencia es inactivada]");

                entity.Property(e => e.TranFechaCreacion)
                    .IsRequired()
                    .HasColumnName("tran_fecha_creacion")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Fecha de Creación de la transferencia.");

                entity.Property(e => e.TranIpCajaDestino)
                    .IsRequired()
                    .HasColumnName("tran_ip_caja_destino")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Indica la IP de la caja de la farmacia Destino.");

                entity.Property(e => e.TranIpServidorDestino)
                    .IsRequired()
                    .HasColumnName("tran_ip_servidor_destino")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Indica la IP del Servidor de la farmacia Destino.");

                entity.Property(e => e.TranIpServidorOrigen)
                    .IsRequired()
                    .HasColumnName("tran_ip_servidor_origen")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Indica la IP del Servidor de la farmacia Origen.')");

                entity.Property(e => e.TranIpUsuarioDestino)
                    .IsRequired()
                    .HasColumnName("tran_ip_usuario_destino")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Indica el usuario de la farmacia Destino.");

                entity.Property(e => e.TranOficinaDestino)
                    .IsRequired()
                    .HasColumnName("tran_oficina_destino")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Indica la oficina destino es decir hacia donde sale la transferencia.");

                entity.Property(e => e.TranOficinaOrigen)
                    .IsRequired()
                    .HasColumnName("tran_oficina_origen")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Indica la oficina origen es decir desde donde sale la transferencia.");

                entity.Property(e => e.TranUsuarioOrigen)
                    .HasColumnName("tran_usuario_origen")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Usuario que genera la transferencia.");
            });

            modelBuilder.Entity<SdZona>(entity =>
            {
                entity.HasKey(e => new { e.ZonCodigo, e.ZonProvincia })
                    .HasName("PK_DOM_Zona");

                entity.ToTable("SD_Zona");

                entity.HasComment(@"Autor: Ing. Claudio Guerron
Almacenamos las zonas en las cuales se puede realizar las transferencias.");

                entity.Property(e => e.ZonCodigo)
                    .HasColumnName("zon_codigo")
                    .HasMaxLength(10)
                    .HasComment("Almacenamos el codigo de la zona[Numero entero positivo autoincrementable en 1]");

                entity.Property(e => e.ZonProvincia)
                    .HasColumnName("zon_provincia")
                    .HasMaxLength(2)
                    .HasComment("Referencia tabla [EasyGestionEmpresarial.tbl_zona campo: zona]");

                entity.Property(e => e.ZonEstado)
                    .IsRequired()
                    .HasColumnName("zon_estado")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("Almacenamos el estado del registro[A=Activo,I=Inactivo]");

                entity.Property(e => e.ZonNombre)
                    .IsRequired()
                    .HasColumnName("zon_nombre")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Almacenamos el nombre de la zona");

                entity.Property(e => e.ZonObservacion)
                    .IsRequired()
                    .HasColumnName("zon_observacion")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Almacenamos una descripción de la zona, pueden ser los límites");

                entity.Property(e => e.ZonProvinciaNombre)
                    .IsRequired()
                    .HasColumnName("zon_provincia_nombre")
                    .HasMaxLength(50)
                    .HasComment("Almacenamos el nombre de la provincia.");
            });

            modelBuilder.Entity<SdZonaAdministradores>(entity =>
            {
                entity.HasKey(e => new { e.ZonCodigo, e.ZonProvincia, e.ZadCedula });

                entity.ToTable("SD_ZonaAdministradores");

                entity.HasComment(@"Autor: Ing. Claudio Guerrón

Tabla que permite almacenar la información de los Adminstradores de cada zona");

                entity.Property(e => e.ZonCodigo)
                    .HasColumnName("zon_codigo")
                    .HasMaxLength(10)
                    .HasComment("Referencia [SD_Zona->zon_codigo]");

                entity.Property(e => e.ZonProvincia)
                    .HasColumnName("zon_provincia")
                    .HasMaxLength(2)
                    .HasComment("Referencia[SD_Zona->zon_provinicia]");

                entity.Property(e => e.ZadCedula)
                    .HasColumnName("zad_cedula")
                    .HasMaxLength(20)
                    .HasComment("Campo en el cual se registra el numero de Cédula del Administrador.");

                entity.Property(e => e.ZadEstado)
                    .IsRequired()
                    .HasColumnName("zad_estado")
                    .HasMaxLength(50)
                    .HasComment("Campo que nos indica el estado del Administrador de la zona.[ACTIVO->Indica que esta habilitado para realizar las operaciones respectivas,INACTIVO->No esta habilitado]");

                entity.Property(e => e.ZadNombreCorto)
                    .IsRequired()
                    .HasColumnName("zad_nombre_corto")
                    .HasMaxLength(200)
                    .HasComment("Campo que nos indica el nombre corto del usuario.");

                entity.Property(e => e.ZadNombres)
                    .IsRequired()
                    .HasColumnName("zad_nombres")
                    .HasMaxLength(200)
                    .HasComment("Campo en el cual se ingresa los nombres del administrador.");

                entity.HasOne(d => d.Zon)
                    .WithMany(p => p.SdZonaAdministradores)
                    .HasForeignKey(d => new { d.ZonCodigo, d.ZonProvincia })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SD_ZonaAdministradores_SD_Zona");
            });

            modelBuilder.Entity<TblCopagoDescuentoConvenio>(entity =>
            {
                entity.HasKey(e => new { e.CdcSerieFactura, e.CdcCodigoArticulo });

                entity.ToTable("tbl_CopagoDescuentoConvenio");

                entity.Property(e => e.CdcSerieFactura)
                    .HasColumnName("cdc_serie_factura")
                    .HasMaxLength(50);

                entity.Property(e => e.CdcCodigoArticulo)
                    .HasColumnName("cdc_codigo_articulo")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CdcCliente)
                    .IsRequired()
                    .HasColumnName("cdc_cliente")
                    .HasMaxLength(20);

                entity.Property(e => e.CdcComentario)
                    .HasColumnName("cdc_comentario")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CdcContratoHumana)
                    .HasColumnName("cdc_contrato_humana")
                    .HasMaxLength(500);

                entity.Property(e => e.CdcCopago)
                    .HasColumnName("cdc_copago")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.CdcDescuento)
                    .HasColumnName("cdc_descuento")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.CdcFechaRegistro)
                    .HasColumnName("cdc_fecha_registro")
                    .HasColumnType("datetime");

                entity.Property(e => e.CdcNombrePaciente)
                    .HasColumnName("cdc_nombre_paciente")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CdcNumeroTransito)
                    .HasColumnName("cdc_numero_transito")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CdcOficina)
                    .IsRequired()
                    .HasColumnName("cdc_oficina")
                    .HasMaxLength(5);

                entity.Property(e => e.CdcPaciente)
                    .HasColumnName("cdc_paciente")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CdcSucursal)
                    .IsRequired()
                    .HasColumnName("cdc_sucursal")
                    .HasMaxLength(5);

                entity.Property(e => e.CdcValorAplicadoDescuento)
                    .HasColumnName("cdc_valor_aplicado_descuento")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.CdcValorCopago)
                    .HasColumnName("cdc_valor_copago")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.CdcValorDescuento)
                    .HasColumnName("cdc_valor_descuento")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.EnvioPos)
                    .HasColumnName("envio_pos")
                    .HasMaxLength(2);
            });

            modelBuilder.Entity<TblUsuariosAcceso>(entity =>
            {
                entity.HasKey(e => e.UsuUsuario)
                    .HasName("PK__TblUsuar__12F06106B7383679");

                entity.ToTable("TblUsuariosAcceso", "ecom");

                entity.Property(e => e.UsuUsuario)
                    .HasColumnName("usu_usuario")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.UsuEstado)
                    .IsRequired()
                    .HasColumnName("usu_estado")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.UsuFechaCreacion)
                    .HasColumnName("usu_fecha_creacion")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UsuPassword)
                    .IsRequired()
                    .HasColumnName("usu_password")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
