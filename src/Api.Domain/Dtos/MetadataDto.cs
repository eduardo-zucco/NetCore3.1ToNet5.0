using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos
{
    public class MetadataDto
    {
        public string serviceApi { get; set; }
        public List<MetadataFieldDto> Fields { get; set; }
    }
}