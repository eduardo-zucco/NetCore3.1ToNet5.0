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
                version = 1,
                title = "SW_PARAMETROS",
                fields = new List<MetadataFieldDto>
                {
                    new MetadataFieldDto { Property = "chave", Label = "Chave", Required = true, GridColumns = 6, maxLength = 100, Type = "string"},
                    new MetadataFieldDto { Property = "descricao", Label = "Descrição", GridColumns = 6, maxLength = 150, Type = "string"},
                    new MetadataFieldDto { Property = "valor", Label = "Valor", GridColumns = 6, Type = "string", maxLength = 60000 },
                    new MetadataFieldDto { Property = "valorInt", Label = "Valor Int", GridColumns = 6, Type = "number", maxValue = int.MaxValue },
                    new MetadataFieldDto { Property = "filial", Label = "Filial", GridColumns = 6, maxLength = 4, Type = "string"},
                    new MetadataFieldDto { Property = "usuario", Label = "Usuário", GridColumns = 6, maxValue = int.MaxValue, Type = "number" }
                },
                keepFilters = true
            };

        }

        private MetadataDto GetUserCompletoMetadata()
        {
            return new MetadataDto
            {
                version = 1,
                title = "User Completo",
                fields = new List<MetadataFieldDto>
                {
                    new MetadataFieldDto{  Property = "id", Label = "Código", Key = true },
                    new MetadataFieldDto{  Property = "name", Label = "Nome" },
                    new MetadataFieldDto{  Property = "email", Label = "E-mail" },
                    new MetadataFieldDto{  Property = "uf", Label = "UF" },
                    new MetadataFieldDto{  Property = "municipio", Label = "Município"  },
                    new MetadataFieldDto{  Property = "cep", Label = "CEP"  }
                },
                keepFilters = true
            };
        }
    }

}    