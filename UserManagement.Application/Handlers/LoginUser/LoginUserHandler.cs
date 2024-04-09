namespace UserManagement.Application.Handlers.LoginUser;

public sealed class LoginUserHandler : IRequestHandler<LoginUserCommand, LoginRequestViewModel?>
{
    private readonly ILoginUserService _loginUserService;

    public LoginUserHandler(ILoginUserService loginUserService)
    {
        _loginUserService = loginUserService;
    }

    public async Task<LoginRequestViewModel?> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        return await _loginUserService.AuthenticateLoginUserAsync(request.LoginUserViewModel, cancellationToken)
            .ConfigureAwait(false);
    }
}