namespace UserManagement.Application.Services.Implementation;

[RegisterService(typeof(ILoginUserService))]
public sealed class LoginUserService : ILoginUserService
{
    private readonly IMapper _mapper;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly ILoginUserRepository _loginUserRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUserRoleRepository _userRoleRepository;

    public LoginUserService(
        IMapper mapper,
        IJwtTokenGenerator jwtTokenGenerator,
        ILoginUserRepository loginUserRepository,
        IUserRepository userRepository,
        IUserRoleRepository userRoleRepository)
    {
        _mapper = mapper;
        _jwtTokenGenerator = jwtTokenGenerator;
        _loginUserRepository = loginUserRepository;
        _userRepository = userRepository;
        _userRoleRepository = userRoleRepository;
    }

    public async Task<LoginRequestViewModel?> AuthenticateLoginUserAsync(LoginRequestViewModel loginViewModel,
        CancellationToken cancellationToken)
    {
        var loginUser = _mapper.Map<LoginRequestViewModel, LoginUser>(loginViewModel);

        await _loginUserRepository.AuthenticateLoginUserAsync(loginUser, cancellationToken).ConfigureAwait(false);

        var userId = await _userRepository.GetUserIdAsync(loginUser.UserName, cancellationToken).ConfigureAwait(false);

        if (userId == null)
        {
            return null;
        }

        var userRoles = await _userRoleRepository.GetUserRoleAsync(userId.Value, cancellationToken)
            .ConfigureAwait(false);
        var (accessToken, refreshToken) =
            _jwtTokenGenerator.GenerateTokens(loginViewModel, userRoles?.ToList() ?? new List<UserRole>());
        await _loginUserRepository.SaveRefreshTokenAsync(userId.Value, refreshToken, cancellationToken)
            .ConfigureAwait(false);
        loginViewModel.Token = accessToken;
        loginViewModel.RefreshToken = refreshToken;

        return loginViewModel;
    }

    public Task<string?> GetRefreshTokenAsync(int userId, CancellationToken cancellationToken)
    {
        return _loginUserRepository.GetRefreshTokenAsync(userId, cancellationToken);
    }
}