using CapaEntidad;
using System.Collections.Generic;
using System.Linq;

namespace CapaDatos
{
    public class DatoProveedor
    {
        readonly SistemaDeFacturacionEntities database = new SistemaDeFacturacionEntities();

        public List<Proveedore> Mostar()
        {
            return database.Proveedores.ToList();
        }

        public Proveedore Buscar(int id)
        {
            return database.Proveedores.Find(id);
        }
        public void Guardar(Proveedore proveedore)
        {
            database.Proveedores.Add(proveedore);
            database.SaveChanges();
        }

        public void Eliminar(Proveedore proveedore)
        {
            var dato = database.Proveedores.Find(proveedore.ID);
            database.Proveedores.Remove(dato);
            database.SaveChanges();
        }

        public void Actualizar(Proveedore proveedore)
        {
            var dato = database.Proveedores.Find(proveedore.ID);
            dato.Nombre = proveedore.Nombre;
            dato.RncCedula = proveedore.RncCedula;
            dato.Telefono = proveedore.Telefono;
            dato.Correo = proveedore.Correo;
            database.SaveChanges();
        }
    }
}
