using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.models
{
    public class CategoryExpense
    {
        public CategoryExpense(string categoryId, string categoryName, string color, string svgContent, decimal totalSpent)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
            Color = color;
            SvgContent = svgContent;
            TotalSpent = totalSpent;
        }
        public CategoryExpense() {
            CategoryId = String.Empty;
            CategoryName = String.Empty;
            Color = String.Empty;
            SvgContent = String.Empty;
            TotalSpent = 0;
        }    

        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Color { get; set; }
        public string SvgContent { get; set; }
        public decimal TotalSpent { get; set; }
    }
}
