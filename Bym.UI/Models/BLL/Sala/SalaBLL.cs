using Bym.UI.Models.DAL;
using Bym.UI.Models.DAL.Sala;
using System.Collections.Generic;
using System.Linq;

namespace Bym.UI.Models.BLL.Sala
{
    public class SalaBLL : ICrud<Domain.Sala>
    {
        private IDao<Domain.Sala> SalaDAL;

        public SalaBLL()
        {
            SalaDAL = new SalaDAL();
        }

        public void Alterar(Domain.Sala entidade)
        {
            SalaDAL.Alterar(entidade);
        }

        public void Cadastrar(Domain.Sala entidade)
        {
            SalaDAL.Cadastrar(entidade);
        }

        public Domain.Sala ConsultarPorId(int id)
        {
            return SalaDAL.ConsultarPorId(id);
        }

        public List<Domain.Sala> ConsultarTodos()
        {
            return SalaDAL.ConsultarTodos().ToList();
        }

        public void Excluir(int id)
        {
            SalaDAL.Excluir(id);
        }
    }
}