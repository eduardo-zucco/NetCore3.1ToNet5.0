using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Interfaces.Services;

namespace Api.Service.Services
{
    public class MetadataService : IMetadataService
    {
        public async Task<MetadataDto> GetMetadataAsync(string entityName)
        {
            return entityName.ToLower() switch
            {
                "sw_parametros" => await Task.FromResult(GetSwParametroMetadata()),
                "usercompletos" => await Task.FromResult(GetUserCompletoMetadata()),
                _ => throw new KeyNotFoundException("Entidade não encontrada.")
            };
        }
        private MetadataDto GetSwParametroMetadata()
        {
            return new MetadataDto
            {
                serviceApi = "/api/sw_parametros",
                Fields = new List<MetadataFieldDto>
                {
                    new MetadataFieldDto { Property = "chave", Label = "Chave", Required = true, GridColumns = 6 },
                    new MetadataFieldDto { Property = "valor", Label = "Valor", GridColumns = 6 },
                    new MetadataFieldDto { Property = "valorInt", Label = "Valor Int", GridColumns = 6 },
                    new MetadataFieldDto { Property = "filial", Label = "Filial", GridColumns = 6 }
                }


            };

        }

        private MetadataDto GetUserCompletoMetadata()
        {
            return new MetadataDto
            {
                serviceApi = "/api/usercompletos",
                Fields = new List<MetadataFieldDto>
                {
                    new MetadataFieldDto{  Property = "id", Label = "Código", Key = true },
                    new MetadataFieldDto{  Property = "name", Label = "Nome",  },
                    new MetadataFieldDto{  Property = "email", Label = "E-mail", },
                    new MetadataFieldDto{  Property = "uf", Label = "UF",  },
                    new MetadataFieldDto{  Property = "municipio", Label = "Município",  },
                    new MetadataFieldDto{  Property = "cep", Label = "CEP",  }
                }
            };
        }
    }

}    