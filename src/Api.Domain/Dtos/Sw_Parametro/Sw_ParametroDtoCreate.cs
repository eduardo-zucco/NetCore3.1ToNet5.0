using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos.Sw_Parametro
{
    #nullable enable
    public class Sw_ParametroDtoCreate
    {
        [Required(ErrorMessage = "Chave é campo obrigatório.")]
        [StringLength(100)]
        [Column("CHAVE")]
        public string? Chave { get; set; }
        [Column("DESCRICAO")]
        [StringLength(150)]
        public string? Descricao { get; set; }
        [Column("VALOR")]
        public string? Valor { get; set; }
        [Column("VALORINT")]
        public int? ValorInt { get; set; }
        [Column("FILIAL")]
        [StringLength(4)]
        public string? Filial { get; set; }
        [Column("USUARIO")]
        public int? Usuario { get; set; }
    }
}