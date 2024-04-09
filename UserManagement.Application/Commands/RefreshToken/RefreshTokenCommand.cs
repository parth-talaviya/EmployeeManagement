namespace UserManagement.Application.Commands.RefreshToken;

public sealed class RefreshTokenCommand : IRequest<RefreshTokenViewModel>
{
    public RefreshTokenCommand(RefreshTokenViewModel refreshTokenViewModel)
    {
        RefreshTokenViewModel = refreshTokenViewModel;
    }

    public RefreshTokenViewModel RefreshTokenViewModel { get; }
}