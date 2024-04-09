namespace UserManagement.Infrastructure.Abstraction;

public interface ILoginUserRepository
{
    Task<LoginUser?> AuthenticateLoginUserAsync(LoginUser loginUser, CancellationToken cancellationToken);

    Task SaveRefreshTokenAsync(int userId, string refreshToken, CancellationToken cancellationToken);

    Task<string?> GetRefreshTokenAsync(int userId, CancellationToken cancellationToken);
}