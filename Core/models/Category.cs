namespace Core.models
{
    public class Category
    {
        public Category(string id,string name,Icon icon,string color,string userId,string iconId)
        { 
            Id = id;
            Name = name;
            Icon = icon;
            Color = color;
            UserId = userId;
            IconId = iconId;
            Icon = new Icon();
            Transactions = new List<Transaction>();
        }
        public Category()
        { 
            Id = String.Empty;
            Name = String.Empty;
            Color = String.Empty;
            IconId = String.Empty;
            UserId = String.Empty;
            Icon = new Icon();
            Transactions = new List<Transaction>();
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string IconId { get; set; }
        public Icon Icon { get; set; }
        public string Color { get; set; }
        public string UserId { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }
        

    }
}
