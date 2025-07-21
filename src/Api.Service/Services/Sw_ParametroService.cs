using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Sw_Parametro;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Sw_Parametro;
using Api.Domain.Models;
using Api.Domain.Repository;
using AutoMapper;

namespace Api.Service.Services
{
    public class Sw_ParametroService : ISw_ParametroService
    {
        private ISw_ParametroRepository _repository;
        private readonly IMapper _mapper;

        public Sw_ParametroService(ISw_ParametroRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<Sw_ParametroDto> Get(int id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<Sw_ParametroDto>(entity);
        }

        public async Task<IEnumerable<Sw_ParametroDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<Sw_ParametroDto>>(listEntity);
        }

        public Task<(IEnumerable<Sw_ParametroDto> items, bool hasNext)> GetFiltered(string search = null, string chave = null, string valor = null, string valorInt = null, string filial = null, string Usuario = null, int page = 1, int pageSize = 10)
        {
            throw new NotImplementedException();
        }

        public async Task<Sw_ParametroDtoCreateResult> Post(Sw_ParametroDtoCreate parametro)
        {
            var model = _mapper.Map<Sw_ParametroModel>(parametro);
            var entity = _mapper.Map<Sw_ParametroEntity>(model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<Sw_ParametroDtoCreateResult>(result);
        }

        public async Task<Sw_ParametroDtoUpdateResult> Put(Sw_ParametroDtoUpdate parametro)
        {
            var model = _mapper.Map<Sw_ParametroModel>(parametro);
            var entity = _mapper.Map<Sw_ParametroEntity>(model);

            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<Sw_ParametroDtoUpdateResult>(result);
        }

        public async Task<Sw_ParametroDtoCreateResult> Create(Sw_ParametroDtoCreate parametro)
        {

            var model = _mapper.Map<Sw_ParametroModel>(parametro);
            var entity = _mapper.Map<Sw_ParametroEntity>(model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<Sw_ParametroDtoCreateResult>(result);
        }

        public async Task<Sw_ParametroDtoUpdateResult> Update(Sw_ParametroDtoUpdate parametro)
        {
            var model = _mapper.Map<Sw_ParametroModel>(parametro);
            var entity = _mapper.Map<Sw_ParametroEntity>(model);

            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<Sw_ParametroDtoUpdateResult>(result);
        }
    }


}