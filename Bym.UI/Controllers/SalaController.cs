using Bym.UI.Facade;
using Bym.UI.Models.Authentication;
using Bym.UI.Models.BLL;
using Bym.UI.Models.BLL.Sala;
using Bym.UI.Models.Domain;
using System.Linq;
using System.Web.Mvc;

namespace Bym.UI.Controllers
{
    [SessionAuthotize]
    public class SalaController : Controller
    {
        private readonly ICrud<Sala> SalaBLL;
        private readonly IFachada<Sala> Fachada;

        public SalaController()
        {
            SalaBLL = new SalaBLL();
            Fachada = new Fachada<Sala>(SalaBLL);
        }

        // GET: Sala
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PV_List()
        {
            return View(Fachada.ConsultarTodos().OrderByDescending(x => x.Id));
        }

        // GET: Sala/Details/5
        public ActionResult Details(int id)
        {
            return View(Fachada.ConsultarPorId(id));
        }

        // GET: Sala/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sala/Create
        [HttpPost]
        public ActionResult Create(Sala sala)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Fachada.Cadastrar(sala);

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(sala);
                }
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Sala/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Fachada.ConsultarPorId(id));
        }

        // POST: Sala/Edit/5
        [HttpPost]
        public ActionResult Edit(Sala sala)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Fachada.Alterar(sala);

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(sala);
                }
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Sala/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Fachada.ConsultarPorId(id));
        }

        // POST: Sala/Delete/5
        [HttpPost]
        public ActionResult Delete(Sala sala)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Fachada.Excluir(sala.Id);

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(sala);
                }
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
