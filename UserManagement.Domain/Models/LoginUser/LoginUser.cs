namespace UserManagement.Domain.Models.LoginUser;

public sealed class LoginUser
{
    public int Id { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public bool IsActive { get; set; }
}