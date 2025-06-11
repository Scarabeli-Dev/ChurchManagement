namespace Authentication.API.Models.ViewModels
{
  public class RegisterViewModel
  {
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public string CPF { get; set; }
    public List<string> Roles { get; set; }
  }
}