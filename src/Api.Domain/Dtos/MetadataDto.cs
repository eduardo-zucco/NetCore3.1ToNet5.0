using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos
{
    public class MetadataDto
    {
        public int version { get; set; }
        public string title { get; set; }
        public string serviceApi { get; set; }
        public List<MetadataFieldDto> fields { get; set; }
        public bool keepFilters { get; set; }
    }
}