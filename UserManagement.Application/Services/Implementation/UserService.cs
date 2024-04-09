namespace UserManagement.Application.Services.Implementation;

[RegisterService(typeof(IUserService))]
public sealed class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRegisterRepository, IUserRoleRepository userRoleRepository, IMapper mapper)
    {
        _userRepository = userRegisterRepository;
        _userRoleRepository = userRoleRepository;
        _mapper = mapper;
    }

    public async Task<int> CreateUserAsync(CreateUserViewModel userViewModel, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<CreateUserViewModel, User>(userViewModel);
        var createdUser = await _userRepository.CreateUserAsync(user, cancellationToken).ConfigureAwait(false);

        var userId = await _userRepository.GetUserIdAsync(user.Name, cancellationToken).ConfigureAwait(false);

        if (userId == null)
        {
            throw new InvalidOperationException("Failed to retrieve user ID after creating the user.");
        }

        await _userRoleRepository.AddUserRoleByIdAsync(userId.Value, cancellationToken).ConfigureAwait(false);
        return createdUser;
    }

    public async Task<UserUpdateProfileViewModel?> EditUserAsync(UserUpdateProfileViewModel userUpdateProfileViewModel,
        CancellationToken cancellationToken)
    {
        var user = _mapper.Map<UserUpdateProfileViewModel, User>(userUpdateProfileViewModel);
        var updatedUser = await _userRepository.EditUserAsync(user, cancellationToken).ConfigureAwait(false);

        return updatedUser != null ? _mapper.Map<User, UserUpdateProfileViewModel>(updatedUser) : null;
    }

    public async Task<UserPasswordUpdateViewModel?> EditUserPasswordAsync(UserPasswordUpdateViewModel userViewModel,
        CancellationToken cancellationToken)
    {
        var user = _mapper.Map<UserPasswordUpdateViewModel, User>(userViewModel);
        var updatedUser = await _userRepository.EditUserPasswordAsync(user, cancellationToken).ConfigureAwait(false);

        return updatedUser != null ? _mapper.Map<User, UserPasswordUpdateViewModel>(updatedUser) : null;
    }

    public async Task<IEnumerable<UserViewModel>> GetAllUserAsync(CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllUserAsync(cancellationToken).ConfigureAwait(false);

        return _mapper.Map<List<UserViewModel>>(users);
    }

    public async Task<UserViewModel?> GetUserAsync(int id, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserAsync(id, cancellationToken).ConfigureAwait(false);

        return user != null ? _mapper.Map<UserViewModel>(user) : null;
    }

    public async Task<UserViewModel?> DeleteUserAsync(int id, CancellationToken cancellationToken)
    {
        var user = await _userRepository.DeleteUserAsync(id, cancellationToken).ConfigureAwait(false);

        return user != null ? _mapper.Map<UserViewModel>(user) : null;
    }
}