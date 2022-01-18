using CapaEntidad;
using CapaNegocio;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CapaPresentacion.Controllers
{
    public class FacturacionController : Controller
    {
        readonly NegocioFacturacion negocioFacturacion = new NegocioFacturacion();

        readonly NegocioCliente negocioCliente = new NegocioCliente();
        readonly NegocioProducto negocioProducto = new NegocioProducto();

        // GET: Facturacion
        public ActionResult Index()
        {
            return View(negocioFacturacion.Mostrar());
        }

        // GET: Facturacion/Create
        public ActionResult Create()
        {
            var listCli = negocioCliente.Mostar();
            var listPro = negocioProducto.Mostar();

            List<SelectListItem> itemsCli = listCli.ConvertAll(a =>
            {
                return new SelectListItem()
                {
                    Text = a.Nombre,
                    Value = a.ID.ToString(),
                    Selected = true
                };
            });

            List<SelectListItem> itemsPro = listPro.ConvertAll(a =>
            {
                return new SelectListItem()
                {
                    Text = a.Nombre,
                    Value = a.ID.ToString(),
                    Selected = true
                };
            });

            ViewBag.itemsCli = itemsCli;
            ViewBag.itemsPro = itemsPro;
            return View();
        }

        // POST: Facturacion/Create
        [HttpPost]
        public ActionResult Create(Facturacion facturacion)
        {
            try
            {
                // TODO: Add insert logic here

                negocioFacturacion.Guardar(facturacion);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
