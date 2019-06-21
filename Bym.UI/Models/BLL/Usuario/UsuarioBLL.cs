using Bym.UI.Models.DAL.Usuario;

namespace Bym.UI.Models.BLL.Usuario
{
    public class UsuarioBLL : IUsuarioBLL
    {
        private readonly IUsuarioDAL usuarioDAL;

        public UsuarioBLL()
        {
            usuarioDAL = new UsuarioDAL();
        }

        public void Cadastrar(Domain.Usuario usuario)
        {
            usuarioDAL.Cadastrar(usuario);
        }

        public bool Login(Domain.Usuario usuario)
        {
            return usuarioDAL.Login(usuario);
        }

        public Domain.Usuario ConsultarPorId(int id)
        {
            return usuarioDAL.ConsultarPorId(id);
        }

        public Domain.Usuario RetornarDadosUsuario(string login, string senha)
        {
            return usuarioDAL.RetornarDadosUsuario(login, senha);
        }
    }
}