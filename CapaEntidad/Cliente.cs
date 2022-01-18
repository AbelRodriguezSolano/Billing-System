namespace CapaEntidad
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cliente()
        {
            this.Facturacions = new HashSet<Facturacion>();
        }

        public int ID { get; set; }

        [MinLength(11, ErrorMessage = "Debe contener minimo 11 digitos.")]
        [StringLength(13, ErrorMessage = "Solo puede contener 13 digitos.")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Display(Name = "RNC o Cedula")]
        public string RncCedula { get; set; }

        [MinLength(4, ErrorMessage = "Debe contener minimo 4 digitos.")]
        [StringLength(25, ErrorMessage = "Solo puede contener 25 digitos.")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Nombre { get; set; }

        [MinLength(10, ErrorMessage = "Debe contener minimo 10 digitos.")]
        [StringLength(12, ErrorMessage = "Solo puede contener 12 digitos.")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Telefono { get; set; }

        [RegularExpression(@"^[_a-z0-9-]+(.[_a-z0-9-]+)*\@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$", ErrorMessage = "Verifique el correo electronico.")]
        public string Correo { get; set; }
        public int Categoria { get; set; }

        public virtual Categoria Categoria1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Facturacion> Facturacions { get; set; }
    }
}
