using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos
{
    public class PageDynamicTableActionDto
    {
        public string New { get; set; }
        public string Edit { get; set; }
        public string Detail { get; set; }
        public bool Delete { get; set; }
    }
}