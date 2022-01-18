using CapaEntidad;
using System.Collections.Generic;
using System.Linq;

namespace CapaDatos
{
    public class DatoCliente
    {
        readonly SistemaDeFacturacionEntities database = new SistemaDeFacturacionEntities();

        public List<Cliente> Mostar()
        {
            return database.Clientes.ToList();
        }

        public Cliente Buscar(int id)
        {
            return database.Clientes.Find(id);
        }

        public void Guardar(Cliente cliente)
        {
            database.Clientes.Add(cliente);
            database.SaveChanges();
        }

        public void Eliminar(Cliente cliente)
        {
            var dato = database.Clientes.Find(cliente.ID);
            database.Clientes.Remove(dato);
            database.SaveChanges();
        }

        public void Actualizar(Cliente cliente)
        {
            var dato = database.Clientes.Find(cliente.ID);
            dato.Nombre = cliente.Nombre;
            dato.RncCedula = cliente.RncCedula;
            dato.Telefono = cliente.Telefono;
            dato.Correo = cliente.Correo;
            dato.Categoria = cliente.Categoria;
            database.SaveChanges();
        }
    }
}
