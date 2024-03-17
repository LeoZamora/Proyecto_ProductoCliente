using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace FacturacionCD
{
    public class ProductoCD
    {
        private ConexionCD conexion = new ConexionCD();
        SqlDataReader Leer;
        DataTable Tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "fact.MostrarProducto";
            comando.CommandType = CommandType.StoredProcedure;
            Leer = comando.ExecuteReader();
            Tabla.Load(Leer);
            conexion.CerrarConexion();
            return Tabla;
        }

        public void Insertar( int CodigoDeProducto, string DescripcionDeProducto, double PrecioProducto,
             int Cantidad, int CantidadaMinima, int CantidadaMaxima)
        {
            comando.Connection=conexion.AbrirConexion();
            comando.CommandText = "fact.InsertarProducto";
            comando.CommandType= CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@CodigoProducto", CodigoDeProducto);
            comando.Parameters.AddWithValue("@Descripcion", DescripcionDeProducto);
            comando.Parameters.AddWithValue("@Precio", PrecioProducto);
            comando.Parameters.AddWithValue("@Cantidad", Cantidad);
            comando.Parameters.AddWithValue("@CantidadMinima", CantidadaMaxima);
            comando.Parameters.AddWithValue("@CantidadMaxima", CantidadaMinima);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
        public void Editar(string CodigoDeProducto, string DescripcionDeProducto, double PrecioProducto,
             int Cantidad, int CantidadaMinima, int CantidadaMaxima, int Id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "fact.ActualizarProducto";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@CodigoProducto", CodigoDeProducto);
            comando.Parameters.AddWithValue("@Descripcion", DescripcionDeProducto);
            comando.Parameters.AddWithValue("@Precio", PrecioProducto);
            comando.Parameters.AddWithValue("@Cantidad", Cantidad);
            comando.Parameters.AddWithValue("@CantidadMinima", CantidadaMaxima);
            comando.Parameters.AddWithValue("@CantidadMaxima", CantidadaMinima);
            comando.Parameters.AddWithValue("@Id", Id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
        public void Eliminar(int Id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "fact.EliminarProducto";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id", Id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();

        }
        public void Actualizar (string CodigoDeProducto, string DescripcionDeProducto, double PrecioProducto,
            int Cantidad, int CantidadaMinima, int CantidadaMaxima, int Id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "fact.ActualizarProducto";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@CodigoProducto", CodigoDeProducto);
            comando.Parameters.AddWithValue("@Descripcion", DescripcionDeProducto);
            comando.Parameters.AddWithValue("@Precio", PrecioProducto);
            comando.Parameters.AddWithValue("@Cantidad", Cantidad);
            comando.Parameters.AddWithValue("@CantidadMinima", CantidadaMaxima);
            comando.Parameters.AddWithValue("@CantidadMaxima", CantidadaMinima);
            comando.Parameters.AddWithValue("@Id", Id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }



    }
}
