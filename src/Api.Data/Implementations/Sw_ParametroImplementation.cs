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
    }


}