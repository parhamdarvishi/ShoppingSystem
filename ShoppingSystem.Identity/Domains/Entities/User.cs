using Microsoft.AspNetCore.Identity;

namespace ShoppingSystem.Identity.Domains.Entities;

public class User: IdentityUser
{
    public string NationalCode { get; set; }
}
