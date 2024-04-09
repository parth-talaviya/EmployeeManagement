namespace UserManagement.Application.Handlers.RefreshToken;

public sealed class RefreshTokenHandler : IRequestHandler<RefreshTokenCommand, RefreshTokenViewModel>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly ILoginUserRepository _loginUserRepository;

    public RefreshTokenHandler(IJwtTokenGenerator jwtTokenGenerator, ILoginUserRepository loginUserRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _loginUserRepository = loginUserRepository;
    }

    public async Task<RefreshTokenViewModel> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var claimsPrincipal = await _jwtTokenGenerator.ValidateTokenAsync(request.RefreshTokenViewModel.AccessToken)
            .ConfigureAwait(false);
        var userIdClaim = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier);

        if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out var userId)) return null!;
        var refreshToken = await _loginUserRepository.GetRefreshTokenAsync(userId, cancellationToken)
            .ConfigureAwait(false);
        if (refreshToken == null) return null!;
        var refreshTokenViewModel = new RefreshTokenViewModel
        {
            RefreshToken = refreshToken
        };

        if (refreshTokenViewModel.RefreshToken != request.RefreshTokenViewModel.RefreshToken)
        {
            throw new UnauthorizedAccessException("Invalid refresh token.");
        }

        var newJwtToken = _jwtTokenGenerator.GenerateNewAccessToken(claimsPrincipal);
        refreshTokenViewModel.AccessToken = newJwtToken;
        return refreshTokenViewModel;
    }
}