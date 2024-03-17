using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace FacturacionCD
{
    public class ConexionCD
    {
        /*cadena de conexion bd*/

        private readonly SqlConnection Conexion = new SqlConnection("Server = DESKTOP-U2BS6VB\\SQLEXPRESS; Database = FacturacionGA; Integrated Security = True");

        public SqlConnection AbrirConexion()
        {
            if (Conexion.State==ConnectionState.Closed)  //se abre la conexion
                Conexion.Open();
            return Conexion; 
        }
        public SqlConnection CerrarConexion() 
        {
            if (Conexion.State == ConnectionState.Open)  //se cierra la conexion
                Conexion.Close();
            return Conexion;
        }
    }
}
