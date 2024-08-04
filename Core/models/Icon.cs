using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.models
{
    public class Icon
    {
        public Icon(string id, string name, string url)
        {
            Id = id;
            Name = name;
            Url = url;
        }
        public Icon()
        {
            Id = String.Empty;
            Name = String.Empty;
            Url = String.Empty;
        }

        public string Id { get; set; }
        public string Name { get; set; }  
        public string Url { get; set; }
    }
}
