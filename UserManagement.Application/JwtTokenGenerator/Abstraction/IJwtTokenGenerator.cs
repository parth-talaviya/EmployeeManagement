namespace UserManagement.Application.JwtTokenGenerator.Abstraction;

public interface IJwtTokenGenerator
{
    public (string AccessToken, string RefreshToken) GenerateTokens(LoginRequestViewModel loginRequestViewModel,
        List<UserRole> userRoles);

    Task<ClaimsPrincipal> ValidateTokenAsync(string token);

    public string GenerateNewAccessToken(ClaimsPrincipal claimsPrincipal);
}