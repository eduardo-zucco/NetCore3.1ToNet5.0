using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class UserCompletoEntity : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(150)]
        public string Email { get; set; }
        [Required]
        [MaxLength(2)]
        public string Uf { get; set; }
        [Required]
        [MaxLength(100)]
        public string Municipio { get; set; }
        [Required]
        [MaxLength(10)]
        public string Cep { get; set; }

    }
}