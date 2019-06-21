using Bym.UI.Models.BLL.Usuario;
using Bym.UI.Models.Domain;
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
        public ActionResult Index()
        {
            return RedirectToAction("Create");
        }

        public ActionResult RetornarUsuarioSessao()
        {
            string nome = string.Empty;

            if (Session["Usuario"] != null)
            {
                nome = ((Usuario)Session["Usuario"]).Login;
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
                
                return RedirectToAction("Index", "Home");
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

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            return View();
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

                    Session.Add("Usuario", usuario);

                    return RedirectToAction("Index", "Home"); 
                }
                else
                {
                    return View(usuario);
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(Usuario usuario)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(Usuario usuario)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
