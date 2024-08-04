using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Identity
{
    public class ExternalAuthPropertiesDto
    {
        public string RedirectUri { get; set; }
        public string LoginProvider { get; set; }
        public IDictionary<string, string> Items { get; set; }

        public ExternalAuthPropertiesDto()
        {
            Items = new Dictionary<string, string>();
        }
    }
}
