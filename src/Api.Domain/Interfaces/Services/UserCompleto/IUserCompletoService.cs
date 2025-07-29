using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.UserCompleto;

namespace Api.Domain.Interfaces.Services.UserCompleto
{
#nullable enable
    public interface IUserCompletoService
    {
        Task<UserCompletoDto> Get(Guid id);
        Task<IEnumerable<UserCompletoDto>> GetAll();
        Task<UserCompletoDtoCreateResult> Post(UserCompletoDtoCreate user);
        Task<UserCompletoDtoUpdateResult> Put(UserCompletoDtoUpdate user);
        Task<bool> Delete(Guid id);
        Task<UserCompletoDto> GetByEmail(string email);
        /*Task<(IEnumerable<UserCompletoDto> items, bool hasNext)> GetFiltered(
            string? search = null,
            string? name = null,
            string? email = null,
            string? uf = null,
            string? municipio = null,
            string? cep = null,
            int page = 1,
            int pageSize = 10);*/
            
        Task<(IEnumerable<UserCompletoDto> items, bool hasNext)> GetFiltered(string search, int page = 1, int pageSize = 10);
    }

}