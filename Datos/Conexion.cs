using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;
namespace Datos
{
    public class Conexion
    {       
        
        public static string ObtenerConnectionString()
        {
            string connectionString = string.Empty;

            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            connectionString = config.GetConnectionString("miConexion");
            return connectionString;
        }
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection con = new SqlConnection(ObtenerConnectionString());
            return con;
        }
        public static void AbrirConexion(SqlConnection con)
        {
            if (con != null && con.State != ConnectionState.Open)
            {
                con.Open();
            }
        }

        public static void CerrarConexion(SqlConnection con)
        {
            if (con != null && con.State != ConnectionState.Closed)
            {
                con.Close();
            }
        }
        public static void CerrarYDesecharConexion(SqlConnection con)
        {
            CerrarConexion(con);
            con.Dispose();
        }
    }
}

   
