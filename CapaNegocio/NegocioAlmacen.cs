using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;
using System.Linq;

namespace CapaNegocio
{
    public class NegocioAlmacen
    {
        SistemaDeFacturacionEntities database = new SistemaDeFacturacionEntities();

        public List<VistaStock_Result> Mostar()
        {
            return database.VistaStock().ToList();
        }
    }
}
