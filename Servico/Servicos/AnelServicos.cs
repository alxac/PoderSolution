using AutoMapper;
using Dominio;
using Dominio.DTO;
using Dominio.Entidades;
using Dominio.Interface;
using Dominio.Repositorio;

namespace Servico.Servicos
{
    public class AnelServicos : IAnelServico
    {
        private IAnelRepositorio _repositorio;
        private readonly IMapper _mapper;

        public AnelServicos(IAnelRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repositorio.DeleteAsync(id);
        }

        public async Task<AnelEntidade> Get(Guid id)
        {
            var entity = await _repositorio.SelectAsync(id);
            return entity;
        }

        public async Task<IEnumerable<AnelEntidade>> GetAll()
        {
            var listEntity = await _repositorio.SelectAsync();
            return listEntity;
        }

        public async Task<AnelEntidade> Post(AnelDTOCreate cep)
        {
            var model = _mapper.Map<AnelEntidade>(cep);
            var result = await _repositorio.InsertAsync(model);

            return result;
        }

        public async Task<AnelEntidade> Put(AnelEntidade cep)
        {
            var result = await _repositorio.UpdateAsync(cep);

            return result;
        }

        public async Task<string> Verifica(TipoAnel tipoAnel)
        {
            var result = await _repositorio.VerificaTipoAnel(tipoAnel);
            return result;
        }
    }
}
