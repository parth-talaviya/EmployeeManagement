namespace UserManagement.Application.JwtTokenGenerator.Implementation;

[RegisterService(typeof(IJwtTokenGenerator))]
public sealed class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IOptions<JwtConnectionOptionsDto> _options;

    public JwtTokenGenerator(IOptions<JwtConnectionOptionsDto> options)
    {
        _options = options;
    }

    public (string AccessToken, string RefreshToken) GenerateTokens(LoginRequestViewModel loginRequestViewModel,
        List<UserRole> userRoles)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Value.Key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        List<Claim> claims = new List<Claim>();

        foreach (var role in userRoles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role.RoleName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, role.UserId.ToString()));
        }

        claims.Add(new Claim(ClaimTypes.Name, loginRequestViewModel.UserName));

        var accessToken = GenerateAccessToken(claims, creds);
        var userIdClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
        if (userIdClaim == null)
        {
            throw new InvalidOperationException("UserId claim not found.");
        }

        var refreshToken = GenerateRefreshToken(userIdClaim.Value);

        return (accessToken, refreshToken.RefreshToken);
    }

    private string GenerateAccessToken(List<Claim> claims, SigningCredentials creds)
    {
        var token = new JwtSecurityToken(
            issuer: _options.Value.Issuer,
            audience: _options.Value.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private RefreshTokenViewModel GenerateRefreshToken(string userId)
    {
        var refreshToken = new RefreshTokenViewModel
        {
            RefreshToken = Guid.NewGuid().ToString("N") + userId,
            RefreshTokenExpires = DateTime.UtcNow.AddDays(7)
        };

        return refreshToken;
    }

    public Task<ClaimsPrincipal> ValidateTokenAsync(string token)
    {
        var key = Encoding.UTF8.GetBytes(_options.Value.Key);

        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ClockSkew = TimeSpan.Zero
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);
        var jwtSecurityToken = securityToken as JwtSecurityToken;
        if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
        {
            throw new SecurityTokenException("Invalid token");
        }

        return Task.FromResult(principal);
    }

    public string GenerateNewAccessToken(ClaimsPrincipal claimsPrincipal)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Value.Key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _options.Value.Issuer,
            audience: _options.Value.Audience,
            claims: claimsPrincipal.Claims,
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}