using Bym.UI.Models.Domain;
using System.Collections.Generic;

namespace Bym.UI.Models.BLL
{
    public interface ICrud<T> where T : EntidadeDominio
    {
        void Cadastrar(T entidade);
        void Alterar(T entidade);
        void Excluir(int id);
        T ConsultarPorId(int id);
        List<T> ConsultarTodos();
    }
}
