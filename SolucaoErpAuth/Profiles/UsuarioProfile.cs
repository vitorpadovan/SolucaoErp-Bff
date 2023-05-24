using AutoMapper;
using SolucaoErpAuth.Data.Dtos;
using SolucaoErpDomain.Model;

namespace SolucaoErpAuth.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDto, Usuario>();
        }
    }
}
