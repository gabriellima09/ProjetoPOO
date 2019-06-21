using Bym.UI.Models.Authentication;
using Bym.UI.Models.BLL.Sala;
using Bym.UI.Models.Domain;
using System.Web.Mvc;

namespace Bym.UI.Controllers
{
    [SessionAuthotize]
    public class SalaController : Controller
    {
        private readonly SalaBLL SalaBLL;

        public SalaController()
        {
            SalaBLL = new SalaBLL();
        }

        // GET: Sala
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PV_List()
        {
            return View(SalaBLL.ConsultarTodos());
        }

        // GET: Sala/Details/5
        public ActionResult Details(int id)
        {
            return View(SalaBLL.ConsultarPorId(id));
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
                    SalaBLL.Cadastrar(sala);

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
            return View(SalaBLL.ConsultarPorId(id));
        }

        // POST: Sala/Edit/5
        [HttpPost]
        public ActionResult Edit(Sala sala)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SalaBLL.Alterar(sala);

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
            return View(SalaBLL.ConsultarPorId(id));
        }

        // POST: Sala/Delete/5
        [HttpPost]
        public ActionResult Delete(Sala sala)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SalaBLL.Excluir(sala.Id);

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
