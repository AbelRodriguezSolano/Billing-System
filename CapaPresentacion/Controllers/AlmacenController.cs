using CapaNegocio;
using System.Web.Mvc;

namespace CapaPresentacion.Controllers
{
    public class AlmacenController : Controller
    {

        NegocioAlmacen negocioAlmacen = new NegocioAlmacen();
        // GET: Almacen
        public ActionResult Index()
        {
            return View(negocioAlmacen.Mostar());
        }
    }
}