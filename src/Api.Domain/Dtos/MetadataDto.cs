using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos
{
    public class MetadataDto
    {
        public int Version { get; set; }
        public string Title { get; set; }
        
        //public string ServiceApi { get; set; }
        public List<MetadataFieldDto> Fields { get; set; }
        public bool KeepFilters { get; set; }
    }
}