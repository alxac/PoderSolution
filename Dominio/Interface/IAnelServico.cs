using Dominio.DTO;
using Dominio.Entidades;

namespace Dominio.Interface
{
    public interface IAnelServico
    {
        Task<AnelEntidade> Get(Guid id);
        Task<IEnumerable<AnelEntidade>> GetAll();
        Task<AnelEntidade> Post(AnelDTOCreate cep);
        Task<AnelEntidade> Put(AnelEntidade cep);
        Task<bool> Delete(Guid id);
        Task<string> Verifica(TipoAnel tipoAnel);
    }
}
