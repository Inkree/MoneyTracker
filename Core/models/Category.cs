using Core.interfaces;

namespace Core.models
{
    public class Category:BaseEntity,IAuditableEntity
    {
        public Category(string name,string svgContent,string color,string userId)
        {     
            Name = name;
            Color = color;
            UserId = userId;
            SvgContent = svgContent;
            Transactions = new List<Transaction>();
        }
        public Category()
        { 
            Name = String.Empty;
            Color = String.Empty;
            SvgContent = String.Empty;
            UserId = String.Empty;
            Transactions = new List<Transaction>();
        }
        public string Name { get; set; }      
        public string Color { get; set; }
        public string? UserId { get; set; }
        public string SvgContent { get; set; }
        public IEnumerable<Transaction>? Transactions { get; set; }
        string? IAuditableEntity.CreatedBy { get; set; }
        string? IAuditableEntity.lastModifiedBy { get; set; }
        DateTimeOffset? IAuditableEntity.CreatedAt { get; set; }
        DateTimeOffset? IAuditableEntity.lastModifiedAt { get; set; }
    }
}
