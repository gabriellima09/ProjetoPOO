namespace Bym.UI.Models.BLL.Usuario
{
    public interface IUsuarioBLL
    {
        void Cadastrar(Domain.Usuario usuario);
        bool Login(Domain.Usuario usuario);
        Domain.Usuario ConsultarPorId(int id);
    }
}
