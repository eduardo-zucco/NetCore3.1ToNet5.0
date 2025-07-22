using Api.Domain.Dtos.Cep;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Dtos.Sw_Parametro;
using Api.Domain.Dtos.Uf;
using Api.Domain.Dtos.User;
using Api.Domain.Dtos.UserCompleto;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            #region User
            CreateMap<UserModel, UserDto>()
                .ReverseMap();
            CreateMap<UserModel, UserDtoCreate>()
                .ReverseMap();
            CreateMap<UserModel, UserDtoUpdate>()
                .ReverseMap();
            #endregion

            #region UF
            CreateMap<UfModel, UfDto>()
                .ReverseMap();
            #endregion

            #region Municipio
            CreateMap<MunicipioModel, MunicipioDto>()
                .ReverseMap();
            CreateMap<MunicipioModel, MunicipioDtoCreate>()
                .ReverseMap();
            CreateMap<MunicipioModel, MunicipioDtoUpdate>()
                .ReverseMap();
            #endregion

            #region CEP
            CreateMap<CepModel, CepDto>()
                .ReverseMap();
            CreateMap<CepModel, CepDtoCreate>()
                .ReverseMap();
            CreateMap<CepModel, CepDtoUpdate>()
                .ReverseMap();
            #endregion

            CreateMap<UserCompletoModel, UserCompletoDto>()
                .ReverseMap();
            CreateMap<UserCompletoModel, UserCompletoDtoCreate>()
                .ReverseMap();
            CreateMap<UserCompletoModel, UserCompletoDtoUpdate>()
                .ReverseMap();


            CreateMap<Sw_ParametroModel, Sw_ParametroDto>()
                .ReverseMap();
            CreateMap<Sw_ParametroModel, Sw_ParametroDtoCreate>()
                .ReverseMap();
            CreateMap<Sw_ParametroModel, Sw_ParametroDtoUpdate>()
                .ReverseMap();

        }

    }
}
