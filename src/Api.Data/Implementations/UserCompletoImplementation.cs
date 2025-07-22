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
    }
}