using FacturacionCD;
using System.Data;

namespace FacturacionCN
{
    public class ProductoCN
    {
        private ProductoCD ProdCD = new ProductoCD();

        public DataTable MostrarProducto()
        {
            DataTable dt = new DataTable();
            dt = ProdCD.Mostrar();
            return dt;
        }

        public void InsertarProducto(int CodigoDeProducto, string DescripcionDeProducto, double PrecioProducto,
           int Cantidad, int CantidadaMinima, int CantidadaMaxima)
        {
            ProdCD.Insertar(CodigoDeProducto, DescripcionDeProducto, PrecioProducto,
          Cantidad, CantidadaMinima, CantidadaMaxima);
        }

        public void EditarProducto(string CodigoDeProducto, string DescripcionDeProducto, double PrecioProducto,
          int Cantidad, int CantidadaMinima, int CantidadaMaxima, int Id)
        {
            ProdCD.Editar(CodigoDeProducto, DescripcionDeProducto, PrecioProducto,
          Cantidad, CantidadaMinima, CantidadaMaxima, Id);
        }

        public void EliminarProducto(int Id)
        {
            ProdCD.Eliminar(Id);
        }

        public void ActualizarProducto(string CodigoDeProducto, string DescripcionDeProducto, double PrecioProducto,
         int Cantidad, int CantidadaMinima, int CantidadaMaxima, int Id)
        {
            ProdCD.Actualizar(CodigoDeProducto, DescripcionDeProducto, PrecioProducto,
          Cantidad, CantidadaMinima, CantidadaMaxima, Id);
        }


    }
}
