using Bym.UI.Models.BLL;
using Bym.UI.Models.Domain;

namespace Bym.UI.Facade
{
    public interface IFachada<T> : ICrud<T> where T : EntidadeDominio
    {
    }
}
