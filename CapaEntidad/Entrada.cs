namespace CapaEntidad
{
    using System.ComponentModel.DataAnnotations;

    public partial class Entrada
    {
        public int ID { get; set; }
        public int Producto { get; set; }
        public int Proveedor { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int Cantidad { get; set; }
        public System.DateTime Fecha { get; set; }

        public virtual Producto Producto1 { get; set; }
        public virtual Proveedore Proveedore { get; set; }
    }
}
