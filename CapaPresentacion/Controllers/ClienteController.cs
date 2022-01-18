using CapaEntidad;
using CapaNegocio;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CapaPresentacion.Controllers
{
    public class ClienteController : Controller
    {
        readonly NegocioCliente negocioCliente = new NegocioCliente();
        // GET: Cliente
        public ActionResult Index()
        {
            return View(negocioCliente.Mostar());
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            var list = negocioCliente.ListaCategoria();

            List<SelectListItem> items = list.ConvertAll(a =>
            {
                return new SelectListItem()
                {
                    Text = a.Nombre,
                    Value = a.ID.ToString(),
                    Selected = true
                };
            });

            ViewBag.items = items;


            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            try
            {
                // TODO: Add insert logic here

                negocioCliente.Guardar(cliente);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            var list = negocioCliente.ListaCategoria();

            List<SelectListItem> items = list.ConvertAll(a =>
            {
                return new SelectListItem()
                {
                    Text = a.Nombre,
                    Value = a.ID.ToString(),
                    Selected = true
                };
            });

            ViewBag.items = items;
            var model = negocioCliente.Buscar(id);

            return View(model);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Cliente cliente)
        {
            try
            {
                // TODO: Add update logic here

                negocioCliente.Actualizar(cliente);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Cliente cliente)
        {
            try
            {
                // TODO: Add delete logic here

                negocioCliente.Eliminar(cliente);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
