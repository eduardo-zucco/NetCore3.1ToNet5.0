using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos.UserCompleto
{
    public class PoPageDynamicEditMetadataDto
    {
        public int Version { get; set; }
        public string Title { get; set; }
        public IEnumerable<PoMetadataFieldDto> Fields { get; set; }
    }
}