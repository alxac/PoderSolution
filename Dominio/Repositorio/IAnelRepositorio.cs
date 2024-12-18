using Dominio.Entidades;
using Dominio.Interface;

namespace Dominio.Repositorio
{
    public interface IAnelRepositorio : IRepositorio<AnelEntidade>
    {
        Task<string> VerificaTipoAnel(TipoAnel tipoAnel);
    }
}
