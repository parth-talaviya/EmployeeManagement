namespace UserManagement.ViewModel.Models.LoginUser;

public sealed class LoginResponseViewModel
{
    public string UserName { get; set; }

    public string Token { get; set; }

    public string RefreshToken { get; set; }
}