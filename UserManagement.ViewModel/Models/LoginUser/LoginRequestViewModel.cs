namespace UserManagement.ViewModel.Models.LoginUser;

public class LoginRequestViewModel
{
    public string UserName { get; set; }

    public string Password { get; set; }
    [JsonIgnore] public string Token { get; set; }
    [JsonIgnore] public string RefreshToken { get; set; }
}