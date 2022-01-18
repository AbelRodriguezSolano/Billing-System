using CapaEntidad;
using CapaNegocio;
using System.Web.Mvc;

namespace CapaPresentacion.Controllers
{
    public class ProveedorController : Controller
    {
        readonly NegocioProveedor negocioProveedor = new NegocioProveedor();
        // GET: Proveedor
        public ActionResult Index()
        {
            return View(negocioProveedor.Mostar());
        }

        // GET: Proveedor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proveedor/Create
        [HttpPost]
        public ActionResult Create(Proveedore proveedore)
        {
            try
            {
                // TODO: Add insert logic here

                negocioProveedor.Guardar(proveedore);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Proveedor/Edit/5
        public ActionResult Edit(int id)
        {
            var model = negocioProveedor.Buscar(id);
            return View(model);
        }

        // POST: Proveedor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Proveedore proveedore)
        {
            try
            {
                // TODO: Add update logic here

                negocioProveedor.Actualizar(proveedore);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Proveedor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Proveedor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Proveedore proveedore)
        {
            try
            {
                // TODO: Add delete logic here

                negocioProveedor.Eliminar(proveedore);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
