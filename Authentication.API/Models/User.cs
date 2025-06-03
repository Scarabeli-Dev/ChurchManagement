using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Authentication.APIModels;

public class User : IdentityUser<Guid>
{
  [Column("cpf")]
  public string CPF { get; set; }

  [Column("user_roles")]
  public IEnumerable<UserRoles> UserRoles { get; set; }
}