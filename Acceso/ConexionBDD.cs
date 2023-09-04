using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceso
{
    public class ConexionBDD
    {
        public string Servidor { get; set; }
        public string Catalogo { get; set; }
        public string Usuario { get; set; }
        public string Contrasenia { get; set; }
        public ConexionBDD(string servidor, string catalogo, string usuario, string contrasenia)
        {
            Servidor = servidor;
            Catalogo = catalogo;
            Usuario = usuario;
            Contrasenia = contrasenia;
        }

        public DataTable EjecutarSql(string query)
        {
            try
            {
                string connectionString = @"Data Source = " + Servidor + "; User ID=" + Usuario + "; Password=" + Contrasenia + "; Initial Catalog=" + Catalogo;
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());
                        connection.Close();
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
