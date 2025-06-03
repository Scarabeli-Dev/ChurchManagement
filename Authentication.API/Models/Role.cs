using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authentication.APIModels;

public class Role : IdentityRole<Guid>
{
  [Column("user_roles")]
  public IEnumerable<UserRoles> UserRoles { get; set; }
}