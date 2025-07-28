using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.UserCompleto;
using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Domain.Repository
{
    public interface IUserCompletoRepository : IRepository<UserCompletoEntity>
    {
        Task<UserCompletoEntity> GetByEmail(string email);
        IQueryable<UserCompletoEntity> GetAllQueryable();
        Task<(IEnumerable<UserCompletoEntity> items, int totalCount)> SelectWithFilterAsync(string search, int page, int pageSize);

        
    }
}