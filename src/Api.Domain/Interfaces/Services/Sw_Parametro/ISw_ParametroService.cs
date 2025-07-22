using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Sw_Parametro;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.Sw_Parametro
{
#nullable enable
    public interface ISw_ParametroService
    {
        Task<Sw_ParametroDto> Get(int id);
        Task<IEnumerable<Sw_ParametroDto>> GetAll();
        Task<Sw_ParametroDtoCreateResult> Create(Sw_ParametroDtoCreate parametro);
        Task<Sw_ParametroDtoUpdateResult> Update(Sw_ParametroDtoUpdate parametro);
        Task<bool> Delete(int id);
        Task<(IEnumerable<Sw_ParametroDto> items, bool hasNext)> GetFiltered(string filter, int page = 1, int pageSize = 10);

        

    }

}
