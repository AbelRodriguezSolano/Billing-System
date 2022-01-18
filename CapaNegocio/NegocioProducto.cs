using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class NegocioProducto
    {
        readonly DatoProducto datoProducto = new DatoProducto();

        public List<Producto> Mostar()
        {
            return datoProducto.Mostar();
        }
        public Producto Buscar(int id)
        {
            return datoProducto.Buscar(id);
        }

        public void Guardar(Producto producto)
        {
            datoProducto.Guardar(producto);
        }
        public void Eliminar(Producto producto)
        {
            datoProducto.Eliminar(producto);
        }
        public void Actualizar(Producto producto)
        {
            datoProducto.Actualizar(producto);
        }
    }
}
