namespace UserManagement.ViewModel.Models.LoginUser;

public class RefreshTokenViewModel
{
    public string AccessToken { get; set; }

    public string RefreshToken { get; set; }

    [JsonIgnore] public DateTime RefreshTokenExpires { get; set; }

    [JsonIgnore] public string UserId { get; set; }
}