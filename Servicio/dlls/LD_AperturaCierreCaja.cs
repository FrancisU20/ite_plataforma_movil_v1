using EasySoft.LogicaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Servicio.dlls
{
    public class LD_AperturaCierreCaja : ADGenerico
    {
        public LD_AperturaCierreCaja(String App, String BDD)
            : base(App, BDD)
        {
        }
        public DataTable ObtenerUsuarios(String fechaTransaccion, String sucursal, String Oficina)
        {
            DataTable dtdatos = new DataTable("USUARIOS_APERURA_CIERRECAJA");
            try
            {
                String sql = "select '[SELECCIONE UNA OPCION]' as userid,'' as codigotransaccion,'' as sucursal,'' as agencia,'' as maquinaid,'' as HORATRANSACCION " +
                             " union all " +
                             "SELECT userid,codigotransaccion,sucursal,agencia,maquinaid,HORATRANSACCION FROM dbo.m_log WITH (NOLOCK) " +
                             "WHERE CONVERT(VARCHAR,HORATRANSACCION,111) ='" + fechaTransaccion + "' AND CODIGOTRANSACCION ='APERTURA' AND SUCURSAL='" + sucursal + "' AND AGENCIA='" + Oficina + "'";
                ComandoSelect = CrearComando(sql, CommandType.Text);
                Recuperar(dtdatos);
                return dtdatos;
            }
            catch (Exception ex)
            {
                new Exception(ex.Message);
                return dtdatos;
            }
        }
        public DataTable ObtenerCierresCaja(String fechaTransaccion, String usuario)
        {
            DataTable dtDatos = new DataTable("CIERRES_CAJA");
            try
            {
                String sql = "";
                sql = "select '[SELECCIONE UNA OPCION]' as HORATRANSACCION,'-1' as Id_Log_Ref " +
                      " union all " +
                      " select CONVERT(VARCHAR,HORATRANSACCION,111)+' '+CONVERT(VARCHAR,HORATRANSACCION,108) as  HORATRANSACCION,Id_Log_Ref from dbo.m_log WITH (NOLOCK) " +
                      " WHERE CONVERT(VARCHAR,HORATRANSACCION,111) ='" + fechaTransaccion + "' AND CODIGOTRANSACCION ='CIERRE' AND USerid='" + usuario + "'";
                ComandoSelect = CrearComando(sql, CommandType.Text);
                Recuperar(dtDatos);
                return dtDatos;
            }
            catch (Exception ex)
            {
                new Exception(ex.Message);
                return dtDatos;
            }
        }
        public DataTable ObtenerAperturaCaja(String Id_Log)
        {
            DataTable dtDatos = new DataTable("APERTURA_CAJA");
            try
            {
                String sql = "";
                sql = "select * FROM dbo.m_log WITH (NOLOCK) where Id_Log=" + Id_Log;
                ComandoSelect = CrearComando(sql, CommandType.Text);
                Recuperar(dtDatos);
                return dtDatos;
            }
            catch (Exception ex)
            {
                new Exception(ex.Message);
                return dtDatos;
            }
        }

        public DataTable ObtenerAvancesEfectivo(String fechaDesde, String FechaHasta, String usuario, String codTransaccion, String sucursal, String oficina, String Marcado)
        {
            DataTable dtDatos = new DataTable("AVANCES DE CAJA");
            try
            {
                String sql = "";
                if (!usuario.Equals(""))
                {
                    sql = "SELECT * FROM dbo.C_MOVIMIENTOS WITH(NOLOCK) WHERE " +
                          " CONVERT(varchar,CONVERT(DATETIME, HoraProceso),111)+' '+CONVERT(varchar,CONVERT(DATETIME,HoraProceso),108) >='" + fechaDesde + "' AND " +
                          " CONVERT(varchar,CONVERT(DATETIME, HoraProceso),111)+' '+CONVERT(varchar,CONVERT(DATETIME,HoraProceso),108) <='" + FechaHasta + "' " +
                          " AND CodigoCaja='" + usuario + "' AND CodigoTransaccion='" + codTransaccion + "' AND MARCADO='" + Marcado + "' AND sucursal='" + sucursal + "' AND agencia='" + oficina + "'";

                }
                else
                {
                    sql = "SELECT * FROM dbo.C_MOVIMIENTOS WITH(NOLOCK) WHERE " +
                          " CONVERT(varchar,CONVERT(DATETIME, HoraProceso),111)+' '+CONVERT(varchar,CONVERT(DATETIME,HoraProceso),108) >='" + fechaDesde + "' AND " +
                          " CONVERT(varchar,CONVERT(DATETIME, HoraProceso),111)+' '+CONVERT(varchar,CONVERT(DATETIME,HoraProceso),108) <='" + FechaHasta + "' " +
                          " AND CodigoTransaccion='" + codTransaccion + "' AND MARCADO='" + Marcado + "' AND sucursal='" + sucursal + "' AND agencia='" + oficina + "'";
                }
                ComandoSelect = CrearComando(sql, CommandType.Text);
                Recuperar(dtDatos);
                return dtDatos;
            }
            catch (Exception ex)
            {
                new Exception(ex.Message);
                return dtDatos;
            }
        }

        public DataTable ObtenerApertutaCaja(String fechaDesde, String FechaHasta, String sucursal, String oficina)
        {
            DataTable dtDatos = new DataTable("AVANCES DE CAJA");
            try
            {
                String sql = "";
                sql = "SELECT * FROM dbo.m_log WITH(NOLOCK) WHERE " +
                      " CONVERT(varchar,CONVERT(DATETIME, HoraTransaccion),111)+' '+CONVERT(varchar,CONVERT(DATETIME,HoraTransaccion),108) >='" + fechaDesde + "' AND " +
                      " CONVERT(varchar,CONVERT(DATETIME, HoraTransaccion),111)+' '+CONVERT(varchar,CONVERT(DATETIME,HoraTransaccion),108) <='" + FechaHasta + "' " +
                      " AND sucursal='" + sucursal + "' AND agencia='" + oficina + "' AND codigotransaccion='APERTURA'";
                ComandoSelect = CrearComando(sql, CommandType.Text);
                Recuperar(dtDatos);
                return dtDatos;
            }
            catch (Exception ex)
            {
                new Exception(ex.Message);
                return dtDatos;
            }
        }
        public DataTable ObtenerTodosCierresCaja(String id_logs, String fechaDesde, String fechaHasta)
        {
            DataTable dtDatos = new DataTable("CIERRES_CAJA");
            try
            {
                String sql = "";
                sql = "SELECT * FROM dbo.m_log WITH(NOLOCK) " +
                      "where id_log_Ref in (" + id_logs + ") and codigotransaccion='CIERRE' AND " +
                      "CONVERT(varchar,CONVERT(DATETIME, HoraTransaccion),111)+' '+CONVERT(varchar,CONVERT(DATETIME,HoraTransaccion),108) >='" + fechaDesde + "' AND " +
                      "CONVERT(varchar,CONVERT(DATETIME, HoraTransaccion),111)+' '+CONVERT(varchar,CONVERT(DATETIME,HoraTransaccion),108) <='" + fechaHasta + "'";
                ComandoSelect = CrearComando(sql, CommandType.Text);
                Recuperar(dtDatos);
                return dtDatos;
            }
            catch (Exception ex)
            {
                new Exception(ex.Message);
                return dtDatos;
            }
        }
        public DataTable ObtenerTodosDsctosCaja(String fechaHasta)
        {
            DataTable dtDatos = new DataTable("c_movimientos");
            try
            {
                String sql = "";
                sql = "select * from c_movimientos with (nolock) " +
                      " where codigotransaccion='CJA' and CONVERT(varchar,CONVERT(DATETIME, horaproceso),111)+' '+CONVERT(varchar,CONVERT(DATETIME,horaproceso),108) >='" + fechaHasta + "'";
                ComandoSelect = CrearComando(sql, CommandType.Text);
                Recuperar(dtDatos);
                return dtDatos;
            }
            catch (Exception ex)
            {
                new Exception(ex.Message);
                return dtDatos;
            }
        }
        public DataTable ObtenerAperturaAnterior(String userID, String fechaFactura)
        {
            DataTable dtDatos = new DataTable("c_movimientos");
            try
            {
                String sql = "";
                sql = "select  max(Id_log) as Id_Log from m_log with (nolock) " +
                      " where userid='" + userID + "' and " +
                      " CONVERT( DATETIME, CONVERT(VARCHAR,HORATRANSACCION,111)+ ' '+ CONVERT(VARCHAR,HORATRANSACCION,108) ) <= '" + fechaFactura + "' AND codigoTransaccion='APERTURA'";
                ComandoSelect = CrearComando(sql, CommandType.Text);
                Recuperar(dtDatos);
                return dtDatos;
            }
            catch (Exception ex)
            {
                new Exception(ex.Message);
                return dtDatos;
            }
        }

        public DataTable ObtenerCierreCajaSiguiente(String Id_Log)
        {
            DataTable dtDatos = new DataTable("APERTURA_CAJA");
            try
            {
                String sql = "";
                sql = "select * FROM dbo.m_log WITH (NOLOCK) where codigoTransaccion='CIERRE' and Id_Log_Ref=" + Id_Log;
                ComandoSelect = CrearComando(sql, CommandType.Text);
                Recuperar(dtDatos);
                return dtDatos;
            }
            catch (Exception ex)
            {
                new Exception(ex.Message);
                return dtDatos;
            }
        }
        public DataTable ObtenerMovAnular(String SerieFactura)
        {
            DataTable dtdatos = new DataTable("C_MOVIMIENTOS");
            try
            {
                String sql = " SELECT * FROM dbo.C_MOVIMIENTOS WITH (NOLOCK) " +
                             " WHERE referenciatransaccion LIKE '%" + SerieFactura + "%'";
                ComandoSelect = CrearComando(sql, CommandType.Text);
                Recuperar(dtdatos);
                return dtdatos;
            }
            catch (Exception ex)
            {
                new Exception(ex.Message);
                return dtdatos;
            }
        }

        public IDbTransaction grabarTransaccion(DataTable dtTransaccion)
        {
            IDbTransaction tran = CrearTransaccion();
            try
            {
                if (dtTransaccion.Rows.Count > 0)
                    Grabar(dtTransaccion);
                return tran;
            }
            catch { return null; }
        }
    }
}
