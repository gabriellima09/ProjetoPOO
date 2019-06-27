using Bym.UI.Facade;
using Bym.UI.Models.Authentication;
using Bym.UI.Models.BLL;
using Bym.UI.Models.BLL.Reserva;
using Bym.UI.Models.BLL.Sala;
using Bym.UI.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Bym.UI.Controllers
{
    [SessionAuthotize]
    public class ReservaController : Controller
    {
        private readonly ICrud<Reserva> ReservaBLL;
        private readonly ICrud<Sala> SalaBLL;
        private readonly IFachada<Reserva> Fachada;
        private readonly IFachada<Sala> SalasFachada;

        public ReservaController()
        {
            ReservaBLL = new ReservaBLL();
            Fachada = new Fachada<Reserva>(ReservaBLL);

            SalaBLL = new SalaBLL();
            SalasFachada = new Fachada<Sala>(SalaBLL);

            CarregarDropDownLists();
        }

        public void CarregarDropDownLists()
        {
            SelectListItem item = new SelectListItem
            {
                Selected = true,
                Text = "Selecione uma opção ...",
                Value = string.Empty,
            };

            List<SelectListItem> selectListSalas = new List<SelectListItem> { item };

            List<Sala> salas = SalasFachada.ConsultarTodos();
            
            salas.ForEach(x => selectListSalas.Add(new SelectListItem
            {
                Text = string.Concat(x.Nome, " - ", x.CapacidadeMaxima, " Lugares - ", x.ValorHora.ToString("C"), "/h"),
                Value = x.Id.ToString()
            }));

            ViewBag.VbSalas = selectListSalas;
        }

        // GET: Reserva
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PV_List()
        {
            return View(Fachada.ConsultarTodos().OrderByDescending(x => x.Id));
        }

        // GET: Reserva/Details/5
        public ActionResult Details(int id)
        {
            return View(Fachada.ConsultarPorId(id));
        }

        // GET: Reserva/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reserva/Create
        [HttpPost]
        public ActionResult Create(Reserva reserva)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    reserva.Usuario = (Usuario)Session["Usuario"];

                    Fachada.Cadastrar(reserva);

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(reserva);
                }
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        // GET: Reserva/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Fachada.ConsultarPorId(id));
        }

        // POST: Reserva/Edit/5
        [HttpPost]
        public ActionResult Edit(Reserva reserva)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    reserva.Usuario = (Usuario)Session["Usuario"];

                    Fachada.Alterar(reserva);

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(reserva);
                }
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Reserva/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Fachada.ConsultarPorId(id));
        }

        // POST: Reserva/Delete/5
        [HttpPost]
        public ActionResult Delete(Reserva reserva)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Fachada.Cadastrar(reserva);

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(reserva);
                }
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
