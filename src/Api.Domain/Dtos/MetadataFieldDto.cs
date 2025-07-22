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
        public int GridColumns { get; set; } = 12;
        public string Type { get; set; }
        public int? maxLength { get; set; }
        public int maxValue { get; set; }
    }
}