namespace UserManagement.Application.Services.Abstraction;

public interface ILoginUserService
{
    Task<LoginRequestViewModel?> AuthenticateLoginUserAsync(LoginRequestViewModel loginViewModel,
        CancellationToken cancellationToken);

    Task<string?> GetRefreshTokenAsync(int userId, CancellationToken cancellationToken);
}