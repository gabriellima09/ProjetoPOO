using System.Collections.Generic;
using Bym.UI.Models.BLL;
using Bym.UI.Models.Domain;

namespace Bym.UI.Facade
{
    public class Fachada<T> : IFachada<T>
        where T : EntidadeDominio
    {
        readonly ICrud<T> BLL;

        public Fachada(ICrud<T> _BLL)
        {
            BLL = _BLL;
        }

        public void Alterar(T entidade)
        {
            BLL.Alterar(entidade);
        }

        public void Cadastrar(T entidade)
        {
            BLL.Cadastrar(entidade);
        }

        public T ConsultarPorId(int id)
        {
            return BLL.ConsultarPorId(id);
        }

        public List<T> ConsultarTodos()
        {
            return BLL.ConsultarTodos();
        }

        public void Excluir(int id)
        {
            BLL.Excluir(id);
        }
    }
}