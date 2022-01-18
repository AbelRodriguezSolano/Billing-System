using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;
using System.Linq;

namespace CapaNegocio
{
    public class NegocioStock
    {
        readonly SistemaDeFacturacionEntities database = new SistemaDeFacturacionEntities();

        public List<VistaStock_Result> Mostrar()
        {
            return database.VistaStock().ToList();
        }
    }
}
