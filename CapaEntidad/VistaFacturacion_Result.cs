namespace CapaEntidad
{
    using System;

    public partial class VistaFacturacion_Result
    {
        public int ID { get; set; }
        public string Cliente { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public System.DateTime Fecha { get; set; }
        public Nullable<decimal> SubTotal { get; set; }
        public Nullable<decimal> Total { get; set; }
    }
}
