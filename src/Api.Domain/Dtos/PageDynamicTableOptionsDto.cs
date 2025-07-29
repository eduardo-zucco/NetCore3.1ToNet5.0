using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos
{
    public class PageDynamicTableOptionsDto
    {
        public string ServiceApi { get; set; }
        public string Title { get; set; }
        public List<MetadataFieldDto> Fields { get; set; }
        public PageDynamicTableActionDto Actions { get; set; }
        public List<PageDynamicTableCustomActionDto> CustomActions { get; set; }
        public bool KeepFilters { get; set; }

    }
}