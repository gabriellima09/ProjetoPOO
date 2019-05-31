using Bym.UI.Models.BLL.Usuario;
using Bym.UI.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bym.UI.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly GestaoUsuario usuarioBLL;

        public UsuarioController()
        {
            usuarioBLL = new GestaoUsuario();
        }

        // GET: Usuario
        public ActionResult Index()
        {
            return RedirectToAction("Create");
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
