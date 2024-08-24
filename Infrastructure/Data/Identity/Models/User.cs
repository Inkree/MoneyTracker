using Core.models;
using Microsoft.AspNetCore.Identity;


namespace Infrastructure.Data.Identity.Models
{
    public class User : IdentityUser
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public IEnumerable<Transaction>? Transactions { get; set; }
        public IEnumerable<Category>? Categories { get; set; }

    }
}
