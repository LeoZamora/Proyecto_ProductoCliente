using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace FacturacionCD
{
     public class ClienteCD
     {
        private ConexionCD conexion = new ConexionCD();
        SqlDataReader Leer;
        DataTable Tabla = new DataTable();
        SqlCommand comando = new SqlCommand();
        public DataTable Mostrar()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "fact.MostrarCliente";
            comando.CommandType = CommandType.StoredProcedure;
            Leer = comando.ExecuteReader();
            Tabla.Load(Leer);
            conexion.CerrarConexion();
            return Tabla;
        }

        public void Insertar(string CodigodeCliente, string NombredeCliente, string ApellidosdeCliente,
             string DirecciondeCliente)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "fact.InsertarCliente";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@CodigodeCliente", CodigodeCliente);
            comando.Parameters.AddWithValue("@NombredeCliente ", NombredeCliente);
            comando.Parameters.AddWithValue("@ApellidosdeCliente", ApellidosdeCliente);
            comando.Parameters.AddWithValue("@DirecciondeCliente", DirecciondeCliente);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
        public void Editar(string CodigodeCliente, string NombredeCliente, string ApellidosdeCliente,
             string DirecciondeCliente, int Id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "fact.ActualizarCliente";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@CodigodeCliente", CodigodeCliente);
            comando.Parameters.AddWithValue("@NombredeCliente ", NombredeCliente);
            comando.Parameters.AddWithValue("@ApellidosdeCliente", ApellidosdeCliente);
            comando.Parameters.AddWithValue("@DirecciondeCliente", DirecciondeCliente);
            comando.Parameters.AddWithValue("@Id", Id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
        public void Eliminar(int Id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "fact.EliminarCliente";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id", Id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();

        }
        public void Actualizar(string CodigodeCliente, string NombredeCliente, string ApellidosdeCliente,
             string DirecciondeCliente, int Id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "fact.ActualizarProducto";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@CodigodeCliente", CodigodeCliente);
            comando.Parameters.AddWithValue("@NombredeCliente ", NombredeCliente);
            comando.Parameters.AddWithValue("@ApellidosdeCliente", ApellidosdeCliente);
            comando.Parameters.AddWithValue("@DirecciondeCliente", DirecciondeCliente); ;
            comando.Parameters.AddWithValue("@Id", Id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }



    }

}

