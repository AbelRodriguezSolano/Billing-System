using CapaEntidad;
using CapaNegocio;
using System.Web.Mvc;

namespace CapaPresentacion.Controllers
{
    public class ProductoController : Controller
    {
        readonly NegocioProducto negocioProducto = new NegocioProducto();
        // GET: Producto
        public ActionResult Index()
        {
            return View(negocioProducto.Mostar());
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        public ActionResult Create(Producto producto)
        {
            try
            {
                // TODO: Add insert logic here

                negocioProducto.Guardar(producto);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(int id)
        {
            var model = negocioProducto.Buscar(id);
            return View(model);
        }

        // POST: Producto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Producto producto)
        {
            try
            {
                // TODO: Add update logic here

                negocioProducto.Actualizar(producto);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Producto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Producto producto)
        {
            try
            {
                // TODO: Add delete logic here

                negocioProducto.Eliminar(producto);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
