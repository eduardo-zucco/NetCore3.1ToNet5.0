using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos.UserCompleto
{
    #nullable enable
    public class UserCompletoFilterDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Uf { get; set; }
        public string? Municipio { get; set; }
        public string? Cep { get; set; }
    }
}