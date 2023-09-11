using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Models
{
    public class User : IdentityUser<long>
    {
        public string Name { get; set; }

        public User(string userName, string name)
        {
            UserName = userName;
            Name = name;
        }
    }
}
