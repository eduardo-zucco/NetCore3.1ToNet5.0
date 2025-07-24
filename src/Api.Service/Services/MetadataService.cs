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
        public MetadataDto GetSwParametroMetadata()
        {
            return new MetadataDto
            {
                Version = 1,
                Title = "TABELA DE PARÂMETROS",
                Fields = new List<MetadataFieldDto>
                {
                    new MetadataFieldDto
                    {
                        Property = "chave",
                        Label = "Chave",
                        Required = true,
                        ShowRequired = true,
                        GridColumns = 6,
                        MaxLength = 100,
                        Type = "string",
                        ErrorMessage = "Campo Requerido",
                        Placeholder = "Digite a chave",
                        Container = "Parâmetros"
                    },
                    new MetadataFieldDto
                    {
                        Property = "descricao",
                        Label = "Descrição",
                        GridColumns = 6,
                        MaxLength = 150,
                        Type = "string",
                        Placeholder = "Digite a descrição"
                    },
                    new MetadataFieldDto
                    {
                        Property = "valor",
                        Label = "Valor",
                        GridColumns = 6,
                        MaxLength = 60000,
                        Type = "string",
                        Placeholder = "Digite o valor"
                    },
                    new MetadataFieldDto
                    {
                        Property = "valorInt",
                        Label = "Valor Int",
                        GridColumns = 6,
                        MaxValue = int.MaxValue,
                        Type = "number",
                        Placeholder = "Insira o valor numérico",   
                    },
                    new MetadataFieldDto
                    {
                        Property = "filial",
                        Label = "Filial",
                        GridColumns = 4,
                        MaxLength = 4,
                        Type = "string",
                        Placeholder = "Digite a filial"
                    },
                    new MetadataFieldDto
                    {
                        Property = "usuario",
                        Label = "Usuário",
                        GridColumns = 6,
                        MaxValue = int.MaxValue,
                        Type = "number",
                        Placeholder = "Insira o número do usuário",
                    }
                },
                KeepFilters = true
            };

        }

        private MetadataDto GetUserCompletoMetadata()
        {
            return new MetadataDto
            {
                Version = 1,
                Title = "USER COMPLETO",
                Fields = new List<MetadataFieldDto>
                {
                    new MetadataFieldDto{  Property = "id", Label = "Código", Key = true },
                    new MetadataFieldDto{  Property = "name", Label = "Nome" },
                    new MetadataFieldDto{  Property = "email", Label = "E-mail" },
                    new MetadataFieldDto{  Property = "uf", Label = "UF" },
                    new MetadataFieldDto{  Property = "municipio", Label = "Município" },
                    new MetadataFieldDto{  Property = "cep", Label = "CEP"  }
                },
                KeepFilters = true
            };
        }
    }

}