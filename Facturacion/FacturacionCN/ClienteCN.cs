using FacturacionCD;
using System.Data;

namespace FacturacionCN
{
    public class ClienteCN
    {
        private ClienteCD CliCD = new ClienteCD();

        public DataTable MostrarCliente()
        {
            DataTable dt = new DataTable();
            dt = CliCD.Mostrar();
            return dt;
        }
        public void InsertarCliente(string CodigodeCliente, string NombredeCliente, string ApellidosdeCliente,
             string DirecciondeCliente)
        {
            CliCD.Insertar(CodigodeCliente, NombredeCliente, ApellidosdeCliente,
            DirecciondeCliente);
        }

        public void EditarCliente(string CodigodeCliente, string NombredeCliente, string ApellidosdeCliente,
             string DirecciondeCliente, int Id)
        {
            CliCD.Editar(CodigodeCliente, NombredeCliente, ApellidosdeCliente,
           DirecciondeCliente, Id);
        }

        public void EliminarCliente(int Id)
        {
            CliCD.Eliminar(Id);
        }

        public void ActualizarCliente(string CodigodeCliente, string NombredeCliente, string ApellidosdeCliente,
             string DirecciondeCliente, int Id)
        {
            CliCD.Actualizar(CodigodeCliente, NombredeCliente, ApellidosdeCliente,
           DirecciondeCliente, Id);
        }
    }

}
