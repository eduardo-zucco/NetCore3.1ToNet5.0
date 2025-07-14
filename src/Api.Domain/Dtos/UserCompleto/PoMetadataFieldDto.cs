using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos.UserCompleto
{
    public class PoMetadataFieldDto
    {
        public string Property { get; set; }
        public string Label { get; set; }
        public bool Required { get; set; }
        public bool Disabled { get; set; }
        public bool Key { get; set; }
        public bool Visible { get; set; } = true;

    }
}