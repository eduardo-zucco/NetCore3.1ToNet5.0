using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos.Sw_Parametro
{
    #nullable enable
    public class Sw_ParametroDtoCreateResult
    {
        public int Id { get; set; }
        public string? Chave { get; set; }
        public string? Descricao { get; set; }
        public string? Valor { get; set; }
        public int? ValorInt { get; set; }
        public string? Filial { get; set; }
        public int? Usuario { get; set; }
    }
}