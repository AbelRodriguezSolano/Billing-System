namespace CapaEntidad
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Facturacion
    {
        public int ID { get; set; }
        public int Cliente { get; set; }
        public int Producto { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int Cantidad { get; set; }
        public System.DateTime Fecha { get; set; }
        public Nullable<decimal> SubTotal { get; set; }
        public Nullable<decimal> Total { get; set; }

        public virtual Cliente Cliente1 { get; set; }
        public virtual Producto Producto1 { get; set; }
    }
}
