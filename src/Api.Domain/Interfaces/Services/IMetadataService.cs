using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos;

namespace Api.Domain.Interfaces.Services
{
    public interface IMetadataService
    {
        Task<MetadataDto> GetMetadataAsync(string entityName);
        Task<PageDynamicTableOptionsDto> GetDynamicOptionsAsync(string entityName);

    }
}