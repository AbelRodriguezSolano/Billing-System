namespace CapaEntidad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Producto()
        {
            this.Entradas = new HashSet<Entrada>();
            this.Facturacions = new HashSet<Facturacion>();
        }

        public int ID { get; set; }

        [MinLength(4, ErrorMessage = "Debe contener minimo 4 digitos.")]
        [StringLength(25, ErrorMessage = "Solo puede contener 25 digitos.")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public decimal Precio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Entrada> Entradas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Facturacion> Facturacions { get; set; }
    }
}
