using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos
{
    public class MetadataFieldDto
    {
        public string Property { get; set; }
        public bool Key { get; set; }
        public string Label { get; set; }
        public bool Required { get; set; } = false;
        public int GridColumns { get; set; } = 6;
        public int GridSmColumns { get; set; } = 12;
        public string Type { get; set; }
        public int? MaxLength { get; set; }
        public int? MaxValue { get; set; }
        public string ErrorMessage { get; set; } = "Formato Inválido";
        public string Placeholder { get; set; } = string.Empty;
        public string Container { get; set; } = string.Empty;
        public bool ShowRequired { get; set; } = false;
    }
}