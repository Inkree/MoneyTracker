using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.models
{
    public class Icon
    {
        public Icon(string id, string name, string svgContent)
        {
            Id = id;
            Name = name;
            SvgContent = svgContent;
        }
        public Icon()
        {
            Id = String.Empty;
            Name = String.Empty;
            SvgContent = String.Empty;
            Categories = new List<Category>();   
        }

        public string Id { get; set; }
        public string Name { get; set; }  
        public string SvgContent { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
