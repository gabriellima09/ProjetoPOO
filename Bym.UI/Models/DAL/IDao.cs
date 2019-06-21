using Bym.UI.Models.Domain;
using System.Collections.Generic;
using System.Data;

namespace Bym.UI.Models.DAL
{
    public interface IDao<T> where T : EntidadeDominio
    {
        void Cadastrar(T entidade);
        void Alterar(T entidade);
        void Excluir(int id);
        IList<T> ConsultarTodos();
        T ConsultarPorId(int id);
        T ObterEntidadeReader(IDataReader reader);
    }
}
