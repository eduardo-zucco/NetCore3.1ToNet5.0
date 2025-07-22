using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.UserCompleto;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.UserCompleto;
using Api.Domain.Models;
using Api.Domain.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Api.Service.Services
{
    public class UserCompletoService : IUserCompletoService
    {

        private IUserCompletoRepository _repository;
        private readonly IMapper _mapper;

        public UserCompletoService(IUserCompletoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<UserCompletoDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<UserCompletoDto>(entity);
        }

        public async Task<IEnumerable<UserCompletoDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<UserCompletoDto>>(listEntity);
        }
        public async Task<UserCompletoDto> GetByEmail(string email)
        {
            var entity = await _repository.FindByConditionAsync(u => u.Email == email);

            if (entity == null)
                return null;

            return _mapper.Map<UserCompletoDto>(entity);
        }


        public async Task<UserCompletoDtoCreateResult> Post(UserCompletoDtoCreate user)
        {
            var model = _mapper.Map<UserCompletoModel>(user);
            var entity = _mapper.Map<UserCompletoEntity>(model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<UserCompletoDtoCreateResult>(result);
        }

        public async Task<UserCompletoDtoUpdateResult> Put(UserCompletoDtoUpdate user)
        {
            var model = _mapper.Map<UserCompletoModel>(user);
            var entity = _mapper.Map<UserCompletoEntity>(model);

            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<UserCompletoDtoUpdateResult>(result);
        }

        public async Task<(IEnumerable<UserCompletoDto> items, bool hasNext)> GetFiltered(string? search = null, string? name = null, string? email = null, string? uf = null, string? municipio = null, string? cep = null, int page = 1, int pageSize = 10)
        {
            var query = _repository.GetAllQueryable(); // IQueryable<User>

            if (!string.IsNullOrEmpty(search))
                query = query.Where(u => u.Name.Contains(search));

            if (!string.IsNullOrEmpty(name))
                query = query.Where(u => u.Name.Contains(name));

            if (!string.IsNullOrEmpty(email))
                query = query.Where(u => u.Email.Contains(email));

            if (!string.IsNullOrEmpty(uf))
                query = query.Where(u => u.Uf.Contains(uf));

            if (!string.IsNullOrEmpty(municipio))
                query = query.Where(u => u.Municipio.Contains(municipio));

            if (!string.IsNullOrEmpty(cep))
                query = query.Where(u => u.Cep.Contains(cep));

            var total = await query.CountAsync();

            var paged = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var dtos = _mapper.Map<IEnumerable<UserCompletoDto>>(paged);

            return (dtos, total > page * pageSize);
        }

    }
}