using AutoMapper;
using Dominio.DTO;
using Dominio.Entidades;

namespace Dominio.Mapper
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<AnelDTOCreate, AnelEntidade>().ReverseMap();
        }
    }
}
