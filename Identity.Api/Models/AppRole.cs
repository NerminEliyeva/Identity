using Microsoft.AspNetCore.Identity;

namespace Identity.Api.Models
{
    public class AppRole : IdentityRole<int>
    {
        public DateTime CreateDate { get; set; }
    }
}
