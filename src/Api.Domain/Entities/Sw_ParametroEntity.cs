using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable enable
namespace Api.Domain.Entities
{
    [Table("SW_PARAMETRO")]
    public class Sw_ParametroEntity
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [Column("CHAVE")]
        public string? Chave { get; set; }
        [Column("DESCRICAO")]
        [MaxLength(150)]
        public string? Descricao { get; set; }
        [Column("VALOR")]
        public string? Valor { get; set; }
        [Column("VALORINT")]
        public int? ValorInt { get; set; }
        [Column("FILIAL")]
        [MaxLength(4)]
        public string? Filial { get; set; }
        [Column("USUARIO")]
        public int? Usuario { get; set; }
    }
}