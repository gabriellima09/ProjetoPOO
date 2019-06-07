using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bym.UI.Models.DAL
{
    public interface IDao<T>
    {
        void Salvar();
        void Alterar();
        void Excluir();
        IList<T> Consultar();
        IList<T> ConsultarPorId(int id);
    }
}
