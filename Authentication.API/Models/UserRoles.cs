using Microsoft.AspNetCore.Identity;

namespace Authentication.API.Models;

public class UserRoles : IdentityUserRole<Guid>
{
  public User User { get; set; }
  public Role Role { get; set; }
}