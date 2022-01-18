using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;
using System.Linq;

namespace CapaNegocio
{
    public class NegocioCliente
    {
        readonly DatoCliente datoCliente = new DatoCliente();
        readonly DatoCategoria datoCategoria = new DatoCategoria();
        readonly SistemaDeFacturacionEntities database = new SistemaDeFacturacionEntities();

        public List<Categoria> ListaCategoria()
        {
            return datoCategoria.ListaCategoria();
        }

        public Cliente Buscar(int id)
        {
            return datoCliente.Buscar(id);
        }
        public List<VistaClientes_Result> Mostar()
        {
            return database.VistaClientes().ToList();
        }

        public void Guardar(Cliente cliente)
        {
            datoCliente.Guardar(cliente);
        }
        public void Eliminar(Cliente cliente)
        {
            datoCliente.Eliminar(cliente);
        }
        public void Actualizar(Cliente cliente)
        {
            datoCliente.Actualizar(cliente);
        }
    }
}
