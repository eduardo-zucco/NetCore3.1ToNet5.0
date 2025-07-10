using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class UserCompletoEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Uf { get; set; }
        public string Municipio { get; set; }
        public string Cep {get; set; }

    }
}