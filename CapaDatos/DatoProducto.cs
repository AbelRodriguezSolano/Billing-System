using CapaEntidad;
using System.Collections.Generic;
using System.Linq;

namespace CapaDatos
{
    public class DatoProducto
    {
        readonly SistemaDeFacturacionEntities database = new SistemaDeFacturacionEntities();

        public List<Producto> Mostar()
        {
            return database.Productos.ToList();
        }

        public Producto Buscar(int id)
        {
            return database.Productos.Find(id);
        }

        public void Guardar(Producto producto)
        {
            database.Productos.Add(producto);
            database.SaveChanges();
        }

        public void Eliminar(Producto producto)
        {
            var dato = database.Productos.Find(producto.ID);
            database.Productos.Remove(dato);
            database.SaveChanges();
        }

        public void Actualizar(Producto producto)
        {
            var dato = database.Productos.Find(producto.ID);
            dato.Nombre = producto.Nombre;
            dato.Precio = producto.Precio;
            database.SaveChanges();
        }
    }
}
