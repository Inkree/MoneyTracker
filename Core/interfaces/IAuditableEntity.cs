using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.interfaces
{
    public interface IAuditableEntity
    {
        public string? CreatedBy { get; set; }
        public string? lastModifiedBy { get; set; }
        public DateTimeOffset? CreatedAt { get; set; } 
        public DateTimeOffset? lastModifiedAt { get; set; }
    }
}
