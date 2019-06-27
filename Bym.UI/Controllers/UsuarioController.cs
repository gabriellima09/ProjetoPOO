using Bym.UI.Models.Authentication;
using Bym.UI.Models.BLL.Dashboard;
using Bym.UI.Models.BLL.Usuario;
using Bym.UI.Models.Domain;
using Bym.UI.Models.Report;
using System;
using System.Web.Mvc;

namespace Bym.UI.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioBLL usuarioBLL;

        public UsuarioController()
        {
            usuarioBLL = new UsuarioBLL();
        }

        // GET: Usuario
        [SessionAuthotize]
        public ActionResult Index()
        {
            return View("Dashboard", new DashboardBLL().RetornarDashboard());
        }

        [SessionAuthotize]
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult RetornarUsuarioSessao()
        {
            string nome = string.Empty;

            if (Session["Usuario"] != null)
            {
                nome = ((Usuario)Session["Usuario"]).Nome;
            }
                
            ViewBag.NomeUsuario = nome;

            return PartialView("PV_Usuario");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            if (usuarioBLL.Login(usuario))
            {
                Session.Add("Usuario", usuarioBLL.RetornarDadosUsuario(usuario.Login, usuario.Senha));
                
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Usuário não encontrado ...");

                return View(usuario);
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();

            return RedirectToAction("Index", "Home");
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuarioBLL.Cadastrar(usuario);

                    usuario = usuarioBLL.RetornarDadosUsuario(usuario.Login, usuario.Senha);

                    Session.Add("Usuario", usuario);

                    return RedirectToAction("Index"); 
                }
                else
                {
                    return View(usuario);
                }
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpPost]
        [SessionAuthotize]
        public ActionResult Report(Dashboard dashboard)
        {
            new Relatorio(dashboard).GerarRelatorio();

            return RedirectToAction("Index");
        }
    }
}
