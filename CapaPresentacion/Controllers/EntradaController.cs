using CapaEntidad;
using CapaNegocio;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CapaPresentacion.Controllers
{
    public class EntradaController : Controller
    {
        readonly NegocioEntradas negocioEntradas = new NegocioEntradas();

        readonly NegocioProducto negocioProducto = new NegocioProducto();

        readonly NegocioProveedor negocioProveedor = new NegocioProveedor();

        // GET: Entrada
        public ActionResult Index()
        {
            return View(negocioEntradas.Mostrar());
        }

        // GET: Entrada/Create
        public ActionResult Create()
        {
            var listPro = negocioProducto.Mostar();

            var listProve = negocioProveedor.Mostar();

            List<SelectListItem> itemsPro = listPro.ConvertAll(a =>
            {
                return new SelectListItem()
                {
                    Text = a.Nombre,
                    Value = a.ID.ToString(),
                    Selected = true
                };
            });

            List<SelectListItem> itemsProve = listProve.ConvertAll(a =>
            {
                return new SelectListItem()
                {
                    Text = a.Nombre,
                    Value = a.ID.ToString(),
                    Selected = true
                };
            });

            ViewBag.itemsPro = itemsPro;
            ViewBag.itemsProve = itemsProve;
            return View();
        }

        // POST: Entrada/Create
        [HttpPost]
        public ActionResult Create(Entrada entrada)
        {
            try
            {
                // TODO: Add insert logic here

                negocioEntradas.Guardar(entrada);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
