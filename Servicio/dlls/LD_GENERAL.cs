using EasySoft.LogicaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Servicio.dlls
{
    public class LD_GENERAL : ADGenerico
    {
        public LD_GENERAL(String APP, String BDD)
            : base(APP, BDD)
        {
        }

        public Object ObtenerFecha()
        {
            try
            {
                String sql = "select getdate() as fecha";
                ComandoSelect = CrearComando(sql, CommandType.Text);
                return EjecutarEscalar(ComandoSelect);
            }
            catch { return null; }
        }
        public DataTable EjecutarSQL(String sql, String NameTable)
        {
            DataTable dt = new DataTable(NameTable);
            ComandoSelect = CrearComando(sql, CommandType.Text);
            Recuperar(dt);
            return dt;
        }
        public DataTable EjecutarSQLTimeOut(String sql, String NameTable, int timeOut)
        {
            DataTable dt = new DataTable(NameTable);

            ComandoSelect = CrearComando(sql, CommandType.Text);
            if (timeOut > 0)
                ComandoSelect.CommandTimeout = 360000;
            Recuperar(dt);
            return dt;
        }
        public Int32 EjecutarNonQuery(String sql)
        {
            ComandoSelect = CrearComando(sql, CommandType.Text);
            ComandoSelect.CommandTimeout = 360000;
            return EjecutarNoQuery(ComandoSelect);
        }
        public DataTable ObtenerDatos(String TableName, String Top, String Where)
        {
            String sql = "select TOP " + Top + " * from " + TableName + " WITH (nolock)";
            if (!Where.Equals(""))
                sql += " WHERE " + Where;
            DataTable dt = new DataTable(TableName);
            ComandoSelect = CrearComando(sql, CommandType.Text);
            Recuperar(dt);
            return dt;
        }
        public DataTable ObtenerDatosOficina(String where)
        {
            String sql = "select ub.usuario, ofi.sucursal, ofi.oficina , ofi.nombre, suc.nombre as nombresucursal, " +
                         "ofi.establecimiento_SRI, ofi.direccion1,ofi.correo_electronico,  " +
                         "ofi.estado, ofi.es_franquicia, ofi.tipo_idfranquiciado, ofi.numero_idfranquiciado,  " +
                         "ofi.tipo_idfranquiciado_real, ofi.numero_idfranquiciado_real , " +
                         "ofi.telefono1,p.descripcion as nombrepais, c.descripcion as nombreciudad " +
                         "from dbo.tbl_UsuariosBodega ub (nolock)  " +
                         "inner join oficina ofi (nolock) on  " +
                         "ub.Oficina = ofi.oficina " +
                         "inner join sucursal suc (nolock) on " +
                         "ofi.sucursal = suc.sucursal " +
                         "inner join tbl_pais p (nolock) on " +
                         "ofi.pais = p.idpais " +
                         "inner join tbl_ciudad c (nolock) on " +
                         "ofi.canton = c.ciudad ";
            if (!where.Equals(""))
                sql += " where " + where;
            DataTable dt = new DataTable("tbl_DatosOficina");
            ComandoSelect = CrearComando(sql, CommandType.Text);
            Recuperar(dt);
            return dt;
        }
        public DataTable ObtenerDatosCompania(String where)
        {
            String sql = "select compania, nombre_compania,direccionempresa1,iva,ice,rucempresa, " +
                         "telefonoempresa,pais,a.provincia,c.ciudad,p.descripcion as nombrePais, " +
                         "c.descripcion as nombreCiudad, codigo_moneda, a.autorizacionsri, a.fecfinautorizacion, a.resolucion_contrib_especial " +
                         "from dbo.tbl_ambiente a (nolock) " +
                         "inner join tbl_pais p (nolock) on " +
                         "a.pais = p.idpais " +
                         "inner join tbl_ciudad c (nolock) on " +
                         "a.ciudad = c.ciudad ";
            if (!where.Equals(""))
                sql += " where " + where;
            DataTable dt = new DataTable("tbl_DatosCompania");
            ComandoSelect = CrearComando(sql, CommandType.Text);
            Recuperar(dt);
            return dt;
        }
        public DataTable ObtenerSucursales(String TOP, String Where)
        {
            String sql = "select " + TOP + " * from sucursal with(nolock) ";
            if (!Where.Equals(""))
                sql += " where " + Where;
            DataTable dtSucursal = new DataTable("sucursal");
            ComandoSelect = CrearComando(sql, CommandType.Text);
            Recuperar(dtSucursal);
            return dtSucursal;

        }
        public DataTable ObtenerOficinas(String TOP, String Where)
        {
            String sql = "select " + TOP + " * from oficina with(nolock) ";
            if (!Where.Equals(""))
                sql += " where " + Where;
            DataTable dtSucursal = new DataTable("oficina");
            ComandoSelect = CrearComando(sql, CommandType.Text);
            Recuperar(dtSucursal);
            return dtSucursal;

        }
        public DataSet ObtenerTablasAnulacion(String TOP, String Where)
        {
            DataSet ds = new DataSet("TablasAnulacion");
            DataTable DtTabla = new DataTable("tbl_maestrofact");
            String sql = "select * from tbl_maestrofact with(nolock) ";
            if (!Where.Equals(""))
                sql += " WHERE " + Where;
            ComandoSelect = CrearComando(sql, CommandType.Text);
            Recuperar(DtTabla);
            ds.Tables.Add(DtTabla.Copy());
            //-------------------------------------------------------------------------------
            DtTabla = new DataTable("tbl_maestrocanc");
            sql = "select * from tbl_maestrocanc with(nolock) ";
            if (!Where.Equals(""))
                sql += " WHERE " + Where;
            ComandoSelect = CrearComando(sql, CommandType.Text);
            Recuperar(DtTabla);
            ds.Tables.Add(DtTabla.Copy());
            //-------------------------------------------------------------------------------
            DtTabla = new DataTable("tbl_maestromovinvent");
            sql = "select * from tbl_maestromovinvent with(nolock) ";
            if (!Where.Equals(""))
                sql += " WHERE " + Where;
            ComandoSelect = CrearComando(sql, CommandType.Text);
            Recuperar(DtTabla);
            ds.Tables.Add(DtTabla.Copy());
            //-------------------------------------------------------------------------------
            DtTabla = new DataTable("tbl_cxcobrar");
            sql = "select * from tbl_cxcobrar with(nolock) ";
            if (!Where.Equals(""))
                sql += " WHERE " + Where;
            ComandoSelect = CrearComando(sql, CommandType.Text);
            Recuperar(DtTabla);
            ds.Tables.Add(DtTabla.Copy());
            //-------------------------------------------------------------------------------
            DtTabla = new DataTable("tbl_custodiochq");
            sql = "select * from tbl_custodiochq with(nolock) ";
            if (!Where.Equals(""))
                sql += " WHERE " + Where;
            ComandoSelect = CrearComando(sql, CommandType.Text);
            Recuperar(DtTabla);
            ds.Tables.Add(DtTabla.Copy());
            //-------------------------------------------------------------------------------
            DtTabla = new DataTable("tbl_desglosecanc");
            sql = "select * from tbl_desglosecanc with(nolock) ";
            if (!Where.Equals(""))
                sql += " WHERE " + Where;
            ComandoSelect = CrearComando(sql, CommandType.Text);
            Recuperar(DtTabla);
            ds.Tables.Add(DtTabla.Copy());

            return ds;
        }
        public DataTable ObtenerDesgloseCanc(String Where)
        {
            DataTable DtTabla = new DataTable("tbl_desglosecanc");
            String sql = "select * from tbl_desglosecanc with(nolock) ";
            if (!Where.Equals(""))
                sql += " WHERE " + Where;
            ComandoSelect = CrearComando(sql, CommandType.Text);
            Recuperar(DtTabla);
            return DtTabla;
        }
        public DataTable ObtenerFormaPago(String TOP, String Where)
        {
            DataTable DtTabla = new DataTable("tbl_formapago");
            String sql = "select * from tbl_formapago with(nolock) ";
            if (!Where.Equals(""))
                sql += " WHERE " + Where;
            ComandoSelect = CrearComando(sql, CommandType.Text);
            Recuperar(DtTabla);

            return DtTabla;
        }
        public DataTable ObtenerTarjetas(String TOP, String Where)
        {
            DataTable DtTabla = new DataTable("tbl_tarjetas");
            String sql = "select * from tbl_tarjetas with(nolock) ";
            if (!Where.Equals(""))
                sql += " WHERE " + Where;
            ComandoSelect = CrearComando(sql, CommandType.Text);
            Recuperar(DtTabla);

            return DtTabla;
        }
        //public String AnularFacturar(Object[] Tablas)
        public String AnularFacturar(DataSet Tablas)
        {
            IDbTransaction objTran = CrearTransaccion();
            IDbTransaction objTran1 = CrearTransaccion();
            String res = "NINGUNA TABLA AFECTADA";
            try
            {
                for (int i = 0; i < Tablas.Tables.Count; i++)
                {
                    if (Tablas.Tables[i].Rows.Count > 0)
                    {
                        if (Tablas.Tables[i].TableName.Equals("MOV_INVENT"))
                        {
                            if (i == 6)
                            {
                                Tablas.Tables[2].TableName = "MOV_INVENT1";
                                Tablas.Tables[i].TableName = "tbl_maestromovinvent";
                                Tablas.Tables[2].TableName = "MOV_INVENT";
                            }
                            else
                            {
                                Tablas.Tables[6].TableName = "MOV_INVENT1";
                                Tablas.Tables[i].TableName = "tbl_maestromovinvent";
                                Tablas.Tables[6].TableName = "MOV_INVENT";
                            }
                        }
                        if (Tablas.Tables[i].Rows.Count > 0 && !Tablas.Tables[i].TableName.Equals("C_MOVIMIENTOS"))
                            Grabar(Tablas.Tables[i].Copy());
                        else
                        {
                            if (Tablas.Tables[i].TableName.Equals("C_MOVIMIENTOS"))
                            {
                                if (Tablas.Tables[i].Rows.Count > 0)
                                    objTran1 = new LD_AperturaCierreCaja("PUNTOVENTA", "BDDEASYPAGOS").grabarTransaccion(Tablas.Tables[i].Copy());
                            }
                        }
                        res = "OK";
                    }
                }
                objTran1.Commit();
                objTran.Commit();
                return res;
            }
            catch (Exception ex)
            {
                if (objTran != null)
                    objTran.Rollback();
                if (objTran1 != null)
                    objTran1.Rollback();
                return ex.Message;
            }
        }
        public DataTable SacarOficinaFranquiciado()
        {
            try
            {
                DataTable dt = new DataTable("oficina");
                string sql = " select o.*,ISNULL(c.nombre_razon,'SIN ASIGNAR') NOMBRE_FRANQUICIADO,'ASIGNAR' ASIGNAR, ";
                sql += " CASE ";
                sql += " WHEN es_franquicia ='N' THEN 'PROPIA' ";
                sql += " WHEN es_franquicia ='S' THEN 'FRANQUICIA' ";
                sql += " END PROPIA,ISNULL(c.estatus,'') estatus  ";
                sql += " from oficina  o with(nolock) ";
                sql += " LEFT JOIN tbl_clientes c with(nolock)  ";
                sql += " ON o.numero_idFranquiciado_real=c.numero_idcliente ";
                sql += " where oficina not in ('TOT','000')  ";

                ComandoSelect = CrearComando(sql, CommandType.Text);
                Recuperar(dt);

                return dt;
            }
            catch { return null; }
        }
        //public String GrabarOficinas(DataTable dtOficina)
        public String GrabarOficinas(DataSet ds)
        {
            IDbTransaction objTran = CrearTransaccion();
            String res = "OK";
            try
            {
                DataTable dtOficina = ds.Tables[0].Copy();
                if (dtOficina.Rows.Count > 0)
                    Grabar(dtOficina);
                objTran.Commit();
                return res;
            }
            catch (Exception ex)
            {
                if (objTran != null)
                    objTran.Rollback();
                return ex.Message;
            }
        }
        #region DocumentacionValija
        public DataTable ObtenerTipoDocumentoEnvioMatriz(bool todos)
        {
            try
            {
                DataTable dt = new DataTable("pv_tipodocumentoenvio");
                string sql = " select td.tde_id, tde_nombre, tde_estado from EasyGestionEmpresarial.dbo.pv_tipodocumentoenvio td ";
                if (!todos)
                    sql += " inner join EasyGestionEmpresarial.par.tbl_par_DocumentacionValija dv on td.tde_id = dv.tde_id ";
                sql += " where tde_estado='Activo' order by td.tde_id";
                ComandoSelect = CrearComando(sql, CommandType.Text);
                Recuperar(dt);

                return dt;
            }
            catch { return null; }
        }
        public DataTable ObtenerDeparatamento(bool todos)
        {
            try
            {
                DataTable dt = new DataTable("vta_departamento");
                string sql = "select distinct d.* from  EasyGestionEmpresarial.par.vta_departamento d";
                if (!todos)
                    sql += " inner join EasyGestionEmpresarial.par.tbl_par_DocumentacionValija dv on d.codigodepartamento = dv.dv_departamento";
                sql += " order by d.departamento";
                ComandoSelect = CrearComando(sql, CommandType.Text);
                Recuperar(dt);

                return dt;
            }
            catch { return null; }
        }
        public DataTable ObtenerAreas(string oficina, bool todos)
        {
            try
            {
                DataTable dt = new DataTable("par.vta_area");
                string sql = "select distinct a.* from  EasyGestionEmpresarial.par.vta_area a";
                if (!todos)
                    sql += " inner join EasyGestionEmpresarial.par.tbl_par_DocumentacionValija dv on dv.dv_area = a.codigoarea " +
                            " order by a.area";
                else
                    sql += " where codigodepartamento='" + oficina + "' order by a.area";

                ComandoSelect = CrearComando(sql, CommandType.Text);
                Recuperar(dt);

                return dt;
            }
            catch { return null; }
        }
        public DataTable ObtenerDocumentosValijasParametrizados(string idtipoDocumento = "", string codigodepartamento = "", string codigoarea = "", string cedularesponsable = "",
                                                                string nombreDocumento = "", string idDocumentoValija = "")
        {
            try
            {
                DataTable dt = new DataTable("par.tbl_par_DocumentacionValija");
                string sql = "select dv.*,td.tde_nombre as tipoDocumento, d.departamento,a.area,isnull(cf.nombre_convenio, 'N/A') as  nombre_convenio " +
                               "from EasyGestionEmpresarial.par.tbl_par_DocumentacionValija dv " +
                               "inner join EasyGestionEmpresarial.dbo.pv_tipodocumentoenvio td on dv.tde_id=td.tde_id " +
                               "inner join EasyGestionEmpresarial.par.vta_departamento d on dv.dv_departamento = d.codigodepartamento " +
                               "inner join EasyGestionEmpresarial.par.vta_area a on dv.dv_area = a.codigoarea " +
                               "left join EasyGestionEmpresarial.dbo.convenio_fac cf on cf.id_convenio=dv.dv_idconvenio";
                string where = " where 1=1";
                if (idtipoDocumento != "")
                    where += " and dv.tde_id=" + idtipoDocumento;
                if (codigodepartamento != "")
                    where += " and dv_departamento=" + codigodepartamento;
                if (codigoarea != "")
                    where += " and dv_area=" + codigoarea;
                if (cedularesponsable != "")
                    where += " and dv_cedularesponsable='" + cedularesponsable + "'";
                if (nombreDocumento != "")
                    where += " and td.tde_nombre like '%" + nombreDocumento + "%'";
                if (idDocumentoValija != "")
                    where += " and dv_id=" + idDocumentoValija;

                if (where.Contains("and"))
                    where = where.Replace("1=1 and", "");
                where += " order by dv.dv_id";
                sql = sql + where;
                ComandoSelect = CrearComando(sql, CommandType.Text);
                Recuperar(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " - " + ex.StackTrace);
                //return null; 
            }
        }
        public int ObtenerCodigoDocumentoValija()
        {

            try
            {
                DataTable dt = new DataTable("par.tbl_par_DocumentacionValija");
                int id = 0;
                string sql = "select isnull((max(dv_id)+1),1) as codigo from EasyGestionEmpresarial.par.tbl_par_DocumentacionValija";
                ComandoSelect = CrearComando(sql, CommandType.Text);
                Recuperar(dt);
                if (dt.Rows.Count > 0)
                    id = Convert.ToInt32(dt.Rows[0]["codigo"].ToString());

                return id;
            }
            catch { return 0; }
        }
        public DataTable ObtenerDocumentoValija(int top, string id)
        {
            try
            {
                DataTable dt = new DataTable("EasyGestionEmpresarial.par.tbl_par_DocumentacionValija");
                string sql = "select top " + top.ToString() + " * from  EasyGestionEmpresarial.par.tbl_par_DocumentacionValija";
                if (id != "")
                    sql += " where dv_id=" + id;
                ComandoSelect = CrearComando(sql, CommandType.Text);
                Recuperar(dt);

                return dt;
            }
            catch { return null; }
        }
        #endregion

        public DataTable ObtenerIpServidor()
        {
            try
            {
                string sql = "SELECT * FROM dbo.PV_IPSERVIDOR with(nolock)";
                DataTable dt = new DataTable("PV_IPSERVIDOR");
                ComandoSelect = CrearComando(sql, CommandType.Text);
                Recuperar(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " - " + ex.StackTrace);
            }
        }
    }
}
