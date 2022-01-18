namespace CapaDatos
{
    using CapaEntidad;
    using System.Data.Entity;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;

    public partial class SistemaDeFacturacionEntities : DbContext
    {
        public SistemaDeFacturacionEntities()
            : base("name=SistemaDeFacturacionEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Proveedore> Proveedores { get; set; }
        public virtual DbSet<Entrada> Entradas { get; set; }
        public virtual DbSet<Facturacion> Facturacions { get; set; }

        public virtual ObjectResult<VistaEntradas_Result> VistaEntradas()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<VistaEntradas_Result>("VistaEntradas");
        }

        public virtual ObjectResult<VistaFacturacion_Result> VistaFacturacion()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<VistaFacturacion_Result>("VistaFacturacion");
        }

        public virtual ObjectResult<VistaStock_Result> VistaStock()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<VistaStock_Result>("VistaStock");
        }

        public virtual ObjectResult<VistaClientes_Result> VistaClientes()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<VistaClientes_Result>("VistaClientes");
        }
    }
}
