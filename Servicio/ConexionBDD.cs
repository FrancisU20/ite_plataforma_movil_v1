using System;
using System.Data;
using System.Data.SqlClient;

namespace Servicio
{
    public class ConexionBDD
    {
        public string Servidor { get; set; }
        public string Catalogo { get; set; }
        public string Usuario { get; set; }
        public string Contrasenia { get; set; }
        public string ConnectionStrings { get; set; }
        public ConexionBDD(string servidor, string catalogo, string usuario, string contrasenia)
        {
            Servidor = servidor;
            Catalogo = catalogo;
            Usuario = usuario;
            Contrasenia = contrasenia;
            ConnectionStrings = @"Data Source = " + Servidor + "; User ID=" + Usuario + "; Password=" + Contrasenia + "; Initial Catalog=" + Catalogo;
        }

        public ConexionBDD(string connectionStrings)
        {
            ConnectionStrings = connectionStrings;
        }

        public DataTable EjecutarSql(string query)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(ConnectionStrings))
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
