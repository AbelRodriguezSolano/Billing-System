using CapaEntidad;
using System.Collections.Generic;
using System.Linq;

namespace CapaDatos
{
    public class DatoCategoria
    {
        readonly SistemaDeFacturacionEntities database = new SistemaDeFacturacionEntities();
        public List<Categoria> ListaCategoria()
        {
            return database.Categorias.ToList();
        }
    }
}
