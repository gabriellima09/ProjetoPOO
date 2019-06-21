using Bym.UI.Models.Authentication;
using Bym.UI.Models.BLL.Reserva;
using Bym.UI.Models.BLL.Sala;
using Bym.UI.Models.Domain;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Bym.UI.Controllers
{
    [SessionAuthotize]
    public class ReservaController : Controller
    {
        private readonly ReservaBLL ReservaBLL;
        private readonly SalaBLL salaBLL;

        public ReservaController()
        {
            ReservaBLL = new ReservaBLL();
            salaBLL = new SalaBLL();

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

            List<Sala> salas = salaBLL.ConsultarTodos();
            
            salas.ForEach(x => selectListSalas.Add(new SelectListItem
            {
                Text = x.Descricao,
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
            return View(ReservaBLL.ConsultarTodos());
        }

        // GET: Reserva/Details/5
        public ActionResult Details(int id)
        {
            return View(ReservaBLL.ConsultarPorId(id));
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

                    ReservaBLL.Cadastrar(reserva);

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

        // GET: Reserva/Edit/5
        public ActionResult Edit(int id)
        {
            return View(ReservaBLL.ConsultarPorId(id));
        }

        // POST: Reserva/Edit/5
        [HttpPost]
        public ActionResult Edit(Reserva reserva)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ReservaBLL.Cadastrar(reserva);

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
            return View(ReservaBLL.ConsultarPorId(id));
        }

        // POST: Reserva/Delete/5
        [HttpPost]
        public ActionResult Delete(Reserva reserva)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ReservaBLL.Cadastrar(reserva);

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
