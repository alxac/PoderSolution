using Data.Contexto;
using Data.Repositorio;
using Dominio;
using Dominio.Entidades;
using Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementacao
{
    public class AnelRepositorio : BaseRepositorio<AnelEntidade>, IAnelRepositorio
    {
        private DbSet<AnelEntidade> table;

        public AnelRepositorio(DBContexto contexto) : base(contexto)
        {
            table = contexto.Set<AnelEntidade>();
        }

        public async Task<string> VerificaTipoAnel(TipoAnel tipoAnel)
        {
            var resultado = string.Empty;
            int contagem = await table.CountAsync(a => a.TipoAnel == tipoAnel);

            switch (tipoAnel)
            {
                case TipoAnel.Elfo:
                    if (contagem >= 3)
                        resultado = "Máximo de 3 anéis para Elfos atingido.";
                    break;

                case TipoAnel.Anao:
                    if (contagem >= 7)
                        resultado = "Máximo de 7 anéis para Anões atingido.";
                    break;

                case TipoAnel.Homem:
                    if (contagem >= 9)
                        resultado = "Máximo de 9 anéis para Homens atingido.";
                    break;

                case TipoAnel.Sauron:
                    if (contagem >= 1)
                        resultado = "Apenas 1 anel é permitido para Sauron.";
                    break;
            }

            return resultado;
        }
    }
}
