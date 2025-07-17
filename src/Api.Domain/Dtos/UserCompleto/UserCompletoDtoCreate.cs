using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos.UserCompleto
{
    public class UserCompletoDtoCreate
    {
        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        [StringLength(100, ErrorMessage = "Nome deve ter no máximo {1} caracteres.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email é um campo obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        [StringLength(150, ErrorMessage = "Email deve ter no máximo {1} caracteres.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "UF é campo Obrigatorio")]
        [StringLength(2, ErrorMessage = "UF deve ter no máximo {1} caracteres.")]
        [RegularExpression(@"^[A-Z]{2}$")]
        public string Uf { get; set; }
        [Required(ErrorMessage = "Nome de Município é campo Obrigatorio")]
        [StringLength(100, ErrorMessage = "Nome de Município deve ter no máximo {1} caracteres.")]
        public string Municipio { get; set; }
        [Required(ErrorMessage = "CEP é campo obrigatório")]
        [StringLength(10, ErrorMessage = "CEP deve ter no máximo {1} caracteres")]
        public string Cep { get; set; }
    }
}