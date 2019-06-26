using Bym.UI.Models.BLL.Usuario;
using Bym.UI.Models.Domain;
using Bym.UI.Models.Report;
using System;
using System.Net;
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
            Dashboard dashboard = new Dashboard
            {
                TotalReservas = 5,
                TotalSalas = 12,
                ValorArrecadado = 50.35M,
                SalaMaiorCapacidade = "Sala Teste",
                UltimaReserva = new Reserva
                {
                    Id = 1,
                    DataHora = DateTime.Now,
                    HorasReservadas = 2,
                    Sala = new Sala
                    {
                        Id = 1,
                        CapacidadeMaxima = 5,
                        Descricao = "Daora",
                        Nome = "Sala Teste",
                        ValorHora = 15.70M,
                        Endereco = new Endereco
                        {
                            Logradouro = "Rua A",
                            Numero = "100",
                            Complemento = "Casa"
                        }
                    },
                    Usuario = new Usuario
                    {
                        Login = "Gabriel"
                    }
                },
                UltimaSalaCadastrada = new Sala
                {
                    Id = 1,
                    CapacidadeMaxima = 5,
                    Descricao = "Daora",
                    Nome = "Sala Teste",
                    ValorHora = 15.70M,
                    Endereco = new Endereco
                    {
                        Logradouro = "Rua A",
                        Numero = "100",
                        Complemento = "Casa"
                    }
                }
            };

            return View(dashboard);
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

                    usuario = usuarioBLL.RetornarDadosUsuario(usuario.Login, usuario.Senha);

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

        [HttpPost]
        public ActionResult Report(Dashboard dashboard)
        {
            new Relatorio(dashboard);

            return RedirectToAction("Index");
        }
    }
}
