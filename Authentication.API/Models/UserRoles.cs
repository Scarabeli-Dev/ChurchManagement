using Microsoft.AspNetCore.Identity;

namespace Authentication.APIModels;

public class UserRoles : IdentityUserRole<Guid>
{
  public User User { get; set; }
  public Role Role { get; set; }
}