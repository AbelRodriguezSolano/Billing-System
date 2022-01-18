using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CapaNegocio
{
    public class NegocioEntradas
    {
        readonly SistemaDeFacturacionEntities database = new SistemaDeFacturacionEntities();

        public List<VistaEntradas_Result> Mostrar()
        {
            return database.VistaEntradas().ToList();
        }

        public void Guardar(Entrada entrada)
        {
            entrada.Fecha = DateTime.Now;
            database.Entradas.Add(entrada);
            database.SaveChanges();
        }

    }
}
