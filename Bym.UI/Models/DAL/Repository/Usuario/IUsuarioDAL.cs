using System.Data;

namespace Bym.UI.Models.DAL.Usuario
{
    public interface IUsuarioDAL
    {
        void Cadastrar(Domain.Usuario usuario);
        bool Login(Domain.Usuario usuario);
        Domain.Usuario ConsultarPorId(int id);
        Domain.Usuario ObterEntidadeReader(IDataReader reader);
    }
}
