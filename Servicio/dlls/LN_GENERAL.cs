using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Servicio.dlls
{
    public class LN_GENERAL
    {
        LD_GENERAL ld_general = new LD_GENERAL("PUNTOVENTA", "CONPVEASY");

        public LN_GENERAL()
        {
        }
        public DateTime ObtenerFecha()
        {
            Object obj = ld_general.ObtenerFecha();
            if (obj != null)
            {
                return Convert.ToDateTime(obj);
            }
            return DateTime.Now;
        }
        public Int32 EjecutarNonQuery(String sql)
        {
            return ld_general.EjecutarNonQuery(sql);
        }
        public DataTable EjecutarSQLTimeOut(String sql, String NameTable, int timeOut)
        {
            return ld_general.EjecutarSQLTimeOut(sql, NameTable, timeOut);
        }
        public DataTable EjecutarSQL(String sql, String NameTable)
        {
            return ld_general.EjecutarSQL(sql, NameTable);
        }
        public DataTable ObtenerDatos(String TableName, String Top, String Where)
        {
            return ld_general.ObtenerDatos(TableName, Top, Where);

        }
        public String DatosEsyCash(String App, String Clave)
        {
            return EasySoft.Util.AccessPoint.GetParametro(App, Clave);
        }
        public DataTable ObtenerDatosOficina(String where)
        {
            return ld_general.ObtenerDatosOficina(where);
        }
        public DataTable ObtenerDatosCompania(String where)
        {
            return ld_general.ObtenerDatosCompania(where);

        }
        public Object[] DatosBDD_LOGIN_PASSWORD(String App, String Clave)
        {
            try
            {
                String Cadena = EasySoft.Util.AccessPoint.GetParametro(App, Clave);
                String Bdd = "", Password = "", Login = "", Catalogo = ""; ;
                String[] valores = Cadena.Split(';');
                for (int i = 0; i < valores.Length; i++)
                {
                    if (valores[i].ToUpper().IndexOf("PASSWORD") != -1)
                        Password = valores[i].Split('=')[1];
                    else if (valores[i].ToUpper().IndexOf("USER ID") != -1)
                        Login = valores[i].Split('=')[1];
                    else if (valores[i].ToUpper().IndexOf("DATA SOURCE") != -1)
                        Bdd = valores[i].Split('=')[1];
                    else if (valores[i].ToUpper().IndexOf("INITIAL CATALOG") != -1)
                        Catalogo = valores[i].Split('=')[1];
                }
                return new Object[] { Bdd, Login, Password, Catalogo };
            }
            catch (Exception ex)
            {
                return new Object[] { "001", ex.Message };
            }
        }


        public DataTable ObtenerSucursales(String TOP, String Where)
        {
            return ld_general.ObtenerSucursales(TOP, Where);
        }
        public DataTable ObtenerOficinas(String TOP, String Where)
        {
            return ld_general.ObtenerOficinas(TOP, Where);
        }
        public DataSet ObtenerTablasAnulacion(String TOP, String Where)
        {
            return ld_general.ObtenerTablasAnulacion(TOP, Where);
        }
        public String AnularFacturar(DataSet Tablas)
        {
            return ld_general.AnularFacturar(Tablas);
        }
        public DataTable ObtenerFormaPago(String TOP, String Where)
        {
            return ld_general.ObtenerFormaPago(TOP, Where);
        }
        public DataTable ObtenerTarjetas(String TOP, String Where)
        {
            return ld_general.ObtenerTarjetas(TOP, Where);
        }
        public DataTable ObtenerDesgloseCanc(String Where)
        {
            return ld_general.ObtenerDesgloseCanc(Where);
        }
        public DataTable SacarOficinaFranquiciado()
        {
            return ld_general.SacarOficinaFranquiciado();
        }
        public String GrabarOficinas(DataSet dsOficina)
        {
            return ld_general.GrabarOficinas(dsOficina);
            //return ld_general.GrabarOficinas(dtOficina);
        }
        #region DocumentacionValija
        public DataTable ObtenerTipoDocumentoEnvioMatriz(bool todos)
        {
            return ld_general.ObtenerTipoDocumentoEnvioMatriz(todos);
        }
        public DataTable ObtenerDeparatamento(bool todos)
        {
            return ld_general.ObtenerDeparatamento(todos);
        }
        public DataTable ObtenerAreas(string oficina, bool todos)
        {
            return ld_general.ObtenerAreas(oficina, todos);
        }
        public DataTable ObtenerDocumentosValijasParametrizados(string idtipoDocumento = "", string codigodepartamento = "", string codigoarea = "", string cedularesponsable = "",
                                                                string nombreDocumento = "", string idDocumentoValija = "")
        {
            return ld_general.ObtenerDocumentosValijasParametrizados(idtipoDocumento, codigodepartamento, codigoarea, cedularesponsable, nombreDocumento, idDocumentoValija);
        }
        public int ObtenerCodigoDocumentoValija()
        {
            return ld_general.ObtenerCodigoDocumentoValija();
        }
        public DataTable ObtenerDocumentoValija(int top, string id)
        {
            return ld_general.ObtenerDocumentoValija(top, id);
        }
        #endregion

        public DataTable ObtenerIpServidor()
        {
            return ld_general.ObtenerIpServidor();
        }
    }
}
