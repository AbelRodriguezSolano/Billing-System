using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class NegocioProveedor
    {
        readonly DatoProveedor datoProveedor = new DatoProveedor();

        public List<Proveedore> Mostar()
        {
            return datoProveedor.Mostar();
        }
        public Proveedore Buscar(int id)
        {
            return datoProveedor.Buscar(id);
        }
        public void Guardar(Proveedore proveedore)
        {
            datoProveedor.Guardar(proveedore);
        }
        public void Eliminar(Proveedore proveedore)
        {
            datoProveedor.Eliminar(proveedore);
        }
        public void Actualizar(Proveedore proveedore)
        {
            datoProveedor.Actualizar(proveedore);
        }
    }
}
