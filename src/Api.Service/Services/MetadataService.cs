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
        public async Task<PageDynamicTableOptionsDto> GetDynamicOptionsAsync(string entityName)
        {
            var metadata = await GetMetadataAsync(entityName);

            return new PageDynamicTableOptionsDto
            {
                Title = metadata.Title,
                ServiceApi = metadata.ServiceApi,
                KeepFilters = metadata.KeepFilters,
                Fields = metadata.Fields,
                Actions = metadata.Actions ?? new PageDynamicTableActionDto(),
                CustomActions = metadata.CustomActions

            };
        }


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
                Version = 3,
                Title = "TABELA DE PARÂMETROS",
                ServiceApi = "http://localhost:5000/api/sw_parametros",
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
                        Container = "Parâmetros",
                        Order = 1,
                    },
                    new MetadataFieldDto
                    {
                        Property = "descricao",
                        Label = "Descrição",
                        GridColumns = 6,
                        MaxLength = 150,
                        Type = "string",
                        Placeholder = "Digite a descrição",
                        Order = 2,
                    },
                    new MetadataFieldDto
                    {
                        Property = "filial",
                        Label = "Filial",
                        GridColumns = 6,
                        MaxLength = 4,
                        Type = "string",
                        Placeholder = "Digite a filial",
                        Order = 3,
                    },
                    new MetadataFieldDto
                    {
                        Property = "valor",
                        Label = "Valor",
                        GridColumns = 6,
                        MaxLength = 60000,
                        Type = "string",
                        Placeholder = "Digite o valor",
                        Order = 4,
                    },
                    new MetadataFieldDto
                    {
                        Property = "valorInt",
                        Label = "Valor Int",
                        GridColumns = 6,
                        MaxValue = int.MaxValue,
                        Type = "number",
                        Placeholder = "Insira o valor numérico",
                        Order = 5,
                    },
                    new MetadataFieldDto
                    {
                        Property = "usuario",
                        Label = "Usuário",
                        GridColumns = 6,
                        MaxValue = int.MaxValue,
                        Type = "number",
                        Placeholder = "Insira o número do usuário",
                        Order = 6,
                    },
                    new MetadataFieldDto
                    {
                        Property = "id",
                        Label = "ID",
                        Visible = false,
                        Key = true,
                        Order = 7,
                    },
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
                ServiceApi = "http://localhost:5000/api/usercompletos",
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