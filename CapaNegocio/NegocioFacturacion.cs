using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CapaNegocio
{
    public class NegocioFacturacion
    {
        readonly SistemaDeFacturacionEntities database = new SistemaDeFacturacionEntities();

        public List<VistaFacturacion_Result> Mostrar()
        {
            return database.VistaFacturacion().ToList();
        }
        public void Guardar(Facturacion facturacion)
        {
            facturacion.Fecha = DateTime.Now;
            database.Facturacions.Add(facturacion);
            database.SaveChanges();
        }
    }
}
