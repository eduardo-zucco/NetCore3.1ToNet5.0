using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class Sw_ParametroImplementation : BaseSwRepository<Sw_ParametroEntity>, ISw_ParametroRepository
    {
        private DbSet<Sw_ParametroEntity> _dataSet;
        public Sw_ParametroImplementation(MyContext context) : base(context)
        {
            _dataSet = context.Set<Sw_ParametroEntity>();
        }

        public async Task<(IEnumerable<Sw_ParametroEntity> items, int totalCount)> SelectWithFilterAsync(string filter, int page, int pageSize)
        {
            var query = _dataSet.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter))
            {
                filter = filter.ToLower();

                query = query.Where(x =>
                    (x.Chave != null && x.Chave.ToLower().Contains(filter)) ||
                    (x.Descricao != null && x.Descricao.ToLower().Contains(filter)) ||
                    (x.Valor != null && x.Valor.ToLower().Contains(filter)) ||
                    (x.Filial != null && x.Filial.ToLower().Contains(filter)) ||
                    x.ValorInt.ToString().Contains(filter) ||
                    x.Usuario.ToString().Contains(filter)
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