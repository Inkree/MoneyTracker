using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Identity
{
    public class CustomAutenticationScheme
    {
        public CustomAutenticationScheme(string Name, string? DisplayName)
        {
            this.Name = Name;
            this.DisplayName = DisplayName;
        }
        
        public string? DisplayName { get; set; }
        public string Name { get; set; }
    }
}
