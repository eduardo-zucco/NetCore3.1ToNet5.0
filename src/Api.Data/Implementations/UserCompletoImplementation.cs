using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Dtos.UserCompleto;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class UserCompletoImplementation : BaseRepository<UserCompletoEntity>, IUserCompletoRepository
    {
        private DbSet<UserCompletoEntity> _dataset;
        public UserCompletoImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<UserCompletoEntity>();
        }

        public IQueryable<UserCompletoEntity> GetAllQueryable()
        {
            return _dataset.AsNoTracking();
        }

        public async Task<UserCompletoEntity> GetByEmail(string email)
        {
            return await _dataset.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<(IEnumerable<UserCompletoEntity> items, int totalCount)> SelectWithFilterAsync(string search, int page, int pageSize)
        {
            var query = _dataset.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower();

                query = query.Where(x =>
                    (x.Name != null && x.Name.ToLower().Contains(search)) ||
                    (x.Email != null && x.Email.ToLower().Contains(search)) ||
                    (x.Uf != null && x.Uf.ToLower().Contains(search)) ||
                    (x.Municipio != null && x.Municipio.ToLower().Contains(search)) ||
                    (x.Cep != null && x.Cep.ToLower().Contains(search)) 
                    
                );
            }

            var totalCount = await query.CountAsync();

            var items = await query
            .OrderBy(x => x.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

            return (items, totalCount);
        }
    }
}